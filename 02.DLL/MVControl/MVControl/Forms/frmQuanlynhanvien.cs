using Commons;
using Commons.VS.Classes.Catalogue;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmQuanlynhanvien : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanlynhanvien()
        {
            InitializeComponent();
        }
        
        public void LoadcboTO2()
        {
            
            if (cboDON_VI2.EditValue == null)
            {
                cboTO2.Properties.DataSource = null;
                cboTo3.Properties.DataSource = null;
                return;
            }

            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanUserAll", 0, cboDON_VI2.EditValue.ToString(), Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTO2, dt, "MS_PB", "TEN_PB", "");


                if ((dt.Rows.Count == 0))
                {
                    cboTo3.Properties.DataSource = null;
                }


            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message, "Vietsoft Ecomaint", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }

        public void LoadcboTo3()
        {
            if (cboTO2.EditValue == null)
            {
                cboTo3.Properties.DataSource = null;

                return;
            }

            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetToPBUserAll", 0, cboDON_VI2.EditValue.ToString(), cboTO2.EditValue.ToString(), Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTo3, dt, "MS_TO1", "TEN_TO", "");

            }
            catch 
            {
                
            }
        }

        public void LoadcboTRINH_DO()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTRINH_DO_VAN_HOAs"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_TRINH_DO, dt, "MS_TRINH_DO", "TEN_GOI", "");
        }

        public void LoadcboNgoaiTe()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNGOAI_TE, new NGOAI_TEController().GetNGOAI_TEs(), "NGOAI_TE", "NGOAI_TE", "");
        }

        public void Refesh()
        {
            txtMS_CONG_NHAN.Text = "";
            txtMS_THE_CC.Text = "";
            txtHO.Text = "";
            txtTEN.Text = "";
            txtNGAY_SINH.Text = "";
            txtNOI_SINH.Text = "";
            txtDIA_CHI_THUONG_TRU.Text = "";
            txtSO_CMND.Text = "";
            txtNGAY_CAP.Text = "";
            txtNOI_CAP.Text = "";
            cboMS_TRINH_DO.EditValue = -1;
            txtNGOAI_NGU.Text = "";
            cboDON_VI2.EditValue = -1;
            cboTO2.EditValue = -1;
            cboTo3.EditValue = -1;
            txtCHUC_VU.Text = "";
            txtNGAY_VAO_LAM.Text = "";
            txtSO_DTDD.Text = "";
            txtUSER_MAIL.Text = "";
            txtSO_DT_NHA_RIENG.Text = "";
            txtTEN_NGUOI_THAN.Text = "";
            txtQUAN_HE.Text = "";
            txtNGAY_NGHI_VIEC.Text = "";
            txtLY_DO_NGHI.Text = "";
            txtBangcap.Text = "";
            txtHINH_CN.Text = "";
        }

        public void LockData(bool blnLock)
        {
            chkBO_VIEC.Enabled = !blnLock;
            chkNu.Enabled = !blnLock;
            txtDIA_CHI_THUONG_TRU.Properties.ReadOnly = blnLock;
            txtCHUC_VU.Properties.ReadOnly = blnLock;
            txtMS_CONG_NHAN.Properties.ReadOnly = blnLock;
            txtTEN.Properties.ReadOnly = blnLock;
            txtTEN_NGUOI_THAN.Properties.ReadOnly = blnLock;
            txtLY_DO_NGHI.Properties.ReadOnly = blnLock;
            txtHO.Properties.ReadOnly = blnLock;
            txtMS_THE_CC.Properties.ReadOnly = blnLock;
            txtNGOAI_NGU.Properties.ReadOnly = blnLock;
            txtNOI_CAP.Properties.ReadOnly = blnLock;
            txtNOI_SINH.Properties.ReadOnly = blnLock;
            txtQUAN_HE.Properties.ReadOnly = blnLock;
            txtSO_CMND.Properties.ReadOnly = blnLock;
            txtBangcap.Properties.ReadOnly = blnLock;
            txtHINH_CN.Properties.ReadOnly = blnLock;
            txtSO_DT_NHA_RIENG.Properties.ReadOnly = blnLock;
            txtSO_DTDD.Properties.ReadOnly = blnLock;
            txtUSER_MAIL.Properties.ReadOnly = blnLock;
            txtTEN_NGUOI_THAN.Properties.ReadOnly = blnLock;
            cboDON_VI2.Enabled = !blnLock;
            cboTO2.Enabled = !blnLock;
            cboTo3.Enabled = !blnLock;
            cboMS_TRINH_DO.Enabled = !blnLock;
            dtpNGAY_CAP.Enabled = !blnLock;
            dtpNGAY_SINH.Enabled = !blnLock;
            dtpNGAY_NGHI_VIEC.Enabled = !blnLock;
            dtpNGAY_VAO_LAM.Enabled = !blnLock;
            cboDON_VI1.Enabled = blnLock;
            cboTO.Enabled = blnLock;
            txtNGAY_CAP.Enabled = !blnLock;
            txtNGAY_NGHI_VIEC.Enabled = !blnLock;
            txtNGAY_SINH.Enabled = !blnLock;
            txtNGAY_VAO_LAM.Enabled = !blnLock;
        }

        public void VisibleButtonCM_BT(bool blnVisible)
        {
            btnThemsua.Visible = blnVisible;
            btnThoat2.Visible = blnVisible;
            btnXoa2.Visible = blnVisible;
            btnGhi2.Visible = !blnVisible;
            btnChonCM_BT.Visible = !blnVisible;
            btnKhongghi2.Visible = !blnVisible;
        }

        public void LockDataCM_BT(bool blnLock)
        {
            grdChuyenmon.Enabled = blnLock;
            grdBactho.Enabled = blnLock;
            cboDON_VI1.Enabled = blnLock;
            cboTO.Enabled = blnLock;
        }
        public void VisibleButtonLuong(bool blnVisible)
        {
            btnThem3.Visible = blnVisible;
            btnSua3.Visible = blnVisible;
            btnThoat3.Visible = blnVisible;
            btnXoa3.Visible = blnVisible;
            btnGhi3.Visible = !blnVisible;
            btnKhongghi3.Visible = !blnVisible;
        }

        public void LockDataLuong(bool blnLock)
        {
            txtSO_QUYET_DINH.Properties.ReadOnly = blnLock;
            txtNGAY_KY.Properties.ReadOnly = blnLock;
            txtNGAY_HIEU_LUC.Properties.ReadOnly = blnLock;
            txtLUONG_CO_BAN.Properties.ReadOnly = blnLock;
            txtHIEU_SUAT.Properties.ReadOnly = blnLock;
            txtNGUOI_KY.Properties.ReadOnly = blnLock;
            cboNGOAI_TE.Enabled = !blnLock;
            dtpNGAY_HIEU_LUC.Enabled = !blnLock;
            dtpNGAY_KY.Enabled = !blnLock;
            cboDON_VI1.Enabled = blnLock;
            cboTO.Enabled = blnLock;
        }


        public void VisibleButtonTainan(bool blnVisible)
        {
            btnThem4.Visible = blnVisible;
            btnSua4.Visible = blnVisible;
            btnThoat4.Visible = blnVisible;
            btnXoa4.Visible = blnVisible;
            btnGhi4.Visible = !blnVisible;
            btnKhongghi4.Visible = !blnVisible;
        }
        public void VisibleButtonVaiTro(bool blnVisible)
        {
            btnThem5.Visible = blnVisible;
            btnThoat5.Visible = blnVisible;
            btnGhi5.Visible = !blnVisible;
            btnKhongghi5.Visible = !blnVisible;
        }
        public void LockDataTainan(bool blnLock)
        {
            dtpNGAY_TAI_NAN.Enabled = !blnLock;
            txtGIO.Properties.ReadOnly = blnLock;
            txtNOI_XAY_RA.Properties.ReadOnly = blnLock;
            txtTINH_TRANG.Properties.ReadOnly = blnLock;
            //txtNGUYEN_NHAN.ReadOnly = blnLock;
            //txtGIAI_QUYET.ReadOnly = blnLock;
            cboDON_VI1.Enabled = blnLock;
            cboTO.Enabled = blnLock;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BindDataCM_BT()
        {
            grdChuyenmon.DataSource = null;

            grdBactho.DataSource = null;
            if (grvNVien.RowCount > -1)
            {

                if (btnGhi2.Visible == false)
                {
                    dtCM_BT = new DataTable();
                    dtCM_BT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetChuyenMonBacTho_CONGNHAN", grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString()));
                }


                DataTable dt = new DataTable();
                dt.Columns.Add("MS_CONG_NHAN");
                dt.Columns.Add("MS_CHUYEN_MON");
                dt.Columns.Add("TEN_CHUYEN_MON");

                IEnumerable<DataRow> query = dtCM_BT.AsEnumerable().Where(x => x["DEL"].ToString() == "0").GroupBy(x => x["MS_CHUYEN_MON"]).Select(x =>
                  {
                      var newRow = dt.NewRow();
                      newRow["MS_CONG_NHAN"] = x.First()["MS_CONG_NHAN"].ToString();
                      newRow["MS_CHUYEN_MON"] = x.First()["MS_CHUYEN_MON"].ToString();
                      newRow["TEN_CHUYEN_MON"] = x.First()["TEN_CHUYEN_MON"].ToString();
                      return newRow;
                  });
                grdChuyenmon.DataSource = query.CopyToDataTable();
                grvChuyenmon.OptionsBehavior.Editable = false;
                grvChuyenmon.BestFitColumns();
                grvChuyenmon.OptionsView.ColumnAutoWidth = true;

                grvChuyenmon.Columns["MS_CONG_NHAN"].Visible = false;
                grvChuyenmon.Columns["MS_CHUYEN_MON"].Visible = false;
                Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChuyenmon, "");

                if (grvBactho.RowCount == 0 & grvChuyenmon.RowCount == 0)
                {
                    btnXoa2.Enabled = false;
                }
                else
                {
                    btnXoa2.Enabled = true;
                }
                if (Commons.Modules.PermisString.Equals("Read only"))
                {
                    EnableButton(false);
                }
            }
        }

        DataTable dtCM_BT;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                VisibleButton(true);
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                if (Commons.Modules.PermisString.Equals("Read only"))
                {
                    LoadcboDON_VI1();
                    Commons.Modules.ObjSystems.DinhDang();
                    flagLoad = true;
                    LoadcboTO();
                    LoadcboDON_VI2();
                    LoadcboTO2();
                    LoadcboTo3();
                    LoadcboTRINH_DO();
                    LoadcboNgoaiTe();

                    Refesh();
                    LockData(true);
                    VisibleButtonCM_BT(true);
                    LockDataCM_BT(true);
                    VisibleButtonLuong(true);
                    LockDataLuong(true);
                    VisibleButtonTainan(true);
                    VisibleButtonVaiTro(true);
                    LockDataTainan(true);
                    VisibleButtonLuong(true);
                    LockDataLuong(true);

                    if (cboTO.EditValue != null)
                    {
                        BindData();
                        ShowCONG_NHAN();
                    }
                    lblHienthitongsoNV.Text = grvNVien.RowCount.ToString();
                    EnableButton(false);
                    flagLoad = false;
                }
                else
                {
                    EnableButton(true);
                    LoadcboDON_VI1();
                    Commons.Modules.ObjSystems.DinhDang();
                    flagLoad = true;
                    LoadcboTO();
                    LoadcboDON_VI2();
                    LoadcboTO2();
                    LoadcboTo3();
                    LoadcboTRINH_DO();
                    LoadcboNgoaiTe();

                    Refesh();
                    LockData(true);
                    VisibleButtonCM_BT(true);
                    LockDataCM_BT(true);
                    VisibleButtonLuong(true);
                    LockDataLuong(true);
                    VisibleButtonTainan(true);
                    VisibleButtonVaiTro(true);
                    LockDataTainan(true);
                    VisibleButtonLuong(true);
                    LockDataLuong(true);
                    if (cboTO.EditValue != null)
                    {
                        BindData();
                        ShowCONG_NHAN();
                    }
                    lblHienthitongsoNV.Text = grvNVien.RowCount.ToString();
                    if (grvNVien.RowCount > 0)
                    {
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnIn.Enabled = true;
                    }
                    else
                    {
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnIn.Enabled = false;
                    }
                    flagLoad = false;
                }
            }
            catch
            {
                flagLoad = false;
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            //tbpLylich.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmQuanlynhanvien", "tbpLylich", Commons.Modules.TypeLanguage);
            //tbpChuyenmon_bactho.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmQuanlynhanvien", "tbpChuyenmon_bactho", Commons.Modules.TypeLanguage);
            //tbpTienluong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmQuanlynhanvien", "tbpTienluong", Commons.Modules.TypeLanguage);
            //tbpTainan.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmQuanlynhanvien", "tbpTainan", Commons.Modules.TypeLanguage);
            //tbpVaitro.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmQuanlynhanvien", "tbpVaitro", Commons.Modules.TypeLanguage);
        }
        public void BindDataLuong()
        {
            if (grvNVien.RowCount <= 0)
                return;
            DataTable dt = new clsLUONG_CO_BANController().GetLUONG_CO_BANs(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString());

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdQuatrinhluong, grvQuatrinhluong, dt, false, true, true, true, true, "");

            grvQuatrinhluong.Columns["NGUOI_KY"].Visible = false;
            grvQuatrinhluong.Columns["HIEU_SUAT"].Visible = false;
            grvQuatrinhluong.Columns["NGOAI_TE"].Visible = false;
            grvQuatrinhluong.Columns["LUONG"].Visible = false;

            if (grvQuatrinhluong.RowCount == 0)
            {
                btnSua3.Enabled = false;
                btnXoa3.Enabled = false;
            }
            else
            {
                btnSua3.Enabled = true;
                btnXoa3.Enabled = true;
                grvQuatrinhluong.Columns["LUONG_CO_BAN"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }

            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                EnableButton(false);
            }
        }
        public void VisibleButton(bool blnVisible)
        {
            btnThem.Visible = blnVisible;
            btnSua.Visible = blnVisible;
            btnThoat.Visible = blnVisible;
            btnXoa.Visible = blnVisible;
            btnIn.Visible = blnVisible;
            btnLuu.Visible = !blnVisible;
            btnKhongLuu.Visible = !blnVisible;
            btnChucvu.Enabled = !blnVisible;
            btnChonDonVi.Enabled = !blnVisible;
            btnChonHinh.Enabled = !blnVisible;
            btnChonPB.Enabled = !blnVisible;
            btnChonTo.Enabled = !blnVisible;
        }

        public void BindDataTainan()
        {
            if (grvNVien.RowCount <= 0)
                return;
            DataTable dt = new clsTAI_NAN_LDController().GetTAI_NAN_LDs(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString());
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdThongtintainan, grvThongtintainan, dt, false, true, true, true, true, "");

            grvThongtintainan.Columns["GIO"].Visible = false;
            grvThongtintainan.Columns["NGUYEN_NHAN"].Visible = false;
            grvThongtintainan.Columns["GIAI_QUYET"].Visible = false;
            grvThongtintainan.Columns["NGAY_TAI_NAN"].Width = 100;
            grvThongtintainan.Columns["NOI_XAY_RA"].Width = 309;
            grvThongtintainan.Columns["TINH_TRANG"].Width = 316;

            if (grvThongtintainan.RowCount == 0)
            {
                btnSua4.Enabled = false;
                btnXoa4.Enabled = false;
            }
            else
            {
                btnSua4.Enabled = true;
                btnXoa4.Enabled = true;
            }
            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                EnableButton(false);
            }
        }
        public void BindDataVaitro()
        {
            try
            {
                if (grvNVien.RowCount <= 0)
                    return;
                DataTable dt = new clsTAI_NAN_LDController().GetVAI_TROs(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString());
                dt.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdVaitro, grvVaitro, dt, false, true, true, true, true, "");
                grvVaitro.Columns["CHON"].OptionsColumn.ReadOnly = false;
                grvVaitro.Columns["MS_VAI_TRO"].Visible = false;
                grvVaitro.Columns["TEN_VAI_TRO_V"].Width = 600;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                EnableButton(false);
            }
        }
        bool flagLoad = false;
        public void BindData()
        {
            if (cboTO.EditValue == null)
            {
                btnSua.Enabled = false;
                btnIn.Enabled = false;
                btnXoa.Enabled = false;
                btnThemsua.Enabled = false;
                btnXoa2.Enabled = false;
                btnThem3.Enabled = false;
                btnSua3.Enabled = false;
                btnXoa3.Enabled = false;
                btnThem4.Enabled = false;
                btnSua4.Enabled = false;
                btnXoa4.Enabled = false;
                return;
            }

            DataTable dtNVien = new DataTable();

            if (cboDON_VI1.EditValue == null)
                return;
            if (optNTHT.SelectedIndex == 2)
            {
                dtNVien.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_UserAll", cboDON_VI1.EditValue, cboTO.EditValue, 0, Commons.Modules.UserName));
            }
            else if (optNTHT.SelectedIndex == 0)
            {
                dtNVien.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_UserAll", cboDON_VI1.EditValue, cboTO.EditValue, 1, Commons.Modules.UserName));
            }
            else if (optNTHT.SelectedIndex == 1)
            {
                dtNVien.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_UserAll", cboDON_VI1.EditValue, cboTO.EditValue, 2, Commons.Modules.UserName));
            }


            try
            {
                // Lấy tổng số nhân viên của đơn vị hoặc tổ tương ứng.
                lblHienthitongsoNV.Text = grvNVien.RowCount.ToString();

                if (grvNVien.RowCount > 0 & !Commons.Modules.PermisString.Equals("Read only"))
                {
                    btnSua.Enabled = true;
                    btnIn.Enabled = true;
                    btnXoa.Enabled = true;
                }

                if (Commons.Modules.PermisString.Equals("Read only"))
                {
                    EnableButton(false);
                }

                dtNVien.PrimaryKey = new DataColumn[] { dtNVien.Columns["MS_CONG_NHAN"] };


                int focusHandle = dtNVien.Rows.IndexOf(dtNVien.Rows.Find(MS_CN_Temp));


                flagLoad = true;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNVien, grvNVien, dtNVien, false, true, true, true, true, "");
                flagLoad = false;
                for (int i = 0; i <= grvNVien.Columns.Count - 1; i++)
                {
                    grvNVien.Columns[i].Visible = false;
                }
                grvNVien.Columns["MS_CONG_NHAN"].Visible = true;
                grvNVien.Columns["HO_TEN"].Visible = true;
                if (grvNVien.Columns["MS_CONG_NHAN"].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                {
                    grvNVien.FocusedRowHandle = focusHandle == -1 ? 0 : focusHandle;
                    return;
                }
                try
                {
                    grvNVien.Columns["MS_CONG_NHAN"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grvNVien.Columns["MS_CONG_NHAN"].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grvNVien.Columns["MS_CONG_NHAN"].AppearanceHeader.Options.UseTextOptions = true;
                    grvNVien.Columns["MS_CONG_NHAN"].Caption = lblMaso.Text;

                    grvNVien.Columns["HO_TEN"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grvNVien.Columns["HO_TEN"].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grvNVien.Columns["HO_TEN"].AppearanceHeader.Options.UseTextOptions = true;
                    grvNVien.Columns["HO_TEN"].Caption = lblHo.Text + " " + lblTen.Text;

                }
                catch 
                {
                }

                grvNVien.Columns["USER_MAIL"].Visible = false;
                grvNVien.Columns["MS_CONG_NHAN"].Width = 150;
                
            }
            catch 
            {
            }


        }
        public void EnableButton(bool bln)
        {
            btnThem.Enabled = bln;
            btnThem3.Enabled = bln;
            btnThem4.Enabled = bln;
            btnThemsua.Enabled = bln;
            btnSua.Enabled = bln;
            btnSua3.Enabled = bln;
            btnSua4.Enabled = bln;
            btnXoa.Enabled = bln;
            btnXoa2.Enabled = bln;
            btnXoa3.Enabled = bln;
            btnXoa4.Enabled = bln;
            btnThem5.Enabled = bln;
        }

        #region LoadCombo
        private void cboDON_VI1_EditValueChanged(object sender, EventArgs e)
        {
            if (flagLoad == true) return;
            LoadcboTO();
            ShowCONG_NHAN();
        }

        private void cboTO_EditValueChanged(object sender, EventArgs e)
        {
            if (flagLoad == true) return;
            Refesh();
            BindData();
            grvNVien_FocusedRowChanged(grvNVien, null);
        }
        public void LoadcboDON_VI1()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 1, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDON_VI1, dt, "MS_DON_VI", "TEN_DON_VI", "");

        }
        public void LoadcboDON_VI2()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_USER", Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDON_VI2, dt, "MS_DON_VI", "TEN_DON_VI", "");
        }
        public void LoadcboTO()
        {
            if (cboDON_VI1.EditValue == null)
            {
                cboTO.Properties.DataSource = new DataTable();
                return;
            }

            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanUserAll", 1, cboDON_VI1.EditValue.ToString(), Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTO, dt, "MS_PB", "TEN_PB", "");

        }
        private void cboDON_VI2_EditValueChanged(object sender, EventArgs e)
        {
            if (flagLoad == true) return;
            LoadcboTO2();
        }

        private void cboTO2_EditValueChanged(object sender, EventArgs e)
        {
            if (flagLoad == true) return;
            LoadcboTo3();
        }
        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            Report1.frmDanhmucdonvi frm = new Report1.frmDanhmucdonvi();
            frm.ShowDialog();
            LoadcboDON_VI2();
        }

        private void btnChonPB_Click(object sender, EventArgs e)
        {
            Report1.frmDanhmucto frm = new Report1.frmDanhmucto();
            frm.ShowDialog();
            LoadcboDON_VI2();

        }

        private void btnChonTo_Click(object sender, EventArgs e)
        {
            Report1.frmDanhmucto frm = new Report1.frmDanhmucto();
            frm.ShowDialog();
            LoadcboTo3();
        }
        #endregion

        


        public void RefeshLuong()
        {
            txtSO_QUYET_DINH.Text = "";
            txtNGAY_KY.Text = "";
            txtNGAY_HIEU_LUC.Text = "";
            txtLUONG_CO_BAN.Text = "";
            txtHIEU_SUAT.Text = "100";
            txtNGUOI_KY.Text = "";
            cboNGOAI_TE.Text = "USD";
            dtpNGAY_KY.EditValue = System.DateTime.Now;
            dtpNGAY_HIEU_LUC.EditValue = System.DateTime.Now;
        }

        public void ShowLuong()
        {
            txtSO_QUYET_DINH.Text = grvQuatrinhluong.GetFocusedDataRow()["SO_QUYET_DINH"].ToString();
            if (object.ReferenceEquals(grvQuatrinhluong.GetFocusedDataRow()["NGAY_KY"], System.DBNull.Value))
            {
                txtNGAY_KY.Text = "";
            }
            else
            {
                txtNGAY_KY.Text = Convert.ToDateTime(grvQuatrinhluong.GetFocusedDataRow()["NGAY_KY"].ToString()).ToString("dd/MM/yyyy");
            }
            txtNGUOI_KY.Text = grvQuatrinhluong.GetFocusedDataRow()["NGUOI_KY"].ToString();
            if (object.ReferenceEquals(grvQuatrinhluong.GetFocusedDataRow()["NGAY_HIEU_LUC"], System.DBNull.Value))
            {
                txtNGAY_HIEU_LUC.Text = "";
            }
            else
            {
                txtNGAY_HIEU_LUC.Text = Convert.ToDateTime(grvQuatrinhluong.GetFocusedDataRow()["NGAY_HIEU_LUC"].ToString()).ToString("dd/MM/yyyy");
            }

            txtLUONG_CO_BAN.Text = string.Format(grvQuatrinhluong.GetFocusedDataRow()["LUONG"].ToString(), "#,##0.00");
            txtHIEU_SUAT.Text = grvQuatrinhluong.GetFocusedDataRow()["HIEU_SUAT"].ToString();
            cboNGOAI_TE.Text = grvQuatrinhluong.GetFocusedDataRow()["NGOAI_TE"].ToString();
        }

        public void RefeshTainan()
        {
            txtGIO.Text = "";
            txtGIAI_QUYET.Text = "";
            dtpNGAY_TAI_NAN.EditValue = DateTime.Now;
            txtNOI_XAY_RA.Text = "";
            txtTINH_TRANG.Text = "";
            txtNGUYEN_NHAN.Text = "";
        }

        public void ShowTainan()
        {
            try
            {
                dtpNGAY_TAI_NAN.EditValue = Convert.ToDateTime(grvThongtintainan.GetFocusedDataRow()["NGAY_TAI_NAN"]);

            }
            catch
            {
                dtpNGAY_TAI_NAN.EditValue = "";
            }
            try
            {
                txtGIO.EditValue = Convert.ToDateTime(grvThongtintainan.GetFocusedDataRow()["GIO"]);
            }
            catch
            {
                txtGIO.EditValue = "";
                txtGIO.Text = "00:00";
            }

            txtNOI_XAY_RA.Text = grvThongtintainan.GetFocusedDataRow()["NOI_XAY_RA"].ToString();
            txtTINH_TRANG.Text = grvThongtintainan.GetFocusedDataRow()["TINH_TRANG"].ToString();
            txtNGUYEN_NHAN.Text = grvThongtintainan.GetFocusedDataRow()["NGUYEN_NHAN"].ToString();
            txtGIAI_QUYET.Text = grvThongtintainan.GetFocusedDataRow()["GIAI_QUYET"].ToString();
        }

        public void ShowCONG_NHAN()
        {
            if (grvNVien.RowCount <= 0)
                return;
            lblHienthitongsoNV.Text = grvNVien.RowCount.ToString();
            txtMS_CONG_NHAN.Text = grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString();
            try
            {
                chkNu.Checked = Convert.ToBoolean(grvNVien.GetFocusedDataRow()["PHAI"].ToString());
            }
            catch
            {
                chkNu.Checked = false;
            }
            txtMS_THE_CC.Text = grvNVien.GetFocusedDataRow()["MS_THE_CC"].ToString();
            txtHO.Text = grvNVien.GetFocusedDataRow()["HO"].ToString();
            txtTEN.Text = grvNVien.GetFocusedDataRow()["TEN"].ToString();
            try
            {
                txtNGAY_SINH.Text = Convert.ToDateTime(grvNVien.GetFocusedDataRow()["NGAY_SINH"].ToString()).ToString("dd/MM/yyy");
            }
            catch
            {
                txtNGAY_SINH.Text = "";
            }
            txtNOI_SINH.Text = grvNVien.GetFocusedDataRow()["NOI_SINH"].ToString();
            txtDIA_CHI_THUONG_TRU.Text = grvNVien.GetFocusedDataRow()["DIA_CHI_THUONG_TRU"].ToString();
            txtSO_CMND.Text = grvNVien.GetFocusedDataRow()["SO_CMND"].ToString();
            try
            {
                txtNGAY_CAP.Text = Convert.ToDateTime(grvNVien.GetFocusedDataRow()["NGAY_CAP"].ToString()).ToString("dd/MM/yyy");
            }
            catch
            {
                txtNGAY_CAP.Text = "";
            }
            txtNOI_CAP.Text = grvNVien.GetFocusedDataRow()["NOI_CAP"].ToString();
            cboMS_TRINH_DO.Text = grvNVien.GetFocusedDataRow()["TEN_GOI"].ToString();
            txtNGOAI_NGU.Text = grvNVien.GetFocusedDataRow()["NGOAI_NGU"].ToString();
            cboDON_VI2.EditValue = grvNVien.GetFocusedDataRow()["MS_DON_VI"].ToString();
            try
            {
                cboTO2.EditValue = Convert.ToInt32(grvNVien.GetFocusedDataRow()["MS_PHONG_BAN"].ToString());

            }
            catch
            {
                cboTO2.EditValue = -1;
            }

            try
            {
                cboTo3.EditValue = Convert.ToInt32(grvNVien.GetFocusedDataRow()["MS_TO"].ToString());
            }
            catch
            {
                cboTo3.EditValue = -1;
            }

            try
            {
                txtNGAY_VAO_LAM.Text = Convert.ToDateTime(grvNVien.GetFocusedDataRow()["NGAY_VAO_LAM"].ToString()).ToString("dd/MM/yyy");
            }
            catch
            {
                txtNGAY_VAO_LAM.Text = "";
            }
            txtSO_DTDD.Text = grvNVien.GetFocusedDataRow()["SO_DTDD"].ToString();
            txtUSER_MAIL.Text = grvNVien.GetFocusedDataRow()["USER_MAIL"].ToString();
            txtSO_DT_NHA_RIENG.Text = grvNVien.GetFocusedDataRow()["SO_DT_NHA_RIENG"].ToString();
            txtTEN_NGUOI_THAN.Text = grvNVien.GetFocusedDataRow()["TEN_NGUOI_THAN"].ToString();
            txtQUAN_HE.Text = grvNVien.GetFocusedDataRow()["QUAN_HE"].ToString();
            try
            {
                chkBO_VIEC.Checked = Convert.ToBoolean(grvNVien.GetFocusedDataRow()["BO_VIEC"].ToString());
            }
            catch
            {
                chkBO_VIEC.Checked = false;
            }
            txtNGAY_NGHI_VIEC.Text = string.Format(grvNVien.GetFocusedDataRow()["NGAY_NGHI_VIEC"].ToString(), "short date");
            txtLY_DO_NGHI.Text = grvNVien.GetFocusedDataRow()["LY_DO_NGHI"].ToString();
            GetCHUC_VU(txtMS_CONG_NHAN.Text);
            txtBangcap.Text = grvNVien.GetFocusedDataRow()["BANG_CAP"].ToString();

            
            try
            {
                txtHINH_CN.Text = grvNVien.GetFocusedDataRow()["HINH_CN"].ToString();
            }
            catch
            {
                txtHINH_CN.Text = "";
            }
        }
        public void GetCHUC_VU(string MS_CONG_NHAN)
        {
            Commons.CONG_NHANInfo objCONG_NHANInfo = new clsCONG_NHANController().GetLastCHUC_VU(MS_CONG_NHAN);
            txtCHUC_VU.Text = objCONG_NHANInfo.CHUC_VU;
        }
        private void grvNVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (flagLoad == true) return;
                if (tabNhanSu.SelectedTabPageIndex == 0)
                {
                    ShowCONG_NHAN();
                }
                else if (tabNhanSu.SelectedTabPageIndex == 1)
                {
                    BindDataCM_BT();
                    grvChuyenmon_FocusedRowChanged(grvChuyenmon, null);
                }
                else if (tabNhanSu.SelectedTabPageIndex == 2)
                {
                    RefeshLuong();
                    BindDataLuong();
                    ShowLuong();
                }
                else if (tabNhanSu.SelectedTabPageIndex == 3)
                {
                    RefeshTainan();
                    BindDataTainan();
                    ShowTainan();
                }
                else if (tabNhanSu.SelectedTabPageIndex == 4)
                {
                    BindDataVaitro();
                }
                btnChucvu.Visible = true;
            }
            catch { }

        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sTim = "";
            try
            {
                dt = grdNVien.DataSource as DataTable;
                if ((!string.IsNullOrEmpty(txtTimkiem.Text.Trim())))
                {
                    if (optNTHT.SelectedIndex == 2)
                    {
                        sTim = " MS_CONG_NHAN LIKE '%" + txtTimkiem.Text.Trim() + "%' OR HO_TEN LIKE '%" + txtTimkiem.Text.Trim() + "%'";
                    }
                    else if (optNTHT.SelectedIndex == 0)
                    {
                        sTim = "(BO_VIEC = 0) AND MS_CONG_NHAN LIKE '%" + txtTimkiem.Text.Trim() + "%' OR HO_TEN LIKE '%" + txtTimkiem.Text.Trim() + "%'";
                    }
                    else if (optNTHT.SelectedIndex == 1)
                    {
                        sTim = "(BO_VIEC = 1) AND MS_CONG_NHAN LIKE '%" + txtTimkiem.Text.Trim() + "%' OR HO_TEN LIKE '%" + txtTimkiem.Text.Trim() + "%'";
                    }
                    dt.DefaultView.RowFilter = sTim;
                }
                else
                {
                    if (optNTHT.SelectedIndex == 2)
                    {
                        sTim = "";
                    }
                    else if (optNTHT.SelectedIndex == 0)
                    {
                        sTim = "BO_VIEC = 0";
                    }
                    else if (optNTHT.SelectedIndex == 1)
                    {
                        sTim = "BO_VIEC = 1";
                    }
                    dt.DefaultView.RowFilter = "";
                }
                grvNVien_FocusedRowChanged(grvNVien, null);
            }
            catch 
            {
                if (optNTHT.SelectedIndex == 2)
                {
                    sTim = "";
                }
                else if (optNTHT.SelectedIndex == 0)
                {
                    sTim = "BO_VIEC = 0";
                }
                else if (optNTHT.SelectedIndex == 1)
                {
                    sTim = "BO_VIEC = 1";
                }
                dt.DefaultView.RowFilter = "";
            }
        }
       
        private void optNTHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
            grvNVien_FocusedRowChanged(grvNVien, null);
        }

        private void frmQuanlynhanvien_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, Name);

        }
        

        #region VaiTro
        private void btnThem5_Click(object sender, EventArgs e)
        {
            VisibleButtonVaiTro(false);
            optNTHT.Enabled = false;

            grdNVien.Enabled = false;
            grvVaitro.OptionsBehavior.Editable = true;
            grvVaitro.Columns["CHON"].OptionsColumn.ReadOnly = false;
        }
        private void btnKhongghi5_Click(object sender, EventArgs e)
        {
            VisibleButtonVaiTro(true);
            optNTHT.Enabled = true;

            grdNVien.Enabled = true;
            grvVaitro.OptionsBehavior.Editable = false;
            grvVaitro.Columns["CHON"].OptionsColumn.ReadOnly = true;
            grvNVien_FocusedRowChanged(grvNVien, null);
        }
        private void btnGhi5_Click(object sender, EventArgs e)
        {

            string sql = "";

            SqlConnection objConnection = new SqlConnection(Commons.IConnections.ConnectionString);
            objConnection.Open();
            SqlTransaction objTrans = objConnection.BeginTransaction();
            try
            {

                sql = "DELETE FROM CONG_NHAN_VAI_TRO WHERE MS_CONG_NHAN='" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "'";
                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql);
                grvVaitro.CloseEditor();
                for (int i = 0; i < grvVaitro.RowCount; i++)
                {

                    if (grvVaitro.GetRowCellValue(i, "CHON").ToString().ToLower() == "true")
                    {
                        sql = "INSERT INTO CONG_NHAN_VAI_TRO ( MS_CONG_NHAN, MS_VAI_TRO) VALUES('" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "','" + grvVaitro.GetRowCellValue(i, "MS_VAI_TRO").ToString() + "')";
                        SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql);
                        SqlHelper.ExecuteNonQuery(objTrans, "UPDATE_CONG_NHAN_VAI_TRO_LOG", grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), grvVaitro.GetRowCellValue(i, "MS_VAI_TRO").ToString(), Name, Commons.Modules.UserName, 1);
                    }

                }
                objTrans.Commit();
                objConnection.Close();
            }
            catch
            {
                objTrans.Rollback();
                objConnection.Close();
            }
            VisibleButtonVaiTro(true);
            optNTHT.Enabled = true;

            grdNVien.Enabled = true;
            grvVaitro.OptionsBehavior.Editable = false;
            grvVaitro.Columns["CHON"].OptionsColumn.ReadOnly = true;
        }
        private void btnThoat5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ChuyenMon-BacTho
        private void grvChuyenmon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvChuyenmon.RowCount > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MS_CONG_NHAN");
                    dt.Columns.Add("MS_CHUYEN_MON");
                    dt.Columns.Add("MS_BAC_THO");
                    dt.Columns.Add("TEN_BAC_THO");
                    dt.Columns.Add("NGAY");

                    IEnumerable<DataRow> query = dtCM_BT.AsEnumerable().Where(x => x["MS_CHUYEN_MON"].ToString() == grvChuyenmon.GetFocusedDataRow()["MS_CHUYEN_MON"].ToString() && x["MS_BAC_THO"].ToString() != "-1" && x["DEL"].ToString() == "0").Select(x =>
                   {
                       var newRow = dt.NewRow();
                       newRow["MS_CONG_NHAN"] = x["MS_CONG_NHAN"].ToString();
                       newRow["MS_CHUYEN_MON"] = x["MS_CHUYEN_MON"].ToString();
                       newRow["MS_BAC_THO"] = x["MS_BAC_THO"].ToString();
                       newRow["TEN_BAC_THO"] = x["TEN_BAC_THO"].ToString();
                       newRow["NGAY"] = x["NGAY"].ToString();
                       return newRow;
                   });
                    grdBactho.DataSource = query.CopyToDataTable();
                    grvBactho.OptionsBehavior.Editable = false;
                    grvBactho.BestFitColumns();
                    grvBactho.OptionsView.ColumnAutoWidth = true;
                    grvBactho.Columns["MS_CONG_NHAN"].Visible = false;
                    grvBactho.Columns["MS_CHUYEN_MON"].Visible = false;
                    grvBactho.Columns["MS_BAC_THO"].Visible = false;
                    Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvBactho, "");

                }
            }
            catch  { grdBactho.DataSource = null; }
        }
        private void btnThemsua_Click(object sender, EventArgs e)
        {
            VisibleButtonCM_BT(false);
            optNTHT.Enabled = false;
            grdNVien.Enabled = false;
            grvChuyenmon.OptionsBehavior.Editable = true;
            grvChuyenmon.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            grvBactho.OptionsBehavior.Editable = true;
            grvBactho.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            frmAddCM_BT frm = new MVControl.frmAddCM_BT();
            frm.MS_CONG_NHAN = grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.dtTMP = dtCM_BT.Copy();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dtCM_BT = frm.dtTTPT1.Copy();

                BindDataCM_BT();
                grvChuyenmon_FocusedRowChanged(grvChuyenmon, null);
            }


        }
        private void btnGhi2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
                if (sql.State == ConnectionState.Closed)
                    sql.Open();

                SqlTransaction tran = null;
                if (dtCM_BT.Rows.Count > 0)
                {
                    try
                    {
                        foreach (DataRow row in dtCM_BT.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                tran = sql.BeginTransaction();

                                SqlHelper.ExecuteNonQuery(tran, "spInsertUpdateChuyenMonBacTho", Convert.ToInt32(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString()), Convert.ToInt32(row["MS_CHUYEN_MON"].ToString()), Convert.ToInt32(row["MS_BAC_THO"].ToString()),
                                    row["NGAY"], row["DEL"]);
                                tran.Commit();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        tran.Rollback();
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgThemCMBTLoi",
                          Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            { }

            VisibleButtonCM_BT(true);
            grdNVien.Enabled = true;
            optNTHT.Enabled = true;
        }
        private void btnKhongghi2_Click(object sender, EventArgs e)
        {
            VisibleButtonCM_BT(true);
            optNTHT.Enabled = true;
            grdNVien.Enabled = true;
            grvNVien_FocusedRowChanged(grvNVien, null);
        }
        private void btnChonCM_BT_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddCM_BT frm = new MVControl.frmAddCM_BT();
                frm.MS_CONG_NHAN = grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.dtTMP = dtCM_BT.Copy();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dtCM_BT = frm.dtTTPT1.Copy();

                    BindDataCM_BT();
                    grvChuyenmon_FocusedRowChanged(grvChuyenmon, null);
                }
            }
            catch
            { }
        }
        #endregion

        #region TaiNan
        DateTime NGAY_TAI_NAN_TMP;

        int blnThemTainan = 0;
        private void btnThem4_Click(object sender, EventArgs e)
        {
            RefeshTainan();
            VisibleButtonTainan(false);
            optNTHT.Enabled = false;
            LockDataTainan(false);
            
            grdNVien.Enabled = false;
            grdThongtintainan.Enabled = false;
            blnThemTainan = 1;
        }
        private void btnSua4_Click(object sender, EventArgs e)
        {

            VisibleButtonTainan(false);
            optNTHT.Enabled = false;
            LockDataTainan(false);
            
            grdNVien.Enabled = false;
            grdThongtintainan.Enabled = false;
            blnThemTainan = 2;
            NGAY_TAI_NAN_TMP = dtpNGAY_TAI_NAN.DateTime.Date;
        }
        private void btnXoa4_Click(object sender, EventArgs e)
        {
            blnThemTainan = 0;
            try
            {

                if (grvThongtintainan.RowCount <= 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa41", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa42", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteTAI_NAN_LD", grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), dtpNGAY_TAI_NAN.DateTime.Date);

                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "UPDATE_TAI_NAN_LD_LOG", grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), dtpNGAY_TAI_NAN.DateTime.Date, this.Name, Commons.Modules.UserName, 3);

                grvNVien_FocusedRowChanged(grvNVien, null);
            }
            catch { }
        }
        private void btnThoat4_Click(object sender, EventArgs e)
        {
            blnThemTainan = 0;
            this.Close();
        }
        private void btnGhi4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpNGAY_TAI_NAN.DateTime.Date > System.DateTime.Now.Date)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra421", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpNGAY_TAI_NAN.Focus();
                    dtpNGAY_TAI_NAN.EditValue = System.DateTime.Now.Date;
                    return;
                }

                string SQL_TMP = "SELECT * FROM TAI_NAN_LD WHERE MS_CONG_NHAN ='" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "'  AND convert(nvarchar(10), NGAY_TAI_NAN, 103) = convert(nvarchar(10),'" + dtpNGAY_TAI_NAN.DateTime.ToShortDateString() + "',103)";
                SqlDataReader dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                // Kiểm tra ngày tai nạn của công nhân này đã tồn tại hay chưa.
                if (blnThemTainan == 1)
                {
                    while (dtReader.Read())
                    {

                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgGhi41", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtpNGAY_TAI_NAN.Focus();
                        dtReader.Close();
                        return;
                        //break; // TODO: might not be correct. Was : Exit While

                    }
                }
                else if (blnThemTainan == 2)
                {
                    if (dtpNGAY_TAI_NAN.DateTime.Date != NGAY_TAI_NAN_TMP)
                    {
                        while (dtReader.Read())
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgGhi42", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtpNGAY_TAI_NAN.Focus();
                            dtReader.Close(); return;
                            //break; // TODO: might not be correct. Was : Exit While
                        }
                    }
                }

                try
                {
                    Convert.ToDateTime(txtGIO.EditValue);
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra1", Commons.Modules.TypeLanguage), "HH:mm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGIO.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtNOI_XAY_RA.Text.Trim()))
                {
                    // Nơi xảy ra tai nạn không được rỗng.
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra41", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNOI_XAY_RA.Focus();
                    txtNOI_XAY_RA.Text = "";
                    return;
                }

                if (string.IsNullOrEmpty(txtTINH_TRANG.Text.Trim()))
                {
                    // Tình trạng tai nạn không được rỗng.
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra42", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTINH_TRANG.Focus();
                    txtTINH_TRANG.Text = "";
                    return;
                }



                TAI_NAN_LDInfo objTainanInfo = new TAI_NAN_LDInfo();
                clsTAI_NAN_LDController objTainanController = new clsTAI_NAN_LDController();
                objTainanInfo.MS_CONG_NHAN = grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString();
                objTainanInfo.NGAY_TAI_NAN = dtpNGAY_TAI_NAN.DateTime;
                if (txtGIO.Text == "  :")
                {
                    objTainanInfo.GIO = "";
                }
                else
                {
                    objTainanInfo.GIO = txtGIO.Text;
                }

                objTainanInfo.NOI_XAY_RA = txtNOI_XAY_RA.Text;
                objTainanInfo.TINH_TRANG = txtTINH_TRANG.Text;
                objTainanInfo.NGUYEN_NHAN = txtNGUYEN_NHAN.Text;
                objTainanInfo.GIAI_QUYET = txtGIAI_QUYET.Text;
                if (blnThemTainan == 2)
                {
                    objTainanInfo.NGAY_TN_TMP = NGAY_TAI_NAN_TMP;
                    objTainanController.UpdateTAI_NAN_LD(objTainanInfo, this.Name);
                }
                else if (blnThemTainan == 1)
                {
                    objTainanController.AddTAI_NAN_LD(objTainanInfo, this.Name);
                }

                optNTHT.Enabled = true;
                VisibleButtonTainan(true);
                LockDataTainan(true);
                
                grdNVien.Enabled = true;
                grdThongtintainan.Enabled = true;


                blnThemTainan = 0;
                grvNVien_FocusedRowChanged(grvNVien, null);
            }
            catch
            { }

        }
        private void btnKhongghi4_Click(object sender, EventArgs e)
        {

            VisibleButtonTainan(true);
            optNTHT.Enabled = true;
            LockDataTainan(true);
            
            grdNVien.Enabled = true;
            grdThongtintainan.Enabled = true;
            blnThemTainan = 0;
            grvNVien_FocusedRowChanged(grvNVien, null);
        }
        private void grvThongtintainan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RefeshTainan();
            ShowTainan();
        }
        #endregion

        #region TienLuong
        int blnThemLuong = 0;
        private void btnThem3_Click(object sender, EventArgs e)
        {
            RefeshLuong();
            VisibleButtonLuong(false);
            optNTHT.Enabled = false;
            LockDataLuong(false);
            
            grdNVien.Enabled = false;
            grdQuatrinhluong.Enabled = false;
            blnThemLuong = 1;


            txtSO_QUYET_DINH.Focus();
            SqlDataReader dtReader;
            string _NGOAI_TE = "";

            if (((DataTable)(cboNGOAI_TE.Properties.DataSource)).Rows.Count > 0)
            {
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH=1");
                dtReader.Read();
                _NGOAI_TE = dtReader["NGOAI_TE"].ToString();
                cboNGOAI_TE.EditValue = _NGOAI_TE;
                cboNGOAI_TE.Enabled = false;
                dtReader.Close();
            }
        }
        string SOQD_Tmp = "";
        DateTime Ngay_HL_tmp;
        private void btnSua3_Click(object sender, EventArgs e)
        {
            VisibleButtonLuong(false);
            optNTHT.Enabled = false;
            LockDataLuong(false);
            
            grdNVien.Enabled = false;
            grdQuatrinhluong.Enabled = false;
            blnThemLuong = 2;
            try
            {
                Ngay_HL_tmp = Convert.ToDateTime(txtNGAY_HIEU_LUC.Text);
            }
            catch
            {
                Ngay_HL_tmp = DateTime.MinValue;
            }
            SOQD_Tmp = txtSO_QUYET_DINH.Text;
        }
        private void btnXoa3_Click(object sender, EventArgs e)
        {
            try
            {
                clsLUONG_CO_BANController objLuongController = new clsLUONG_CO_BANController();
                if (grvQuatrinhluong.RowCount <= 0)
                {
                    // Nếu không có dữ liệu thì đưa ra thông báo và thoát.
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa31", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa32", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;
                objLuongController.DeleteLUONG_CO_BAN(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), txtSO_QUYET_DINH.Text.Trim());

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_LUONG_CO_BAN_LOG", grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), txtSO_QUYET_DINH.Text.Trim(), this.Name, Commons.Modules.UserName, 3);
                grvNVien_FocusedRowChanged(grvNVien, null);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool IsValidatedLuong()
        {

            if (string.IsNullOrEmpty(txtSO_QUYET_DINH.Text.Trim()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi33", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSO_QUYET_DINH.Focus();
                return false;
            }
            else
            {
                string SQL_TMP = "SELECT * FROM LUONG_CO_BAN WHERE MS_CONG_NHAN ='" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "' AND SO_QUYET_DINH = '" + txtSO_QUYET_DINH.Text.Trim() + "'";
                SqlDataReader dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);

                if (blnThemLuong == 1)
                {
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgGhi31", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSO_QUYET_DINH.Focus();
                        dtReader.Close();
                        return false;
                    }
                }
                else
                {
                    if (txtSO_QUYET_DINH.Text.Trim() != SOQD_Tmp)
                    {
                        while (dtReader.Read())
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgGhi32", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSO_QUYET_DINH.Focus();
                            dtReader.Close();
                            return false;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(txtNGAY_KY.Text.Trim()))
            {
                try
                {
                    Convert.ToDateTime(txtNGAY_KY.Text.Trim());
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra310", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_KY.Focus();
                    txtNGAY_KY.Text = "";
                    return false;
                }
                if (Convert.ToDateTime(txtNGAY_KY.Text.Trim()).Date > System.DateTime.Now.Date)
                {
                    // Ngày ký phải nhỏ hơn hoặc bằng ngày hiện tại.
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra311", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_KY.Focus();
                    txtNGAY_KY.Text = "";
                    return false;
                }
            }


            if (string.IsNullOrEmpty(txtNGAY_HIEU_LUC.Text.Trim()))
            {
                // Ngày hiệu lực không được rỗng.
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra37", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNGAY_HIEU_LUC.Focus();
                txtNGAY_HIEU_LUC.Text = "";
                return false;
            }
            else
            {
                try
                {
                    Convert.ToDateTime(txtNGAY_HIEU_LUC.Text.Trim());
                }
                catch
                {
                    // Ngày tháng kieu dd/mm/yyyy
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra38", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_HIEU_LUC.Focus();
                    txtNGAY_HIEU_LUC.Text = "";
                    return false;
                }


                if (Convert.ToDateTime(txtNGAY_HIEU_LUC.Text.Trim()) < Convert.ToDateTime(txtNGAY_KY.Text.Trim()))
                {
                    // Ngày hiệu lực phải lớn hơn hoặc bằng ngày ký.
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra39", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtNGAY_HIEU_LUC.Focus()
                    txtNGAY_HIEU_LUC.Text = "";
                    txtNGAY_HIEU_LUC.Focus();
                    return false;
                }

                string SQL_TMP = "SELECT * FROM LUONG_CO_BAN WHERE MS_CONG_NHAN ='" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "' AND SO_QUYET_DINH = '" + txtSO_QUYET_DINH.Text.Trim() + "'  AND  convert(nvarchar(10), NGAY_HIEU_LUC,103) = convert(nvarchar(10),'" + txtNGAY_HIEU_LUC.Text.Trim() + "',103)";
                SqlDataReader dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                // Kiểm tra ngày tai nạn của công nhân này đã tồn tại hay chưa.
                if (blnThemLuong == 1)
                {
                    while (dtReader.Read())
                    {
                        // Trong một ngày, một công nhân không thể có hai số quyết định lương.
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgGhi301", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNGAY_HIEU_LUC.Focus();
                        dtReader.Close();
                        return false;
                    }
                }
                else if (blnThemLuong == 2)
                {
                    if (Convert.ToDateTime(txtNGAY_HIEU_LUC.Text) != Ngay_HL_tmp)
                    {
                        while (dtReader.Read())
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgGhi301", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNGAY_HIEU_LUC.Focus();
                            dtReader.Close();
                            return false;
                        }
                    }
                }

            }
            if (string.IsNullOrEmpty(txtHIEU_SUAT.Text.Trim()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra34", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHIEU_SUAT.Focus();
                txtHIEU_SUAT.Text = "";
                return false;
            }

            try
            {
                Convert.ToInt32(txtHIEU_SUAT.Text.Trim());
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra35", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show("Hiệu suất phải là kiểu số")
                txtHIEU_SUAT.Focus();
                txtHIEU_SUAT.Text = "";
                return false;
            }

            if (Convert.ToDouble(txtHIEU_SUAT.Text.Trim()) < 0 | Convert.ToDouble(txtHIEU_SUAT.Text.Trim()) > 100)
            {
                //MessageBox.Show("Hiệu suất phải lớn hơn hoặc bằng 0 và nhỏ hơn hoặc bằng 100")
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra36", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtHIEU_SUAT.Focus();
                txtHIEU_SUAT.Text = "";
                return false;
            }
            else
            {
                txtHIEU_SUAT.Text = Convert.ToDouble(txtHIEU_SUAT.Text.Trim()).ToString();
            }


            if (string.IsNullOrEmpty(txtLUONG_CO_BAN.Text.Trim()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra31", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLUONG_CO_BAN.Focus();
                txtLUONG_CO_BAN.Text = "";
                return false;
            }

            try
            {
                Convert.ToDouble(txtLUONG_CO_BAN.Text.Trim());
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra32", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLUONG_CO_BAN.Focus();
                txtLUONG_CO_BAN.Text = "";
                return false;
            }

            if (Convert.ToDouble(txtLUONG_CO_BAN.Text.Trim()) < 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra33", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLUONG_CO_BAN.Focus();
                txtLUONG_CO_BAN.Text = "";
                return false;
            }
            else
            {
                txtLUONG_CO_BAN.Text = string.Format(txtLUONG_CO_BAN.Text.Trim(), "###,##0.00");
            }





            return true;
        }
        private void btnGhi3_Click(object sender, EventArgs e)
        {

            try
            {
                if (IsValidatedLuong() == false) return;
                string tmp = txtSO_QUYET_DINH.Text;
                LUONG_CO_BANInfo objLuongInfo = new LUONG_CO_BANInfo();
                clsLUONG_CO_BANController objLuongController = new clsLUONG_CO_BANController();
                objLuongInfo.MS_CONG_NHAN = grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString();
                objLuongInfo.SO_QUYET_DINH = txtSO_QUYET_DINH.Text;
                if (txtNGAY_KY.Text == "  /  /")
                {
                    objLuongInfo.NGAY_KY = "";
                }
                else
                {
                    objLuongInfo.NGAY_KY = txtNGAY_KY.Text;
                }
                objLuongInfo.NGUOI_KY = txtNGUOI_KY.Text;
                objLuongInfo.NGAY_HIEU_LUC = txtNGAY_HIEU_LUC.Text;
                objLuongInfo.LUONG_CO_BAN = Convert.ToDouble(txtLUONG_CO_BAN.Text.Trim());
                objLuongInfo.HIEU_SUAT = Convert.ToDouble(txtHIEU_SUAT.Text);
                objLuongInfo.NGOAI_TE = cboNGOAI_TE.Text;
                if (blnThemLuong == 2)
                {
                    objLuongInfo.SO_QD_Tmp = SOQD_Tmp;
                    objLuongController.UpdateLUONG_CO_BAN(objLuongInfo, this.Name);
                }
                else if (blnThemLuong == 1)
                {
                    objLuongController.AddLUONG_CO_BAN(objLuongInfo, this.Name);
                }

                VisibleButtonLuong(true);
                optNTHT.Enabled = true;
                LockDataLuong(true);
                
                grdNVien.Enabled = true;
                grdQuatrinhluong.Enabled = true;
                grvNVien_FocusedRowChanged(grvNVien, null);

            }
            catch
            { }
        }
        private void btnKhongghi3_Click(object sender, EventArgs e)
        {
            VisibleButtonLuong(true);
            optNTHT.Enabled = true;
            LockDataLuong(true);
            
            grdNVien.Enabled = true;
            grdQuatrinhluong.Enabled = true;
            blnThemLuong = 0;
        }
        private void btnThoat3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dtpNGAY_KY_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

            try
            {
                if ((dtpNGAY_KY.EditValue == e.Value))
                {
                    return;
                }
                txtNGAY_KY.Text = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                txtNGAY_KY.Focus();
            }
            catch
            {}

        }
        private void dtpNGAY_HIEU_LUC_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if ((dtpNGAY_HIEU_LUC.EditValue == e.Value))
                {
                    return;
                }
                txtNGAY_HIEU_LUC.Text = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                txtNGAY_HIEU_LUC.Focus();
            }
            catch
            {}
        }
        private void grvQuatrinhluong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RefeshLuong();
            ShowLuong();
        }

        #endregion

        #region LyLich
        int blnThemLyLich = 0;
        string MS_CN_Temp = "";
        private void btnThem_Click(object sender, EventArgs e)
        {
            Refesh();
            VisibleButton(false);
            optNTHT.Enabled = false;
            LockData(false);
            
            grdNVien.Enabled = false;
            blnThemLyLich = 1;

            txtNGAY_NGHI_VIEC.Properties.ReadOnly = true;
            dtpNGAY_NGHI_VIEC.Enabled = false;
            txtLY_DO_NGHI.Properties.ReadOnly = true;


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            VisibleButton(false);
            optNTHT.Enabled = false;
            LockData(false);
            
            grdNVien.Enabled = false;
            blnThemLyLich = 2;
            MS_CN_Temp = txtMS_CONG_NHAN.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string SQL_TMP = "";
                SqlDataReader dtReader;
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SQL_TMP = "SELECT * FROM CHUC_VU WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa3", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    //  Kiểm tra CONG_NHAN này có đang được sử dụng trong bảng CONG_NHAN_CHUYEN_MON không.

                    SQL_TMP = "SELECT * FROM CONG_NHAN_CHUYEN_MON WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        //MsgBox("CONG_NHAN này đang được sử dụng trong CONG_NHAN_CHUYEN_MON! Không thể xóa.", MessageBoxButtons.OK + MessageBoxIcon.Information, "Thông báo")
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa4", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    // Kiểm tra công nhân này có đang tồn tại trong table GIAM_SAT_TINH_TRANG không?

                    SQL_TMP = "SELECT * FROM GIAM_SAT_TINH_TRANG WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa51", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    //  Kiểm tra CONG_NHAN này có đang được sử dụng trong bảng KE_HOACH_THUC_HIEN không.

                    SQL_TMP = "SELECT * FROM KE_HOACH_THUC_HIEN WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa52", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    //  Kiểm tra CONG_NHAN này có đang được sử dụng trong bảng LUONG_CO_BAN không.

                    SQL_TMP = "SELECT * FROM LUONG_CO_BAN WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa6", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    // Kiểm tra nhân viên này có đang được sử dụng trong table PHIEU_BAO_TRI không.

                    SQL_TMP = "SELECT * FROM PHIEU_BAO_TRI WHERE NGUOI_LAP = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "' OR NGUOI_GIAM_SAT = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa53", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    //  Kiểm tra nhân viên này có đang được sử dụng trong table TAI_NAN_LD không.

                    SQL_TMP = "SELECT * FROM TAI_NAN_LD WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa7", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    //  Kiểm tra CONG_NHAN này có đang được sử dụng trong bảng BACK_UP_XOA không.

                    SQL_TMP = "SELECT * FROM YEU_CAU_NSD_CHI_TIET WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa8", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    // Kiểm tra công nhân có tồn tại trong table CONG_VIEC_HANG_NGAY_NV

                    SQL_TMP = "SELECT * FROM CONG_VIEC_HANG_NGAY_NV WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa801", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    // Kiểm tra công nhân có tồn tại trong table IC_DON_HANG_XUAT

                    SQL_TMP = "SELECT * FROM IC_DON_HANG_XUAT WHERE NGUOI_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNhanviendasudungtrongdonhangxuat", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    // Kiểm tra công nhân có tồn tại trong table IC_DON_HANG_NHAP

                    SQL_TMP = "SELECT * FROM IC_DON_HANG_NHAP WHERE NGUOI_NHAP = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNhanviendasudungtrongdonhangnhap", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();


                    // Kiểm tra công nhân có tồn tại trong table TRUC_CA

                    SQL_TMP = "SELECT * FROM TRUC_CA WHERE TRUONG_CA = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa802", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();

                    // Kiểm tra công nhân này có tồn tại trong trực ca chi tiết 
                    SQL_TMP = "SELECT * FROM TRUC_CA_CONG_NHAN WHERE CN_GIAI_QUYET = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa803", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();
                    SQL_TMP = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa804", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();
                    SQL_TMP = "SELECT * FROM PHIEU_BAO_TRI_CV_PHU_TRO_NHAN_SU WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa804", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();
                    SQL_TMP = "SELECT * FROM EOR WHERE MS_CN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "' OR MS_CN_1='" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa805", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();
                    SQL_TMP = "SELECT MS_CONG_NHAN FROM CONG_NHAN_VAI_TRO WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                    dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa806", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtReader.Close();
                        return;
                    }
                    dtReader.Close();
                    // Xóa CONG_NHAN 

                    clsCONG_NHANController objCONG_NHANController = new clsCONG_NHANController();

                    objCONG_NHANController.DeleteCONG_NHAN(txtMS_CONG_NHAN.Text, this.Name);
                    Refesh();
                    BindData();
                    grvNVien_FocusedRowChanged(grvNVien, null);
                    if (grvNVien.RowCount <= 0)
                    {
                        LoadcboDON_VI1();
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            grvNVien_FocusedRowChanged(grvNVien, null);

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (txtMS_CONG_NHAN.Text == "") return;
            try
            {
                byte[] arrImage = null;
                bool Hinh = false;
                if (string.IsNullOrEmpty(txtHINH_CN.Text) == false)
                {
                    try
                    {
                        System.IO.FileInfo _fileInfo = new System.IO.FileInfo(txtHINH_CN.Text);
                        long _NumBytes = _fileInfo.Length;
                        System.IO.FileStream _FStream = new System.IO.FileStream(txtHINH_CN.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FStream);
                        arrImage = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes));
                        _fileInfo = null;
                        _NumBytes = 0;
                        _FStream.Close();
                        _FStream.Dispose();
                        _BinaryReader.Close();
                        Hinh = true;
                    }
                    catch 
                    {
                        arrImage = null;
                        Hinh = false;
                    }
                }
                else
                {
                    Hinh = false;
                }
                DataTable dtTmp = new DataTable();
                if (Hinh)
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Printlylichcongnhan", txtMS_CONG_NHAN.Text, arrImage));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Printlylichcongnhan", txtMS_CONG_NHAN.Text, null));


                frmReport frm = new frmReport();
                frm.rptName = "Nhanvien";
                dtTmp.TableName = "NHAN_VIEN";
                frm.AddDataTableSource(dtTmp);

                System.Data.DataTable TbTieuDe = new System.Data.DataTable();
                TbTieuDe.Columns.Add("HO_TEN");
                TbTieuDe.Columns.Add("DON_VI");
                TbTieuDe.Columns.Add("BO_PHAN");
                TbTieuDe.Columns.Add("NGAY_SINH");
                TbTieuDe.Columns.Add("NOI_SINH");
                TbTieuDe.Columns.Add("CMND");
                TbTieuDe.Columns.Add("NGAY_CAP");
                TbTieuDe.Columns.Add("NOI_CAP");
                TbTieuDe.Columns.Add("DCHI");
                TbTieuDe.Columns.Add("TDVH");
                TbTieuDe.Columns.Add("DTDD");
                TbTieuDe.Columns.Add("NGAY_VL");
                TbTieuDe.Columns.Add("CHUYEN_MON");
                TbTieuDe.Columns.Add("LCB");
                TbTieuDe.Columns.Add("NGAY_NGHI");
                TbTieuDe.Columns.Add("LD_NGHI");
                TbTieuDe.Columns.Add("NGUOI_THAN");
                TbTieuDe.Columns.Add("TAI_NAN");
                TbTieuDe.Columns.Add("MS_NV");
                TbTieuDe.Columns.Add("TO");
                TbTieuDe.Columns.Add("BCAP");
                TbTieuDe.Columns.Add("DT_NHA");
                TbTieuDe.Columns.Add("CHUC_VU");
                TbTieuDe.Columns.Add("BAC_THO");
                TbTieuDe.Columns.Add("QUAN_HE");
                TbTieuDe.Columns.Add("NGAY_IN");
                TbTieuDe.Columns.Add("TMP1");
                TbTieuDe.Columns.Add("TMP2");
                TbTieuDe.Columns.Add("TMP3");
                TbTieuDe.Columns.Add("TMP4");
                TbTieuDe.Columns.Add("TMP5");

                DataRow rTitle = TbTieuDe.NewRow();
                rTitle["HO_TEN"] = lblHo.Text + ' ' + lblTen.Text.ToLower();
                rTitle["DON_VI"] = lblDonvi2.Text;
                rTitle["BO_PHAN"] = lblTo2.Text;
                rTitle["NGAY_SINH"] = lblNgaysinh.Text;
                rTitle["NOI_SINH"] = lblNoisinh.Text;
                rTitle["CMND"] = lblSoCMND.Text;
                rTitle["NGAY_CAP"] = lblNgaycap.Text;
                rTitle["NOI_CAP"] = lblNoicap.Text;
                rTitle["DCHI"] = lblDiachi.Text;
                rTitle["TDVH"] = lblTrinhdoVH.Text;
                rTitle["DTDD"] = lblDienthoaididong.Text;
                rTitle["NGAY_VL"] = lblNgayvaolam.Text;
                rTitle["CHUYEN_MON"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "Nhanvien", "CHUYEN_MON", Commons.Modules.TypeLanguage);
                rTitle["LCB"] = lblLuongcoban.Text;
                rTitle["NGAY_NGHI"] = lblNgaynghiviec.Text;
                rTitle["LD_NGHI"] = lblLydonghiviec.Text;
                rTitle["NGUOI_THAN"] = lblHotennguoithan.Text;
                rTitle["TAI_NAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "Nhanvien", "TAI_NAN", Commons.Modules.TypeLanguage);
                rTitle["MS_NV"] = lblMaso.Text;
                rTitle["TO"] = lblTo3.Text;
                rTitle["BCAP"] = lblBangcap.Text;
                rTitle["DT_NHA"] = lblDienthoainharieng.Text;
                rTitle["CHUC_VU"] = lblChucVu.Text;
                rTitle["BAC_THO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "Nhanvien", "BAC_THO", Commons.Modules.TypeLanguage);
                rTitle["QUAN_HE"] = lblQuanhe.Text;
                rTitle["NGAY_IN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "Nhanvien", "NGAY_IN", Commons.Modules.TypeLanguage) + " : " + DateTime.Now.Date;
                

                TbTieuDe.TableName = "TIEU_DE";
                TbTieuDe.Rows.Add(rTitle);
                frm.AddDataTableSource(TbTieuDe);
                this.Cursor = Cursors.Default;
                frm.ShowDialog(this);

                //Commons.OSystems obj = new Commons.OSystems();
                //Commons.clsprintnhanvien obj1 = new Commons.clsprintnhanvien();
                //DataTable dt = new DataTable();
                //DataRow row = default(DataRow);
                //string tenchucvu = "";
                //string path = "";
                //string bacluong = "";
                //if (string.IsNullOrEmpty(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString())) return;

                //obj.XoaTable("dbo.rptBaocaocongnhan");
                //if (grvNVien.RowCount <= 0)
                //    return;
                //obj1.Printlylichcongnhan(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString());
                //dt = obj1.Getduongdan(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString());
                //if (dt.Rows.Count > 0)
                //{
                //    row = dt.Rows[0];
                //    path = row["HINH_CN"].ToString();
                //}
                //System.System.IO.FileStream fileData1 = default(System.System.IO.FileStream);
                //System.System.IO.BinaryReader binarydata1 = default(System.System.IO.BinaryReader);
                //byte[] bty1 = null;

                //if (!string.IsNullOrEmpty(path) && File.Exists(path) == true)
                //{
                //    fileData1 = new System.System.IO.FileStream(path, System.System.IO.FileMode.OpenOrCreate, System.System.IO.FileAccess.Read);
                //    binarydata1 = new System.System.IO.BinaryReader(fileData1);
                //    bty1 = binarydata1.ReadBytes(Convert.ToInt32(fileData1.Length));
                //    obj1.Updateimage(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), bty1);
                //}

                //DataTable dt1 = new DataTable();
                //DataRow row1 = default(DataRow);
                //dt1 = obj1.Getchucvu_cn(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString());
                //if (dt1.Rows.Count > 0)
                //{
                //    row1 = dt1.Rows[0];
                //    tenchucvu = row1["TEN_CHUC_VU"].ToString();
                //}
                //DataTable dt2 = new DataTable();
                //DataRow row2 = default(DataRow);
                //dt2 = obj1.PrintBacluong(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString());
                //if (dt2.Rows.Count > 0)
                //{
                //    row2 = dt2.Rows[0];
                //    bacluong = row2["LUONG_CO_BAN"].ToString();

                //}
                ////Call ReportPreview("reports\BangKeHoaDon-DichVuMuaVao.rpt", "", "thang= '" & thang & " '&nam='" & nam & "'&nam='" & nam & "'&nguoinopthue='" & nguoitinhthue & "'&Masothue='" & masothue & "'")
                //Commons.mdShowReport.ReportPreview("reports\\Nhanvien.rpt", "", "CHUC_VU='" + tenchucvu + "'&LCB='" + bacluong + "'");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {


                if (IsValidatedLyLich() == false) return;

                AddCONG_NHAN();

                if (txtHINH_CN.Text.Trim() != "")
                {
                    clsCONG_NHANController objCONG_NHANController = new clsCONG_NHANController();

                    string strDuongDan = @"";
                    strDuongDan = Commons.Modules.ObjSystems.CapnhatTL(false, MS_CN_Temp);
                    string str = "";
                    str = strDuongDan + "\\" + "NV_" + MS_CN_Temp.Replace("/", "_") + "_" + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + Commons.Modules.ObjSystems.LayDuoiFile(txtHINH_CN.Text.Trim());

                    Commons.Modules.ObjSystems.LuuDuongDan(txtHINH_CN.Text.Trim(), str);
                    txtHINH_CN.Text = str;
                    objCONG_NHANController.UpdateHinhCONG_NHAN(MS_CN_Temp, str);
                }

                VisibleButton(true);
                optNTHT.Enabled = true;
                LockData(true);
                
                grdNVien.Enabled = true;


                Refesh();
                BindData();
                grvNVien_FocusedRowChanged(grvNVien, null);


                MS_CN_Temp = "";
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        public bool IsValidatedLyLich()
        {

            string SQL_TMP = "";
            SqlDataReader dtReader;


            if (string.IsNullOrEmpty(txtMS_CONG_NHAN.Text.Trim()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi1", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMS_CONG_NHAN.Focus();
                return false;
            }
            else
            {
                if (txtMS_CONG_NHAN.Text.Trim().Split(' ').Count() > 1)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi77", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMS_CONG_NHAN.Focus();
                    txtMS_CONG_NHAN.SelectAll();
                    return false;
                }

                SQL_TMP = "SELECT MS_CONG_NHAN FROM CONG_NHAN WHERE MS_CONG_NHAN = '" + txtMS_CONG_NHAN.Text.Replace("'", "''") + "'";
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL_TMP);
                if (blnThemLyLich == 1)
                {
                    while (dtReader.Read())
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi7", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMS_CONG_NHAN.Focus();
                        txtMS_CONG_NHAN.SelectAll();
                        dtReader.Close();
                        return false;
                    }
                }
                else if (blnThemLyLich == 2)
                {
                    if (txtMS_CONG_NHAN.Text != MS_CN_Temp)
                    {
                        while (dtReader.Read())
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi8", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMS_CONG_NHAN.Focus();
                            txtMS_CONG_NHAN.SelectAll();
                            dtReader.Close();
                            return false;
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(txtHO.Text.Trim()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi3", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHO.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTEN.Text.Trim()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi2", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTEN.Focus();
                return false;

            }


            if (!string.IsNullOrEmpty(txtNGAY_SINH.Text.Trim()))
            {
                try
                {
                    Convert.ToDateTime(txtNGAY_SINH.Text.Trim());
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra10", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_SINH.Focus();
                    txtNGAY_SINH.Text = "";
                    return false;
                }
                if (Convert.ToDateTime(txtNGAY_SINH.Text.Trim()).Date >= DateTime.Now.Date)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra11", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_SINH.Focus();
                    txtNGAY_SINH.Text = "";
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(txtNGAY_CAP.Text.Trim()))
            {

                try
                {
                    Convert.ToDateTime(txtNGAY_CAP.Text.Trim());
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra12", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_CAP.Focus();
                    txtNGAY_CAP.Text = "";
                    return false;
                }

                if (Convert.ToDateTime(txtNGAY_CAP.Text.Trim()).Date > DateTime.Now.Date)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra13", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_CAP.Focus();
                    txtNGAY_CAP.Text = "";
                    return false;

                }
                if (!string.IsNullOrEmpty(txtNGAY_SINH.Text.Trim()))
                {
                    if (Convert.ToDateTime(txtNGAY_SINH.Text.Trim()) > Convert.ToDateTime(txtNGAY_CAP.Text.Trim()))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra14", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNGAY_CAP.Focus();
                        txtNGAY_CAP.Text = "";
                        return false;

                    }
                }
            }
            if (!string.IsNullOrEmpty(txtNGAY_VAO_LAM.Text.Trim()))
            {
                try
                {
                    Convert.ToDateTime(txtNGAY_VAO_LAM.Text.Trim());
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra15", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_VAO_LAM.Focus();
                    txtNGAY_VAO_LAM.Text = "";
                    return false;
                }

                if (Convert.ToDateTime(txtNGAY_VAO_LAM.Text.Trim()).Date > DateTime.Now.Date)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra16", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_VAO_LAM.Focus();
                    txtNGAY_VAO_LAM.Text = "";
                    return false;
                }
                if (!string.IsNullOrEmpty(txtNGAY_SINH.Text.Trim()))
                {
                    if (Convert.ToDateTime(txtNGAY_SINH.Text.Trim()).Date > Convert.ToDateTime(txtNGAY_VAO_LAM.Text.Trim()).Date)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra17", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNGAY_VAO_LAM.Focus();
                        txtNGAY_VAO_LAM.Text = "";
                        return false;
                    }
                }

                if (chkBO_VIEC.Checked == true && !string.IsNullOrEmpty(txtNGAY_NGHI_VIEC.Text.Trim()))
                {
                    if (Convert.ToDateTime(txtNGAY_VAO_LAM.Text.Trim()).Date > Convert.ToDateTime(txtNGAY_NGHI_VIEC.Text.Trim()))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra18", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNGAY_VAO_LAM.Focus();
                        txtNGAY_VAO_LAM.Text = "";
                        return false;
                    }
                }
            }


            if (chkBO_VIEC.Checked == true && !string.IsNullOrEmpty(txtNGAY_NGHI_VIEC.Text.Trim()))
            {
                try
                {
                    Convert.ToDateTime(txtNGAY_NGHI_VIEC.Text.Trim());
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra19", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_NGHI_VIEC.Focus();
                    txtNGAY_NGHI_VIEC.Text = "";
                    return false;
                }

                if (Convert.ToDateTime(txtNGAY_NGHI_VIEC.Text.Trim()).Date > DateTime.Now.Date)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra20", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_NGHI_VIEC.Focus();
                    txtNGAY_NGHI_VIEC.Text = ""; return false;
                }

                if (!string.IsNullOrEmpty(txtNGAY_SINH.Text.Trim()))
                {
                    if (Convert.ToDateTime(txtNGAY_NGHI_VIEC.Text.Trim()).Date < Convert.ToDateTime(txtNGAY_SINH.Text.Trim()).Date)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra21", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNGAY_NGHI_VIEC.Focus();
                        txtNGAY_NGHI_VIEC.Text = "";
                        return false;
                    }
                }
                if (!string.IsNullOrEmpty(txtNGAY_VAO_LAM.Text.Trim()))
                {
                    if (Convert.ToDateTime(txtNGAY_NGHI_VIEC.Text.Trim()).Date < Convert.ToDateTime(txtNGAY_VAO_LAM.Text.Trim()).Date)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra22", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNGAY_NGHI_VIEC.Focus();
                        txtNGAY_NGHI_VIEC.Text = "";
                    }
                }
            }

            if (string.IsNullOrEmpty(cboDON_VI2.Text))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi4", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDON_VI2.Focus();
                return false;
                //Exit Function
            }
            if (string.IsNullOrEmpty(cboTO2.Text.Trim()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi5", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTO2.Focus();
                return false;
                //Exit Function
            }
            if (string.IsNullOrEmpty(cboTo3.Text.Trim()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTo", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTo3.Focus();
                return false;
                //Exit Function
            }

            if (!string.IsNullOrEmpty(txtUSER_MAIL.Text.Trim()))
            {
                if ((Commons.Modules.ObjSystems.MCheckEmail(txtUSER_MAIL.Text)) == false)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongPhaiMail", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUSER_MAIL.Focus();
                    return false;
                }
            }



            if (chkBO_VIEC.Checked)
            {
                // Ngày nghỉ việc không được rỗng.
                if (string.IsNullOrEmpty(txtNGAY_NGHI_VIEC.Text.Trim()))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi9", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNGAY_NGHI_VIEC.Focus();
                    return false;
                }
                // Lý do nghỉ không được rỗng.
                if (string.IsNullOrEmpty(txtLY_DO_NGHI.Text.Trim()))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi10", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLY_DO_NGHI.Focus();
                    return false;
                    //Exit Function
                }
                else
                {
                    txtLY_DO_NGHI.Text = txtLY_DO_NGHI.Text.Trim();
                }
            }

            return true;
        }

        public void AddCONG_NHAN()
        {
            CONG_NHANInfo objCONG_NHANInfo = new CONG_NHANInfo();
            clsCONG_NHANController objCONG_NHANController = new clsCONG_NHANController();

            objCONG_NHANInfo.MS_CONG_NHAN = txtMS_CONG_NHAN.Text.Trim();
            objCONG_NHANInfo.HO = txtHO.Text.Trim();
            objCONG_NHANInfo.TEN = txtTEN.Text.Trim();
            if (txtNGAY_SINH.Text == "  /  /")
            {
                objCONG_NHANInfo.NGAY_SINH = "";
            }
            else
            {
                objCONG_NHANInfo.NGAY_SINH = txtNGAY_SINH.Text;
            }
            objCONG_NHANInfo.NOI_SINH = txtNOI_SINH.Text.Trim();
            objCONG_NHANInfo.PHAI = chkNu.Checked;
            objCONG_NHANInfo.DIA_CHI_THUONG_TRU = txtDIA_CHI_THUONG_TRU.Text.Trim();
            objCONG_NHANInfo.SO_CMND = txtSO_CMND.Text.Trim();
            objCONG_NHANInfo.BANG_CAP = txtBangcap.Text.Trim();
            objCONG_NHANInfo.Hinh_CN = txtHINH_CN.Text.Trim();
            if (txtNGAY_CAP.Text == "  /  /")
            {
                objCONG_NHANInfo.NGAY_CAP = "";
            }
            else
            {
                objCONG_NHANInfo.NGAY_CAP = txtNGAY_CAP.Text;
            }
            objCONG_NHANInfo.NOI_CAP = txtNOI_CAP.Text.Trim();

            try
            {
                objCONG_NHANInfo.MS_TO = Convert.ToInt32(cboTo3.EditValue);
            }
            catch
            {
                objCONG_NHANInfo.MS_TO = 0;
            }

            if (txtNGAY_VAO_LAM.Text == "  /  /")
            {
                objCONG_NHANInfo.NGAY_VAO_LAM = "";
            }
            else
            {
                objCONG_NHANInfo.NGAY_VAO_LAM = txtNGAY_VAO_LAM.Text;
            }
            objCONG_NHANInfo.BO_VIEC = chkBO_VIEC.Checked;
            if (!chkBO_VIEC.Checked)
            {
                objCONG_NHANInfo.NGAY_NGHI_VIEC = "";
                objCONG_NHANInfo.LY_DO_NGHI = "";
            }
            else
            {
                if (txtNGAY_NGHI_VIEC.Text == "  /  /")
                {
                    objCONG_NHANInfo.NGAY_NGHI_VIEC = "";
                }
                else
                {
                    objCONG_NHANInfo.NGAY_NGHI_VIEC = txtNGAY_NGHI_VIEC.Text;
                }
                objCONG_NHANInfo.LY_DO_NGHI = txtLY_DO_NGHI.Text.Trim();
            }
            try
            {
                objCONG_NHANInfo.MS_TRINH_DO = Convert.ToInt32(cboMS_TRINH_DO.EditValue);
            }
            catch
            {
                objCONG_NHANInfo.MS_TRINH_DO = 0 ;
            }
            objCONG_NHANInfo.NGOAI_NGU = txtNGOAI_NGU.Text.Trim();
            objCONG_NHANInfo.GHI_CHU = "";
            objCONG_NHANInfo.MS_THE_CC = txtMS_THE_CC.Text.Trim();
            objCONG_NHANInfo.SO_DT_NHA_RIENG = txtSO_DT_NHA_RIENG.Text.Trim();
            objCONG_NHANInfo.SO_DTDD = txtSO_DTDD.Text.Trim();
            objCONG_NHANInfo.USER_MAIL = txtUSER_MAIL.Text.Trim();
            objCONG_NHANInfo.TEN_NGUOI_THAN = txtTEN_NGUOI_THAN.Text.Trim();
            objCONG_NHANInfo.QUAN_HE = txtQUAN_HE.Text.Trim();
            if (blnThemLyLich == 2)
            {
                objCONG_NHANInfo.MS_CN_Temp = MS_CN_Temp;
                objCONG_NHANController.UpdateCONG_NHAN(objCONG_NHANInfo, this.Name);
            }
            else if (blnThemLyLich == 1)
            {

                objCONG_NHANController.AddCONG_NHAN(objCONG_NHANInfo, this.Name);
            }
            MS_CN_Temp = objCONG_NHANInfo.MS_CONG_NHAN;
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            Refesh();
            VisibleButton(true);
            optNTHT.Enabled = true;
            LockData(true);
            
            grdNVien.Enabled = true;
            blnThemLyLich = 0;
            grvNVien_FocusedRowChanged(grvNVien, null);
        }
        private void dtpNGAY_CAP_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if ((dtpNGAY_CAP.EditValue == e.Value))
                {
                    return;
                }
                txtNGAY_CAP.Text = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                txtNGAY_CAP.Focus();
            }
            catch
            {}
        }
        private void dtpNGAY_VAO_LAM_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if ((dtpNGAY_VAO_LAM.EditValue == e.Value))
                {
                    return;
                }
                txtNGAY_VAO_LAM.Text = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                txtNGAY_VAO_LAM.Focus();
            }
            catch 
            {}
        }
        private void dtpNGAY_NGHI_VIEC_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if ((dtpNGAY_NGHI_VIEC.EditValue == e.Value))
                {
                    return;
                }
                txtNGAY_NGHI_VIEC.Text = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                txtNGAY_NGHI_VIEC.Focus();
            }
            catch 
            {}
        }
        #endregion

        private void chkBO_VIEC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBO_VIEC.Checked)
            {
                dtpNGAY_NGHI_VIEC.Enabled = true;
                txtLY_DO_NGHI.Properties.ReadOnly = false;
            }
            else
            {
                dtpNGAY_NGHI_VIEC.Enabled = false;
                txtLY_DO_NGHI.Properties.ReadOnly = true;
            }

        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvNVien.RowCount <= 0)
                    return;
                clsCONG_NHANController objCONG_NHANController = new clsCONG_NHANController();

                if (btnLuu.Visible == true)
                {
                    MS_CN_Temp = grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString();
                }
                else
                {
                    MS_CN_Temp = grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString();
                }

                OpenFileDialog OpfHinhNV = new OpenFileDialog();

                OpfHinhNV.Filter = "Picture (*.jpg)|*.jpg|All files (*.*)|*.*";
                OpfHinhNV.FilterIndex = 1;
                OpfHinhNV.Title = "Chọn mở hình nhân viên";

                if (OpfHinhNV.ShowDialog() == DialogResult.OK)
                {
                    if (btnLuu.Visible == true)
                    {
                        txtHINH_CN.Text = OpfHinhNV.FileName;
                        return;
                    }
                    else
                    {
                        string strDuongDan = "";
                        strDuongDan = Commons.Modules.ObjSystems.CapnhatTL(false, MS_CN_Temp);
                        string str = "";
                        str = strDuongDan + "\\" + "NV_" + MS_CN_Temp.Replace("/", "_") + "_" + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + Commons.Modules.ObjSystems.LayDuoiFile(OpfHinhNV.FileName);
                        txtHINH_CN.Text = str;                        
                        Commons.Modules.ObjSystems.LuuDuongDan(OpfHinhNV.FileName, str);
                        objCONG_NHANController.UpdateHinhCONG_NHAN(MS_CN_Temp, str);
                    }
                }
                BindData();
                MS_CN_Temp = "";
            }
            catch
            { }
        }
        private void btnXoa2_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvChuyenmon.RowCount <= 0 & grvBactho.RowCount <= 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa21", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa22", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    // Traloi2 = Yes Xóa chuyên môn đang được chọn (tất nhiển xóa tất cả các bậc thợ của nó)
                    // Traloi2 = No Xóa bậc thợ dang được chọn.
                    // Traloi2 = Cancel Không thực hiện xóa gì cả.
                    switch (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoa23", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3))
                    {
                        case DialogResult.Yes:
                            // Thực hiện xóa tất cả bậc thợ của chuyên môn.
                            deleteBT(true);
                            // Thực hiện xóa chuyên môn.
                            deleteCM();
                            break;
                        case DialogResult.No:
                            // Thực hiện xóa bậc thợ đang được chọn.
                            if (grvBactho.RowCount < 1)
                                break; // TODO: might not be correct. Was : Exit Select

                            deleteBT(false);
                            break;
                        case DialogResult.Cancel:
                            return;
                    }

                    LockDataCM_BT(true);
                    grvNVien_FocusedRowChanged(grvNVien, null);
                }
                else
                {
                    return;
                }
            }
            catch
            { }

        }

        private void deleteCM()
        {

            clsCHUYEN_MON_BTController objCM_BTController = new clsCHUYEN_MON_BTController();
            objCM_BTController.DeleteCONG_NHAN_CM(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), Convert.ToInt32(grvChuyenmon.GetFocusedDataRow()["MS_CHUYEN_MON"].ToString()));

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UPDATE_CONG_NHAN_CHUYEN_MON_LOG", grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), Convert.ToInt32(grvChuyenmon.GetFocusedDataRow()["MS_CHUYEN_MON"].ToString()), this.Name, Commons.Modules.UserName, 3);



        }

        private void deleteBT(bool v)
        {
            try
            {

                clsCHUYEN_MON_BTController objCM_BTController = new clsCHUYEN_MON_BTController();
                int i = 0;
                // Xóa toàn bộ bậc thợ của chuyên môn hoặc chỉ xóa một bậc thợ.
                if (v)
                {
                    while (i < grvBactho.RowCount)
                    {
                        objCM_BTController.DeleteCONG_NHAN_CM_BT(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), Convert.ToInt32(grvChuyenmon.GetFocusedDataRow()["MS_CHUYEN_MON"].ToString()), Convert.ToInt32(grvBactho.GetDataRow(i)["MS_BAC_THO"].ToString()), this.Name);
                        i = i + 1;
                    }
                }
                else
                {
                    objCM_BTController.DeleteCONG_NHAN_CM_BT(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), Convert.ToInt32(grvChuyenmon.GetFocusedDataRow()["MS_CHUYEN_MON"].ToString()), Convert.ToInt32(grvBactho.GetFocusedDataRow()["MS_BAC_THO"].ToString()), this.Name);
                }

            }
            catch
            { }
        }
        
        private void tabNhanSu_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (tabNhanSu.SelectedTabPageIndex == 0)
                {
                    ShowCONG_NHAN();
                }
                else if (tabNhanSu.SelectedTabPageIndex == 1)
                {
                    BindDataCM_BT();
                    grvChuyenmon_FocusedRowChanged(grvChuyenmon, null);
                }
                else if (tabNhanSu.SelectedTabPageIndex == 2)
                {
                    RefeshLuong();
                    BindDataLuong();
                    ShowLuong();
                }
                else if (tabNhanSu.SelectedTabPageIndex == 3)
                {
                    RefeshTainan();
                    BindDataTainan();
                    ShowTainan();
                }
                else if (tabNhanSu.SelectedTabPageIndex == 4)
                {
                    BindDataVaitro();
                }
                btnChucvu.Visible = true;
            }
            catch
            { }

        }

        private void btnChucvu_Click(object sender, EventArgs e)
        {

            Report1.frmDanhmucchucvu frm = new Report1.frmDanhmucchucvu();
            frm.MS_CN = txtMS_CONG_NHAN.Text;
            frm.MS_CN_TMP = txtMS_CONG_NHAN.Text;
            if (btnLuu.Visible)
            {
                if (IsValidatedLyLich() == false) return;
                AddCONG_NHAN();

                MS_CN_Temp = txtMS_CONG_NHAN.Text;
               
            }
            if (grvNVien.RowCount <= 0)
                return;
            frm.ShowDialog();
            txtCHUC_VU.Text = frm.tennhanvien;
        }

        private void dtpNGAY_SINH_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if ((dtpNGAY_SINH.EditValue == e.Value))
                {
                    return;
                }
                txtNGAY_SINH.Text = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
                txtNGAY_SINH.Focus();
            }
            catch
            { }
        }
        
    }
}