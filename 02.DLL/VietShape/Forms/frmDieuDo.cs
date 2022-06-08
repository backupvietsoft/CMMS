using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace VietShape
{
    public partial class frmDieuDo : DevExpress.XtraEditors.XtraForm
    {
        public double dSO_NV_DD = 0, dSO_GIO_DD = 0, dHIEU_SUAT_DD = 0, dSO_PHUT_KHONG_DD = 0;
        public DateTime dTNgay, dDNgay;
        public frmDieuDo()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCmb()
        {
            DataTable dt = new DataTable();
            #region "Load loai may"
            try
            {
                dt = Commons.Modules.ObjSystems.MLoadDataLoaiMay(1);
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay1, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay2, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
            #endregion

            #region "Load nha xuong"
            try
            {
                dt = new DataTable();
                dt = Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1);
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cbtDDiem, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cbtDDiem1, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cbtDDiem2, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
            #endregion

            #region "Load day chuyen"
            try
            {
                dt = new DataTable();
                dt = Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1);

                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cbtDChuyen, dt, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cbtDChuyen1, dt, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cbtDChuyen2, dt, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
            #endregion
            
            #region "Load don vi"
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDV, Commons.Modules.ObjSystems.MLoadDataDonVi(1), "MS_DON_VI", "TEN_DON_VI", "");
            }
            catch { }
            #endregion

            #region "Load Nhom Dieu Do"
            LoadNhomDD();
            #endregion
        }
        private void LoadNhomDD()
        {
            #region "Load Nhom Dieu Do"
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spDDNhomMay", 1, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomDD, dt, "ID_NHOM_DD", "TEN_NHOM", "");
            }
            catch { }
            #endregion
        }
        private void frmDieuDo_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            DateTime dtNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtTNgay.DateTime = dtNgay;
            dtDNgay.DateTime = dtTNgay.DateTime.AddMonths(1).AddDays(-1);
            LoadCmb();

            Commons.Modules.SQLString = "LoadForm";
            LoadDieuDo("-1");
            Commons.Modules.SQLString = "";
            TaoPBT(0);
            
            KhoaText(true);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        
        private void LoadTextTrang()
        {
            if (string.IsNullOrEmpty(cbtDDiem.TextValue)) return;

            DateTime dtNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtMsDD.Text = "";
            txtUserDD.Text = Commons.Modules.UserName;
            dtNgayDD.DateTime = DateTime.Now;
            dtCVTNgay.DateTime = dtNgay;
            dtCVDNgay.DateTime = dtCVTNgay.DateTime.AddMonths(1).AddDays(-1);
                 
            txtGhiChu.Text = "";

        }
        private void KhoaText(bool bKhoa)
        {
            dtTNgay.Properties.ReadOnly = !bKhoa;
            dtTNgay.Properties.Buttons[0].Enabled = bKhoa;
            dtDNgay.Properties.ReadOnly = !bKhoa;
            dtDNgay.Properties.Buttons[0].Enabled = bKhoa;

            dtNgayDD.Properties.ReadOnly = bKhoa;
            dtNgayDD.Properties.Buttons[0].Enabled = !bKhoa;
            txtUserDD.Properties.ReadOnly = bKhoa;

            cboNhomDD.Enabled = !bKhoa;

            dtCVTNgay.Properties.ReadOnly = bKhoa;
            dtCVTNgay.Properties.Buttons[0].Enabled = !bKhoa;
            dtCVDNgay.Properties.ReadOnly = bKhoa;
            dtCVDNgay.Properties.Buttons[0].Enabled = !bKhoa;
                      
            txtGhiChu.Properties.ReadOnly = bKhoa;
            btnDieuDo.Visible = bKhoa;
            btnXoa.Visible = bKhoa;
            btnThoat.Visible = bKhoa;
            btnChart.Visible = bKhoa;
            btnChonNS.Visible = !bKhoa;

            btnGhi.Visible = !bKhoa;
            btnKhong.Visible = !bKhoa;
            btnChon.Visible = !bKhoa;                        
            btnBoChon.Visible = !bKhoa;
            //btnChonNS.Visible = true;

            grvPBT.OptionsBehavior.Editable = !bKhoa;          
            grvCVVP.OptionsBehavior.Editable = !bKhoa;
            grvGSTT.OptionsBehavior.Editable = !bKhoa;
            grvKHTT.OptionsBehavior.Editable = !bKhoa;
            tableLayoutPanel2.Enabled = bKhoa;
            XoaBangTmp();
        }

        private void LoadDieuDo(string sMS_DIEU_DO)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDieuDo", Commons.Modules.UserName, dtTNgay.DateTime.Date, dtDNgay.DateTime.Date));
            dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["MS_DIEU_DO"] };

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDieuDo, grvDieuDo, dtTmp, false, true, true, true, true, this.Name);
            for (int i = 2; i <= grvDieuDo.Columns.Count - 1; i++)
            {
                grvDieuDo.Columns[i].Visible = false;
            }
            if (dtTmp.Rows.Count == 0)
                LoadTextTrang();

            if (sMS_DIEU_DO != "-1")
            {
                int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(sMS_DIEU_DO));
                grvDieuDo.FocusedRowHandle = grvDieuDo.GetRowHandle(index);
            }

            tbDieuDo_SelectedPageChanged(null, null);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            KhoaText(true);
            grvDieuDo_FocusedRowChanged(null, null);
        }

        private void btnDieuDo_Click(object sender, EventArgs e)
        {
            LoadTextTrang();
            KhoaText(false);
            txtMsDD.Text = Commons.Modules.ObjSystems.CreateMsDieuDo();
            txtID.Text = "-1";
            TaoGSTT(1);
            TaoKHTT(1);
            TaoPBT(1);
            TaoCVVP(1);
        }
        private void TaoPBT(int Action)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "LoadForm") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();
                int iMSo = -1;
                try
                { iMSo = int.Parse(txtID.Text); }
                catch { }
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDieuDoPBT", iMSo, Commons.Modules.UserName, dtCVTNgay.DateTime.Date, dtCVDNgay.DateTime.Date, Commons.Modules.TypeLanguage, (cboNhomDD.Text == "" ? -1 : cboNhomDD.EditValue), Action));
                
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["TK"] };
                dtTmp.Columns["CHON"].ReadOnly = !btnGhi.Visible;
                dtTmp.Columns["NGAY_DD"].ReadOnly = !btnGhi.Visible;


                if (grdPBT.DataSource == null)
                {
                    for (int i = 1; i <= dtTmp.Columns.Count - 1; i++)
                    {
                        dtTmp.Columns[i].ReadOnly = true;
                    }

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPBT, grvPBT, dtTmp, false, true, false, true, true, this.Name);
                    grvPBT.Columns["MS_CV"].Visible = false;
                    grvPBT.Columns["MS_N_XUONG"].Visible = false;
                    grvPBT.Columns["MS_HE_THONG"].Visible = false;
                    grvPBT.Columns["MS_LOAI_MAY"].Visible = false;
                    grvPBT.Columns["MS_NHOM_MAY"].Visible = false;
                    grvPBT.Columns["MS_LOAI_BT"].Visible = false;
                    grvPBT.Columns["TINH_TRANG_PBT"].Visible = false;
                    grvPBT.Columns["K1"].Visible = false;
                    grvPBT.Columns["K2"].Visible = false;
                    grvPBT.Columns["K3"].Visible = false;
                    grvPBT.Columns["K4"].Visible = false;
                    grvPBT.Columns["K5"].Visible = false;
                    grvPBT.Columns["MS_UU_TIEN"].Visible = false;
                    grvPBT.Columns["TK"].Visible = false;

                    grvPBT.Columns["MS_NX_CHA"].Visible = false;
                    grvPBT.Columns["MS_HT_CHA"].Visible = false;
                    grvPBT.Columns["SO_NGUOI_DD"].Visible = false;

                }
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPBT, grvPBT, dtTmp, false, false, false, false, true, this.Name);


                grvPBT.Columns["MO_TA_CV"].BestFit();
                grvPBT.Columns["CHON"].OptionsColumn.ReadOnly = !btnGhi.Visible;
                grvPBT.Columns["CHON"].Visible = btnGhi.Visible;
                grvPBT.Columns["MS_DIEU_DO"].Visible = btnGhi.Visible;
                grvPBT.Columns["NGAY_DD"].Visible = btnGhi.Visible;

                grvPBT.OptionsBehavior.Editable = btnGhi.Visible;
                grvPBT.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "N0";
                grvPBT.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvPBT.Columns["SO_GIO_KH"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grvPBT.Columns["SO_GIO_KH"].SummaryItem.DisplayFormat = "Sum = {0:n0}";
                grvPBT.Columns["SO_GIO_KH"].Width = 100;
                
                grvPBT.Columns["MS_PHIEU_BAO_TRI"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                grvPBT.Columns["MS_PHIEU_BAO_TRI"].SummaryItem.FieldName = "MS_PHIEU_BAO_TRI";
                grvPBT.Columns["MS_PHIEU_BAO_TRI"].SummaryItem.DisplayFormat = "Count: {0:n0}";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void TaoKHTT(int Action)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();
                int iMSo = -1;
                try
                { iMSo = int.Parse(txtID.Text); }
                catch { }

                SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);

                SqlCommand cmd = new SqlCommand();

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 999999;
                cmd.CommandText = "spGetDieuDoKHTT";
                cmd.Parameters.Add(new SqlParameter("@IdDD", iMSo));
                cmd.Parameters.Add(new SqlParameter("@UName", Commons.Modules.UserName));
                cmd.Parameters.Add(new SqlParameter("@TNgay", dtCVTNgay.DateTime.Date));
                cmd.Parameters.Add(new SqlParameter("@DNgay", dtCVDNgay.DateTime.Date));
                cmd.Parameters.Add(new SqlParameter("@NNgu", Commons.Modules.TypeLanguage));
                cmd.Parameters.Add(new SqlParameter("@MsNhomDD", (cboNhomDD.Text == "" ? -1 : cboNhomDD.EditValue)));
                cmd.Parameters.Add(new SqlParameter("@Action", Action));

                dtTmp.Load(cmd.ExecuteReader());
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["TK"] };
                
                dtTmp.Columns["CHON"].ReadOnly = !btnGhi.Visible;
                dtTmp.Columns["NGAY_DD"].ReadOnly = !btnGhi.Visible;

                grvKHTT.ClearColumnsFilter();
                if (grdKHTT.DataSource == null)
                {
                    for (int i = 1; i <= dtTmp.Columns.Count - 1; i++)
                    {
                        dtTmp.Columns[i].ReadOnly = true;
                    }

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHTT, grvKHTT, dtTmp, false, true, false, true, true, this.Name);
                    grvKHTT.Columns["MS_CV"].Visible = false;
                    grvKHTT.Columns["MS_N_XUONG"].Visible = false;
                    grvKHTT.Columns["MS_HE_THONG"].Visible = false;
                    grvKHTT.Columns["MS_LOAI_MAY"].Visible = false;
                    grvKHTT.Columns["MS_NHOM_MAY"].Visible = false;
                    grvKHTT.Columns["K1"].Visible = false;
                    grvKHTT.Columns["K2"].Visible = false;
                    grvKHTT.Columns["K3"].Visible = false;
                    grvKHTT.Columns["K4"].Visible = false;
                    grvKHTT.Columns["K5"].Visible = false;
                    grvKHTT.Columns["MS_UU_TIEN"].Visible = false;
                    grvKHTT.Columns["HANG_MUC_ID"].Visible = false;
                    grvKHTT.Columns["TK"].Visible = false;

                    grvKHTT.Columns["MS_NX_CHA"].Visible = false;
                    grvKHTT.Columns["MS_HT_CHA"].Visible = false;                    
                    grvKHTT.Columns["SO_NGUOI_DD"].Visible = false;
                }
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHTT, grvKHTT, dtTmp, false, false, false, false, true, this.Name);

                grvKHTT.Columns["MO_TA_CV"].BestFit();
                grvKHTT.Columns["CHON"].OptionsColumn.ReadOnly = !btnGhi.Visible;
                grvKHTT.Columns["CHON"].Visible = btnGhi.Visible;
                grvKHTT.Columns["MS_DIEU_DO"].Visible = btnGhi.Visible;
                grvKHTT.Columns["NGAY_DD"].Visible = btnGhi.Visible;

                grvKHTT.Columns["THOI_GIAN_DU_KIEN"].DisplayFormat.FormatString = "N0";
                grvKHTT.Columns["THOI_GIAN_DU_KIEN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvKHTT.OptionsBehavior.Editable = btnGhi.Visible;
                grvKHTT.Columns["THOI_GIAN_DU_KIEN"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grvKHTT.Columns["THOI_GIAN_DU_KIEN"].SummaryItem.DisplayFormat = "Sum = {0:n0}";
                grvKHTT.Columns["THOI_GIAN_DU_KIEN"].Width = 100;

                grvKHTT.Columns["TEN_HANG_MUC"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                grvKHTT.Columns["TEN_HANG_MUC"].SummaryItem.FieldName = "TEN_HANG_MUC";
                grvKHTT.Columns["TEN_HANG_MUC"].SummaryItem.DisplayFormat = "Count: {0:n0}";


                #region Group
                //DevExpress.XtraGrid.Columns.GridColumn col = grvPBT.Columns["MS_PHIEU_BAO_TRI"];
                //grvPBT.BeginSort();
                //try
                //{
                //    grvPBT.ClearGrouping();
                //    col.GroupIndex = 0;
                //}
                //finally
                //{
                //    grvPBT.EndSort();
                //}
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        void RepChecked_EditValueChanged(object sender, EventArgs e)
        {
            //your code
            grvKHTT.UpdateCurrentRow();

        }
        private void TaoGSTT(int Action)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();
                int iMSo = -1;
                try
                { iMSo = int.Parse(txtID.Text); }
                catch { }

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDieuDoGSTT", iMSo, Commons.Modules.UserName, dtCVTNgay.DateTime.Date, dtCVDNgay.DateTime.Date, Commons.Modules.TypeLanguage, (cboNhomDD.Text == "" ? -1 : cboNhomDD.EditValue), Action));

                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["TK"] };
                dtTmp.Columns["CHON"].ReadOnly = !btnGhi.Visible;
                dtTmp.Columns["NGAY_DD"].ReadOnly = !btnGhi.Visible;

                if (grdGSTT.DataSource == null)
                {
                    for (int i = 1; i <= dtTmp.Columns.Count - 1; i++)
                    {
                        dtTmp.Columns[i].ReadOnly = true;
                    }

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdGSTT, grvGSTT, dtTmp, false, true, false, true, true, this.Name);
                    grvGSTT.Columns["MS_TS_GSTT"].Visible = false;
                    grvGSTT.Columns["STT"].Visible = false;
                    grvGSTT.Columns["MS_TT"].Visible = false;
                    grvGSTT.Columns["MS_N_XUONG"].Visible = false;
                    grvGSTT.Columns["MS_HE_THONG"].Visible = false;
                    grvGSTT.Columns["MS_LOAI_MAY"].Visible = false;
                    grvGSTT.Columns["MS_NHOM_MAY"].Visible = false;
                    grvGSTT.Columns["K1"].Visible = false;
                    grvGSTT.Columns["K2"].Visible = false;
                    grvGSTT.Columns["K3"].Visible = false;
                    grvGSTT.Columns["K4"].Visible = false;
                    grvGSTT.Columns["K5"].Visible = false;
                    grvGSTT.Columns["MUC_UU_TIEN"].Visible = false;
                    grvGSTT.Columns["TK"].Visible = false;
                    grvGSTT.Columns["MS_NX_CHA"].Visible = false;
                    grvGSTT.Columns["MS_HT_CHA"].Visible = false;
                    grvGSTT.Columns["SO_NGUOI_DD"].Visible = false;

                }
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdGSTT, grvGSTT, dtTmp, false, false, false, false, true, this.Name);

                grvGSTT.Columns["TEN_TS_GSTT"].BestFit();
                grvGSTT.Columns["CHON"].OptionsColumn.ReadOnly = !btnGhi.Visible;
                grvGSTT.Columns["CHON"].Visible = btnGhi.Visible;
                grvGSTT.Columns["MS_DIEU_DO"].Visible = btnGhi.Visible;
                grvGSTT.Columns["NGAY_DD"].Visible = btnGhi.Visible;
                grvGSTT.Columns["THOI_GIAN"].DisplayFormat.FormatString = "N0";
                grvGSTT.Columns["THOI_GIAN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvGSTT.OptionsBehavior.Editable = btnGhi.Visible;
                grvGSTT.Columns["THOI_GIAN"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grvGSTT.Columns["THOI_GIAN"].SummaryItem.DisplayFormat = "Sum = {0:n0}";
                grvGSTT.Columns["THOI_GIAN"].Width = 100;

                grvGSTT.Columns["SO_PHIEU"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                grvGSTT.Columns["SO_PHIEU"].SummaryItem.FieldName = "SO_PHIEU";
                grvGSTT.Columns["SO_PHIEU"].SummaryItem.DisplayFormat = "Count: {0:n0}";


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
            
        private void TaoCVVP(int Action)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();
                int iMSo = -1;
                try
                { iMSo = int.Parse(txtID.Text); }
                catch { }


                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetDieuDoCVVP", iMSo, Commons.Modules.UserName, dtCVTNgay.DateTime.Date, dtCVDNgay.DateTime.Date, Commons.Modules.TypeLanguage, (cboNhomDD.Text == "" ? -1 : cboNhomDD.EditValue), Action));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["TK"] };
                
                dtTmp.Columns["CHON"].ReadOnly = !btnGhi.Visible;
                dtTmp.Columns["NGAY_DD"].ReadOnly = !btnGhi.Visible;

                if (grdCVVP.DataSource == null)
                {
                    for (int i = 1; i <= dtTmp.Columns.Count - 1; i++)
                    {
                        dtTmp.Columns[i].ReadOnly = true;
                    }

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdCVVP, grvCVVP, dtTmp, false, true, true, true, true, this.Name);
                    grvCVVP.Columns["K1"].Visible = false;
                    grvCVVP.Columns["K2"].Visible = false;
                    grvCVVP.Columns["K3"].Visible = false;
                    grvCVVP.Columns["K4"].Visible = false;
                    grvCVVP.Columns["K5"].Visible = false;
                    grvCVVP.Columns["MS_UU_TIEN"].Visible = false;
                    grvCVVP.Columns["STT"].Visible = false;
                    grvCVVP.Columns["TK"].Visible = false;

                    grvCVVP.Columns["HO"].Visible = false;
                    grvCVVP.Columns["TEN"].Visible = false;
                    grvCVVP.Columns["MS_DON_VI"].Visible = false;
                    grvCVVP.Columns["MS_TO"].Visible = false;
                    grvCVVP.Columns["MS_PB"].Visible = false;
                    grvCVVP.Columns["SO_NGUOI_DD"].Visible = false;
                }
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdCVVP, grvCVVP, dtTmp, false, false, true, false, true, this.Name);

                grvCVVP.Columns["HO_TEN"].BestFit();
                grvCVVP.Columns["CHON"].OptionsColumn.ReadOnly = !btnGhi.Visible;
                grvCVVP.Columns["CHON"].Visible = btnGhi.Visible;
                grvCVVP.Columns["MS_DIEU_DO"].Visible = btnGhi.Visible;
                grvCVVP.Columns["NGAY_DD"].Visible = btnGhi.Visible;

                grvCVVP.Columns["THOI_GIAN_DK"].DisplayFormat.FormatString = "N0";
                grvCVVP.Columns["THOI_GIAN_DK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvCVVP.OptionsBehavior.Editable = btnGhi.Visible;
                grvCVVP.Columns["THOI_GIAN_DK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grvCVVP.Columns["THOI_GIAN_DK"].SummaryItem.DisplayFormat = "Sum = {0:n2}";
                grvCVVP.Columns["THOI_GIAN_DK"].Width = 100;

                grvCVVP.Columns["MS_CONG_NHAN"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                grvCVVP.Columns["MS_CONG_NHAN"].SummaryItem.FieldName = "MS_CONG_NHAN";
                grvCVVP.Columns["MS_CONG_NHAN"].SummaryItem.DisplayFormat = "Count: {0:n0}";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void LocDuLieu()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            string sDK = " (1 = 1) ";
            try
            {
                #region "Kiem tab de loc"
                
                switch (tbDieuDo.SelectedTabPageIndex)
                {
                    #region "PBT"
                    case 0:
                        if (cbtDDiem.EditValue == null) return;
                        if (cbtDChuyen.EditValue == null) return;
                        if (cboLMay.EditValue == null) return;
                        if (grdPBT.DataSource == null) return;
                        dtTmp = (DataTable)grdPBT.DataSource;
                        if (cbtDDiem.EditValue.ToString() != "-1")
                            sDK = sDK + " AND (MS_N_XUONG = '" + cbtDDiem.EditValue.ToString() + "' OR MS_NX_CHA LIKE '%" + cbtDDiem.EditValue.ToString() + "%') ";
                        if (cbtDChuyen.EditValue.ToString() != "-1")
                            sDK = sDK + " AND (MS_HE_THONG = " + cbtDChuyen.EditValue.ToString() + " OR MS_HT_CHA LIKE '%" + cbtDChuyen.EditValue.ToString() + "%') ";
                        if (cboLMay.EditValue.ToString() != "-1")
                            sDK = sDK + " AND (MS_LOAI_MAY = '" + cboLMay.EditValue.ToString() + "')  ";
                        break;
                    #endregion
                    #region "KHTT"
                    case 1:
                        if (cbtDDiem1.EditValue == null) return;
                        if (cbtDChuyen1.EditValue == null) return;
                        if (cboLMay1.EditValue == null) return;
                        if (grdKHTT.DataSource == null) return;
                        dtTmp = (DataTable)grdKHTT.DataSource;
                        if (cbtDDiem1.EditValue.ToString() != "-1")
                            sDK = sDK + " AND (MS_N_XUONG = '" + cbtDDiem1.EditValue.ToString() + "' OR MS_NX_CHA LIKE '%" + cbtDDiem1.EditValue.ToString() + "%') ";
                        if (cbtDChuyen1.EditValue.ToString() != "-1")
                            sDK = sDK + " AND (MS_HE_THONG = " + cbtDChuyen1.EditValue.ToString() + " OR MS_HT_CHA LIKE '%" + cbtDChuyen1.EditValue.ToString() + "%') ";
                        if (cboLMay1.EditValue.ToString() != "-1")
                            sDK = sDK + " AND MS_LOAI_MAY = '" + cboLMay1.EditValue.ToString() + "'  ";
                        break;
                    #endregion
                    #region "GSTT"
                    case 2:
                        if (cbtDDiem2.EditValue == null) return;
                        if (cbtDChuyen2.EditValue == null) return;
                        if (cboLMay2.EditValue == null) return;
                        if (grdGSTT.DataSource == null) return;
                        dtTmp = (DataTable)grdGSTT.DataSource;
                        if (cbtDDiem2.EditValue.ToString() != "-1")
                            sDK = sDK + " AND (MS_N_XUONG = '" + cbtDDiem2.EditValue.ToString() + "' OR MS_NX_CHA LIKE '%" + cbtDDiem2.EditValue.ToString() + "%') ";
                        if (cbtDChuyen2.EditValue.ToString() != "-1")
                            sDK = sDK + " AND (MS_HE_THONG = " + cbtDChuyen2.EditValue.ToString() + " OR MS_HT_CHA LIKE '%" + cbtDChuyen2.EditValue.ToString() + "%') ";
                        if (cboLMay1.EditValue.ToString() != "-1")
                            sDK = sDK + " AND MS_LOAI_MAY = '" + cboLMay1.EditValue.ToString() + "'  ";
                        break;
                    #endregion
                    #region "CVVP"
                    case 3:
                        if (cboDV.EditValue == null) return;
                        if (cboPB.EditValue == null) return;
                        if (cboTo.EditValue == null) return;
                        if (grdCVVP.DataSource == null) return;
                        dtTmp = (DataTable)grdCVVP.DataSource;
                        if (cboDV.EditValue.ToString() != "-1")
                            sDK = sDK + " AND MS_DON_VI = '" + cboDV.EditValue.ToString() + "' ";
                        if (cboPB.EditValue.ToString() != "-1")
                            sDK = sDK + " AND MS_PB = " + cboPB.EditValue.ToString() + " ";
                        if (cboTo.EditValue.ToString() != "-1")
                            sDK = sDK + " AND MS_TO = '" + cboTo.EditValue.ToString() + "'  ";
                        break;
                        #endregion
                }
                #endregion
                dtTmp.DefaultView.RowFilter = sDK;
            }
            catch
            { dtTmp.DefaultView.RowFilter = ""; }

            



        }
        private void dtCVTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (btnGhi.Visible) tbDieuDo_SelectedPageChanged(null, null);
            
        }

        private void cbtDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LocDuLieu();
        }

        private bool KiemGhi()
        {
            string sSql;
            DataTable dtTmp = new DataTable();

            try
            {

                if (txtMsDD.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapMSDD", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    sSql = "SELECT TOP 1 * FROM DIEU_DO WHERE MS_DIEU_DO = N'" + txtMsDD.Text + "' ";
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                        txtMsDD.Text = Commons.Modules.ObjSystems.CreateMsDieuDo();
                }
                if (txtUserDD.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapUser", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dtNgayDD.DateTime.ToString() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonNgayDD", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                
                if (dtCVTNgay.DateTime.ToString() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonCongViecDDTuNgay", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dtCVDNgay.DateTime.ToString() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonCongViecDDDenNgay", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (cbtDDiem.TextValue == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonNhaXuong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (cbtDChuyen.TextValue == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonDayChuyen", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (cboLMay.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonLoaiMay", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (cboNhomDD.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonNhomDD", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                sSql = "SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'DD_NS" + Commons.Modules.UserName + "') AND type in (N'U')";
                
                try
                {
                    dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count == 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonNhanSuDieuDo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                catch {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonNhanSuDieuDo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }




        private void btnGhi_Click(object sender, EventArgs e)
        {
            ColumnView view = grdPBT.FocusedView as ColumnView;
            view.CloseEditor();
            view.UpdateCurrentRow();

            view = grdKHTT.FocusedView as ColumnView;
            view.CloseEditor();
            view.UpdateCurrentRow();

            view = grdGSTT.FocusedView as ColumnView;
            view.CloseEditor();
            view.UpdateCurrentRow();

            view = grdCVVP.FocusedView as ColumnView;
            view.CloseEditor();
            view.UpdateCurrentRow();


            string sSql = "";
            DataTable dtTmp = new DataTable();
            sSql = "SELECT TOP 1 * FROM DD_TT_TMP" + Commons.Modules.UserName + " WHERE ISNULL(NGAY_DD,'01/01/1900') = '01/01/1900'";
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanChuaDieuDo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgbanChuaDieuDo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }  

            if (!KiemGhi()) return;

            dtTmp = new DataTable();
            dtTmp = (DataTable)grdPBT.DataSource; // ((DataTable)(grdPBT.DataSource)).Copy();
            dtTmp.DefaultView.RowFilter = "CHON = 1";
            string sBT = "DIEU_DO_TMP" + Commons.Modules.UserName;
            dtTmp = dtTmp.DefaultView.ToTable();
            double iDD = -1;

            SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
            if (sql.State == ConnectionState.Closed)
                sql.Open();

            SqlTransaction tran = null;
            tran = sql.BeginTransaction();
            try
            { 
                sBT = "DD_PBT_TMP" + Commons.Modules.UserName;
                if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, ""))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTaoTableDDKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tran.Rollback();
                    return;
                }

                iDD = Convert.ToDouble(SqlHelper.ExecuteScalar(tran, "spDieuDoPBTAddEdit", txtMsDD.Text, dtNgayDD.DateTime.Date, Commons.Modules.UserName, dTNgay.Date, dDNgay.Date, dtCVTNgay.DateTime.Date, dtCVDNgay.DateTime.Date, cboNhomDD.EditValue, dSO_NV_DD, dSO_GIO_DD, dHIEU_SUAT_DD, dSO_PHUT_KHONG_DD, txtGhiChu.Text, sBT, "DD_NS" + Commons.Modules.UserName, "DD_TT_TMP" + Commons.Modules.UserName));
                Commons.Modules.ObjSystems.XoaTable(sBT);
                txtID.Text = iDD.ToString();
                sBT = "DD_KHTT_TMP" + Commons.Modules.UserName;
                if (grdKHTT.DataSource != null)
                {
                    dtTmp = new DataTable();
                    dtTmp = (DataTable)grdKHTT.DataSource;
                    dtTmp.DefaultView.RowFilter = "CHON = 1";
                    dtTmp = dtTmp.DefaultView.ToTable();
                    if (dtTmp.Rows.Count > 0)
                    {
                        if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, ""))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTaoTableDDKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tran.Rollback();
                            return;
                        }
                        SqlHelper.ExecuteNonQuery(tran, "spDieuDoKHTTAddEdit", iDD, sBT);
                        Commons.Modules.ObjSystems.XoaTable(sBT);
                    }
                }
                sBT = "DD_GSTT_TMP" + Commons.Modules.UserName;
                if (grdGSTT.DataSource != null)
                {
                    dtTmp = new DataTable();
                    dtTmp = ((DataTable)(grdGSTT.DataSource)).Copy();
                    dtTmp.DefaultView.RowFilter = "CHON = 1";
                    dtTmp = dtTmp.DefaultView.ToTable();
                    if (dtTmp.Rows.Count > 0)
                    {
                        if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, ""))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTaoTableDDKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tran.Rollback();
                            return;
                        }
                        SqlHelper.ExecuteNonQuery(tran, "spDieuDoGSTTAddEdit", iDD, sBT);
                        Commons.Modules.ObjSystems.XoaTable(sBT);
                    }

                }
                sBT = "DD_CVVP_TMP" + Commons.Modules.UserName;
                if (grdCVVP.DataSource != null)
                {
                    dtTmp = new DataTable();
                    dtTmp = ((DataTable)(grdCVVP.DataSource)).Copy();
                    dtTmp.DefaultView.RowFilter = "CHON = 1";
                    dtTmp = dtTmp.DefaultView.ToTable();
                    if (dtTmp.Rows.Count > 0)
                    {
                        if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, ""))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTaoTableDDKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tran.Rollback();
                            return;
                        }
                        SqlHelper.ExecuteNonQuery(tran, "spDieuDoCVVPAddEdit", iDD, sBT);
                        Commons.Modules.ObjSystems.XoaTable(sBT);
                    }
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KhoaText(true);
            LoadDieuDo(txtMsDD.Text);
            switch (tbDieuDo.SelectedTabPageIndex)
            {
                case 0:
                    TaoPBT(0);
                    break;
                case 1:
                    TaoKHTT(0);
                    break;
                case 2:
                    TaoGSTT(0);
                    break;
                case 3:
                    TaoCVVP(0);
                    break;
            }
            LocDuLieu();
        }

        private void XoaBangTmp()
        {
            Commons.Modules.ObjSystems.XoaTable("DD_NS_TMPGSTT" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("DD_NS_GSTT" + Commons.Modules.UserName);

            Commons.Modules.ObjSystems.XoaTable("DD_NS_TMPPBT" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("DD_NS_PBT" + Commons.Modules.UserName);

            Commons.Modules.ObjSystems.XoaTable("DD_NS_TMPKHTT" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("DD_NS_KHTT" + Commons.Modules.UserName);

            Commons.Modules.ObjSystems.XoaTable("DD_NS_TMPCVVP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("DD_NS_CVVP" + Commons.Modules.UserName);

            Commons.Modules.ObjSystems.XoaTable("DD_CHART_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("DD_CHART_NS_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("DD_TT_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("DD_NS" + Commons.Modules.UserName);
        }

        private void grvDieuDo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowText();
        }

        private void ShowText()
        {
            try
            {
                txtMsDD.Text = grvDieuDo.GetFocusedRowCellValue("MS_DIEU_DO").ToString();
                dtNgayDD.DateTime = Convert.ToDateTime(grvDieuDo.GetFocusedRowCellValue("NGAY_DD").ToString());
                txtUserDD.Text = grvDieuDo.GetFocusedRowCellValue("USER_DD").ToString();
                dtCVTNgay.DateTime = Convert.ToDateTime(grvDieuDo.GetFocusedRowCellValue("CV_TN").ToString());
                dtCVDNgay.DateTime = Convert.ToDateTime(grvDieuDo.GetFocusedRowCellValue("CV_DN").ToString());
                cboNhomDD.EditValue = grvDieuDo.GetFocusedRowCellValue("ID_NHOM_DD").ToString();
                txtGhiChu.Text = grvDieuDo.GetFocusedRowCellValue("GHI_CHU").ToString();
                txtID.Text = grvDieuDo.GetFocusedRowCellValue("ID_DD").ToString();

            }catch{
                LoadTextTrang();}

            tbDieuDo_SelectedPageChanged(null, null);
        }

        private void dtTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadDieuDo("-1");
        }

        private void tbDieuDo_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "LoadForm") return;
            if (dtCVTNgay.DateTime.ToString() == "01/01/0001 00:00:00") return;
            if (dtCVDNgay.DateTime.ToString()   == "01/01/0001 00:00:00") return;
            

            switch (tbDieuDo.SelectedTabPageIndex)
            {
                case 0:
                    if (grdPBT.DataSource == null)
                        if (btnGhi.Visible) TaoPBT(1); else TaoPBT(0);
                    else
                    {
                        if (grvPBT.RowCount <= 0)
                            if (btnGhi.Visible) TaoPBT(1); else TaoPBT(0);
                        else
                        {
                            if (grvPBT.GetFocusedRowCellValue("K1").ToString() == txtID.Text && grvPBT.GetFocusedRowCellValue("K2").ToString() == Commons.Modules.UserName && Convert.ToDateTime(grvPBT.GetFocusedRowCellValue("K3").ToString()).Date == dtCVTNgay.DateTime.Date && Convert.ToDateTime(grvPBT.GetFocusedRowCellValue("K4").ToString()).Date == dtCVDNgay.DateTime.Date && grvPBT.GetFocusedRowCellValue("K5").ToString() == cboNhomDD.EditValue.ToString() )
                                return;
                            else
                                if (btnGhi.Visible) TaoPBT(1); else TaoPBT(0);
                        }
                    }
                    break;
                case 1:
                    if (grdKHTT.DataSource == null)
                        if (btnGhi.Visible) TaoKHTT(1); else TaoKHTT(0);
                    else
                    {
                        if (grvKHTT.RowCount <= 0)
                            if (btnGhi.Visible) TaoKHTT(1); else TaoKHTT(0);
                        else
                        {
                            if (grvKHTT.GetFocusedRowCellValue("K1").ToString() == txtID.Text && grvKHTT.GetFocusedRowCellValue("K2").ToString() == Commons.Modules.UserName && Convert.ToDateTime(grvKHTT.GetFocusedRowCellValue("K3").ToString()).Date == dtCVTNgay.DateTime.Date && Convert.ToDateTime(grvKHTT.GetFocusedRowCellValue("K4").ToString()).Date == dtCVDNgay.DateTime.Date && grvKHTT.GetFocusedRowCellValue("K5").ToString() == cboNhomDD.EditValue.ToString())
                                return;
                            else
                                if (btnGhi.Visible) TaoKHTT(1); else TaoKHTT(0);
                        }
                    }
                    break;
                    
                case 2:
                    if (grdGSTT.DataSource == null)
                        if (btnGhi.Visible) TaoGSTT(1); else TaoGSTT(0);
                    else
                    {
                        if (grvGSTT.RowCount <= 0)
                            if (btnGhi.Visible) TaoGSTT(1); else TaoGSTT(0);
                        else
                        {
                            if (grvGSTT.GetFocusedRowCellValue("K1").ToString() == txtID.Text && grvGSTT.GetFocusedRowCellValue("K2").ToString() == Commons.Modules.UserName && Convert.ToDateTime(grvGSTT.GetFocusedRowCellValue("K3").ToString()).Date == dtCVTNgay.DateTime.Date && Convert.ToDateTime(grvGSTT.GetFocusedRowCellValue("K4").ToString()).Date == dtCVDNgay.DateTime.Date && grvGSTT.GetFocusedRowCellValue("K5").ToString() == cboNhomDD.EditValue.ToString())
                                return;
                            else
                                if (btnGhi.Visible) TaoGSTT(1); else TaoGSTT(0);
                        }
                    }
                    break;
                    
                case 3:
                    if (grdCVVP.DataSource == null)
                        if (btnGhi.Visible) TaoCVVP(1); else TaoCVVP(0);
                    else
                    {
                        if (grvCVVP.RowCount <= 0)
                            if (btnGhi.Visible) TaoCVVP(1); else TaoCVVP(0);
                        else
                        {
                            if (grvCVVP.GetFocusedRowCellValue("K1").ToString() == txtID.Text && grvCVVP.GetFocusedRowCellValue("K2").ToString() == Commons.Modules.UserName && Convert.ToDateTime(grvCVVP.GetFocusedRowCellValue("K3").ToString()).Date == dtCVTNgay.DateTime.Date && Convert.ToDateTime(grvCVVP.GetFocusedRowCellValue("K4").ToString()).Date == dtCVDNgay.DateTime.Date && grvCVVP.GetFocusedRowCellValue("K5").ToString() == cboNhomDD.EditValue.ToString())
                                return;
                            else
                                if (btnGhi.Visible) TaoCVVP(1); else TaoCVVP(0);
                        }
                    }
                    break;
                    
            }
            LocDuLieu();
        }
        

        private void grvPBT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            grvPBT.UpdateCurrentRow();
            
        }

        private void grvKHTT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            grvKHTT.UpdateCurrentRow();

        }

        private void grvGSTT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            grvGSTT.UpdateCurrentRow();
        }

        private void grvCVVP_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            grvCVVP.UpdateCurrentRow();
        }

        private void grvKHTT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            grvKHTT.UpdateCurrentRow();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            view = grvPBT;
            switch (tbDieuDo.SelectedTabPageIndex)
            {
                case 0:
                    view = grvPBT;
                    break;
                case 1:
                    view = grvKHTT;
                    break;
                case 2:
                    view = grvGSTT;
                    break;
                case 3:
                    view = grvCVVP;
                    break;
                
            }

            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", view);
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            view = grvPBT;
            switch (tbDieuDo.SelectedTabPageIndex)
            {
                case 0:
                    view = grvPBT;
                    break;
                case 1:
                    view = grvKHTT;
                    break;
                case 2:
                    view = grvGSTT;
                    break;
                case 3:
                    view = grvCVVP;
                    break;

            }

            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", view);
        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "-1" || string.IsNullOrEmpty(txtID.Text))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuDieuDo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmDDChart frm = new frmDDChart();
            frm.txtID.Text = txtID.Text;
            frm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(grvDieuDo.RowCount==0 || grdDieuDo.DataSource == null)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaVaCapNhapLaiDuLieuDaDieuDo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
            if (sql.State == ConnectionState.Closed)
                sql.Open();

            SqlTransaction tran = null;
            tran = sql.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(tran, "spDieuDoXoa", Int64.Parse(txtID.Text));
                tran.Commit();
                dtTNgay_EditValueChanged(null, null);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTo_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LocDuLieu();
        }

        private void cboNhomDD_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index != 1) return;
            frmDDNhom frm = new frmDDNhom();
            frm.ShowDialog();
            LoadNhomDD();
        }

        private void frmDieuDo_FormClosed(object sender, FormClosedEventArgs e)
        {
            XoaBangTmp();
        }

        private bool TaoBangTam(DevExpress.XtraGrid.GridControl grd, string sBT)
        {
            try
            {
                //sBT = "DD_NS_TMP" + sBT + Commons.Modules.UserName;
                ColumnView view = grd.FocusedView as ColumnView;
                view.CloseEditor();
                view.UpdateCurrentRow();

                if (grd.DataSource == null) return false;
                DataTable dtTmp = new DataTable();
                dtTmp = ((DataTable)grd.DataSource).Copy();
                
                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();

                if (!Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, dtTmp, ""))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTaoTableDDKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                } 
            }
            catch
            { return false; }
            return true;

        }

        private void cboDV_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            #region "Load phong ban"
            if (cboDV.EditValue == null) return;
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPB, Commons.Modules.ObjSystems.MLoadDataPhongBan(1,(cboDV.Text == "" ? "-1": cboDV.EditValue.ToString())), "MS_PB", "TEN_PB", "");
            }
            catch { }
            #endregion
            Commons.Modules.SQLString = "";
            LocDuLieu();
        }

        private void cboPB_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            #region "Load to"
            if (cboDV.EditValue == null) return;
            if (cboPB.EditValue == null) return;
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTo, Commons.Modules.ObjSystems.MLoadDataTo(1, (cboDV.Text == "" ? "-1" : cboDV.EditValue.ToString()), int.Parse((cboPB.Text == "" ? "-1" : cboPB.EditValue.ToString()))), "MS_TO1", "TEN_TO", "");
            }
            catch { }
            #endregion
            Commons.Modules.SQLString = "";
            LocDuLieu();

        }


        private void btnChonNS_Click(object sender, EventArgs e)
        {

            if (Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Month, dtCVTNgay.DateTime, dtCVDNgay.DateTime) > 3)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgVuiLongKhongChonQua3Thang", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmDDNhanLuc frm = new frmDDNhanLuc();
            int iMSo = -1;
            String sSql = "";
            string sBTmpGSTT = "DD_NS_TMPGSTT" + Commons.Modules.UserName; 
            string sBTGSTT = "DD_NS_GSTT" + Commons.Modules.UserName;
            string sBTmpPBT = "DD_NS_TMPPBT" + Commons.Modules.UserName;
            string sBTPBT = "DD_NS_PBT" + Commons.Modules.UserName;
            string sBTmpKHTT = "DD_NS_TMPKHTT" + Commons.Modules.UserName;
            string sBTKHTT = "DD_NS_KHTT" + Commons.Modules.UserName;
            string sBTmpCVVP = "DD_NS_TMPCVVP" + Commons.Modules.UserName; 
            string sBTCVVP = "DD_NS_CVVP" + Commons.Modules.UserName; 
            string sBTDD = "DD_TT_TMP" + Commons.Modules.UserName;
            string sBTNS = "DD_CHART_NS_TMP" + Commons.Modules.UserName;
            string sBTNSLuu = "DD_NS" + Commons.Modules.UserName;
            
            if ( txtID.Text != "-1")
            {
                try
                { iMSo = int.Parse(txtID.Text); }
                catch { }
                frm.iID = iMSo;
                frm.sMsDD = txtMsDD.Text;
                frm.sUserDD = txtUserDD.Text;
                frm.dNgayDD = dtNgayDD.DateTime;

                try
                {
                    frm.dDDTuNgay = Convert.ToDateTime(grvDieuDo.GetFocusedRowCellValue("DD_TN").ToString());
                    frm.dDDDenNgay = Convert.ToDateTime(grvDieuDo.GetFocusedRowCellValue("DD_DN").ToString());
                }
                catch { }
                frm.sBTKHTT = grvDieuDo.GetFocusedRowCellValue("SO_NV_DD").ToString();   // txtNL
                frm.sBTCVVP = grvDieuDo.GetFocusedRowCellValue("SO_GIO_DD").ToString();   // txtGioLV
                frm.sBTDD = grvDieuDo.GetFocusedRowCellValue("HIEU_SUAT_DD").ToString();    // txtHSuat
                frm.sBTNS = grvDieuDo.GetFocusedRowCellValue("SO_PHUT_KHONG_DD").ToString();    //txtSPhutDD


                frm.ShowDialog();
                return;
            }



            DataTable dtTmp = new DataTable();

            if (TaoBangTam(grdGSTT, sBTmpGSTT))
            {
                Commons.Modules.ObjSystems.XoaTable(sBTGSTT);
                sSql = "SELECT CONVERT(INT,ROW_NUMBER() OVER (ORDER BY STT, MS_MAY, MS_TS_GSTT, MS_BO_PHAN, MS_TT, T1.MUC_UU_TIEN )) AS KHOA, STT, MS_MAY, MS_TS_GSTT, MS_BO_PHAN, MS_TT, T1.MUC_UU_TIEN AS MS_UU_TIEN, NGAY_KT AS NGAY_KH, NGAY_KT AS NGAY_TRUOC, CONVERT(DATETIME, DATEADD(DAY, ISNULL(T2.SO_NGAY_PHAI_BD, 0), T1.NGAY_KT)) AS NGAY_SAU, ISNULL(THOI_GIAN,0) AS TG_KH, CONVERT(INT, 1) AS LOAI INTO " + sBTGSTT + " FROM " + sBTmpGSTT + " T1 LEFT OUTER JOIN MUC_UU_TIEN AS T2 ON T1.MUC_UU_TIEN = T2.MS_UU_TIEN ORDER BY STT, MS_MAY, MS_TS_GSTT, MS_BO_PHAN, MS_TT, T1.MUC_UU_TIEN ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
            }
            else return;

            if (TaoBangTam(grdPBT, sBTmpPBT))
            {
                Commons.Modules.ObjSystems.XoaTable(sBTPBT);

                sSql = "SELECT CONVERT(INT, ROW_NUMBER() OVER(ORDER BY NGAY_BD_KH, MS_PHIEU_BAO_TRI, TEN_TINH_TRANG, T2.TEN_UU_TIEN, T1.MS_MAY, TEN_BO_PHAN, MO_TA_CV)) AS KHOA, T1.MS_PHIEU_BAO_TRI, T1.MS_BO_PHAN, T1.MS_CV,T1.MSUT AS MS_UU_TIEN, T1.NGAY_BD_KH AS NGAY_KH, T1.NGAY_BD_KH AS NGAY_TRUOC, CONVERT(DATETIME, DATEADD(DAY, ISNULL(T2.SO_NGAY_PHAI_BD, 0), T1.NGAY_BD_KH)) AS NGAY_SAU, T1.SO_GIO_KH AS TG_KH, CONVERT(INT, 2) AS LOAI INTO " + sBTPBT + " FROM  (SELECT A.*,ISNULL(MS_UU_TIEN,B.MUC_UU_TIEN) AS MSUT FROM " + sBTmpPBT + " A LEFT JOIN MAY B ON A.MS_MAY = B.MS_MAY )  AS T1 LEFT OUTER JOIN MUC_UU_TIEN AS T2 ON T1.MSUT = T2.MS_UU_TIEN ORDER BY NGAY_BD_KH, MS_PHIEU_BAO_TRI, TEN_TINH_TRANG, T2.TEN_UU_TIEN, T1.MS_MAY, TEN_BO_PHAN, MO_TA_CV";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
            }
            else return;


            if (TaoBangTam(grdKHTT, sBTmpKHTT))
            {
                Commons.Modules.ObjSystems.XoaTable(sBTKHTT);
                sSql = "SELECT CONVERT(INT,ROW_NUMBER() OVER (ORDER BY T1.MS_MAY,T1.HANG_MUC_ID,T1.MS_BO_PHAN,T1.MS_CV,T2.TEN_UU_TIEN)) AS KHOA,T1.MS_MAY,T1.HANG_MUC_ID,T1.MS_BO_PHAN,T1.MS_CV,T1.MSUT AS MS_UU_TIEN,T1.NGAY_BD_KH AS NGAY_KH, T1.NGAY_BD_KH AS NGAY_TRUOC, CONVERT(DATETIME, DATEADD(DAY, ISNULL(T2.SO_NGAY_PHAI_BD, 0), T1.NGAY_BD_KH)) AS NGAY_SAU,THOI_GIAN_DU_KIEN AS TG_KH , CONVERT(INT,4) AS LOAI INTO " + sBTKHTT + "  FROM  (SELECT A.*,ISNULL(MS_UU_TIEN,B.MUC_UU_TIEN) AS MSUT FROM " + sBTmpKHTT + " A LEFT JOIN MAY B ON A.MS_MAY = B.MS_MAY ) T1 LEFT OUTER JOIN MUC_UU_TIEN AS T2 ON T1.MSUT = T2.MS_UU_TIEN  ORDER BY T1.MS_MAY,T1.HANG_MUC_ID,T1.MS_BO_PHAN,T1.MS_CV,T2.TEN_UU_TIEN";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

            }
            else return;

            if (TaoBangTam(grdCVVP, sBTmpCVVP))
            {
                Commons.Modules.ObjSystems.XoaTable(sBTCVVP);
                sSql = "SELECT CONVERT(INT,ROW_NUMBER() OVER (ORDER BY T1.MS_CONG_NHAN,T1.NGAY,T1.STT,T1.MS_UU_TIEN )) AS KHOA,T1.MS_CONG_NHAN,T1.NGAY AS NGAY_KH,T1.STT,T1.MS_UU_TIEN, T1.NGAY AS NGAY_TRUOC, CONVERT(DATETIME, DATEADD(DAY, ISNULL(T2.SO_NGAY_PHAI_BD, 0), T1.NGAY)) AS NGAY_SAU,THOI_GIAN_DK AS TG_KH, CONVERT(INT,3) AS LOAI INTO " + sBTCVVP + "  FROM " + sBTmpCVVP + " T1 LEFT OUTER JOIN MUC_UU_TIEN AS T2 ON T1.MS_UU_TIEN = T2.MS_UU_TIEN  ORDER BY T1.MS_CONG_NHAN,T1.NGAY,T1.STT,T1.MS_UU_TIEN ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
            }
            else return;

            Commons.Modules.ObjSystems.XoaTable(sBTDD);
            sSql = "SELECT CONVERT(INT,ROW_NUMBER() OVER (ORDER BY NGAY_KH,MS_UU_TIEN,LOAI )) AS MA_SO, KHOA,NGAY_KH,NGAY_TRUOC,NGAY_SAU,ISNULL(TG_KH,0) AS TG_KH, CONVERT(FLOAT,0) AS SO_NGUOI_DD,NGAY_DD,MS_UU_TIEN, LOAI INTO " + sBTDD + " FROM(SELECT KHOA,NGAY_KH,NGAY_TRUOC,NGAY_SAU,TG_KH, CONVERT(DATETIME, NULL) AS NGAY_DD,MS_UU_TIEN, LOAI FROM " + sBTGSTT + "  UNION SELECT KHOA,NGAY_KH,NGAY_TRUOC,NGAY_SAU,TG_KH, CONVERT(DATETIME, NULL) AS NGAY_DD,MS_UU_TIEN, LOAI FROM " + sBTPBT + "  UNION SELECT KHOA,NGAY_KH,NGAY_TRUOC,NGAY_SAU,TG_KH, CONVERT(DATETIME, NULL) AS NGAY_DD,MS_UU_TIEN, LOAI FROM " + sBTCVVP + "  UNION SELECT KHOA,NGAY_KH,NGAY_TRUOC,NGAY_SAU,TG_KH, CONVERT(DATETIME, NULL) AS NGAY_DD,MS_UU_TIEN, LOAI FROM " + sBTKHTT + " ) T ORDER BY NGAY_KH,MS_UU_TIEN,LOAI";
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                sSql = "SELECT TOP 1 * FROM " + sBTDD;
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuDeDieuDo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuDeDieuDo", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            try
            { iMSo = int.Parse(txtID.Text); }
            catch { }
            frm.iID = iMSo;
            frm.sMsDD = txtMsDD.Text;
            frm.sUserDD = txtUserDD.Text;
            frm.dNgayDD = dtNgayDD.DateTime;

            frm.dDDTuNgay = dtCVTNgay.DateTime;
            frm.dDDDenNgay = dtCVDNgay.DateTime;
            frm.dDDCVTuNgay = dtCVTNgay.DateTime;
            frm.dDDCVDenNgay = dtCVDNgay.DateTime;

            frm.sBTGSTT = sBTGSTT;
            frm.sBTPBT = sBTPBT;
            frm.sBTKHTT = sBTKHTT;
            frm.sBTCVVP = sBTCVVP;
            frm.sBTDD = sBTDD;
            frm.sBTNS = sBTNS;
            frm.sBTNSLuu = sBTNSLuu;
            try
            {
                object row = cboNhomDD.Properties.GetDataSourceRowByKeyValue(cboNhomDD.EditValue);
                if (row != null)
                {
                    string columnValue = ((DataRowView)row)["SN"].ToString();
                    frm.iNhanLuc = int.Parse(columnValue);
                }
            }catch { }
            
            //public double dSO_NV_DD = 0, dSO_GIO_DD = 0, dHIEU_SUAT_DD = 0, dSO_PHUT_KHONG_DD = 0;


            if (frm.ShowDialog() == DialogResult.OK)
            {
                dtTmp = new DataTable();
                dTNgay = frm.dDDTuNgay;
                dDNgay = frm.dDDDenNgay;

                dSO_NV_DD = double.Parse(frm.txtNL.Text);
                dSO_GIO_DD = double.Parse(frm.txtGioLV.Text);
                dHIEU_SUAT_DD = double.Parse(frm.txtHSuat.Text);
                dSO_PHUT_KHONG_DD = double.Parse(frm.txtSPhutDD.Text);

                grvCVVP.ActiveFilter.Clear();
                sSql = "UPDATE " + sBTmpGSTT + " SET NGAY_DD = T1.NGAY_DD, SO_NGUOI_DD = T1.SO_NGUOI_DD FROM " + sBTDD + " AS T1 INNER JOIN " + sBTGSTT + " AS T2 ON T1.KHOA = T2.KHOA AND T1.LOAI = T2.LOAI INNER JOIN " + sBTmpGSTT + " AS T3 ON T2.STT = T3.STT AND T2.MS_MAY = T3.MS_MAY AND T2.MS_TS_GSTT = T3.MS_TS_GSTT AND T2.MS_BO_PHAN = T3.MS_BO_PHAN AND T2.MS_TT = T3.MS_TT ";
                try
                { SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql); }
                catch { }

                sSql = "UPDATE " + sBTmpPBT + " SET NGAY_DD = T1.NGAY_DD, SO_NGUOI_DD = T1.SO_NGUOI_DD FROM " + sBTDD + " AS T1 INNER JOIN " + sBTPBT + " AS T2 ON T1.KHOA = T2.KHOA AND T1.LOAI = T2.LOAI INNER JOIN " + sBTmpPBT + " AS T3 ON T2.MS_PHIEU_BAO_TRI = T3.MS_PHIEU_BAO_TRI AND T2.MS_BO_PHAN = T3.MS_BO_PHAN AND T2.MS_CV = T3.MS_CV ";
                try
                { SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql); }
                catch{ }

                sSql = "UPDATE  " + sBTmpKHTT + "  SET NGAY_DD = T1.NGAY_DD, SO_NGUOI_DD = T1.SO_NGUOI_DD FROM " + sBTDD + " AS T1 INNER JOIN " + sBTKHTT + " AS T2 ON T1.KHOA = T2.KHOA AND T1.LOAI = T2.LOAI INNER JOIN  " + sBTmpKHTT + "  AS T3 ON T2.MS_MAY = T3.MS_MAY AND T2.HANG_MUC_ID = T3.HANG_MUC_ID AND T2.MS_BO_PHAN = T3.MS_BO_PHAN AND T2.MS_CV = T3.MS_CV ";
                try
                { SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql); }
                catch{ }

                sSql = "UPDATE " + sBTmpCVVP + " SET NGAY_DD = T1.NGAY_DD, SO_NGUOI_DD = T1.SO_NGUOI_DD FROM " + sBTDD + " AS T1 INNER JOIN " + sBTCVVP + " AS T2 ON T1.KHOA = T2.KHOA AND T1.LOAI = T2.LOAI INNER JOIN " + sBTmpCVVP + " AS T3 ON T2.MS_CONG_NHAN = T3.MS_CONG_NHAN AND T2.STT = T3.STT ";
                try
                { SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql); }
                catch{ }


                
                #region PBT

                sSql = "SELECT * FROM " + sBTmpPBT;
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));

                foreach (DataRow dr in dtTmp.Rows)
                {
                    int rowHandle = grvPBT.LocateByValue(0, grvPBT.Columns["TK"], dr["TK"]);
                    grvPBT.SetRowCellValue(rowHandle, "NGAY_DD", dr["NGAY_DD"].ToString());
                    grvPBT.SetRowCellValue(rowHandle, "SO_NGUOI_DD", dr["SO_NGUOI_DD"].ToString());

                }
                grvPBT.RefreshData();

                #endregion

                #region KHTT
                dtTmp = new DataTable();
                sSql = "SELECT * FROM " + sBTmpKHTT;
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));

                foreach (DataRow dr in dtTmp.Rows)
                {
                    int rowHandle = grvKHTT.LocateByValue(0, grvKHTT.Columns["TK"], dr["TK"]);
                    grvKHTT.SetRowCellValue(rowHandle, "NGAY_DD", dr["NGAY_DD"].ToString());
                    grvKHTT.SetRowCellValue(rowHandle, "SO_NGUOI_DD", dr["SO_NGUOI_DD"].ToString());

                }
                grvKHTT.RefreshData();

                #endregion

                #region GSTT
                dtTmp = new DataTable();
                sSql = "SELECT * FROM " + sBTmpGSTT;
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));

                foreach (DataRow dr in dtTmp.Rows)
                {
                    int rowHandle = grvGSTT.LocateByValue(0, grvGSTT.Columns["TK"], dr["TK"]);
                    grvGSTT.SetRowCellValue(rowHandle, "NGAY_DD", dr["NGAY_DD"].ToString());
                    grvGSTT.SetRowCellValue(rowHandle, "SO_NGUOI_DD", dr["SO_NGUOI_DD"].ToString());

                }
                grvGSTT.RefreshData();

                #endregion

                #region CVVP
                dtTmp = new DataTable();
                sSql = "SELECT * FROM " + sBTmpCVVP;
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));

                foreach (DataRow dr in dtTmp.Rows)
                {
                    int rowHandle = grvCVVP.LocateByValue(0, grvCVVP.Columns["TK"], dr["TK"]);
                    grvCVVP.SetRowCellValue(rowHandle, "NGAY_DD", dr["NGAY_DD"].ToString());
                    grvCVVP.SetRowCellValue(rowHandle, "SO_NGUOI_DD", dr["SO_NGUOI_DD"].ToString());

                }
                grvCVVP.RefreshData();

                #endregion
            }
        }
}
}
