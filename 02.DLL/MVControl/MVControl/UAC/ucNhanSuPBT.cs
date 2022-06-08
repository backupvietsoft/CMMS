using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons.VS.Classes.Catalogue;
using DevExpress.XtraEditors.Repository;
using Microsoft.ApplicationBlocks.Data;
using MVControl.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Reflection;
using System.Globalization;
using Commons;

namespace MVControl
{
    public partial class ucNhanSuPBT : DevExpress.XtraEditors.XtraUserControl
    {
        public int iTTPBTri { get; set; }
        public string sMsPBT { get; set; }
        public string sMsMay { get; set; }
        public DateTime ngayBDKH { get; set; }
        public DateTime ngayKTKH { get; set; }
        public DateTime denNgayGioHong { get; set; }
        public DateTime tuNgayGioHong { get; set; }

        public Boolean bLoadNS { get; set; } = false;

        public ucNhanSuPBT()
        {
            InitializeComponent();
        }

        public DataRow KeHoachNhanVienFocusedDataRow
        {
            get { return grvKHNhanVien.GetFocusedDataRow(); }
        }

        private delegate void BindDataCongViecPhuNS();
        public void LoadCongViecPhuNS()
        {
            if (grdCVPhuNS.InvokeRequired)
            {
                grdCVPhuNS.Invoke(new BindDataCongViecPhuNS(LoadCongViecPhuNS), null);
            }
            else
            {
                lblCVP.Text = "";
                DataTable dt = new JOBCARD_Controller().get_Congviecphu(sMsPBT);
                Commons.Modules.SQLString = "0Load";
                if (grdCVPhuNS.DataSource == null)
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdCVPhuNS, grvCVPhuNS, dt, false, false, false, true, true, "FrmPhieuBaoTri_New");
                else
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdCVPhuNS, grvCVPhuNS, dt, false, false, false, false, true, "FrmPhieuBaoTri_New");
                Commons.Modules.SQLString = "";

                if (grvCVPhuNS.Columns["STT"].Visible == false) goto jump;

                RepositoryItemDateEdit cboNgay = new RepositoryItemDateEdit();
                cboNgay.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                grvCVPhuNS.Columns["NGAY_HOAN_THANH"].ColumnEdit = cboNgay;
                grvCVPhuNS.Columns["NGAY_HOAN_THANH"].ColumnEdit.NullText = "";
                grvCVPhuNS.Columns["NGAY_HOAN_THANH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvCVPhuNS.Columns["NGAY_HOAN_THANH"].DisplayFormat.FormatString = "dd/MM/yyyy";
                grvCVPhuNS.Columns["NGAY_HOAN_THANH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvCVPhuNS.Columns["NGAY_HOAN_THANH"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";
                grvCVPhuNS.Columns["TEN_CONG_VIEC"].Width = 350;
                grvCVPhuNS.Columns["NGAY_HOAN_THANH"].Width = 150;
                grvCVPhuNS.Columns["SO_GIO_KH"].Width = 150;
                grvCVPhuNS.Columns["SO_GIO_KH"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvCVPhuNS.Columns["STT"].Visible = false;
                grvCVPhuNS.Columns["SO_GIO_KH"].OptionsColumn.ReadOnly = true;
                grvCVPhuNS.Columns["NGAY_HOAN_THANH"].OptionsColumn.ReadOnly = true;


            jump: if (grvCVPhuNS.RowCount < 0)
                {
                    this.grdKHNhanVien.DataSource = System.DBNull.Value;
                    this.btnThemsua.Enabled = false;
                    this.btnCopyNS.Enabled = false;
                    this.btnXoa.Enabled = false;
                    btnHThanhNS.Enabled = false;
                    btnTinhcuasobaotri.Enabled = false;
                }
                grvCVPhuNS_FocusedRowChanged(null, null);

                try
                {
                    if (Commons.Modules.iPhutGioPBT == 1)
                    {
                        grvCVPhuNS.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0";
                        grvCVPhuNS.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        grvCVPhuNS.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT", Commons.Modules.TypeLanguage);
                    }
                    else
                    {
                        grvCVPhuNS.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0.#00";
                        grvCVPhuNS.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        grvCVPhuNS.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO", Commons.Modules.TypeLanguage);
                    }
                }
                catch { }
                try
                {
                    String sSql = "SELECT ISNULL(SUM(SO_GIO_KH), 0) AS SP FROM dbo.PHIEU_BAO_TRI_CV_PHU_TRO WHERE MS_PHIEU_BAO_TRI = N'" + sMsPBT + "' ";
                    sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));

                    string s1;
                    s1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "lblCVC", Commons.Modules.TypeLanguage);
                    lblCVP.Text = s1 + sSql + ". ";

                }
                catch { }
            }
        }
        private delegate void BindDataCongViecChinhNS();

        public void LoadCongViecChinhNS()
        {
            if (grdCVChinhNS.InvokeRequired)
            {
                grdCVChinhNS.Invoke(new BindDataCongViecChinhNS(LoadCongViecChinhNS), null);
            }
            else
            {
                lblCVC.Text = "";
                DataTable dt = new JOBCARD_Controller().get_Congviecchinh(sMsPBT, Commons.Modules.UserName);
                dt.Columns["H_THANH"].ReadOnly = false;
                Commons.Modules.SQLString = "0Load";
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCVChinhNS, grvCVChinhNS, dt, false, false, false, false, true, "FrmPhieuBaoTri_New");
                Commons.Modules.SQLString = "";

                if (grvCVChinhNS.Columns["MS_CV"].Visible == false) goto JUMP;
                grvCVChinhNS.OptionsView.RowAutoHeight = true;
                RepositoryItemMemoEdit meno = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                meno.WordWrap = true;
                meno.AutoHeight = true;
                meno.BeginInit();
                grvCVChinhNS.Columns["TEN_BO_PHAN"].ColumnEdit = meno;
                grdCVChinhNS.RepositoryItems.Add(meno);

                RepositoryItemDateEdit cboNgay = new RepositoryItemDateEdit();
                cboNgay.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                grvCVChinhNS.Columns["NGAY_HOAN_THANH"].ColumnEdit = cboNgay;
                grvCVChinhNS.Columns["NGAY_HOAN_THANH"].ColumnEdit.NullText = "";
                grvCVChinhNS.Columns["NGAY_HOAN_THANH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvCVChinhNS.Columns["NGAY_HOAN_THANH"].DisplayFormat.FormatString = "dd/MM/yyyy";
                grvCVChinhNS.Columns["NGAY_HOAN_THANH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvCVChinhNS.Columns["NGAY_HOAN_THANH"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";
                grvCVChinhNS.Columns["MS_MAY"].Visible = false;
                grvCVChinhNS.Columns["STT_CT"].Visible = false;
                grvCVChinhNS.Columns["MS_BO_PHAN"].Visible = false;
                grvCVChinhNS.Columns["TEN_LOAI_CV"].Visible = false;
                grvCVChinhNS.Columns["SO_GIO_KH"].Width = 80;
                grvCVChinhNS.Columns["TEN_BO_PHAN"].Width = 150;
                grvCVChinhNS.Columns["TEN_LOAI_CV"].Width = 150;
                grvCVChinhNS.Columns["MO_TA_CV"].Width = 250;
                grvCVChinhNS.Columns["TEN_LOAI_CV"].Width = 150;
                grvCVChinhNS.Columns["MO_TA_CV"].Width = 250;
                grvCVChinhNS.Columns["NGAY_HOAN_THANH"].Width = 120;
                grvCVChinhNS.Columns["NGAY_HOAN_THANH"].OptionsColumn.ReadOnly = true;
                grvCVChinhNS.Columns["DANH_GIA"].OptionsColumn.ReadOnly = true;
                grvCVChinhNS.Columns["PT_HOAN_THANH"].OptionsColumn.ReadOnly = true;
                grvCVChinhNS.Columns["H_THANH"].OptionsColumn.ReadOnly = true;
                grvCVChinhNS.Columns["DANH_GIA"].Width = 300;
                grvCVChinhNS.Columns["SO_GIO_KH"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvCVChinhNS.Columns["PT_HOAN_THANH"].DisplayFormat.FormatString = "N2";
                grvCVChinhNS.Columns["PT_HOAN_THANH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvCVChinhNS.Columns["PT_HOAN_THANH"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvCVChinhNS.Columns["MO_TA_CV"].OptionsColumn.ReadOnly = true;
                grvCVChinhNS.Columns["TEN_BO_PHAN"].OptionsColumn.ReadOnly = true;
                grvCVChinhNS.Columns["SO_GIO_KH"].OptionsColumn.ReadOnly = true;
                grvCVChinhNS.Columns["TEN_LOAI_CV"].OptionsColumn.ReadOnly = true;
                grvCVChinhNS.Columns["NGAY_HOAN_THANH"].OptionsColumn.ReadOnly = true;
                grvCVChinhNS.Columns["MS_CV"].Visible = false;
            JUMP:
                if (grvCVChinhNS.RowCount < 0)
                {
                    grdKHNhanVien.DataSource = System.DBNull.Value;
                    btnThemsua.Enabled = false;
                    btnCopyNS.Enabled = false;
                    btnXoa.Enabled = false;
                    btnHThanhNS.Enabled = false;
                    btnTinhcuasobaotri.Enabled = false;
                }
                grvCVChinhNS_FocusedRowChanged(null, null);





                //iPhutGioPBT =          PHUT_GIO_PBT: Định nghĩa đơn ví tính là giờ hay phút (0 - dùng giờ, 1 dùng phút )
                try
                {
                    if (Commons.Modules.iPhutGioPBT == 1)
                    {
                        grvCVChinhNS.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0";
                        grvCVChinhNS.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        grvCVChinhNS.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT", Commons.Modules.TypeLanguage);
                    }
                    else
                    {
                        grvCVChinhNS.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0.#00";
                        grvCVChinhNS.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                        grvCVChinhNS.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO", Commons.Modules.TypeLanguage);
                    }
                }
                catch { }


            }
            try
            {
                String sSql = "SELECT ISNULL(SUM(SO_GIO_KH), 0) AS SP FROM dbo.PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI = N'" + sMsPBT + "' ";
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                string s1;

                s1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "lblCVC", Commons.Modules.TypeLanguage);
                lblCVC.Text = s1 + sSql + ". ";
            }
            catch { }

        }

        public void KiemLoadCV()
        {
            // = 0 la co nhan su theo cong viec
            // = 1 la co nhan su khong cong viec
            // = null chua co nhap 0 dau
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT DISTINCT 0 AS LOAI, MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU WHERE MS_PHIEU_BAO_TRI = N'" + sMsPBT + "' UNION SELECT DISTINCT 0 AS LOAI, MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI = N'" + sMsPBT + "' UNION  SELECT DISTINCT 1 AS LOAI, MS_PHIEU_BAO_TRI FROM PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI = N'" + sMsPBT + "'"));
            bLoadNS = true;
            if (dtTmp.Rows.Count > 0)
            {
                if (dtTmp.Rows[0][0].ToString() == "0") optOption.SelectedIndex = 0; else optOption.SelectedIndex = 1;
                optOption.Enabled = false;
            }
            else
            {
                optOption.SelectedIndex = 0;
                optOption.Enabled = true;
            }
            bLoadNS = false;
            optOption_SelectedIndexChanged(null, null);
        }

        private void grvCVChinhNS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                BindDataKeHoachNhanSu();
                LoadLuoiSoGio();
            }
            catch { }
        }

        DataTable TBNhanVien = new DataTable();
        DataTable dtNhanSuKeHoachTMP = new DataTable();
        private delegate void BindDataKeHoachNS();

        public void BindDataKeHoachNhanSu()
        {
            if (bLoadNS) return;
            if (grdKHNhanVien.InvokeRequired)
            {
                grdKHNhanVien.Invoke(new BindDataKeHoachNS(BindDataKeHoachNhanSu), null);
            }
            else
            {
                JOBCARD_Controller objcontroller = new JOBCARD_Controller();
                try
                {
                    lblKH.Text = "";
                    grdKHNhanVien.DataSource = null;
                }
                catch
                {
                }
                TBNhanVien = new DataTable();
                if (tabCVNhanSu.SelectedTabPageIndex == 0)
                {
                    if (btnGhi.Visible == true)
                    {
                        dtNhanSuKeHoachTMP.DefaultView.RowFilter = "MS_CV = '" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"] + "' AND MS_BO_PHAN = '" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"] + "'";
                    }
                    else
                    {
                        try
                        {
                            TBNhanVien = objcontroller.get_Kehoachnhanvien(sMsPBT, Convert.ToInt32(grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString()), grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), 0);
                        }
                        catch
                        {
                            TBNhanVien = objcontroller.get_Kehoachnhanvien(sMsPBT, -1, "-1", 0);
                        }
                        try
                        {
                            TBNhanVien.Columns["TEN_CONG_NHAN"].ReadOnly = false;
                            TBNhanVien.Columns["TU_GIO"].ReadOnly = false;
                            TBNhanVien.Columns["THUE_NGOAI"].ReadOnly = false;
                            TBNhanVien.Columns["DEN_GIO"].ReadOnly = false;
                            TBNhanVien.Columns["NGAY"].ReadOnly = false;
                            TBNhanVien.Columns["DEN_NGAY"].ReadOnly = false;
                            TBNhanVien.Columns["TU_GIO_KH"].ReadOnly = false;
                            TBNhanVien.Columns["DEN_GIO_KH"].ReadOnly = false;
                            TBNhanVien.Columns["NGAY_KH"].ReadOnly = false;
                            TBNhanVien.Columns["DEN_NGAY_KH"].ReadOnly = false;
                        }
                        catch { }
                    }

                    if ((btnGhi.Visible == true))
                    {
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHNhanVien, grvKHNhanVien, dtNhanSuKeHoachTMP.DefaultView.ToTable().Copy(), true, true, true, false, true, "frmPhieuBaoTri_New");
                        grvKHNhanVien.Columns["TEN_CONG_NHAN"].OptionsColumn.AllowEdit = false;
                        grvKHNhanVien.Columns["MS_CV"].Visible = false;
                        grvKHNhanVien.Columns["MS_BO_PHAN"].Visible = false;
                    }
                    else
                    {
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHNhanVien, grvKHNhanVien, TBNhanVien.Copy(), false, true, true, false, true, "frmPhieuBaoTri_New");
                    }
                    grvKHNhanVien.Columns["MS_CN"].Visible = false;
                    grvKHNhanVien.Columns["THUE_NGOAI"].Visible = false;
                    grvKHNhanVien.Columns["HOAN_THANH"].Visible = false;
                    grvKHNhanVien.Columns["TEN_CONG_NHAN"].MinWidth = 180;
                    grvKHNhanVien.Columns["THUE_NGOAI"].MinWidth = 80;
                    grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width = grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width - 20;
                    grvKHNhanVien.Columns["MS_CONG_NHAN"].Visible = false;
                    grvKHNhanVien.Columns["STT"].Visible = false;
                }
                else
                {
                    if ((btnGhi.Visible == true))
                    {
                        dtNhanSuKeHoachTMP.DefaultView.RowFilter = "MS_CV = '" + grvCVPhuNS.GetFocusedDataRow()["STT"] + "'";
                    }
                    else
                    {
                        try
                        {
                            TBNhanVien = objcontroller.get_Kehoachnhanvienphu(sMsPBT, Convert.ToInt32(grvCVPhuNS.GetFocusedDataRow()["STT"].ToString()), 0);
                        }
                        catch
                        {
                            TBNhanVien = objcontroller.get_Kehoachnhanvienphu(sMsPBT, -1, 0);
                        }
                    }
                    TBNhanVien.Columns["TEN_CONG_NHAN"].ReadOnly = false;
                    TBNhanVien.Columns["TU_GIO"].ReadOnly = false;
                    TBNhanVien.Columns["NGAY"].ReadOnly = false;
                    TBNhanVien.Columns["DEN_NGAY"].ReadOnly = false;
                    TBNhanVien.Columns["THUE_NGOAI"].ReadOnly = false;
                    TBNhanVien.Columns["DEN_GIO"].ReadOnly = false;
                    TBNhanVien.Columns["TU_GIO_KH"].ReadOnly = false;
                    TBNhanVien.Columns["DEN_GIO_KH"].ReadOnly = false;
                    TBNhanVien.Columns["NGAY_KH"].ReadOnly = false;
                    TBNhanVien.Columns["DEN_NGAY_KH"].ReadOnly = false;
                    if (btnGhi.Visible == true)
                    {
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHNhanVien, grvKHNhanVien, dtNhanSuKeHoachTMP.DefaultView.ToTable().Copy(), true, true, true, false, false, "frmPhieuBaoTri_New");
                        grvKHNhanVien.Columns["TEN_CONG_NHAN"].OptionsColumn.AllowEdit = false;
                        grvKHNhanVien.Columns["MS_CV"].Visible = false;
                        grvKHNhanVien.Columns["MS_BO_PHAN"].Visible = false;
                    }
                    else
                    {
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHNhanVien, grvKHNhanVien, TBNhanVien.Copy(), false, true, true, false, true, "frmPhieuBaoTri_New");
                    }
                    try
                    {
                        grvKHNhanVien.Columns["ID_STT"].Visible = false;
                    }
                    catch
                    {
                    }
                    grvKHNhanVien.Columns["MS_CN"].Visible = false;
                    grvKHNhanVien.Columns["THUE_NGOAI"].Visible = false;
                    grvKHNhanVien.Columns["HOAN_THANH"].Visible = false;
                    grvKHNhanVien.Columns["TEN_CONG_NHAN"].MinWidth = 180;
                    grvKHNhanVien.Columns["THUE_NGOAI"].MinWidth = 80;
                    grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width = grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width - 20;
                    grvKHNhanVien.Columns["MS_CONG_NHAN"].Visible = false;
                    LockButtonNS();
                }
                try
                {
                    RepositoryItemTimeEdit cboTuGio = new RepositoryItemTimeEdit();
                    RepositoryItemTimeEdit cboDenGio = new RepositoryItemTimeEdit();
                    RepositoryItemDateEdit cboDenNgay = new RepositoryItemDateEdit();
                    RepositoryItemDateEdit cboNgay = new RepositoryItemDateEdit();
                    cboTuGio.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    cboDenGio.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    cboDenNgay.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    cboNgay.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    grvKHNhanVien.Columns["NGAY"].ColumnEdit = cboNgay;
                    grvKHNhanVien.Columns["TU_GIO"].ColumnEdit = cboTuGio;
                    grvKHNhanVien.Columns["DEN_GIO"].ColumnEdit = cboDenGio;
                    grvKHNhanVien.Columns["DEN_NGAY"].ColumnEdit = cboDenNgay;
                    grvKHNhanVien.Columns["NGAY"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["TU_GIO"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["DEN_GIO"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["DEN_NGAY"].ColumnEdit.NullText = "";

                    grvKHNhanVien.Columns["TU_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";

                    grvKHNhanVien.Columns["TU_GIO"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO"].ColumnEdit.EditFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO"].ColumnEdit.EditFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";

                    grvKHNhanVien.Columns["NGAY_KH"].ColumnEdit = cboNgay;
                    grvKHNhanVien.Columns["TU_GIO_KH"].ColumnEdit = cboTuGio;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].ColumnEdit = cboDenGio;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].ColumnEdit = cboDenNgay;
                    grvKHNhanVien.Columns["NGAY_KH"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["TU_GIO_KH"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["DEN_GIO_KH"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].ColumnEdit.NullText = "";

                    grvKHNhanVien.Columns["TU_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO_KH"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO_KH"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].DisplayFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY_KH"].DisplayFormat.FormatString = "dd/MM/yyyy";

                    grvKHNhanVien.Columns["TU_GIO_KH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY_KH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO_KH"].ColumnEdit.EditFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO_KH"].ColumnEdit.EditFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY_KH"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
                    LoadLuoiSoGio();
                }
                catch
                {
                }

                if (optTrangThai.SelectedIndex == 0)
                {
                    grvKHNhanVien.Columns["NGAY_KH"].Visible = true;
                    grvKHNhanVien.Columns["TU_GIO_KH"].Visible = true;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = true;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = true;
                    grvKHNhanVien.Columns["TONG_GIO_KH"].Visible = true;

                    grvKHNhanVien.Columns["SO_GIO"].Visible = false;
                    grvKHNhanVien.Columns["NGAY"].Visible = false;
                    grvKHNhanVien.Columns["TU_GIO"].Visible = false;
                    grvKHNhanVien.Columns["DEN_GIO"].Visible = false;
                    grvKHNhanVien.Columns["DEN_NGAY"].Visible = false;
                }
                else
                {
                    grvKHNhanVien.Columns["NGAY"].Visible = true;
                    grvKHNhanVien.Columns["TU_GIO"].Visible = true;
                    grvKHNhanVien.Columns["DEN_GIO"].Visible = true;
                    grvKHNhanVien.Columns["DEN_NGAY"].Visible = true;
                    grvKHNhanVien.Columns["SO_GIO"].Visible = true;

                    grvKHNhanVien.Columns["NGAY_KH"].Visible = false;
                    grvKHNhanVien.Columns["TU_GIO_KH"].Visible = false;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = false;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = false;
                    grvKHNhanVien.Columns["TONG_GIO_KH"].Visible = false;
                }

                if (Commons.Modules.PermisString.Equals("Read only")) return;


                if (tabCVNhanSu.SelectedTabPageIndex == 0)
                {
                    try
                    {
                        if (iTTPBTri < 4)
                        {
                            btnThemsua.Enabled = true;
                            if (tabCVNhanSu.SelectedTabPageIndex == 0) btnCopyNS.Enabled = true; else btnCopyNS.Enabled = false;
                            btnXoa.Enabled = true;
                            btnHThanhNS.Enabled = true;
                            btnTinhcuasobaotri.Enabled = true;
                            if (iTTPBTri == 3)
                            {
                                btnHThanhNS.Enabled = false;
                            }
                        }
                        else
                        {
                            btnThemsua.Enabled = false;
                            btnCopyNS.Enabled = false;
                            btnXoa.Enabled = false;
                            btnHThanhNS.Enabled = false;
                            btnTinhcuasobaotri.Enabled = false;
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        if (iTTPBTri < 4)
                        {
                            btnThemsua.Enabled = true;
                            if (tabCVNhanSu.SelectedTabPageIndex == 0) btnCopyNS.Enabled = true; else btnCopyNS.Enabled = false;
                            btnXoa.Enabled = true;
                            btnHThanhNS.Enabled = true;
                            btnTinhcuasobaotri.Enabled = true;
                            if (iTTPBTri == 3)
                            {
                                btnHThanhNS.Enabled = false;
                            }
                        }
                        else
                        {
                            btnThemsua.Enabled = false;
                            btnCopyNS.Enabled = false;
                            btnXoa.Enabled = false;
                            btnHThanhNS.Enabled = false;
                            btnTinhcuasobaotri.Enabled = false;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            LLB();

        }
        private void LLB()
        {

            try
            {
                String sTT, sKH, sSql;
                if (tabCVNhanSu.SelectedTabPageIndex == 0) sSql = "PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET"; else sSql = "PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO";


                sSql = "SELECT ISNULL(SUM(SO_GIO), 0) AS SG_TT FROM dbo." + sSql + " WHERE MS_PHIEU_BAO_TRI = N'" + sMsPBT + "' ";
                sTT = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));

                if (tabCVNhanSu.SelectedTabPageIndex == 0) sSql = "PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET"; else sSql = "PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO";
                sSql = "SELECT ISNULL(SUM(TONG_GIO_KH), 0) AS SG_KH FROM dbo." + sSql + " WHERE MS_PHIEU_BAO_TRI = N'" + sMsPBT + "' ";
                sKH = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));

                string s1, s2;

                s1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "sTongKH", Commons.Modules.TypeLanguage);

                s2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "sTongTT", Commons.Modules.TypeLanguage);

                //lblKH.Text = "Tổng TG kế hoạch : " + sKH + ". Tổng TG thực tế : " + sTT + ". ";
                lblKH.Text = s1 + sKH + s2 + sTT + ". ";

            }
            catch { }
        }
        private void LoadLuoiSoGio()
        {

            try
            {
                //iPBTTheoGio = PBT_THEO_GIO: Định nghĩa cách nhập
                //PBT_THEO_GIO=0 Nhập từ ngày, đến ngày, từ giờ đến giờ , tính ra số giờ 
                //PBT_THEO_GIO=1 Nhập từ ngày, đến ngày, từ giờ đến giờ nhưng không tính số giờ tự động, số giờ có thể khác từ giờ - đến giờ  
                //PBT_THEO_GIO=2 Chỉ nhập số giờ hay phút 

                if (btnGhi.Visible == true)
                {
                    grvKHNhanVien.Columns["SO_GIO"].OptionsColumn.AllowEdit = Commons.Modules.iPBTTheoGio == 0 ? false : true;
                    grvKHNhanVien.Columns["TONG_GIO_KH"].OptionsColumn.AllowEdit = Commons.Modules.iPBTTheoGio == 0 ? false : true;

                }

                //if (Commons.Modules.iPBTTheoGio == 2)
                //{
                //    grvKHNhanVien.Columns["NGAY"].Visible = false;
                //    grvKHNhanVien.Columns["TU_GIO"].Visible = false;
                //    grvKHNhanVien.Columns["DEN_GIO"].Visible = false;
                //    grvKHNhanVien.Columns["DEN_NGAY"].Visible = false;
                //    grvKHNhanVien.Columns["NGAY_KH"].Visible = false;
                //    grvKHNhanVien.Columns["TU_GIO_KH"].Visible = false;
                //    grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = false;
                //    grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = false;
                //    grvKHNhanVien.Columns["SO_GIO"].Width = grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width / 2;
                //    grvKHNhanVien.Columns["TONG_GIO_KH"].Width = grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width / 2;
                //}
            }
            catch (Exception ex)
            {
            }
            LoadSoGioSoPhut();

        }

        private void LockButtonNS()
        {
            this.btnThemsua.Enabled = true;
            if (tabCVNhanSu.SelectedTabPageIndex == 0) btnCopyNS.Enabled = true; else btnCopyNS.Enabled = false;
            if (this.tabControl.SelectedTabPageIndex == 0)
            {
                if (tabCVNhanSu.SelectedTabPageIndex == 0)
                {
                    if (this.grvCVChinhNS.RowCount > 0)
                    {
                        if (!string.IsNullOrEmpty(grvCVChinhNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString()))
                        {
                            this.btnThemsua.Enabled = false;
                            this.btnCopyNS.Enabled = false;
                            this.btnXoa.Enabled = false;
                            btnHThanhNS.Enabled = false;
                            btnTinhcuasobaotri.Enabled = false;
                            return;
                        }
                        if (this.grvKHNhanVien.RowCount > 0)
                        {
                            this.btnXoa.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.btnXoa.Enabled = false;
                            return;
                        }
                    }
                    else
                    {
                        this.btnThemsua.Enabled = false;
                        this.btnCopyNS.Enabled = false;
                        this.btnXoa.Enabled = false;
                        btnHThanhNS.Enabled = false;
                        btnTinhcuasobaotri.Enabled = false;
                        return;
                    }
                }
                else
                {
                    if (this.grvCVPhuNS.RowCount > 0)
                    {
                        if (!string.IsNullOrEmpty(grvCVPhuNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString()))
                        {
                            this.btnThemsua.Enabled = false;
                            this.btnCopyNS.Enabled = false;
                            this.btnXoa.Enabled = false;
                            btnHThanhNS.Enabled = false;
                            btnTinhcuasobaotri.Enabled = false;
                            return;
                        }
                        if (this.grvKHNhanVien.RowCount > 0)
                        {
                            this.btnXoa.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.btnXoa.Enabled = false;
                            return;
                        }
                    }
                    else
                    {
                        btnThemsua.Enabled = false;
                        btnCopyNS.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHThanhNS.Enabled = false;
                        btnTinhcuasobaotri.Enabled = false;
                        return;
                    }
                }
            }
            else
            {
                btnXoa.Enabled = false;
                btnThemsua.Enabled = false;
                btnCopyNS.Enabled = false;
                btnHThanhNS.Enabled = false;
                btnTinhcuasobaotri.Enabled = false;
            }
        }

        private void grvCVPhuNS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            BindDataKeHoachNhanSu();
        }

        private void tabCVNhanSu_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabCVNhanSu.SelectedTabPageIndex == 0)
            {
                LoadCongViecChinhNS();
            }
            else if (tabCVNhanSu.SelectedTabPageIndex == 1)
            {
                LoadCongViecPhuNS();
            }
        }

        private void tabCVNhanSu_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (btnGhi.Visible)
                e.Cancel = true;
        }

        private bool Check()
        {
            string str = "";
            if (optOption.SelectedIndex == 0)
            {
                if (tabCVNhanSu.SelectedTabPageIndex == 0)
                {
                    if (grvCVChinhNS.RowCount == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (grvCVPhuNS.RowCount == 0)
                    {
                        return false;
                    }
                }
                str = $"SELECT * FROM PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI = '{ sMsPBT }'";
                if (SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str).HasRows)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "DaNhapDuLieuNhanSuKhongTheoCongViec", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                str = $"SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU WHERE MS_PHIEU_BAO_TRI = '{ sMsPBT }'";
                if (SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str).HasRows)
                {
                    goto Result;
                }
                str = $"SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE MS_PHIEU_BAO_TRI = '{ sMsPBT }'";
                if (SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str).HasRows)
                {
                    goto Result;
                }
            }
            return true;
        Result:
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "DaNhapDuLieuNhanSuTheoCongViec", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public void ThemNhanSuPBT()
        {
            if (!Check()) return;


            string str = "";
            try
            {
                str = "DROP TABLE tmpPhanBoNhanVien" + Commons.Modules.UserName;
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }
            str = "CREATE TABLE tmpPhanBoNhanVien" + Commons.Modules.UserName + " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV INT, " + " MS_BO_PHAN NVARCHAR(50), MS_CONG_NHAN NVARCHAR(9), TU_GIO NVARCHAR(8), TU_NGAY NVARCHAR(10),DEN_GIO NVARCHAR(8), DEN_NGAY NVARCHAR(10),DONG INT, ID_STT INT, TU_GIO_KH NVARCHAR(8), NGAY_KH NVARCHAR(10),DEN_GIO_KH NVARCHAR(8), DEN_NGAY_KH NVARCHAR(10))";
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

            if (tabCVNhanSu.SelectedTabPageIndex == 0)
            {
                str = "INSERT INTO tmpPhanBoNhanVien" + Commons.Modules.UserName + "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_CONG_NHAN,TU_GIO,TU_NGAY,DEN_GIO,DEN_NGAY, ID_STT, TU_GIO_KH,NGAY_KH,DEN_GIO_KH,DEN_NGAY_KH)  " + " SELECT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_CONG_NHAN,CONVERT(NVARCHAR(5),TU_GIO,114), " + " CONVERT(NVARCHAR(10),NGAY,103),CONVERT(NVARCHAR(5),DEN_GIO,114),CONVERT(NVARCHAR(10),DEN_NGAY ,103), STT, CONVERT(NVARCHAR(5),TU_GIO_KH,114),CONVERT(NVARCHAR(10),NGAY_KH,103),CONVERT(NVARCHAR(5),DEN_GIO_KH,114),CONVERT(NVARCHAR(10),DEN_NGAY_KH ,103) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "'";
            }
            else
            {
                str = "INSERT INTO tmpPhanBoNhanVien" + Commons.Modules.UserName + "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_CONG_NHAN,TU_GIO,TU_NGAY,DEN_GIO,DEN_NGAY, ID_STT, TU_GIO_KH,NGAY_KH,DEN_GIO_KH,DEN_NGAY_KH)  " + " SELECT MS_PHIEU_BAO_TRI,STT as MS_CV,NULL,MS_CONG_NHAN,CONVERT(NVARCHAR(5),TU_GIO,114),CONVERT(NVARCHAR(10),NGAY,103), " + " CONVERT(NVARCHAR(5),DEN_GIO,114),CONVERT(NVARCHAR(10),DEN_NGAY ,103), ID_STT , CONVERT(NVARCHAR(5),TU_GIO_KH,114),CONVERT(NVARCHAR(10),NGAY_KH,103),CONVERT(NVARCHAR(5),DEN_GIO_KH,114),CONVERT(NVARCHAR(10),DEN_NGAY_KH ,103) FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO " + " WHERE MS_PHIEU_BAO_TRI= '" + sMsPBT + "'";
            }
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            if (optOption.SelectedIndex == 0)
            {
                if (tabCVNhanSu.SelectedTabPageIndex == 0)
                {
                    dtNhanSuKeHoachTMP = new DataTable();
                    dtNhanSuKeHoachTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getALL_Kehoachnhanvienchinh", sMsPBT));
                }
                else
                {
                    dtNhanSuKeHoachTMP = new DataTable();
                    dtNhanSuKeHoachTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getALL_Kehoachnhanvienphu", sMsPBT));
                }
            }
            else
            {
                dtNhanSuKeHoachTMP = new DataTable();
                dtNhanSuKeHoachTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetStaffByWorkOrder", sMsPBT));
            }
            dtNhanSuKeHoachTMP.Columns["NGAY"].ReadOnly = false;
            dtNhanSuKeHoachTMP.Columns["TU_GIO"].ReadOnly = false;
            dtNhanSuKeHoachTMP.Columns["DEN_NGAY"].ReadOnly = false;
            dtNhanSuKeHoachTMP.Columns["DEN_GIO"].ReadOnly = false;
            dtNhanSuKeHoachTMP.Columns["NGAY_KH"].ReadOnly = false;
            dtNhanSuKeHoachTMP.Columns["TU_GIO_KH"].ReadOnly = false;
            dtNhanSuKeHoachTMP.Columns["DEN_NGAY_KH"].ReadOnly = false;
            dtNhanSuKeHoachTMP.Columns["DEN_GIO_KH"].ReadOnly = false;
            dtNhanSuKeHoachTMP.Columns["SO_GIO"].ReadOnly = false;
            dtNhanSuKeHoachTMP.Columns["TONG_GIO_KH"].ReadOnly = false;

            dtNhanSuKeHoachTMP.Columns["NGAY"].AllowDBNull = true;
            dtNhanSuKeHoachTMP.Columns["TU_GIO"].AllowDBNull = true;
            dtNhanSuKeHoachTMP.Columns["DEN_NGAY"].AllowDBNull = true;
            dtNhanSuKeHoachTMP.Columns["DEN_GIO"].AllowDBNull = true;
            dtNhanSuKeHoachTMP.Columns["NGAY_KH"].AllowDBNull = true;
            dtNhanSuKeHoachTMP.Columns["TU_GIO_KH"].AllowDBNull = true;
            dtNhanSuKeHoachTMP.Columns["DEN_NGAY_KH"].AllowDBNull = true;
            dtNhanSuKeHoachTMP.Columns["DEN_GIO_KH"].AllowDBNull = true;
            dtNhanSuKeHoachTMP.Columns["SO_GIO"].AllowDBNull = true;
            dtNhanSuKeHoachTMP.Columns["TONG_GIO_KH"].AllowDBNull = true;


            VisibleButton(false);
            if (tabCVNhanSu.SelectedTabPageIndex == 1)
            {
                try
                {
                    grvCVPhuNS.OptionsBehavior.Editable = true;
                    grvCVPhuNS.Columns["NGAY_HOAN_THANH"].OptionsColumn.ReadOnly = false;

                }
                catch { }
            }
            else
            {
                try
                {
                    grvCVChinhNS.OptionsBehavior.Editable = true;
                    grvCVChinhNS.Columns["NGAY_HOAN_THANH"].OptionsColumn.ReadOnly = false;
                    grvCVChinhNS.Columns["H_THANH"].OptionsColumn.ReadOnly = false;
                    grvCVChinhNS.Columns["DANH_GIA"].OptionsColumn.ReadOnly = false;
                    grvCVChinhNS.Columns["PT_HOAN_THANH"].OptionsColumn.ReadOnly = false;
                }
                catch { }

            }
            grvKHNhanVien.OptionsBehavior.Editable = true;
            grvKHNhanVien.Columns["TEN_CONG_NHAN"].OptionsColumn.AllowEdit = false;
            LoadLuoiSoGio();
            CreateMenuThemNgayGioNhanSu(grdKHNhanVien);
            optTrangThai_SelectedIndexChanged(null, null);
        }

        public void VisibleButton(bool bln)
        {
            btnThemsua.Visible = bln;
            btnCopyNS.Visible = bln;
            btnXoa.Visible = bln;
            btnThoat.Visible = bln;
            BtnChonNV.Visible = !bln;
            btnGhi.Visible = !bln;
            btnKhongghi.Visible = !bln;
            //btnCapnhatthoigiancongviec.Visible = !bln;
            btnHThanhNS.Visible = bln;
        }

        private void BtnChonNV_Click(object sender, EventArgs e)
        {
            try
            {
                frmChonNhanSuChoPBT frm = new frmChonNhanSuChoPBT();
                string sBTNVien = "tmpNhanVien" + Commons.Modules.UserName;
                frm.sBTNVien = sBTNVien;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string str = "";
                    str = "SELECT MS_CONG_NHAN, HO_TEN AS HO_TEN, THUE_NGOAI FROM " + sBTNVien;
                    DataTable tb = new DataTable();
                    tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables[0];
                    int iSTT = 0;

                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        DataRow dr = default(DataRow);
                        if (optOption.SelectedIndex == 1 && dtNhanSuKeHoachTMP.Select().AsEnumerable().Any(p => p["MS_CONG_NHAN"].ToString() == tb.Rows[i]["MS_CONG_NHAN"].ToString())) continue;

                        dr = dtNhanSuKeHoachTMP.NewRow();
                        dr["MS_CONG_NHAN"] = tb.Rows[i]["MS_CONG_NHAN"];
                        dr["MS_CN"] = tb.Rows[i]["MS_CONG_NHAN"];
                        dr["TEN_CONG_NHAN"] = tb.Rows[i]["HO_TEN"].ToString().Replace("   ", "'");
                        dr["HOAN_THANH"] = 0;
                        dr["THUE_NGOAI"] = tb.Rows[i]["THUE_NGOAI"];
                        if (Commons.Modules.sPrivate == "BARIA" || Commons.Modules.sPrivate == "VINHHOAN")
                        {
                            dr["NGAY"] = ngayBDKH.Date;
                            dr["TU_GIO"] = "08:00";
                            dr["DEN_GIO"] = "17:00";
                            dr["DEN_NGAY"] = ngayKTKH.Date;
                            dr["SO_GIO"] = 9;
                            dr["NGAY_KH"] = ngayBDKH.Date;
                            dr["TU_GIO_KH"] = "08:00";
                            dr["DEN_GIO_KH"] = "17:00";
                            dr["DEN_NGAY_KH"] = ngayKTKH.Date;
                            dr["TONG_GIO_KH"] = 9;
                        }
                        else
                        {
                            if (tuNgayGioHong.Date.ToString("yyyy").Equals("1900"))
                            {
                                dr["NGAY"] = DBNull.Value;
                                dr["TU_GIO"] = DBNull.Value;
                                dr["NGAY_KH"] = DBNull.Value;
                                dr["TU_GIO_KH"] = DBNull.Value;
                            }
                            else
                            {
                                dr["NGAY"] = tuNgayGioHong.Date.ToString("yyyy/MM/dd");
                                dr["TU_GIO"] = tuNgayGioHong.ToString("HH:mm");
                                dr["NGAY_KH"] = tuNgayGioHong.Date.ToString("yyyy/MM/dd");
                                dr["TU_GIO_KH"] = tuNgayGioHong.ToString("HH:mm");
                            }
                            if (denNgayGioHong.Date.ToString("yyyy").Equals("1900"))
                            {
                                dr["DEN_NGAY"] = DBNull.Value;
                                dr["DEN_GIO"] = DBNull.Value;
                                dr["DEN_GIO_KH"] = DBNull.Value;
                                dr["DEN_NGAY_KH"] = DBNull.Value;
                            }
                            else
                            {
                                dr["DEN_NGAY"] = denNgayGioHong.Date.ToString("yyyy/MM/dd");
                                dr["DEN_GIO"] = denNgayGioHong.ToString("HH:mm");
                                dr["DEN_NGAY_KH"] = denNgayGioHong.Date.ToString("yyyy/MM/dd");
                                dr["DEN_GIO_KH"] = denNgayGioHong.ToString("HH:mm");
                            }
                        }
                        if (Commons.Modules.sPrivate == "REMINGTON")
                        {
                            //ngayBDKH
                            dr["NGAY"] = ngayBDKH.Date.ToString("yyyy/MM/dd");
                            dr["NGAY_KH"] = ngayBDKH.Date.ToString("yyyy/MM/dd");


                            dr["DEN_NGAY"] = ngayKTKH.Date.ToString("yyyy/MM/dd");
                            dr["DEN_NGAY_KH"] = ngayKTKH.Date.ToString("yyyy/MM/dd");


                        }

                        double iSoGio = 0;
                        try
                        {

                            try
                            {
                                if (Commons.Modules.sPrivate == "REMINGTON")
                                {
                                    iSoGio = Convert.ToDouble(grvCVChinhNS.GetFocusedDataRow()["SO_GIO_KH"]);
                                }
                                else
                                {
                                    if (Commons.Modules.iPhutGioPBT == 1)
                                    {
                                        iSoGio = (denNgayGioHong - tuNgayGioHong).TotalMinutes;
                                    }
                                    else
                                    {
                                        iSoGio = Math.Round((denNgayGioHong - tuNgayGioHong).TotalMinutes / 60, 2);
                                    }
                                }
                            }
                            catch { iSoGio = 0; }
                            if (Commons.Modules.sPrivate != "BARIA" && Commons.Modules.sPrivate != "VINHHOAN")
                            {
                                dr["SO_GIO"] = iSoGio;
                                dr["TONG_GIO_KH"] = iSoGio;
                            }

                        }
                        catch
                        {
                        }

                        if (optOption.SelectedIndex == 1)
                        {
                        }
                        else
                        {
                            if (tabCVNhanSu.SelectedTabPageIndex == 1)
                            {
                                dr["MS_CV"] = grvCVPhuNS.GetFocusedDataRow()["STT"];
                                dr["MS_BO_PHAN"] = grvCVPhuNS.GetFocusedDataRow()["STT"];
                                str = "STTID" + Commons.Modules.UserName;
                                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, str, dtNhanSuKeHoachTMP, "");
                                str = " SELECT TOP 1 ISNULL(MAX(ID_STT),0) + 1 FROM " + str + " WHERE (MS_CONG_NHAN = '" + tb.Rows[i]["MS_CONG_NHAN"].ToString() + "' )";
                                try
                                {
                                    iSTT = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str));
                                }
                                catch
                                {
                                    iSTT = 1;
                                }
                                dr["ID_STT"] = iSTT;
                            }
                            else
                            {
                                dr["MS_CV"] = grvCVChinhNS.GetFocusedDataRow()["MS_CV"];
                                dr["MS_BO_PHAN"] = grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"];
                                str = "STTID" + Commons.Modules.UserName;
                                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, str, dtNhanSuKeHoachTMP, "");
                                str = " SELECT TOP 1 ISNULL(MAX(STT), 0) + 1 FROM " + str + " WHERE (MS_CONG_NHAN = '" + tb.Rows[i]["MS_CONG_NHAN"].ToString() + "' )";
                                try
                                {
                                    iSTT = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str));
                                }
                                catch
                                {
                                    iSTT = 1;
                                }
                                dr["STT"] = iSTT;
                            }
                        }
                        dtNhanSuKeHoachTMP.Rows.Add(dr);
                    }
                    Commons.Modules.ObjSystems.XoaTable("STTID" + Commons.Modules.UserName);
                    if (optOption.SelectedIndex == 0)
                    {
                        if (tabCVNhanSu.SelectedTabPageIndex == 1)
                        {
                            dtNhanSuKeHoachTMP.DefaultView.RowFilter = "MS_CV = '" + grvCVPhuNS.GetFocusedDataRow()["STT"] + "' AND MS_BO_PHAN = '" + grvCVPhuNS.GetFocusedDataRow()["STT"] + "'";
                        }
                        else
                        {
                            dtNhanSuKeHoachTMP.DefaultView.RowFilter = "MS_CV = '" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"] + "' AND MS_BO_PHAN = '" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"] + "'";
                        }
                    }
                    try
                    {
                        grvKHNhanVien.Columns.Clear();
                    }
                    catch
                    {
                    }
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHNhanVien, grvKHNhanVien, dtNhanSuKeHoachTMP.DefaultView.ToTable().Copy(), true, false, true, false, true, "frmPhieuBaoTri_New");
                    grvKHNhanVien.Columns["MS_CN"].Visible = false;
                    grvKHNhanVien.Columns["THUE_NGOAI"].Visible = false;
                    grvKHNhanVien.Columns["HOAN_THANH"].Visible = false;
                    grvKHNhanVien.Columns["TEN_CONG_NHAN"].MinWidth = 180;
                    grvKHNhanVien.Columns["THUE_NGOAI"].MinWidth = 80;
                    grvKHNhanVien.Columns["TEN_CONG_NHAN"].BestFit();
                    grvKHNhanVien.Columns["TEN_CONG_NHAN"].OptionsColumn.AllowEdit = false;
                    grvKHNhanVien.Columns["MS_CONG_NHAN"].Visible = false;
                    if (optOption.SelectedIndex == 0)
                    {
                        grvKHNhanVien.Columns["MS_CV"].Visible = false;
                        grvKHNhanVien.Columns["MS_BO_PHAN"].Visible = false;
                        if (tabCVNhanSu.SelectedTabPageIndex == 0)
                        {
                            grvKHNhanVien.Columns["STT"].Visible = false;
                        }
                        else
                        {
                            grvKHNhanVien.Columns["ID_STT"].Visible = false;
                        }
                    }
                    else
                    {
                        grvKHNhanVien.Columns["STT"].Visible = false;
                    }
                    RepositoryItemTimeEdit cboTuGio = new RepositoryItemTimeEdit();
                    RepositoryItemTimeEdit cboDenGio = new RepositoryItemTimeEdit();
                    RepositoryItemDateEdit cboDenNgay = new RepositoryItemDateEdit();
                    RepositoryItemDateEdit cboNgay = new RepositoryItemDateEdit();
                    grvKHNhanVien.Columns["TU_GIO"].ColumnEdit = cboTuGio;
                    grvKHNhanVien.Columns["DEN_GIO"].ColumnEdit = cboDenGio;
                    grvKHNhanVien.Columns["DEN_NGAY"].ColumnEdit = cboDenNgay;
                    grvKHNhanVien.Columns["TU_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";

                    grvKHNhanVien.Columns["TU_GIO_KH"].ColumnEdit = cboTuGio;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].ColumnEdit = cboDenGio;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].ColumnEdit = cboDenNgay;
                    grvKHNhanVien.Columns["TU_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO_KH"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO_KH"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].DisplayFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY_KH"].DisplayFormat.FormatString = "dd/MM/yyyy";

                    if (btnGhi.Visible == true)
                    {
                        grvKHNhanVien.Columns["SO_GIO"].OptionsColumn.AllowEdit = Commons.Modules.iPBTTheoGio == 0 ? false : true;
                        grvKHNhanVien.Columns["TONG_GIO_KH"].OptionsColumn.AllowEdit = Commons.Modules.iPBTTheoGio == 0 ? false : true;
                    }
                    grvKHNhanVien.Columns["SO_GIO"].Caption = Commons.Modules.iPBTTheoGio == 0 ? Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT", Commons.Modules.TypeLanguage) : Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO", Commons.Modules.TypeLanguage);

                    grvKHNhanVien.Columns["SO_GIO"].Caption = Commons.Modules.iPBTTheoGio == 0 ? Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT_KH", Commons.Modules.TypeLanguage) : Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "TONG_GIO_KH", Commons.Modules.TypeLanguage);

                    //if (Commons.Modules.iPBTTheoGio == 2)
                    //{
                    //    //////////grvKHNhanVien.Columns["NGAY"].Visible = false;
                    //    //////////grvKHNhanVien.Columns["TU_GIO"].Visible = false;
                    //    //////////grvKHNhanVien.Columns["DEN_GIO"].Visible = false;
                    //    //////////grvKHNhanVien.Columns["DEN_NGAY"].Visible = false;
                    //    //////////grvKHNhanVien.Columns["NGAY_KH"].Visible = false;
                    //    //////////grvKHNhanVien.Columns["TU_GIO_KH"].Visible = false;
                    //    //////////grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = false;
                    //    //////////grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = false;
                    //    ////////grvKHNhanVien.Columns["SO_GIO"].Width = grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width / 2;
                    //    ////////grvKHNhanVien.Columns["TONG_GIO_KH"].Width = grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width / 2;
                    //}
                    //else
                    //{
                    if (optTrangThai.SelectedIndex == 0)
                    {
                        grvKHNhanVien.Columns["NGAY_KH"].Visible = true;
                        grvKHNhanVien.Columns["TU_GIO_KH"].Visible = true;
                        grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = true;
                        grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = true;
                        grvKHNhanVien.Columns["TONG_GIO_KH"].Visible = true;

                        grvKHNhanVien.Columns["NGAY"].Visible = false;
                        grvKHNhanVien.Columns["TU_GIO"].Visible = false;
                        grvKHNhanVien.Columns["DEN_GIO"].Visible = false;
                        grvKHNhanVien.Columns["DEN_NGAY"].Visible = false;
                        grvKHNhanVien.Columns["SO_GIO"].Visible = false;
                    }
                    else
                    {
                        grvKHNhanVien.Columns["NGAY"].Visible = true;
                        grvKHNhanVien.Columns["TU_GIO"].Visible = true;
                        grvKHNhanVien.Columns["DEN_GIO"].Visible = true;
                        grvKHNhanVien.Columns["DEN_NGAY"].Visible = true;
                        grvKHNhanVien.Columns["SO_GIO"].Visible = true;
                        grvKHNhanVien.Columns["NGAY_KH"].Visible = false;
                        grvKHNhanVien.Columns["TU_GIO_KH"].Visible = false;
                        grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = false;
                        grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = false;
                        grvKHNhanVien.Columns["TONG_GIO_KH"].Visible = false;
                    }
                    //}
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void btnKhongghi_Click(object sender, EventArgs e)
        {
            VisibleButton(true);

            optOption_SelectedIndexChanged(null, null);

            string str = "";
            try
            {
                str = "DROP TABLE tmpNhanVien" + Commons.Modules.UserName;
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }
            try
            {
                str = "DROP TABLE tmpPhanBoNhanVien" + Commons.Modules.UserName;
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }
            BarManagerNS.Dispose();
        }


        public DevExpress.XtraBars.BarManager BarManagerNS = new DevExpress.XtraBars.BarManager();
        private void CreateMenuThemNgayGioNhanSu(GridControl grd)
        {
            try
            {
                foreach (Control control in grd.Controls)
                {
                    if (control.GetType() == typeof(DevExpress.XtraBars.BarDockControl))
                    {
                        return;
                    }
                }
            }
            catch
            {
            }

            BarManagerNS = new DevExpress.XtraBars.BarManager();
            BarManagerNS.Form = grd;
            BarManagerNS.ItemClick += BarManagerNS_ItemClick;
            BarManagerNS.BeginUpdate();
            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(BarManagerNS);
            BarManagerNS.SetPopupContextMenu(grd, popup);

            string sStr = null;

            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuThemTatCaThoiGian", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuThemTatCaThoiGian = new DevExpress.XtraBars.BarButtonItem(BarManagerNS, sStr);
            mnuThemTatCaThoiGian.Name = "mnuThemTatCaThoiGian";

            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuBoTatCaThoiGian", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuBoTatCaThoiGian = new DevExpress.XtraBars.BarButtonItem(BarManagerNS, sStr);
            mnuBoTatCaThoiGian.Name = "mnuBoTatCaThoiGian";

            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuThemDongDangChon", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuThemDongDangChon = new DevExpress.XtraBars.BarButtonItem(BarManagerNS, sStr);
            mnuThemDongDangChon.Name = "mnuThemDongDangChon";

            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuBoDongDangChon", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuBoDongDangChon = new DevExpress.XtraBars.BarButtonItem(BarManagerNS, sStr);
            mnuBoDongDangChon.Name = "mnuBoDongDangChon";

            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuSaoChep", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuSaoChep = new DevExpress.XtraBars.BarButtonItem(BarManagerNS, sStr);
            mnuSaoChep.Name = "mnuSaoChep";


            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", optTrangThai.SelectedIndex == 0 ? "mnuChuyenGioKHQuaTTDangChon" : "mnuChuyenGioKHQuaTTAll", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuChuyenGioXQuaYDangChon = new DevExpress.XtraBars.BarButtonItem(BarManagerNS, sStr);
            mnuChuyenGioXQuaYDangChon.Name = "mnuChuyenGioXQuaYDangChon";


            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", optTrangThai.SelectedIndex == 0 ? "mnuChuyenGioKHQuaTTAll" : "mnuChuyenGioTTQuaKHAll", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuChuyenGioXQuaYAll = new DevExpress.XtraBars.BarButtonItem(BarManagerNS, sStr);
            mnuChuyenGioXQuaYAll.Name = "mnuChuyenGioXQuaYAll";

            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", optTrangThai.SelectedIndex == 0 ? "mnuChuyenTatCaGioKHQuaTatCaGioTT" : "mnuChuyenTatCaGioTTQuaTatCaGioKH", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuChuyenTatCaGioXQuaTatCaY = new DevExpress.XtraBars.BarButtonItem(BarManagerNS, sStr);
            mnuChuyenTatCaGioXQuaTatCaY.Name = "mnuChuyenTatCaGioXQuaTatCaY";


            popup.AddItems(new DevExpress.XtraBars.BarItem[] {
                            mnuThemDongDangChon,
                            mnuBoDongDangChon,
                            mnuThemTatCaThoiGian,
                            mnuBoTatCaThoiGian,
                            mnuChuyenGioXQuaYDangChon,
                            mnuChuyenGioXQuaYAll,
                            mnuChuyenTatCaGioXQuaTatCaY,
                            mnuSaoChep
                        });

            popup.ItemLinks[2].BeginGroup = true;
            popup.ItemLinks[4].BeginGroup = true;
            popup.ItemLinks[6].BeginGroup = true;
            popup.ItemLinks[7].BeginGroup = true;


            BarManagerNS.EndUpdate();
        }

        private void BarManagerNS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DevExpress.XtraBars.BarSubItem subMenu = e.Item as DevExpress.XtraBars.BarSubItem;
            DevExpress.XtraBars.BarManager barMenu = sender as DevExpress.XtraBars.BarManager;
            if ((subMenu != null))
                return;
            if ((grvKHNhanVien.RowCount == 0))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "KhongCoDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DevExpress.XtraGrid.GridControl grd = this.Controls.Find(barMenu.Form.Name, true).FirstOrDefault() as DevExpress.XtraGrid.GridControl;
            GridView grv = grd.MainView as GridView;

            try
            {
                DataTable dt = new DataTable();
                switch (e.Item.Name)
                {
                    case "mnuThemTatCaThoiGian":
                        if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgChacChanThemAllThoiGianNhanSu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No))
                            return;
                        Commons.Modules.SQLString = "0NS";
                        for (int j = 0; j <= grv.RowCount - 1; j++)
                        {
                            if (optTrangThai.SelectedIndex == 0)
                            {
                                grv.SetRowCellValue(j, "NGAY_KH", DateTime.Now.ToString("dd/MM/yyyy"));
                                grv.SetRowCellValue(j, "TU_GIO_KH", DateTime.Now.ToString("HH:mm"));
                                grv.SetRowCellValue(j, "DEN_NGAY_KH", DateTime.Now.ToString("dd/MM/yyyy"));
                                grv.SetRowCellValue(j, "DEN_GIO_KH", DateTime.Now.ToString("HH:mm"));
                            }
                            else
                            {
                                grv.SetRowCellValue(j, "NGAY", DateTime.Now.ToString("dd/MM/yyyy"));
                                grv.SetRowCellValue(j, "TU_GIO", DateTime.Now.ToString("HH:mm"));
                                grv.SetRowCellValue(j, "DEN_NGAY", DateTime.Now.ToString("dd/MM/yyyy"));
                                grv.SetRowCellValue(j, "DEN_GIO", DateTime.Now.ToString("HH:mm"));
                            }
                            grv.UpdateCurrentRow();
                        }

                        Commons.Modules.SQLString = "";
                        goto all;

                    case "mnuBoTatCaThoiGian":
                        if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgChacChanBoAllThoiGianNhanSu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No))
                            return;

                        Commons.Modules.SQLString = "0NS";
                        for (int j = 0; j <= grv.RowCount - 1; j++)
                        {
                            if (optTrangThai.SelectedIndex == 0)
                            {
                                grv.SetRowCellValue(j, "NGAY_KH", null);
                                grv.SetRowCellValue(j, "TU_GIO_KH", null);
                                grv.SetRowCellValue(j, "DEN_NGAY_KH", null);
                                grv.SetRowCellValue(j, "DEN_GIO_KH", null);
                                grv.SetRowCellValue(j, "TONG_GIO_KH", 0);
                            }
                            else
                            {
                                grv.SetRowCellValue(j, "NGAY", null);
                                grv.SetRowCellValue(j, "TU_GIO", null);
                                grv.SetRowCellValue(j, "DEN_GIO", null);
                                grv.SetRowCellValue(j, "DEN_NGAY", null);
                                grv.SetRowCellValue(j, "SO_GIO", 0);
                            }
                            grv.UpdateCurrentRow();
                        }

                        Commons.Modules.SQLString = "";
                        goto all;

                    case "mnuThemDongDangChon":
                        Commons.Modules.SQLString = "0NS";
                        if (optTrangThai.SelectedIndex == 0)
                        {
                            grv.SetFocusedRowCellValue("NGAY_KH", DateTime.Now.ToString("dd/MM/yyyy"));
                            grv.SetFocusedRowCellValue("TU_GIO_KH", DateTime.Now.ToString("HH:mm"));
                            grv.SetFocusedRowCellValue("DEN_NGAY_KH", DateTime.Now.ToString("dd/MM/yyyy"));
                            grv.SetFocusedRowCellValue("DEN_GIO_KH", DateTime.Now.ToString("HH:mm"));
                        }
                        else
                        {
                            grv.SetFocusedRowCellValue("NGAY", DateTime.Now.ToString("dd/MM/yyyy"));
                            grv.SetFocusedRowCellValue("TU_GIO", DateTime.Now.ToString("HH:mm"));
                            grv.SetFocusedRowCellValue("DEN_NGAY", DateTime.Now.ToString("dd/MM/yyyy"));
                            grv.SetFocusedRowCellValue("DEN_GIO", DateTime.Now.ToString("HH:mm"));
                        }
                        grv.UpdateCurrentRow();
                        Commons.Modules.SQLString = "";
                        goto one;

                    case "mnuBoDongDangChon":
                        Commons.Modules.SQLString = "0NS";
                        if (optTrangThai.SelectedIndex == 0)
                        {
                            grv.SetFocusedRowCellValue("NGAY_KH", null);
                            grv.SetFocusedRowCellValue("TU_GIO_KH", null);
                            grv.SetFocusedRowCellValue("DEN_NGAY_KH", null);
                            grv.SetFocusedRowCellValue("DEN_GIO_KH", null);
                            grv.SetFocusedRowCellValue("TONG_GIO_KH", 0);

                        }
                        else
                        {
                            grv.SetFocusedRowCellValue("NGAY", null);
                            grv.SetFocusedRowCellValue("TU_GIO", null);
                            grv.SetFocusedRowCellValue("DEN_GIO", null);
                            grv.SetFocusedRowCellValue("DEN_NGAY", null);
                            grv.SetFocusedRowCellValue("SO_GIO", 0);

                        }
                        grv.SetFocusedRowCellValue("SO_GIO", null);
                        grv.UpdateCurrentRow();

                        Commons.Modules.SQLString = "";
                        goto one;

                    case "mnuSaoChep":
                        if (grvKHNhanVien.RowCount <= 0)
                        {
                            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgVuiLongChonNhanVien", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        try
                        {
                            Commons.Modules.SQLString = "0NS";
                            for (int j = 0; j <= grv.RowCount - 1; j++)
                            {
                                if (j != grv.FocusedRowHandle)
                                {
                                    if (optTrangThai.SelectedIndex == 0)
                                    {
                                        grv.SetRowCellValue(j, "NGAY_KH", grv.GetFocusedDataRow()["NGAY_KH"]);
                                        grv.SetRowCellValue(j, "TU_GIO_KH", grv.GetFocusedDataRow()["TU_GIO_KH"]);
                                        grv.SetRowCellValue(j, "DEN_NGAY_KH", grv.GetFocusedDataRow()["DEN_NGAY_KH"]);
                                        grv.SetRowCellValue(j, "DEN_GIO_KH", grv.GetFocusedDataRow()["DEN_GIO_KH"]);
                                        grv.SetRowCellValue(j, "TONG_GIO_KH", grv.GetFocusedDataRow()["TONG_GIO_KH"]);
                                    }
                                    else
                                    {
                                        grv.SetRowCellValue(j, "NGAY", grv.GetFocusedDataRow()["NGAY"]);
                                        grv.SetRowCellValue(j, "TU_GIO", grv.GetFocusedDataRow()["TU_GIO"]);
                                        grv.SetRowCellValue(j, "DEN_NGAY", grv.GetFocusedDataRow()["DEN_NGAY"]);
                                        grv.SetRowCellValue(j, "DEN_GIO", grv.GetFocusedDataRow()["DEN_GIO"]);
                                        grv.SetRowCellValue(j, "SO_GIO", grv.GetFocusedDataRow()["SO_GIO"]);
                                    }
                                    grv.UpdateCurrentRow();
                                }
                            }
                        }
                        catch
                        {
                        }
                        Commons.Modules.SQLString = "";
                        goto all;
                    case "mnuChuyenGioXQuaYDangChon":
                        Commons.Modules.SQLString = "0NS";
                        if (optTrangThai.SelectedIndex == 0)
                        {
                            TrangThai = 1;
                            grv.SetFocusedRowCellValue("NGAY", grv.GetFocusedRowCellValue("NGAY_KH"));
                            grv.SetFocusedRowCellValue("TU_GIO", grv.GetFocusedRowCellValue("TU_GIO_KH"));
                            grv.SetFocusedRowCellValue("DEN_NGAY", grv.GetFocusedRowCellValue("DEN_NGAY_KH"));
                            grv.SetFocusedRowCellValue("DEN_GIO", grv.GetFocusedRowCellValue("DEN_GIO_KH"));
                            grv.SetFocusedRowCellValue("SO_GIO", grv.GetFocusedRowCellValue("TONG_GIO_KH"));
                        }
                        else
                        {
                            TrangThai = 0;
                            grv.SetFocusedRowCellValue("NGAY_KH", grv.GetFocusedRowCellValue("NGAY"));
                            grv.SetFocusedRowCellValue("TU_GIO_KH", grv.GetFocusedRowCellValue("TU_GIO"));
                            grv.SetFocusedRowCellValue("DEN_NGAY_KH", grv.GetFocusedRowCellValue("DEN_NGAY"));
                            grv.SetFocusedRowCellValue("DEN_GIO_KH", grv.GetFocusedRowCellValue("DEN_GIO"));
                            grv.SetFocusedRowCellValue("TONG_GIO_KH", grv.GetFocusedRowCellValue("SO_GIO"));
                        }
                        grv.UpdateCurrentRow();
                        Commons.Modules.SQLString = "";
                        goto one;

                    case "mnuChuyenGioXQuaYAll":
                        if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", optTrangThai.SelectedIndex == 0 ? "msgChuyenGioKHQuaTTAll" : "msgChuyenGioTTQuaKHAll", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No))
                            return;
                        Commons.Modules.SQLString = "0NS";
                        for (int j = 0; j <= grv.RowCount - 1; j++)
                        {
                            if (optTrangThai.SelectedIndex == 0)
                            {
                                grv.SetRowCellValue(j, "NGAY", grv.GetFocusedRowCellValue("NGAY_KH"));
                                grv.SetRowCellValue(j, "TU_GIO", grv.GetFocusedRowCellValue("TU_GIO_KH"));
                                grv.SetRowCellValue(j, "DEN_NGAY", grv.GetFocusedRowCellValue("DEN_NGAY_KH"));
                                grv.SetRowCellValue(j, "DEN_GIO", grv.GetFocusedRowCellValue("DEN_GIO_KH"));
                                grv.SetRowCellValue(j, "SO_GIO", grv.GetFocusedRowCellValue("TONG_GIO_KH"));
                            }
                            else
                            {
                                grv.SetRowCellValue(j, "NGAY_KH", grv.GetFocusedRowCellValue("NGAY"));
                                grv.SetRowCellValue(j, "TU_GIO_KH", grv.GetFocusedRowCellValue("TU_GIO"));
                                grv.SetRowCellValue(j, "DEN_NGAY_KH", grv.GetFocusedRowCellValue("DEN_NGAY"));
                                grv.SetRowCellValue(j, "DEN_GIO_KH", grv.GetFocusedRowCellValue("DEN_GIO"));
                                grv.SetRowCellValue(j, "TONG_GIO_KH", grv.GetFocusedRowCellValue("SO_GIO"));
                            }
                            grv.UpdateCurrentRow();
                        }
                        TrangThai = optTrangThai.SelectedIndex == 0 ? 1 : 0;
                        Commons.Modules.SQLString = "";
                        goto all;
                    case "mnuChuyenTatCaGioXQuaTatCaY":
                        Commons.Modules.SQLString = "0NS";
                        for (int j = 0; j <= grv.RowCount - 1; j++)
                        {
                            if (optTrangThai.SelectedIndex == 0)
                            {
                                TrangThai = 1;
                                grv.SetRowCellValue(j, "NGAY", grv.GetDataRow(j)["NGAY_KH"]);
                                grv.SetRowCellValue(j, "TU_GIO", grv.GetDataRow(j)["TU_GIO_KH"]);
                                grv.SetRowCellValue(j, "DEN_NGAY", grv.GetDataRow(j)["DEN_NGAY_KH"]);
                                grv.SetRowCellValue(j, "DEN_GIO", grv.GetDataRow(j)["DEN_GIO_KH"]);
                                grv.SetRowCellValue(j, "SO_GIO", grv.GetDataRow(j)["TONG_GIO_KH"]);
                            }
                            else
                            {
                                TrangThai = 0;
                                grv.SetRowCellValue(j, "NGAY_KH", grv.GetDataRow(j)["NGAY"]);
                                grv.SetRowCellValue(j, "TU_GIO_KH", grv.GetDataRow(j)["TU_GIO"]);
                                grv.SetRowCellValue(j, "DEN_NGAY_KH", grv.GetDataRow(j)["DEN_NGAY"]);
                                grv.SetRowCellValue(j, "DEN_GIO_KH", grv.GetDataRow(j)["DEN_GIO"]);
                                grv.SetRowCellValue(j, "TONG_GIO_KH", grv.GetDataRow(j)["SO_GIO"]);
                            }
                        }
                        grv.UpdateCurrentRow();
                        Commons.Modules.SQLString = "";
                        goto all;
                    default:
                        break;
                }
            one:
                grvKHNhanVien_CellValueChanged(grvKHNhanVien, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(grvKHNhanVien.FocusedRowHandle, null, null));

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "CapNhapThanhCong", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                TrangThai = optTrangThai.SelectedIndex;
                return;
            all:
                for (int j = 0; j <= grvKHNhanVien.RowCount - 1; j++)
                {
                    grvKHNhanVien_CellValueChanged(grvKHNhanVien, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(j, null, null));
                }
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "CapNhapThanhCong", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                TrangThai = optTrangThai.SelectedIndex;
                return;
            }
            catch
            {
                Commons.Modules.SQLString = "";
            }
            Commons.Modules.SQLString = "";

        }

        private string ConvertDatetimeByCultural(string date, string format)
        {
            return Convert.ToDateTime(date, new CultureInfo("vi-vn")).ToString(format);
        }

        private void InsertStaffByWorkOrder()
        {
            string sBT = "PBTNS" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, dtNhanSuKeHoachTMP, "");


            SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                //SqlHelper.ExecuteNonQuery(trans, CommandType.Text, $"DELETE PHIEU_BAO_TRI_NHAN_SU WHERE MS_PHIEU_BAO_TRI = '{ sMsPBT }'");


                //dtNhanSuKeHoachTMP.Select().AsEnumerable().ToList().ForEach(p =>
                //{
                //    string str = $"INSERT INTO PHIEU_BAO_TRI_NHAN_SU (MS_PHIEU_BAO_TRI, MS_CONG_NHAN, NGAY, TU_GIO,DEN_NGAY, DEN_GIO, HOAN_THANH,  SO_GIO, NGAY_KH, TU_GIO_KH, DEN_NGAY_KH, DEN_GIO_KH, TONG_GIO_KH) VALUES ( '{ sMsPBT }', '{ p["MS_CONG_NHAN"] }' ,'{ ConvertDatetimeByCultural(p["NGAY"].ToString(), "yyyy/MM/dd") }' ,'{ ConvertDatetimeByCultural(p["TU_GIO"].ToString(), "yyyy/MM/dd HH:mm") }' ,'{ ConvertDatetimeByCultural(p["DEN_NGAY"].ToString(), "yyyy/MM/dd") }' ,'{ ConvertDatetimeByCultural(p["DEN_GIO"].ToString(), "yyyy/MM/dd HH:mm") }' ,'{ p["HOAN_THANH"] }' ,'{ p["SO_GIO"] }' ,'{ ConvertDatetimeByCultural(p["NGAY_KH"].ToString(), "yyyy/MM/dd")}' ,'{  ConvertDatetimeByCultural(p["TU_GIO_KH"].ToString(), "yyyy/MM/dd HH:mm") }' ,'{ ConvertDatetimeByCultural(p["DEN_NGAY_KH"].ToString(), "yyyy/MM/dd") }' ,'{ ConvertDatetimeByCultural(p["DEN_GIO_KH"].ToString(), "yyyy/MM/dd HH:mm") }', '{ p["TONG_GIO_KH"] }' )";
                //    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, str);
                //});

                //foreach (DataRow dr in dtNhanSuKeHoachTMP.Rows)
                //{
                //string sNGAY, sTU_GIO, sDEN_NGAY, sDEN_GIO, sNGAY_KH, sSO_GIO, sTU_GIO_KH, sDEN_NGAY_KH, sDEN_GIO_KH, sTONG_GIO_KH, sHOAN_THANH;

                //try { sNGAY = " '" +  ConvertDatetimeByCultural(dr["NGAY"].ToString(), "yyyy/MM/dd") + "' "; } catch { sNGAY = "NULL"; }
                //try { sTU_GIO = " '" + ConvertDatetimeByCultural(dr["TU_GIO"].ToString(), "yyyy/MM/dd HH:mm") + "' "; } catch { sTU_GIO = "NULL"; }
                //try { sDEN_NGAY = " '" + ConvertDatetimeByCultural(dr["DEN_NGAY"].ToString(), "yyyy/MM/dd") + "' "; } catch { sDEN_NGAY = "NULL"; }
                //try { sDEN_GIO = " '" + ConvertDatetimeByCultural(dr["DEN_GIO"].ToString(), "yyyy/MM/dd HH:mm") + "' "; } catch { sDEN_GIO = "NULL"; }
                //try { sSO_GIO = (string.IsNullOrEmpty(dr["SO_GIO"].ToString()) ? "NULL" : dr["SO_GIO"].ToString()); } catch { sSO_GIO = "NULL"; }
                //try { if (sSO_GIO == "0") sSO_GIO = "NULL"; } catch { sSO_GIO = "NULL"; }
                //try { sNGAY_KH = " '" + ConvertDatetimeByCultural(dr["NGAY_KH"].ToString(), "yyyy/MM/dd") + "' "; } catch { sNGAY_KH = "NULL"; }
                //try { sTU_GIO_KH = " '" + ConvertDatetimeByCultural(dr["TU_GIO_KH"].ToString(), "yyyy/MM/dd HH:mm") + "' "; } catch { sTU_GIO_KH = "NULL"; }
                //try { sDEN_NGAY_KH = " '" + ConvertDatetimeByCultural(dr["DEN_NGAY_KH"].ToString(), "yyyy/MM/dd") + "' "; } catch { sDEN_NGAY_KH = "NULL"; }
                //try { sDEN_GIO_KH = " '" + ConvertDatetimeByCultural(dr["DEN_GIO_KH"].ToString(), "yyyy/MM/dd HH:mm") + "' "; } catch { sDEN_GIO_KH = "NULL"; }
                //try { sTONG_GIO_KH = (string.IsNullOrEmpty(dr["TONG_GIO_KH"].ToString()) ? "NULL" : dr["TONG_GIO_KH"].ToString()); } catch { sTONG_GIO_KH = "NULL"; }
                //try { if (sTONG_GIO_KH == "0") sTONG_GIO_KH = "NULL"; } catch { sTONG_GIO_KH = "NULL"; }
                //try { sHOAN_THANH = " '" + (dr["HOAN_THANH"].ToString() == "0" ? "NULL" : dr["HOAN_THANH"].ToString()) + "' "; } catch { sHOAN_THANH = "NULL"; }

                //string str = $"INSERT INTO PHIEU_BAO_TRI_NHAN_SU (MS_PHIEU_BAO_TRI, MS_CONG_NHAN, NGAY, TU_GIO,DEN_NGAY, DEN_GIO, HOAN_THANH,  SO_GIO, NGAY_KH, TU_GIO_KH, DEN_NGAY_KH, DEN_GIO_KH, TONG_GIO_KH) VALUES ( '{ sMsPBT }', '{ dr["MS_CONG_NHAN"] }' ,{ sNGAY } ,{ sTU_GIO } ,{ sDEN_NGAY } ,{ sDEN_GIO } ,{ sHOAN_THANH } ,{ sSO_GIO } ,{ sNGAY_KH } ,{ sTU_GIO_KH } ,{ sDEN_NGAY_KH } ,{ sDEN_GIO_KH }, { sTONG_GIO_KH } )";
                //SqlHelper.ExecuteNonQuery(trans, CommandType.Text, str);

                SqlHelper.ExecuteNonQuery(trans, "AddPBTNhanSu", sMsPBT, sBT);
                //}
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }


            Commons.Modules.ObjSystems.XoaTable(sBT);


        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                grvKHNhanVien_ValidateRow(null, null);

                if (optOption.SelectedIndex == 1)
                {
                    string sBT = null;
                    sBT = "PBTCVNSCT" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtNhanSuKeHoachTMP, "");
                    if (!CheckGioNhanVien(sBT)) return;
                    InsertStaffByWorkOrder();
                }
                else
                {
                    if (!KiemTraPhanBoNhanVien())
                    {
                        return;
                    }
                    string sBT = null;
                    sBT = "PBTCVNSCT" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtNhanSuKeHoachTMP, "");
                    if (!CheckGioNhanVien(sBT)) return;

                    clsJobCardInfo jobcardinfo = new clsJobCardInfo();
                    JOBCARD_Controller jobcardcontroller = new JOBCARD_Controller();
                    try
                    {
                        if (this.tabControl.SelectedTabPageIndex == 0)
                        {
                            if (tabCVNhanSu.SelectedTabPageIndex == 0)
                            {
                                sBT = "PBTCVNSCT";
                                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtNhanSuKeHoachTMP, "");
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddPBTCVNhanSuChiTiet_NEW", sMsPBT);
                                Commons.Modules.ObjSystems.XoaTable(sBT);
                            }
                            else
                            {
                                sBT = "PBTCVNPT";
                                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtNhanSuKeHoachTMP, "");
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddPBTCVNhanSuPhuTro_NEW", sMsPBT);
                                Commons.Modules.ObjSystems.XoaTable(sBT);
                            }
                        }
                    }
                    catch
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "MsgDateTimeError", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                VisibleButton(true);

                optOption_SelectedIndexChanged(null, null);

                grvCVChinhNS.OptionsBehavior.Editable = false;
                grvCVPhuNS.OptionsBehavior.Editable = false;

                BarManagerNS.Dispose();
                //btnCapnhatthoigiancongviec.Visible = false;
                string str = "";
                try
                {
                    str = "DROP TABLE tmpNhanVien" + Commons.Modules.UserName;
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }
                try
                {
                    str = "DROP TABLE tmpPhanBoNhanVien" + Commons.Modules.UserName;
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }

            }
            catch
            {
            }

        }



        private bool CheckGioNhanVien(string sBT)
        {
            //kiểm giờ kê hoạch trước
            for (int k = 0; k <= this.grvKHNhanVien.RowCount - 1; k++)
            {
                try
                {
                    if ((grvKHNhanVien.GetDataRow(k)["NGAY_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["NGAY_KH"].ToString().Trim())) & (grvKHNhanVien.GetDataRow(k)["TU_GIO_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["TU_GIO_KH"].ToString())) & (grvKHNhanVien.GetDataRow(k)["DEN_NGAY_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["DEN_NGAY_KH"].ToString())) & (grvKHNhanVien.GetDataRow(k)["DEN_GIO_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["DEN_GIO_KH"].ToString())))
                    {
                        //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgChuaNhapTuNgayGioDenNgayGioKeHoach", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //optTrangThai.SelectedIndex = 0;
                        //grvKHNhanVien.FocusedRowHandle = k;
                        //Commons.Modules.ObjSystems.XoaTable(sBT);
                        //return false;
                    }
                    else
                    {

                        if ((!string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["NGAY_KH"].ToString())) & (!string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["TU_GIO_KH"].ToString())) & (!string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["DEN_NGAY_KH"].ToString())) & (!string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["DEN_GIO_KH"].ToString())))
                        {
                            if (Convert.ToDateTime(grvKHNhanVien.GetDataRow(k)["NGAY_KH"].ToString().Trim().Split(' ')[0] + " " + grvKHNhanVien.GetDataRow(k)["TU_GIO_KH"].ToString().Trim().Split(' ')[1]) > Convert.ToDateTime(grvKHNhanVien.GetDataRow(k)["DEN_NGAY_KH"].ToString().Trim().Split(' ')[0] + " " + grvKHNhanVien.GetDataRow(k)["DEN_GIO_KH"].ToString().Trim().Split(' ')[1]))
                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "MsgDateTimeError", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                optTrangThai.SelectedIndex = 0;
                                grvKHNhanVien.FocusedRowHandle = k;
                                Commons.Modules.ObjSystems.XoaTable(sBT);
                                return false;
                            }
                            if (optOption.SelectedIndex == 0)
                            {
                                string sSql = "SELECT COUNT (*) FROM " + sBT + " WHERE MS_CONG_NHAN = '" + grvKHNhanVien.GetDataRow(k)["MS_CONG_NHAN"].ToString().Trim() + "' AND NGAY_KH = '" + Convert.ToDateTime(grvKHNhanVien.GetDataRow(k)["NGAY_KH"].ToString().Trim().Split(' ')[0]).ToString("yyy/MM/dd") + "' AND CONVERT(NVARCHAR(8), TU_GIO_KH, 108) = '" + grvKHNhanVien.GetDataRow(k)["TU_GIO_KH"].ToString().Trim().Split(' ')[1] + "' AND DEN_NGAY_KH = '" + Convert.ToDateTime(grvKHNhanVien.GetDataRow(k)["DEN_NGAY_KH"].ToString().Trim().Split(' ')[0]).ToString("yyy/MM/dd") + "' AND CONVERT(NVARCHAR(8), DEN_GIO_KH, 108) = '" + grvKHNhanVien.GetDataRow(k)["DEN_GIO_KH"].ToString().Trim().Split(' ')[1] + "' AND MS_CV = '" + (tabCVNhanSu.SelectedTabPageIndex.ToString() == "0" ? grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() : grvCVPhuNS.GetFocusedDataRow()["STT"].ToString()) + "'";
                                int res = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                                if (res > 1)
                                {
                                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "TrungDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    optTrangThai.SelectedIndex = 0;
                                    grvKHNhanVien.FocusedRowHandle = k;
                                    Commons.Modules.ObjSystems.XoaTable(sBT);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "ChuaNhapDuDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //optTrangThai.SelectedIndex = 0;
                            //grvKHNhanVien.FocusedRowHandle = k;
                            //return false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "MsgDateTimeError", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    optTrangThai.SelectedIndex = 0;
                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    return false;
                }
            }
            //kiểm giờ TT
            for (int k = 0; k <= this.grvKHNhanVien.RowCount - 1; k++)
            {
                try
                {
                    if ((grvKHNhanVien.GetDataRow(k)["NGAY"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["NGAY"].ToString().Trim())) & (grvKHNhanVien.GetDataRow(k)["TU_GIO"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["TU_GIO"].ToString())) & (grvKHNhanVien.GetDataRow(k)["DEN_NGAY"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["DEN_NGAY"].ToString())) & (grvKHNhanVien.GetDataRow(k)["DEN_GIO"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["DEN_GIO"].ToString())))
                    {
                        //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgChuaNhapTuNgayGioDenNgayGioThucTe", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //optTrangThai.SelectedIndex = 1;
                        //grvKHNhanVien.FocusedRowHandle = k;
                        //Commons.Modules.ObjSystems.XoaTable(sBT);
                        //return false;
                    }
                    else
                    {

                        if ((!string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["NGAY"].ToString())) & (!string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["TU_GIO"].ToString())) & (!string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["DEN_NGAY"].ToString())) & (!string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(k)["DEN_GIO"].ToString())))
                        {
                            if (Convert.ToDateTime(grvKHNhanVien.GetDataRow(k)["NGAY"].ToString().Trim().Split(' ')[0] + " " + grvKHNhanVien.GetDataRow(k)["TU_GIO"].ToString().Trim().Split(' ')[1]) > Convert.ToDateTime(grvKHNhanVien.GetDataRow(k)["DEN_NGAY"].ToString().Trim().Split(' ')[0] + " " + grvKHNhanVien.GetDataRow(k)["DEN_GIO"].ToString().Trim().Split(' ')[1]))
                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "MsgDateTimeError", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                optTrangThai.SelectedIndex = 1;
                                grvKHNhanVien.FocusedRowHandle = k;
                                Commons.Modules.ObjSystems.XoaTable(sBT);
                                return false;
                            }
                            if (optOption.SelectedIndex == 0)
                            {

                                string sSql = "SELECT COUNT (*) FROM " + sBT + " WHERE MS_CONG_NHAN = '" + grvKHNhanVien.GetDataRow(k)["MS_CONG_NHAN"].ToString().Trim() + "' AND NGAY = '" + Convert.ToDateTime(grvKHNhanVien.GetDataRow(k)["NGAY"].ToString().Trim().Split(' ')[0]).ToString("yyy/MM/dd") + "' AND CONVERT(NVARCHAR(8), TU_GIO, 108) = '" + grvKHNhanVien.GetDataRow(k)["TU_GIO"].ToString().Trim().Split(' ')[1] + "' AND DEN_NGAY = '" + Convert.ToDateTime(grvKHNhanVien.GetDataRow(k)["DEN_NGAY"].ToString().Trim().Split(' ')[0]).ToString("yyy/MM/dd") + "' AND CONVERT(NVARCHAR(8), DEN_GIO, 108) = '" + grvKHNhanVien.GetDataRow(k)["DEN_GIO"].ToString().Trim().Split(' ')[1] + "' AND MS_CV = '" + (tabCVNhanSu.SelectedTabPageIndex.ToString() == "0" ? grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() : grvCVPhuNS.GetFocusedDataRow()["STT"].ToString()) + "'";
                                int res = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                                if (res > 1)
                                {
                                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "TrungDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    optTrangThai.SelectedIndex = 1;
                                    grvKHNhanVien.FocusedRowHandle = k;
                                    Commons.Modules.ObjSystems.XoaTable(sBT);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "ChuaNhapDuDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //optTrangThai.SelectedIndex = 1;
                            //grvKHNhanVien.FocusedRowHandle = k;
                            //return false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "MsgDateTimeError", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    optTrangThai.SelectedIndex = 1;
                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    return false;
                }
            }

            return true;
        }

        private bool KiemTraPhanBoNhanVien()
        {
            string str = "";
            str = "Delete from tmpPhanBoNhanVien" + Commons.Modules.UserName + " where MS_PHIEU_BAO_TRI IS NULL OR ( MS_PHIEU_BAO_TRI='" + sMsPBT + "'";
            if (tabCVNhanSu.SelectedTabPageIndex == 0)
            {
                str = str + " and MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "')";
            }
            else
            {
                str = str + " and MS_CV=" + grvCVPhuNS.GetFocusedDataRow()["STT"].ToString() + ")";
            }
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

            int i = 0;
            int idSTT = 0;
            idSTT = 0;
            for (i = 0; i <= grvKHNhanVien.RowCount - 1; i++)
            {
                if (!string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(i)["NGAY"].ToString()) & !string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(i)["TU_GIO"].ToString()) & !string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(i)["DEN_NGAY"].ToString()) & !string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(i)["DEN_GIO"].ToString()))
                {
                    if (tabCVNhanSu.SelectedTabPageIndex == 0)
                    {
                        idSTT = Convert.ToInt32(grvKHNhanVien.GetDataRow(i)["STT"].ToString());
                    }
                    else
                    {
                        idSTT = Convert.ToInt32(grvKHNhanVien.GetDataRow(i)["ID_STT"].ToString());
                    }
                    str = "Insert into tmpPhanBoNhanVien" + Commons.Modules.UserName + " (MS_CONG_NHAN,TU_NGAY,TU_GIO,DEN_NGAY,DEN_GIO,DONG, ID_STT) " + " VALUES(N'" + grvKHNhanVien.GetDataRow(i)["MS_CONG_NHAN"].ToString() + "','" + grvKHNhanVien.GetDataRow(i)["NGAY"].ToString().Split(' ')[0] + "','" + grvKHNhanVien.GetDataRow(i)["TU_GIO"].ToString().Split(' ')[1] + "','" + grvKHNhanVien.GetDataRow(i)["DEN_NGAY"].ToString().Split(' ')[0] + "','" + grvKHNhanVien.GetDataRow(i)["DEN_GIO"].ToString().Split(' ')[1] + "'," + i + ", " + idSTT + "  )";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
            }
            str = "SELECT MIN(CONVERT(DATETIME,TU_NGAY,103)) AS NGAY ,MAX(CONVERT(DATETIME,DEN_NGAY,103))AS DEN_NGAY FROM tmpPhanBoNhanVien" + Commons.Modules.UserName;
            System.Data.SqlClient.SqlDataReader objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str);
            string tu_ngay = "";
            string den_ngay = "";
            while (objRead.Read())
            {
                tu_ngay = objRead["NGAY"].ToString();
                den_ngay = objRead["DEN_NGAY"].ToString();
            }
            objRead.Close();
            if (!string.IsNullOrEmpty(tu_ngay))
            {
                if (tabCVNhanSu.SelectedTabPageIndex == 0)
                {
                    str = " INSERT INTO tmpPhanBoNhanVien" + Commons.Modules.UserName + " (MS_CONG_NHAN,TU_NGAY,TU_GIO,DEN_NGAY,DEN_GIO, ID_STT) " + " SELECT    MS_CONG_NHAN,CONVERT(NVARCHAR(10),NGAY,103) AS NGAY,CONVERT(NVARCHAR(5),TU_GIO,114) AS TU_GIO, " + " CONVERT(NVARCHAR(10),DEN_NGAY,103) AS DEN_NGAY,CONVERT(NVARCHAR(5),DEN_GIO,114) AS DEN_GIO, STT  FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE (NGAY BETWEEN CONVERT(DATETIME,'" + tu_ngay + "',103) AND CONVERT(DATETIME,'" + den_ngay + "',103) OR DEN_NGAY BETWEEN CONVERT(DATETIME,'" + tu_ngay + "',103) AND  CONVERT(DATETIME,'" + den_ngay + "',103)) AND MS_PHIEU_BAO_TRI <>'" + sMsPBT + "'";
                }
                else
                {
                    str = " INSERT INTO tmpPhanBoNhanVien" + Commons.Modules.UserName + "(MS_CONG_NHAN,TU_NGAY,TU_GIO,DEN_NGAY,DEN_GIO, ID_STT) SELECT    MS_CONG_NHAN,CONVERT(NVARCHAR(10),NGAY,103) AS NGAY,CONVERT(NVARCHAR(5),TU_GIO,114) AS TU_GIO, CONVERT(NVARCHAR(10),DEN_NGAY,103) AS DEN_NGAY,CONVERT(NVARCHAR(5),DEN_GIO,114) AS DEN_GIO , ID_STT FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE (NGAY BETWEEN CONVERT(DATETIME,'" + tu_ngay + "',103) AND CONVERT(DATETIME,'" + den_ngay + "',103)  OR DEN_NGAY BETWEEN CONVERT(DATETIME,'" + tu_ngay + "',103) AND  CONVERT(DATETIME,'" + den_ngay + "',103)) AND MS_PHIEU_BAO_TRI <>'" + sMsPBT + "'";
                }
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                DataTable tb = new DataTable();
                str = "select MS_CONG_NHAN,CONVERT(DATETIME,TU_NGAY,103) AS NGAY,CONVERT(DATETIME,TU_GIO,114) AS TU_GIO, CONVERT(DATETIME,DEN_NGAY,103)AS DEN_NGAY,CONVERT(DATETIME,DEN_GIO,114) AS DEN_GIO,DONG, ID_STT from tmpPhanBoNhanVien" + Commons.Modules.UserName + " order by MS_CONG_NHAN,NGAY,TU_GIO";

                tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables[0];

                string sql = "SELECT TOP 1 KIEM_PCCV FROM THONG_TIN_CHUNG";
                bool res = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql));

                if (res == true)
                {
                    for (i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        for (int j = i + 1; j <= tb.Rows.Count - 1; j++)
                        {
                            if (tb.Rows[i]["MS_CONG_NHAN"].ToString() == tb.Rows[j]["MS_CONG_NHAN"].ToString())
                            {
                                if (Convert.ToDateTime(Convert.ToDateTime(tb.Rows[j]["NGAY"]).ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(tb.Rows[j]["TU_GIO"].ToString()).ToString("HH:mm"))
                                >= Convert.ToDateTime(Convert.ToDateTime(tb.Rows[i]["NGAY"]).ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(tb.Rows[i]["TU_GIO"].ToString()).ToString("HH:mm")) &&
                                Convert.ToDateTime(Convert.ToDateTime(tb.Rows[j]["NGAY"]).ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(tb.Rows[j]["TU_GIO"].ToString()).ToString("HH:mm")) <
                                Convert.ToDateTime(Convert.ToDateTime(tb.Rows[i]["DEN_NGAY"]).ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(tb.Rows[i]["DEN_GIO"].ToString()).ToString("HH:mm")))
                                {
                                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "MsgPCTrungThoiGian", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    grvKHNhanVien.FocusedRowHandle = string.IsNullOrEmpty(tb.Rows[j]["DONG"].ToString()) ? string.IsNullOrEmpty(tb.Rows[i]["DONG"].ToString()) ? 0 : Convert.ToInt32(tb.Rows[j]["DONG"].ToString()) : Convert.ToInt32(tb.Rows[j]["DONG"].ToString());
                                    grvKHNhanVien.FocusedColumn = grvKHNhanVien.Columns["DEN_GIO"];
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        int TrangThai = 0;
        private void grvKHNhanVien_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (btnGhi.Visible == false)
                return;
            if (Commons.Modules.SQLString == "0NS")
                return;
            string dTNgay = "";
            string dTGio = "";
            string dDNgay = "";
            string dDGio = "";
            double dSGLuoi = 0.0;
            try
            {
                try
                {
                    dTNgay = TrangThai == 0 ? grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "NGAY_KH") : grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "NGAY");
                }
                catch
                {
                    dTNgay = "";
                }

                try
                {
                    dTGio = TrangThai == 0 ? grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "TU_GIO_KH") : grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "TU_GIO");
                }
                catch
                {
                    dTGio = "";
                }
                try
                {
                    dDNgay = TrangThai == 0 ? grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_NGAY_KH") : grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_NGAY");
                }
                catch
                {
                    dDNgay = "";
                }
                try
                {
                    dDGio = TrangThai == 0 ? grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_GIO_KH") : grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_GIO");
                }
                catch
                {
                    dDGio = "";
                }
                try
                {
                    dSGLuoi = TrangThai == 0 ? Convert.ToDouble(grvKHNhanVien.GetDataRow(e.RowHandle)["TONG_GIO_KH"]) : Convert.ToDouble(grvKHNhanVien.GetDataRow(e.RowHandle)["SO_GIO"]);
                }
                catch
                {
                    dSGLuoi = 0.0;
                }

                if (dSGLuoi == 0.0 & dDNgay == "")
                {
                    ReupdateTemporaryDataWhenDataHasChanged(e.RowHandle);
                    return;
                }
                if (dSGLuoi == 0.0 & dDGio == "")
                {
                    ReupdateTemporaryDataWhenDataHasChanged(e.RowHandle);
                    return;
                }

                if (dSGLuoi == 0.0 & dTGio == "")
                {
                    ReupdateTemporaryDataWhenDataHasChanged(e.RowHandle);
                    return;
                }
                if (dSGLuoi == 0.0 & dTNgay == "")
                {
                    ReupdateTemporaryDataWhenDataHasChanged(e.RowHandle);
                    return;
                }

                if (dTNgay == "" & dTGio == "" & dDGio == "" & dDNgay == "")
                {
                    ReupdateTemporaryDataWhenDataHasChanged(e.RowHandle);
                    return;
                }
                TinhSoGioNV(int.Parse(e.RowHandle.ToString()), dTNgay, dTGio, dDNgay, dDGio);
            }
            catch
            {
            }

            Commons.Modules.SQLString = "";

        }

        private void TinhSoGioNV(int iRow, string dTNgay, string dTGio, string dDNgay, string dDGio)
        {

            if (Commons.Modules.iPBTTheoGio == 2)
                return;
            try
            {
                //iPBTTheoGio =          PBT_THEO_GIO: Định nghĩa cách nhập
                //PBT_THEO_GIO=0 Nhập từ ngày, đến ngày, từ giờ đến giờ , tính ra số giờ 
                //PBT_THEO_GIO=1 Nhập từ ngày, đến ngày, từ giờ đến giờ nhưng không tính số giờ tự động, số giờ có thể khác từ giờ - đến giờ  
                //PBT_THEO_GIO=2 Chỉ nhập số giờ hay phút 

                //iPhutGioPBT =          PHUT_GIO_PBT: Định nghĩa đơn ví tính là giờ hay phút (0 - dùng giờ, 1 dùng phút )


                //1.	PBT_THEO_GIO=0: Số giờ theo ngày giờ
                //-	Nhập từ ngày giờ đến ngày giờ thì tính ra số giờ
                //-	Nhập từ ngày giờ và số giờ thì tính ra đến ngày giờ
                //-	Nhập đến ngày giờ và số giờ thì tính ra từ ngày giờ
                //-	Thay đổi từ ngày giờ , đến ngày giờ thì tính lại số giờ
                //-	Thay đổi số giờ thì tính lại đến ngày giờ
                //2.	PBT_THEO_GIO=1: Số giờ không theo ngày giờ
                //-	Nhập từ ngày giờ, đến ngày giờ thì tính default số giờ. 
                //-	Sửa số giờ thì chỉ cập nhật lại từ ngày giờ hoặc đến ngày giờ trong trường hợp bị null, ngược lại k cập nhật gì hết
                //-	Kiểm soát số giờ k dc nhỏ hơn 0


                double dSoPGio = 0;
                double dSGLuoi = 0;
                DateTime TNgayGio = default(DateTime);
                DateTime DNgayGio = default(DateTime);
                //TrangThai = optTrangThai.SelectedIndex;
                try
                {
                    dSGLuoi = TrangThai == 0 ? Convert.ToDouble(grvKHNhanVien.GetDataRow(iRow)["TONG_GIO_KH"].ToString()) : Convert.ToDouble(grvKHNhanVien.GetDataRow(iRow)["SO_GIO"].ToString());
                }
                catch
                {
                    dSGLuoi = 0;
                }


                TNgayGio = Convert.ToDateTime(dTNgay + " " + dTGio, new CultureInfo("vi-vn"));
                DNgayGio = Convert.ToDateTime(dDNgay + " " + dDGio, new CultureInfo("vi-vn"));
                try
                {
                    //iPhutGioPBT =          PHUT_GIO_PBT: Định nghĩa đơn ví tính là giờ hay phút (0 - dùng giờ, 1 dùng phút )
                    if (Commons.Modules.iPhutGioPBT == 1)
                    {
                        dSoPGio = (DNgayGio - TNgayGio).TotalMinutes;
                    }
                    else
                    {
                        dSoPGio = Math.Round(Convert.ToDouble((DNgayGio - TNgayGio).TotalMinutes / 60), 2);
                    }
                }
                catch
                {
                    dSoPGio = 0;
                }
                Commons.Modules.SQLString = "0NS";

                if (Commons.Modules.iPBTTheoGio == 0)
                {
                    grvKHNhanVien.SetRowCellValue(iRow, TrangThai == 0 ? "TONG_GIO_KH" : "SO_GIO", dSoPGio);

                    if (TrangThai == 0)
                    {
                        if ((grvKHNhanVien.GetDataRow(iRow)["NGAY_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["NGAY_KH"].ToString().Trim())) | (grvKHNhanVien.GetDataRow(iRow)["TU_GIO_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["TU_GIO_KH"].ToString())) | (grvKHNhanVien.GetDataRow(iRow)["DEN_NGAY_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["DEN_NGAY_KH"].ToString())) | (grvKHNhanVien.GetDataRow(iRow)["DEN_GIO_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["DEN_GIO_KH"].ToString())))
                        {
                            grvKHNhanVien.SetRowCellValue(iRow, TrangThai == 0 ? "TONG_GIO_KH" : "SO_GIO", 0);
                        }
                    }
                    else
                    {
                        if ((grvKHNhanVien.GetDataRow(iRow)["NGAY"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["NGAY"].ToString().Trim())) | (grvKHNhanVien.GetDataRow(iRow)["TU_GIO"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["TU_GIO"].ToString())) | (grvKHNhanVien.GetDataRow(iRow)["DEN_NGAY"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["DEN_NGAY"].ToString())) | (grvKHNhanVien.GetDataRow(iRow)["DEN_GIO"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["DEN_GIO"].ToString())))
                        {
                            grvKHNhanVien.SetRowCellValue(iRow, TrangThai == 0 ? "TONG_GIO_KH" : "SO_GIO", 0);
                        }
                    }
                }
                if (Commons.Modules.iPBTTheoGio == 1 & dSGLuoi <= 0)
                {
                    grvKHNhanVien.SetRowCellValue(iRow, TrangThai == 0 ? "TONG_GIO_KH" : "SO_GIO", dSoPGio);

                    if (TrangThai == 0)
                    {
                        if ((grvKHNhanVien.GetDataRow(iRow)["NGAY_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["NGAY_KH"].ToString().Trim())) & (grvKHNhanVien.GetDataRow(iRow)["TU_GIO_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["TU_GIO_KH"].ToString())) & (grvKHNhanVien.GetDataRow(iRow)["DEN_NGAY_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["DEN_NGAY_KH"].ToString())) & (grvKHNhanVien.GetDataRow(iRow)["DEN_GIO_KH"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["DEN_GIO_KH"].ToString())))
                        {
                            grvKHNhanVien.SetRowCellValue(iRow, TrangThai == 0 ? "TONG_GIO_KH" : "SO_GIO", 0);
                        }
                    }
                    else
                    {
                        if ((grvKHNhanVien.GetDataRow(iRow)["NGAY"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["NGAY"].ToString().Trim())) & (grvKHNhanVien.GetDataRow(iRow)["TU_GIO"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["TU_GIO"].ToString())) & (grvKHNhanVien.GetDataRow(iRow)["DEN_NGAY"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["DEN_NGAY"].ToString())) & (grvKHNhanVien.GetDataRow(iRow)["DEN_GIO"] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(iRow)["DEN_GIO"].ToString())))
                        {
                            grvKHNhanVien.SetRowCellValue(iRow, TrangThai == 0 ? "TONG_GIO_KH" : "SO_GIO", 0);
                        }
                    }
                }



                ReupdateTemporaryDataWhenDataHasChanged(iRow);
                Commons.Modules.SQLString = "";
            }
            catch
            {
                Commons.Modules.SQLString = "";
            }
        }

        private void ReupdateTemporaryDataForStaffByWorkOrder(int rowHandle)
        {
            try
            {
                foreach (DataRow dr in dtNhanSuKeHoachTMP.Rows)
                {
                    if (dr["MS_CONG_NHAN"].ToString() == grvKHNhanVien.GetDataRow(rowHandle)["MS_CONG_NHAN"].ToString())
                    {
                        if (optTrangThai.SelectedIndex == 1)
                        {
                            if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "NGAY").Trim() == "")
                            {
                                dr["NGAY"] = DBNull.Value;
                            }
                            else
                            {
                                dr["NGAY"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["NGAY"]).ToString("yyyy/MM/dd");
                            }
                            dr["TU_GIO"] = grvKHNhanVien.GetDataRow(rowHandle)["TU_GIO"];
                            if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "DEN_NGAY").Trim() == "")
                            {
                                dr["DEN_NGAY"] = DBNull.Value;
                            }
                            else
                            {
                                dr["DEN_NGAY"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["DEN_NGAY"]).ToString("yyyy/MM/dd");
                            }
                            dr["DEN_GIO"] = grvKHNhanVien.GetDataRow(rowHandle)["DEN_GIO"];
                            dr["SO_GIO"] = grvKHNhanVien.GetDataRow(rowHandle)["SO_GIO"];
                        }
                        else
                        {
                            if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "NGAY_KH").Trim() == "")
                            {
                                dr["NGAY_KH"] = DBNull.Value;
                            }
                            else
                            {
                                dr["NGAY_KH"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["NGAY_KH"]).ToString("yyyy/MM/dd");
                            }

                            if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "DEN_NGAY_KH").Trim() == "")
                            {
                                dr["DEN_NGAY_KH"] = DBNull.Value;
                            }
                            else
                            {
                                dr["DEN_NGAY_KH"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["DEN_NGAY_KH"]).ToString("yyyy/MM/dd");
                            }
                            dr["TU_GIO_KH"] = grvKHNhanVien.GetDataRow(rowHandle)["TU_GIO_KH"];
                            dr["DEN_GIO_KH"] = grvKHNhanVien.GetDataRow(rowHandle)["DEN_GIO_KH"];
                            dr["TONG_GIO_KH"] = grvKHNhanVien.GetDataRow(rowHandle)["TONG_GIO_KH"];
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void ReupdateTemporaryDataWhenDataHasChanged(int rowHandle)
        {
            try
            {
                if (optOption.SelectedIndex == 1)
                {
                    ReupdateTemporaryDataForStaffByWorkOrder(rowHandle);
                    return;
                }

                foreach (DataRow dr in dtNhanSuKeHoachTMP.Rows)
                {

                    if ((tabCVNhanSu.SelectedTabPageIndex == 0))
                    {
                        if (dr["MS_CV"].ToString() == grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() & dr["MS_BO_PHAN"].ToString() == grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() & dr["MS_CONG_NHAN"].ToString() == grvKHNhanVien.GetDataRow(rowHandle)["MS_CONG_NHAN"].ToString() & dr["STT"].ToString() == grvKHNhanVien.GetDataRow(rowHandle)["STT"].ToString())
                        {
                            if (TrangThai == 1)
                            {
                                if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "NGAY").Trim() == "")
                                {
                                    dr["NGAY"] = DBNull.Value;
                                }
                                else
                                {
                                    dr["NGAY"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["NGAY"]).ToString("yyyy/MM/dd");
                                }

                                dr["TU_GIO"] = grvKHNhanVien.GetDataRow(rowHandle)["TU_GIO"];
                                if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "DEN_NGAY").Trim() == "")
                                {
                                    dr["DEN_NGAY"] = DBNull.Value;
                                }
                                else
                                {
                                    dr["DEN_NGAY"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["DEN_NGAY"]).ToString("yyyy/MM/dd");
                                }


                                dr["DEN_GIO"] = grvKHNhanVien.GetDataRow(rowHandle)["DEN_GIO"];
                                dr["SO_GIO"] = grvKHNhanVien.GetDataRow(rowHandle)["SO_GIO"];
                            }
                            else
                            {
                                if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "NGAY_KH").Trim() == "")
                                {
                                    dr["NGAY_KH"] = DBNull.Value;
                                }
                                else
                                {
                                    dr["NGAY_KH"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["NGAY_KH"]).ToString("yyyy/MM/dd");
                                }

                                if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "DEN_NGAY_KH").Trim() == "")
                                {
                                    dr["DEN_NGAY_KH"] = DBNull.Value;
                                }
                                else
                                {
                                    dr["DEN_NGAY_KH"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["DEN_NGAY_KH"]).ToString("yyyy/MM/dd");
                                }

                                dr["TU_GIO_KH"] = grvKHNhanVien.GetDataRow(rowHandle)["TU_GIO_KH"];
                                dr["DEN_GIO_KH"] = grvKHNhanVien.GetDataRow(rowHandle)["DEN_GIO_KH"];
                                dr["TONG_GIO_KH"] = grvKHNhanVien.GetDataRow(rowHandle)["TONG_GIO_KH"];
                            }
                        }
                    }
                    else
                    {

                        if ((dr["MS_CV"].ToString() == grvCVPhuNS.GetFocusedDataRow()["STT"].ToString() & dr["MS_BO_PHAN"].ToString() == grvCVPhuNS.GetFocusedDataRow()["STT"].ToString() & dr["MS_CONG_NHAN"].ToString() == grvKHNhanVien.GetDataRow(rowHandle)["MS_CONG_NHAN"].ToString() & dr["ID_STT"].ToString() == grvKHNhanVien.GetDataRow(rowHandle)["ID_STT"].ToString()))
                        {
                            if (TrangThai == 1)
                            {
                                if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "NGAY").Trim() == "")
                                {
                                    dr["NGAY"] = DBNull.Value;
                                }
                                else
                                {
                                    dr["NGAY"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["NGAY"]).ToString("yyyy/MM/dd");
                                }

                                dr["TU_GIO"] = grvKHNhanVien.GetDataRow(rowHandle)["TU_GIO"];
                                if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "DEN_NGAY").Trim() == "")
                                {
                                    dr["DEN_NGAY"] = DBNull.Value;
                                }
                                else
                                {
                                    dr["DEN_NGAY"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["DEN_NGAY"]).ToString("yyyy/MM/dd");
                                }
                                dr["DEN_GIO"] = grvKHNhanVien.GetDataRow(rowHandle)["DEN_GIO"];
                                dr["SO_GIO"] = grvKHNhanVien.GetDataRow(rowHandle)["SO_GIO"];
                            }
                            else
                            {
                                if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "NGAY_KH").Trim() == "")
                                {
                                    dr["NGAY_KH"] = DBNull.Value;
                                }
                                else
                                {
                                    dr["NGAY_KH"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["NGAY_KH"]).ToString("yyyy/MM/dd");
                                }

                                if (grvKHNhanVien.GetRowCellDisplayText(rowHandle, "DEN_NGAY_KH").Trim() == "")
                                {
                                    dr["DEN_NGAY_KH"] = DBNull.Value;
                                }
                                else
                                {
                                    dr["DEN_NGAY_KH"] = Convert.ToDateTime(grvKHNhanVien.GetDataRow(rowHandle)["DEN_NGAY_KH"]).ToString("yyyy/MM/dd");
                                }
                                dr["TU_GIO_KH"] = grvKHNhanVien.GetDataRow(rowHandle)["TU_GIO_KH"];
                                dr["DEN_GIO_KH"] = grvKHNhanVien.GetDataRow(rowHandle)["DEN_GIO_KH"];
                                dr["TONG_GIO_KH"] = grvKHNhanVien.GetDataRow(rowHandle)["TONG_GIO_KH"];
                            }
                        }
                    }

                }
            }
            catch
            {
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            (ParentForm).Close();
        }

        private void btnCNhapGKH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sMsMay))
                return;
            if (string.IsNullOrEmpty(sMsPBT))
                return;

            if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgBanMuonCapNhapLaiSoGioKeHoach", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                return;
            string sSql = null;
            try
            {
                sSql = " UPDATE CAU_TRUC_THIET_BI_CONG_VIEC SET TG_KH = TGIO FROM CAU_TRUC_THIET_BI_CONG_VIEC T1 INNER JOIN (SELECT MS_BO_PHAN,MS_CV, N'" + sMsMay + "' AS MS_MAY , SUM(SO_GIO) AS TGIO FROM PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET  WHERE MS_PHIEU_BAO_TRI = N'" + sMsPBT + "'GROUP BY MS_BO_PHAN,MS_CV) T2 ON T1.MS_MAY = T2.MS_MAY AND T1.MS_BO_PHAN = T2.MS_BO_PHAN AND T1.MS_CV = T2.MS_CV ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            }
            catch (Exception ex)
            {
            }

        }

        private void btnTinhcuasobaotri_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(sMsPBT))
                return;


            JOBCARD_Controller objController = new JOBCARD_Controller();
            DataTable dt = new DataTable();
            dt = objController.get_Cuasobaotri(sMsMay, ngayBDKH.ToString("yyyy/dd/MM"), ngayKTKH.ToString("yyyy/dd/MM"));
            try
            {
                grdCSBaoTri.DataSource = null;
                grvCSBaoTri.Columns.Clear();

            }
            catch (Exception ex)
            {
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCSBaoTri, grvCSBaoTri, dt, false, true, true, true, true, "frmPhieuBaoTri_New");
            try
            {
                grvCSBaoTri.Columns["THU"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grvCSBaoTri.Columns["FROM_HOUR"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grvCSBaoTri.Columns["TO_HOUR"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
            }
            if (btnGhi.Visible)
            {
                if (grvCSBaoTri.RowCount > 0)
                {
                    //btnCapnhatthoigiancongviec.Visible = true;
                }
                else
                {
                    //  btnCapnhatthoigiancongviec.Visible = false;
                }
            }

        }

        public void Enable_Button(bool bln)
        {
            this.btnThemsua.Enabled = bln;
            this.btnCopyNS.Enabled = bln;
            this.btnXoa.Enabled = bln;
            btnHThanhNS.Enabled = bln;
            btnTinhcuasobaotri.Enabled = bln;
        }


        private void grvKHNhanVien_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            if (btnGhi.Visible == false)
                return;
            if (Commons.Modules.SQLString == "0NS")
                return;
            //TrangThai = optTrangThai.SelectedIndex;
            string dTNgay = "";
            string dTGio = "";
            string dDNgay = "";
            string dDGio = "";
            try
            {
                try
                {
                    dTNgay = optTrangThai.SelectedIndex == 0 ? grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "NGAY_KH") : grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "NGAY");
                    dDNgay = optTrangThai.SelectedIndex == 0 ? grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_NGAY_KH") : grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_NGAY");
                    if (optTrangThai.SelectedIndex == 1)
                    {
                        try
                        {
                            DateTime dt = Convert.ToDateTime(dTNgay, new CultureInfo("vi-vn"));
                            if (dt > DateTime.Now)
                            {
                                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgNgayBDThucTeLonHonNgayHienTai", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    e.Valid = false;
                                    return;
                                }
                            }
                        }
                        catch { }

                        try
                        {
                            DateTime dt = Convert.ToDateTime(dDNgay, new CultureInfo("vi-vn"));
                            if (dt > DateTime.Now)
                            {
                                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgDenNgayThucTeLonHonNgayHienTai", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    e.Valid = false;
                                    return;
                                }
                            }
                        }
                        catch { }

                    }
                }
                catch
                {
                    dTNgay = "";
                    dDNgay = "";
                }
                try
                {
                    dTGio = optTrangThai.SelectedIndex == 0 ? grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "TU_GIO_KH") : grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "TU_GIO");
                }
                catch
                {
                    dTGio = "";
                }
                try
                {
                    dDNgay = optTrangThai.SelectedIndex == 0 ? grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_NGAY_KH") : grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_NGAY");
                }
                catch
                {
                    dDNgay = "";
                }
                try
                {
                    dDGio = optTrangThai.SelectedIndex == 0 ? grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_GIO_KH") : grvKHNhanVien.GetRowCellDisplayText(e.RowHandle, "DEN_GIO");
                }
                catch
                {
                    dDGio = "";
                }
                DateTime TNgayGio, DNgayGio;
                try
                {
                    TNgayGio = Convert.ToDateTime(dTNgay + " " + dTGio);
                }
                catch
                {
                    TNgayGio = Convert.ToDateTime(null);
                }

                try
                {
                    DNgayGio = Convert.ToDateTime(dDNgay + " " + dDGio);
                }
                catch
                {
                    DNgayGio = Convert.ToDateTime(null);
                }
                ReupdateTemporaryDataWhenDataHasChanged(e.RowHandle);
                //string dTNgay = "";
                //string dTGio = "";
                //string dDNgay = "";
                //string dDGio = "";
                //if (TNgayGio != Convert.ToDateTime( "01/01/0001 00:00:00") && DNgayGio != Convert.ToDateTime("01/01/0001 00:00:00"))

                if (!string.IsNullOrEmpty(dTNgay) & !string.IsNullOrEmpty(dTGio) & !string.IsNullOrEmpty(dDNgay) & !string.IsNullOrEmpty(dDGio))
                {
                    if (TNgayGio > DNgayGio)
                    {

                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgTuNgayLonHonDenNgay", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Commons.Modules.SQLString = "0NS";

                        grvKHNhanVien.SetFocusedRowCellValue(optTrangThai.SelectedIndex == 0 ? "TONG_GIO_KH" : "SO_GIO", 0);

                        Commons.Modules.SQLString = "";
                        e.Valid = false;
                        return;
                    }
                }

            }
            catch
            {
            }

        }
        private void grvKHNhanVien_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

        }

        private void grvKHNhanVien_ShownEditor(object sender, EventArgs e)
        {
            if (btnGhi.Visible == false) return;
            GridView View = (GridView)sender;
            Point pt = View.GridControl.PointToClient(Control.MousePosition);
            DoRowNhanSuClick(View, pt);

        }

        private void DoRowNhanSuClick(GridView view, Point pt)
        {
            string tuNgay = optTrangThai.SelectedIndex == 0 ? "NGAY_KH" : "NGAY";
            string denNgay = optTrangThai.SelectedIndex == 0 ? "DEN_NGAY_KH" : "DEN_NGAY";
            string tuGio = optTrangThai.SelectedIndex == 0 ? "TU_GIO_KH" : "TU_GIO";
            string denGio = optTrangThai.SelectedIndex == 0 ? "DEN_GIO_KH" : "DEN_GIO";

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(pt);
            if ((info.InRow | info.InRowCell))
            {
                if ((info.Column.FieldName == tuNgay))
                {
                    if ((grvKHNhanVien.GetDataRow(info.RowHandle)[tuNgay] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(info.RowHandle)[tuNgay].ToString())))
                    {
                        grvKHNhanVien.SetRowCellValue(info.RowHandle, tuNgay, DateTime.Now.ToString("dd/MM/yyyy"));

                    }
                }
                if ((info.Column.FieldName == denNgay))
                {
                    if ((grvKHNhanVien.GetDataRow(info.RowHandle)[denNgay] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(info.RowHandle)[denNgay].ToString())))
                    {
                        grvKHNhanVien.SetRowCellValue(info.RowHandle, denNgay, DateTime.Now.ToString("dd/MM/yyyy"));
                    }
                }
                if ((info.Column.FieldName == tuGio))
                {
                    if ((grvKHNhanVien.GetDataRow(info.RowHandle)[tuGio] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(info.RowHandle)[tuGio].ToString())))
                    {
                        grvKHNhanVien.SetRowCellValue(info.RowHandle, tuGio, DateTime.Now.ToString("HH:mm"));
                    }
                }
                if ((info.Column.FieldName == denGio))
                {
                    if ((grvKHNhanVien.GetDataRow(info.RowHandle)[denGio] == null | string.IsNullOrEmpty(grvKHNhanVien.GetDataRow(info.RowHandle)[denGio].ToString())))
                    {
                        grvKHNhanVien.SetRowCellValue(info.RowHandle, denGio, DateTime.Now.ToString("HH:mm"));
                    }
                }
            }
        }

        private void grvCVChinhNS_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if (btnGhi.Visible == false) return;
                string str = "";
                if (grvCVChinhNS.GetFocusedDataRow()["NGAY_HOAN_THANH"] != null || !string.IsNullOrEmpty(grvCVChinhNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString()))
                {
                    try
                    {
                        Convert.ToDateTime(grvCVChinhNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString());
                    }
                    catch
                    {
                        if (grvCVChinhNS.GetFocusedRowCellDisplayText("NGAY_HOAN_THANH").ToString().Trim() == "")
                        {
                            string str1 = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=NULL WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str1);
                            btnThemsua.Enabled = true;
                            if (tabCVNhanSu.SelectedTabPageIndex == 0) btnCopyNS.Enabled = true; else btnCopyNS.Enabled = false;
                            btnXoa.Enabled = true;
                            btnHThanhNS.Enabled = true;
                            btnTinhcuasobaotri.Enabled = true;
                            return;
                        }

                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "MsgNgayHoanThanh", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grvCVChinhNS.FocusedColumn = grvCVChinhNS.Columns["NGAY_HOAN_THANH"];
                        e.Valid = false;
                        return;
                    }

                    SqlDataReader objReader;
                    str = "SELECT NGAY_HOAN_THANH FROM  PHIEU_BAO_TRI_CONG_VIEC  WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    while (objReader.Read())
                    {
                        if (!string.IsNullOrEmpty(objReader["NGAY_HOAN_THANH"].ToString()))
                        {
                            if (Convert.ToDateTime(objReader["NGAY_HOAN_THANH"].ToString()).Date != Convert.ToDateTime(grvCVChinhNS.GetFocusedDataRow()["NGAY_HOAN_THANH"]).Date)
                            {
                                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH= '" + Convert.ToDateTime(grvCVChinhNS.GetFocusedDataRow()["NGAY_HOAN_THANH"]).ToString("yyyy/MM/dd") + "' WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                            }
                            objReader.Close();
                            return;
                        }
                    }
                    str = "SELECT MS_CONG_NHAN from PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET WHERE HOAN_THANH=1 AND MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                    objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    bool tmp = false;
                    while (objReader.Read())
                    {
                        if (!string.IsNullOrEmpty(objReader["MS_CONG_NHAN"].ToString()))
                        {
                            tmp = true;
                            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" + grvCVChinhNS.GetFocusedDataRow()["NGAY_HOAN_THANH"] + "',103) WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                            btnThemsua.Enabled = false;
                            btnCopyNS.Enabled = false;
                            btnXoa.Enabled = false;
                            btnHThanhNS.Enabled = false;
                            btnTinhcuasobaotri.Enabled = false;
                            objReader.Close();
                            e.Valid = true;
                            return;
                        }
                    }
                    objReader.Close();
                    if (!tmp)
                    {
                        if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "Msgghi", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            grvCVChinhNS.SetFocusedRowCellValue("NGAY_HOAN_THANH", null);
                            return;
                        }
                        else
                        {
                            Commons.Modules.SQLString = "0Load";
                            grvCVChinhNS.SetFocusedRowCellValue("H_THANH", true);
                            grvCVChinhNS.SetFocusedRowCellValue("PT_HOAN_THANH", 100);
                            Commons.Modules.SQLString = "";

                            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET H_THANH = 1 ,PT_HOAN_THANH= 100, " + " NGAY_HOAN_THANH=CONVERT(DATETIME,'" + grvCVChinhNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString() + "',103) WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

                            try
                            {
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapHoanThanhKHTT", sMsPBT, grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString(), grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), 100);

                            }
                            catch (Exception ex)
                            {
                            }
                            btnThemsua.Enabled = false;
                            btnCopyNS.Enabled = false;
                            btnXoa.Enabled = false;
                            btnHThanhNS.Enabled = false;
                            btnTinhcuasobaotri.Enabled = false;
                        }
                    }
                }
            }
            catch { e.Valid = false; }
        }

        private void grvCVChinhNS_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string str = "";
            if (Commons.Modules.SQLString == "0Load") return;
            if (e.Column.FieldName == "H_THANH")
            {
                if (Convert.ToBoolean(e.Value.ToString()) == true)
                {
                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET H_THANH= 1, PT_HOAN_THANH = 100, NGAY_HOAN_THANH = '" + DateTime.Now.ToString("yyyy/MM/dd") + "' WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    Commons.Modules.SQLString = "0Load";
                    grvCVChinhNS.SetFocusedRowCellValue("PT_HOAN_THANH", 100);
                    try
                    {
                        Convert.ToDateTime(grvCVChinhNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString());
                    }
                    catch { grvCVChinhNS.SetFocusedRowCellValue("NGAY_HOAN_THANH", DateTime.Now.ToString("yyyy/MM/dd")); }
                    Commons.Modules.SQLString = "";
                    try
                    {
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapHoanThanhKHTT", sMsPBT, grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString(), grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), 100);
                    }
                    catch (Exception ex)
                    {
                    }

                }
                else
                {
                    str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET H_THANH= 0 WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                return;
            }

            if (e.Column.FieldName == "DANH_GIA")
            {
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET DANH_GIA= N'" + grvCVChinhNS.GetFocusedDataRow()["DANH_GIA"].ToString() + "' WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                return;
            }
            if (e.Column.FieldName == "PT_HOAN_THANH")
            {
                if (Convert.ToInt32(e.Value) > 100)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "msgPhanTramLonHon100", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grvCVChinhNS.FocusedColumn = grvCVChinhNS.Columns["PT_HOAN_THANH"];
                    return;
                }
                str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET PT_HOAN_THANH= " + e.Value.ToString() + " WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapHoanThanhKHTT", sMsPBT, grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString(), grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), e.Value.ToString());

                }
                catch (Exception ex)
                {
                }
                return;
            }
        }

        private void grvCVChinhNS_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvCVPhuNS_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvCVPhuNS_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string tmp = "";
                Convert.ToDateTime(grvCVPhuNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString());

                SqlDataReader objReader = null;
                tmp = "SELECT NGAY_HOAN_THANH FROM PHIEU_BAO_TRI_CV_PHU_TRO WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND STT=" + grvCVPhuNS.GetFocusedDataRow()["STT"].ToString();
                objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, tmp);

                while (objReader.Read())
                {
                    if (!string.IsNullOrEmpty(objReader["NGAY_HOAN_THANH"].ToString()))
                    {
                        if (Convert.ToDateTime(objReader["NGAY_HOAN_THANH"].ToString()).Date != Convert.ToDateTime(grvCVPhuNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString()).Date)
                        {
                            tmp = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH='" + Convert.ToDateTime(grvCVPhuNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString()).ToString("yyyy/MM/dd") + "' WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND STT=" + grvCVPhuNS.GetFocusedDataRow()["STT"].ToString();
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, tmp);

                        }
                        objReader.Close();
                        e.Valid = true;
                        return;
                    }
                }
                objReader.Close();
                tmp = "SELECT MS_CONG_NHAN from PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_PHU_TRO WHERE HOAN_THANH=1 AND MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND STT=" + grvCVPhuNS.GetFocusedDataRow()["STT"].ToString();
                objReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, tmp);
                bool flag = false;
                while (objReader.Read())
                {
                    if (!string.IsNullOrEmpty(objReader["MS_CONG_NHAN"].ToString()))
                    {
                        flag = true;
                        tmp = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH= '" + Convert.ToDateTime(grvCVPhuNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString()).ToString("yyyy/MM/dd") + "' WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND STT=" + grvCVPhuNS.GetFocusedDataRow()["STT"].ToString();
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, tmp);
                        btnThemsua.Enabled = false;
                        btnCopyNS.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHThanhNS.Enabled = false;
                        btnTinhcuasobaotri.Enabled = false;
                        objReader.Close();
                        return;
                    }
                }
                objReader.Close();
                if (!flag)
                {
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "Msgghi", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        Commons.Modules.SQLString = "0Load";
                        grvCVPhuNS.SetFocusedRowCellValue("NGAY_HOAN_THANH", null);
                        grvCVPhuNS.SetFocusedRowCellValue("SO_GIO_KH", null);
                        Commons.Modules.SQLString = "";
                        return;
                    }
                    else
                    {
                        tmp = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH='" + Convert.ToDateTime(grvCVPhuNS.GetFocusedDataRow()["NGAY_HOAN_THANH"].ToString()).ToString("yyyy/MM/dd") + "' WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND STT=" + grvCVPhuNS.GetFocusedDataRow()["STT"].ToString();
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, tmp);
                        btnThemsua.Enabled = false;
                        btnCopyNS.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHThanhNS.Enabled = false;
                        btnTinhcuasobaotri.Enabled = false;
                    }
                }
            }
            catch
            {
                if (grvCVPhuNS.GetFocusedRowCellDisplayText("NGAY_HOAN_THANH").ToString().Trim() == "")
                {
                    string str = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=NULL WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND STT=" + grvCVPhuNS.GetFocusedDataRow()["STT"].ToString();
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    btnThemsua.Enabled = true;
                    if (tabCVNhanSu.SelectedTabPageIndex == 0) btnCopyNS.Enabled = true; else btnCopyNS.Enabled = false;
                    btnXoa.Enabled = true;
                    btnHThanhNS.Enabled = true;
                    btnTinhcuasobaotri.Enabled = true;
                    return;
                }
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "MsgNgayhoanThanh", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grvCVPhuNS.FocusedColumn = grvCVPhuNS.Columns["NGAY_HOAN_THANH"];
                e.Valid = false;
                return;
            }
        }

        private void optTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrangThai = optTrangThai.SelectedIndex;
            if (grdKHNhanVien.DataSource == null) return;
            if (optTrangThai.SelectedIndex == 0)
            {
                grvKHNhanVien.Columns["NGAY_KH"].Visible = true;
                grvKHNhanVien.Columns["TU_GIO_KH"].Visible = true;
                grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = true;
                grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = true;
                grvKHNhanVien.Columns["TONG_GIO_KH"].Visible = true;
                grvKHNhanVien.Columns["NGAY_KH"].VisibleIndex = 1;
                grvKHNhanVien.Columns["TU_GIO_KH"].VisibleIndex = 2;
                grvKHNhanVien.Columns["DEN_NGAY_KH"].VisibleIndex = 3;
                grvKHNhanVien.Columns["DEN_GIO_KH"].VisibleIndex = 4;
                grvKHNhanVien.Columns["TONG_GIO_KH"].VisibleIndex = 5;
                grvKHNhanVien.Columns["NGAY"].Visible = false;
                grvKHNhanVien.Columns["TU_GIO"].Visible = false;
                grvKHNhanVien.Columns["DEN_GIO"].Visible = false;
                grvKHNhanVien.Columns["DEN_NGAY"].Visible = false;
                grvKHNhanVien.Columns["SO_GIO"].Visible = false;
            }
            else
            {
                grvKHNhanVien.Columns["NGAY"].Visible = true;
                grvKHNhanVien.Columns["TU_GIO"].Visible = true;
                grvKHNhanVien.Columns["DEN_GIO"].Visible = true;
                grvKHNhanVien.Columns["DEN_NGAY"].Visible = true;
                grvKHNhanVien.Columns["SO_GIO"].Visible = true;
                grvKHNhanVien.Columns["NGAY"].VisibleIndex = 1;
                grvKHNhanVien.Columns["TU_GIO"].VisibleIndex = 2;
                grvKHNhanVien.Columns["DEN_NGAY"].VisibleIndex = 3;
                grvKHNhanVien.Columns["DEN_GIO"].VisibleIndex = 4;
                grvKHNhanVien.Columns["SO_GIO"].VisibleIndex = 5;
                grvKHNhanVien.Columns["NGAY_KH"].Visible = false;
                grvKHNhanVien.Columns["TU_GIO_KH"].Visible = false;
                grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = false;
                grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = false;
                grvKHNhanVien.Columns["TONG_GIO_KH"].Visible = false;
            }
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvKHNhanVien, "frmPhieuBaoTri_NEW");
            grvKHNhanVien.Columns["SO_GIO"].Caption = Commons.Modules.iPBTTheoGio == 0 ? Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT", Commons.Modules.TypeLanguage) : Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO", Commons.Modules.TypeLanguage);
            //grvKHNhanVien.Columns["TONG_GIO_KH"].Caption = Commons.Modules.iPBTTheoGio == 0 ? Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT_KH", Commons.Modules.TypeLanguage) : Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "TONG_GIO_KH", Commons.Modules.TypeLanguage);
            grvKHNhanVien.Columns["TONG_GIO_KH"].Caption = Commons.Modules.iPBTTheoGio == 0 ? Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT_KH", Commons.Modules.TypeLanguage) : Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "TONG_GIO_KH", Commons.Modules.TypeLanguage);
            if (btnGhi.Visible == false) return;

            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(BarManagerNS);
            popup = BarManagerNS.GetPopupContextMenu(grdKHNhanVien);

            popup.ItemLinks[4].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", optTrangThai.SelectedIndex == 0 ? "mnuChuyenGioKHQuaTTDangChon" : "mnuChuyenGioTTQuaKHDangChon", Commons.Modules.TypeLanguage);

            popup.ItemLinks[5].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", optTrangThai.SelectedIndex == 0 ? "mnuChuyenGioKHQuaTTAll" : "mnuChuyenGioTTQuaKHAll", Commons.Modules.TypeLanguage);

            popup.ItemLinks[6].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", optTrangThai.SelectedIndex == 0 ? "mnuChuyenTatCaGioKHQuaTatCaGioTT" : "mnuChuyenTatCaGioTTQuaTatCaGioKH", Commons.Modules.TypeLanguage);
        }

        public void LoadFormNSPBT()
        {
            optTrangThai.SelectedIndex = 1;
            TrangThai = optTrangThai.SelectedIndex;
            if (Commons.Modules.sPrivate.ToUpper() == "GREENFEED") optOption.Visible = false;
            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                btnThemsua.Visible = false;
                btnCopyNS.Visible = false;
                btnTinhcuasobaotri.Visible = false;
                btnXoa.Visible = false;
                btnHThanhNS.Visible = false;
            }
            KiemLoadCV();
            LoadSoGioSoPhut();
        }

        private void LoadSoGioSoPhut()
        {
            //iPhutGioPBT =          PHUT_GIO_PBT: Định nghĩa đơn ví tính là giờ hay phút (0 - dùng giờ, 1 dùng phút )
            try
            {
                if (Commons.Modules.iPhutGioPBT == 1)
                {
                    grvKHNhanVien.Columns["SO_GIO"].DisplayFormat.FormatString = "#,###,###,###,##0";
                    grvKHNhanVien.Columns["SO_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    grvKHNhanVien.Columns["TONG_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0";
                    grvKHNhanVien.Columns["TONG_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                    grvKHNhanVien.Columns["SO_GIO"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT", Commons.Modules.TypeLanguage);
                    grvKHNhanVien.Columns["TONG_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT_KH", Commons.Modules.TypeLanguage);
                }
                else
                {
                    grvKHNhanVien.Columns["SO_GIO"].DisplayFormat.FormatString = "#,###,###,###,##0.#00";
                    grvKHNhanVien.Columns["SO_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    grvKHNhanVien.Columns["TONG_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0.#00";
                    grvKHNhanVien.Columns["TONG_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                    grvKHNhanVien.Columns["SO_GIO"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO", Commons.Modules.TypeLanguage);
                    grvKHNhanVien.Columns["TONG_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "TONG_GIO_KH", Commons.Modules.TypeLanguage);
                }
            }
            catch { }
        }


        public void optOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (optOption.SelectedIndex == 0)
            {
                tabCVNhanSu.Enabled = true;
                tabCVNhanSu_SelectedPageChanged(null, null);
            }
            else
            {
                tabCVNhanSu.Enabled = false;
                BindDataStaffByWorkOrder();
            }
            this.Cursor = Cursors.Default;
        }

        private delegate void BindDataStaffByWO();
        public void BindDataStaffByWorkOrder()
        {
            if (bLoadNS) return;
            if (grdKHNhanVien.InvokeRequired)
            {
                grdKHNhanVien.Invoke(new BindDataStaffByWO(BindDataStaffByWorkOrder), null);
            }
            else
            {
                try
                {
                    lblKH.Text = "";
                    grdKHNhanVien.DataSource = null;
                }
                catch
                {
                }
                TBNhanVien = new DataTable();
                if (btnGhi.Visible == true)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHNhanVien, grvKHNhanVien, dtNhanSuKeHoachTMP.Copy(), true, true, true, false, true, "frmPhieuBaoTri_New");
                    grvKHNhanVien.Columns["TEN_CONG_NHAN"].OptionsColumn.AllowEdit = false;
                    grvKHNhanVien.Columns["MS_CV"].Visible = false;
                    grvKHNhanVien.Columns["MS_BO_PHAN"].Visible = false;
                }
                else
                {
                    TBNhanVien.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetStaffByWorkOrder", sMsPBT));
                    TBNhanVien.Columns["TEN_CONG_NHAN"].ReadOnly = false;
                    TBNhanVien.Columns["TU_GIO"].ReadOnly = false;
                    TBNhanVien.Columns["THUE_NGOAI"].ReadOnly = false;
                    TBNhanVien.Columns["DEN_GIO"].ReadOnly = false;
                    TBNhanVien.Columns["NGAY"].ReadOnly = false;
                    TBNhanVien.Columns["DEN_NGAY"].ReadOnly = false;
                    TBNhanVien.Columns["TU_GIO_KH"].ReadOnly = false;
                    TBNhanVien.Columns["DEN_GIO_KH"].ReadOnly = false;
                    TBNhanVien.Columns["NGAY_KH"].ReadOnly = false;
                    TBNhanVien.Columns["DEN_NGAY_KH"].ReadOnly = false;
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdKHNhanVien, grvKHNhanVien, TBNhanVien.Copy(), false, true, true, false, true, "frmPhieuBaoTri_New");
                }
                grvKHNhanVien.Columns["MS_CN"].Visible = false;
                grvKHNhanVien.Columns["THUE_NGOAI"].Visible = false;
                grvKHNhanVien.Columns["HOAN_THANH"].Visible = false;
                grvKHNhanVien.Columns["TEN_CONG_NHAN"].MinWidth = 180;
                grvKHNhanVien.Columns["THUE_NGOAI"].MinWidth = 80;
                grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width = grvKHNhanVien.Columns["TEN_CONG_NHAN"].Width - 20;
                grvKHNhanVien.Columns["MS_CONG_NHAN"].Visible = false;
                grvKHNhanVien.Columns["STT"].Visible = false;
                try
                {
                    RepositoryItemTimeEdit cboTuGio = new RepositoryItemTimeEdit();
                    RepositoryItemTimeEdit cboDenGio = new RepositoryItemTimeEdit();
                    RepositoryItemDateEdit cboDenNgay = new RepositoryItemDateEdit();
                    RepositoryItemDateEdit cboNgay = new RepositoryItemDateEdit();
                    cboTuGio.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    cboDenGio.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    cboDenNgay.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    cboNgay.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                    grvKHNhanVien.Columns["NGAY"].ColumnEdit = cboNgay;
                    grvKHNhanVien.Columns["TU_GIO"].ColumnEdit = cboTuGio;
                    grvKHNhanVien.Columns["DEN_GIO"].ColumnEdit = cboDenGio;
                    grvKHNhanVien.Columns["DEN_NGAY"].ColumnEdit = cboDenNgay;
                    grvKHNhanVien.Columns["NGAY"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["TU_GIO"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["DEN_GIO"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["DEN_NGAY"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["TU_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";

                    grvKHNhanVien.Columns["TU_GIO"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO"].ColumnEdit.EditFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO"].ColumnEdit.EditFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";

                    grvKHNhanVien.Columns["NGAY_KH"].ColumnEdit = cboNgay;
                    grvKHNhanVien.Columns["TU_GIO_KH"].ColumnEdit = cboTuGio;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].ColumnEdit = cboDenGio;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].ColumnEdit = cboDenNgay;
                    grvKHNhanVien.Columns["NGAY_KH"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["TU_GIO_KH"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["DEN_GIO_KH"].ColumnEdit.NullText = "";
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].ColumnEdit.NullText = "";

                    grvKHNhanVien.Columns["TU_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO_KH"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO_KH"].DisplayFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].DisplayFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY_KH"].DisplayFormat.FormatString = "dd/MM/yyyy";

                    grvKHNhanVien.Columns["TU_GIO_KH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["NGAY_KH"].ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvKHNhanVien.Columns["TU_GIO_KH"].ColumnEdit.EditFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_GIO_KH"].ColumnEdit.EditFormat.FormatString = "HH:mm";
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.Columns["NGAY_KH"].ColumnEdit.EditFormat.FormatString = "dd/MM/yyyy";
                    grvKHNhanVien.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
                    LoadLuoiSoGio();
                }
                catch
                {
                }

                if (optTrangThai.SelectedIndex == 0)
                {
                    grvKHNhanVien.Columns["NGAY_KH"].Visible = true;
                    grvKHNhanVien.Columns["TU_GIO_KH"].Visible = true;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = true;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = true;
                    grvKHNhanVien.Columns["TONG_GIO_KH"].Visible = true;

                    grvKHNhanVien.Columns["SO_GIO"].Visible = false;
                    grvKHNhanVien.Columns["NGAY"].Visible = false;
                    grvKHNhanVien.Columns["TU_GIO"].Visible = false;
                    grvKHNhanVien.Columns["DEN_GIO"].Visible = false;
                    grvKHNhanVien.Columns["DEN_NGAY"].Visible = false;
                }
                else
                {
                    grvKHNhanVien.Columns["NGAY"].Visible = true;
                    grvKHNhanVien.Columns["TU_GIO"].Visible = true;
                    grvKHNhanVien.Columns["DEN_GIO"].Visible = true;
                    grvKHNhanVien.Columns["DEN_NGAY"].Visible = true;
                    grvKHNhanVien.Columns["SO_GIO"].Visible = true;

                    grvKHNhanVien.Columns["NGAY_KH"].Visible = false;
                    grvKHNhanVien.Columns["TU_GIO_KH"].Visible = false;
                    grvKHNhanVien.Columns["DEN_GIO_KH"].Visible = false;
                    grvKHNhanVien.Columns["DEN_NGAY_KH"].Visible = false;
                    grvKHNhanVien.Columns["TONG_GIO_KH"].Visible = false;
                }
                try
                {
                    if (iTTPBTri < 4)
                    {
                        btnThemsua.Enabled = true;
                        if (tabCVNhanSu.SelectedTabPageIndex == 0) btnCopyNS.Enabled = true; else btnCopyNS.Enabled = false;
                        btnXoa.Enabled = true;
                        btnHThanhNS.Enabled = true;
                        btnTinhcuasobaotri.Enabled = true;
                        if (iTTPBTri == 3)
                        {
                            btnHThanhNS.Enabled = false;
                        }
                    }
                    else
                    {
                        btnThemsua.Enabled = false;
                        btnCopyNS.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHThanhNS.Enabled = false;
                        btnTinhcuasobaotri.Enabled = false;
                    }
                }
                catch
                {
                }
            }
            LLB();
        }

        public void OptionChanged()
        {
            Action<object, EventArgs> tmp = optOption_SelectedIndexChanged;
            tmp(null, null);
        }

        private void btnThemsua_Click(object sender, EventArgs e)
        {
            if (sMsPBT == null || sMsPBT == "")
            {
                //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "msgChuaChonPBT", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ThemNhanSuPBT();
        }

        private void btnCopyNS_Click(object sender, EventArgs e)
        {
            frmCapNhatNhanSu frm = new frmCapNhatNhanSu();
            frm.sMsPBT = sMsPBT;
            try
            {
                frm.sMsBP = grvCVChinhNS.GetFocusedDataRow()["MS_BO_PHAN"].ToString();
                frm.iMsCV = int.Parse(grvCVChinhNS.GetFocusedDataRow()["MS_CV"].ToString());
                frm.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgKhongCoCongViec", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTrucca", "THONG_BAO", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

    }
}