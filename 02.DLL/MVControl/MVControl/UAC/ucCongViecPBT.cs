using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using Commons.VS.Classes.Catalogue;
using Commons;
using DevExpress.XtraEditors.Repository;
using System.Data.SqlClient;

using System.Threading;
using MVControl.Forms;
using System.Diagnostics;

namespace MVControl
{
    public partial class ucCongViecPBT : DevExpress.XtraEditors.XtraUserControl
    {
        string sToken = "";
        public int iTTPBTri { get; set; }
        public string sMsPBT { get; set; }
        public string sMsMay { get; set; }
        public DateTime ngayBDKH { get; set; }
        public string _SynConnectionInfo { get; set; }
        public ucCongViecPBT()
        {
            InitializeComponent();
        }
        public void LoadCongViec()
        {
            if (grdCongviec.InvokeRequired)
            {
                grdCongviec.Invoke(new BindDataCongViec(LoadCongViec), null);
            }
            else
            {
                string str = "";
                DataTable dt = new DataTable();

                if (btnGhi.Visible)
                {
                    try
                    {
                        str = " UPDATE PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName + " SET TEN_BO_PHAN = T1.MS_BO_PHAN + ' - ' + T2.TEN_BO_PHAN, MSCVBT = CONVERT(NVARCHAR(250),MS_CV) +  CONVERT(NVARCHAR(250),T1.MS_BO_PHAN)  FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName + "  AS T1 INNER JOIN dbo.CAU_TRUC_THIET_BI AS T2 ON T1.MS_BO_PHAN = T2.MS_BO_PHAN WHERE MS_MAY = N'" + sMsMay + "' ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        str = "SELECT DISTINCT MS_PHIEU_BAO_TRI, MS_CV,  MA_CV, MS_BO_PHAN, MS_BO_PHAN + ' - ' + TEN_BO_PHAN as TEN_BO_PHAN, CASE ISNULL(NGAY_HOAN_THANH, '1900/01/01')  WHEN '1900/01/01' THEN (SELECT MAX(PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH) AS NGAY_HOAN_THANH FROM PHIEU_BAO_TRI INNER JOIN PHIEU_BAO_TRI_CONG_VIEC  ON PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI WHERE PHIEU_BAO_TRI.MS_MAY = N'" + sMsMay + "' AND  PHIEU_BAO_TRI_CONG_VIEC.MS_CV = T.MS_CV AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = T.MS_BO_PHAN) ELSE (SELECT MAX(PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH) AS NGAY_HOAN_THANH FROM PHIEU_BAO_TRI  INNER JOIN PHIEU_BAO_TRI_CONG_VIEC  ON PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI WHERE PHIEU_BAO_TRI.MS_MAY = N'" + sMsMay + "' AND  PHIEU_BAO_TRI_CONG_VIEC.MS_CV = T.MS_CV AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = T.MS_BO_PHAN HAVING MAX(PHIEU_BAO_TRI_CONG_VIEC.NGAY_HOAN_THANH) > T.NGAY_HOAN_THANH) END NGAY_TRUOC, NGAY_HOAN_THANH,NGAY_BDCV,NGAY_KTCV, SO_GIO_KH,SO_GIO_PB, DINH_MUC_PB, HANG_MUC_ID, TEN_HANG_MUC, EOR_ID, THUC_KIEM, GHI_CHU,  MSCVBT, THAO_TAC, TIEU_CHUAN_KT,PATH_HD, SO_NGUOI,YEU_CAU_DUNG_CU,YCSD,TON_TAI from PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName + " T ";
                        dt = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables[0];
                    }
                    catch
                    {
                    }
                }
                else
                {
                    dt = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CONG_VIECs", sMsPBT).Tables[0];
                }

                dt.DefaultView.Sort = "TEN_BO_PHAN, MA_CV";
                dt = dt.DefaultView.ToTable();
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MSCVBT"] };


                dt.Columns["SO_GIO_PB"].ReadOnly = false;
                dt.Columns["DINH_MUC_PB"].ReadOnly = false;
                dt.Columns["GHI_CHU"].ReadOnly = false;
                dt.Columns["THUC_KIEM"].ReadOnly = false;
                dt.Columns["SO_NGUOI"].ReadOnly = false;
                dt.Columns["YEU_CAU_DUNG_CU"].ReadOnly = false;
                dt.Columns["THAO_TAC"].ReadOnly = false;
                dt.Columns["TIEU_CHUAN_KT"].ReadOnly = false;
                Commons.Modules.SQLString = "0Load";
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCongviec, grvCongViec, dt, false, false, false, false, true, "FrmPhieuBaoTri_New");
                Commons.Modules.SQLString = "";
                LoadSoGioSoPhut();

                if (grvCongViec.Columns["NGAY_KTCV"].Visible == false) goto jump;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvCongViec.Columns)
                {
                    col.OptionsColumn.ReadOnly = true;
                    col.OptionsColumn.AllowEdit = false;
                }
                grvCongViec.OptionsView.RowAutoHeight = true;
                RepositoryItemMemoEdit meno = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                meno.WordWrap = true;
                meno.AutoHeight = true;
                meno.BeginInit();
                grvCongViec.Columns["TEN_BO_PHAN"].ColumnEdit = meno;
                grdCongviec.RepositoryItems.Add(meno);

                grvCongViec.Columns["TEN_BO_PHAN"].VisibleIndex = 4;
                grvCongViec.Columns["MA_CV"].VisibleIndex = 5;
                grvCongViec.Columns["NGAY_TRUOC"].VisibleIndex = 6;

                grvCongViec.Columns["SO_GIO_KH"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvCongViec.Columns["SO_GIO_KH"].OptionsColumn.AllowEdit = true;

                grvCongViec.Columns["SO_GIO_PB"].OptionsColumn.AllowEdit = true;
                grvCongViec.Columns["DINH_MUC_PB"].OptionsColumn.AllowEdit = true;
                grvCongViec.Columns["GHI_CHU"].OptionsColumn.AllowEdit = true;
                grvCongViec.Columns["THUC_KIEM"].OptionsColumn.AllowEdit = true;
                grvCongViec.Columns["SO_NGUOI"].OptionsColumn.AllowEdit = true;
                grvCongViec.Columns["YEU_CAU_DUNG_CU"].OptionsColumn.AllowEdit = true;
                grvCongViec.Columns["TIEU_CHUAN_KT"].OptionsColumn.AllowEdit = true;
                grvCongViec.Columns["THAO_TAC"].OptionsColumn.AllowEdit = true;

                grvCongViec.Columns["SO_GIO_KH"].OptionsColumn.ReadOnly = false;
                grvCongViec.Columns["SO_GIO_PB"].OptionsColumn.ReadOnly = false;
                grvCongViec.Columns["DINH_MUC_PB"].OptionsColumn.ReadOnly = false;
                grvCongViec.Columns["GHI_CHU"].OptionsColumn.ReadOnly = false;
                grvCongViec.Columns["THUC_KIEM"].OptionsColumn.ReadOnly = false;
                grvCongViec.Columns["SO_NGUOI"].OptionsColumn.ReadOnly = false;
                grvCongViec.Columns["YEU_CAU_DUNG_CU"].OptionsColumn.ReadOnly = false;
                grvCongViec.Columns["TIEU_CHUAN_KT"].OptionsColumn.ReadOnly = false;
                grvCongViec.Columns["THAO_TAC"].OptionsColumn.ReadOnly = false;
                try
                {
                    grvCongViec.Columns["TON_TAI"].Visible = false;
                    grvCongViec.Columns["PATH_HD"].VisibleIndex = grvCongViec.Columns["YCSD"].VisibleIndex;
                }
                catch
                {
                }
                grvCongViec.Columns["SO_GIO_KH"].Width = 95;
                grvCongViec.Columns["SO_GIO_PB"].Width = 95;
                grvCongViec.Columns["DINH_MUC_PB"].Width = 95;
                grvCongViec.Columns["NGAY_TRUOC"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                grvCongViec.Columns["NGAY_TRUOC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvCongViec.Columns["MA_CV"].Width = 200;
                grvCongViec.Columns["TEN_BO_PHAN"].Width = 200;
                grvCongViec.Columns["NGAY_TRUOC"].Width = 150;
                grvCongViec.Columns["GHI_CHU"].Width = 200;
                grvCongViec.Columns["THUC_KIEM"].Width = 200;
                grvCongViec.Columns["SO_NGUOI"].Width = 100;
                grvCongViec.Columns["YEU_CAU_DUNG_CU"].Width = 300;
                grvCongViec.Columns["THAO_TAC"].Width = 300;
                grvCongViec.Columns["TIEU_CHUAN_KT"].Width = 300;
                grvCongViec.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
                grvCongViec.Columns["NGAY_HOAN_THANH"].Visible = false;
                grvCongViec.Columns["MS_CV"].Visible = false;
                grvCongViec.Columns["MS_BO_PHAN"].Visible = false;
                grvCongViec.Columns["HANG_MUC_ID"].Visible = false;
                grvCongViec.Columns["MSCVBT"].Visible = false;
                grvCongViec.Columns["EOR_ID"].Visible = false;
                grvCongViec.Columns["NGAY_BDCV"].Visible = false;
                grvCongViec.Columns["NGAY_KTCV"].Visible = false;

                jump: if (btnGhi.Visible)
                {
                    grvCongViec.OptionsBehavior.Editable = true;
                }
                else
                {
                    grvCongViec.OptionsBehavior.Editable = false;
                }
                grvCongViec_FocusedRowChanged(null, null);
            }
        }

        private void LoadSoGioSoPhut()
        {
            //iPhutGioPBT =          PHUT_GIO_PBT: Định nghĩa đơn ví tính là giờ hay phút (0 - dùng giờ, 1 dùng phút )
            try
            {
                if (Commons.Modules.iPhutGioPBT == 1)
                {
                    grvCongViec.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0";
                    grvCongViec.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    grvCongViec.Columns["SO_GIO_PB"].DisplayFormat.FormatString = "#,###,###,###,##0";
                    grvCongViec.Columns["SO_GIO_PB"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                    grvCongViec.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT", Commons.Modules.TypeLanguage);
                    grvCongViec.Columns["SO_GIO_PB"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO_PB_PHUT", Commons.Modules.TypeLanguage);
                }
                else
                {
                    grvCongViec.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0.#00";
                    grvCongViec.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    grvCongViec.Columns["SO_GIO_PB"].DisplayFormat.FormatString = "#,###,###,###,##0.#00";
                    grvCongViec.Columns["SO_GIO_PB"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                    grvCongViec.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO", Commons.Modules.TypeLanguage);
                    grvCongViec.Columns["SO_GIO_PB"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO_PB", Commons.Modules.TypeLanguage);
                }
            }
            catch { }
        }

        private delegate void BindDataCongViec();

        public void VisibleButton(bool chon)
        {
            btnThem.Visible = chon;
            btnBackLog.Enabled = chon;
            btnXoa.Visible = chon;
            btnThoat.Visible = chon;
            btnXemTonKhoPBT.Visible = chon;
            btnChonCongViec.Visible = !chon;
            btnChonVTPT.Visible = !chon;
            btnGhi.Visible = !chon;
            btnKhongGhi.Visible = !chon;
        }

        public void VisibleButtonXoa(bool chon)
        {
            btnXoaCongViecChinh.Visible = chon;

            btnXoaVatTuPT.Visible = chon;
            btnXoaViTriPT.Visible = chon;
            BtnTrove.Visible = chon;
            btnChonCongViec.Visible = !chon;
            btnChonVTPT.Visible = !chon;
            btnGhi.Visible = !chon;
            btnKhongGhi.Visible = !chon;
            btnThem.Visible = !chon;
            btnBackLog.Enabled = !chon;
            btnXoa.Visible = !chon;
            btnThoat.Visible = !chon;
            btnXemTonKhoPBT.Visible = !chon;

        }

        public void LoadFormCVPBT()
        {
            VisibleButton(true);
            DieuKhienNutSyn();
            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                btnThem.Visible = false;
                btnXoa.Visible = false;
                btnBackLog.Visible = false;
                btnXemTonKhoPBT.Visible = false;
                btnSynDNXK.Visible = false;
            }
            LoadSoGioSoPhut();
        }
        private void grvCongViec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            BindPhuTung();
        }
        private delegate void BindDataPhuTung();

        public void BindPhuTung()
        {
            if (grdPhuTung.InvokeRequired)
            {
                grdPhuTung.Invoke(new BindDataPhuTung(BindPhuTung), null);
            }
            else
            {
                try
                {
                    if (grvCongViec.RowCount == 0)
                    {
                        if (grvPhuTung.Columns.Count > 0)
                        {
                            DataTable dttmp = grdPhuTung.DataSource as DataTable;
                            try
                            {
                                dttmp.Rows.Clear();
                                grdPhuTung.DataSource = dttmp;

                            }
                            catch { grdPhuTung.DataSource = null; }
                        }
                        return;
                    }
                }
                catch { }

                DataTable dt = new DataTable();

                if (btnGhi.Visible)
                {
                    try
                    {
                        string str = "SELECT DISTINCT A.MS_PHIEU_BAO_TRI,A.MS_CV,A.MS_BO_PHAN,A.MS_PT,A.TEN_PT,IC_PHU_TUNG.QUY_CACH, A.SL_KH,A.SL_TT,  A.GHI_CHU,A.MS_PT_CTY,A.MS_PT_CHA,  LOAI_VT.VAT_TU  FROM  " + sBTPT + " AS A INNER JOIN  IC_PHU_TUNG ON A.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN  LOAI_VT ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT WHERE MS_CV = '" + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + "' AND MS_BO_PHAN = '" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' ORDER BY A.MS_PT ";
                        
                        dt = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, CommandType.Text, str).Tables[0];
                    }
                    catch
                    {
                    }
                }
                else
                {
                    dt = new clsPHIEU_BAO_TRIController().GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNGs(sMsPBT, Convert.ToInt32(grvCongViec.GetFocusedDataRow()["MS_CV"]), grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString());
                }
                dt.Columns["SL_TT"].ReadOnly = true;
                Commons.Modules.SQLString = "0Load";
                grdPhuTung.DataSource = dt;
                Commons.Modules.SQLString = "";
                grvPhuTung.OptionsBehavior.Editable = false;
                if (Commons.Modules.ObjSystems.PBTKho == false)
                {
                    if (btnGhi.Visible)
                    {
                        grvPhuTung.OptionsBehavior.Editable = true;
                        grvPhuTung.Columns["SL_TT"].OptionsColumn.ReadOnly = false;
                        grvPhuTung.Columns["SL_TT"].OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        grvPhuTung.OptionsBehavior.Editable = false;
                    }
                }
                else
                {
                    grvPhuTung.OptionsBehavior.Editable = false;
                    grvPhuTung.Columns["SL_TT"].OptionsColumn.ReadOnly = true;
                    grvPhuTung.Columns["SL_TT"].OptionsColumn.AllowEdit = false;
                }
                grvPhuTung.Columns["SL_TT"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
                grvPhuTung.Columns["SL_TT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvPhuTung.Columns["SL_KH"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
                grvPhuTung.Columns["SL_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvPhuTung.Columns["SL_KH"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvPhuTung.Columns["SL_TT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;


                grvPhuTung_FocusedRowChanged(null, null);
            }
        }

        private void grvPhuTung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            BindViTri();


            try
            {
                if (btnGhi.Visible)
                {
                    // VAT TU = 1
                    if (Convert.ToBoolean(grvPhuTung.GetFocusedDataRow()["VAT_TU"].ToString()))
                    {
                        if (!Commons.Modules.ObjSystems.PBTKho)
                        {

                            grvPhuTung.Columns["SL_TT"].OptionsColumn.ReadOnly = false;
                            grvPhuTung.Columns["SL_TT"].OptionsColumn.AllowEdit = true;

                        }
                        grvPhuTung.OptionsBehavior.Editable = true;
                        grvPhuTung.Columns["SL_KH"].OptionsColumn.ReadOnly = false;
                        grvPhuTung.Columns["SL_KH"].OptionsColumn.AllowEdit = true;

                    }
                    else
                    {
                        grvPhuTung.OptionsBehavior.Editable = false;

                        CreateMenuThemViTri(grdViTri);
                    }
                }

            }
            catch
            {
            }
        }
        private delegate void BindDataViTri();

        private void BindViTri()
        {
            if (grdViTri.InvokeRequired)
            {
                grdViTri.Invoke(new BindDataViTri(BindViTri), null);
            }
            else
            {
                try
                {
                    grdViTri.DataSource = System.DBNull.Value;
                }
                catch { }

                if (grdPhuTung.DataSource == null) return;
                if (grvPhuTung.RowCount == 0)
                {

                    if (grvViTri.Columns.Count > 0)
                    {
                        DataTable dttmp = grdViTri.DataSource as DataTable;
                        try
                        {
                            dttmp.Rows.Clear();
                            grdViTri.DataSource = dttmp;

                        }
                        catch { grdViTri.DataSource = null; }
                    }
                    return;
                }

                DataTable dt = new DataTable();
                if (btnGhi.Visible)
                {
                    try
                    {
                        dt = new DataTable();
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_PHIEU_BT_CV_PT_CT_TEMP", sMsPBT, grvCongViec.GetFocusedDataRow()["MS_CV"].ToString(), grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString(), "PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName, sBTPT, sBTPTCT));
                    }
                    catch (Exception EX)
                    {
                    }
                }
                else
                {
                    dt = new clsPHIEU_BAO_TRIController().GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIETs(sMsPBT, Convert.ToInt32(grvCongViec.GetFocusedDataRow()["MS_CV"].ToString()), grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString());
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdViTri, grvViTri, dt, false, false, true, false, true, "FrmPhieuBaoTri_New");



                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvViTri.Columns)
                {
                    col.OptionsColumn.ReadOnly = true;
                    col.OptionsColumn.AllowEdit = false;
                }
                dt.Columns["SL_KH"].ReadOnly = false;

                grvViTri.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
                grvViTri.Columns["MS_CV"].Visible = false;
                grvViTri.Columns["MS_BO_PHAN"].Visible = false;
                grvViTri.Columns["MS_PT"].Visible = false;
                grvViTri.Columns["THAY_SUA"].Visible = false;
                grvViTri.Columns["NGAY_HOAN_THANH"].Visible = false;
                grvViTri.Columns["STT"].Visible = false;
                grvViTri.Columns["MS_VI_TRI_PT"].OptionsColumn.ReadOnly = true;
                grvViTri.Columns["NGAY_TRUOC"].OptionsColumn.ReadOnly = true;

                if (Commons.Modules.ObjSystems.PBTKho == false)
                {
                    if (btnGhi.Visible)
                    {
                        grvViTri.OptionsBehavior.Editable = true;
                        grvViTri.Columns["SL_TT"].OptionsColumn.ReadOnly = false;
                        grvViTri.Columns["SL_TT"].OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        grvViTri.OptionsBehavior.Editable = false;
                    }
                }
                else
                {
                    grvViTri.OptionsBehavior.Editable = false;
                    grvViTri.Columns["SL_TT"].OptionsColumn.ReadOnly = true;
                    grvViTri.Columns["SL_TT"].OptionsColumn.AllowEdit = false;
                }

                if (btnGhi.Visible)
                {
                    grvViTri.OptionsBehavior.Editable = true;
                    grvViTri.Columns["SL_KH"].OptionsColumn.ReadOnly = false;
                    grvViTri.Columns["SL_KH"].OptionsColumn.AllowEdit = true;
                }
                try
                {
                    if (Convert.ToBoolean(grvViTri.GetFocusedDataRow()["VTPT"].ToString()))
                    {
                        grvViTri.Columns["MS_VI_TRI_PT"].OptionsColumn.ReadOnly = false;
                        grvViTri.Columns["MS_VI_TRI_PT"].OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        grvViTri.OptionsBehavior.Editable = false;
                        grvViTri.Columns["MS_VI_TRI_PT"].OptionsColumn.ReadOnly = true;
                    }
                }
                catch { }
                grvViTri.Columns["SL_KH"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvViTri.Columns["SL_TT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                try
                {
                    grvViTri.Columns["SL_CUM"].Visible = false;
                    grvViTri.Columns["SL_CUM"].OptionsColumn.ReadOnly = true;
                }
                catch
                {
                }

                try
                {
                    grvViTri.Columns["MS_VI_TRI_PT"].Width = 90;
                    grvViTri.Columns["SL_KH"].Width = 67;
                    grvViTri.Columns["SL_TT"].Width = 67;
                }
                catch
                {
                }
            }
        }
        public void ThemSuaCV()
        {
            if (sMsPBT == null || sMsPBT =="")
            {
                //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "msgChuaChonPBT", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VisibleButton(false);
            //Thread t = new Thread(new ThreadStart(LoadTableTmp));
            //t.Start();
            LoadTableTmp();
            grvCongViec.OptionsBehavior.Editable = true;
            grvPhuTung.OptionsBehavior.Editable = true;
            grvViTri.OptionsBehavior.Editable = true;


            try
            {
                if (btnGhi.Visible)
                {
                    if (!Convert.ToBoolean(grvPhuTung.GetFocusedDataRow()["VAT_TU"].ToString()))
                    {
                        CreateMenuThemViTri(grdViTri);
                    }
                    if (grvPhuTung.RowCount < 2)
                    {
                        Commons.Modules.SQLString = "";
                        grvPhuTung_FocusedRowChanged(null, null);
                    }
                }

            }
            catch
            {
            }
        }

        public void DropTable()
        {
            Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CV_PHU_TRO_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable(sBTPT);
            Commons.Modules.ObjSystems.XoaTable(sBTPTCT);
        }
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            VisibleButton(true);

            grvCongViec.OptionsBehavior.Editable = false;
            grvPhuTung.OptionsBehavior.Editable = false;
            grvViTri.OptionsBehavior.Editable = false;
            LoadCongViec();

            DropTable();
            try
            {
                bar.Dispose();
            }
            catch { }
            Commons.Modules.ObjSystems.XoaTable("PHU_TU_XK" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PHU_TU_XK");
            DieuKhienNutSyn();
        }
        string sBTPT = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP" + Commons.Modules.UserName;
        string sBTPTCT = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP" + Commons.Modules.UserName;

        private delegate void LoadTMP();

        private void LoadTableTmp()
        {
            try
            {
                //if (grdCongviec.InvokeRequired)
                //{
                //    grdCongviec.Invoke(new LoadTMP(LoadTableTmp), null);
                //}
                //else
                //{
                    string str = "";
                    Commons.Modules.ObjSystems.XoaTable(sBTPTCT);
                    str = "CREATE TABLE " + sBTPTCT + " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV INT, MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(30),STT INT ,MS_VI_TRI_PT NVARCHAR(50),SL_KH FLOAT, SL_TT FLOAT,SL_CUM FLOAT,THAY_SUA BIT,DON_GIA FLOAT,NGOAI_TE NVARCHAR(10),TY_GIA FLOAT,TY_GIA_USD FLOAT) ";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

                    Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName);

                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName, (DataTable)grdCongviec.DataSource, "");


                    Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CV_PHU_TRO_TMP" + Commons.Modules.UserName);
                    str = "CREATE  TABLE PHIEU_BAO_TRI_CV_PHU_TRO_TMP" + Commons.Modules.UserName + " (MS_PHIEU_BAO_TRI NVARCHAR(30),STT INT, TEN_CONG_VIEC NVARCHAR(255), SO_GIO_KH FLOAT,NGAY_HOAN_THANH DATETIME,NGAY_BDCV DATETIME,NGAY_KTCV DATETIME)";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    try
                    {
                        str = "DROP TABLE " + sBTPT;
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    }
                    catch
                    {
                    }
                    str = "CREATE TABLE " + sBTPT + "(MS_PHIEU_BAO_TRI NVARCHAR(30),MS_CV int,MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(25),TEN_PT NVARCHAR(255), MS_PT_NCC NVARCHAR(255),MS_PT_CTY NVARCHAR(255),SL_KH FLOAT,SL_TT FLOAT,DON_GIA FLOAT,NGOAI_TE NVARCHAR(25), TY_GIA FLOAT,TY_GIA_USD FLOAT,NGAY_HOAN_THANH DATETIME,GHI_CHU NVARCHAR(255),MS_PT_CHA NVARCHAR(50), TON_TAI BIT,TU_XUAT BIT, MS_PT_TT NVARCHAR(500), VTPT BIT )";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

                    str = "INSERT INTO " + sBTPT + " SELECT DISTINCT  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT, IC_PHU_TUNG.TEN_PT,  IC_PHU_TUNG.MS_PT_NCC, IC_PHU_TUNG.MS_PT_CTY, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_KH,  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.SL_TT, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.DON_GIA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.NGOAI_TE, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.TY_GIA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.TY_GIA_USD,NULL AS Expr1, '' AS Expr2, (CASE WHEN CAU_TRUC_THIET_BI.MS_PT IS NULL  AND CAu_TRUC_THIET_BI_PHU_TUNG.MS_PT IS NULL  THEN 'N' ELSE 'Y' END) AS MS_PT_CHA, (CASE WHEN SL_KH IS NULL THEN '0' ELSE '1' END) AS TON_TAI, 0, MS_PT_TT ,0 FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG INNER JOIN IC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = IC_PHU_TUNG.MS_PT INNER JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND PHIEU_BAO_TRI_CONG_VIEC.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND  PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS NULL INNER JOIN PHIEU_BAO_TRI ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI.MS_PHIEU_BAO_TRI LEFT OUTER JOIN CAU_TRUC_THIET_BI ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI.MS_PT AND PHIEU_BAO_TRI.MS_MAY = CAU_TRUC_THIET_BI.MS_MAY AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = CAU_TRUC_THIET_BI.MS_BO_PHAN LEFT OUTER JOIN CAU_TRUC_THIET_BI_PHU_TUNG ON PHIEU_BAO_TRI.MS_MAY = CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN AND  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT AND  CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY = N'" + sMsMay + "' WHERE (PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = '" + sMsPBT + "')";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

                    DataTable tb = new DataTable();
                    str = "SELECT DISTINCT MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT FROM " + sBTPT;
                    tb.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));

                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        str = "INSERT INTO " + sBTPTCT + " SELECT DISTINCT '" + sMsPBT + "' AS MS_PHIEU_BAO_TRI,'" + tb.Rows[i]["MS_CV"] + "' AS MS_CV,  CAU_TRUC_THIET_BI.MS_BO_PHAN,  CAU_TRUC_THIET_BI.MS_PT,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, NULL AS MS_VI_TRI_PT,  CASE WHEN ISNULL(PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH,0)<=0 THEN CAU_TRUC_THIET_BI.SO_LUONG ELSE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH END , PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,CAU_TRUC_THIET_BI.SO_LUONG, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.DON_GIA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.NGOAI_TE, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.TY_GIA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.TY_GIA_USD FROM CAU_TRUC_THIET_BI RIGHT OUTER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON CAU_TRUC_THIET_BI.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND   CAU_TRUC_THIET_BI.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT LEFT OUTER JOIN  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND   PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT LEFT OUTER JOIN   PHIEU_BAO_TRI_CONG_VIEC ON  PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND  PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS NULL AND PHIEU_BAO_TRI_CONG_VIEC.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND  PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN  WHERE  CAU_TRUC_THIET_BI.MS_BO_PHAN = '" + tb.Rows[i]["MS_BO_PHAN"] + "' AND CAU_TRUC_THIET_BI.MS_MAY=N'" + sMsMay + "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT='" + tb.Rows[i]["MS_PT"] + "' UNION SELECT DISTINCT '" + sMsPBT + "' AS MS_PHIEU_BAO_TRI,'" + tb.Rows[i]["MS_CV"] + "' AS MS_CV, CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN, CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.STT, CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_KH, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.SL_TT,CAU_TRUC_THIET_BI_PHU_TUNG.SO_LUONG,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.THAY_SUA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.DON_GIA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.NGOAI_TE, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.TY_GIA,PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.TY_GIA_USD FROM  PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET INNER JOIN CAU_TRUC_THIET_BI_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN = CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_VI_TRI_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV INNER JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS NULL AND PHIEU_BAO_TRI_CONG_VIEC.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN = '" + tb.Rows[i]["MS_BO_PHAN"] + "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY=N'" + sMsMay + "' AND CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT='" + tb.Rows[i]["MS_PT"] + "' AND PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV= '" + tb.Rows[i]["MS_CV"] + "' ORDER BY MS_CV";
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    }
                    str = "INSERT INTO PHIEU_BAO_TRI_CV_PHU_TRO_TMP" + Commons.Modules.UserName + " SELECT * FROM PHIEU_BAO_TRI_CV_PHU_TRO WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "'";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                //}
            }
            catch
            {
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTMP = new DataTable();
                dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName + " WHERE ISNULL(YCSD,0) = 1 "));
                DialogResult result = DialogResult.No;

                if (dtTMP.Rows.Count > 0)
                {
                    result = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgHangMucCoYeuCauBanCoMuonGhiPBTVaoYCCT", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                string str = " UPDATE " + sBTPTCT + " SET MS_VI_TRI_PT = '' WHERE ISNULL(MS_VI_TRI_PT,'') = '' ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                string msBPCV = grvCongViec.GetFocusedDataRow()["MSCVBT"].ToString();

                GhiPBTCongViecChinh();

                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "InsertPhuTungLoaiMayPCV", sMsPBT);
                }
                catch
                {
                }

                if (result == DialogResult.Yes)
                {
                    str = "CV_PBT_TMP" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, str, dtTMP, "");
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, " UPDATE YEU_CAU_NSD_CHI_TIET SET MS_PBT = '" + sMsPBT + "' WHERE HANG_MUC_ID_KE_HOACH IN(SELECT DISTINCT HANG_MUC_ID  FROM " + str + ") AND ISNULL(MS_PBT,'') = '' ");
                    str = " UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_PBT = '" + sMsPBT + "' WHERE ISNULL(MS_CACH_TH,'-1') <> '03' AND STT_VAN_DE IN (SELECT DISTINCT STT_VAN_DE FROM YEU_CAU_NSD_CHI_TIET " + " WHERE HANG_MUC_ID_KE_HOACH IN(SELECT DISTINCT HANG_MUC_ID  FROM " + str + ")) AND ISNULL(MS_PBT,'') = '' ";
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                DieuKhienNutSyn();
                Commons.Modules.ObjSystems.XoaTable("PHU_TU_XK" + Commons.Modules.UserName);
                try
                {
                    bar.Dispose();
                }
                catch { }
            }
            catch (Exception ex)
            { }
        }

        public void DieuKhienNutSyn()
        {
            if (isSynData == false)
            {
                btnSynDNXK.Visible = false;
                btnTraKho.Visible = false;
                if (Commons.Modules.sPrivate == "BARIA"  || Commons.Modules.sPrivate == "PILMICO")
                {
                    if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 61) == false)
                    {
                        btnSynDNXK.Visible = false;
                        btnTraKho.Visible = false;
                        return;
                    }
                    else
                    {
                        if (iTTPBTri == 2)
                            btnSynDNXK.Visible = true;
                        else
                            btnSynDNXK.Visible = false;

                        if (iTTPBTri >= 2)
                            btnTraKho.Visible = true;
                        else
                            btnTraKho.Visible = false;
                    }

                }
                if (Commons.Modules.sPrivate == "PILMICO") btnTraKho.Visible = false;
                return;
            }

            if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 61) == false)
            {
                btnSynDNXK.Visible = false;
                btnTraKho.Visible = false;
                return;
            }

            if (Commons.Modules.sPrivate == "BARIA")
            {
                if (iTTPBTri == 2)
                    btnSynDNXK.Visible = true;
                else
                    btnSynDNXK.Visible = false;
                if (iTTPBTri >= 2)
                    btnTraKho.Visible = true;
                else
                    btnTraKho.Visible = false;
            }
            else
            {
                if (isSynData)
                {
                    if (iTTPBTri == 2)
                        btnSynDNXK.Visible = true;
                    else
                        btnSynDNXK.Visible = false;

                }
            }
        }

        private void GhiPBTCongViecChinh()
        {
            try
            {
                string MS_CVBT = null;
                if (grvCongViec.RowCount == 0)
                {
                    MS_CVBT = " - 1";
                }
                else
                {
                    MS_CVBT = grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString();
                }

                //kiem tra sl_kh o danh sach vi tri phu tung  co bang phu tung cha kong
                string str = "";
                SqlDataReader objRead;
                double iTong = 0;

                string _MS_PT_CHA = "";
                bool bVatTu = false;
                SqlDataReader dtReaderVT;

                try
                {
                    str = "SELECT MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" + sMsMay + "' AND MS_BO_PHAN ='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                    objRead = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    objRead.Read();
                    _MS_PT_CHA = objRead["MS_PT"].ToString();
                }
                catch
                {
                }
                for (int i = 0; i <= grvPhuTung.RowCount - 1; i++)
                {
                    if (grvPhuTung.GetDataRow(i)["MS_PT"].ToString().ToUpper() != _MS_PT_CHA.ToUpper())
                    {
                        iTong = 0;
                        for (int j = 0; j <= grvViTri.RowCount - 1; j++)
                        {
                            if (!(grvViTri.GetDataRow(j)["SL_KH"] == DBNull.Value) || !string.IsNullOrEmpty(grvViTri.GetDataRow(j)["SL_KH"].ToString()))
                            {
                                if (Convert.ToDouble(grvViTri.GetDataRow(j)["SL_KH"].ToString()) > 0)
                                    iTong += Convert.ToDouble(grvViTri.GetDataRow(j)["SL_KH"].ToString());
                            }
                        }

                        dtReaderVT = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) FROM IC_PHU_TUNG INNER JOIN LOAI_VT ON IC_PHU_TUNG.MS_LOAI_VT = LOAI_VT.MS_LOAI_VT WHERE (IC_PHU_TUNG.MS_PT = '" + grvPhuTung.GetDataRow(i)["MS_PT"].ToString() + "') AND (LOAI_VT.VAT_TU = 0)");
                        bVatTu = false;
                        while (dtReaderVT.Read())
                        {
                            if (dtReaderVT[0].ToString() == "0")
                            {
                                bVatTu = false;
                            }
                        }
                        dtReaderVT.Close();

                        if (bVatTu == true & Convert.ToDouble(grvPhuTung.GetDataRow(i)["SL_KH"].ToString()) != iTong)
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgSL_TTKhongTrung", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                        }
                    }
                }
                GhiPhieuBaoTriCongViec();
                GhiPhieuBaoTriCongViecPhuTung();
                try
                {
                    str = " INSERT INTO CAU_TRUC_THIET_BI_PHU_TUNG (MS_MAY, MS_BO_PHAN, MS_PT, MS_VI_TRI_PT , SO_LUONG , ACTIVE, CHUC_NANG) " + " SELECT N'" + sMsMay + "', T1.MS_BO_PHAN, T1.MS_PT, T1.MS_VI_TRI_PT, T1.SL_KH, 1,NULL FROM " + sBTPTCT + " T1 WHERE SL_CUM = 0 AND NOT EXISTS (SELECT * FROM CAU_TRUC_THIET_BI_PHU_TUNG T2 WHERE T2.MS_MAY = N'" + sMsMay + "' AND T2.MS_BO_PHAN = T1.MS_BO_PHAN AND T2.MS_PT = T1.MS_PT )";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }
                VisibleButton(true);
                LoadCongViec();
                try
                {
                    DataTable dt = (DataTable)grdCongviec.DataSource;
                    grvCongViec.FocusedRowHandle = dt.Rows.IndexOf(dt.Rows.Find(MS_CVBT));
                }
                catch { }
            }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        private void GhiPhieuBaoTriCongViecPhuTung()
        {
            try
            {
                string str = "";
                str = " DELETE T1 FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO T1 WHERE (T1.MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND ((T1.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T1.MS_CV) + T1.MS_BO_PHAN + T1.MS_PT + CONVERT (NVARCHAR (8), T1.STT )) NOT IN (SELECT T2.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T2.MS_CV) + T2.MS_BO_PHAN + T2.MS_PT + CONVERT (NVARCHAR (8), T2.STT ) FROM " + sBTPTCT + " T2)) Or  ((T1.MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND (T1.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T1.MS_CV) + T1.MS_BO_PHAN + T1.MS_PT + CONVERT (NVARCHAR (8), STT )) NOT IN  (SELECT T2.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T2.MS_CV) + T2.MS_BO_PHAN + T2.MS_PT+ CONVERT (NVARCHAR (8), STT ) FROM " + sBTPT + " T2 WHERE T2.SL_KH IS NOT NULL AND T2.SL_KH > 0 ))";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                str = " DELETE T1  FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET T1 INNER JOIN PHIEU_BAO_TRI_CONG_VIEC T2 ON T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI AND T1.MS_CV = T2.MS_CV  WHERE (T1.MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND T2.STT_SERVICE IS NULL AND  ((T1.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T1.MS_CV) + T1.MS_BO_PHAN + T1.MS_PT + CONVERT (NVARCHAR (8), T1.STT )) NOT IN  (SELECT     T2.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T2.MS_CV) + T2.MS_BO_PHAN + T2.MS_PT + CONVERT (NVARCHAR (8), T2.STT ) FROM " + sBTPTCT + " T2))  OR  ((T1.MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND (T1.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T1.MS_CV) + T1.MS_BO_PHAN + T1.MS_PT+ CONVERT (NVARCHAR (8), STT )) NOT IN  (SELECT T2.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T2.MS_CV) + T2.MS_BO_PHAN + T2.MS_PT+ CONVERT (NVARCHAR (8), STT )  FROM  " + sBTPT + " T2 WHERE T2.SL_KH IS NOT NULL AND T2.SL_KH > 0)) ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                str = " DELETE T1 FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG T1 INNER JOIN  IC_PHU_TUNG T2 ON T1.MS_PT = T2.MS_PT INNER JOIN  LOAI_VT T3 ON T2.MS_LOAI_VT = T3.MS_LOAI_VT INNER JOIN PHIEU_BAO_TRI_CONG_VIEC T4 ON T1.MS_PHIEU_BAO_TRI = T4.MS_PHIEU_BAO_TRI AND T1.MS_CV = T4.MS_CV  WHERE  (T1.MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND  T4.STT_SERVICE IS NULL AND ((T1.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T1.MS_CV) + T1.MS_BO_PHAN + T1.MS_PT) NOT IN  (SELECT     T2.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T2.MS_CV) + T2.MS_BO_PHAN + T2.MS_PT FROM " + sBTPT + " T2 WHERE T2.SL_KH IS NOT NULL AND T2.SL_KH > 0 )) ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                str = " UPDATE T1 SET T1.SL_KH = T2.SL_KH,T1.GHI_CHU = T2.GHI_CHU,T1.DON_GIA = T2.DON_GIA,T1.NGOAI_TE = T2.NGOAI_TE, T1.SL_TT=T2.SL_TT, T1.TY_GIA=T2.TY_GIA, T1.TY_GIA_USD=T2.TY_GIA_USD,T1.MS_PT_TT=T2.MS_PT_TT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG T1 INNER JOIN " + sBTPT + " T2 ON  T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI And T1.MS_CV = T2.MS_CV And T1.MS_BO_PHAN = T2.MS_BO_PHAN  AND T1.MS_PT = T2.MS_PT WHERE (T1.MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND   (T1.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T1.MS_CV) + T1.MS_BO_PHAN + T1.MS_PT) = (T2.MS_PHIEU_BAO_TRI + Convert(NVARCHAR(8), T2.MS_CV) + T2.MS_BO_PHAN + T2.MS_PT) ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                str = " UPDATE T1 SET T1.SL_KH = T2.SL_KH,T1.SL_TT=T2.SL_TT,T1.DON_GIA = T2.DON_GIA,T1.NGOAI_TE=T2.NGOAI_TE,T1.TY_GIA=T2.TY_GIA,T1.TY_GIA_USD=T2.TY_GIA_USD FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET T1 INNER JOIN " + sBTPTCT + " T2 ON  T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI And T1.MS_CV = T2.MS_CV And T1.MS_BO_PHAN = T2.MS_BO_PHAN  AND T1.MS_PT = T2.MS_PT AND T1.STT = T2.STT  WHERE  (T1.MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND  (T1.MS_PHIEU_BAO_TRI + CONVERT(NVARCHAR(8), T1.MS_CV) + T1.MS_BO_PHAN + T1.MS_PT+ CONVERT(NVARCHAR(8), T1.STT)) =  (T2.MS_PHIEU_BAO_TRI + Convert(NVARCHAR(8), T2.MS_CV) + T2.MS_BO_PHAN + T2.MS_PT+ CONVERT(NVARCHAR(8), T1.STT)) ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                str = " INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,SL_KH,SL_TT,GHI_CHU,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD, MS_PT_TT)  SELECT DISTINCT T1.MS_PHIEU_BAO_TRI,  T1.MS_CV, T1.MS_BO_PHAN, T1.MS_PT,  T1.SL_KH, T1.SL_TT, T2.GHI_CHU,T1.DON_GIA,T1.NGOAI_TE,T1.TY_GIA,T1.TY_GIA_USD, MS_PT_TT FROM " + sBTPT + " T1 INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName + " T2 ON T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI AND T1.MS_CV = T2.MS_CV AND T1.MS_BO_PHAN = T2.MS_BO_PHAN  WHERE  (T1.MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND (T1.SL_KH IS NOT NULL ) AND (T1.SL_KH > 0 ) AND T1.MS_PHIEU_BAO_TRI + CONVERT (NVARCHAR (8), T1.MS_CV) + T1.MS_BO_PHAN + T1.MS_PT NOT IN ( SELECT T2.MS_PHIEU_BAO_TRI + CONVERT (NVARCHAR (8), T2.MS_CV) + T2.MS_BO_PHAN + T2.MS_PT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG T2 )";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                str = " INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD)  SELECT DISTINCT T1.MS_PHIEU_BAO_TRI, T1.MS_CV, T1.MS_BO_PHAN, T1.MS_PT, T1.MS_VI_TRI_PT,  T1.SL_KH, T1.SL_TT,T1.DON_GIA,T1.NGOAI_TE,T1.TY_GIA,T1.TY_GIA_USD " + "FROM " + sBTPTCT + " T1 INNER JOIN " + sBTPT + " T2 ON T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI AND T1.MS_CV = T2.MS_CV AND T1.MS_BO_PHAN = T2.MS_BO_PHAN AND T1.MS_PT = T2.MS_PT WHERE  (T1.MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND (T1.SL_KH IS NOT NULL )  AND (T1.SL_KH > 0)  AND T1.MS_PHIEU_BAO_TRI + CONVERT (NVARCHAR (8), T1.MS_CV) + T1.MS_BO_PHAN + T1.MS_PT NOT IN ( SELECT T2.MS_PHIEU_BAO_TRI + CONVERT (NVARCHAR (8), T2.MS_CV) + T2.MS_BO_PHAN + T2.MS_PT  FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET T2)";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                str = " UPDATE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG SET SL_KH = SL FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG A INNER JOIN (SELECT MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN , MS_PT, SUM(SL_KH)  AS SL FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET  WHERE MS_PHIEU_BAO_TRI= '" + sMsPBT + "' GROUP BY MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN,MS_PT ) B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI  AND B.MS_BO_PHAN = A.MS_BO_PHAN AND B.MS_CV = A.MS_CV AND B.MS_PT = A.MS_PT WHERE A.MS_PHIEU_BAO_TRI = '" + sMsPBT + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        public void GhiPhieuBaoTriCongViec()
        {
            string str = "";
            str = "UPDATE PHIEU_BAO_TRI_CONG_VIEC set SO_GIO_KH =TMP.SO_GIO_KH,NGAY_BDCV=TMP.NGAY_BDCV,NGAY_KTCV=TMP.NGAY_KTCV ,SO_GIO_PB =TMP.SO_GIO_PB ,DINH_MUC_PB =TMP.DINH_MUC_PB ,NGOAI_TE =NULL , BAC_THO=NULL ,THUC_KIEM =TMP.THUC_KIEM, GHI_CHU=TMP.GHI_CHU, THAO_TAC = TMP.THAO_TAC, TIEU_CHUAN_KT = TMP.TIEU_CHUAN_KT ,PATH_HD = TMP.PATH_HD ,SO_NGUOI = TMP.SO_NGUOI ,YEU_CAU_NS = NULL ,YEU_CAU_DUNG_CU = TMP.YEU_CAU_DUNG_CU FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName + " TMP,PHIEU_BAO_TRI_CONG_VIEC TMP1  WHERE(TMP.TON_TAI = 1 And TMP.MS_PHIEU_BAO_TRI = TMP1.MS_PHIEU_BAO_TRI And TMP.MS_CV = TMP1.MS_CV And TMP.MS_BO_PHAN = TMP1.MS_BO_PHAN)";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

            SqlConnection objConnection = new SqlConnection(Commons.IConnections.ConnectionString);
            objConnection.Open();
            SqlTransaction objTrans = objConnection.BeginTransaction();
          
            try
            {
                str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH,NGAY_BDCV,NGAY_KTCV,SO_GIO_PB,DINH_MUC_PB,NGOAI_TE,HANG_MUC_ID,EOR_ID,BAC_THO,THUC_KIEM,GHI_CHU, THAO_TAC , TIEU_CHUAN_KT ,PATH_HD ,SO_NGUOI ,YEU_CAU_NS ,YEU_CAU_DUNG_CU) SELECT distinct MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,SO_GIO_KH,NGAY_BDCV,NGAY_KTCV,SO_GIO_PB,DINH_MUC_PB,NULL,HANG_MUC_ID,EOR_ID,NULL,THUC_KIEM,GHI_CHU, THAO_TAC , TIEU_CHUAN_KT ,PATH_HD ,SO_NGUOI ,NULL ,YEU_CAU_DUNG_CU FROM PHIEU_BAO_TRI_CONG_VIEC_TMP" + Commons.Modules.UserName + " WHERE TON_TAI IS NULL ";

                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, str);
                objTrans.Commit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                objTrans.Rollback();
                return;
            }
            finally
            {
                objConnection.Close();
            }
            for (int i = 0; i <= grvCongViec.RowCount - 1; i++)
            {
                if (!string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["HANG_MUC_ID"].ToString()))
                {
                    str = "UPDATE KE_HOACH_TONG_CONG_VIEC SET MS_PHIEU_BAO_TRI='" + sMsPBT + "' WHERE KE_HOACH_TONG_CONG_VIEC.MS_MAY=N'" + sMsMay + "' AND KE_HOACH_TONG_CONG_VIEC.HANG_MUC_ID=" + grvCongViec.GetDataRow(i)["HANG_MUC_ID"].ToString() + " AND KE_HOACH_TONG_CONG_VIEC.MS_CV =" + grvCongViec.GetDataRow(i)["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCongViec.GetDataRow(i)["MS_BO_PHAN"].ToString() + "'";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                else
                {
                    if (!string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["EOR_ID"].ToString()))
                    {
                        str = "UPDATE EOR_CONG_VIEC SET MS_PHIEU_BAO_TRI='" + sMsPBT + "'  WHERE EOR_ID='" + grvCongViec.GetDataRow(i)["EOR_ID"].ToString() + "' AND MS_CV =" + grvCongViec.GetDataRow(i)["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCongViec.GetDataRow(i)["MS_BO_PHAN"].ToString() + "'";
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    }
                }

            }

        }

        private void grvCongViec_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            double soGio = 0.0;
            try
            {
                try
                {
                    soGio = Convert.ToDouble(grvCongViec.GetFocusedRowCellValue("SO_GIO_KH"));
                }catch { soGio = 0; }
                if (soGio < 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgSoGioKhongAm", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    return;
                }
                try
                {
                    soGio = Convert.ToDouble(grvCongViec.GetFocusedRowCellValue("SO_GIO_PB"));
                }catch { soGio = 0; }
                if (soGio < 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgSoGioKhongAm", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    return;
                }
                try { 
                soGio = Convert.ToDouble(grvCongViec.GetFocusedRowCellValue("DINH_MUC_PB"));
                }
                catch { soGio = 0; }
                if (soGio < 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgSoGioKhongAm", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    return;
                }

                try
                {
                    soGio = Convert.ToDouble(grvCongViec.GetFocusedRowCellValue("SO_NGUOI"));
                }
                catch { soGio = 0; }
                if (soGio < 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgSoNguoiKhongAm", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    return;
                }
                soGio = Commons.Modules.iPBTTheoGio == 0 ? 1 : 2;
                String sKH = String.IsNullOrEmpty(grvCongViec.GetFocusedDataRow()["SO_GIO_KH"].ToString()) ? "NULL" : grvCongViec.GetFocusedDataRow()["SO_GIO_KH"].ToString();
                String sPB = String.IsNullOrEmpty(grvCongViec.GetFocusedDataRow()["SO_GIO_PB"].ToString()) ? "NULL" : grvCongViec.GetFocusedDataRow()["SO_GIO_PB"].ToString();
                String sDMPB = String.IsNullOrEmpty(grvCongViec.GetFocusedDataRow()["DINH_MUC_PB"].ToString()) ? "NULL" : grvCongViec.GetFocusedDataRow()["DINH_MUC_PB"].ToString();
                String sSN = String.IsNullOrEmpty(grvCongViec.GetFocusedDataRow()["SO_NGUOI"].ToString()) ? "NULL" : grvCongViec.GetFocusedDataRow()["SO_NGUOI"].ToString();

                //string str = $"UPDATE PHIEU_BAO_TRI_CONG_VIEC_TMP{ Commons.Modules.UserName } SET SO_GIO_KH = {  grvCongViec.GetFocusedDataRow()["SO_GIO_KH"].ToString()  }, SO_GIO_PB = { grvCongViec.GetFocusedDataRow()["SO_GIO_PB"].ToString() }, DINH_MUC_PB = { grvCongViec.GetFocusedDataRow()["DINH_MUC_PB"].ToString() }, GHI_CHU = N'{ grvCongViec.GetFocusedDataRow()["GHI_CHU"].ToString() }', THUC_KIEM = N'{ grvCongViec.GetFocusedDataRow()["THUC_KIEM"].ToString() }', SO_NGUOI = { grvCongViec.GetFocusedDataRow()["SO_NGUOI"].ToString() }, YEU_CAU_DUNG_CU = N'{ grvCongViec.GetFocusedDataRow()["YEU_CAU_DUNG_CU"].ToString() }', TIEU_CHUAN_KT = N'{ grvCongViec.GetFocusedDataRow()["TIEU_CHUAN_KT"].ToString() }', THAO_TAC = N'{ grvCongViec.GetFocusedDataRow()["THAO_TAC"].ToString() }'  WHERE MS_CV='{ grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() }' and MS_BO_PHAN='{ grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() }'";

                string str = $"UPDATE PHIEU_BAO_TRI_CONG_VIEC_TMP{ Commons.Modules.UserName } SET SO_GIO_KH = { sKH }, SO_GIO_PB = { sPB }, DINH_MUC_PB = { sDMPB }, GHI_CHU = N'{ grvCongViec.GetFocusedDataRow()["GHI_CHU"].ToString() }', THUC_KIEM = N'{ grvCongViec.GetFocusedDataRow()["THUC_KIEM"].ToString() }', SO_NGUOI = { sSN }, YEU_CAU_DUNG_CU = N'{ grvCongViec.GetFocusedDataRow()["YEU_CAU_DUNG_CU"].ToString() }', TIEU_CHUAN_KT = N'{ grvCongViec.GetFocusedDataRow()["TIEU_CHUAN_KT"].ToString() }', THAO_TAC = N'{ grvCongViec.GetFocusedDataRow()["THAO_TAC"].ToString() }'  WHERE MS_CV='{ grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() }' and MS_BO_PHAN='{ grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() }'";



                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch { e.Valid = false; }
        }

        private void grvCongViec_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }


        private void grvViTri_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {

                double iTong = 0;
                string sql = "";
                switch (e.Column.FieldName)
                {
                    case "SL_KH":
                        for (int i = 0; i <= grvViTri.RowCount - 1; i++)
                        {
                            if (!(grvViTri.GetDataRow(i)["SL_KH"] == DBNull.Value) || !string.IsNullOrEmpty(grvViTri.GetDataRow(i)["SL_KH"].ToString()))
                            {
                                if (Convert.ToDouble(grvViTri.GetDataRow(i)["SL_KH"].ToString()) > 0)
                                    iTong += Convert.ToDouble(grvViTri.GetDataRow(i)["SL_KH"].ToString());
                            }
                        }
                        grvPhuTung.SetFocusedRowCellValue("SL_KH", iTong);
                        sql = "UPDATE " + sBTPTCT + " SET SL_KH ='" + e.Value + "' WHERE MS_CV='" + grvPhuTung.GetFocusedRowCellValue("MS_CV") + "' and MS_BO_PHAN='" + grvPhuTung.GetFocusedRowCellValue("MS_BO_PHAN") + "' and MS_PT='" + grvPhuTung.GetFocusedRowCellValue("MS_PT") + "' AND MS_VI_TRI_PT = N'" + grvViTri.GetFocusedRowCellValue("MS_VI_TRI_PT") + "'";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql);
                        break;
                    case "SL_TT":
                        for (int i = 0; i <= grvViTri.RowCount - 1; i++)
                        {
                            if (!(grvViTri.GetDataRow(i)["SL_TT"] == DBNull.Value) || !string.IsNullOrEmpty(grvViTri.GetDataRow(i)["SL_TT"].ToString()))
                            {
                                if (Convert.ToDouble(grvViTri.GetDataRow(i)["SL_TT"].ToString()) > 0)
                                    iTong += Convert.ToDouble(grvViTri.GetDataRow(i)["SL_TT"].ToString());
                            }
                        }
                        grvPhuTung.SetFocusedRowCellValue("SL_TT", iTong);
                        sql = "UPDATE " + sBTPTCT + " SET SL_TT ='" + e.Value + "' WHERE MS_CV='" + grvPhuTung.GetFocusedRowCellValue("MS_CV") + "' and MS_BO_PHAN='" + grvPhuTung.GetFocusedRowCellValue("MS_BO_PHAN") + "' and MS_PT='" + grvPhuTung.GetFocusedRowCellValue("MS_PT") + "' AND MS_VI_TRI_PT = N'" + grvViTri.GetFocusedRowCellValue("MS_VI_TRI_PT") + "'";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql);
                        break;
                }
            }
            catch { }
        }

        private void grvViTri_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            double soluong = 0.0;
            try
            {
                soluong = Convert.ToDouble(grvViTri.GetFocusedRowCellValue("SL_KH"));
                if (soluong <= 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgSoLuongLonHonKhong", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    return;
                }
            }
            catch { }
        }

        private void grvViTri_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvPhuTung_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            try
            {
                string str = "";
                try
                {
                    str = " UPDATE " + sBTPTCT + " SET MS_VI_TRI_PT = '' WHERE ISNULL(MS_VI_TRI_PT,'') = '' ";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                }
                catch
                {
                }


                double sl = 0;
                switch (e.Column.FieldName)
                {
                    case "SL_KH":
                        sl = Convert.ToDouble(grvPhuTung.GetFocusedDataRow()["SL_KH"].ToString());
                        str = "UPDATE " + sBTPT + " SET SL_KH ='" + sl + "' WHERE MS_CV='" + grvPhuTung.GetFocusedDataRow()["MS_CV"].ToString() + "' and MS_BO_PHAN='" + grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' and MS_PT='" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "' ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        break;
                    case "SL_TT":
                        sl = Convert.ToDouble(grvPhuTung.GetFocusedDataRow()["SL_TT"].ToString());
                        str = "UPDATE " + sBTPT + " SET SL_TT ='" + sl + "' WHERE MS_CV='" + grvPhuTung.GetFocusedDataRow()["MS_CV"].ToString() + "' and MS_BO_PHAN='" + grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' and MS_PT='" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "' ";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        break;
                }

            }
            catch
            {
            }

        }


        private void grvPhuTung_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            double soluong = 0.0;
            try
            {
                soluong = Convert.ToDouble(grvPhuTung.GetFocusedRowCellValue("SL_KH"));
                if (soluong <= 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgSoLuongLonHonKhong", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Valid = false;
                    return;
                }
            }
            catch { }
        }

        private void grvPhuTung_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            VisibleButtonXoa(true);
        }

        private void BtnTrove_Click(object sender, EventArgs e)
        {
            VisibleButtonXoa(false);
            VisibleButton(true);
        }

        private void btnXoaCongViecChinh_Click(object sender, EventArgs e)
        {

            if (grvCongViec.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                clsPHIEU_BAO_TRIController objPHIEU_BAO_TRIController = new clsPHIEU_BAO_TRIController();
                if (!objPHIEU_BAO_TRIController.CheckPHIEU_BAO_TRI_CONG_VIEC(sMsPBT, Convert.ToInt32(grvCongViec.GetFocusedDataRow()["MS_CV"].ToString()), grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString()))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgCongViecDaSD", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {

                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoaCongViec", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC(sMsPBT, Convert.ToInt32(grvCongViec.GetFocusedDataRow()["MS_CV"].ToString()), grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString());
                        if (!string.IsNullOrEmpty(grvCongViec.GetFocusedDataRow()["HANG_MUC_ID"].ToString()))
                        {
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKE_HOACH_TONG_CONG_VIEC", sMsMay, grvCongViec.GetFocusedDataRow()["HANG_MUC_ID"].ToString(), Convert.ToInt32(grvCongViec.GetFocusedDataRow()["MS_CV"].ToString()), grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), sMsPBT);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(grvCongViec.GetFocusedDataRow()["EOR_ID"].ToString()))
                            {
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE EOR_CONG_VIEC SET MS_PHIEU_BAO_TRI =NULL WHERE EOR_ID='" + grvCongViec.GetFocusedDataRow()["EOR_ID"].ToString() + "' AND MS_CV=" + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' AND MS_PHIEU_BAO_TRI='" + sMsPBT + "'");
                            }
                        }
                        LoadCongViec();
                    }
                }
            }

        }

        private void btnXoaVatTuPT_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvPhuTung.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (Commons.Modules.sPrivate == "BARIA" || Commons.Modules.sPrivate == "PILMICO")
                    {
                        if (!KiemXoaINT("-1")) return;
                    }
                    if (grvPhuTung.RowCount > 1)
                    {
                        // MsgXoaVTPT = Chọn YES nếu bạn muốn xóa tất cả phụ tùng của công việc này, chọn NO nếu bạn muốn xóa phụ tùng đang chọn, chọn CANCEL nếu bạn muốn quay lại màn hình chính !
                        DialogResult result = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoaVTPT", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            string str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvPhuTung.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                            str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvPhuTung.GetFocusedDataRow()["MS_CV"] + " AND MS_BO_PHAN='" + grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                            str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvPhuTung.GetFocusedDataRow()["MS_CV"] + " AND MS_BO_PHAN='" + grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"] + "'";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        }
                        else if (result == DialogResult.No)
                        {
                            clsPHIEU_BAO_TRIController objPHIEU_BAO_TRIController = new clsPHIEU_BAO_TRIController();
                            objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(sMsPBT, Convert.ToInt32(grvPhuTung.GetFocusedDataRow()["MS_CV"]), grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString());
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {

                        if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoaVatTuPhuTung", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            clsPHIEU_BAO_TRIController objPHIEU_BAO_TRIController = new clsPHIEU_BAO_TRIController();
                            objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(sMsPBT, Convert.ToInt32(grvPhuTung.GetFocusedDataRow()["MS_CV"]), grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString());
                        }
                    }
                    grvCongViec_FocusedRowChanged(null, null);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXoaViTriPT_Click(object sender, EventArgs e)
        {

            if (grvViTri.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (Commons.Modules.sPrivate == "BARIA" || Commons.Modules.sPrivate == "PILMICO")
                {
                    if (!KiemXoaINT(grvViTri.GetFocusedDataRow()["MS_PT"].ToString())) return;
                }

                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoaViTriPT", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    clsPHIEU_BAO_TRIController objPHIEU_BAO_TRIController = new clsPHIEU_BAO_TRIController();
                    objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(sMsPBT, Convert.ToInt32(grvViTri.GetFocusedDataRow()["MS_CV"].ToString()), grvViTri.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), grvViTri.GetFocusedDataRow()["MS_PT"].ToString(), Convert.ToInt32(grvViTri.GetFocusedDataRow()["STT"].ToString()));
                    grvCongViec_FocusedRowChanged(null, null);

                }
            }

        }

        private void btnXemTonKhoPBT_Click(object sender, EventArgs e)
        {
            if (Commons.Modules.sPrivate == "PILMICO")
                InTonKhoTheoPBT();
            else
            {
                ReportMain.Forms.frmChonKhoInDMTB frm = new ReportMain.Forms.frmChonKhoInDMTB();
                frm.iLBCao = 2;
                frm.sMsPBT = sMsPBT;
                frm.ShowDialog();
            }
        }



        private void btnTraKho_Click(object sender, EventArgs e)
        {
            ReportHuda.frmChonVTINTPBT frmBR = new ReportHuda.frmChonVTINTPBT();
            frmBR.sPBT = sMsPBT;
            frmBR.sMay = sMsMay;
            frmBR.iLoaiForm = 1;
            frmBR.ShowDialog();
        }
        public bool isSynData = false;
        private void btnSynDNXK_Click(object sender, EventArgs e)
        {

            if (Commons.Modules.sPrivate == "BARIA" || Commons.Modules.sPrivate == "PILMICO")
            {
                try
                {
                    ReportHuda.frmChonVTRequestPBT FRM = new ReportHuda.frmChonVTRequestPBT();
                    FRM.sPBT = sMsPBT;
                    FRM.sMay = sMsMay;
                    FRM.dNgayYC = DateTime.Now.Date;
                    FRM.sCN = Commons.Modules.sMaNhanVienMD;
                    //FRM.LoadFormRequest();
                    FRM.ShowDialog();
                }
                catch
                {
                }

                return;
            }
            if (isSynData)
            {
                try
                {
                    DataTable _DataSynInfo = new DataTable();
                    _DataSynInfo.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "INTEGRATION_GET_DATA_FOR_DNXK_SYN", sMsPBT));
                    if (_DataSynInfo.Rows.Count > 0)
                    {
                        var frm = new ReportHuda.frmDeNghiVatTuBHS();
                        frm.sMsPBT = sMsPBT;
                        frm.dNgayBDKH = ngayBDKH;

                        if (frm.ShowDialog() == DialogResult.Cancel)
                            return;
                        string sMsKho = frm.sMsKho;
                        string sMsPB = frm.sMsPhongBan;
                        string sTenPB = frm.sTenPhongBan;
                        string sMsLyDoXuatKT = frm.sMsLyDoXuat;
                        string sNoiDung = frm.sNoiDung;

                        SqlConnection scon = new SqlConnection(_SynConnectionInfo);
                        try
                        {
                            scon.Open();
                        }
                        catch
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgConnectKhongThanhCong", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        SqlTransaction sqlTrans = scon.BeginTransaction();
                        try
                        {
                            SqlCommand commanddel = scon.CreateCommand();
                            commanddel.Connection = scon;
                            commanddel.CommandTimeout = 9999;
                            commanddel.Transaction = sqlTrans;
                            commanddel.CommandType = CommandType.Text;
                            commanddel.CommandText = "DELETE  TB_DNXK WHERE MASOYC = '" + sMsPBT + "'";
                            commanddel.ExecuteNonQuery();

                            //Them du lieu vao Allocated
                            for (int i = 0; i <= _DataSynInfo.Rows.Count - 1; i++)
                            {
                                SqlCommand command = scon.CreateCommand();
                                command.Connection = scon;
                                command.CommandTimeout = 9999;
                                command.Transaction = sqlTrans;
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandText = "INTEGRATION_INSERT_DNXK_FOR_SYN";

                                command.Parameters.Add("@MAKHO", SqlDbType.NVarChar);
                                command.Parameters["@MAKHO"].Value = sMsKho;
                                //_DataSynInfo.Rows[i]["MAKHO"].ToString()

                                command.Parameters.Add("@MASOYC", SqlDbType.NVarChar);
                                command.Parameters["@MASOYC"].Value = _DataSynInfo.Rows[i]["MASOYC"].ToString();

                                command.Parameters.Add("@GIOLAP", SqlDbType.DateTime);
                                command.Parameters["@GIOLAP"].Value = _DataSynInfo.Rows[i]["GIOLAP"].ToString();

                                command.Parameters.Add("@NGAYLAP", SqlDbType.DateTime);
                                command.Parameters["@NGAYLAP"].Value = _DataSynInfo.Rows[i]["NGAYLAP"].ToString();

                                command.Parameters.Add("@MASOPB", SqlDbType.NVarChar);
                                command.Parameters["@MASOPB"].Value = sMsPB;
                                //_DataSynInfo.Rows[i]["MASOPB"].ToString()

                                command.Parameters.Add("@TENPB", SqlDbType.NVarChar);
                                command.Parameters["@TENPB"].Value = sTenPB;
                                //_DataSynInfo.Rows[i]["TENPB"].ToString()

                                command.Parameters.Add("@TENNVYC", SqlDbType.NVarChar);
                                command.Parameters["@TENNVYC"].Value = _DataSynInfo.Rows[i]["TENNVYC"].ToString();

                                command.Parameters.Add("@NOIDUNG", SqlDbType.NVarChar);
                                command.Parameters["@NOIDUNG"].Value = sNoiDung;
                                //_DataSynInfo.Rows[i]["NOIDUNG"].ToString()

                                command.Parameters.Add("@MAVT", SqlDbType.NVarChar);
                                command.Parameters["@MAVT"].Value = _DataSynInfo.Rows[i]["MAVT"].ToString();

                                command.Parameters.Add("@MAHANGMUC", SqlDbType.NVarChar);
                                command.Parameters["@MAHANGMUC"].Value = _DataSynInfo.Rows[i]["MAHANGMUC"].ToString();

                                command.Parameters.Add("@MALYDOXUAT", SqlDbType.NVarChar);
                                command.Parameters["@MALYDOXUAT"].Value = sMsLyDoXuatKT;
                                //_DataSynInfo.Rows[i]["MALYDOXUAT"].ToString()

                                command.Parameters.Add("@SOLUONG", SqlDbType.Float);
                                command.Parameters["@SOLUONG"].Value = _DataSynInfo.Rows[i]["SOLUONG"].ToString();

                                command.Parameters.Add("@INSERT_DATE", SqlDbType.DateTime);
                                command.Parameters["@INSERT_DATE"].Value = _DataSynInfo.Rows[i]["INSERT_DATE"].ToString();

                                command.Parameters.Add("@UserLap", SqlDbType.NVarChar);
                                command.Parameters["@UserLap"].Value = Commons.Modules.UserName;

                                command.ExecuteNonQuery();
                            }


                            sqlTrans.Commit();
                            scon.Close();
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TAO_DNXK_THANH_CONG", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TAO_DNXK_KHONG_THANH_CONG" + "\n" + ex.Message, Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);


                            sqlTrans.Rollback();
                            scon.Close();
                        }

                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "CONNECT_TO_DBSYN_UNSUCCESSFUL" + "\n" + ex.Message, Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        DevExpress.XtraBars.BarManager bar;
        private void CreateMenuThemViTri(GridControl grd)
        {
            try
            {
                foreach (Control control in grd.Controls)
                {
                    if (control is DevExpress.XtraBars.BarDockControl)
                    {
                        return;
                    }
                }
            }
            catch
            {
            }
            bar = new DevExpress.XtraBars.BarManager();
            bar.Form = grd;
            bar.ItemClick += Bar_ItemClick;
            bar.BeginUpdate();
            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(bar);
            bar.SetPopupContextMenu(grd, popup);
            string sStr = null;
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_New", "mnThemViTri", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnThemViTri = new DevExpress.XtraBars.BarButtonItem(bar, sStr);
            mnThemViTri.Name = "mnThemViTri";

            popup.AddItems(new DevExpress.XtraBars.BarItem[] { mnThemViTri });
            bar.EndUpdate();
        }

        private void Bar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvViTri.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "MsgChiThemVTriChoPT", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            formThemViTri frm = new formThemViTri();
            frm.themViTri = new formThemViTri.ThemViTri(ThemViTriPT);
            frm.dt = (DataTable)grdViTri.DataSource;
            frm.ShowDialog();
        }

        private void ThemViTriPT(string tenViTri, DataTable dtTmp)
        {
            dtTmp.Columns["SL_TT"].AllowDBNull = true;
            if (!string.IsNullOrEmpty(tenViTri))
            {
                string str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_CV = " + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN = '" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' AND MS_PT = '" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "' AND MS_PHIEU_BAO_TRI = '" + sMsPBT + "'";
                DataTable DT = new DataTable();
                DT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                int STT = -1;
                if ((DT.Rows.Count > 0))
                {
                    str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET (MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT, THAY_SUA) " + "VALUES(N'" + sMsPBT + "'," + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + ",'" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "','" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "','" + tenViTri + "',1, NULL, 0) SELECT SCOPE_IDENTITY() ";
                    STT = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str));

                    str = "INSERT INTO " + sBTPTCT + "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,SL_CUM, THAY_SUA, STT) " + "VALUES(N'" + sMsPBT + "'," + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + ",'" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "','" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "','" + tenViTri + "', 1, NULL, 1, 0, " + STT + ")";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                else
                {
                    str = "INSERT INTO " + sBTPTCT + "(MS_PHIEU_BAO_TRI,MS_CV,MS_BO_PHAN,MS_PT,MS_VI_TRI_PT,SL_KH,SL_TT,SL_CUM, THAY_SUA, STT) " + "VALUES(N'" + sMsPBT + "'," + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + ",'" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "','" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "','" + tenViTri + "', 1, NULL, 1, 0, NULL)";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    STT = -1;
                }
                grvViTri.AddNewRow();
                int rowHandle = grvViTri.GetRowHandle(grvViTri.DataRowCount);
                if (grvViTri.IsNewItemRow(rowHandle))
                {
                    grvViTri.SetRowCellValue(rowHandle, "MS_VI_TRI_PT", tenViTri);
                    grvViTri.SetRowCellValue(rowHandle, "SL_KH", 1);
                    grvViTri.SetRowCellValue(rowHandle, "SL_TT", DBNull.Value);
                    grvViTri.SetRowCellValue(rowHandle, "STT", STT);
                    grvViTri.SetRowCellValue(rowHandle, "MS_CV", grvCongViec.GetFocusedDataRow()["MS_CV"].ToString());
                    grvViTri.SetRowCellValue(rowHandle, "MS_BO_PHAN", grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString());
                    grvViTri.SetRowCellValue(rowHandle, "MS_PT", grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString());
                    grvPhuTung.SetFocusedRowCellValue("SL_KH", Convert.ToDouble(grvPhuTung.GetFocusedDataRow()["SL_KH"].ToString()) + 1);
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private bool KiemXoaINT(string MsPT)
        {
            try
            {
                try
                {
                    
                    string sSql = "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG";
                    string sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                    if (Commons.Modules.sPrivate == "BARIA")
                        sSql = "SELECT ISNULL(SUM(SO_LUONG),0) AS SL FROM NAV_REQUEST WHERE (MS_PHIEU_BAO_TRI = '" + sMsPBT + "') AND (MS_MAY = N'" + sMsMay + "') AND (MS_PT = '" + MsPT + "'  OR '" + MsPT + "'  = '-1' ";
                    else
                        sSql = "SELECT ISNULL(SUM(Quantity),0) AS SL FROM MaterialRequest WHERE (WorkOrder = '" + sMsPBT + "')  AND (ItemID = '" + MsPT + "' OR '" + MsPT + "' = '-1' ) ";

                    DataTable dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(sINTConnect, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        if (double.Parse(dtTmp.Rows[0][0].ToString()) > 0)
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "msgDaChuyenDuLieuKhongTheXoa", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
                catch
                {
                    
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "msgDaChuyenDuLieuKhongTheXoa", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch { return false; }
            return true;
        }

        private void grdViTri_KeyDown(object sender, KeyEventArgs e)
        {
            if (!btnGhi.Visible) return;
            if (grvViTri.RowCount == 0) return;
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (Commons.Modules.sPrivate == "BARIA" || Commons.Modules.sPrivate == "PILMICO")
                    {
                        if (!KiemXoaINT(grvViTri.GetFocusedDataRow()["MS_PT"].ToString())) return;
                    }


                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "MsgXoaViTriPT", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "frmPhieuBaoTri_NEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        clsPHIEU_BAO_TRIController objPHIEU_BAO_TRIController = new clsPHIEU_BAO_TRIController();

                        string str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_KHO WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "'";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();
                        try
                        {
                            str = "DELETE FROM " + sBTPTCT + " WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' AND MS_PT='" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "' AND (STT = " + grvViTri.GetFocusedDataRow()["STT"].ToString() + " OR STT = -1)";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);



                        }
                        catch
                        {
                        }

                        try
                        {
                            str = "SELECT * FROM " + sBTPTCT + " WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' AND MS_PT='" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "'";
                            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));


                        }
                        catch
                        {
                        }


                        objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(sMsPBT, Convert.ToInt32(grvCongViec.GetFocusedDataRow()["MS_CV"].ToString()), grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString(), Convert.ToInt32(grvViTri.GetFocusedDataRow()["STT"].ToString()));


                        str = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' AND MS_PT='" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "'";
                        dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));


                        if (dt1.Rows.Count == 0 & dt.Rows.Count == 0)
                        {
                            try
                            {
                                str = "DELETE " + sBTPT + " WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' AND MS_PT='" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "'";
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                            }
                            catch
                            {
                            }
                            str = "DELETE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + " AND MS_BO_PHAN='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' AND MS_PT='" + grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString() + "'";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        }
                        grvCongViec_FocusedRowChanged(null, null);
                    }
                }
                catch
                {
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSuaCV();
            try
            {
                //grvPhuTung_FocusedRowChanged(null, null);
            }
            catch { }
        }

        private void grvCongViec_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {   
                var gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (gv.FocusedColumn.FieldName.ToUpper() == "SO_NGUOI" || gv.FocusedColumn.FieldName.ToUpper() == "DINH_MUC_PB" || gv.FocusedColumn.FieldName.ToUpper() == "SO_GIO_KH" || gv.FocusedColumn.FieldName.ToUpper() == "SO_GIO_PB")
                {
                    if (e.Value != DBNull.Value && Convert.ToString(e.Value) == "")
                    {
                        Commons.Modules.SQLString = "0Load";
                        e.Value = DBNull.Value;
                        Commons.Modules.SQLString = "";
                    }
                }
            }
            catch { }
        }





        #region Ton Pilmico



        private void InTonKhoTheoPBT()
        {
            try
            {

                #region Tao Du Lieu
                
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MTonKhoTheoPBT", sMsPBT, "-1"));

                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmTonKhoTheoPBT", "KhongCoDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                dtTmp.Columns["STT"].ReadOnly = false;
                for (int i = 0; i <= dtTmp.Rows.Count - 1; i++)
                {
                    dtTmp.Rows[i][0] = (i + 1).ToString();
                }


                ReportMain.frmPrInDMTB frm = new ReportMain.frmPrInDMTB();
                if (Commons.Modules.sPrivate == "PILMICO")
                    frm.dtPrInDMTB = TonTheoPilmico(dtTmp);
                else
                    frm.dtPrInDMTB = dtTmp;

                frm.sTenKho = "";
                frm.sMsPBT = sMsPBT;
                frm.ShowDialog();
                #endregion

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "KhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                    ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private DataTable TonTheoPilmico(DataTable dtTon)
        {
            try
            {
                CallBack();
                dtTon.Columns["SL_TON"].ReadOnly = false;
                foreach (DataRow drRow in dtTon.Rows)
                {

                    double SLTon = 0;
                    string sMSPT = "";
                    sMSPT = drRow["MS_PT"].ToString();
                    try
                    {
                        if (sToken == "") CallBack();
                        SLTon = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spGetDataPIL", sMSPT, sToken));
                    }
                    catch
                    {
                        SLTon = 0;
                    }
                    if (SLTon == 0)
                    {
                        try
                        {
                            CallBack();
                            SLTon = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spGetDataPIL", sMSPT, sToken));
                        }
                        catch
                        {
                            SLTon = 0;
                        }
                    }
                    try
                    {
                        drRow["SL_TON"] = SLTon;
                    }
                    catch { }

                }
                dtTon.AcceptChanges();
                return dtTon;
            }
            catch
            {
                return dtTon;
            }

        }

        private void CallProcess(string args)
        {
            try
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.Arguments = args;
                start.FileName = Application.StartupPath + "\\GetTokenPIL.exe";
                start.WindowStyle = ProcessWindowStyle.Hidden;
                start.CreateNoWindow = true;
                int exitCode;
                using (Process proc = Process.Start(start))
                {
                    proc.WaitForExit();
                    exitCode = proc.ExitCode;
                    if (exitCode == 0)
                    {
                        sToken = System.IO.File.ReadAllText(Application.StartupPath + "\\GetTokenPIL.txt");
                    }
                }
            }
            catch { sToken = ""; }
            System.IO.File.Delete(Application.StartupPath + "\\GetTokenPIL.txt");
        }

        private void CallBack()
        {
            CallProcess("Basic OVg2dXVBUnNHbUdjNkJCUkFzbkU2ZEpTSXdRNXlDbnY6REFEaldrYjRRYzl5d1RGNQ==");
        }



        #endregion

    }
}


