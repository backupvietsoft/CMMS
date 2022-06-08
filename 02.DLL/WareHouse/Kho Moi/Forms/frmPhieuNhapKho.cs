using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using Commons.VS.Classes.Catalogue;

namespace WareHouse
{
    public partial class frmPhieuNhapKho_New : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Khai báo toàn cục
        /// </summary>
        private BindingSource BindingPhieuNhapKho = new BindingSource();
        private DataTable TbPhieuNhapKho = new DataTable();
        private DataTable TbPhieuNhapKhoPhuTung = new DataTable();
        private DataTable TbPhieuNhapKhoPhuTungChiTiet = new DataTable();
        private string TrangThai = String.Empty;
        private int flag = 0;
        private DataTable dt;
        private bool isFirst = false;
        private bool bUnLock = false;
        private bool bSuaSLGia = false;
        private bool bSua = false;
        private bool bXoa = false;
        private string sTong = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuNhapKho_New", "Total", Commons.Modules.TypeLanguage);
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public frmPhieuNhapKho_New()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// 
        private void LoadPhieuNhapKho()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            this.Cursor = Cursors.WaitCursor;
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            TbPhieuNhapKho = new DataTable();
            int kho = -1;
            string s_kho = Convert.ToString(lokWareHouse.EditValue);
            bool isLock = chkIsLock.Checked;
            if (!string.IsNullOrEmpty(s_kho))
                kho = Convert.ToInt32(s_kho);
            TbPhieuNhapKho.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_NHU_Y_GET_DON_HANG_NHAP", Commons.Modules.UserName, kho, datFromDate.DateTime, Convert.ToDateTime(datToDate.DateTime.ToShortDateString()).AddDays(1), isLock));
            foreach (DataColumn ClPhieuNhapKho in TbPhieuNhapKho.Columns)
            {
                ClPhieuNhapKho.AllowDBNull = true;
            }
            DateTime NgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();
            TbPhieuNhapKho.Columns["NGAY"].DefaultValue = NgayHT;
            TbPhieuNhapKho.Columns["GIO"].DefaultValue = NgayHT;
            TbPhieuNhapKho.Columns["LOCK"].DefaultValue = false;
            TbPhieuNhapKho.Columns["MS_DON_HANG"].ReadOnly = false;
            BindingPhieuNhapKho.DataSource = TbPhieuNhapKho;
            isFirst = true;
            LocData();
            this.Cursor = Cursors.Default;
            BtnSua.Enabled = true;
            try
            {
                if (DgvPhieuNhapKho.RowCount <= 0) BtnIn.Visible = false;
            }
            catch { BtnIn.Visible = false; }
        }

        private void InitializeDatabase()
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime NgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();
            DataTable dtTmp = new DataTable();
            try
            {
                Commons.Modules.SQLString = "0Load";
                datFromDate.DateTime = Convert.ToDateTime("01/" + NgayHT.Month + "/" + NgayHT.Year);
                datToDate.DateTime = NgayHT;
                if (Commons.Modules.sPrivate == "HUDA")
                {
                    DgvPhieuNhapKhoChiTiet.Columns["MS_PT_CT"].Visible = true;
                    DgvPhieuNhapKhoChiTiet.Columns["TEN_PT_CT"].Visible = true;
                }
                else
                {
                    DgvPhieuNhapKhoChiTiet.Columns["MS_PT_CT"].Visible = false;
                    DgvPhieuNhapKhoChiTiet.Columns["TEN_PT_CT"].Visible = false;
                }
                if (Commons.Modules.sPrivate == "CS")
                    btnAutoDH.Visible = true;
                else
                    btnAutoDH.Visible = false;


                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_KHO_DON_HANG_NHAP", Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(CboKho, dtTmp, "MS_KHO", "TEN_KHO", "");
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_KHO", Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(lokWareHouse, dtTmp, "MS_KHO", "TEN_KHO", "");
                lokWareHouse.ItemIndex = -1;



                //dtTmp = new DataTable();
                //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSERS"));
                //Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThukho, dtTmp, "USERNAME", "FULL_NAME", "");
                txtThuKho.Enabled = false;

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_NGUOI_NHAP_KHO", Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(CboNguoiNhap, dtTmp, "MS_NGUOI_NHAP", "TEN_NGUOI_NHAP", "");
                CboNguoiNhap.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                CboNguoiNhap.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                CboNguoiNhap.Properties.AutoSearchColumnIndex = 1;
                CboNguoiNhap.ItemIndex = 0;

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_DANG_NHAP_KHO"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(CboDangNhap, dtTmp, "MS_DANG_NHAP", "TEN_DANG_NHAP", "");
                CboDangNhap.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                CboDangNhap.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                CboDangNhap.Properties.AutoSearchColumnIndex = 1;
                CboDangNhap.ItemIndex = 0;

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_CON_LAM_VIEC"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNLap, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "");
                CboDangNhap.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                CboDangNhap.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                CboDangNhap.Properties.AutoSearchColumnIndex = 1;
                CboDangNhap.ItemIndex = 0;

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_DON_DAT_HANG_NHAP_KHO_1", Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(CboDDH, dtTmp, "MS_DON_DAT_HANG", "TEN_DON_DAT_HANG", "");
                CboDDH.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                CboDDH.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                CboDDH.Properties.AutoSearchColumnIndex = 1;
                CboDDH.ItemIndex = 0;

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GET_LY_DO_NHAP_KE_TOAN"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLyDoKT, dtTmp, "MS_LY_DO_NHAP_KT", "TEN_LY_DO_NHAP_KT", "");
                cboLyDoKT.ItemIndex = -1;

                Commons.Modules.SQLString = "";
                LoadPhieuNhapKho();


                BindingPhieuNhapKho.CurrentChanged += new EventHandler(BindingPhieuNhapKho_CurrentChanged);
                DgvPhieuNhapKho.AutoGenerateColumns = false;

                DgvPhieuNhapKho.DataSource = BindingPhieuNhapKho;

                DgvPhieuNhapKho.Columns["MS_DH_NHAP_PT"].DataPropertyName = "MS_DH_NHAP_PT";
                BindingControl();

                #region Load luoi phu tung
                DataTable TbNgoaiTe = new DataTable();
                TbNgoaiTe.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_NGOAI_TE_NHAP_KHO"));
                ((DataGridViewComboBoxColumn)DgvPhieuNhapKhoChiTiet.Columns["NGOAI_TE"]).DataSource = TbNgoaiTe;
                ((DataGridViewComboBoxColumn)DgvPhieuNhapKhoChiTiet.Columns["NGOAI_TE"]).ValueMember = "NGOAI_TE";
                ((DataGridViewComboBoxColumn)DgvPhieuNhapKhoChiTiet.Columns["NGOAI_TE"]).DisplayMember = "TEN_NGOAI_TE";




                try
                {
                    LoadPhuTung(((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString());
                    LoadChiPhi(((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString());
                }
                catch
                {
                    LoadPhuTung("-1");
                    LoadChiPhi("-1");
                }

                #endregion

                #region Loadluoi chi tiet

                //dtTmp = new DataTable();
                //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_VI_TRI_KHO"));
                //((DataGridViewComboBoxColumn)DgvViTriPhuTung.Columns["MS_VI_TRI"]).DataSource = dtTmp;
                //((DataGridViewComboBoxColumn)DgvViTriPhuTung.Columns["MS_VI_TRI"]).ValueMember = "MS_VI_TRI";
                //((DataGridViewComboBoxColumn)DgvViTriPhuTung.Columns["MS_VI_TRI"]).DisplayMember = "TEN_VI_TRI";

                try
                {
                    LoadViTri(((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString());
                }
                catch
                {
                    LoadViTri("-1");
                }
                try
                {
                    LocChiTiet(DgvPhieuNhapKhoChiTiet.CurrentRow.Index);
                }
                catch
                {
                    TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1";
                }

                #endregion
            }
            catch
            { }
            Commons.Modules.ObjSystems.MVisGrid(DgvPhieuNhapKhoChiTiet, "frmPhieuNhapKho_New", "DgvPhieuNhapKhoChiTiet", Commons.Modules.UserName);
            this.Cursor = Cursors.Default;
        }

        private void LoadPhuTung(string MsDHN)
        {
            this.Cursor = Cursors.WaitCursor;
            TbPhieuNhapKhoPhuTung = new DataTable();
            TbPhieuNhapKhoPhuTung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_DON_HANG_NHAP_VAT_TU", MsDHN));
            TbPhieuNhapKhoPhuTung.Columns["TONG_CP_NHAP_KHAU_VT"].ReadOnly = false;
            TbPhieuNhapKhoPhuTung.Columns["TONG_THUE_NK"].ReadOnly = false;
            TbPhieuNhapKhoPhuTung.Columns["TONG_PHI_VAN_CHUYEN"].ReadOnly = false;
            TbPhieuNhapKhoPhuTung.Columns["TONG_PHI_BAO_HIEM"].ReadOnly = false;
            TbPhieuNhapKhoPhuTung.Columns["TONG_THUE_NHA_THAU"].ReadOnly = false;
            TbPhieuNhapKhoPhuTung.Columns["TONG_PHI6"].ReadOnly = false;
            TbPhieuNhapKhoPhuTung.Columns["TONG_PHI7"].ReadOnly = false;
            TbPhieuNhapKhoPhuTung.Columns["TONG_PHI8"].ReadOnly = false;
            TbPhieuNhapKhoPhuTung.Columns["TONG_PHI9"].ReadOnly = false;
            TbPhieuNhapKhoPhuTung.Columns["TONG_CP_KHAC_VT"].ReadOnly = false;
            foreach (DataColumn ClPhieuNhapKhoPhuTung in TbPhieuNhapKhoPhuTung.Columns)
            {
                ClPhieuNhapKhoPhuTung.ReadOnly = false;
                ClPhieuNhapKhoPhuTung.AllowDBNull = true;
            }
            try
            {
                TbPhieuNhapKhoPhuTung.Columns["MS_DH_NHAP_PT"].DefaultValue = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"];
                TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString().Trim() + "'";
            }
            catch
            {
                TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "0=1";
            }
            DgvPhieuNhapKhoChiTiet.AutoGenerateColumns = false;
            DgvPhieuNhapKhoChiTiet.DataSource = TbPhieuNhapKhoPhuTung.DefaultView;
            foreach (DataGridViewColumn ClPhieuNhapKhoChiTiet in DgvPhieuNhapKhoChiTiet.Columns)
            {
                ClPhieuNhapKhoChiTiet.DataPropertyName = ClPhieuNhapKhoChiTiet.Name;
            }
            DgvPhieuNhapKhoChiTiet.Columns["TT_TAX"].DefaultCellStyle.NullValue = "";
            DgvPhieuNhapKhoChiTiet.Columns["ID"].Visible = false;
            AnHienCotChiPhi();
            this.Cursor = Cursors.Default;
        }
        private void LoadViTri(string MsDHN)
        {
            this.Cursor = Cursors.WaitCursor;
            TbPhieuNhapKhoPhuTungChiTiet = new DataTable();
            TbPhieuNhapKhoPhuTungChiTiet.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                "SP_Y_GET_DON_HANG_NHAP_VAT_TU_CHI_TIET", MsDHN));
            foreach (DataColumn ClPhieuNhapKhoPhuTungChiTiet in TbPhieuNhapKhoPhuTungChiTiet.Columns)
            {
                ClPhieuNhapKhoPhuTungChiTiet.ReadOnly = false;
                ClPhieuNhapKhoPhuTungChiTiet.AllowDBNull = true;
            }
            DgvViTriPhuTung.AutoGenerateColumns = false;
            DgvViTriPhuTung.DataSource = TbPhieuNhapKhoPhuTungChiTiet;
            foreach (DataGridViewColumn ClPhieuNhapKhoPhuTungChiTiet in DgvViTriPhuTung.Columns)
            {
                ClPhieuNhapKhoPhuTungChiTiet.DataPropertyName = ClPhieuNhapKhoPhuTungChiTiet.Name;
            }


            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Điều khiển form
        /// </summary>
        private void InitializeForm()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                TxtMSDHN.Enabled = false;
                datNgayNhap.Enabled = false;
                MskGioNhap.Enabled = false;

                switch (TrangThai)
                {
                    case "Add":
                    case "Edit":

                        if (!((DataRowView)BindingPhieuNhapKho.Current).Row.IsNull("LOCK") && ((DataRowView)BindingPhieuNhapKho.Current).Row["LOCK"].Equals(true))
                        {

                            TxtSoDHN.Enabled = false;
                            txtLPN.Enabled = false;

                            CboKho.Enabled = false;
                            CboNguoiNhap.Enabled = false;
                            btnTimNCty.Enabled = false;
                            MskNgayCT.Enabled = true;
                            CboDangNhap.Enabled = false;
                            TxtSoCT.Enabled = true;
                            CboDDH.Enabled = false;
                            txtThuKho.Enabled = false;
                            MskDiem1.Enabled = true;
                            TxtDanhGia.Enabled = true;
                            MskDiem2.Enabled = true;
                            TxtGhiChu.Enabled = true;
                            MskDiem3.Enabled = true;

                            DgvPhieuNhapKho.ReadOnly = true;
                            DgvPhieuNhapKho.Enabled = false;
                            DgvPhieuNhapKho.AllowUserToAddRows = false;
                            DgvPhieuNhapKho.AllowUserToDeleteRows = false;
                            DgvPhieuNhapKhoChiTiet.ReadOnly = false;

                            foreach (DataGridViewColumn col in DgvPhieuNhapKhoChiTiet.Columns)
                                col.ReadOnly = true;

                            grdChiPhi.ReadOnly = true;
                            foreach (DataGridViewColumn col in grdChiPhi.Columns)
                                col.ReadOnly = true;
                            grdChiPhi.AllowUserToAddRows = false;
                            grdChiPhi.AllowUserToDeleteRows = false;

                            DgvPhieuNhapKhoChiTiet.Columns["MS_PT_CT"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TEN_PT_CT"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.AllowUserToAddRows = false;
                            DgvPhieuNhapKhoChiTiet.AllowUserToDeleteRows = false;

                            DgvViTriPhuTung.Enabled = false;
                            DgvViTriPhuTung.ReadOnly = true;
                            DgvViTriPhuTung.AllowUserToAddRows = false;
                            DgvViTriPhuTung.AllowUserToDeleteRows = false;

                            BtnLuu.Visible = true;
                            BtnHuy.Visible = true;
                            BtnThem.Visible = false;
                            BtnSua.Visible = false;
                            BtnXoa.Visible = false;
                            BtnIn.Visible = false;
                            BtnThoat.Visible = false;
                            BtnLock.Visible = false;
                            btnUnLock.Visible = false;
                            BtnChonPT.Visible = false;
                            btnCP1.Visible = false;
                            btnCPAll.Visible = false;
                            btnAutoDH.Visible = false;
                            tblCondition.Enabled = false;
                            TxtLyDo.Enabled = true;
                            TxtCancu.Enabled = true;
                            cboNLap.Enabled = true;
                            TxtThuKhoKy.Enabled = true;
                            TxtNguoiGiao.Enabled = true;
                            txtBSXE.Enabled = true;
                            cboLyDoKT.Enabled = true;
                        }
                        else
                        {
                            TxtSoDHN.Enabled = true;
                            txtLPN.Enabled = false;


                            CboKho.Enabled = true;
                            CboNguoiNhap.Enabled = true;
                            btnTimNCty.Enabled = true;
                            MskNgayCT.Enabled = true;
                            CboDangNhap.Enabled = true;
                            TxtSoCT.Enabled = true;
                            CboDDH.Enabled = true;
                            txtThuKho.Enabled = false;
                            MskDiem1.Enabled = true;
                            TxtDanhGia.Enabled = true;
                            MskDiem2.Enabled = true;
                            TxtGhiChu.Enabled = true;
                            MskDiem3.Enabled = true;

                            if (TrangThai.Equals("Edit"))
                            {
                                CboDangNhap.Enabled = false;
                                CboDDH.Enabled = false;
                                CboKho.Enabled = false;
                            }
                            DgvPhieuNhapKho.ReadOnly = true;
                            DgvPhieuNhapKho.Enabled = false;
                            DgvPhieuNhapKho.AllowUserToAddRows = false;
                            DgvPhieuNhapKho.AllowUserToDeleteRows = false;

                            DgvPhieuNhapKhoChiTiet.Enabled = true;
                            DgvPhieuNhapKhoChiTiet.ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.AllowUserToAddRows = false;
                            DgvPhieuNhapKhoChiTiet.AllowUserToDeleteRows = false;
                            foreach (DataGridViewColumn ClPhieuNhapKhoChiTiet in DgvPhieuNhapKhoChiTiet.Columns)
                            {
                                ClPhieuNhapKhoChiTiet.ReadOnly = true;
                            }

                            DgvPhieuNhapKhoChiTiet.Columns["MS_PT_CT"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TEN_PT_CT"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["SO_LUONG_CTU"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["SL_THUC_NHAP"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["Tax"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TT_TAX"].ReadOnly = false;

                            if (Commons.Modules.sPrivate.ToUpper() != "ACECOOK")
                            {
                                DgvPhieuNhapKhoChiTiet.Columns["TY_GIA"].ReadOnly = false;
                                DgvPhieuNhapKhoChiTiet.Columns["TY_GIA_USD"].ReadOnly = false;
                            }
                            if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED")
                            {
                                DgvPhieuNhapKhoChiTiet.Columns["NGOAI_TE"].ReadOnly = true;
                                DgvPhieuNhapKhoChiTiet.Columns["TY_GIA"].ReadOnly = true;
                            }
                            else
                            {
                                DgvPhieuNhapKhoChiTiet.Columns["TY_GIA"].ReadOnly = false;
                                DgvPhieuNhapKhoChiTiet.Columns["NGOAI_TE"].ReadOnly = false;
                            }

                            DgvPhieuNhapKhoChiTiet.Columns["BAO_HANH_DEN_NGAY"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["GHI_CHU"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["XUAT_XU"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["DON_GIA_GOC"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_CP_NHAP_KHAU_VT"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_THUE_NK"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI_VAN_CHUYEN"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI_BAO_HIEM"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_THUE_NHA_THAU"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI6"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI7"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI8"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI9"].ReadOnly = false;
                            DgvPhieuNhapKhoChiTiet.Columns["TONG_CP_KHAC_VT"].ReadOnly = false;

                            grdChiPhi.Enabled = true;
                            grdChiPhi.ReadOnly = false;
                            grdChiPhi.AllowUserToAddRows = false;
                            grdChiPhi.AllowUserToDeleteRows = false;

                            foreach (DataGridViewColumn ClChiPhi in grdChiPhi.Columns)
                            {
                                ClChiPhi.ReadOnly = true;
                            }
                            try
                            {
                                grdChiPhi.Columns["DANG_PB"].ReadOnly = false;
                                grdChiPhi.Columns["cboDANG_PB"].ReadOnly = false;
                                grdChiPhi.Columns["TONG_CP"].ReadOnly = false;
                                grdChiPhi.Columns["GHI_CHU"].ReadOnly = false;
                            }
                            catch { }

                            DgvViTriPhuTung.Enabled = true;
                            DgvViTriPhuTung.ReadOnly = false;
                            DgvViTriPhuTung.AllowUserToAddRows = false;
                            DgvViTriPhuTung.AllowUserToDeleteRows = false;
                            foreach (DataGridViewColumn ClPhieuNhapKhoPhuTungChiTiet in DgvViTriPhuTung.Columns)
                            {
                                ClPhieuNhapKhoPhuTungChiTiet.ReadOnly = true;
                            }
                            DgvViTriPhuTung.Columns["SL_VT"].ReadOnly = false;

                            BtnLuu.Visible = true;
                            btnCP1.Visible = true;
                            btnCPAll.Visible = true;
                            BtnHuy.Visible = true;
                            BtnThem.Visible = false;
                            BtnSua.Visible = false;
                            BtnXoa.Visible = false;
                            BtnIn.Visible = false;
                            BtnThoat.Visible = false;
                            BtnLock.Visible = false;
                            btnUnLock.Visible = false;
                            BtnChonPT.Visible = true;
                            btnAutoDH.Visible = false;

                            TxtLyDo.Enabled = true;
                            TxtCancu.Enabled = true;
                            cboNLap.Enabled = true;
                            cboNLap.Enabled = true;
                            TxtThuKhoKy.Enabled = true;
                            TxtNguoiGiao.Enabled = true;
                            txtBSXE.Enabled = true;
                            cboLyDoKT.Enabled = true;
                        }
                        break;
                    default:
                        TxtSoDHN.Enabled = false;
                        txtLPN.Enabled = true;


                        CboKho.Enabled = false;
                        CboNguoiNhap.Enabled = false;
                        btnTimNCty.Enabled = false;
                        MskNgayCT.Enabled = false;
                        CboDangNhap.Enabled = false;
                        TxtSoCT.Enabled = false;
                        MskGioNhap.Enabled = false;
                        CboDDH.Enabled = false;
                        MskDiem1.Enabled = false;
                        TxtDanhGia.Enabled = false;
                        MskDiem2.Enabled = false;
                        TxtGhiChu.Enabled = false;
                        MskDiem3.Enabled = false;
                        txtThuKho.Enabled = false;

                        DgvPhieuNhapKho.ReadOnly = true;
                        DgvPhieuNhapKho.Enabled = true;
                        DgvPhieuNhapKho.AllowUserToAddRows = false;
                        DgvPhieuNhapKho.AllowUserToDeleteRows = false;

                        DgvPhieuNhapKhoChiTiet.Enabled = true;
                        DgvPhieuNhapKhoChiTiet.ReadOnly = true;
                        DgvPhieuNhapKhoChiTiet.AllowUserToAddRows = false;
                        DgvPhieuNhapKhoChiTiet.AllowUserToDeleteRows = true;

                        grdChiPhi.Enabled = true;
                        grdChiPhi.ReadOnly = true;
                        grdChiPhi.AllowUserToAddRows = false;
                        grdChiPhi.AllowUserToDeleteRows = false;

                        DgvViTriPhuTung.Enabled = true;
                        DgvViTriPhuTung.ReadOnly = true;
                        DgvViTriPhuTung.AllowUserToAddRows = false;
                        DgvViTriPhuTung.AllowUserToDeleteRows = false;

                        BtnLuu.Visible = false;
                        btnCP1.Visible = false;
                        btnCPAll.Visible = false;
                        BtnHuy.Visible = false;
                        BtnThem.Visible = true;
                        BtnChonPT.Visible = false;
                        BtnThoat.Visible = true;

                        TxtLyDo.Enabled = false;
                        TxtCancu.Enabled = false;
                        cboNLap.Enabled = false;
                        cboNLap.Enabled = false;
                        TxtThuKhoKy.Enabled = false;
                        TxtNguoiGiao.Enabled = false;
                        txtBSXE.Enabled = false;
                        cboLyDoKT.Enabled = false;

                        if (BindingPhieuNhapKho.Count > 0)
                        {
                            BtnSua.Visible = true;
                            BtnXoa.Visible = true;
                            BtnIn.Visible = true;
                            BtnLock.Visible = true;
                            btnUnLock.Visible = true;
                        }
                        else
                        {
                            BtnSua.Visible = false;
                            BtnXoa.Visible = false;
                            BtnIn.Visible = false;
                            BtnLock.Visible = false;
                            btnUnLock.Visible = false;
                        }
                        break;
                }

                if (TrangThai == "Add")
                {
                    datNgayNhap.Enabled = true;
                    MskGioNhap.Enabled = true;
                    datNgayNhap.Properties.ReadOnly = false;
                    MskGioNhap.ReadOnly = false;
                    txtThuKho.Text = Commons.Modules.UserName;
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["THU_KHO"] = Commons.Modules.UserName;
                    tblCondition.Enabled = false;
                }
                else
                {
                    if (TrangThai != "Edit")
                    {
                        datNgayNhap.Enabled = false;
                        MskGioNhap.Enabled = false;
                        tblCondition.Enabled = true;
                    }
                    else
                    {
                        if (CboDDH.Text.Trim() != "")
                        {
                            CboNguoiNhap.Enabled = false;
                            btnTimNCty.Enabled = false;
                        }
                        tblCondition.Enabled = false;
                    }
                }

                InitializeControl();
            }
            catch { }
            this.Cursor = Cursors.Default;


        }

        /// <summary>
        /// Gắn source
        /// </summary>
        private void BindingControl()
        {
            this.Cursor = Cursors.WaitCursor;
            TxtMSDHN.DataBindings.Clear();
            TxtMSDHN.DataBindings.Add("Text", BindingPhieuNhapKho, "MS_DH_NHAP_PT", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            TxtSoDHN.DataBindings.Clear();
            TxtSoDHN.DataBindings.Add("Text", BindingPhieuNhapKho, "SO_PHIEU_XN", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            datNgayNhap.DataBindings.Clear();
            datNgayNhap.DataBindings.Add("Text", BindingPhieuNhapKho, "NGAY", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value, "dd/MM/yyyy");

            CboKho.DataBindings.Clear();
            CboKho.DataBindings.Add("EditValue", BindingPhieuNhapKho, "MS_KHO", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);

            txtThuKho.DataBindings.Clear();
            txtThuKho.DataBindings.Add("Text", BindingPhieuNhapKho, "THU_KHO", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);

            MskGioNhap.DataBindings.Clear();
            MskGioNhap.DataBindings.Add("Text", BindingPhieuNhapKho, "GIO", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value, "HH:mm:ss");
            CboDangNhap.DataBindings.Clear();
            CboDangNhap.DataBindings.Add("EditValue", BindingPhieuNhapKho, "MS_DANG_NHAP", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            MskNgayCT.DataBindings.Clear();
            MskNgayCT.DataBindings.Add("Text", BindingPhieuNhapKho, "NGAY_CHUNG_TU", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value, "dd/MM/yyyy");

            TxtLyDo.DataBindings.Clear();
            TxtLyDo.DataBindings.Add("Text", BindingPhieuNhapKho, "LY_DO");
            TxtCancu.DataBindings.Clear();
            TxtCancu.DataBindings.Add("Text", BindingPhieuNhapKho, "CAN_CU");

            cboNLap.DataBindings.Clear();
            cboNLap.DataBindings.Add("Text", BindingPhieuNhapKho, "NGUOI_LAP");

            TxtThuKhoKy.DataBindings.Clear();
            TxtThuKhoKy.DataBindings.Add("Text", BindingPhieuNhapKho, "THU_KHO_KY");
            TxtNguoiGiao.DataBindings.Clear();
            TxtNguoiGiao.DataBindings.Add("Text", BindingPhieuNhapKho, "NGUOI_GIAO");
            txtBSXE.DataBindings.Clear();
            txtBSXE.DataBindings.Add("Text", BindingPhieuNhapKho, "BSXE");
            cboLyDoKT.DataBindings.Clear();
            cboLyDoKT.DataBindings.Add("EditValue", BindingPhieuNhapKho, "MS_LY_DO_NHAP_KT", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            try
            {
                btnAutoDH.Visible = false;
                if (Commons.Modules.sPrivate == "CS")
                {
                    if (!CboDangNhap.EditValue.ToString().Equals("3"))
                    {
                        if (TbPhieuNhapKho.Rows.Count > 0)
                        {
                            if (DgvPhieuNhapKhoChiTiet.Rows.Count > 0)
                                btnAutoDH.Visible = true;
                            else
                                btnAutoDH.Visible = false;
                        }
                    }
                    else
                        btnAutoDH.Visible = false;

                }
            }
            catch { }
            TxtSoCT.DataBindings.Clear();
            TxtSoCT.DataBindings.Add("Text", BindingPhieuNhapKho, "SO_CHUNG_TU");


            CboDDH.DataBindings.Clear();
            CboDDH.DataBindings.Add("EditValue", BindingPhieuNhapKho, "MS_DON_HANG");

            MskDiem1.DataBindings.Clear();
            MskDiem1.DataBindings.Add("Text", BindingPhieuNhapKho, "DIEM");
            MskDiem2.DataBindings.Clear();
            MskDiem2.DataBindings.Add("Text", BindingPhieuNhapKho, "DIEM1");
            MskDiem3.DataBindings.Clear();
            MskDiem3.DataBindings.Add("Text", BindingPhieuNhapKho, "DIEM2");
            TxtDanhGia.DataBindings.Clear();
            TxtDanhGia.DataBindings.Add("Text", BindingPhieuNhapKho, "DANH_GIA");
            TxtGhiChu.DataBindings.Clear();
            TxtGhiChu.DataBindings.Add("Text", BindingPhieuNhapKho, "GHI_CHU");

            CboNguoiNhap.DataBindings.Clear();
            CboNguoiNhap.DataBindings.Add("EditValue", BindingPhieuNhapKho, "NGUOI_NHAP", true, DataSourceUpdateMode.OnPropertyChanged);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Chọn dữ liệu mới
        /// </summary>        
        void BindingPhieuNhapKho_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPhuTung(((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString());
                #region Load chi phi
                LoadChiPhi(((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString());
                #endregion
                TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "SL_VT > 0 AND MS_PT = '" + DgvPhieuNhapKhoChiTiet.Rows[DgvPhieuNhapKhoChiTiet.CurrentCell.RowIndex].Cells["MS_PT"].Value.ToString() + "' AND MS_DH_NHAP_PT = '" + TxtMSDHN.Text + "'";
            }
            catch
            {
                TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "0=1";
            }
            //Loc luoi vi tri



            try
            {
                LoadViTri(((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString());
            }
            catch
            {
                LoadViTri("-1");
            }
            try
            {
                LocChiTiet(DgvPhieuNhapKhoChiTiet.CurrentRow.Index);
            }
            catch { TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1"; }
            InitializeControl();
            LoadTongThanhTien();
            InitializeControl();
        }

        private void LoadTongThanhTien()
        {
            txtTongSL.Text = "0";
            txtTongTT.Text = "0";
            txtTongTTST.Text = "0";
            txtTongThue.Text = "0";
            try
            {
                DataView DvTmp = new DataView();
                DvTmp = (DataView)DgvPhieuNhapKhoChiTiet.DataSource;
                Double dTong = Convert.ToDouble((DvTmp.ToTable()).Compute("Sum(SL_THUC_NHAP)", ""));
                txtTongSL.Text = dTong.ToString(Commons.Modules.sSoLeSL);
                dTong = Convert.ToDouble((DvTmp.ToTable()).Compute("Sum(THANH_TIEN_VND)", ""));
                txtTongTT.Text = dTong.ToString(Commons.Modules.sSoLeTT);

                dTong = Convert.ToDouble((DvTmp.ToTable()).Compute("Sum(THANH_TIEN)", ""));
                txtTongTTST.Text = dTong.ToString(Commons.Modules.sSoLeTT);

                dTong = Convert.ToDouble((DvTmp.ToTable()).Compute("Sum(TT_TAX)", ""));
                txtTongThue.Text = dTong.ToString(Commons.Modules.sSoLeTT);

            }
            catch { }
        }

        /// <summary>
        /// Chi tiết trên vị trí
        /// </summary>  
        private void InitializeControl()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (TrangThai != "Add" && TrangThai != "Edit")
                {
                    if (!((DataRowView)BindingPhieuNhapKho.Current).Row.IsNull("LOCK") && ((DataRowView)BindingPhieuNhapKho.Current).Row["LOCK"].Equals(true))
                    {
                        BtnLuu.Visible = false;
                        btnCP1.Visible = false;
                        btnCPAll.Visible = false;
                        BtnHuy.Visible = false;
                        BtnThem.Visible = true;
                        BtnSua.Visible = false;
                        BtnXoa.Visible = false;
                        BtnIn.Visible = true;
                        BtnThoat.Visible = true;
                        BtnLock.Visible = false;
                        if (bUnLock)
                        {
                            btnUnLock.Visible = true;
                            BtnSua.Visible = false;
                        }
                        BtnChonPT.Visible = false;
                    }
                    else
                    {
                        BtnLuu.Visible = false;
                        btnCP1.Visible = false;
                        btnCPAll.Visible = false;
                        BtnHuy.Visible = false;
                        BtnThem.Visible = true;
                        BtnSua.Visible = true;
                        BtnXoa.Visible = true;
                        BtnIn.Visible = true;
                        BtnThoat.Visible = true;
                        BtnLock.Visible = true;
                        btnUnLock.Visible = false;
                        BtnChonPT.Visible = false;
                    }
                    try
                    {
                        btnAutoDH.Visible = false;
                        if (Commons.Modules.sPrivate == "CS")
                        {
                            if (!CboDangNhap.EditValue.ToString().Equals("3"))
                            {
                                if (TbPhieuNhapKho.Rows.Count > 0)
                                {
                                    if (DgvPhieuNhapKhoChiTiet.Rows.Count > 0)
                                        btnAutoDH.Visible = true;
                                    else
                                        btnAutoDH.Visible = false;
                                }
                            }
                            else
                                btnAutoDH.Visible = false;



                        }
                    }
                    catch { }
                    LocDangNhap(false);


                }
                else
                {
                    LocDangNhap(true);
                }
            }
            catch
            {
                if (bUnLock)
                {
                    btnUnLock.Visible = true;
                    BtnSua.Visible = false;
                }
                BtnChonPT.Visible = false;
                try
                {
                    if (Commons.Modules.sPrivate == "CS")
                    {
                        if (!CboDangNhap.EditValue.ToString().Equals("3"))
                        {
                            if (TbPhieuNhapKho.Rows.Count > 0)
                                btnAutoDH.Visible = true;
                        }
                        else
                            btnAutoDH.Visible = false;
                    }
                }
                catch
                {
                    btnAutoDH.Visible = false;
                }
                LocDangNhap(false);
            }

            if (Commons.Modules.PermisString.ToUpper() == "READ ONLY")
            {
                BtnThem.Visible = false;
                BtnSua.Visible = false;
                BtnXoa.Visible = false;
                btnUnLock.Visible = false;
                BtnLock.Visible = false;
                if (BindingPhieuNhapKho.Count > 0 && TrangThai != "Add" && TrangThai != "Edit")
                    BtnIn.Visible = true;
                else
                    BtnIn.Visible = false;
            }
            else
            {
                if (!bSua) BtnSua.Visible = false;
                if (!bXoa) BtnXoa.Visible = false;

            }


            this.Cursor = Cursors.Default;

        }

        /// <summary>
        /// Load form
        /// </summary>
        private void frmPhieuNhapKho_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Unlock phieu nhap
            DataTable dtTmp = new DataTable();
            bUnLock = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 18);
            bSua = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 4);
            bXoa = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 10);
            InitializeDatabase();
            InitializeForm();
            try
            {

                TbPhieuNhapKhoPhuTung.Columns["MS_DH_NHAP_PT"].DefaultValue = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"];
                TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString().Trim() + "'";
            }
            catch
            {
                TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "0=1";
            }
            //Loc luoi vi tri
            try
            {
                LocChiTiet(DgvPhieuNhapKhoChiTiet.CurrentRow.Index);
            }
            catch { TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1"; }
            btnTimNCty.Text = "...";

            try
            {
                DgvViTriPhuTung.Columns["MS_PTVT"].Visible = false;
                DgvViTriPhuTung.Columns["IDVT"].Visible = false;
            }
            catch { }

            DgvPhieuNhapKhoChiTiet.Columns["TY_GIA"].DefaultCellStyle.Format = "N6";
            DgvPhieuNhapKhoChiTiet.Columns["TY_GIA_USD"].DefaultCellStyle.Format = "N6";
            DgvPhieuNhapKhoChiTiet.Columns["DON_GIA_USD"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeDG.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["THANH_TIEN_USD"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeTT.ToString();

            DgvPhieuNhapKhoChiTiet.Columns["SL_THUC_NHAP"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["SO_LUONG_CTU"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["SL_THUC_NHAP"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["DON_GIA"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeDG.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["THANH_TIEN"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeTT.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["THANH_TIEN_VND"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeTT.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["THANH_TIEN_ST"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeTT.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TAX"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TT_TAX"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeTT.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["DON_GIA_VND"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeDG.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["DON_GIA_GOC"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeDG.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["DON_GIA_GOC_VND"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeDG.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_CP_NHAP_KHAU_VT"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_THUE_NK"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI_VAN_CHUYEN"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI_BAO_HIEM"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_THUE_NHA_THAU"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI6"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI7"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI8"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_PHI9"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_CP_KHAC_VT"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            DgvPhieuNhapKhoChiTiet.Columns["TONG_CP"].DefaultCellStyle.Format = "N" + Commons.Modules.iSoLeSL.ToString();
            this.Cursor = Cursors.Default;
            Commons.Modules.ObjSystems.ThayDoiNN(this);

            btnTimNCty.Text = "...";
            if (DgvPhieuNhapKho.RowCount == 0) chkIsLock_CheckedChanged(null, null);
            if (DgvPhieuNhapKho.RowCount == 1) chkIsLock_CheckedChanged(null, null);
            LoadTongThanhTien();
        }

        private void LocDangNhap(Boolean bThemSua)
        {
            if (CboDangNhap.Properties.DataSource == null) return;
            if (TrangThai.ToUpper() == "EDIT") return;
            if (bThemSua)
                ((DataTable)CboDangNhap.Properties.DataSource).DefaultView.RowFilter = " MS_DANG_NHAP NOT IN (9,10)";
            else
                ((DataTable)CboDangNhap.Properties.DataSource).DefaultView.RowFilter = "";
        }
        /// <summary>
        /// Thêm dữ liệu
        /// </summary> 
        /// 
        int checkDataSouce = 0;
        private void BtnThem_Click(object sender, EventArgs e)
        {
            txtLPN.Text = "";
            this.Cursor = Cursors.WaitCursor;
            TabDHNCT.SelectedTabPageIndex = 0;
            TrangThai = "Add";
            Commons.Modules.SQLString = "BtnThem";
            if (chkIsLock.Checked == true)
                chkIsLock.Checked = false;

            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DgvPhieuNhapKho.AllowUserToAddRows = true;
            checkDataSouce = BindingPhieuNhapKho.Count;
            BindingPhieuNhapKho.AddNew();

            DateTime dtNgayHT = Commons.Modules.ObjSystems.GetNgayHeThong();

            MskNgayCT.Text = dtNgayHT.ToString("dd/MM/yyyy");
            datNgayNhap.DateTime = dtNgayHT.Date;

            TxtMSDHN.Text = Vietsoft.Information.GetID("PN", dtNgayHT);
            ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"] = TxtMSDHN.Text;
            ((DataRowView)BindingPhieuNhapKho.Current).Row["NGAY"] = dtNgayHT.ToString("dd/MM/yyyy");
            ((DataRowView)BindingPhieuNhapKho.Current).Row["GIO"] = dtNgayHT.ToString("HH:mm:ss");


            InitializeForm();
            Commons.Modules.SQLString = "";
            CboDangNhap_EditValueChanged(sender, e);
            if (Commons.Modules.iDefault == 1 | Commons.Modules.iDefault == 2)
            {
                TxtSoDHN.Text = TxtMSDHN.Text;
                ((DataRowView)BindingPhieuNhapKho.Current).Row["SO_PHIEU_XN"] = TxtMSDHN.Text;
            }

            if (Commons.Modules.iDefault == 2) TxtSoDHN.Enabled = false;

            cboNLap.EditValue = Commons.Modules.sMaNhanVienMD;
            if (Commons.Modules.iMaKhoMD != -1)
            {
                try
                {
                    CboKho.EditValue = Commons.Modules.iMaKhoMD;
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_KHO"] = Commons.Modules.iMaKhoMD;
                }
                catch { }
            }


            LoadChiPhi(TxtMSDHN.Text);
            TxtSoDHN.Focus();

            if (BtnLuu.Visible == true)
            {
                if (TabDHNCT.SelectedTabPageIndex == 0)
                {
                    btnCP1.Visible = false;
                    btnCPAll.Visible = false;
                    BtnChonPT.Visible = true;
                }
                else if (TabDHNCT.SelectedTabPageIndex == 1)
                {
                    btnCP1.Visible = true;
                    btnCPAll.Visible = true;
                    BtnChonPT.Visible = false;
                }
            }
            txtTimVTri.Enabled = true;

            this.Cursor = Cursors.Default;
        }

        public static string GetID(string FieldName, string TableName, int lenAutoNo, string FirstString, string LastString, string strWhere)
        {
            try
            {
                int lenFirst = FirstString.ToString().Length;
                int lenLast = LastString.ToString().Length;
                float intCount = 0;
                string strMs = "";
                string strSql = "";
                if (strWhere.Length != 0) strWhere = " AND " + strWhere;

                lenFirst = lenFirst + lenLast;
                strSql = "SELECT ISNULL( MAX(CONVERT(REAL, RIGHT(LEFT(" + FieldName + ",LEN(" + FieldName + ") - " + lenLast +
                        "),LEN(" + FieldName + ")-(" + lenFirst + ")))) ,0) AS KEY_NEW " +
                        " FROM " + TableName + " " +
                        " WHERE LEFT(" + FieldName + "," + lenFirst + ")='" + FirstString + "'" +
                        " AND RIGHT(" + FieldName + "," + lenLast + ")='" + LastString + "' " + strWhere + " ORDER BY KEY_NEW  ";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, strSql));
                if (dtTmp.Rows.Count > 0) intCount = int.Parse(dtTmp.Rows[0]["KEY_NEW"].ToString());
                intCount += 1;
                if (lenAutoNo == 0) strMs = intCount.ToString();
                else
                {
                    if (lenAutoNo < intCount.ToString().Length)
                    {
                        //kiem tra neu ma ma so tang tu dong tang cao hon voi so max cua chieu dai so thi bao loi
                        MessageBox.Show("Overload ID! Please check info!");
                        return null;
                    }
                    for (int i = 0; i <= lenAutoNo; i++)
                    {
                        strMs = strMs + "0";
                    }
                }

                if (intCount.ToString().Length == lenAutoNo) return FirstString + intCount.ToString();
                strMs = strMs + intCount;
                strMs = strMs.Substring(strMs.Length - lenAutoNo);
                return FirstString + strMs;


            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>        
        private void BtnSua_Click(object sender, EventArgs e)
        {
            //nếu dạng nhập là chuyển kho thì select về tab đâu tiên
            if (Convert.ToInt32(CboDangNhap.EditValue) == 9 && TabDHNCT.SelectedTabPage == tabChiPhi)
            {
                TabDHNCT.SelectedTabPage = TabPT;
            }
            this.Cursor = Cursors.WaitCursor;
            TrangThai = "Edit";
            if ((int)CboDangNhap.EditValue == 6)
            {
                TabDHNCT.SelectedTabPageIndex = 0;
            }
            InitializeForm();
            try
            {
                object count = SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, CommandType.Text, "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM [SVM_TRANS_ACC] WHERE IO_KEY=N''" + TxtMSDHN.Text + "'' AND STATUS = ''C''')");


                if (Convert.ToInt16(count) > 0)
                {
                    TxtSoCT.Enabled = false;
                    MskNgayCT.Enabled = false;
                    CboNguoiNhap.Enabled = false;
                    btnTimNCty.Enabled = false;
                }
            }
            catch { }
            if (Commons.Modules.iDefault == 2) TxtSoDHN.Enabled = false;
            LoadChiPhi(((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString());
            if (BtnLuu.Visible == true)
            {
                if (TabDHNCT.SelectedTabPageIndex == 0)
                {
                    btnCP1.Visible = false;
                    btnCPAll.Visible = false;
                    BtnChonPT.Visible = true;
                }
                else if (TabDHNCT.SelectedTabPageIndex == 1)
                {
                    btnCP1.Visible = true;
                    btnCPAll.Visible = true;
                    BtnChonPT.Visible = false;
                }
                if ((int)CboDangNhap.EditValue == 6)
                {
                    try
                    {
                        DgvPhieuNhapKhoChiTiet.Columns["DON_GIA_GOC"].ReadOnly = true;
                        DgvPhieuNhapKhoChiTiet.Columns["TAX"].ReadOnly = true;
                        DgvPhieuNhapKhoChiTiet.Columns["TT_TAX"].ReadOnly = true;
                        DgvPhieuNhapKhoChiTiet.Columns["NGOAI_TE"].ReadOnly = true;
                        DgvPhieuNhapKhoChiTiet.Columns["TY_GIA"].ReadOnly = true;
                        DgvPhieuNhapKhoChiTiet.Columns["TY_GIA_USD"].ReadOnly = true;
                    }
                    catch
                    { }
                }
                else
                {

                    try
                    {
                        DgvPhieuNhapKhoChiTiet.Columns["DON_GIA_GOC"].ReadOnly = false;
                        DgvPhieuNhapKhoChiTiet.Columns["TAX"].ReadOnly = false;
                        DgvPhieuNhapKhoChiTiet.Columns["TT_TAX"].ReadOnly = false;
                        DgvPhieuNhapKhoChiTiet.Columns["NGOAI_TE"].ReadOnly = false;
                        DgvPhieuNhapKhoChiTiet.Columns["TY_GIA"].ReadOnly = false;
                        DgvPhieuNhapKhoChiTiet.Columns["TY_GIA_USD"].ReadOnly = false;
                    }
                    catch
                    { }
                }
            }
            if ((int)CboDangNhap.EditValue == 9)
            {
                DgvPhieuNhapKhoChiTiet.Columns["TONG_CP"].ReadOnly = false;
            }
            txtTimVTri.Enabled = true;
            try
            {
                TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = " MS_PT = '" + DgvPhieuNhapKhoChiTiet.Rows[DgvPhieuNhapKhoChiTiet.CurrentCell.RowIndex].Cells["MS_PT"].Value.ToString() + "' AND MS_DH_NHAP_PT = '" + TxtMSDHN.Text + "' AND ID = " + DgvPhieuNhapKhoChiTiet.Rows[DgvPhieuNhapKhoChiTiet.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "";
            }
            catch
            {
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Chọn vật tư phụ tùng
        /// </summary> 
        private void BtnChonPT_Click(object sender, EventArgs e)
        {
            DateTime dTNgay, dDNgay;
            dTNgay = datNgayNhap.DateTime.Date;

            try
            {
                dTNgay = Convert.ToDateTime("01/" + dTNgay.Month.ToString() + "/" + dTNgay.Year.ToString());
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNgayNhapSai", Commons.Modules.TypeLanguage));
                return;
            }
            dDNgay = datNgayNhap.DateTime.Date;
            DataTable dtTmp = new DataTable();
            string sTmp;
            if (Commons.Modules.sPrivate == "ACECOOK")
            {
                sTmp = " SELECT * FROM ( SELECT T1.*, ISNULL(TI_GIA,-1) AS TGIA FROM NGOAI_TE T1 LEFT JOIN " +
                                " (SELECT A.* FROM TI_GIA_NT A INNER JOIN (SELECT NGOAI_TE, MAX(NGAY) AS NMAX FROM TI_GIA_NT  " +
                                " WHERE NGAY_NHAP BETWEEN '" + dTNgay.ToString("MM/dd/yyyy") + "' AND '" + dDNgay.ToString("MM/dd/yyyy") + "' GROUP BY NGOAI_TE)B ON A.NGOAI_TE = B.NGOAI_TE AND A.NGAY = B.NMAX " +
                                " )T2 ON T1.NGOAI_TE = T2.NGOAI_TE) A WHERE TGIA = -1 ";
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sTmp));
                if (dtTmp.Rows.Count > 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanChuaNhapTiGia", Commons.Modules.TypeLanguage));
                    return;
                }

            }
            if (TabDHNCT.SelectedTabPageIndex == 1)
            {
                Vietsoft.Information.MsgBox(this, "msgChonTabPhuTung", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (CboKho.Properties.DataSource == null)
            {
                Vietsoft.Information.MsgBox(this, "MsgChonKho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                CboKho.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(CboKho.Text.Trim()))
            {
                Vietsoft.Information.MsgBox(this, "MsgChonKho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                CboKho.Focus();
                return;

            }

            try
            {
                frmChonPTNhapKho frmPhuTung = new frmChonPTNhapKho();
                frmPhuTung.CurrentSource = TbPhieuNhapKhoPhuTung.DefaultView.ToTable();
                try
                {
                    frmPhuTung.Kho = (int)CboKho.EditValue;
                }
                catch
                {
                    Vietsoft.Information.MsgBox(this, "MsgChonKho", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    CboKho.Focus();
                    return;
                }
                DateTime NNhap;
                try
                {
                    if (!DateTime.TryParse(datNgayNhap.Text, out NNhap))
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNgayNhapSai", Commons.Modules.TypeLanguage));
                        datNgayNhap.Focus();
                        return;
                    }
                    if (NNhap > Commons.Modules.ObjSystems.GetNgayHeThong().Date)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNgayNhapLonHonHienTai", Commons.Modules.TypeLanguage));
                        datNgayNhap.Focus();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChonNgayNhap", Commons.Modules.TypeLanguage));
                    datNgayNhap.Focus();
                    return;
                }
                try
                {
                    frmPhuTung.DangNhap = (int)CboDangNhap.EditValue;
                }
                catch
                {
                    Vietsoft.Information.MsgBox(this, "MsgChonDangNhap", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    CboDangNhap.Focus();
                    return;
                }
                if ((int)CboDangNhap.EditValue == 3)
                {
                    if (CboDDH.EditValue.ToString() == null || CboDDH.EditValue.ToString().Equals(DBNull.Value))
                    {
                        Vietsoft.Information.MsgBox(this, "MsgDonDatHang", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        CboDDH.Focus();
                        return;
                    }
                }
                if ((int)CboDangNhap.EditValue == 6 || (int)CboDangNhap.EditValue == 10)
                {
                    if (CboDDH.EditValue.ToString() == null || CboDDH.EditValue.ToString().Equals(DBNull.Value))
                    {
                        Vietsoft.Information.MsgBox(this, "ChuaChonPX", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        CboDDH.Focus();
                        return;
                    }
                }

                try
                {
                    if (CboDDH.EditValue.ToString() == null || CboDDH.EditValue.ToString().Equals(DBNull.Value))
                    {
                        frmPhuTung.DonDatHang = "-1";
                    }
                    else
                    {
                        frmPhuTung.DonDatHang = (string)CboDDH.EditValue.ToString();
                    }
                }
                catch
                {
                    frmPhuTung.DonDatHang = "-1";
                }

                sTmp = "SELECT * FROM IC_DON_HANG_NHAP WHERE (MS_DH_XUAT_PT <> '') AND (MS_DH_NHAP_PT = N'" + TxtMSDHN.Text + "')";
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sTmp));



                if (dtTmp.Rows.Count > 0)
                {
                    if ((int)CboDangNhap.EditValue == 9)
                    {
                        Vietsoft.Information.MsgBox(this, "KhongTheChonDangNhapDiDuong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        CboDangNhap.Focus();
                        return;
                    }
                    string sSql = "SELECT * FROM IC_KHO WHERE ISNULL(KHO_DD,0) = 1 AND MS_KHO = " + CboKho.EditValue.ToString();
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));

                    if (dtTmp.Rows.Count > 0)
                    {
                        Vietsoft.Information.MsgBox(this, "KhongTheChonKhoDiDuong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        CboKho.Focus();
                        return;
                    }
                }


                try
                {

                    if (frmPhuTung.ShowDialog(this) == DialogResult.OK)
                    {
                        Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                        double id = 0;
                        double idLuoi = 0;
                        string TMP;
                        dtTmp = new DataTable();
                        try
                        {
                            id = Convert.ToDouble(SqlPhieuNhapKho.ExecuteScalar(CommandType.StoredProcedure, "SP_MASHJ_GET_ID_IC_DON_HANG_NHAP_VAT_TU", TxtMSDHN.Text));
                        }
                        catch { }

                        try
                        {
                            DataView dtID = new DataView(TbPhieuNhapKhoPhuTung, "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() + "'", "ID DESC", DataViewRowState.CurrentRows);
                            if (dtID.Count > 0)
                                idLuoi = Convert.ToDouble(dtID[0].Row["ID"]);
                        }
                        catch { }

                        if (id != idLuoi)
                        {
                            if (id > idLuoi) id = id; else id = idLuoi;
                        }
                        else id = id;
                        string sNTe = "VND";
                        try
                        {
                            sNTe = Convert.ToString(SqlPhieuNhapKho.ExecuteScalar(CommandType.Text, "SELECT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH = 1"));
                        }
                        catch { }


                        frmPhuTung.DataSource.DefaultView.RowFilter = "CHON = True";
                        for (int i = 0; i < frmPhuTung.DataSource.DefaultView.Count; i++)
                        {
                            if (TbPhieuNhapKhoPhuTung.Columns.Count > 0)
                            {
                                id += 1;
                                DataRow rPhieuNhapKhoPhuTung = TbPhieuNhapKhoPhuTung.NewRow();
                                rPhieuNhapKhoPhuTung["MS_DH_NHAP_PT"] = TxtMSDHN.Text;
                                rPhieuNhapKhoPhuTung["MS_CHI_TIET_DH"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_CHI_TIET_DH"];
                                rPhieuNhapKhoPhuTung["MS_PT_CT"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT"];
                                rPhieuNhapKhoPhuTung["TEN_PT_CT"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_PT"];
                                rPhieuNhapKhoPhuTung["MS_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_PT"];
                                rPhieuNhapKhoPhuTung["TEN_PT"] = frmPhuTung.DataSource.DefaultView[i].Row["TEN_PT"];
                                rPhieuNhapKhoPhuTung["QUY_CACH"] = frmPhuTung.DataSource.DefaultView[i].Row["QUY_CACH"];
                                rPhieuNhapKhoPhuTung["PART_NO"] = frmPhuTung.DataSource.DefaultView[i].Row["PART_NO"];
                                rPhieuNhapKhoPhuTung["DVT"] = frmPhuTung.DataSource.DefaultView[i].Row["DVT"];
                                rPhieuNhapKhoPhuTung["SO_LUONG_CTU"] = frmPhuTung.DataSource.DefaultView[i].Row["SL_DAT_HANG"];
                                rPhieuNhapKhoPhuTung["SL_THUC_NHAP"] = frmPhuTung.DataSource.DefaultView[i].Row["SL_DAT_HANG"];
                                rPhieuNhapKhoPhuTung["DON_GIA_GOC"] = frmPhuTung.DataSource.DefaultView[i].Row["DON_GIA"];
                                rPhieuNhapKhoPhuTung["DON_GIA"] = frmPhuTung.DataSource.DefaultView[i].Row["DON_GIA"];
                                rPhieuNhapKhoPhuTung["NGOAI_TE"] = frmPhuTung.DataSource.DefaultView[i].Row["NGOAI_TE"];
                                try
                                {
                                    rPhieuNhapKhoPhuTung["XUAT_XU"] = frmPhuTung.DataSource.DefaultView[i].Row["XUAT_XU"];
                                    rPhieuNhapKhoPhuTung["BAO_HANH_DEN_NGAY"] = frmPhuTung.DataSource.DefaultView[i].Row["BAO_HANH_DEN_NGAY"];

                                }
                                catch { }
                                if (rPhieuNhapKhoPhuTung["NGOAI_TE"].ToString() == "")
                                {
                                    rPhieuNhapKhoPhuTung["NGOAI_TE"] = sNTe;
                                }
                                try
                                {
                                    rPhieuNhapKhoPhuTung["TAX"] = frmPhuTung.DataSource.DefaultView[i].Row["THUE_VAT"];
                                }
                                catch { rPhieuNhapKhoPhuTung["TAX"] = 0; }

                                rPhieuNhapKhoPhuTung["ID"] = id;
                                try
                                {
                                    if (CboDangNhap.EditValue.Equals(6))
                                        rPhieuNhapKhoPhuTung["SL_MAX"] = frmPhuTung.DataSource.DefaultView[i].Row["TON_KHO"];
                                    else
                                        rPhieuNhapKhoPhuTung["SL_MAX"] = 0;
                                }
                                catch
                                {
                                    rPhieuNhapKhoPhuTung["SL_MAX"] = 0;
                                }

                                try
                                {
                                    rPhieuNhapKhoPhuTung["VI_TRI"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_VI_TRI"];
                                }
                                catch
                                { }

                                try
                                {
                                    if ((int)CboDangNhap.EditValue == 6)
                                    {
                                        rPhieuNhapKhoPhuTung["MS_DH_NHAP_PT_GOC"] = frmPhuTung.DataSource.DefaultView[i].Row["MS_DH_NHAP_PT"];
                                        rPhieuNhapKhoPhuTung["ID_GOC"] = frmPhuTung.DataSource.DefaultView[i].Row["ID_XUAT"];
                                        try
                                        {
                                            DgvPhieuNhapKhoChiTiet.Columns["DON_GIA_GOC"].ReadOnly = true;
                                            DgvPhieuNhapKhoChiTiet.Columns["TAX"].ReadOnly = true;
                                            DgvPhieuNhapKhoChiTiet.Columns["TT_TAX"].ReadOnly = true;
                                            DgvPhieuNhapKhoChiTiet.Columns["NGOAI_TE"].ReadOnly = true;
                                            DgvPhieuNhapKhoChiTiet.Columns["TY_GIA"].ReadOnly = true;
                                            DgvPhieuNhapKhoChiTiet.Columns["TY_GIA_USD"].ReadOnly = true;
                                        }
                                        catch
                                        { }
                                    }
                                    else
                                    {
                                        rPhieuNhapKhoPhuTung["MS_DH_NHAP_PT_GOC"] = TxtMSDHN.Text;
                                        rPhieuNhapKhoPhuTung["ID_GOC"] = id;
                                        try
                                        {
                                            DgvPhieuNhapKhoChiTiet.Columns["DON_GIA_GOC"].ReadOnly = false;
                                            DgvPhieuNhapKhoChiTiet.Columns["TAX"].ReadOnly = false;
                                            DgvPhieuNhapKhoChiTiet.Columns["TT_TAX"].ReadOnly = false;
                                            DgvPhieuNhapKhoChiTiet.Columns["NGOAI_TE"].ReadOnly = false;
                                            DgvPhieuNhapKhoChiTiet.Columns["TY_GIA"].ReadOnly = false;
                                            DgvPhieuNhapKhoChiTiet.Columns["TY_GIA_USD"].ReadOnly = false;
                                        }
                                        catch
                                        { }
                                    }
                                }
                                catch { }
                                try
                                {
                                    Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                                    DataTable TbNgoaiTe = new DataTable();
                                    if (Commons.Modules.sPrivate == "ACECOOK")
                                    {
                                        string sSql = " SELECT dbo.NGOAI_TE.TEN_NGOAI_TE, ISNULL(TMP2.TI_GIA,0) AS TI_GIA, ISNULL(TMP2.TI_GIA_USD,0) AS TI_GIA_USD " +
                                                     " FROM (SELECT dbo.TI_GIA_NT.NGOAI_TE, ISNULL(dbo.TI_GIA_NT.TI_GIA ,0 ) AS TI_GIA, ISNULL(dbo.TI_GIA_NT.TI_GIA_USD,0) AS TI_GIA_USD " +
                                                     " FROM dbo.TI_GIA_NT INNER JOIN  " +
                                                     " (SELECT NGOAI_TE , MAX (NGAY) AS NGAY FROM dbo.TI_GIA_NT  WHERE NGAY_NHAP BETWEEN '" + dTNgay.ToString("MM/dd/yyyy") + "' AND '" +
                                                     dDNgay.ToString("MM/dd/yyyy") + "'  AND NGOAI_TE = N'" + rPhieuNhapKhoPhuTung["NGOAI_TE"].ToString() + "' " +
                                                     " GROUP BY NGOAI_TE)TMP1 ON dbo.TI_GIA_NT.NGOAI_TE = TMP1.NGOAI_TE AND dbo.TI_GIA_NT.NGAY = TMP1.NGAY ) TMP2  " +
                                                     " INNER JOIN dbo.NGOAI_TE ON TMP2.NGOAI_TE = dbo.NGOAI_TE.NGOAI_TE  " +
                                                     " WHERE  dbo.NGOAI_TE.TEN_NGOAI_TE = '" + rPhieuNhapKhoPhuTung["NGOAI_TE"].ToString() + "' ";

                                        TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.Text, sSql));
                                        if (TbNgoaiTe.Rows.Count <= 0)
                                        {
                                            sSql = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapTiGia", Commons.Modules.TypeLanguage);

                                            rPhieuNhapKhoPhuTung["TY_GIA"] = 0;
                                            rPhieuNhapKhoPhuTung["TY_GIA_USD"] = 0;
                                            rPhieuNhapKhoPhuTung["THANH_TIEN"] = 0;
                                            rPhieuNhapKhoPhuTung["THANH_TIEN_VND"] = 0;
                                            rPhieuNhapKhoPhuTung["THANH_TIEN_USD"] = 0;
                                        }
                                        else
                                        {
                                            rPhieuNhapKhoPhuTung["TY_GIA"] = TbNgoaiTe.Rows[0]["TI_GIA"];
                                            rPhieuNhapKhoPhuTung["TY_GIA_USD"] = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                                            Double dDG = 0;

                                            try
                                            {
                                                dDG = Convert.ToDouble(rPhieuNhapKhoPhuTung["DON_GIA"]);
                                            }
                                            catch { }
                                            rPhieuNhapKhoPhuTung["THANH_TIEN"] = Convert.ToDouble(rPhieuNhapKhoPhuTung["SL_THUC_NHAP"]) * dDG;
                                            rPhieuNhapKhoPhuTung["THANH_TIEN_VND"] = Convert.ToDouble(rPhieuNhapKhoPhuTung["THANH_TIEN"]) * Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA"]);
                                            rPhieuNhapKhoPhuTung["THANH_TIEN_USD"] = Convert.ToDouble(rPhieuNhapKhoPhuTung["THANH_TIEN"]) * Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA_USD"]);
                                        }
                                    }
                                    else
                                    {
                                        TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", rPhieuNhapKhoPhuTung["NGOAI_TE"]));
                                        if (TbNgoaiTe.Rows.Count > 0)
                                        {
                                            rPhieuNhapKhoPhuTung["TY_GIA"] = TbNgoaiTe.Rows[0]["TI_GIA"];
                                            rPhieuNhapKhoPhuTung["TY_GIA_USD"] = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                                            Double dDG = 0;
                                            Double dSL = 0;
                                            try
                                            {
                                                dDG = Convert.ToDouble(rPhieuNhapKhoPhuTung["DON_GIA"]);
                                            }
                                            catch { }
                                            try
                                            {
                                                dSL = Convert.ToDouble(rPhieuNhapKhoPhuTung["SL_THUC_NHAP"]);
                                            }
                                            catch { }
                                            rPhieuNhapKhoPhuTung["THANH_TIEN"] = dSL * dDG;
                                            rPhieuNhapKhoPhuTung["THANH_TIEN_VND"] = Convert.ToDouble(rPhieuNhapKhoPhuTung["THANH_TIEN"]) * Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA"]);
                                            rPhieuNhapKhoPhuTung["THANH_TIEN_USD"] = Convert.ToDouble(rPhieuNhapKhoPhuTung["THANH_TIEN"]) * Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA_USD"]);
                                        }
                                    }
                                }
                                catch
                                {
                                }


                                #region Tinh don gia vnd
                                try
                                {
                                    rPhieuNhapKhoPhuTung["DON_GIA_VND"] =
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["DON_GIA"]) * Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA"]);
                                }
                                catch
                                {
                                    rPhieuNhapKhoPhuTung["DON_GIA_VND"] = 0;
                                }
                                #endregion

                                #region Tinh don gia usd
                                try
                                {
                                    rPhieuNhapKhoPhuTung["DON_GIA_USD"] =
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["DON_GIA"]) *
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA_USD"]);
                                }
                                catch
                                {
                                    rPhieuNhapKhoPhuTung["DON_GIA_USD"] = 0;
                                }
                                #endregion

                                #region Tinh don gia goc vnd
                                try
                                {
                                    rPhieuNhapKhoPhuTung["DON_GIA_GOC_VND"] =
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["DON_GIA_GOC"]) *
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA"]);
                                }
                                catch
                                {
                                    rPhieuNhapKhoPhuTung["DON_GIA_GOC_VND"] = 0;
                                }
                                #endregion

                                #region Tinh thanh tien
                                try
                                {
                                    rPhieuNhapKhoPhuTung["THANH_TIEN"] =
                                        (Convert.ToDouble(rPhieuNhapKhoPhuTung["SL_THUC_NHAP"]) *
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["DON_GIA"]));

                                }
                                catch { rPhieuNhapKhoPhuTung["THANH_TIEN"] = 0; }
                                #endregion

                                #region Tinh thanh tien VND
                                try
                                {
                                    rPhieuNhapKhoPhuTung["THANH_TIEN_VND"] =
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["THANH_TIEN"]) *
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA"]);
                                }
                                catch
                                {
                                    rPhieuNhapKhoPhuTung["THANH_TIEN_VND"] = 0;
                                }
                                #endregion

                                #region Tinh thanh tien USD
                                try
                                {
                                    rPhieuNhapKhoPhuTung["THANH_TIEN_USD"] =
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["THANH_TIEN"]) *
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA_USD"]);
                                }
                                catch
                                {
                                    rPhieuNhapKhoPhuTung["THANH_TIEN_USD"] = 0;
                                }
                                #endregion

                                #region Tinh thanh tien thue
                                try
                                {
                                    rPhieuNhapKhoPhuTung["TT_TAX"] =
                                        ((Convert.ToDouble(rPhieuNhapKhoPhuTung["DON_GIA_GOC"]) *
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA"]) *
                                            Convert.ToDouble(rPhieuNhapKhoPhuTung["TAX"])) / 100) * Convert.ToDouble(rPhieuNhapKhoPhuTung["SL_THUC_NHAP"]);


                                }
                                catch
                                {
                                    rPhieuNhapKhoPhuTung["TT_TAX"] = 0;
                                }

                                #endregion

                                #region Tinh thanh tien thue
                                try
                                {
                                    rPhieuNhapKhoPhuTung["TAX"] =
                                        (Convert.ToDouble(rPhieuNhapKhoPhuTung["TT_TAX"]) * 100) /
                                            (Convert.ToDouble(rPhieuNhapKhoPhuTung["DON_GIA_GOC"]) * Convert.ToDouble(rPhieuNhapKhoPhuTung["TY_GIA"]) * Convert.ToDouble(rPhieuNhapKhoPhuTung["SL_THUC_NHAP"]));
                                    if (rPhieuNhapKhoPhuTung["TAX"].ToString().ToUpper() == "NAN")
                                        rPhieuNhapKhoPhuTung["TAX"] = 0;

                                }
                                catch//141,543.01
                                {
                                    rPhieuNhapKhoPhuTung["TAX"] = 0;
                                }

                                #endregion

                                #region Tinh thanh tien sau thue
                                try
                                {
                                    rPhieuNhapKhoPhuTung["THANH_TIEN_ST"] =
                                        (Convert.ToDouble(rPhieuNhapKhoPhuTung["THANH_TIEN_VND"]) +
                                        Convert.ToDouble(rPhieuNhapKhoPhuTung["TT_TAX"]));
                                }
                                catch { rPhieuNhapKhoPhuTung["THANH_TIEN_ST"] = 0; }
                                #endregion




                                TbPhieuNhapKhoPhuTung.Rows.Add(rPhieuNhapKhoPhuTung);
                                if (CboDangNhap.EditValue.Equals(3) || CboDangNhap.EditValue.Equals(6) || CboDangNhap.EditValue.Equals(10))
                                {
                                    CboDangNhap.Enabled = false;
                                    CboDDH.Enabled = false;
                                }
                                CboKho.Enabled = false;
                                CboDangNhap.Enabled = false;
                                datNgayNhap.Enabled = false;
                                MskGioNhap.Enabled = false;

                                DataTable TbViTriKhoPT = new DataTable();
                                TbViTriKhoPT.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_VI_TRI_KHO_PT", CboKho.EditValue));
                                foreach (DataRow dr in TbViTriKhoPT.Rows)
                                {
                                    DataRow rPhieuNhapKhoPhuTungChiTiet = TbPhieuNhapKhoPhuTungChiTiet.NewRow();
                                    rPhieuNhapKhoPhuTungChiTiet["MS_DH_NHAP_PT"] = TxtMSDHN.Text;
                                    rPhieuNhapKhoPhuTungChiTiet["MS_PT"] = rPhieuNhapKhoPhuTung["MS_PT"];
                                    rPhieuNhapKhoPhuTungChiTiet["MS_VI_TRI"] = dr["MS_VI_TRI"];
                                    rPhieuNhapKhoPhuTungChiTiet["TEN_VI_TRI"] = dr["TEN_VI_TRI"];
                                    rPhieuNhapKhoPhuTungChiTiet["ID"] = id;
                                    rPhieuNhapKhoPhuTungChiTiet["SL_VT"] = 0;
                                    TbPhieuNhapKhoPhuTungChiTiet.Rows.Add(rPhieuNhapKhoPhuTungChiTiet);
                                }


                            }
                        }
                    }
                }
                catch (Exception EX) { MessageBox.Show(EX.Message); }
                try
                {
                    TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString().Trim() + "'";
                    LocChiTiet(DgvPhieuNhapKhoChiTiet.CurrentRow.Index);
                }
                catch { TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1"; }
            }
            catch { }
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary> 
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgCheckDelete"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                try
                {
                    object count = SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, CommandType.Text, "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM [SVM_TRANS_ACC] WHERE IO_KEY=N''" + TxtMSDHN.Text + "'' AND STATUS = ''C''')");

                    if (Convert.ToInt16(count) > 0)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgNotDelete", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                catch { }
                this.Cursor = Cursors.WaitCursor;
                Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                SqlPhieuNhapKho.BeginTransaction();
                try
                {
                    string SOPN = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString();

                    SqlPhieuNhapKho.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Y_DELETE_VI_TRI_KHO_VAT_TU", SOPN);
                    Vietsoft.DataInfo.DeleteDataView(SqlPhieuNhapKho, "SP_Y_DELETE_DON_HANG_NHAP_VAT_TU_CHI_TIET",
                        new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" +
                            ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() + "'",
                            "MS_PT", DataViewRowState.CurrentRows), "MS_DH_NHAP_PT", "MS_PT", "MS_VI_TRI", "ID");

                    Vietsoft.DataInfo.DeleteDataView(SqlPhieuNhapKho, "SP_Y_DELETE_DON_HANG_NHAP_VAT_TU",
                        TbPhieuNhapKhoPhuTung.DefaultView, "MS_DH_NHAP_PT", "MS_PT", "ID");

                    Vietsoft.DataInfo.DeleteDataRow(SqlPhieuNhapKho, "SP_Y_DELETE_DON_HANG_NHAP_CHI_PHI",
                        ((DataRowView)BindingPhieuNhapKho.Current).Row, "MS_DH_NHAP_PT");

                    Vietsoft.DataInfo.DeleteDataRow(SqlPhieuNhapKho, "SP_Y_DELETE_DON_HANG_NHAP",
                        ((DataRowView)BindingPhieuNhapKho.Current).Row, "MS_DH_NHAP_PT");
                    Vietsoft.DataInfo.ClearData(new DataView(TbPhieuNhapKhoPhuTungChiTiet,
                        "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() + "'",
                        "MS_PT", DataViewRowState.CurrentRows));

                    if (Commons.Modules.iTRFData == 1)
                    {
                        System.Data.DataTable dttmp = new System.Data.DataTable();
                        dttmp.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "spTRFDelNhapKho", SOPN, "-1", -1));
                        if (dttmp.Rows.Count > 0)
                        {
                            MessageBox.Show(dttmp.Rows[0][3].ToString() + "\n" + dttmp.Rows[0][5].ToString());
                            SqlPhieuNhapKho.RollbackTransaction();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }

                    Vietsoft.DataInfo.ClearData(TbPhieuNhapKhoPhuTung.DefaultView);
                    BindingPhieuNhapKho.RemoveCurrent();
                    TbPhieuNhapKho.AcceptChanges();
                    TbPhieuNhapKhoPhuTung.AcceptChanges();
                    TbPhieuNhapKhoPhuTungChiTiet.AcceptChanges();
                    SqlPhieuNhapKho.CommitTransaction();
                    InitializeForm();
                }
                catch
                {
                    SqlPhieuNhapKho.RollbackTransaction();
                    Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Lọc dữ liệu
        /// </summary> 


        /// <summary>
        /// In dữ liệu
        /// </summary> 
        private void CreateRPT_DUYTAN()
        {
            dt = new DataTable();
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT_DUYTAN", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
            frmReport frmRptPhieuNhap = new frmReport();
            frmRptPhieuNhap.rptName = "rptPhieuNhapKho_DUYTAN";

            foreach (DataColumn col in TbSource.Columns)
            {
                dt.Columns.Add(col.ColumnName);
            }


            foreach (DataRow dr in TbSource.Rows)
            {
                flag = 0;
                string tensp = dr["TEN_PT"].ToString();
                DupRow(dr);
            }

            dt.TableName = "rptPhieuNhapKhoNew";
            frmRptPhieuNhap.AddDataTableSource(dt);

            float tongtien = 0;
            string doctien = "";
            foreach (DataRow row in TbSource.Rows)
            {
                tongtien += float.Parse(row["THANH_TIEN"].ToString());
            }
            if (tongtien != 0)
            {
                doctien = Doctien(tongtien);
            }

            DataTable TbTongtien = new DataTable("tbTONG_TIEN");
            TbTongtien.Columns.Add("TIEN_SO");
            TbTongtien.Columns.Add("TIEN_CHU");
            DataRow rowtt = TbTongtien.NewRow();
            rowtt["TIEN_SO"] = String.Format("{0:N2}", tongtien);
            rowtt["TIEN_CHU"] = doctien;
            TbTongtien.Rows.Add(rowtt);
            frmRptPhieuNhap.AddDataTableSource(TbTongtien);

            DataTable TbTieuDe = CreateTitle(TxtThuKhoKy.Text);
            frmRptPhieuNhap.AddDataTableSource(TbTieuDe);
            frmRptPhieuNhap.ShowDialog(this);
        }

        private void DupRow(DataRow r)
        {
            DataRow row = dt.NewRow();
            string tenpt = "";
            foreach (DataColumn c1 in dt.Columns)
            {
                row[c1.ColumnName] = r[c1.ColumnName];
            }
            if (row["TEN_PT"].ToString().Length >= 43)
            {
                tenpt = row["TEN_PT"].ToString().Substring(0, 43);
            }
            else
                tenpt = row["TEN_PT"].ToString();
            if (tenpt != "")
                dt.Rows.Add(row);
            if (row["TEN_PT"].ToString().Length > 42)
            {
                row["TEN_PT"] = row["TEN_PT"].ToString().Remove(0, 43);
                DupRow(row);
            }
            row["TEN_PT"] = tenpt;
        }

        private string Doctien(float number)
        {
            string str = " ";
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;

            bool booAm = false;
            decimal decS = 0;
            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            return str = str + "đồng";

        }

        private void CreateRPT_NTD()
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT_NTD", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
            TbSource.TableName = "rptPhieuNhapKhoNew";
            DataTable TbSource1 = new DataTable();

            DataTable TbSource2 = new DataTable();
            TbSource2.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT_NTD_DONVI", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
            TbSource2.TableName = "rptPhieuNhapKhoNew_DonVi";

            frmReport frmRptPhieuNhap = new frmReport();
            if (CboDangNhap.EditValue.ToString() != "4")
            {

                TbSource1.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT_NTD_DOCTIEN_VAT", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
                TbSource1.TableName = "rptPhieuNhapKhoNew_DocTien";

                frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVTNew_NTD";
            }
            else
            {

                TbSource1.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT_NTD_DOCTIEN", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
                TbSource1.TableName = "rptPhieuNhapKhoNew_DocTien";

                frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVTNew_NTD_TAINHAP";
            }

            frmRptPhieuNhap.AddDataTableSource(TbSource);
            frmRptPhieuNhap.AddDataTableSource(TbSource1);
            frmRptPhieuNhap.AddDataTableSource(TbSource2);

            DataTable TbTieuDe = CreateTitle_NTD();
            frmRptPhieuNhap.AddDataTableSource(TbTieuDe);
            frmRptPhieuNhap.ShowDialog(this);
        }
        private void CreateInVard(string TenThuKho)
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
            TbSource.TableName = "rptPhieuNhapKhoNew";
            frmReport frmRptPhieuNhap = new frmReport();
            //frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVMPACKNew";
            frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVTNew_VARD";
            frmRptPhieuNhap.AddDataTableSource(TbSource);
            DataTable TbTieuDe = CreateTitle(TenThuKho);
            frmRptPhieuNhap.AddDataTableSource(TbTieuDe);
            Commons.Modules.SQLString = "0LOAD";
            frmRptPhieuNhap.ShowDialog(this);
            Commons.Modules.SQLString = "";
        }
        private void CreateRPTN(string TenThuKho)
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT_TN", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
            TbSource.TableName = "rptPhieuNhapKhoNew";
            frmReport frmRptPhieuNhap = new frmReport();
            frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVTNew_TN";
            frmRptPhieuNhap.AddDataTableSource(TbSource);
            DataTable TbTieuDe = CreateTitle(TenThuKho);
            frmRptPhieuNhap.AddDataTableSource(TbTieuDe);
            frmRptPhieuNhap.ShowDialog(this);
        }

        private void CreateRPT(string TenThuKho)
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
            TbSource.TableName = "rptPhieuNhapKhoNew";
            frmReport frmRptPhieuNhap = new frmReport();
            frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVTNew";
            frmRptPhieuNhap.AddDataTableSource(TbSource);
            DataTable TbTieuDe = CreateTitle(TenThuKho);
            frmRptPhieuNhap.AddDataTableSource(TbTieuDe);
            frmRptPhieuNhap.ShowDialog(this);
        }
        private void CreateRPTNU(string TenThuKho)
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT_NU", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
            TbSource.TableName = "rptPhieuNhapKhoNew";
            frmReport frmRptPhieuNhap = new frmReport();
            frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVTNew_NU";
            frmRptPhieuNhap.AddDataTableSource(TbSource);
            DataTable TbTieuDe = CreateTitle(TenThuKho);
            frmRptPhieuNhap.AddDataTableSource(TbTieuDe);

            frmRptPhieuNhap.ShowDialog(this);
        }
        private void CreateRPT_KKTL()
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbSource = new DataTable();
            TbSource.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DON_HANG_NHAP_RPT", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"], Commons.Modules.TypeLanguage));
            TbSource.TableName = "rptPhieuNhapKhoNew";
            frmReport frmRptPhieuNhap = new frmReport();
            //frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVMPACKNew";
            frmRptPhieuNhap.rptName = "rptPhieuNhapKhoVT_KKTL";
            frmRptPhieuNhap.AddDataTableSource(TbSource);
            DataTable TbTieuDe = CreateTitle(TxtThuKhoKy.Text);
            frmRptPhieuNhap.AddDataTableSource(TbTieuDe);
            frmRptPhieuNhap.ShowDialog(this);
        }

        private static DataTable CreateTitle_NTD()
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
            TbTieuDe.Columns.Add("Tax");
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
            TbTieuDe.Columns.Add("NGAY");
            TbTieuDe.Columns.Add("THANG");
            TbTieuDe.Columns.Add("NAM");
            TbTieuDe.Columns.Add("LY_DO");
            TbTieuDe.Columns.Add("CAN_CU");




            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["SO_ISO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "SO_ISO", Commons.Modules.TypeLanguage);
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["LIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "LIEN", Commons.Modules.TypeLanguage);
            rTitle["NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NO", Commons.Modules.TypeLanguage);
            rTitle["SO_PHIEU_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "SO_PHIEU_NHAP", Commons.Modules.TypeLanguage);
            rTitle["CO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "CO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGUOI_NHAP", Commons.Modules.TypeLanguage);
            rTitle["DANG_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "DANG_NHAP", Commons.Modules.TypeLanguage);
            rTitle["MS_DH_NHAP_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage);
            rTitle["SO_CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "SO_CHUNG_TU", Commons.Modules.TypeLanguage);
            rTitle["NGAY_CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGAY_CHUNG_TU", Commons.Modules.TypeLanguage);
            rTitle["TEN_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "TEN_KHO", Commons.Modules.TypeLanguage);
            rTitle["NGAY_NHAP_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGAY_NHAP_KHO", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU_DH_NHAP_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "GHI_CHU_DH_NHAP_PT", Commons.Modules.TypeLanguage);
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "STT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["PRAR_NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "PRAR_NO", Commons.Modules.TypeLanguage);
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "QUY_CACH", Commons.Modules.TypeLanguage);
            rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "DVT", Commons.Modules.TypeLanguage);
            rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "SO_LUONG", Commons.Modules.TypeLanguage);
            rTitle["SL_CTU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "SL_CTU", Commons.Modules.TypeLanguage);
            rTitle["SL_THUC_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "SL_THUC_NHAP", Commons.Modules.TypeLanguage);
            rTitle["Tax"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "Tax", Commons.Modules.TypeLanguage);
            rTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "DON_GIA", Commons.Modules.TypeLanguage);
            rTitle["NGOAI_TE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGOAI_TE", Commons.Modules.TypeLanguage);
            rTitle["TY_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "TY_GIA", Commons.Modules.TypeLanguage);
            rTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "THANH_TIEN", Commons.Modules.TypeLanguage);
            rTitle["THANH_TIEN_VND"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "THANH_TIEN_VND", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU_CT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "GHI_CHU_CT", Commons.Modules.TypeLanguage);
            rTitle["TONG_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "TONG_TIEN", Commons.Modules.TypeLanguage);
            rTitle["NGAY_THANG_NAM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGAY_THANG_NAM", Commons.Modules.TypeLanguage);
            rTitle["TRUONG_DON_VI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "TRUONG_DON_VI", Commons.Modules.TypeLanguage);
            rTitle["TRUONG_DV_KY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "TRUONG_DV_KY", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGUOI_LAP", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_LAP_KY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGUOI_LAP_KY", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_GIAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGUOI_GIAO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_GIAO_KY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGUOI_GIAO_KY", Commons.Modules.TypeLanguage);
            rTitle["THU_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "THU_KHO", Commons.Modules.TypeLanguage);
            rTitle["THU_KHO_KY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "THU_KHO_KY", Commons.Modules.TypeLanguage);
            rTitle["NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGAY", Commons.Modules.TypeLanguage);
            rTitle["THANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "THANG", Commons.Modules.TypeLanguage);
            rTitle["NAM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NAM", Commons.Modules.TypeLanguage);

            rTitle["LY_DO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "LY_DO", Commons.Modules.TypeLanguage);
            rTitle["CAN_CU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "CAN_CU", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "NGUOI_LAP", Commons.Modules.TypeLanguage);
            rTitle["Tax"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew_NTD", "Tax", Commons.Modules.TypeLanguage);

            TbTieuDe.TableName = "rptTieuDePhieuNhapKhoNew";
            TbTieuDe.Rows.Add(rTitle);
            return TbTieuDe;
        }

        private static DataTable CreateTitle(string TenThuKho)
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
            TbTieuDe.Columns.Add("Tax");
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
            TbTieuDe.Columns.Add("TEN_THU_KHO");
            TbTieuDe.Columns.Add("MS_PT_NCC");
            TbTieuDe.Columns.Add("NHA_CUNG_CAP");
            TbTieuDe.Columns.Add("MS_PT_CTY");



            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["MS_PT_NCC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "MS_PT_NCC", Commons.Modules.TypeLanguage);
            rTitle["NHA_CUNG_CAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NHA_CUNG_CAP", Commons.Modules.TypeLanguage);
            rTitle["SO_ISO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "SO_ISO", Commons.Modules.TypeLanguage);
            rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "TIEU_DE", Commons.Modules.TypeLanguage);
            rTitle["LIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "LIEN", Commons.Modules.TypeLanguage);
            rTitle["NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NO", Commons.Modules.TypeLanguage);
            rTitle["SO_PHIEU_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "SO_PHIEU_NHAP", Commons.Modules.TypeLanguage);
            rTitle["CO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "CO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NGUOI_NHAP", Commons.Modules.TypeLanguage);
            rTitle["DANG_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "DANG_NHAP", Commons.Modules.TypeLanguage);
            rTitle["MS_DH_NHAP_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "MS_DH_NHAP_PT", Commons.Modules.TypeLanguage);
            rTitle["SO_CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "SO_CHUNG_TU", Commons.Modules.TypeLanguage);
            rTitle["NGAY_CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NGAY_CHUNG_TU", Commons.Modules.TypeLanguage);
            rTitle["TEN_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "TEN_KHO", Commons.Modules.TypeLanguage);
            rTitle["NGAY_NHAP_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NGAY_NHAP_KHO", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU_DH_NHAP_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "GHI_CHU_DH_NHAP_PT", Commons.Modules.TypeLanguage);
            rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "STT", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["PRAR_NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "PRAR_NO", Commons.Modules.TypeLanguage);
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "QUY_CACH", Commons.Modules.TypeLanguage);
            rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "DVT", Commons.Modules.TypeLanguage);
            rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "SO_LUONG", Commons.Modules.TypeLanguage);
            rTitle["SL_CTU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "SL_CTU", Commons.Modules.TypeLanguage);
            rTitle["SL_THUC_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "SL_THUC_NHAP", Commons.Modules.TypeLanguage);
            rTitle["Tax"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "Tax", Commons.Modules.TypeLanguage);
            rTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "DON_GIA", Commons.Modules.TypeLanguage);
            rTitle["NGOAI_TE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NGOAI_TE", Commons.Modules.TypeLanguage);
            rTitle["TY_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "TY_GIA", Commons.Modules.TypeLanguage);
            rTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "THANH_TIEN", Commons.Modules.TypeLanguage);
            rTitle["THANH_TIEN_VND"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "THANH_TIEN_VND", Commons.Modules.TypeLanguage);
            rTitle["GHI_CHU_CT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "GHI_CHU_CT", Commons.Modules.TypeLanguage);
            rTitle["TONG_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "TONG_TIEN", Commons.Modules.TypeLanguage);
            rTitle["NGAY_THANG_NAM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NGAY_THANG_NAM", Commons.Modules.TypeLanguage);
            rTitle["TRUONG_DON_VI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "TRUONG_DON_VI", Commons.Modules.TypeLanguage);
            rTitle["TRUONG_DV_KY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "TRUONG_DV_KY", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NGUOI_LAP", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_LAP_KY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NGUOI_LAP_KY", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_GIAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NGUOI_GIAO", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_GIAO_KY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "NGUOI_GIAO_KY", Commons.Modules.TypeLanguage);
            rTitle["THU_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "THU_KHO", Commons.Modules.TypeLanguage);
            rTitle["THU_KHO_KY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "THU_KHO_KY", Commons.Modules.TypeLanguage);
            rTitle["MS_PT_CTY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapKhoNew", "MS_PT_CTY", Commons.Modules.TypeLanguage);
            rTitle["TEN_THU_KHO"] = TenThuKho;

            TbTieuDe.TableName = "rptTieuDePhieuNhapKhoNew";
            TbTieuDe.Rows.Add(rTitle);
            return TbTieuDe;
        }

        /// <summary>
        /// Lưu dữ liệu
        /// </summary> 
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            Validate();



            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (((DataRowView)BindingPhieuNhapKho.Current).Row["MS_KHO"] == null || ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_KHO"].Equals(DBNull.Value) || ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_KHO"].Equals(""))
            {
                Vietsoft.Information.MsgBox(this, "MsgKhoNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                CboKho.Focus();
                return;
            }
            if (((DataRowView)BindingPhieuNhapKho.Current).Row["NGUOI_NHAP"] == null || ((DataRowView)BindingPhieuNhapKho.Current).Row["NGUOI_NHAP"].Equals(DBNull.Value) || ((DataRowView)BindingPhieuNhapKho.Current).Row["NGUOI_NHAP"].Equals(""))
            {
                Vietsoft.Information.MsgBox(this, "MsgNguoiNhapNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                CboNguoiNhap.Focus();
                return;
            }

            if (((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DANG_NHAP"] == null || ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DANG_NHAP"].Equals(DBNull.Value) || ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DANG_NHAP"].Equals(""))
            {
                if (CboDangNhap.Text != "")
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DANG_NHAP"] = CboDangNhap.EditValue;
                else
                {
                    Vietsoft.Information.MsgBox(this, "MsgDangNhapNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    CboDangNhap.Focus();
                    return;
                }
            }
            if (CboDangNhap.EditValue.Equals(3))
            {
                if (((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] == null || ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"].Equals(DBNull.Value) || ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"].Equals(""))
                {
                    Vietsoft.Information.MsgBox(this, "MsgDDHNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    CboDDH.Focus();
                    return;
                }
            }
            DateTime NNhap;
            try
            {
                if (!DateTime.TryParse(datNgayNhap.Text, out NNhap))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNgayNhapSai", Commons.Modules.TypeLanguage));
                    datNgayNhap.Focus();
                    return;
                }

                if (NNhap > Commons.Modules.ObjSystems.GetNgayHeThong().Date)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNgayNhapLonHonHienTai", Commons.Modules.TypeLanguage));
                    datNgayNhap.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgChonNgayNhap", Commons.Modules.TypeLanguage));
                datNgayNhap.Focus();
                return;
            }
            if (DgvPhieuNhapKhoChiTiet.RowCount <= 0)
            {
                Vietsoft.Information.MsgBox(this, "MsgChuaChonPhuTung", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                DgvPhieuNhapKhoChiTiet.Focus();
                return;
            }
            if (((DataRowView)BindingPhieuNhapKho.Current).Row["GIO"] == null || ((DataRowView)BindingPhieuNhapKho.Current).Row["GIO"].Equals(DBNull.Value))
            {
                Vietsoft.Information.MsgBox(this, "MsgGioNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                MskGioNhap.Focus();
                return;
            }

            if (((DataRowView)BindingPhieuNhapKho.Current).Row["NGAY"] == null || ((DataRowView)BindingPhieuNhapKho.Current).Row["NGAY"].Equals(DBNull.Value))
            {
                Vietsoft.Information.MsgBox(this, "MsgNgayNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                datNgayNhap.Focus();
                return;
            }

            if (((DataRowView)BindingPhieuNhapKho.Current).Row["THU_KHO"] == null || ((DataRowView)BindingPhieuNhapKho.Current).Row["THU_KHO"].Equals(DBNull.Value) || ((DataRowView)BindingPhieuNhapKho.Current).Row["THU_KHO"].Equals(""))
            {
                Vietsoft.Information.MsgBox(this, "MsgUserNhapNull", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtThuKho.Focus();
                return;
            }

            if (Convert.ToInt32(CboDangNhap.EditValue.ToString()) == 9)
            {
                double a = 0;
                //cập nhật từ tổng qua bên chi phí
                foreach (DataGridViewRow data in DgvPhieuNhapKhoChiTiet.Rows)
                {
                    try
                    { a += Convert.ToDouble(data.Cells["TONG_CP"].Value); }
                    catch
                    { }
                }
                grdChiPhi.Rows[1].Cells["TONG_CP"].Value = a;
                foreach (DataGridViewRow VARIABLE in grdChiPhi.Rows)
                {
                    if (Convert.ToInt32(VARIABLE.Cells["MS_CHI_PHI"].Value.ToString()) == 10)
                    {
                        VARIABLE.Cells["TONG_CP"].Value = a;
                    }
                }
            }

            #region Kiem tra so luong 
            foreach (DataGridViewRow rPhieuNhapKhoChiTiet in DgvPhieuNhapKhoChiTiet.Rows)
            {
                if (((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["SO_LUONG_CTU"] == null || ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["SO_LUONG_CTU"].Equals(DBNull.Value) || Convert.ToDouble(((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["SO_LUONG_CTU"]) <= 0)
                {

                    Vietsoft.Information.MsgBox(this, "MsgSLCTLONHON0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["SO_LUONG_CTU"];
                    return;

                }
                if (((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["SL_THUC_NHAP"] == null || ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["SL_THUC_NHAP"].Equals(DBNull.Value) || Convert.ToDouble(((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["SL_THUC_NHAP"]) <= 0)
                {
                    Vietsoft.Information.MsgBox(this, "MsgSLTNLONHON0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["SL_THUC_NHAP"];
                    return;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["Tax"])))
                {
                    if (Convert.ToDouble(((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["Tax"]) < 0)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgTaxLONHON0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["Tax"];
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["TT_TAX"])))
                {
                    if (Convert.ToDouble(((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["TT_TAX"]) < 0)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgTaxLONHON0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["TT_TAX"];
                        return;
                    }
                }

                if (((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] != "" && ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] != null && !((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"].Equals(DBNull.Value))
                {
                    if (CboDangNhap.EditValue.Equals(3))
                    {
                        #region Kiem So Luong Nhap theo Don hang                      
                        double SLDH = Convert.ToDouble(SqlPhieuNhapKho.ExecuteScalar(CommandType.StoredProcedure,
                               "SP_Y_GET_SLDHDX_HT", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"],
                               ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"],
                               ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_PT"],
                               ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_CHI_TIET_DH"]));

                        DataView DvTmp = new DataView(TbPhieuNhapKhoPhuTung,
                            " MS_DH_NHAP_PT = '" + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_DH_NHAP_PT"].ToString().Trim() + "' " +
                            " AND MS_CHI_TIET_DH = '" + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_CHI_TIET_DH"].ToString().Trim() + "' " +
                            " AND MS_PT = '" + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_PT"].ToString() + "' "
                            , "", DataViewRowState.CurrentRows);

                        double SLuoi = 0;
                        try
                        {
                            SLuoi = Convert.ToDouble((DvTmp.ToTable()).Compute("Sum(SL_THUC_NHAP)", ""));
                        }
                        catch { }


                        if (Convert.ToDouble(SLuoi) > Convert.ToDouble(SLDH))
                        {
                            Vietsoft.Information.MsgBox(this, "MsgSL_LONHON_DH", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["SL_THUC_NHAP"];
                            return;
                        }
                        #endregion
                    }
                }
                if (((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] != "" && ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] != null && !((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"].Equals(DBNull.Value))
                {
                    if (CboDangNhap.EditValue.Equals(6))
                    {
                        #region Kiem So Luong Nhap Tra
                        double SLDH = Convert.ToDouble(SqlPhieuNhapKho.ExecuteScalar(CommandType.StoredProcedure,
                           "SP_GET_SLMAXTRA", ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"],
                           ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"],
                           ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_PT"], ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_DH_NHAP_PT_GOC"], ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["ID_GOC"]));

                        DataView DvTmp = new DataView(TbPhieuNhapKhoPhuTung,
                            " MS_DH_NHAP_PT = '" + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_DH_NHAP_PT"].ToString() + "' " +
                            " AND MS_CHI_TIET_DH = '" + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_CHI_TIET_DH"].ToString() + "' " +
                            " AND MS_PT = '" + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_PT"].ToString() + "' " +
                            " AND MS_DH_NHAP_PT_GOC = '" + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_DH_NHAP_PT_GOC"].ToString() + "' " +
                            " AND ID_GOC = '" + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["ID_GOC"].ToString() + "' "
                            , "", DataViewRowState.CurrentRows);


                        double SLuoi = 0;
                        try
                        {
                            SLuoi = Convert.ToDouble((DvTmp.ToTable()).Compute("Sum(SL_THUC_NHAP)", ""));
                        }
                        catch { }
                        if (Convert.ToDouble(SLuoi) > Convert.ToDouble(SLDH))
                        {
                            Vietsoft.Information.MsgBox(this, "MsgSL_LONHON_PX", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["SL_THUC_NHAP"];
                            return;
                        }
                        #endregion
                    }

                }

                #region Kiem tra so luong vi tri co can voi so luong vat tu
                try
                {
                    DataView DgvTmp = new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" +
                            ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_DH_NHAP_PT"].ToString() +
                            "' AND MS_PT = '" + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["MS_PT"].ToString() + "' " +
                            " AND ID = " + ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["ID"].ToString() + " ", "", DataViewRowState.CurrentRows);


                    double SlVT = 0;
                    try
                    {
                        DataTable dtmp = DgvTmp.ToTable().Copy();
                        SlVT = Convert.ToDouble(dtmp.Compute("Sum(SL_VT)", ""));
                    }
                    catch { }

                    if (Convert.ToDouble(((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["SL_THUC_NHAP"]) != SlVT)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgSLKhongCan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["SL_THUC_NHAP"];
                        return;
                    }
                }
                catch { }
                #endregion

                #region Kiem tra don gia , ngoai te co null

                if (((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["DON_GIA_GOC"] == null || ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["DON_GIA_GOC"].Equals(DBNull.Value))
                {
                    Vietsoft.Information.MsgBox(this, "MsgDONGIAGOCNULL", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["DON_GIA_GOC"];
                    return;
                }
                if (((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["NGOAI_TE"] == null || ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["NGOAI_TE"].Equals(DBNull.Value))
                {
                    Vietsoft.Information.MsgBox(this, "MsgNGOAITENULL", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["NGOAI_TE"];
                    return;
                }

                if (((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["TY_GIA"] == null || ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["TY_GIA"].Equals(DBNull.Value))
                {
                    Vietsoft.Information.MsgBox(this, "MsgTYGIANULL", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["TY_GIA"];
                    rPhieuNhapKhoChiTiet.Cells["TY_GIA"].ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapTiGia", Commons.Modules.TypeLanguage);
                    return;
                }
                if (((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["TY_GIA_USD"] == null || ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["TY_GIA_USD"].Equals(DBNull.Value))
                {
                    Vietsoft.Information.MsgBox(this, "MsgTIGIAUSDNULL", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["TY_GIA_USD"];
                    return;
                }
                if (((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["DON_GIA"] == null || ((DataRowView)rPhieuNhapKhoChiTiet.DataBoundItem).Row["DON_GIA"].Equals(DBNull.Value))
                {
                    Vietsoft.Information.MsgBox(this, "MsgDONGIANULL", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    DgvPhieuNhapKhoChiTiet.CurrentCell = rPhieuNhapKhoChiTiet.Cells["DON_GIA"];
                    return;
                }
                #endregion
            }

            #endregion

            #region Kiem tra chi phi
            string sTMP = "";
            if (Convert.ToInt32(CboDangNhap.EditValue.ToString()) != 9)
            {
                if (!KiemDuLieuChiPhi(-1, out sTMP))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgChiPhiKhongCan", Commons.Modules.TypeLanguage) + "\n" + sTMP);
                    return;
                }
            }

            #endregion

            #region KiemTra so phieu co dung voi nam thang hien tai chi kiem voi trang thai add

            if (TrangThai.ToUpper() == "ADD")
            {
                string sPN = TxtMSDHN.Text;
                string sMSPN0ld = TxtMSDHN.Text;
                try
                {
                    DateTime ThangHT, ThangTxt;
                    ThangHT = DateTime.Parse(datNgayNhap.DateTime.Day.ToString() + "/" + sPN.ToString().Substring(5, 2) + "/" + sPN.ToString().Substring(3, 2));
                    ThangTxt = DateTime.Parse(datNgayNhap.Text);
                    if (ThangHT != ThangTxt)
                    {
                        sPN = Vietsoft.Information.GetID("PN", datNgayNhap.DateTime);
                        if (TxtSoDHN.Text == TxtMSDHN.Text)
                        {
                            TxtMSDHN.Text = sPN;
                            TxtSoDHN.Text = sPN;
                            ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"] = sPN;
                            ((DataRowView)BindingPhieuNhapKho.Current).Row["SO_PHIEU_XN"] = sPN;
                        }
                        else
                        {
                            TxtMSDHN.Text = sPN;
                            ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"] = sPN;
                        }

                        foreach (DataRow dr in TbPhieuNhapKhoPhuTung.Rows)
                        {
                            if (dr["MS_DH_NHAP_PT"].ToString() == sMSPN0ld)
                                dr["MS_DH_NHAP_PT"] = sPN;
                        }

                        foreach (DataRow dr in TbPhieuNhapKhoPhuTungChiTiet.Rows)
                        {
                            if (dr["MS_DH_NHAP_PT"].ToString() == sMSPN0ld)
                                dr["MS_DH_NHAP_PT"] = sPN;
                        }

                    }
                }
                catch { }
            }


            #endregion

            #region Kiem Tra lai so phieu neu da ton tai thi tu tang len 1 so
            if (TrangThai.ToUpper() == "ADD")
            {
                string sMSPN = "";
                string sMSPN0ld = TxtMSDHN.Text;
                sMSPN = Vietsoft.Information.GetID("PN", datNgayNhap.DateTime);
                if (sMSPN != TxtMSDHN.Text)
                {
                    if (TxtSoDHN.Text == TxtMSDHN.Text)
                    {
                        TxtMSDHN.Text = sMSPN;
                        TxtSoDHN.Text = sMSPN;
                        ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"] = sMSPN;
                        ((DataRowView)BindingPhieuNhapKho.Current).Row["SO_PHIEU_XN"] = sMSPN;
                    }
                    else
                    {
                        TxtMSDHN.Text = sMSPN;
                        ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"] = sMSPN;
                    }

                    foreach (DataRow dr in TbPhieuNhapKhoPhuTung.Rows)
                    {
                        if (dr["MS_DH_NHAP_PT"].ToString() == sMSPN0ld)
                            dr["MS_DH_NHAP_PT"] = sMSPN;
                    }

                    foreach (DataRow dr in TbPhieuNhapKhoPhuTungChiTiet.Rows)
                    {
                        if (dr["MS_DH_NHAP_PT"].ToString() == sMSPN0ld)
                            dr["MS_DH_NHAP_PT"] = sMSPN;
                    }

                }
            }

            #endregion

            TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "";
            TbPhieuNhapKhoPhuTung = TbPhieuNhapKhoPhuTung.DefaultView.ToTable();
            TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString().Trim() + "'";

            TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "";
            TbPhieuNhapKhoPhuTungChiTiet = TbPhieuNhapKhoPhuTungChiTiet.DefaultView.ToTable();
            TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" +
               ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() + "'";


            this.Cursor = Cursors.WaitCursor;
            SqlPhieuNhapKho.BeginTransaction();
            try
            {
                DataTable TbPhieuNhapKhoPhuTungTMP = TbPhieuNhapKhoPhuTung.DefaultView.ToTable(true, "MS_DH_NHAP_PT",
                       "MS_PT", "SO_LUONG_CTU", "SL_THUC_NHAP", "DON_GIA", "NGOAI_TE", "TY_GIA", "TY_GIA_USD",
                       "MS_VT_NCC", "BAO_HANH_DEN_NGAY", "SL_DA_SD", "XUAT_XU", "THANH_TIEN", "GHI_CHU", "MS_PT_CT",
                       "TEN_PT_CT", "Tax", "ID", "MS_CHI_TIET_DH", "MS_DH_NHAP_PT_GOC", "ID_GOC", "TT_TAX", "DON_GIA_GOC",
                       "TONG_CP_NHAP_KHAU_VT", "TONG_THUE_NK", "TONG_PHI_VAN_CHUYEN", "TONG_PHI_BAO_HIEM", "TONG_THUE_NHA_THAU",
                       "TONG_PHI6", "TONG_PHI7", "TONG_PHI8", "TONG_PHI9", "TONG_CP_KHAC_VT");
                DataTable dtTmp = new DataTable();

                string sBT = "PHIEU_NHAP_ADD" + Commons.Modules.UserName;
                switch (TrangThai)
                {
                    case "Add":
                        Vietsoft.DataInfo.InsertDataRow(SqlPhieuNhapKho, "SP_Y_INSERT_DON_HANG_NHAP", ((DataRowView)BindingPhieuNhapKho.Current).Row);
                        Vietsoft.DataInfo.InsertDataView(SqlPhieuNhapKho, "SP_Y_INSERT_DON_HANG_NHAP_VAT_TU", TbPhieuNhapKhoPhuTungTMP.DefaultView);
                        dtTmp = TbPhieuNhapKhoPhuTungChiTiet.DefaultView.ToTable();
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
                        SqlPhieuNhapKho.ExecuteNonQuery(CommandType.StoredProcedure, "AddVatTuChiTiet",
                            ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString(), sBT);
                        break;
                    case "Edit":
                        Vietsoft.DataInfo.UpdateDataRow(SqlPhieuNhapKho, "SP_Y_EDIT_DON_HANG_NHAP", ((DataRowView)BindingPhieuNhapKho.Current).Row);
                        if (!Convert.ToBoolean(chkIsLock.EditValue))
                        {
                            Vietsoft.DataInfo.UpdateDataView(SqlPhieuNhapKho, "SP_Y_INSERT_DON_HANG_NHAP_VAT_TU",
                                   "SP_Y_EDIT_DON_HANG_NHAP_VAT_TU", "SP_Y_CHECK_DON_HANG_NHAP_VAT_TU",
                                   TbPhieuNhapKhoPhuTungTMP.DefaultView, "MS_DH_NHAP_PT", "MS_PT", "ID");
                            dtTmp = TbPhieuNhapKhoPhuTungChiTiet.DefaultView.ToTable().Copy();
                            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
                            SqlPhieuNhapKho.ExecuteNonQuery(CommandType.StoredProcedure, "AddVatTuChiTiet",
                                ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString(), sBT);
                        }
                        break;
                }
                #region Luu Chi Phi
                DataTable dtCP = new DataTable();
                sBT = "IC_CHI_PHI_TMP" + Commons.Modules.UserName;
                dtCP = (DataTable)grdChiPhi.DataSource;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtCP, "");

                SqlPhieuNhapKho.ExecuteNonQuery(CommandType.StoredProcedure, "AddChiPhiDHN",
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString(), sBT);

                #endregion

                #region tranfer data
                if (Commons.Modules.iTRFData == 1)
                {
                    if (!TRFNhapKho(SqlPhieuNhapKho, TxtMSDHN.Text, -1))
                    {
                        SqlPhieuNhapKho.RollbackTransaction();

                        TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "";
                        TbPhieuNhapKhoPhuTung = TbPhieuNhapKhoPhuTung.DefaultView.ToTable();
                        TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "";
                        TbPhieuNhapKhoPhuTungChiTiet = TbPhieuNhapKhoPhuTungChiTiet.DefaultView.ToTable();
                        TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString().Trim() + "'";
                        DgvPhieuNhapKhoChiTiet.DataSource = TbPhieuNhapKhoPhuTung.DefaultView;
                        LocChiTiet(DgvPhieuNhapKhoChiTiet.CurrentRow.Index);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                #endregion
                SqlPhieuNhapKho.CommitTransaction();

                BindingPhieuNhapKho.EndEdit();
                BindingPhieuNhapKho.ResetAllowNew();
                BindingPhieuNhapKho.ResetBindings(true);
                TbPhieuNhapKho.AcceptChanges();
                TbPhieuNhapKhoPhuTung.AcceptChanges();
                TbPhieuNhapKhoPhuTungChiTiet.AcceptChanges();
                TrangThai = String.Empty;
                InitializeForm();
                ((DataTable)CboDDH.Properties.DataSource).DefaultView.RowFilter = "";

            }
            catch (Exception ex)
            {
                SqlPhieuNhapKho.RollbackTransaction();
                TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "";
                TbPhieuNhapKhoPhuTung = TbPhieuNhapKhoPhuTung.DefaultView.ToTable();
                TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "";
                TbPhieuNhapKhoPhuTungChiTiet = TbPhieuNhapKhoPhuTungChiTiet.DefaultView.ToTable();
                TbPhieuNhapKhoPhuTung.DefaultView.RowFilter = "MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString().Trim() + "'";
                DgvPhieuNhapKhoChiTiet.DataSource = TbPhieuNhapKhoPhuTung.DefaultView;
                Vietsoft.Information.MsgBox(this, "MsgUpdateError" + "\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            LocChiTiet(DgvPhieuNhapKhoChiTiet.CurrentRow.Index);

            try
            {
                LoadChiPhi(((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString());
            }
            catch
            {
                LoadChiPhi("-1");
            }
            txtTimVTri.Enabled = false;
            this.Cursor = Cursors.Default;
        }



        /// <summary>
        /// Không lưu dữ liệu
        /// </summary> 
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (CboDangNhap.EditValue.Equals(3)) CboDangNhap.ItemIndex = 1;
                Commons.Modules.SQLString = "BtnHuy";
                if (checkDataSouce > 0)
                {
                    BindingPhieuNhapKho.CancelEdit();
                    checkDataSouce = 0;
                }
                TbPhieuNhapKho.RejectChanges();
                TbPhieuNhapKhoPhuTung.RejectChanges();
                TbPhieuNhapKhoPhuTungChiTiet.RejectChanges();

                BindingPhieuNhapKho.ResetAllowNew();
                BindingPhieuNhapKho.ResetBindings(false);

                DgvPhieuNhapKho.DataSource = BindingPhieuNhapKho;
                DgvPhieuNhapKho.Columns["MS_DH_NHAP_PT"].DataPropertyName = "MS_DH_NHAP_PT";
                double SLH = 0;
                try
                {
                    SLH = Convert.ToDouble(TxtMSDHN.Text.ToString().Substring((TxtMSDHN.Text.ToString().Length) - 4, 4));
                }
                catch { }
                Vietsoft.SqlInfo SqlKT = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);

                if (TrangThai == "Add")
                {
                    double SLDH = Convert.ToDouble(SqlKT.ExecuteScalar(CommandType.Text,
                        "SELECT ID_I FROM TB_S_ID WHERE ID_H = 'PN' AND MONTH (ID_D) =  MONTH (getdate()) and YEAR ( ID_D) =  YEAR ( getdate()) "));
                    if (SLH == SLDH)
                    {
                        SLH = SLH - 1;
                        SqlKT.ExecuteNonQuery(CommandType.Text, "UPDATE TB_S_ID SET ID_I = " + SLH +
                            "  WHERE ID_H = 'PN' AND MONTH (ID_D) =  MONTH (getdate()) and YEAR ( ID_D) =  YEAR ( getdate()) ");
                    }
                }

            }
            catch { }
            TrangThai = String.Empty;
            Commons.Modules.SQLString = "";
            if (DgvPhieuNhapKho.RowCount < 2)
                LoadPhieuNhapKho();



            InitializeForm();
            ((DataTable)CboDDH.Properties.DataSource).DefaultView.RowFilter = "";
            try
            {
                LoadChiPhi(((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString());
            }
            catch
            {
                LoadChiPhi("-1");
            }
            LoadTongThanhTien();
            txtTimVTri.Enabled = false;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Thoát form
        /// </summary> 
        private void BtnThoat_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        //Chuyen du lieu wa trung gian
        private bool TRFNhapKho(Vietsoft.SqlInfo objTrans, string MsNhap, int TrangThai)
        {
            //if (Commons.IConnections.Server.ToLower() == "mashilove") return true;


            try
            {
                System.Data.DataTable dttmp = new System.Data.DataTable();
                dttmp.Load(objTrans.ExecuteReader(CommandType.StoredProcedure, "spTRFNhapKho", MsNhap, TrangThai));
                if (dttmp.Rows.Count > 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgVuiLongXemLaiDataTrungGian", Commons.Modules.TypeLanguage) + "\n" + dttmp.Rows[0][3].ToString() + "\n" + dttmp.Rows[0][5].ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {

                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgUpdateError", Commons.Modules.TypeLanguage) + "\n" + ex.Message);
                return false;
            }
            return true;
        }

        private void AddVitri(string vitri, double soluong)
        {
            int i = 0;
            if (soluong > 0)
            {
                if (DgvViTriPhuTung.Rows.Count == 1)
                {
                    DgvViTriPhuTung.Rows[0].Cells["SL_VT"].Value = soluong;
                    try
                    {
                        DgvViTriPhuTung.CurrentCell = DgvViTriPhuTung.Rows[0].Cells["MS_VI_TRI"];
                    }
                    catch { }
                }
                else
                {
                    DataTable dtTmp1 = new DataTable();
                    dtTmp1 = ((DataTable)DgvViTriPhuTung.DataSource).DefaultView.ToTable();
                    int index1 = 0;


                    string sSql = " SELECT TOP 1 MS_VI_TRI FROM IC_PHU_TUNG_KHO WHERE MS_KHO = " + CboKho.EditValue.ToString() + " AND MS_PT = '" + DgvPhieuNhapKhoChiTiet.CurrentRow.Cells["MS_PT"].Value.ToString() + "'";

                    DataTable dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sSql));



                    if (dtTmp.Rows.Count != 0)
                    {
                        try
                        {
                            DataRow[] rows = dtTmp1.Select("MS_VI_TRI = " + dtTmp.Rows[0][0].ToString());
                            foreach (DataRow row in rows)
                            {
                                index1 = dtTmp1.Rows.IndexOf(row);
                                if (index1 == index1) break;
                            }
                        }
                        catch { index1 = 0; }
                    }
                    else
                        index1 = int.Parse(vitri);



                    try
                    {
                        DgvViTriPhuTung.Rows[index1].Cells["SL_VT"].Value = soluong;
                        DgvViTriPhuTung.CurrentCell = DgvViTriPhuTung.Rows[index1].Cells["MS_VI_TRI"];
                    }
                    catch { }


                }
            }
        }

        private void CboDangNhap_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "BtnThem") return;
            try
            {
                CboDDH.DataBindings.Clear();
                CboDDH.DataBindings.Add("EditValue", BindingPhieuNhapKho, "MS_DON_HANG");
                if (TrangThai.Equals("Add") || TrangThai.Equals("Edit"))
                {

                    switch (int.Parse(CboDangNhap.EditValue.ToString()))
                    {
                        case 1:
                        case 3:
                            ((DataTable)CboNguoiNhap.Properties.DataSource).DefaultView.RowFilter = "VTRO = 4 AND KHACH_HANG = 1";
                            break;
                        case 2:
                        case 4:
                        case 5:
                        case 9:
                            ((DataTable)CboNguoiNhap.Properties.DataSource).DefaultView.RowFilter = "VTRO = 4 ";
                            break;
                        case 6:
                        case 10:
                            ((DataTable)CboNguoiNhap.Properties.DataSource).DefaultView.RowFilter = "VTRO = 4 AND KHACH_HANG = 0";
                            break;
                        default:
                            ((DataTable)CboNguoiNhap.Properties.DataSource).DefaultView.RowFilter = "VTRO = 4";
                            break;
                    }
                    CboNguoiNhap.EditValue = -1;
                    CboDDH.EditValue = "-1";
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DHX"] = "";
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DDH"] = "";
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] = "";
                    if (CboDangNhap.EditValue.Equals(6) || CboDangNhap.EditValue.Equals(10))
                    {
                        ((DataTable)CboDDH.Properties.DataSource).DefaultView.RowFilter = "DON_HANG = 0";
                        ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] = CboDDH.EditValue;
                    }
                    if (CboDangNhap.EditValue.Equals(3))
                    {
                        ((DataTable)CboDDH.Properties.DataSource).DefaultView.RowFilter = "DON_HANG = 1";
                        ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] = CboDDH.EditValue;

                    }
                }
                else
                    ((DataTable)CboNguoiNhap.Properties.DataSource).DefaultView.RowFilter = "VTRO =  -1";
            }
            catch { }

            if (TrangThai.Equals("Add") || TrangThai.Equals("Edit"))
            {
                if (CboDangNhap.EditValue.Equals(10) || CboDangNhap.EditValue.Equals(3) || CboDangNhap.EditValue.Equals(6))
                {
                    CboDDH.Enabled = true;
                }
                else
                {
                    CboDDH.Enabled = false;
                }

                try
                {
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DANG_NHAP"] = CboDangNhap.EditValue;

                }
                catch
                {
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DANG_NHAP"] = null;
                }
                if (Commons.Modules.sPrivate.ToUpper() == "PILMICO")
                {
                    if (CboNguoiNhap.Text == "")
                    {
                        CboNguoiNhap.EditValue = Commons.Modules.sMaNhanVienMD;
                        ((DataRowView)BindingPhieuNhapKho.Current).Row["NGUOI_NHAP"] = Commons.Modules.sMaNhanVienMD;
                    }
                }
            }
        }

        private void BtnLock_Click(object sender, EventArgs e)
        {
            if (!Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 63))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                "msgKhongCoQuyenLockPhieuNhap", Commons.Modules.TypeLanguage), this.Text);
                return;
            }
            if (DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, this.Name, "msgBanCoChacKhoaPhieu", Commons.Modules.TypeLanguage),
                    this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;

            string mspn = TxtMSDHN.Text;

            DataRow _row = ((DataRowView)BindingPhieuNhapKho.Current).Row;
            _row["LOCK"] = true;
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            SqlPhieuNhapKho.BeginTransaction();
            try
            {
                Vietsoft.DataInfo.UpdateDataRow(SqlPhieuNhapKho, "SP_Y_EDIT_DON_HANG_NHAP", _row);
                SqlPhieuNhapKho.ExecuteNonQuery("DELETE dbo.IC_DON_HANG_NHAP_VAT_TU_CHI_TIET WHERE MS_DH_NHAP_PT = N'" + _row["MS_DH_NHAP_PT"].ToString() + "' AND SL_VT IS NULL OR SL_VT <=0");
                if (!string.IsNullOrEmpty(Convert.ToString(CboDDH.EditValue)))
                {
                    if (Commons.Modules.sPrivate == "HUDA")
                    {
                        double SL_DDH = Convert.ToDouble(SqlPhieuNhapKho.ExecuteScalar("SELECT SUM(SL_DAT_HANG) FROM DON_DAT_HANG_CHI_TIET WHERE MS_DON_DAT_HANG ='" + CboDDH.EditValue.ToString() + "'").ToString());
                        double SL_NHAP = Convert.ToDouble(SqlPhieuNhapKho.ExecuteScalar("SELECT SUM(SL_THUC_NHAP)  FROM IC_DON_HANG_NHAP_VAT_TU A INNER JOIN IC_DON_HANG_NHAP B ON A.MS_DH_NHAP_PT=B.MS_DH_NHAP_PT WHERE B.MS_DDH ='" + CboDDH.EditValue.ToString() + "'").ToString());
                        if (SL_NHAP >= SL_DDH)
                        {
                            string NGAY_GIAO = SqlPhieuNhapKho.ExecuteScalar("SELECT CONVERT(nvarchar(10),MAX(ngay),101) AS NGAY FROM IC_DON_HANG_NHAP WHERE MS_DDH='" + CboDDH.Text + "'").ToString();
                            SqlPhieuNhapKho.ExecuteNonQuery("UPDATE DON_DAT_HANG SET NGAY_GIAO='" + NGAY_GIAO + "' WHERE MS_DON_DAT_HANG='" + CboDDH.EditValue.ToString() + "'");
                        }
                    }
                }

                Vietsoft.DataInfo.ClearData(new DataView(TbPhieuNhapKhoPhuTungChiTiet, "(SL_VT IS NULL OR SL_VT <=0) " +
                        " AND MS_DH_NHAP_PT = '" + ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() +
                        "'", "MS_PT", DataViewRowState.CurrentRows));
                // day du lieu ra data trung gian
                if (Commons.Modules.iTRFData == 1)
                {
                    if (!TRFNhapKho(SqlPhieuNhapKho, TxtMSDHN.Text, 1))
                    {
                        SqlPhieuNhapKho.RollbackTransaction();
                        TbPhieuNhapKho.RejectChanges();
                        return;
                    }
                }
                SqlPhieuNhapKho.CommitTransaction();

                //Kiem dong don de xuat
                try
                {
                    if (int.Parse(CboDangNhap.EditValue.ToString()) == 3)
                    {
                        DataTable dtTmp = new DataTable();
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sKiemDongDHX", CboDDH.EditValue.ToString(), TxtMSDHN.Text));
                        if (dtTmp.Rows.Count > 0)
                        {
                            if (int.Parse(dtTmp.Rows[0][0].ToString()) == 0)
                            {
                                //string sSql = "UPDATE DE_XUAT_MUA_HANG SET NGAY_DONG = GETDATE(), NGUOI_DONG = N'" + Commons.Modules.UserName + "' WHERE MS_DE_XUAT = '" + TxtMS_DE_XUAT.Text + "' ";
                                string sSql = "UPDATE DE_XUAT_MUA_HANG SET NGAY_DONG = CONVERT(DATETIME,CONVERT(NVARCHAR(10),GETDATE(),101)), " +
                                        " NGUOI_DONG = N'" + Commons.Modules.UserName + "', TRANG_THAI = 4 , " +
                                        " TEN_TRANG_THAI = N'Đóng' WHERE MS_DE_XUAT = '" + CboDDH.EditValue.ToString() + "'";
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                            }
                        }
                    }
                }
                catch { }
                BindingPhieuNhapKho.RemoveCurrent();
                TbPhieuNhapKho.AcceptChanges();

            }
            catch
            {
                SqlPhieuNhapKho.RollbackTransaction();
                TbPhieuNhapKho.RejectChanges();
                Vietsoft.Information.MsgBox(this, "MsgUpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            #region đối với trung nguyên khi mà lock phiếu đề của dạng nhập từ đề xuất thì tự động tạo luôn phiếu xuất khác để xuất nó đi

            if (Commons.Modules.sPrivate == "TRUNGNGUYEN" && int.Parse(CboDangNhap.EditValue.ToString()) == 3)
            {
                //get ID
                string mspx = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "sp_get_id", "PX", DateTime.Now));
                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spUpdateAutoXuatDeXuat", mspx, mspn);
                }
                catch
                {
                }
            }
            #endregion

            InitializeControl();
            InitializeForm();
        }

        private void TxtSoDHN_Validated(object sender, EventArgs e)
        {
            if (TxtSoDHN.Text.Trim() != "")
            {
                Vietsoft.SqlInfo Sql = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                System.Data.DataTable Tb = new System.Data.DataTable();
                Tb.Load(Sql.ExecuteReader(CommandType.StoredProcedure, "CheckSoDonHangNhap", TxtSoDHN.Text.Trim(), TxtMSDHN.Text.Trim()));
                if (Tb.Rows.Count > 0)
                {
                    Vietsoft.Information.MsgBox(this, "MsgSoDHNTontai", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    TxtSoDHN.Focus();
                    return;
                }
            }
        }

        private void CboDDH_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "BtnThem") return;
            if (TrangThai.Equals("Add") || TrangThai.Equals("Edit"))
            {
                ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DHX"] = "";
                ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DDH"] = "";
                ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] = "";

                try
                {

                    if (CboDDH.ItemIndex >= 0)
                    {
                        ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DON_HANG"] = CboDDH.EditValue.ToString();
                        //if (CboDangNhap.EditValue.Equals(6) || CboDangNhap.EditValue.Equals(10))
                        //{

                        //    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DHX"] = CboDDH.EditValue.ToString();
                        //}
                        //if (CboDangNhap.EditValue.Equals(3))
                        //{
                        //    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DDH"] = CboDDH.EditValue.ToString();
                        //}


                        //Vietsoft.SqlInfo Sql = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                        //CboNguoiNhap.EditValue = Sql.ExecuteScalar(CommandType.Text, "SELECT MS_KH FROM KHACH_HANG INNER JOIN DON_DAT_HANG ON KHACH_HANG.TEN_CONG_TY = DON_DAT_HANG.NHA_CUNG_CAP WHERE DON_DAT_HANG.MS_DON_DAT_HANG='" + CboDDH.Text.Trim() + "'");
                        //CboNguoiNhap.Enabled = false;
                        //btnTimNCty.Enabled = false;
                    }
                    else
                    {
                        CboNguoiNhap.EditValue = -1;
                        CboNguoiNhap.Enabled = true;
                        btnTimNCty.Enabled = true;
                    }
                }
                catch { }
            }
        }

        private void DgvPhieuNhapKhoChiTiet_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                object count = SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, CommandType.Text, "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM [SVM_TRANS_ACC] WHERE IO_KEY=N''" + TxtMSDHN.Text + "'' AND STATUS = ''C'' AND mng_05 = N''" + DgvPhieuNhapKhoChiTiet.CurrentRow.Cells["MS_PT"].Value.ToString() + "''')");

                if (Convert.ToInt16(count) > 0)
                {
                    e.Cancel = true;

                    return;
                }
            }
            catch { }

        }

        private void DgvViTriPhuTung_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!BtnHuy.Focused)
            {
                try
                {
                    int index = e.ColumnIndex;
                    double sl = 0;
                    switch (index)
                    {
                        case 1:
                            sl = Convert.ToDouble(e.FormattedValue);
                            break;

                    }

                    if (sl < 0)
                        e.Cancel = true;
                }
                catch { }
            }
        }

        private void DgvPhieuNhapKhoChiTiet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!BtnHuy.Focused)
            {
                try
                {
                    int index = e.ColumnIndex;
                    double sl = 0;
                    switch (DgvPhieuNhapKhoChiTiet.Columns[e.ColumnIndex].Name)
                    {
                        case "SO_LUONG_CTU":
                            sl = Convert.ToDouble(e.FormattedValue);
                            break;
                        case "SL_THUC_NHAP":
                            sl = Convert.ToDouble(e.FormattedValue);
                            break;
                    }

                    if (sl < 0)
                        e.Cancel = true;
                }
                catch { }
            }
        }

        private void DgvPhieuNhapKhoChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (Commons.Modules.SQLString == "0Tinh") return;

            switch (DgvPhieuNhapKhoChiTiet.Columns[e.ColumnIndex].Name.ToUpper())
            {
                case "SO_LUONG_CTU":
                    DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["SL_THUC_NHAP"].Value = DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["SO_LUONG_CTU"].Value;
                    ResetChiPhi(e.RowIndex);
                    break;
                case "NGOAI_TE":
                    #region Ngoai Te
                    try
                    {
                        DataTable TbNgoaiTe = new DataTable();
                        Vietsoft.SqlInfo SqlNgoaiTe = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                        if (Commons.Modules.sPrivate == "ACECOOK")
                        {
                            DateTime dTNgay, dDNgay;
                            dTNgay = datNgayNhap.DateTime.Date;
                            dTNgay = Convert.ToDateTime("01/" + dTNgay.Month.ToString() + "/" + dTNgay.Year.ToString());
                            dDNgay = datNgayNhap.DateTime.Date;

                            string sSql = " SELECT dbo.NGOAI_TE.TEN_NGOAI_TE, ISNULL(TMP2.TI_GIA,0) AS TI_GIA, ISNULL(TMP2.TI_GIA_USD,0) AS TI_GIA_USD " +
                                         " FROM (SELECT dbo.TI_GIA_NT.NGOAI_TE, ISNULL(dbo.TI_GIA_NT.TI_GIA ,0 ) AS TI_GIA, ISNULL(dbo.TI_GIA_NT.TI_GIA_USD,0) AS TI_GIA_USD " +
                                         " FROM dbo.TI_GIA_NT INNER JOIN  " +
                                         " (SELECT NGOAI_TE , MAX (NGAY) AS NGAY FROM dbo.TI_GIA_NT  WHERE NGAY_NHAP BETWEEN '" + dTNgay.ToString("MM/dd/yyyy") + "' AND '" +
                                         dDNgay.ToString("MM/dd/yyyy") + "'  AND NGOAI_TE = N'" + DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["NGOAI_TE"].Value.ToString() + "' " +
                                         " GROUP BY NGOAI_TE)TMP1 ON dbo.TI_GIA_NT.NGOAI_TE = TMP1.NGOAI_TE AND dbo.TI_GIA_NT.NGAY = TMP1.NGAY ) TMP2  " +
                                         " INNER JOIN dbo.NGOAI_TE ON TMP2.NGOAI_TE = dbo.NGOAI_TE.NGOAI_TE  " +
                                         " WHERE  dbo.NGOAI_TE.TEN_NGOAI_TE = '" + DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["NGOAI_TE"].Value.ToString() + "' ";

                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.Text, sSql));
                            if (TbNgoaiTe.Rows.Count <= 0)
                            {
                                sSql = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapTiGia", Commons.Modules.TypeLanguage);

                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].ErrorText = sSql;
                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].ErrorText = sSql;

                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = DBNull.Value;
                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = DBNull.Value;
                            }
                            else
                            {
                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = TbNgoaiTe.Rows[0]["TI_GIA"];
                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                            }
                        }
                        else
                        {

                            TbNgoaiTe.Load(SqlNgoaiTe.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TY_GIA_NGOAI_TE", DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["NGOAI_TE"].Value));
                            if (TbNgoaiTe.Rows.Count > 0)
                            {
                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = TbNgoaiTe.Rows[0]["TI_GIA"];
                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = TbNgoaiTe.Rows[0]["TI_GIA_USD"];
                            }
                            else
                            {
                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = DBNull.Value;
                                DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = DBNull.Value;
                            }
                        }
                    }
                    catch
                    {
                        DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value = DBNull.Value;
                        DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA_USD"].Value = DBNull.Value;
                    }
                    ResetChiPhi(e.RowIndex);
                    break;
                #endregion
                case "TAX":
                    #region Tinh thanh tien thue
                    try
                    {
                        DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TT_TAX"].Value =
                            ((Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["DON_GIA_GOC"].Value) * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value) *
                                Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TAX"].Value)) / 100) * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["SL_THUC_NHAP"].Value);

                    }
                    catch
                    {
                        DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TT_TAX"].Value = DBNull.Value;
                    }
                    ResetChiPhi(e.RowIndex);

                    #endregion
                    break;
                case "TT_TAX":
                    #region Tinh thanh tien thue
                    try
                    {
                        DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TAX"].Value =
                            (Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TT_TAX"].Value) * 100) /
                                (Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["DON_GIA_GOC"].Value) * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TY_GIA"].Value) * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["SL_THUC_NHAP"].Value));
                    }
                    catch//141,543.01
                    {
                        DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["TT_TAX"].Value = DBNull.Value;
                    }
                    ResetChiPhi(e.RowIndex);

                    #endregion
                    break;

            }
            #region Kiem so luong chi tiet khong co thi tu dong add
            try
            {
                DataView DgvTmp = new DataView(TbPhieuNhapKhoPhuTungChiTiet, "MS_DH_NHAP_PT = '" +
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() +
                    "' AND MS_PT = '" + DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["MS_PT"].Value.ToString() + "' " +
                    " AND ID = " + ((DataRowView)DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].DataBoundItem).Row["ID"].ToString(), "",
                    DataViewRowState.CurrentRows);
                double SlVT = 0;
                try
                {
                    DataTable dt = DgvTmp.ToTable().Copy();
                    SlVT = Convert.ToDouble(dt.Compute("Sum(SL_VT)", ""));
                }
                catch { }

                if (SlVT != double.Parse(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["SL_THUC_NHAP"].Value.ToString()))
                {

                    AddVitri(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["VI_TRI"].Value.ToString(), (double)DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["SL_THUC_NHAP"].Value);
                }
            }
            catch { }
            #endregion
            CapNhapDonGiaGoc(e.RowIndex);
        }

        private void DgvPhieuNhapKhoChiTiet_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    LocChiTiet(e.RowIndex);

                    try
                    {
                        DgvViTriPhuTung.CurrentCell = DgvViTriPhuTung.Rows[0].Cells["MS_VI_TRI"];
                    }
                    catch { }
                }
                catch { TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1"; }
            }
        }

        private void DgvPhieuNhapKhoChiTiet_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            TbPhieuNhapKhoPhuTung.AcceptChanges();
            TbPhieuNhapKhoPhuTungChiTiet.AcceptChanges();
            LoadTongThanhTien();
        }

        private void DgvPhieuNhapKhoChiTiet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            if (TrangThai != "Add" && TrangThai != "Edit")
            {
                if (BindingPhieuNhapKho.Current != null)
                {
                    if (((DataRowView)BindingPhieuNhapKho.Current).Row["LOCK"].Equals(true))
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        if (Vietsoft.Information.MsgBox(this, "MsgCheckDelete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            //kiem tra
                            //if close thong bao then e.Cancel = true
                            try
                            {
                                object count = SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, CommandType.Text, "SELECT * FROM OPENQUERY ([SEPHIROTH],'SELECT COUNT(*) FROM [SVM_TRANS_ACC] WHERE IO_KEY=N''" + TxtMSDHN.Text + "'' AND STATUS = ''C'' AND mng_05 = N''" + e.Row.Cells["MS_PT"].Value.ToString() + "''')");


                                if (Convert.ToInt16(count) > 0)
                                {
                                    e.Cancel = true;

                                    return;
                                }
                            }
                            catch { }
                            SqlPhieuNhapKho.BeginTransaction();
                            try
                            {
                                Vietsoft.DataInfo.DeleteDataRow(SqlPhieuNhapKho, "DeleteVI_TRI_KHO_VAT_TU",
                                    ((DataRowView)e.Row.DataBoundItem).Row, "MS_DH_NHAP_PT", "MS_PT", "ID");
                                Vietsoft.DataInfo.DeleteDataView(SqlPhieuNhapKho,
                                    "SP_Y_DELETE_DON_HANG_NHAP_VAT_TU_CHI_TIET",
                                    TbPhieuNhapKhoPhuTungChiTiet.DefaultView,
                                    "MS_DH_NHAP_PT", "MS_PT", "MS_VI_TRI", "ID");
                                Vietsoft.DataInfo.DeleteDataRow(SqlPhieuNhapKho, "SP_Y_DELETE_DON_HANG_NHAP_VAT_TU",
                                    ((DataRowView)e.Row.DataBoundItem).Row, "MS_DH_NHAP_PT", "MS_PT", "ID");

                                if (Commons.Modules.iTRFData == 1)
                                {
                                    System.Data.DataTable dttmp = new System.Data.DataTable();
                                    dttmp.Load(SqlPhieuNhapKho.ExecuteReader(CommandType.StoredProcedure, "spTRFDelNhapKho",
                                        ((DataRowView)e.Row.DataBoundItem).Row["MS_DH_NHAP_PT"], ((DataRowView)e.Row.DataBoundItem).Row["MS_PT"],
                                        ((DataRowView)e.Row.DataBoundItem).Row["ID"]));

                                    if (dttmp.Rows.Count > 0)
                                    {
                                        MessageBox.Show(dttmp.Rows[0][3].ToString() + "\n" + dttmp.Rows[0][5].ToString());
                                        e.Cancel = true;
                                        SqlPhieuNhapKho.RollbackTransaction();
                                        return;
                                    }
                                }

                                SqlPhieuNhapKho.CommitTransaction();
                                Vietsoft.DataInfo.ClearData(TbPhieuNhapKhoPhuTungChiTiet.DefaultView);
                            }
                            catch
                            {
                                SqlPhieuNhapKho.RollbackTransaction();
                                e.Cancel = true;
                                Vietsoft.Information.MsgBox(this, "MsgDeleteError", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
            LoadTongThanhTien();
        }

        private void lokWareHouse_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadPhieuNhapKho();
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
                        LoadPhieuNhapKho();
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
                        LoadPhieuNhapKho();
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

        private void chkIsLock_CheckedChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadPhieuNhapKho();

            if (TrangThai == "")
                InitializeForm();

        }

        private void MskDiem1_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MskDiem1.Text.Trim()))
            {
                if (Convert.ToDouble(MskDiem1.Text) < 0 || Convert.ToDouble(MskDiem1.Text) > 10)
                {
                    Vietsoft.Information.MsgBox(this, "MsgMskDiem1", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    MskDiem1.Focus();
                }
            }
        }

        private void MskDiem2_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MskDiem2.Text.Trim()))
            {
                if (Convert.ToDouble(MskDiem2.Text) < 0 || Convert.ToDouble(MskDiem2.Text) > 10)
                {
                    Vietsoft.Information.MsgBox(this, "MsgMskDiem2", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    MskDiem2.Focus();
                }
            }
        }

        private void MskDiem3_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(MskDiem3.Text.Trim()))
                {
                    if (Convert.ToDouble(MskDiem3.Text) < 0 || Convert.ToDouble(MskDiem3.Text) > 10)
                    {
                        Vietsoft.Information.MsgBox(this, "MsgMskDiem3", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        MskDiem3.Focus();
                    }
                }
            }
            catch { MskDiem3.Focus(); }
        }

        private void btnAutoDH_Click(object sender, EventArgs e)
        {
            frmChonDonHang frm = new frmChonDonHang();
            frm.MS_DH_NHAP_PT = TxtMSDHN.Text;
            frm.NGUOI_NHAP = CboNguoiNhap.EditValue.ToString();
            DialogResult res = frm.ShowDialog();
            if (res.Equals(DialogResult.OK))
            {
                BindingPhieuNhapKho.EndEdit();
                TbPhieuNhapKho.AcceptChanges();
                CboDangNhap.EditValue = 3;
                CboDDH.EditValue = frm.MS_DDH;
                CboNguoiNhap.EditValue = frm.MS_KH;
            }

        }

        private void CboKho_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;
                if (Commons.Modules.SQLString == "BtnThem") return;
                if (TrangThai.Equals("Add") || TrangThai.Equals("Edit"))
                {

                    string sql = "SELECT ISNULL(dbo.CONG_NHAN.HO, N'') + ' ' + ISNULL(dbo.CONG_NHAN.TEN, N'') AS HOTEN FROM dbo.IC_KHO INNER JOIN  dbo.CONG_NHAN ON dbo.IC_KHO.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN WHERE  dbo.IC_KHO.MS_KHO='" + CboKho.EditValue.ToString() + "'";
                    TxtThuKhoKy.Text = SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, CommandType.Text, sql).ToString();
                }
            }
            catch { TxtThuKhoKy.Text = ""; }

        }

        private void cboNLap_Validating(object sender, CancelEventArgs e)
        {
            string chuoi = cboNLap.Text;
            chuoi = chuoi.Trim();

            if (chuoi != "")
            {
                if (cboNLap.EditValue == null || cboNLap.EditValue.Equals(DBNull.Value))
                {
                    cboNLap.Focus();
                    Vietsoft.Information.MsgBox(this, "MsgNguoiLap", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }


        private void LocChiTiet(int dong)
        {
            try
            {
                TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_DH_NHAP_PT"].DefaultValue = ((DataRowView)DgvPhieuNhapKhoChiTiet.Rows[dong].DataBoundItem).Row["MS_DH_NHAP_PT"];
                TbPhieuNhapKhoPhuTungChiTiet.Columns["MS_PT"].DefaultValue = ((DataRowView)DgvPhieuNhapKhoChiTiet.Rows[dong].DataBoundItem).Row["MS_PT"];
                TbPhieuNhapKhoPhuTungChiTiet.Columns["ID"].DefaultValue = ((DataRowView)DgvPhieuNhapKhoChiTiet.Rows[dong].DataBoundItem).Row["ID"];

                if (BtnLuu.Visible == true)
                {
                    try
                    {
                        string dk = "";
                        TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "(TEN_VI_TRI LIKE '%" + txtTimVTri.Text + "%' OR MS_VI_TRI = " + txtTimVTri.Text + ") AND MS_PT = '" + DgvPhieuNhapKhoChiTiet.Rows[dong].Cells["MS_PT"].Value.ToString() + "' AND MS_DH_NHAP_PT = '" + TxtMSDHN.Text + "' AND ID = " + DgvPhieuNhapKhoChiTiet.Rows[dong].Cells["ID"].Value.ToString() + "";

                    }
                    catch (Exception ex) { TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = " MS_PT = '" + DgvPhieuNhapKhoChiTiet.Rows[dong].Cells["MS_PT"].Value.ToString() + "' AND MS_DH_NHAP_PT = '" + TxtMSDHN.Text + "' AND  ID = " + DgvPhieuNhapKhoChiTiet.Rows[dong].Cells["ID"].Value.ToString() + ""; }
                }
                else
                {
                    TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = " " +
                    "SL_VT > 0 AND MS_DH_NHAP_PT = '" + ((DataRowView)DgvPhieuNhapKhoChiTiet.Rows[dong].DataBoundItem).Row["MS_DH_NHAP_PT"].ToString() + "' " +
                    " AND MS_PT = '" + ((DataRowView)DgvPhieuNhapKhoChiTiet.Rows[dong].DataBoundItem).Row["MS_PT"].ToString() + "' " +
                    " AND ID = " + ((DataRowView)DgvPhieuNhapKhoChiTiet.Rows[dong].DataBoundItem).Row["ID"].ToString();
                }



            }
            catch
            {
                TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "0=1";
            }
        }

        private void txtLPN_TextChanged(object sender, EventArgs e)
        {
            LocData();
            InitializeForm();

        }

        private void LocData()
        {
            string dk = "";
            try
            {

                if (txtLPN.Text.Length != 0) dk = dk + " OR MS_DH_NHAP_PT LIKE '%" + txtLPN.Text + "%' ";
                if (txtLPN.Text.Length != 0) dk = dk + " OR SO_PHIEU_XN LIKE '%" + txtLPN.Text + "%' ";
                if (txtLPN.Text.Length != 0) dk = dk + " OR TEN_KHO LIKE '%" + txtLPN.Text + "%' ";
                if (txtLPN.Text.Length != 0) dk = dk + " OR SO_CHUNG_TU LIKE '%" + txtLPN.Text + "%' ";
                TbPhieuNhapKho.DefaultView.RowFilter = dk.Substring(4, dk.Length - 4);
            }
            catch { TbPhieuNhapKho.DefaultView.RowFilter = ""; }


            try
            {
                DataView dv = new DataView(TbPhieuNhapKho);
                if (dk.Length > 0) dv.RowFilter = dk.Substring(4, dk.Length - 4);
                lbl.Text = sTong + " : " + dv.Count.ToString();

            }
            catch { lbl.Text = sTong + " : 0"; }

        }



        private void BtnIn_Click(object sender, EventArgs e)
        {
            if (Commons.Modules.sPrivate.Trim().ToUpper() == "ADC")
            {
                InPhieuNhapRongAChau();
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "ACECOOK")
            {
                InPhieuNhapACE();
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "DUYTAN")
            {
                CreateRPT_DUYTAN();
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "KKTL")
            {
                CreateRPT_KKTL();
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "NTD")
            {
                CreateRPT_NTD();
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED")
            {
                InPhieuNhapGreenFeed();
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "SHISEIDO")
            {
                InPhieuNhapSSD();
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "VINHHOAN")
            {
                InPhieuNhapVinhHoan();
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "VARD")
            {
                CreateInVard(TxtThuKhoKy.Text);
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "NUTIFOOD")
            {
                CreateRPTNU(TxtThuKhoKy.Text);
                return;
            }
            if (Commons.Modules.sPrivate.ToUpper() == "TRUNGNGUYEN")
            {
                CreateRPTN(TxtThuKhoKy.Text);
                return;
            }

            try
            {
                CreateRPT(TxtThuKhoKy.Text);
            }
            catch { CreateRPT(""); }
        }

        private void InPhieuNhapRongAChau()
        {
            try
            {
                string sMSPN;
                sMSPN = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString();

                this.Cursor = Cursors.WaitCursor;
                frmReport frmRptDexuat = new frmReport();
                frmRptDexuat.rptName = "rptPhieuNhapADC";

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetInPhieuNhapADC", sMSPN, Commons.Modules.TypeLanguage));
                dtTmp.TableName = "NHAP_KHO_ADC";
                frmRptDexuat.AddDataTableSource(dtTmp);


                System.Data.DataTable TbTieuDe = new System.Data.DataTable();
                TbTieuDe.Columns.Add("MAU_SO");
                TbTieuDe.Columns.Add("LB_HANH");
                TbTieuDe.Columns.Add("NGAY_BH");
                TbTieuDe.Columns.Add("TIEU_DE_NK_DAC");

                TbTieuDe.Columns.Add("SO_PHIEU");
                TbTieuDe.Columns.Add("NGAY_NHAP");
                TbTieuDe.Columns.Add("KHO_NHAP");
                TbTieuDe.Columns.Add("DANG_NHAP");
                TbTieuDe.Columns.Add("NGUOI_NHAP");
                TbTieuDe.Columns.Add("GHI_CHU");


                TbTieuDe.Columns.Add("STT");
                TbTieuDe.Columns.Add("MHH");
                TbTieuDe.Columns.Add("TEN");
                TbTieuDe.Columns.Add("DVT");
                TbTieuDe.Columns.Add("SL_NHAP");
                TbTieuDe.Columns.Add("DON_GIA");
                TbTieuDe.Columns.Add("THANH_TIEN");

                TbTieuDe.Columns.Add("TRUONG_BP");
                TbTieuDe.Columns.Add("THU_KHO");
                TbTieuDe.Columns.Add("NGUOI_NHAN_HANG");
                TbTieuDe.Columns.Add("NGUOI_LAP");

                TbTieuDe.Columns.Add("NGUOI_NHAN");
                TbTieuDe.Columns.Add("NGUOI_DX");

                TbTieuDe.Columns.Add("TMP1");
                TbTieuDe.Columns.Add("TMP2");
                TbTieuDe.Columns.Add("TMP3");
                TbTieuDe.Columns.Add("TMP4");
                TbTieuDe.Columns.Add("TMP5");

                DataRow rTitle = TbTieuDe.NewRow();

                rTitle["MAU_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "MAU_SO", Commons.Modules.TypeLanguage);
                rTitle["LB_HANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "LB_HANH", Commons.Modules.TypeLanguage);
                rTitle["NGAY_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "NGAY_BH", Commons.Modules.TypeLanguage);
                rTitle["TIEU_DE_NK_DAC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "TIEU_DE_NK_DAC", Commons.Modules.TypeLanguage);

                rTitle["SO_PHIEU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "SO_PHIEU", Commons.Modules.TypeLanguage);
                rTitle["NGAY_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "NGAY_NHAP", Commons.Modules.TypeLanguage);
                rTitle["KHO_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "KHO_NHAP", Commons.Modules.TypeLanguage);
                rTitle["DANG_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "DANG_NHAP", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "NGUOI_NHAP", Commons.Modules.TypeLanguage);
                rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "GHI_CHU", Commons.Modules.TypeLanguage);

                rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "STT", Commons.Modules.TypeLanguage);
                rTitle["MHH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "MHH", Commons.Modules.TypeLanguage);
                rTitle["TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "TEN", Commons.Modules.TypeLanguage);
                rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "DVT", Commons.Modules.TypeLanguage);
                rTitle["SL_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "SL_NHAP", Commons.Modules.TypeLanguage);
                rTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "DON_GIA", Commons.Modules.TypeLanguage);
                rTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "THANH_TIEN", Commons.Modules.TypeLanguage);


                rTitle["TRUONG_BP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "TRUONG_BP", Commons.Modules.TypeLanguage);
                rTitle["THU_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "THU_KHO", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_NHAN_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "NGUOI_NHAN_HANG", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "NGUOI_LAP", Commons.Modules.TypeLanguage);


                rTitle["NGUOI_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "NGUOI_NHAN", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_DX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "NGUOI_DX", Commons.Modules.TypeLanguage);

                rTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "TMP1", Commons.Modules.TypeLanguage);
                rTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "TMP2", Commons.Modules.TypeLanguage);
                rTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "TMP3", Commons.Modules.TypeLanguage);
                rTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "TMP4", Commons.Modules.TypeLanguage);
                rTitle["TMP5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapADC", "TMP5", Commons.Modules.TypeLanguage);

                TbTieuDe.TableName = "TIEU_DE_NK_ADC";
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

        private void InPhieuNhapACE()
        {
            try
            {
                string sMSPN;
                sMSPN = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString();

                this.Cursor = Cursors.WaitCursor;
                frmReport frmRptDexuat = new frmReport();
                frmRptDexuat.rptName = "rptPhieuNhapACE";

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetInPhieuNhapACE", sMSPN, Commons.Modules.TypeLanguage));
                dtTmp.TableName = "NHAP_KHO_ACE";
                frmRptDexuat.AddDataTableSource(dtTmp);

                dtTmp = new DataTable();
                dtTmp = (DataTable)grdChiPhi.DataSource;
                dtTmp.TableName = "CHI_PHI_NK_ACE";
                frmRptDexuat.AddDataTableSource(dtTmp);



                System.Data.DataTable TbTieuDe = new System.Data.DataTable();
                TbTieuDe.Columns.Add("SO");
                TbTieuDe.Columns.Add("TIEU_DE");
                TbTieuDe.Columns.Add("INPUT");
                TbTieuDe.Columns.Add("NGAY1");
                TbTieuDe.Columns.Add("DON_VI");
                TbTieuDe.Columns.Add("CHUNG_TU");
                TbTieuDe.Columns.Add("NGAY2");
                TbTieuDe.Columns.Add("KHO");
                TbTieuDe.Columns.Add("NGAY3");
                TbTieuDe.Columns.Add("STT");
                TbTieuDe.Columns.Add("MS_PT");
                TbTieuDe.Columns.Add("TEN_PT");
                TbTieuDe.Columns.Add("DVT");
                TbTieuDe.Columns.Add("SO_LUONG");
                TbTieuDe.Columns.Add("DGIA");
                TbTieuDe.Columns.Add("TTIEN");
                TbTieuDe.Columns.Add("GHI_CHU");
                TbTieuDe.Columns.Add("NO");
                TbTieuDe.Columns.Add("ID");
                TbTieuDe.Columns.Add("NAME");
                TbTieuDe.Columns.Add("UNIT");
                TbTieuDe.Columns.Add("QUA");
                TbTieuDe.Columns.Add("UPRICE");
                TbTieuDe.Columns.Add("AMOUNT");
                TbTieuDe.Columns.Add("NOTE");
                TbTieuDe.Columns.Add("TONG_CONG");
                TbTieuDe.Columns.Add("THANH_TIEN");
                TbTieuDe.Columns.Add("TOTAL");
                TbTieuDe.Columns.Add("NGUOI_LAP");
                TbTieuDe.Columns.Add("PSXUAT");
                TbTieuDe.Columns.Add("PCDIEN");
                TbTieuDe.Columns.Add("TNMAY");
                TbTieuDe.Columns.Add("GDOC");
                TbTieuDe.Columns.Add("BKEEPER");
                TbTieuDe.Columns.Add("PDEPT");
                TbTieuDe.Columns.Add("MDEPT");
                TbTieuDe.Columns.Add("FMANAGER");
                TbTieuDe.Columns.Add("DIC");
                TbTieuDe.Columns.Add("DU_1");
                TbTieuDe.Columns.Add("DU_2");
                TbTieuDe.Columns.Add("DU_3");

                DateTime Ngay;
                string sTmp = "";

                DataRow rTitle = TbTieuDe.NewRow();
                rTitle["SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "SO",
                    Commons.Modules.TypeLanguage) + " " + TxtMSDHN.Text;
                rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "TIEU_DE", Commons.Modules.TypeLanguage);
                rTitle["INPUT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "INPUT", Commons.Modules.TypeLanguage);
                try
                {
                    Ngay = datNgayNhap.DateTime.Date;
                }
                catch { Ngay = Convert.ToDateTime(null); }
                //if (Ngay == Convert.ToDateTime(null))
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Ngay", Commons.Modules.TypeLanguage) + " ..... " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Thang", Commons.Modules.TypeLanguage) + " ..... " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Nam", Commons.Modules.TypeLanguage) + " ...... ";
                //else
                //    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Ngay", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("dd") + " " +
                //        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Thang", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("MM") + " " +
                //        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Nam", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("yyyy") + " ";

                rTitle["NGAY1"] = sTmp;

                rTitle["DON_VI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "DON_VI",
                    Commons.Modules.TypeLanguage) + " : " + CboNguoiNhap.Text;
                rTitle["CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "CHUNG_TU",
                    Commons.Modules.TypeLanguage) + " : " + TxtSoCT.Text;
                try
                {
                    Ngay = Convert.ToDateTime(MskNgayCT.Text);
                }
                catch { Ngay = Convert.ToDateTime(null); }
                if (Ngay == Convert.ToDateTime(null))
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Ngay", Commons.Modules.TypeLanguage) + " " + "  " + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Thang", Commons.Modules.TypeLanguage) + " " + "  " + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Nam", Commons.Modules.TypeLanguage) + " " + "    " + " ";
                else
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Ngay", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("dd") + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Thang", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("MM") + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Nam", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("yyyy") + " ";

                rTitle["NGAY2"] = sTmp;
                rTitle["KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "KHO", Commons.Modules.TypeLanguage) + " : " + CboKho.Text;
                try
                {
                    Ngay = datNgayNhap.DateTime.Date;
                }
                catch { Ngay = Convert.ToDateTime(null); }
                if (Ngay == Convert.ToDateTime(null))
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Ngay", Commons.Modules.TypeLanguage) + " " + "  " + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Thang", Commons.Modules.TypeLanguage) + " " + "  " + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Nam", Commons.Modules.TypeLanguage) + " " + "    " + " ";
                else
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Ngay", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("dd") + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Thang", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("MM") + " " +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "Nam", Commons.Modules.TypeLanguage) + " " + Ngay.ToString("yyyy") + " ";
                rTitle["NGAY3"] = sTmp;
                rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "STT", Commons.Modules.TypeLanguage);
                rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "MS_PT", Commons.Modules.TypeLanguage);
                rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "TEN_PT", Commons.Modules.TypeLanguage);
                rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "DVT", Commons.Modules.TypeLanguage);
                rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "SO_LUONG", Commons.Modules.TypeLanguage);
                rTitle["DGIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "DGIA", Commons.Modules.TypeLanguage);
                rTitle["TTIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "TTIEN", Commons.Modules.TypeLanguage);
                rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "GHI_CHU", Commons.Modules.TypeLanguage);
                rTitle["NO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "NO", Commons.Modules.TypeLanguage);
                rTitle["ID"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "ID", Commons.Modules.TypeLanguage);
                rTitle["NAME"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "NAME", Commons.Modules.TypeLanguage);
                rTitle["UNIT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "UNIT", Commons.Modules.TypeLanguage);
                rTitle["QUA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "QUA", Commons.Modules.TypeLanguage);
                rTitle["UPRICE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "UPRICE", Commons.Modules.TypeLanguage);
                rTitle["AMOUNT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "AMOUNT", Commons.Modules.TypeLanguage);
                rTitle["NOTE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "NOTE", Commons.Modules.TypeLanguage);
                rTitle["TONG_CONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "TONG_CONG", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "NGUOI_LAP", Commons.Modules.TypeLanguage);
                rTitle["PSXUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "PSXUAT", Commons.Modules.TypeLanguage);
                rTitle["PCDIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "PCDIEN", Commons.Modules.TypeLanguage);
                rTitle["TNMAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "TNMAY", Commons.Modules.TypeLanguage);
                rTitle["GDOC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "NGAY_LAP", Commons.Modules.TypeLanguage);
                rTitle["BKEEPER"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "BKEEPER", Commons.Modules.TypeLanguage);
                rTitle["PDEPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "PDEPT", Commons.Modules.TypeLanguage);
                rTitle["MDEPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "MDEPT", Commons.Modules.TypeLanguage);
                rTitle["FMANAGER"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "FMANAGER", Commons.Modules.TypeLanguage);
                rTitle["DIC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "DIC", Commons.Modules.TypeLanguage);
                rTitle["DU_2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "DU_2", Commons.Modules.TypeLanguage);
                rTitle["DU_3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "DU_3", Commons.Modules.TypeLanguage);

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetSoTienACE", sMSPN, 0));
                rTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "THANH_TIEN",
                    Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0][0].ToString();

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetSoTienDFC", sMSPN, 3, 1));
                rTitle["TOTAL"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "TOTAL",
                    Commons.Modules.TypeLanguage) + " : " + dtTmp.Rows[0][0].ToString();

                sTmp = "SELECT NGOAI_TE,TY_GIA FROM IC_DON_HANG_NHAP_VAT_TU WHERE MS_DH_NHAP_PT = '" + sMSPN + "' AND NGOAI_TE NOT IN (SELECT DISTINCT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH = 1)";
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sTmp));
                sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPhieuNhapACE", "TY_GIA", Commons.Modules.TypeLanguage) + " : ";
                if (dtTmp.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtTmp.Rows)
                    {

                        try
                        {
                            sTmp += dr["NGOAI_TE"].ToString() + " : " + Convert.ToDouble(dr["TY_GIA"].ToString()).ToString("##,##.##") + " ; ";
                        }
                        catch { }
                    }

                }

                rTitle["DU_1"] = sTmp;


                TbTieuDe.TableName = "TD_NHAP_AFC";
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

        private void InPhieuNhapGreenFeed()
        {
            try
            {
                string sMSPN, sBCao;
                sMSPN = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString();
                sBCao = "rptPhieuNhapGRE";
                this.Cursor = Cursors.WaitCursor;
                frmReport frmRptDexuat = new frmReport();
                frmRptDexuat.rptName = "rptPhieuNhapGRE";

                //Dim ds As New DataSet
                DataSet dsTmp = new DataSet();
                DataTable dtTmp = new DataTable();
                dsTmp = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetInPhieuNhapGRE", sMSPN, Commons.Modules.TypeLanguage);

                dtTmp = dsTmp.Tables[1];
                dtTmp.TableName = "NHAP_KHO_GRE";
                frmRptDexuat.AddDataTableSource(dtTmp);

                System.Data.DataTable TbTieuDe = new System.Data.DataTable();
                TbTieuDe.Columns.Add("SO_PN");
                TbTieuDe.Columns.Add("TIEU_DE");
                TbTieuDe.Columns.Add("NGAY_LAP");
                TbTieuDe.Columns.Add("NGAY_NHAN");

                TbTieuDe.Columns.Add("DON_VI_BAN");
                TbTieuDe.Columns.Add("KHO_NHAP");
                TbTieuDe.Columns.Add("LY_DO_NHAP");

                TbTieuDe.Columns.Add("CHUNG_TU");
                TbTieuDe.Columns.Add("DE_XUAT_SO");


                TbTieuDe.Columns.Add("STT");
                TbTieuDe.Columns.Add("MS_PT");
                TbTieuDe.Columns.Add("TEN_PT");
                TbTieuDe.Columns.Add("DVT");
                TbTieuDe.Columns.Add("SO_LUONG");
                TbTieuDe.Columns.Add("NGAY_HET_BH");
                TbTieuDe.Columns.Add("GHI_CHU");


                TbTieuDe.Columns.Add("DANH_GIA");
                TbTieuDe.Columns.Add("NGAY_HT");


                TbTieuDe.Columns.Add("NGUOI_LAP");
                TbTieuDe.Columns.Add("NGUOI_GIAO");
                TbTieuDe.Columns.Add("THU_KHO");
                TbTieuDe.Columns.Add("BAO_VE");
                TbTieuDe.Columns.Add("TRUONG_BP");

                TbTieuDe.Columns.Add("TEN_NGUOI_LAP");
                TbTieuDe.Columns.Add("TEN_NGUOI_GIAO");
                TbTieuDe.Columns.Add("TEN_THU_KHO");


                TbTieuDe.Columns.Add("DU_1");
                TbTieuDe.Columns.Add("DU_2");
                TbTieuDe.Columns.Add("DU_3");
                TbTieuDe.Columns.Add("DU_4");
                TbTieuDe.Columns.Add("DU_5");

                DateTime Ngay;
                string sTmp = "";

                DataRow rTitle = TbTieuDe.NewRow();
                rTitle["SO_PN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                    "SO_PN", Commons.Modules.TypeLanguage) + " : " + TxtMSDHN.Text;
                rTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                    "TIEU_DE", Commons.Modules.TypeLanguage);
                try
                {
                    Ngay = datNgayNhap.DateTime.Date;
                }
                catch { Ngay = Convert.ToDateTime(null); }
                if (Ngay == Convert.ToDateTime(null))
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGAY_LAP", Commons.Modules.TypeLanguage);
                else
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGAY_LAP", Commons.Modules.TypeLanguage) + " : " + Ngay.Date.ToShortDateString();
                rTitle["NGAY_LAP"] = sTmp;

                try
                {
                    Ngay = Convert.ToDateTime(MskNgayCT.Text);
                }
                catch { Ngay = Convert.ToDateTime(null); }
                if (Ngay == Convert.ToDateTime(null))
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                            "NGAY_NHAN", Commons.Modules.TypeLanguage);
                else
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                            "NGAY_NHAN", Commons.Modules.TypeLanguage) + " : " + Ngay.Date.ToShortDateString();
                rTitle["NGAY_NHAN"] = sTmp;


                rTitle["DON_VI_BAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                    "DON_VI_BAN", Commons.Modules.TypeLanguage) + " : " + CboNguoiNhap.Text;

                rTitle["KHO_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                    "KHO_NHAP", Commons.Modules.TypeLanguage) + " : " + CboKho.Text;

                rTitle["LY_DO_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                    "LY_DO_NHAP", Commons.Modules.TypeLanguage) + " : " + cboLyDoKT.Text;

                rTitle["CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                    "CHUNG_TU", Commons.Modules.TypeLanguage) + " : " + TxtSoCT.Text;

                sTmp = "";
                if (CboDangNhap.EditValue.Equals(3))
                    rTitle["DE_XUAT_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                                "DON_HANG", Commons.Modules.TypeLanguage) + " : " + CboDDH.Text;
                if (CboDangNhap.EditValue.Equals(6))
                    rTitle["DE_XUAT_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                                "NHAP_TRA_TU_BAO_TRI", Commons.Modules.TypeLanguage) + " : " + CboDDH.Text;
                if (CboDangNhap.EditValue.Equals(10))
                    rTitle["DE_XUAT_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                                "NHAP_GIA_CONG_TU_PHIEU_XUAT", Commons.Modules.TypeLanguage) + " : " + CboDDH.Text;

                rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "STT", Commons.Modules.TypeLanguage);
                rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "MS_PT", Commons.Modules.TypeLanguage);
                rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "TEN_PT", Commons.Modules.TypeLanguage);
                rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "DVT", Commons.Modules.TypeLanguage);
                rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "SO_LUONG", Commons.Modules.TypeLanguage);
                rTitle["NGAY_HET_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGAY_HET_BH", Commons.Modules.TypeLanguage);
                rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "GHI_CHU", Commons.Modules.TypeLanguage);
                rTitle["DU_1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "TRANG", Commons.Modules.TypeLanguage);
                rTitle["DU_2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                    "UserIn", Commons.Modules.TypeLanguage) + " : " + Commons.Modules.UserName.ToString();



                rTitle["DANH_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                    "DANH_GIA", Commons.Modules.TypeLanguage) + " : " + TxtDanhGia.Text;
                try
                {
                    dtTmp = new DataTable();
                    dtTmp = dsTmp.Tables[0];
                    Ngay = DateTime.Parse(dtTmp.Rows[0][0].ToString());
                    rTitle["NGAY_HT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao,
                        "NGAY_IN", Commons.Modules.TypeLanguage) + " : " + Ngay.Date.ToShortDateString();
                }
                catch { }
                rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGUOI_LAP", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_GIAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGUOI_GIAO", Commons.Modules.TypeLanguage);
                rTitle["THU_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "THU_KHO", Commons.Modules.TypeLanguage);
                rTitle["BAO_VE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "BAO_VE", Commons.Modules.TypeLanguage);
                rTitle["TRUONG_BP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "TRUONG_BP", Commons.Modules.TypeLanguage);

                rTitle["TEN_NGUOI_LAP"] = cboNLap.Text;
                rTitle["TEN_NGUOI_GIAO"] = TxtNguoiGiao.Text;
                rTitle["TEN_THU_KHO"] = TxtThuKhoKy.Text;

                TbTieuDe.TableName = "TD_PHIEU_NHAP_GRE";
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

        #region InPhieuNhapSSD
        private void InPhieuNhapSSD()
        {
            try
            {
                string sMSPN, sBCao;
                sMSPN = ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString();
                sBCao = "rptPhieuNhapSSD";
                this.Cursor = Cursors.WaitCursor;
                frmReport frmRptDexuat = new frmReport();
                frmRptDexuat.rptName = "rptPhieuNhapSSD";

                //Dim ds As New DataSet

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBCPhieuNhapSSD", sMSPN, Commons.Modules.TypeLanguage));

                dtTmp.TableName = "NHAP_KHO_SSD";
                frmRptDexuat.AddDataTableSource(dtTmp);




                dtTmp = new System.Data.DataTable();


                dtTmp.Columns.Add("SO_PN");
                dtTmp.Columns.Add("NGAY_NHAN");


                dtTmp.Columns.Add("NGUOI_LAP");
                dtTmp.Columns.Add("KHO_NHAP");

                dtTmp.Columns.Add("CTY_NGUOI_NHAN");
                dtTmp.Columns.Add("NGUOI_GIAO");

                dtTmp.Columns.Add("LY_DO_NHAP");

                DataRow rPN = dtTmp.NewRow();

                rPN["SO_PN"] = TxtMSDHN.Text;
                try
                {
                    rPN["NGAY_NHAN"] = datNgayNhap.DateTime.Date.ToShortDateString();
                }
                catch { }

                rPN["NGUOI_LAP"] = cboNLap.Text;


                rPN["KHO_NHAP"] = CboKho.Text;


                rPN["CTY_NGUOI_NHAN"] = CboNguoiNhap.Text;
                rPN["NGUOI_GIAO"] = TxtNguoiGiao.Text;


                rPN["LY_DO_NHAP"] = TxtLyDo.Text;

                dtTmp.TableName = "PHIEU_NHAP_SSD";
                dtTmp.Rows.Add(rPN);
                frmRptDexuat.AddDataTableSource(dtTmp);






                System.Data.DataTable TbTieuDe = new System.Data.DataTable();
                TbTieuDe.Columns.Add("TD_PN_SSD");

                TbTieuDe.Columns.Add("SO_PN");
                TbTieuDe.Columns.Add("NGAY_NHAN");


                TbTieuDe.Columns.Add("NGUOI_LAP");
                TbTieuDe.Columns.Add("KHO_NHAP");

                TbTieuDe.Columns.Add("CTY_NGUOI_NHAN");
                TbTieuDe.Columns.Add("NGUOI_GIAO");

                TbTieuDe.Columns.Add("LY_DO_NHAP");

                TbTieuDe.Columns.Add("STT");
                TbTieuDe.Columns.Add("MS_PT");
                TbTieuDe.Columns.Add("TEN_PT");
                TbTieuDe.Columns.Add("DVT");
                TbTieuDe.Columns.Add("SO_LUONG");
                TbTieuDe.Columns.Add("DON_GIA");
                TbTieuDe.Columns.Add("THANH_TIEN");
                TbTieuDe.Columns.Add("GHI_CHU");

                TbTieuDe.Columns.Add("NGUOI_LAP_1");
                TbTieuDe.Columns.Add("NGUOI_GIAO_1");
                TbTieuDe.Columns.Add("NGUOI_DUYET");

                TbTieuDe.Columns.Add("KY_HO_TEN");
                TbTieuDe.Columns.Add("APPROVED");



                TbTieuDe.Columns.Add("TMP_1");
                TbTieuDe.Columns.Add("TMP_2");
                TbTieuDe.Columns.Add("TMP_3");
                TbTieuDe.Columns.Add("TMP_4");
                TbTieuDe.Columns.Add("TMP_5");

                DataRow rTitle = TbTieuDe.NewRow();
                rTitle["TD_PN_SSD"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "TD_PN_SSD", Commons.Modules.TypeLanguage);

                rTitle["SO_PN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "SO_PN", Commons.Modules.TypeLanguage) + " : ";
                rTitle["NGAY_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGAY_NHAN", Commons.Modules.TypeLanguage) + " : ";
                rTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGUOI_LAP", Commons.Modules.TypeLanguage) + " : ";
                rTitle["KHO_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "KHO_NHAP", Commons.Modules.TypeLanguage) + " : ";
                rTitle["CTY_NGUOI_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "CTY_NGUOI_NHAN", Commons.Modules.TypeLanguage) + " : ";
                rTitle["NGUOI_GIAO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGUOI_GIAO", Commons.Modules.TypeLanguage) + " : ";
                rTitle["LY_DO_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "LY_DO_NHAP", Commons.Modules.TypeLanguage) + " : ";



                rTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "STT", Commons.Modules.TypeLanguage);
                rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "MS_PT", Commons.Modules.TypeLanguage);
                rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "TEN_PT", Commons.Modules.TypeLanguage);
                rTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "DVT", Commons.Modules.TypeLanguage);
                rTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "SO_LUONG", Commons.Modules.TypeLanguage);
                rTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "DON_GIA", Commons.Modules.TypeLanguage);
                rTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "THANH_TIEN", Commons.Modules.TypeLanguage);
                rTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "GHI_CHU", Commons.Modules.TypeLanguage);



                rTitle["NGUOI_LAP_1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGUOI_LAP_1", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_GIAO_1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGUOI_GIAO", Commons.Modules.TypeLanguage);
                rTitle["NGUOI_DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "NGUOI_DUYET", Commons.Modules.TypeLanguage);

                rTitle["KY_HO_TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "KY_HO_TEN", Commons.Modules.TypeLanguage);
                rTitle["APPROVED"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBCao, "APPROVED", Commons.Modules.TypeLanguage);



                TbTieuDe.TableName = "TD_PHIEU_NHAP_SSD";
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


        #endregion

        #region InPhieuNhapVinhHoan
        private void InPhieuNhapVinhHoan()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                frmReport frmRpt = new frmReport();

                frmRpt.rptName = "rptDONHANGNHAP_VH";
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
                connection.Open();

                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandText = "SP_DONHANGNHAP";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MS_DH_NHAP_PT", TxtMSDHN.Text));


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
                            dtTmp.TableName = "DHN_INFO";
                            break;

                        case 1:
                            dtTmp.TableName = "DHN_DETAIL";
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
            vtbTitle.TableName = "TIEU_DE_DHN";
            Int32 i = 0;
            for (i = 0; i <= 27; i++)
            {
                vtbTitle.Columns.Add();
            }
            try
            {
                vtbTitle.Columns[0].ColumnName = "PHIEU_NHAP_KHO";
                vtbTitle.Columns[1].ColumnName = "MA_SO";
                vtbTitle.Columns[2].ColumnName = "NGAY_HIEU_LUC";
                vtbTitle.Columns[3].ColumnName = "LAN_SOAT_XET";

                vtbTitle.Columns[4].ColumnName = "NHAP_TAI_KHO";
                vtbTitle.Columns[5].ColumnName = "NGAY_GIO_NHAP";
                vtbTitle.Columns[6].ColumnName = "SO_XE";

                vtbTitle.Columns[7].ColumnName = "LOAI_CHUNG_TU";
                vtbTitle.Columns[8].ColumnName = "STT";

                vtbTitle.Columns[9].ColumnName = "TEN_HANG_HOA";
                vtbTitle.Columns[10].ColumnName = "MA_HANG";


                vtbTitle.Columns[11].ColumnName = "DVT";
                vtbTitle.Columns[12].ColumnName = "SO_LUONG";

                vtbTitle.Columns[13].ColumnName = "THEO_CHUNG_TU";
                vtbTitle.Columns[14].ColumnName = "THUC_NHAP";



                vtbTitle.Columns[15].ColumnName = "DON_GIA";
                vtbTitle.Columns[16].ColumnName = "THANH_TIEN";
                vtbTitle.Columns[17].ColumnName = "GHI_CHU";
                vtbTitle.Columns[18].ColumnName = "NGUOI_GIAO_HANG";

                vtbTitle.Columns[19].ColumnName = "THU_KHO";
                vtbTitle.Columns[20].ColumnName = "KE_TOAN_TRUONG";
                vtbTitle.Columns[21].ColumnName = "KY_HO_TEN";




                vtbTitle.Columns[22].ColumnName = "SO_PN";
                vtbTitle.Columns[23].ColumnName = "TMP1";
                vtbTitle.Columns[24].ColumnName = "TMP2";
                vtbTitle.Columns[25].ColumnName = "TMP3";
                vtbTitle.Columns[26].ColumnName = "TMP4";
                vtbTitle.Columns[27].ColumnName = "TMP5";

                DataRow vRowTitle = vtbTitle.NewRow();
                String sBC = "rptDONHANGNHAP_VH";

                vRowTitle["PHIEU_NHAP_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHIEU_NHAP_KHO", Commons.Modules.TypeLanguage);
                vRowTitle["MA_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_SO", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_HIEU_LUC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_HIEU_LUC", Commons.Modules.TypeLanguage);
                vRowTitle["LAN_SOAT_XET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LAN_SOAT_XET", Commons.Modules.TypeLanguage);
                vRowTitle["NHAP_TAI_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NHAP_TAI_KHO", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_GIO_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_GIO_NHAP", Commons.Modules.TypeLanguage);
                vRowTitle["SO_XE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_XE", Commons.Modules.TypeLanguage);
                vRowTitle["LOAI_CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LOAI_CHUNG_TU", Commons.Modules.TypeLanguage);
                vRowTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "STT", Commons.Modules.TypeLanguage);
                vRowTitle["TEN_HANG_HOA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_HANG_HOA", Commons.Modules.TypeLanguage);
                vRowTitle["MA_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_HANG", Commons.Modules.TypeLanguage);

                vRowTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DVT", Commons.Modules.TypeLanguage);
                vRowTitle["SO_LUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_LUONG", Commons.Modules.TypeLanguage);
                vRowTitle["THEO_CHUNG_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THEO_CHUNG_TU", Commons.Modules.TypeLanguage);
                vRowTitle["THUC_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THUC_NHAP", Commons.Modules.TypeLanguage);

                vRowTitle["DON_GIA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DON_GIA", Commons.Modules.TypeLanguage);
                vRowTitle["THANH_TIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THANH_TIEN", Commons.Modules.TypeLanguage);
                vRowTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "GHI_CHU", Commons.Modules.TypeLanguage);
                vRowTitle["NGUOI_GIAO_HANG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_GIAO_HANG", Commons.Modules.TypeLanguage);
                vRowTitle["THU_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THU_KHO", Commons.Modules.TypeLanguage);
                vRowTitle["KE_TOAN_TRUONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KE_TOAN_TRUONG", Commons.Modules.TypeLanguage);
                vRowTitle["KY_HO_TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "KY_HO_TEN", Commons.Modules.TypeLanguage);

                vRowTitle["SO_PN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_PN", Commons.Modules.TypeLanguage);
                vRowTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP1", Commons.Modules.TypeLanguage);
                vRowTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP2", Commons.Modules.TypeLanguage);
                vRowTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP3", Commons.Modules.TypeLanguage);
                vRowTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP4", Commons.Modules.TypeLanguage);
                string sTmp = "";
                try
                {
                    sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LabNguoiNhap", Commons.Modules.TypeLanguage) + " : " + CboNguoiNhap.Text;
                }
                catch { sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LabNguoiNhap", Commons.Modules.TypeLanguage); }
                vRowTitle["TMP5"] = sTmp;

                vtbTitle.Rows.Add(vRowTitle);
            }
            catch { }
            return vtbTitle;

        }
        #endregion

        private void btnUnLock_Click(object sender, EventArgs e)
        {


            if (!bUnLock)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongCoQuyen", Commons.Modules.TypeLanguage));
                return;
            }
            string sSql = "SELECT * FROM IC_DON_HANG_XUAT_VAT_TU_CHI_TIET WHERE MS_DH_NHAP_PT = '" + TxtMSDHN.Text + "'";
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count > 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "DaXuatKhongUnLock", Commons.Modules.TypeLanguage));
                return;
            }
            sSql = "SELECT C.* FROM IC_DON_HANG_NHAP A INNER JOIN IC_DON_HANG_XUAT B ON A.MS_DHX = B.MS_DH_XUAT_PT " +
                        " INNER JOIN PHIEU_BAO_TRI C ON C.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI " +
                        " WHERE MS_DANG_NHAP = 6 AND MS_DH_NHAP_PT = '" + TxtMSDHN.Text + "' AND C.TINH_TRANG_PBT > =4 ";
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count > 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDaNgiemThuPBTKhongUnLock", Commons.Modules.TypeLanguage));
                return;
            }
            if (Convert.ToInt32(CboDangNhap.EditValue.ToString()) == 10)
            {
                //kiểm tra nếu phiếu bảo trì đó chưa nghiệm thu thì được sữa
                sSql = "SELECT COUNT(*) FROM IC_DON_HANG_NHAP A INNER JOIN dbo.IC_DON_HANG_XUAT B ON B.MS_DH_XUAT_PT = A.MS_DH_XUAT_PT INNER JOIN dbo.PHIEU_BAO_TRI C ON C.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI WHERE A.MS_DH_NHAP_PT = '" + TxtMSDHN.EditValue + "' AND C.TINH_TRANG_PBT > 3";
                int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (n > 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgNhapTaiSuDungKhongUnLock", Commons.Modules.TypeLanguage));
                    return;
                }
            }
            if (Vietsoft.Information.MsgBox(this, "BanCoChacUnLockPN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No) return;
            Vietsoft.SqlInfo SqlPhieuNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            try
            {
                SqlPhieuNhapKho.BeginTransaction();
                string sPN = TxtMSDHN.Text;
                sSql = "UPDATE IC_DON_HANG_NHAP SET LOCK = 0 WHERE MS_DH_NHAP_PT = '" + sPN + "'";
                SqlHelper.ExecuteNonQuery(Vietsoft.Information.ConnectionString, CommandType.Text, sSql);

                if (Commons.Modules.iTRFData == 1)
                {
                    if (!TRFNhapKho(SqlPhieuNhapKho, TxtMSDHN.Text, 0))
                    {
                        SqlPhieuNhapKho.RollbackTransaction();
                        return;
                    }
                }

                SqlPhieuNhapKho.CommitTransaction();
                chkIsLock.Checked = false;
                InitializeControl();
                InitializeForm();
                BindingPhieuNhapKho.Position = BindingPhieuNhapKho.Find("MS_DH_NHAP_PT", sPN);
            }
            catch
            {
                SqlPhieuNhapKho.RollbackTransaction();
            }
        }

        private void frmPhieuNhapKho_New_VisibleChanged(object sender, EventArgs e)
        {
            //Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "FrmPhieuNhapKhoVatTu");
        }

        private void btnTimNCty_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimNCTy frm = new frmTimNCTy();
                frm.Loai = 4;
                try
                {
                    frm.DangNhapXuat = int.Parse(CboDangNhap.EditValue.ToString());
                }
                catch
                {
                    frm.DangNhapXuat = -1;
                }
                if (frm.ShowDialog() == DialogResult.Cancel) return;
                CboNguoiNhap.EditValue = frm.MsNV;
            }
            catch { }

        }


        #region Chi Phi
        private void AnHienCotChiPhi()
        {
            try
            {
                string sSql = "";
                sSql = "SELECT MS_CHI_PHI FROM dbo.CHI_PHI_NHAP_KHO WHERE (ACTIVE = 0)";
                DataTable dtTMP = new DataTable();
                dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTMP.Rows.Count == 0) return;
                foreach (DataRow drCP in dtTMP.Rows)
                    DgvPhieuNhapKhoChiTiet.Columns[GetCotChiPhi(int.Parse(drCP["MS_CHI_PHI"].ToString()))].Visible = false;

            }
            catch { }

        }

        private void LoadChiPhi(string sMsDHN)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                if (BtnLuu.Visible && !chkIsLock.Checked)
                    dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetChiPhiDHN", sMsDHN, Commons.Modules.TypeLanguage, 2));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, "GetChiPhiDHN", sMsDHN, Commons.Modules.TypeLanguage, 1));

                foreach (DataColumn ClChiPhi in dtTmp.Columns)
                {
                    ClChiPhi.ReadOnly = false;
                    ClChiPhi.AllowDBNull = true;
                }
                foreach (DataGridViewColumn ClChiPhi in DgvViTriPhuTung.Columns)
                {
                    ClChiPhi.DataPropertyName = ClChiPhi.Name;

                }

                grdChiPhi.DataSource = dtTmp;

                if (grdChiPhi.Columns[3].Name.ToUpper() == "cboDANG_PB".ToUpper()) return;
                grdChiPhi.Columns["TONG_CP"].DefaultCellStyle.Format = "N2";
                grdChiPhi.Columns["TONG_CP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                grdChiPhi.Columns["DANG_PB"].Visible = false;
                grdChiPhi.Columns["MS_DH_NHAP_PT"].Visible = false;
                grdChiPhi.Columns["MS_CHI_PHI"].Visible = false;
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT CONVERT(INT,1) AS DANG_PB, N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "cmbPhanBoTheoSoLuong", Commons.Modules.TypeLanguage) + "' AS TEN_PB UNION SELECT 2 AS DANG_PB, N'" +
                        Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "cmbPhanBoTheoGiatri",
                        Commons.Modules.TypeLanguage) + "' AS TEN_PB ORDER BY DANG_PB"));

                DataGridViewComboBoxColumn cboCPhi = new DataGridViewComboBoxColumn();
                cboCPhi.Name = "cboDANG_PB";
                cboCPhi.ValueMember = "DANG_PB";
                cboCPhi.DisplayMember = "TEN_PB";
                cboCPhi.DataPropertyName = "DANG_PB";
                cboCPhi.DataSource = dtTmp;
                cboCPhi.Width = 250;
                grdChiPhi.Columns.Insert(3, cboCPhi);

                grdChiPhi.Columns["TEN_CP"].Width = 220;
                grdChiPhi.Columns["cboDANG_PB"].Width = 200;
                grdChiPhi.Columns["TONG_CP"].Width = 200;
                grdChiPhi.Columns["GHI_CHU"].Width = 350;
            }
            catch { }
        }

        private void btnCP1_Click(object sender, EventArgs e)
        {
            if (DgvPhieuNhapKhoChiTiet.RowCount == 0) return;
            double dTongCP = 0;
            if (TabDHNCT.SelectedTabPageIndex == 0)
            {
                #region Cap nhap nguoc lai tong chi phi
                try
                {
                    string sTmp = "";
                    sTmp = DgvPhieuNhapKhoChiTiet.Columns[DgvPhieuNhapKhoChiTiet.CurrentCell.ColumnIndex].Name.ToString();
                    if (GetMaSoChiPhi(sTmp) == -1) return;
                    DataTable dtTmp = (DataTable)grdChiPhi.DataSource;
                    DataRow[] customerRow = dtTmp.Select("MS_CHI_PHI = " + GetMaSoChiPhi(sTmp).ToString());
                    // Doi voi truong hop cap nhap nguoc lai thi chi lay tong khong can theo loai
                    dTongCP = GetTongSoLuong(sTmp, 1);
                    customerRow[0]["TONG_CP"] = dTongCP;
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCapNhapChiPhiThanhCong", Commons.Modules.TypeLanguage));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCapNhapChiPhiKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message);
                }
                #endregion
            }
            else
            {
                #region Phan bo chi phi
                try
                {

                    try
                    {
                        double.TryParse(grdChiPhi.CurrentRow.Cells["TONG_CP"].Value.ToString(), out dTongCP);
                    }
                    catch { }

                    if (!PhanBoChiPhi(GetCotChiPhi(int.Parse(grdChiPhi.CurrentRow.Cells["MS_CHI_PHI"].Value.ToString())), GetTongSoLuong("SL_THUC_NHAP",
                        int.Parse(grdChiPhi.CurrentRow.Cells["DANG_PB"].Value.ToString())), dTongCP,
                        int.Parse(grdChiPhi.CurrentRow.Cells["DANG_PB"].Value.ToString())))
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhanBoKhongThanhCongChiPhi", Commons.Modules.TypeLanguage));
                    else
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhanBoThanhCongChiPhi", Commons.Modules.TypeLanguage));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhanBoKhongThanhCongChiPhi",
                                    Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString());
                }
                #endregion
            }

        }

        private void btnCPAll_Click(object sender, EventArgs e)
        {
            if (DgvPhieuNhapKhoChiTiet.RowCount == 0) return;

            if (TabDHNCT.SelectedTabPageIndex == 0)
            {
                #region Cap nhap nguoc lai tong chi phi
                try
                {
                    string sSql = "";
                    sSql = "SELECT MS_CHI_PHI FROM dbo.CHI_PHI_NHAP_KHO WHERE (ACTIVE = 1)";
                    DataTable dtTMP = new DataTable();
                    dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTMP.Rows.Count == 0) return;
                    foreach (DataRow drCP in dtTMP.Rows)
                    {
                        string sTmp = "";
                        sTmp = GetCotChiPhi(int.Parse(drCP["MS_CHI_PHI"].ToString()));
                        // doi voi truong hop cap nhap nguoc lai thi chi can lay tong
                        double dTongCP = GetTongSoLuong(sTmp, 1);
                        DataTable dtTmp = (DataTable)grdChiPhi.DataSource;
                        DataRow[] customerRow = dtTmp.Select("MS_CHI_PHI = " + int.Parse(drCP["MS_CHI_PHI"].ToString()));
                        if (customerRow.Length != 0)
                            if (dTongCP == 0)
                                customerRow[0]["TONG_CP"] = DBNull.Value;
                            else
                                customerRow[0]["TONG_CP"] = dTongCP;
                    }
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCapNhapChiPhiThanhCong", Commons.Modules.TypeLanguage));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCapNhapChiPhiKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message);
                }
                #endregion
            }
            else
            {
                #region Phan bo chi phi
                try
                {

                    string sMess = "";
                    int t = 0;
                    foreach (DataGridViewRow drChiPhi in grdChiPhi.Rows)
                    {
                        Double dTongSL = GetTongSoLuong("SL_THUC_NHAP", int.Parse(((DataRowView)drChiPhi.DataBoundItem).Row["DANG_PB"].ToString()));

                        if (dTongSL == 0)
                        {
                            t++;
                            continue;
                        }
                        double dCP = 0;
                        try
                        {
                            dCP = Double.Parse(((DataRowView)drChiPhi.DataBoundItem).Row["TONG_CP"].ToString());
                        }
                        catch { }
                        if (!PhanBoChiPhi(GetCotChiPhi(int.Parse(((DataRowView)drChiPhi.DataBoundItem).Row["MS_CHI_PHI"].ToString())), dTongSL,
                            dCP, int.Parse(((DataRowView)drChiPhi.DataBoundItem).Row["DANG_PB"].ToString())))
                            sMess = (sMess == "" ? "" : sMess + "\n") + ((DataRowView)drChiPhi.DataBoundItem).Row["TEN_CP"].ToString();
                    }
                    if (t > 0)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgLoiChiaSoKhong",
                              Commons.Modules.TypeLanguage));
                        return;

                    }
                    if (sMess != "")
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhanBoKhongThanhCongChiPhi",
                                Commons.Modules.TypeLanguage) + "\n" + sMess);
                    else
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhanBoThanhCongChiPhi",
                                Commons.Modules.TypeLanguage));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhanBoKhongThanhCongChiPhi",
                                    Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString());
                }
                #endregion
            }
        }

        private string GetCotChiPhi(int iCot)
        {
            switch (iCot)
            {
                case 1://--TONG_CP_NHAP_KHAU_VT	float	Checked	-- Phí nhập khẩu
                    return "TONG_CP_NHAP_KHAU_VT";
                    break;
                case 2://TONG_THUE_NK FLOAT	--Thuế nhập khẩu
                    return "TONG_THUE_NK";
                    break;
                case 3://TONG_PHI_VAN_CHUYEN FLOAT --Phí vận chuyển
                    return "TONG_PHI_VAN_CHUYEN";
                    break;
                case 4://TONG_PHI_BAO_HIEM FLOAT	--Phí bảo hiểm
                    return "TONG_PHI_BAO_HIEM";
                    break;
                case 5://TONG_THUE_NHA_THAU FLOAT	--Thuế nhà thầu
                    return "TONG_THUE_NHA_THAU";
                    break;
                case 6://TONG_PHI6 FLOAT	--Cost6
                    return "TONG_PHI6";
                    break;
                case 7://TONG_PHI7 FLOAT	--Cost7
                    return "TONG_PHI7";
                    break;
                case 8://TONG_PHI8 FLOAT	--Cost8
                    return "TONG_PHI8";
                    break;
                case 9://TONG_PHI9 FLOAT	--Cost9
                    return "TONG_PHI9";
                    break;
                case 10://TONG_CP_KHAC_VT	--Phí khác
                    return "TONG_CP_KHAC_VT";
                    break;
                case 11://TONG_CP_KHAC_VT	--Phí khác
                    return "TONG_CP";
                    break;
                default:
                    return "";
                    break;
            }

        }

        private int GetMaSoChiPhi(string sCot)
        {
            switch (sCot)
            {
                case "TONG_CP_NHAP_KHAU_VT"://--TONG_CP_NHAP_KHAU_VT	float	Checked	-- Phí nhập khẩu
                    return 1;
                    break;
                case "TONG_THUE_NK"://TONG_THUE_NK FLOAT	--Thuế nhập khẩu
                    return 2;
                    break;
                case "TONG_PHI_VAN_CHUYEN"://TONG_PHI_VAN_CHUYEN FLOAT --Phí vận chuyển
                    return 3;
                    break;
                case "TONG_PHI_BAO_HIEM"://TONG_PHI_BAO_HIEM FLOAT	--Phí bảo hiểm
                    return 4;
                    break;
                case "TONG_THUE_NHA_THAU"://TONG_THUE_NHA_THAU FLOAT	--Thuế nhà thầu
                    return 5;
                    break;
                case "TONG_PHI6"://TONG_PHI6 FLOAT	--Cost6
                    return 6;
                    break;
                case "TONG_PHI7"://TONG_PHI7 FLOAT	--Cost7
                    return 7;
                    break;
                case "TONG_PHI8"://TONG_PHI8 FLOAT	--Cost8
                    return 8;
                    break;
                case "TONG_PHI9"://TONG_PHI9 FLOAT	--Cost9
                    return 9;
                    break;
                case "TONG_CP_KHAC_VT"://TONG_CP_KHAC_VT	--Phí khác
                    return 10;
                    break;
                default:
                    return -1;
                    break;
            }

        }

        private double GetTongSoLuong(string sCotTinh, int iCachTinh)
        {
            // iCachTinh = 1 theo so luong = 2 theo gia tri
            double tongSoLuong = 0;
            DataView DgvTmp = new DataView(TbPhieuNhapKhoPhuTung, "MS_DH_NHAP_PT = '" +
                    ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() + "' ", "",
                    DataViewRowState.CurrentRows);

            try
            {
                if (iCachTinh == 1)
                {
                    tongSoLuong = Convert.ToDouble((DgvTmp.ToTable()).Compute("Sum(" + sCotTinh + ")", ""));
                }
                else
                {
                    int sum = 0;
                    foreach (DataRow dr in DgvTmp.ToTable().Rows)
                    {
                        double dTSL = 0;
                        try { dTSL = double.Parse(dr["SL_THUC_NHAP"].ToString()); }
                        catch { }
                        double dgTri = 0;
                        try { dgTri = double.Parse(dr["DON_GIA_GOC"].ToString()) * double.Parse(dr["TY_GIA"].ToString()); }
                        catch { }

                        tongSoLuong += (double)(dTSL * dgTri);
                    }

                }
            }
            catch { }
            return tongSoLuong;

        }

        private Boolean PhanBoChiPhi(string sCotPB, double dTongSoLuong, double dTongCP, int iCachTinh)
        {
            try
            {
                double dongiaSl = 0;
                if (dTongSoLuong != 0)
                {
                    dongiaSl = dTongCP / dTongSoLuong;
                }

                double dTongDaPB = 0;
                for (int i = 0; i <= DgvPhieuNhapKhoChiTiet.Rows.Count - 1; i++)
                {
                    Commons.Modules.SQLString = "0Tinh";
                    if (dongiaSl == 0)
                        DgvPhieuNhapKhoChiTiet.Rows[i].Cells[sCotPB].Value = DBNull.Value;
                    else
                    {
                        // CACH 1 THEO SO LUONG
                        // CACH 2 THEO GIA TRI
                        if (iCachTinh == 1)
                            DgvPhieuNhapKhoChiTiet.Rows[i].Cells[sCotPB].Value = Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[i].Cells["SL_THUC_NHAP"].Value) * dongiaSl;
                        else
                            DgvPhieuNhapKhoChiTiet.Rows[i].Cells[sCotPB].Value = Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[i].Cells["SL_THUC_NHAP"].Value) * (dongiaSl * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[i].Cells["DON_GIA_GOC"].Value) * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[i].Cells["TY_GIA"].Value));
                    }
                    Commons.Modules.SQLString = "";
                    CapNhapDonGiaGoc(i);
                    double sl = 0;
                    try { sl = Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[i].Cells[sCotPB].Value); }
                    catch { }
                    dTongDaPB = dTongDaPB + sl;
                }

                if (dTongDaPB != dTongCP)
                {
                    double varian = dTongCP - dTongDaPB;
                    double sl = 0;
                    try
                    {
                        sl = Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[DgvPhieuNhapKhoChiTiet.Rows.Count - 1].Cells[sCotPB].Value);
                    }
                    catch { }
                    DgvPhieuNhapKhoChiTiet.Rows[DgvPhieuNhapKhoChiTiet.Rows.Count - 1].Cells[sCotPB].Value = sl + varian;
                }
            }
            catch { return false; }
            return true;
        }

        private void ResetChiPhi(int iRow)
        {
            try
            {
                for (int i = 0; i <= DgvPhieuNhapKhoChiTiet.Rows.Count - 1; i++)
                {
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(1)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(2)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(3)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(4)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(5)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(6)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(7)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(8)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(9)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[i].Cells[GetCotChiPhi(10)].Value = 0;
                }
            }
            catch { }
        }
        private void CapNhapDonGiaGoc(int iRow)
        {
            Commons.Modules.SQLString = "0Tinh";
            double dTongCP = 0;
            #region Tinh tong chi phi

            if (Convert.ToInt32(CboDangNhap.EditValue.ToString()) != 9)
            {
                try
                {
                    dTongCP = (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(1)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(1)].Value)) +
                              (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(2)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(2)].Value)) +
                              (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(3)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(3)].Value)) +
                              (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(4)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(4)].Value)) +
                              (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(5)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(5)].Value)) +
                              (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(6)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(6)].Value)) +
                              (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(7)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(7)].Value)) +
                              (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(8)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(8)].Value)) +
                              (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(9)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(9)].Value)) +
                              (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(10)].Value == DBNull.Value
                                  ? 0
                                  : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(10)].Value));
                    DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TONG_CP"].Value = dTongCP;

                }
                catch
                {
                    DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TONG_CP"].Value = 0;
                }
            }
            else
            {
                try
                {
                    dTongCP = (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(11)].Value == DBNull.Value
                        ? 0
                        : Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(11)].Value));
                    DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(1)].Value = dTongCP;
                    DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(11)].Value = dTongCP;
                }
                catch
                {
                    DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(1)].Value = 0;
                    DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells[GetCotChiPhi(11)].Value = 0;
                }
            }
            #endregion

            #region Tinh Don Gia
            try
            {
                double dDGGoc = 0;
                try
                {
                    dDGGoc = Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_GOC"].Value);
                }
                catch
                { DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_GOC"].Value = 0; }

                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA"].Value =
                  dDGGoc
                        * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA"].Value) + dTongCP /
                   Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["SL_THUC_NHAP"].Value);

                if (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA"].Value.ToString() == "NaN")
                    DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA"].Value = 0;
            }
            catch
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA"].Value = 0;
            }
            #endregion

            #region Tinh don gia vnd
            try
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_VND"].Value =
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA"].Value) /
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA"].Value);
            }
            catch
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_VND"].Value = 0;
            }
            #endregion

            #region Tinh don gia usd
            try
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_USD"].Value =


                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA"].Value) *
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA_USD"].Value) / Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA"].Value);
            }
            catch
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_USD"].Value = 0;
            }
            #endregion





            #region Tinh don gia goc vnd
            try
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_GOC_VND"].Value =
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_GOC"].Value) *
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA"].Value);
            }
            catch
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_GOC_VND"].Value = 0;
            }
            #endregion

            #region Tinh thanh tien VND
            try
            {

                //thành tiền VND thì mình = phí NK + đơn giá * tỷ giá [08:51:28] Tân (Luke) Lương: dạ
                //DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN_VND"].Value =
                //  Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TONG_CP"].Value) +
                //  (
                //  (Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_GOC"].Value) *
                //  Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA"].Value)) *
                //  Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["SL_THUC_NHAP"].Value));

                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN_VND"].Value =
                    (
                    (Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_GOC"].Value) *
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA"].Value)) *
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["SL_THUC_NHAP"].Value));
            }
            catch
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN_VND"].Value = 0;
            }
            #endregion


            #region Tinh thanh tien thue
            try
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TT_TAX"].Value =
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_GOC"].Value) *
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA"].Value) *
                        (Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TAX"].Value) / 100) * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["SL_THUC_NHAP"].Value);
            }
            catch
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TT_TAX"].Value = 0;
            }
            #endregion

            #region Tinh thanh tien thue
            try
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TAX"].Value =
                    (Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TT_TAX"].Value) * 100) /
                        (Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["DON_GIA_GOC"].Value) * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA"].Value) * Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["SL_THUC_NHAP"].Value));


                if (DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TAX"].Value.ToString().ToUpper() == "NAN")
                    DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TAX"].Value = 0;

            }
            catch//141,543.01
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TT_TAX"].Value = 0;
            }

            #endregion

            #region Tinh thanh tien sau thue
            try
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN_ST"].Value =
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN_VND"].Value) +
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TT_TAX"].Value);


            }
            catch { DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN_ST"].Value = DBNull.Value; }
            #endregion

            #region Tinh thanh tien
            try
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN"].Value =
                    (Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN_ST"].Value) + Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TONG_CP"].Value));

            }
            catch { DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN"].Value = 0; }
            #endregion
            #region Tinh thanh tien USD
            try
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN_USD"].Value =
                    (Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN"].Value) / Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA"].Value))
                    *
                    Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["TY_GIA_USD"].Value);
            }
            catch
            {
                DgvPhieuNhapKhoChiTiet.Rows[iRow].Cells["THANH_TIEN_USD"].Value = 0;
            }
            #endregion
            LoadTongThanhTien();

            Commons.Modules.SQLString = "";
        }

        private Boolean KiemDuLieuChiPhi(int iCot, out string sMess)
        {
            string sTmp = "";
            try
            {
                DataView DgvTmp = new DataView(TbPhieuNhapKhoPhuTung, "MS_DH_NHAP_PT = '" +
                        ((DataRowView)BindingPhieuNhapKho.Current).Row["MS_DH_NHAP_PT"].ToString() + "' ", "",
                        DataViewRowState.CurrentRows);

                if (iCot == -1)
                {
                    foreach (DataGridViewRow drChiPhi in grdChiPhi.Rows)
                    {
                        double dTongCP = 0;
                        double dCP = 0;
                        try
                        {
                            dTongCP = Convert.ToDouble((DgvTmp.ToTable()).Compute("Sum(" +
                                    GetCotChiPhi(int.Parse(((DataRowView)drChiPhi.DataBoundItem).Row["MS_CHI_PHI"].ToString())) + ")", ""));
                        }
                        catch { }
                        try
                        {
                            dCP = double.Parse(((DataRowView)drChiPhi.DataBoundItem).Row["TONG_CP"].ToString());
                        }
                        catch { }
                        if (dCP != dTongCP)
                        {
                            sTmp = (sTmp == "" ? "" : sTmp + "\n") + ((DataRowView)drChiPhi.DataBoundItem).Row["TEN_CP"].ToString();
                        }
                    }
                }
            }
            catch
            {
                sMess = sTmp;
                return false;
            }
            sMess = sTmp;
            if (sTmp != "") return false;
            return true;
        }

        private void frmPhieuNhapKho_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                grdChiPhi.Columns.Clear();
            }
            catch { }
        }

        #endregion

        #region Cap Nhap So Luong Khi Phieu Da Lock

        private void DgvPhieuNhapKhoChiTiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BtnLuu.Visible) return;
            if (!chkIsLock.Checked) return;
            if (!Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 54)) return;
            if (TxtMSDHN.Text.Trim() == "") return;
            if (DgvPhieuNhapKhoChiTiet.Columns[e.ColumnIndex].Name.ToUpper() != "SL_THUC_NHAP" && DgvPhieuNhapKhoChiTiet.Columns[e.ColumnIndex].Name.ToUpper() != "DON_GIA_GOC") return;
            Double dGTThayDoi;

            switch (DgvPhieuNhapKhoChiTiet.Columns[e.ColumnIndex].Name.ToUpper())
            {
                #region Thay Doi So Luong Thuc Nhap
                case "SL_THUC_NHAP":
                    if (DgvViTriPhuTung.RowCount > 1)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                "msgCo2ViTriVuiLongChonBenLuoiVitriSLCanCapNhap", Commons.Modules.TypeLanguage));
                        return;
                    }

                    if (!bKiemPhieuBaoTriNghiemThu(TxtMSDHN.Text)) return;
                    string sTmp = Microsoft.VisualBasic.Interaction.InputBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgVuiLongNhapSoLuong", Commons.Modules.TypeLanguage), "", " ", 500, 300);

                    if (!iKiemGiaTri(sTmp, out dGTThayDoi)) return;

                    try
                    {
                        CapNhapSoLuongVoiPhieuDaLock(TxtMSDHN.Text, DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["MS_PT"].Value.ToString(),
                            DgvViTriPhuTung.Rows[DgvViTriPhuTung.CurrentRow.Index].Cells["MS_VI_TRI"].Value.ToString(),
                            Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["ID"].Value), dGTThayDoi);
                    }
                    catch { }

                    dGTThayDoi = e.RowIndex;
                    BindingPhieuNhapKho_CurrentChanged(sender, e);
                    DgvPhieuNhapKhoChiTiet.CurrentCell = DgvPhieuNhapKhoChiTiet.Rows[Convert.ToInt16(dGTThayDoi)].Cells[0];
                    break;
                #endregion

                #region Thay Doi Don gia goc
                case "DON_GIA_GOC":
                    if (!bKiemPhieuBaoTriNghiemThu(TxtMSDHN.Text)) return;
                    sTmp = Microsoft.VisualBasic.Interaction.InputBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgVuiLongNhapDonGia", Commons.Modules.TypeLanguage), "", " ", 500, 300);

                    if (!iKiemGiaTri(sTmp, out dGTThayDoi)) return;
                    CapNhapDonGiaGocVoiPhieuDaLock(TxtMSDHN.Text, DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["MS_PT"].Value.ToString(),
                        Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[e.RowIndex].Cells["ID"].Value), dGTThayDoi);

                    dGTThayDoi = e.RowIndex;
                    BindingPhieuNhapKho_CurrentChanged(sender, e);
                    DgvPhieuNhapKhoChiTiet.CurrentCell = DgvPhieuNhapKhoChiTiet.Rows[Convert.ToInt16(dGTThayDoi)].Cells[0];
                    break;
                    #endregion

            }
        }

        private Boolean iKiemGiaTri(string sGiatri, out Double dSLThayDoi)
        {
            dSLThayDoi = 0;
            if (sGiatri == "") return false;
            try
            {
                dSLThayDoi = Double.Parse(sGiatri);
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgKhongPhaiSo", Commons.Modules.TypeLanguage));
                return false;
            }
            if (dSLThayDoi == 0)
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgBanCoChacNhapGiaTriBang0", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return false;
            if (dSLThayDoi < 0)
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgBanCoChacNhapGiaTriNhoHon0", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return false;

            return true;
        }
        private void DgvViTriPhuTung_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BtnLuu.Visible) return;
            if (!chkIsLock.Checked) return;
            if (!Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 54)) return;
            if (DgvViTriPhuTung.Columns[e.ColumnIndex].Name.ToUpper() != "SL_VT") return;
            if (TxtMSDHN.Text.Trim() == "") return;
            //if (DgvViTriPhuTung.RowCount <= 1) return;

            if (!bKiemPhieuBaoTriNghiemThu(TxtMSDHN.Text)) return;
            string sTmp = Microsoft.VisualBasic.Interaction.InputBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                "msgVuiLongNhapSoLuong", Commons.Modules.TypeLanguage), "", " ", 500, 300);
            Double dSLThayDoi;
            try
            {
                dSLThayDoi = Double.Parse(sTmp);
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgKhongPhaiSo", Commons.Modules.TypeLanguage));
                return;
            }


            CapNhapSoLuongVoiPhieuDaLock(TxtMSDHN.Text, DgvPhieuNhapKhoChiTiet.Rows[DgvPhieuNhapKhoChiTiet.CurrentRow.Index].Cells["MS_PT"].Value.ToString(),
                DgvViTriPhuTung.Rows[e.RowIndex].Cells["MS_VI_TRI"].Value.ToString(),
                Convert.ToDouble(DgvPhieuNhapKhoChiTiet.Rows[DgvPhieuNhapKhoChiTiet.CurrentRow.Index].Cells["ID"].Value), dSLThayDoi);

            dSLThayDoi = DgvPhieuNhapKhoChiTiet.CurrentRow.Index;
            BindingPhieuNhapKho_CurrentChanged(sender, e);
            DgvPhieuNhapKhoChiTiet.CurrentCell = DgvPhieuNhapKhoChiTiet.Rows[Convert.ToInt16(dSLThayDoi)].Cells[0];

        }

        private Boolean bKiemPhieuBaoTriNghiemThu(string sMsDHN)
        {
            try
            {
                string sSql = "SELECT  B.MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO A INNER JOIN " +
                        " PHIEU_BAO_TRI B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI WHERE MS_DH_NHAP_PT = '" + TxtMSDHN.Text + "' AND TINH_TRANG_PBT > 3";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    sSql = "";
                    foreach (DataRow dr in dtTmp.Rows)
                    {
                        sSql = sSql + "-" + dr[0].ToString();
                    }
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgPhieuBaoTriDaNghiemThu", Commons.Modules.TypeLanguage) + "\n" + sSql + ".");
                    return false;
                }
                return true;
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgThayDoiKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + EX.Message + ".");
                return false;
            }
        }

        private void CapNhapSoLuongVoiPhieuDaLock(string sMsDHN, string sMsPT, string sViTri, Double ID, Double dSLThayDoi)
        {
            Vietsoft.SqlInfo SqlNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            string sSql = "";
            sSql = "SELECT SUM(SL_VT) AS SL  FROM IC_DON_HANG_XUAT_VAT_TU_CHI_TIET WHERE MS_DH_NHAP_PT = '" + sMsDHN + "' AND MS_PT = '" + sMsPT + "' " +
                        " AND MS_VI_TRI = " + sViTri + " AND ID_XUAT = " + ID.ToString();
            sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            try
            {
                Double dSLuong = 0;
                try
                {
                    dSLuong = Double.Parse(sSql);
                }
                catch { }
                if (dSLuong > dSLThayDoi)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgSoLuongThayDoiLonHonTongSoLuongDaXuat", Commons.Modules.TypeLanguage) + " : " + sSql + ".");
                    return;
                }
                SqlNhapKho.BeginTransaction();
                System.Data.DataTable dttmp = new System.Data.DataTable();
                dttmp.Load(SqlNhapKho.ExecuteReader(CommandType.StoredProcedure, "UpdateSoLuongPhieuNhap",
                    dSLThayDoi, sMsDHN, sMsPT, ID, sViTri, Commons.Modules.iTRFData));

                if (dttmp.Rows.Count > 0)
                {
                    SqlNhapKho.RollbackTransaction();
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCapNhapKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + dttmp.Rows[0][3].ToString() + "\n" + dttmp.Rows[0][5].ToString());
                    return;
                }

                SqlNhapKho.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlNhapKho.RollbackTransaction();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgThayDoiKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message + ".");
            }
        }

        private void CapNhapDonGiaGocVoiPhieuDaLock(string sMsDHN, string sMsPT, Double ID, Double dGTThayDoi)
        {
            Vietsoft.SqlInfo SqlNhapKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            try
            {
                SqlNhapKho.BeginTransaction();
                System.Data.DataTable dttmp = new System.Data.DataTable();
                dttmp.Load(SqlNhapKho.ExecuteReader(CommandType.StoredProcedure, "UpdateGiaTriPhieuNhap", dGTThayDoi, sMsDHN, sMsPT, ID, Commons.Modules.iTRFData));
                if (dttmp.Rows.Count > 0)
                {
                    SqlNhapKho.RollbackTransaction();
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCapNhapKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + dttmp.Rows[0][3].ToString() + "\n" + dttmp.Rows[0][5].ToString());
                    return;
                }
                SqlNhapKho.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlNhapKho.RollbackTransaction();
                DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgUpdateError", Commons.Modules.TypeLanguage) + "\n" + ex.Message);
                return;
            }
            return;
        }
        #endregion

        private void txtLPN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (txtLPN.Text.Trim() == "")
            {
                TbPhieuNhapKho.DefaultView.RowFilter = "";
                return;
            }
            string dk = " MS_DH_NHAP_PT = '" + txtLPN.Text + "' ";
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = TbPhieuNhapKho.Copy();

                dtTmp.DefaultView.RowFilter = dk;
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count == 0)
                {
                    string sSql = "";
                    sSql = " SELECT A.MS_DH_NHAP_PT, A.SO_PHIEU_XN, A.GIO, A.NGAY, A.MS_KHO, B.TEN_KHO, A.MS_DANG_NHAP, A.NGUOI_NHAP, A.NGAY_CHUNG_TU, A.SO_CHUNG_TU, A.DIEM, " +
                                    " A.DANH_GIA, A.GHI_CHU, A.LOCK, A.STT, A.DA_HET, A.THU_KHO, A.MS_DDH, A.SO_DE_XUAT, A.NGUOI_GIAO, A.BSXE, A.DIEM1, A.DIEM2, A.LY_DO, A.CAN_CU, A.THU_KHO_KY, A.NGUOI_LAP,  " +
                                    " A.MS_DHX, A.CP_NHAP_KHAU, A.CP_KHAC, A.MS_LY_DO_NHAP_KT " +
                                    " FROM dbo.IC_DON_HANG_NHAP AS A INNER JOIN " +
                                    " dbo.IC_KHO AS B ON A.MS_KHO = B.MS_KHO INNER JOIN " +
                                    " dbo.NHOM_KHO AS C ON A.MS_KHO = C.MS_KHO INNER JOIN " +
                                    " dbo.USERS AS D ON C.GROUP_ID = D.GROUP_ID " +
                                    " WHERE     (D.USERNAME = '" + Commons.Modules.UserName + "') AND MS_DH_NHAP_PT = '" + txtLPN.Text + "' ";
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        Commons.Modules.SQLString = "0Load";
                        if (int.Parse(lokWareHouse.EditValue.ToString()) != -1)
                        {
                            lokWareHouse.EditValue = int.Parse(dtTmp.Rows[0]["MS_KHO"].ToString());
                        }
                        if (Boolean.Parse(dtTmp.Rows[0]["LOCK"].ToString()) != chkIsLock.Checked)
                            chkIsLock.Checked = !chkIsLock.Checked;

                        datToDate.DateTime = DateTime.Parse(dtTmp.Rows[0]["NGAY"].ToString());
                        datFromDate.DateTime = DateTime.Parse(dtTmp.Rows[0]["NGAY"].ToString());
                        Commons.Modules.SQLString = "";
                        LoadPhieuNhapKho();
                    }
                }
            }
            catch { TbPhieuNhapKho.DefaultView.RowFilter = ""; }
            try
            {
                TbPhieuNhapKho.DefaultView.RowFilter = dk;
            }
            catch { TbPhieuNhapKho.DefaultView.RowFilter = ""; }

        }

        private void TabDHNCT_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (BtnLuu.Visible == true)
            {
                if (TabDHNCT.SelectedTabPageIndex == 0)
                {
                    btnCP1.Visible = false;
                    btnCPAll.Visible = false;
                    BtnChonPT.Visible = true;
                }
                else if (TabDHNCT.SelectedTabPageIndex == 1)
                {
                    btnCP1.Visible = true;
                    btnCPAll.Visible = true;
                    BtnChonPT.Visible = false;
                }
            }
        }

        private void TabDHNCT_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            try
            {
                if (BtnLuu.Visible == true && ((int)CboDangNhap.EditValue == 6 || (int)CboDangNhap.EditValue == 9))
                {
                    e.Cancel = true;
                }

            }
            catch { e.Cancel = true; }
        }

        private void txtTimVTri_EditValueChanged(object sender, EventArgs e)
        {
            if (BtnLuu.Visible == true)
            {
                try
                {
                    string dk = "";
                    TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = "(TEN_VI_TRI LIKE '%" + txtTimVTri.Text + "%' OR MS_VI_TRI = " + txtTimVTri.Text + ") AND MS_PT = '" + DgvPhieuNhapKhoChiTiet.Rows[DgvPhieuNhapKhoChiTiet.CurrentCell.RowIndex].Cells["MS_PT"].Value.ToString() + "' AND MS_DH_NHAP_PT = '" + TxtMSDHN.Text + "'";
                }
                catch (Exception ex) { TbPhieuNhapKhoPhuTungChiTiet.DefaultView.RowFilter = " MS_PT = '" + DgvPhieuNhapKhoChiTiet.Rows[DgvPhieuNhapKhoChiTiet.CurrentCell.RowIndex].Cells["MS_PT"].Value.ToString() + "' AND MS_DH_NHAP_PT = '" + TxtMSDHN.Text + "'"; }
            }
        }
        private void MskNgayNhap_Validated(object sender, EventArgs e)
        {
            try
            {
                if (TrangThai != "Add") return;
                DateTime NNhap;
                if (!DateTime.TryParse(datNgayNhap.Text, out NNhap))
                {
                    return;
                }
                if (TxtMSDHN.Text.Substring(5, 2) == datNgayNhap.Text.Substring(3, 2) && TxtMSDHN.Text.Substring(3, 2) == datNgayNhap.Text.Substring(8, 2))
                {
                    return;
                }
                String sPN = Vietsoft.Information.GetID("PN", datNgayNhap.DateTime);
                if (TxtMSDHN.Text == TxtSoDHN.Text)
                {
                    TxtSoDHN.Text = sPN;
                }
                TxtMSDHN.Text = sPN;
            }
            catch
            {
            }
        }

        private void datNgayNhap_Validated(object sender, EventArgs e)
        {
            try
            {
                if (TrangThai != "Add") return;
                DateTime NNhap;
                if (string.IsNullOrEmpty(datNgayNhap.Text)) return;

                if (!DateTime.TryParse(datNgayNhap.Text, out NNhap))
                {
                    return;
                }
                if (TxtMSDHN.Text.Substring(5, 2) == datNgayNhap.Text.Substring(3, 2) && TxtMSDHN.Text.Substring(3, 2) == datNgayNhap.Text.Substring(8, 2))
                {
                    return;
                }
                String sPN = Vietsoft.Information.GetID("PN", datNgayNhap.DateTime);
                if (TxtMSDHN.Text == TxtSoDHN.Text)
                {
                    TxtSoDHN.Text = sPN;
                }
                TxtMSDHN.Text = sPN;
            }
            catch
            {
            }
        }
    }
}