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
    public partial class frmKeHoachCongViec : DevExpress.XtraEditors.XtraForm
    {
        string MS_CN_Temp = "";
        public frmKeHoachCongViec()
        {
            InitializeComponent();
        }

        private void VisibleButton(bool flag)
        {
            btnCopy.Visible = flag;
            btnThemSua.Visible = flag;
            btnXoa.Visible = flag;
            btnIn.Visible = flag;
            btnThoat.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhongGhi.Visible = !flag;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                
                if (Commons.Modules.PermisString.Equals("Read only"))
                {
                    LoadcboDON_VI1();
                    Commons.Modules.ObjSystems.DinhDang();
                    flagLoad = true;
                    LoadcboTO();
                    if (cboTO.EditValue != null)
                    {
                        BindData();
                    }
                    

                    btnThemSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
                else
                {

                    LoadcboDON_VI1();
                    Commons.Modules.ObjSystems.DinhDang();
                    flagLoad = true;
                    LoadcboTO();

                    if (cboTO.EditValue != null)
                    {
                        BindData();
                    }
                }
                dtTNgay_1.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtDNgay_1.DateTime = dtTNgay_1.DateTime.AddMonths(1).AddDays(-1);
                flagLoad = false;
            }
            catch
            {
                flagLoad = false;
            }

            optNTHT_SelectedIndexChanged(null, null);

            try
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : " + grvNVien.RowCount.ToString();

            }
            catch
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : 0";
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        public void BindData()
        {
            if (cboTO.EditValue == null)
            {
                return;
            }

            DataTable dtNVien = new DataTable();

            if (cboDON_VI1.EditValue == null)
                return;

            dtNVien.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_UserAll", cboDON_VI1.EditValue, cboTO.EditValue, 1, Commons.Modules.UserName));
            try
            {
                dtNVien.PrimaryKey = new DataColumn[] { dtNVien.Columns["MS_CONG_NHAN"] };
                int focusHandle = dtNVien.Rows.IndexOf(dtNVien.Rows.Find(MS_CN_Temp));

                flagLoad = true;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNVien, grvNVien, dtNVien, false, true, true, true, true, this.Name);
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

                    grvNVien.Columns["HO_TEN"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grvNVien.Columns["HO_TEN"].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grvNVien.Columns["HO_TEN"].AppearanceHeader.Options.UseTextOptions = true;

                }
                catch
                {
                }

                grvNVien.Columns["USER_MAIL"].Visible = false;
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }
            catch
            {
            }
            try
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : " + grvNVien.RowCount.ToString();

            }
            catch
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : 0";
            }


        }
        bool flagLoad = false;
        #region LoadCombo
        private void cboDON_VI1_EditValueChanged(object sender, EventArgs e)
        {
            if (flagLoad == true) return;
            LoadcboTO();
        }

        private void cboTO_EditValueChanged(object sender, EventArgs e)
        {
            if (flagLoad == true) return;
            flagLoad = true;
            BindData();
            flagLoad = false;
            grvNVien_FocusedRowChanged(grvNVien, null);
        }
        public void LoadcboDON_VI1()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDonViUserAll", 1, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDON_VI1, dt, "MS_DON_VI", "TEN_DON_VI", "");

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


        #endregion



        public void BindDataCongViec()
        {
            try
            {
                try
                {
                    grvKeHoachCongViec.Columns.Clear();
                    grdKeHoachCongViec.DataSource = null;
                }
                catch { }
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKE_HOACH_THUC_HIEN", grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), dtTNgay_1.DateTime.Date, dtDNgay_1.DateTime.Date, optNTHT.SelectedIndex == 0 ? -1 : optNTHT.SelectedIndex == 1 ? 0 : 1));
                dt.Columns["STT"].AllowDBNull = true;
                dt.Columns["MSCN_OLD"].AllowDBNull = true;
                dt.Columns["STT_OLD"].AllowDBNull = true;
                dt.Columns["NGAY_OLD"].AllowDBNull = true;
                foreach (DataColumn col in dt.Columns)
                {
                    col.AllowDBNull = true;
                }
                dt.Columns["TEN_CONG_VIEC"].AllowDBNull = false;

                dt.Columns["USER_LAST"].ReadOnly = true;
                dt.Columns["THOI_GIAN_DK"].ReadOnly = false;
                dt.Columns["PREVIOUS_USER"].ReadOnly = true;
                dt.Columns["DA_XONG"].ReadOnly = false;
                dt.Columns["CO_KH"].ReadOnly = false;
                dt.Columns["SPHUT"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdKeHoachCongViec, grvKeHoachCongViec, dt, false, false, false, true, true, this.Name);                
                string str = " SELECT MS_UU_TIEN, " + (Commons.Modules.TypeLanguage == 0 ? " TEN_UU_TIEN " : " TEN_TA ") + " AS TEN_UU_TIEN FROM MUC_UU_TIEN";
                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboMucUT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                cboMucUT.Name = "cboMucUT";
                cboMucUT.ValueMember = "MS_UU_TIEN";
                cboMucUT.DisplayMember = "TEN_UU_TIEN";
                cboMucUT.DataSource = dt;
                cboMucUT.PopulateColumns();
                cboMucUT.Columns["MS_UU_TIEN"].Visible = false;
                cboMucUT.NullText = "";
                grvKeHoachCongViec.Columns["UU_TIEN"].ColumnEdit = cboMucUT;

                grvKeHoachCongViec.Columns["USER_LAST"].Visible = false;
                grvKeHoachCongViec.Columns["PREVIOUS_USER"].Visible = false;
                grvKeHoachCongViec.Columns["THOI_GIAN_SUA"].Visible = false;


                grvKeHoachCongViec.Columns["STT"].Visible = false;
                grvKeHoachCongViec.Columns["MSCN_OLD"].Visible = false;
                grvKeHoachCongViec.Columns["STT_OLD"].Visible = false;
                grvKeHoachCongViec.Columns["NGAY_OLD"].Visible = false;
                grvKeHoachCongViec.Columns["NGAY"].Width = 100;
                grvKeHoachCongViec.Columns["THOI_HAN"].Width = 100;
                grvKeHoachCongViec.Columns["UU_TIEN"].Width = 100;

                grvKeHoachCongViec.Columns["TEN_CONG_VIEC"].Width = 300;
                grvKeHoachCongViec.Columns["GHI_CHU"].Width = 300;
                grvKeHoachCongViec.Columns["USER_LAST"].Width = 120;
                grvKeHoachCongViec.Columns["THOI_GIAN_SUA"].Width = 130;
                grvKeHoachCongViec.Columns["PREVIOUS_USER"].Width = 120;
                grvKeHoachCongViec.Columns["THOI_GIAN_DK"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                grvKeHoachCongViec.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvKeHoachCongViec.Columns["THOI_GIAN_SUA"].OptionsColumn.AllowEdit = false;
                grvKeHoachCongViec.Columns["SPHUT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                grvKeHoachCongViec.Columns["SPHUT"].OptionsColumn.AllowEdit = true;
             
                //if (Commons.Modules.sPrivate.ToUpper() != "ADC")
                //{
                //    this.grvKeHoachCongViec.Columns["TU_GIO"].Visible = false;
                //    this.grvKeHoachCongViec.Columns["DEN_GIO"].Visible = false;         
                //}
                //else
                //{

                    DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit dtTuGioLuoi = new
                        DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
                    dtTuGioLuoi.EditFormat.FormatString = "HH:mm";
                    dtTuGioLuoi.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    dtTuGioLuoi.EditMask = "HH:mm";
                    grvKeHoachCongViec.Columns["TU_GIO"].ColumnEdit = dtTuGioLuoi;

                    DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit dtDenGioLuoi = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
                    dtDenGioLuoi.EditFormat.FormatString = "HH:mm";
                    dtDenGioLuoi.EditMask = "HH:mm";
                    dtDenGioLuoi.Mask.EditMask = "HH:mm";
                    dtDenGioLuoi.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    grvKeHoachCongViec.Columns["DEN_GIO"].ColumnEdit = dtDenGioLuoi;

                    grvKeHoachCongViec.Columns["TU_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    grvKeHoachCongViec.Columns["TU_GIO"].DisplayFormat.FormatString = "HH:mm";

                    grvKeHoachCongViec.Columns["DEN_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    grvKeHoachCongViec.Columns["DEN_GIO"].DisplayFormat.FormatString = "HH:mm";

                    grvKeHoachCongViec.Columns["SPHUT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grvKeHoachCongViec.Columns["SPHUT"].OptionsColumn.AllowEdit = false;
                //}

            }
            catch { }
        }



        private void grvNVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (flagLoad == true) return;

                BindDataCongViec();
            }
            catch { }

        }
        

        private void optNTHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagLoad == true) return;
            BindDataCongViec();
        }

        private void dtTNgay_1_EditValueChanged(object sender, EventArgs e)
        {
            if (flagLoad == true) return;
            BindDataCongViec();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //optNTHT.SelectedIndex = 1;
            VisibleButton(false);
            EnableControl(false);

            grvKeHoachCongViec.OptionsBehavior.Editable = true;
            grvKeHoachCongViec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }

        private void grvKeHoachCongViec_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {

            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvKeHoachCongViec_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (grvKeHoachCongViec.GetDataRow(e.RowHandle)["TEN_CONG_VIEC"].ToString().Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "MsgTenNull", Commons.Modules.TypeLanguage));
                grvKeHoachCongViec.FocusedColumn = grvKeHoachCongViec.Columns["TEN_CONG_VIEC"];
                e.Valid = false;
            }


            try
            {
                if (Convert.ToDateTime(grvKeHoachCongViec.GetDataRow(e.RowHandle)["THOI_HAN"].ToString().Trim()) < Convert.ToDateTime(grvKeHoachCongViec.GetDataRow(e.RowHandle)["NGAY"].ToString().Trim()))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "MsgNgay_HTkhonghople", Commons.Modules.TypeLanguage));
                    grvKeHoachCongViec.FocusedColumn = grvKeHoachCongViec.Columns["NGAY"];

                    e.Valid = false;
                }

            }
            catch 
            {
            }

        }

        private void grvKeHoachCongViec_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                if (grvKeHoachCongViec.GetDataRow(e.RowHandle)["NGAY"].ToString().Trim() == "")
                {
                    grvKeHoachCongViec.SetRowCellValue(e.RowHandle, "NGAY", DateTime.Now);
                }
                if (grvKeHoachCongViec.GetDataRow(e.RowHandle)["THOI_HAN"].ToString().Trim() == "")
                {
                    grvKeHoachCongViec.SetRowCellValue(e.RowHandle, "THOI_HAN", DateTime.Now);
                }
                if (grvKeHoachCongViec.GetDataRow(e.RowHandle)["DA_XONG"] == DBNull.Value)
                {
                    grvKeHoachCongViec.SetRowCellValue(e.RowHandle, "DA_XONG", false);
                }
                if (grvKeHoachCongViec.GetDataRow(e.RowHandle)["CO_KH"] == DBNull.Value)
                {
                    grvKeHoachCongViec.SetRowCellValue(e.RowHandle, "CO_KH", false);
                }
                if (grvKeHoachCongViec.GetDataRow(e.RowHandle)["TU_GIO"].ToString().Trim() == "")
                {
                    grvKeHoachCongViec.SetRowCellValue(e.RowHandle, "TU_GIO", DateTime.Now);
                }
                if (grvKeHoachCongViec.GetDataRow(e.RowHandle)["DEN_GIO"].ToString().Trim() == "")
                {
                    grvKeHoachCongViec.SetRowCellValue(e.RowHandle, "DEN_GIO", DateTime.Now);
                }
                if (grvKeHoachCongViec.GetDataRow(e.RowHandle)["SPHUT"].ToString().Trim() == "")
                {
                    grvKeHoachCongViec.SetRowCellValue(e.RowHandle, "SPHUT", 0);
                }
            }
            catch { }
        }
        private void EnableControl(bool flag)
        {
            grpDSNhanVien.Enabled = flag;
            cboDON_VI1.Enabled = flag;
            cboTO.Enabled = flag;

            optNTHT.Enabled = flag;
            dtTNgay_1.Enabled = flag;
            dtDNgay_1.Enabled = flag;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            AddKehoach();
            VisibleButton(true);
            EnableControl(true);
            grvKeHoachCongViec.OptionsBehavior.Editable = false;
            grvKeHoachCongViec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            optNTHT_SelectedIndexChanged(null, null);
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            VisibleButton(true);
            EnableControl(true);
            grvKeHoachCongViec.OptionsBehavior.Editable = false;
            grvKeHoachCongViec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        private void TinhSoPhut()
        {

            if (!string.IsNullOrEmpty(grvKeHoachCongViec.GetFocusedDataRow()["NGAY"].ToString()) && !string.IsNullOrEmpty(grvKeHoachCongViec.GetFocusedDataRow()["THOI_HAN"].ToString()))
            {
                System.DateTime dTu = default(System.DateTime);
                System.DateTime dDen = default(System.DateTime);


                try
                {
                    dTu = Convert.ToDateTime(Convert.ToDateTime(grvKeHoachCongViec.GetFocusedDataRow()["NGAY"]).ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(grvKeHoachCongViec.GetFocusedDataRow()["TU_GIO"]).ToString("HH:mm:ss"));
                }
                catch 
                {
                    dTu = Convert.ToDateTime(Convert.ToDateTime(grvKeHoachCongViec.GetFocusedDataRow()["NGAY"]).ToString("yyyy/MM/dd") + " 00:00:00.000");
                }


                try
                {
                    dDen = Convert.ToDateTime(Convert.ToDateTime(grvKeHoachCongViec.GetFocusedDataRow()["THOI_HAN"]).ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(grvKeHoachCongViec.GetFocusedDataRow()["DEN_GIO"]).ToString("HH:mm:ss"));

                }
                catch 
                {
                    dDen = Convert.ToDateTime(Convert.ToDateTime(grvKeHoachCongViec.GetFocusedDataRow()["THOI_HAN"]).ToString("yyyy/MM/dd") + " 00:00:00.000");
                }

                double SPhut = 0;
                SPhut = (dDen - dTu).TotalMinutes;
                grvKeHoachCongViec.SetFocusedRowCellValue("SPHUT", SPhut);
                grvKeHoachCongViec.SetFocusedRowCellValue("THOI_GIAN_DK", SPhut);

                
                grvKeHoachCongViec.UpdateCurrentRow();
            }
        }
        public void AddKehoach()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sBTam = "KHCV_TMP" + Commons.Modules.UserName;
                dtTmp = (DataTable)grdKeHoachCongViec.DataSource;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
                string sSql = null;
                sSql = "";
                sSql = "UPDATE KE_HOACH_THUC_HIEN SET [MS_CONG_NHAN] = MSCN_OLD, " + " [NGAY] = CONVERT(DATETIME,CONVERT(NVARCHAR(10),A.[NGAY],101)), " + " [TEN_CONG_VIEC] = A.[TEN_CONG_VIEC], " + " [GHI_CHU] = A.[GHI_CHU], " + " [MS_UU_TIEN] = A.UU_TIEN , " + " [THOI_HAN] = CONVERT(DATETIME,CONVERT(NVARCHAR(10),A.[THOI_HAN],101)) , " + " [THOI_GIAN_DK] = A.[THOI_GIAN_DK], " + " [USER_LAST] = A.[USER_LAST], " + " [PREVIOUS_USER] = A.[PREVIOUS_USER], " + " [THOI_GIAN_SUA] = A.[THOI_GIAN_SUA], " + " [DA_XONG] = ISNULL(A.[DA_XONG],0), " + " [TU_GIO] = A.[TU_GIO], " + " [DEN_GIO] = A.[DEN_GIO], " + " [CO_KH] = A.[CO_KH] " + " FROM " + sBTam + " A INNER JOIN KE_HOACH_THUC_HIEN B ON  " + " A.MSCN_OLD = B.MS_CONG_NHAN And A.NGAY_OLD = B.NGAY And A.STT_OLD = B.STT WHERE B.MS_CONG_NHAN = '" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "' AND ISNULL(MSCN_OLD,'') <> ''";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                sSql = "INSERT INTO [KE_HOACH_THUC_HIEN] ([MS_CONG_NHAN],[NGAY],[TEN_CONG_VIEC],[GHI_CHU],[MS_UU_TIEN],[THOI_HAN],[THOI_GIAN_DK],[USER_LAST], " + " [PREVIOUS_USER],[THOI_GIAN_SUA],[DA_XONG],[TU_GIO],[DEN_GIO], [CO_KH]) " + " SELECT '" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "' AS [MS_CONG_NHAN],CONVERT(DATETIME,CONVERT(NVARCHAR(10),A.[NGAY],101)),A.[TEN_CONG_VIEC],A.[GHI_CHU],A.UU_TIEN AS [MS_UU_TIEN], " + " CONVERT(DATETIME,CONVERT(NVARCHAR(10),A.[THOI_HAN],101)),A.[THOI_GIAN_DK], " + " A.[USER_LAST],A.[PREVIOUS_USER],A.[THOI_GIAN_SUA],ISNULL(A.[DA_XONG],0),A.[TU_GIO],A.[DEN_GIO], A.[CO_KH] " + " FROM " + sBTam + " A WHERE ISNULL(MSCN_OLD,'') = ''";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.XoaTable(sBTam);
                sSql = " UPDATE [KE_HOACH_THUC_HIEN] SET SPHUT =  DATEDIFF(MINUTE,CONVERT(DATETIME,CONVERT(NVARCHAR(10),NGAY,101) + ' ' + CONVERT(NVARCHAR(10),ISNULL(TU_GIO,'00:00:00'),108)) , " + " CONVERT(DATETIME,CONVERT(NVARCHAR(10),THOI_HAN,101) + ' ' + CONVERT(NVARCHAR(10),ISNULL(DEN_GIO,'00:00:00'),108))) WHERE MS_CONG_NHAN = '" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            }
            catch { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            KE_HOACH_THUC_HIENController objKH_THController = new KE_HOACH_THUC_HIENController();
            objKH_THController.DeleteKE_HOACH_THUC_HIEN(grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), Convert.ToDateTime(grvKeHoachCongViec.GetFocusedDataRow()["NGAY"].ToString()), Convert.ToInt32(grvKeHoachCongViec.GetFocusedDataRow()["STT"].ToString()), this.Name);

            optNTHT_SelectedIndexChanged(null, null);

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                CreateTitleReport();
                string SqlText = "";
                try
                {
                    SqlText = " DROP TABLE [dbo].rptKE_HOACH_THUC_HIEN";
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText);
                }
                catch
                { }

                //SqlText = " CREATE TABLE [dbo].rptKE_HOACH_THUC_HIEN ( TEN_CONG_VIEC NVARCHAR(255),THOI_GIAN_DK FLOAT, NGAY DATETIME,THOI_HAN DATETIME,GHI_CHU NVARCHAR(255),UU_TIEN NVARCHAR(50), " + " USER_LAST NVARCHAR(50),THOI_GIAN_SUA DATETIME,PREVIOUS_USER NVARCHAR(50) ,  TU_GIO DATETIME ,  DEN_GIO DATETIME ,  SPHUT FLOAT )";

                //SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText);
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "InsertKE_HOACH_THUC_HIEN", grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString(), dtTNgay_1.DateTime, dtDNgay_1.DateTime, optNTHT.SelectedIndex));


                Report1.frmShowXMLReport frmIn = new Report1.frmShowXMLReport();
                dtTmp.TableName = "rptKE_HOACH_THUC_HIEN";
                frmIn.AddDataTableSource(dtTmp);


                if (Commons.Modules.sPrivate.ToUpper() == "ADC")
                    frmIn.rptName = "rptKE_HOACH_THUC_HIENADC";
                else
                    frmIn.rptName = "rptKE_HOACH_THUC_HIEN";

                
                
                

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM rptTIEU_DE_KE_HOACH_THUC_HIEN"));
                dtTmp.TableName = "rptTIEU_DE_KE_HOACH_THUC_HIEN";
                frmIn.AddDataTableSource(dtTmp);

                frmIn.ShowDialog();

                try
                {
                    Commons.Modules.ObjSystems.XoaTable("rptTIEU_DE_KE_HOACH_THUC_HIEN");
                }
                catch
                { }
            }catch { }
        }

        public void CreateTitleReport()
        {
            string SqlText = "";
            try
            {
                SqlText = " DROP TABLE rptTIEU_DE_KE_HOACH_THUC_HIEN";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText);
            }
            catch 
            {}

            SqlText = " CREATE TABLE rptTIEU_DE_KE_HOACH_THUC_HIEN( TypeLanguage int  ,TrangIn NVARCHAR(20),NgayIn NVARCHAR(20),TieudeReport NVARCHAR(255),NoiDung NVARCHAR(255),STT NVARCHAR(10),TenCongViec NVARCHAR(50),ThoiGianDK NVARCHAR(50),NgayDK NVARCHAR(50),ThoiHan NVARCHAR(50),GhiChu NVARCHAR(50),UuTien NVARCHAR(50),UserLast NVARCHAR(50),ThoiGianSua NVARCHAR(50),PreviousUser NVARCHAR(50))";
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText);

            string sTieudeReport = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TieudeReport", Commons.Modules.TypeLanguage);
            string sSTT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "STT", Commons.Modules.TypeLanguage);
            string sNgayIn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "Ngayin", Commons.Modules.TypeLanguage);
            string sTrangIn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "Trangin", Commons.Modules.TypeLanguage);
            string sTencongviec = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TenCongViec", Commons.Modules.TypeLanguage);
            string sThoiGianDK = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ThoiGianDK", Commons.Modules.TypeLanguage);
            string sNgay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NgayDK", Commons.Modules.TypeLanguage);
            string sThoiHan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ThoiHan", Commons.Modules.TypeLanguage);
            string sGhiChu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "GhiChu", Commons.Modules.TypeLanguage);
            string sUuTien = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "UuTien", Commons.Modules.TypeLanguage);

            string sUserLast = null;
            if (Commons.Modules.sPrivate.ToUpper() == "ADC")
            {
                sUserLast = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TU_GIO", Commons.Modules.TypeLanguage);
            }
            else
            {
                sUserLast = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "UserLast", Commons.Modules.TypeLanguage);
            }

            string sThoiGianSua = null;
            if (Commons.Modules.sPrivate.ToUpper() == "ADC")
            {
                sThoiGianSua = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "DEN_GIO", Commons.Modules.TypeLanguage);
            }
            else
            {
                sThoiGianSua = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ThoiGianSua", Commons.Modules.TypeLanguage);
            }
            string sPreviousUser = null;
            if (Commons.Modules.sPrivate.ToUpper() == "ADC")
            {
                sPreviousUser = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "SO_PHUT", Commons.Modules.TypeLanguage);
            }
            else
            {
                sPreviousUser = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "PreviousUser", Commons.Modules.TypeLanguage);
            }
            string sNoiDung = "";
            string tmp = "";
            if (Commons.Modules.TypeLanguage == 0)
            {
                tmp = " của nhân viên ";
            }
            else
            {
                tmp = " of employee ";
            }
            if (optNTHT.SelectedIndex == 1)
                sNoiDung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "RadChuaHoanThanh", Commons.Modules.TypeLanguage) + tmp + " " + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + " " + dtTNgay_1.DateTime.ToString("dd/MM/yyyy") + " " + lblTNgay.Text + " " + lblDenngay_1.Text + " " + dtDNgay_1.DateTime.ToString("dd/MM/yyyy");
            else
            {
                if (optNTHT.SelectedIndex == 2)
                    sNoiDung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "RadDaHoanThanh", Commons.Modules.TypeLanguage) + tmp + " " + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + " " + lblTNgay.Text + " " + dtTNgay_1.DateTime.ToString("dd/MM/yyyy") + " " + lblDenngay_1.Text + " " + dtDNgay_1.DateTime.ToString("dd/MM/yyyy");
                else
                    sNoiDung = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "grpKeHoachCongViec", Commons.Modules.TypeLanguage) + tmp + " " + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + " " + lblTNgay.Text + " " + dtTNgay_1.DateTime.ToString("dd/MM/yyyy") + " " + lblDenngay_1.Text + " " + dtDNgay_1.DateTime.ToString("dd/MM/yyyy");

            }
            SqlText = "INSERT INTO rptTIEU_DE_KE_HOACH_THUC_HIEN(Commons.Modules.TypeLanguage,TrangIn,NgayIn,TieudeReport,NoiDung,STT,TenCongViec,ThoiGianDK,NgayDK,ThoiHan,GhiChu,UuTien,UserLast,ThoiGianSua,PreviousUser) " + "VALUES(" + Commons.Modules.TypeLanguage + ",N'" + sTrangIn + "',N'" + sNgayIn + "'," + "N'" + sTieudeReport + "',N'" + sNoiDung + "',N'" + sSTT + "',N'" + sTencongviec + "',N'" + sThoiGianDK + "',N'" + sNgay + "',N'" + sThoiHan + "',N'" + sGhiChu + "',N'" + sUuTien + "'," + "N'" + sUserLast + "',N'" + sThoiGianSua + "',N'" + sPreviousUser + "')";
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, SqlText);
        }

        private void grvKeHoachCongViec_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "NGAY" || e.Column.FieldName == "THOI_HAN")
                {
                    TinhSoPhut();
                }
                   
            }
            catch { }
        }

        private void grvNVien_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                if (flagLoad == true) return;

                BindDataCongViec();
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_UserAll", "-1", "-1", 1, Commons.Modules.UserName));
            dtTmp = ((DataTable)grdNVien.DataSource).Copy();
            frmChonVTPT frm = new frmChonVTPT();
            frm.iLoaiChon = 1;
            frm.dtChon = dtTmp;
            DataRow[] drr = dtTmp.Select("MS_CONG_NHAN = '" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "' ");
            foreach (var row in drr)
                row.Delete();

            if (frm.ShowDialog() == DialogResult.Cancel) return;

            dtTmp = new DataTable();
            frm.dtChon.DefaultView.RowFilter = "CHON = TRUE";
            dtTmp = frm.dtChon.DefaultView.ToTable();
            string sTmp = "NVIEN_TMP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sTmp, dtTmp, "");
            DateTime dNgay;
            try
            {
                dNgay = Convert.ToDateTime(grvKeHoachCongViec.GetFocusedDataRow()["NGAY"].ToString());
                sTmp = "INSERT INTO [KE_HOACH_THUC_HIEN] ([MS_CONG_NHAN],[NGAY],[TEN_CONG_VIEC],[GHI_CHU],[MS_UU_TIEN],[THOI_HAN],[THOI_GIAN_DK],[USER_LAST], " +
                        " [PREVIOUS_USER],[THOI_GIAN_SUA],[DA_XONG],[TU_GIO],[DEN_GIO],[SPHUT],[CO_KH]) " +
                        " SELECT T2.[MS_CONG_NHAN], [NGAY], [TEN_CONG_VIEC], T1.[GHI_CHU], [MS_UU_TIEN], [THOI_HAN], [THOI_GIAN_DK], [USER_LAST], " +
                        " [PREVIOUS_USER], [THOI_GIAN_SUA], [DA_XONG], [TU_GIO], [DEN_GIO], [SPHUT], [CO_KH] FROM KE_HOACH_THUC_HIEN T1, " + sTmp +
                        " T2 WHERE T1.MS_CONG_NHAN = '" + grvNVien.GetFocusedDataRow()["MS_CONG_NHAN"].ToString() + "' AND NGAY = '" + dNgay.ToString("MM/dd/yyyy") + "' " + 
                        " AND T1.STT = " + Convert.ToInt32(grvKeHoachCongViec.GetFocusedDataRow()["STT"].ToString());
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sTmp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "msgCopyNhanVienKhongThanhCong", Commons.Modules.TypeLanguage) + "/n" + ex.Message) ;
            }

        }

        private void txtTimkiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dt = new DataTable();
            string sTim = "";
            try
            {
                dt = grdNVien.DataSource as DataTable;
                if ((!string.IsNullOrEmpty(txtTimkiem.Text.Trim())))
                {
                    sTim = "MS_CONG_NHAN LIKE '%" + txtTimkiem.Text.Trim() + "%' OR HO_TEN LIKE '%" + txtTimkiem.Text.Trim() + "%'";
                    dt.DefaultView.RowFilter = sTim;
                }
                else
                {
                    dt.DefaultView.RowFilter = "";
                }
            }
            catch
            {
                dt.DefaultView.RowFilter = "";
            }
            optNTHT_SelectedIndexChanged(null, null);


            try
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : " + grvNVien.RowCount.ToString();

            }
            catch
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : 0";
            }
        }
    }



}