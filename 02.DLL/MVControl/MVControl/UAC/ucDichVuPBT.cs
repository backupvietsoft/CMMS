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

namespace MVControl
{
    public partial class ucDichVuPBT : DevExpress.XtraEditors.XtraUserControl
    {

        public int iTTPBTri { get; set; }
        public string sMsPBT { get; set; }
        public string sMsMay { get; set; }

        public ucDichVuPBT()
        {
            InitializeComponent();
        }
        
        public void LoadFormDVPBT()
        {
            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                btnThemSuaCV.Visible = false;
                btnThemSuaDV.Visible = false;
                btnXoa.Visible = false;
                btnDanhGia.Enabled = false;
            }
            LoadSoGioSoPhut();
        }
        private delegate void BindDataDichVu();
        public void LoadDichVu()
        {
            if (grdDichVu.InvokeRequired)
            {
                grdDichVu.Invoke(new BindDataDichVu(LoadDichVu), null);
            }
            else
            {
                DataTable dt = new clsPHIEU_BAO_TRI_SERVICEController().GetDanhsachDVThueNgoai(sMsPBT);
                Commons.Modules.SQLString = "0Load";
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDichVu, grvDichVu, dt, false, false, true, true, true, "FrmPhieuBaoTri_New");
                Commons.Modules.SQLString = "";
                dt.Columns["THANH_TIEN"].ReadOnly = false;
                dt.Columns["TY_GIA_USD"].ReadOnly = false;
                dt.Columns["STT"].AutoIncrement = false;
                dt.Columns["STT"].AllowDBNull = true;
                
                grvDichVu.Columns["MS_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_CONG_TY", Commons.Modules.TypeLanguage);
                try
                {
                    if (grvDichVu.RowCount <= 0) btnThemSuaCV.Enabled = false;else btnThemSuaCV.Enabled = true;
                }
                catch
                { btnThemSuaCV.Visible = true; }

                if (grvDichVu.Columns["STT"].Visible == false) goto jump;
                DataTable dtTMP = new DataTable();
                dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGOAI_TE,TEN_NGOAI_TE FROM NGOAI_TE ORDER BY TEN_NGOAI_TE"));
                RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
                cbo.Name = "NGOAI_TE";
                cbo.DataSource = dtTMP;
                cbo.PopulateColumns();
                cbo.ValueMember = "NGOAI_TE";
                cbo.DisplayMember = "TEN_NGOAI_TE";
                cbo.Columns["NGOAI_TE"].Visible = false;
                cbo.NullText = "";
                grvDichVu.Columns["NGOAI_TE"].ColumnEdit = cbo;

                dtTMP = new DataTable();
                cbo = new RepositoryItemLookUpEdit();
                dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_KH, TEN_RUT_GON FROM KHACH_HANG ORDER BY TEN_RUT_GON"));

                cbo.Name = "TEN_RUT_GON";
                cbo.DataSource = dtTMP;
                cbo.PopulateColumns();
                cbo.ValueMember = "MS_KH";
                cbo.DisplayMember = "TEN_RUT_GON";
                cbo.NullText = "";
                cbo.Columns["MS_KH"].Visible = false;
                grvDichVu.Columns["MS_KH"].ColumnEdit = cbo;


                FormatGridDichVu();
                jump:
                if (iTTPBTri < 2)
                {
                    btnDanhGia.Enabled = false;
                }
                else
                {
                    if (Commons.Modules.PermisString.Equals("Read only"))                    
                        btnDanhGia.Enabled = false;
                    else
                        btnDanhGia.Enabled = true;
                }
                if (grvDichVu.RowCount == 0)
                {
                    grdCongViec.DataSource = DBNull.Value;
                    grdPhuTung.DataSource = DBNull.Value;
                    grdDanhGia.DataSource = DBNull.Value;
                    btnDanhGia.Enabled = false;
                }
                else
                {
                }
                grvDichVu_FocusedRowChanged(null, null);
            }
        }

        public void FormatGridDichVu()
        {
            try
            {
               
                try
                {
                    grvDichVu.Columns["SER_GROUP_NAME"].Width = 150;
                    grvDichVu.Columns["TEN_GL"].Width = 150;
                }
                catch
                {
                }
                grvDichVu.Columns["MS_KH"].Width = 100;
                grvDichVu.Columns["MS_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_CONG_TY", Commons.Modules.TypeLanguage);
                grvDichVu.Columns["SO_LUONG"].DisplayFormat.FormatString = (Commons.Modules.sPrivate == "REMINGTON" ? Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG) : Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL));

                grvDichVu.Columns["SO_LUONG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvDichVu.Columns["SO_LUONG"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvDichVu.Columns["DON_GIA"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvDichVu.Columns["NOI_DUNG_SERVICE"].Width = 300;
                grvDichVu.Columns["SO_LUONG"].Width = 90;
                grvDichVu.Columns["DON_GIA"].Width = 100;
                grvDichVu.Columns["DON_GIA"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
                grvDichVu.Columns["NGOAI_TE"].Width = 90;
                grvDichVu.Columns["THANH_TIEN"].Width = 100;
                grvDichVu.Columns["TY_GIA"].Width = 100;
                grvDichVu.Columns["TY_GIA"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvDichVu.Columns["TY_GIA_USD"].Width = 100;
                grvDichVu.Columns["TY_GIA_USD"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvDichVu.Columns["THANH_TIEN"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT);
                grvDichVu.Columns["THANH_TIEN"].OptionsColumn.AllowEdit = false;
                grvDichVu.Columns["THANH_TIEN"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvDichVu.Columns["STT"].Visible = false;
                grvDichVu.Columns["TEN_RUT_GON"].Visible = false;
                grvDichVu.Columns["NGUOI_GIAO_DICH"].Visible = false;
                grvDichVu.Columns["EOR_ID"].Visible = false;
                grvDichVu.Columns["STT_EOR"].Visible = false;
                grvDichVu.Columns["MnR"].Visible = false;
            }
            catch
            {
            }
        }

        public void ThemSuaDV()
        {
            blnDv = true;
            bThem = 4;
            HideButton(false);
            HideDelete(false);
            HideSave(true);
            grdCongViec.Enabled = false;
            grdPhuTung.Enabled = false;
            grdDanhGia.Enabled = false;
            grvDichVu.OptionsBehavior.Editable = true;
            grvDichVu.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
        }
        public void grvDichVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (blnDv == true) return;
            BindCongViecThueNgoai();
            try
            {
                LoadDanhGia();
            }
            catch
            { }
        }
        private delegate void BindDataThueNgoai();

        private void BindCongViecThueNgoai()
        {
            if (grdCongViec.InvokeRequired)
            {
                grdCongViec.Invoke(new BindDataThueNgoai(BindCongViecThueNgoai), null);
            }
            else
            {
                

                if (grvDichVu.RowCount == 0)
                {
                    if (grvCongViec.Columns.Count > 0)
                    {
                        DataTable dttmp = grdCongViec.DataSource as DataTable;
                        try
                        {
                            dttmp.Rows.Clear();
                            grdCongViec.DataSource = dttmp;

                        }
                        catch { grdCongViec.DataSource = null; }
                    }
                    
                    return;
                }
                    
                string str = "";
                try
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        //grdCongViec.DataSource = null;
                        //grvCongViec.Columns.Clear();
                    }
                    catch { }

                    if (btnGhi.Visible)
                    {
                        str = "SELECT DISTINCT * FROM" + " PHIEU_BAO_TRI_CONG_VIEC_TMP1" + Commons.Modules.UserName;
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                        Commons.Modules.SQLString = "0Load";
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdCongViec, grvCongViec, dt, true, false, false, false, true, "FrmPhieuBaoTri_New");
                        Commons.Modules.SQLString = "";

                        try
                        {
                            grvCongViec.Columns["TON_TAI"].Visible = false;
                        }
                        catch { }
                    }
                    else
                    {
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CONG_VIECs_THUENGOAI1", sMsPBT, grvDichVu.GetFocusedDataRow()["STT"]));
                        Commons.Modules.SQLString = "0Load";
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdCongViec, grvCongViec, dt, false, false, false, false, true, "FrmPhieuBaoTri_New");
                        Commons.Modules.SQLString = "";
                    }
                    LoadSoGioSoPhut();
                    if (grvCongViec.Columns["STT_EOR"].Visible == false) goto jump;
                    for (int i = 0; i < grvCongViec.Columns.Count; i++)
                    {
                        grvCongViec.Columns[i].OptionsColumn.ReadOnly = true;
                        grvCongViec.Columns[i].OptionsColumn.AllowEdit = false;
                    }

                    grvCongViec.Columns["MS_CV"].Visible = false;
                    grvCongViec.Columns["MS_BO_PHAN"].Visible = false;
                    grvCongViec.Columns["MSCVBT"].Visible = false;
                    grvCongViec.Columns["STT_EOR"].Visible = false;
                    grvCongViec.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
                    grvCongViec.Columns["HANG_MUC_ID"].Visible = false;
                    grvCongViec.Columns["EOR_ID"].Visible = false;
                    grvCongViec.Columns["BAC_THO"].Visible = false;

                    grvCongViec.Columns["SO_GIO_PB"].DisplayFormat.FormatString = "N2";
                    grvCongViec.Columns["SO_GIO_PB"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                    grvCongViec.Columns["SO_GIO_KH"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                    RepositoryItemLookUpEdit cboBTho = new RepositoryItemLookUpEdit();
                    DataTable dtBAC_THO = new DataTable();
                    dtBAC_THO.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "GetBAC_THOs"));
                    cboBTho.Name = "cboBTho";
                    cboBTho.DisplayMember = "TEN_BAC_THO";
                    cboBTho.ValueMember = "MS_BAC_THO";
                    cboBTho.DataSource = dtBAC_THO;
                    grvCongViec.Columns["BAC_THO"].ColumnEdit = cboBTho;

                    grvCongViec.Columns["MA_CV"].Width = 250;
                    grvCongViec.Columns["TEN_BO_PHAN"].Width = 150;
                    grvCongViec.Columns["THUC_KIEM"].Width = 150;
                    grvCongViec.Columns["THAO_TAC"].Width = 200;
                    grvCongViec.Columns["TIEU_CHUAN_KT"].Width = 200;
                    grvCongViec.Columns["GHI_CHU"].Width = 200;
                    grvCongViec.Columns["MA_CV"].Width = 200;
                    grvCongViec.Columns["TEN_BO_PHAN"].Width = 200;

                    grvCongViec.Columns["SO_GIO_PB"].OptionsColumn.ReadOnly = false;
                    grvCongViec.Columns["DINH_MUC_PB"].OptionsColumn.ReadOnly = false;
                    grvCongViec.Columns["GHI_CHU"].OptionsColumn.ReadOnly = false;
                    grvCongViec.Columns["THUC_KIEM"].OptionsColumn.ReadOnly = false;
                    grvCongViec.Columns["SO_GIO_PB"].OptionsColumn.AllowEdit = true;
                    grvCongViec.Columns["DINH_MUC_PB"].OptionsColumn.AllowEdit = true;
                    grvCongViec.Columns["GHI_CHU"].OptionsColumn.AllowEdit = true;
                    grvCongViec.Columns["THUC_KIEM"].OptionsColumn.AllowEdit = true;
                    grvCongViec.Columns["THAO_TAC"].OptionsColumn.AllowEdit = true;
                    grvCongViec.Columns["TIEU_CHUAN_KT"].OptionsColumn.AllowEdit = true;
                    grvCongViec.Columns["STT_EOR"].Visible = false;

                }
                catch
                {
                }
                jump:
                if (grvDichVu.RowCount == 0)
                {
                    btnThemSuaCV.Enabled = false;
                    btnXoa.Enabled = false;
                    grdDanhGia.DataSource = null;
                }
                else
                {
                    btnThemSuaCV.Enabled = true;
                    btnXoa.Enabled = true;
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

                    grvCongViec.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_PHUT_KH", Commons.Modules.TypeLanguage);
                    grvCongViec.Columns["SO_GIO_PB"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO_PB_PHUT", Commons.Modules.TypeLanguage);

                }
                else
                {

                    grvCongViec.Columns["SO_GIO_KH"].DisplayFormat.FormatString = "#,###,###,###,##0.#00";
                    grvCongViec.Columns["SO_GIO_KH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                    grvCongViec.Columns["SO_GIO_PB"].DisplayFormat.FormatString = "#,###,###,###,##0.#00";
                    grvCongViec.Columns["SO_GIO_PB"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                    grvCongViec.Columns["SO_GIO_KH"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO_KH", Commons.Modules.TypeLanguage);
                    grvCongViec.Columns["SO_GIO_PB"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "SO_GIO_PB", Commons.Modules.TypeLanguage);


                }
            }
            catch { }
        }


        private void grvDichVu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") { return; }
            DataTable dt = new DataTable();
            if (btnGhi.Visible)
            {
                if (e.Column.FieldName == "NGOAI_TE")
                {
                    try
                    {

                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM TI_GIA_NT WHERE NGOAI_TE='" + grvDichVu.GetDataRow(e.RowHandle)["NGOAI_TE"].ToString() + "' AND NGAY >=ALL (SELECT MAX(NGAY) FROM TI_GIA_NT)"));

                        Commons.Modules.SQLString = "0Load";
                        grvDichVu.SetRowCellValue(e.RowHandle, "TY_GIA_USD", dt.Rows[0]["TI_GIA_USD"]);
                        grvDichVu.SetRowCellValue(e.RowHandle, "TY_GIA", dt.Rows[0]["TI_GIA"]);

                        grvDichVu.UpdateCurrentRow();
                    }
                    catch
                    {
                    }
                    Commons.Modules.SQLString = "";
                }
                else if (e.Column.FieldName == "SO_LUONG")
                {
                    try
                    {
                        Commons.Modules.SQLString = "0Load";
                        grvDichVu.SetRowCellValue(e.RowHandle, "THANH_TIEN", Convert.ToDouble(grvDichVu.GetDataRow(e.RowHandle)["SO_LUONG"]) * Convert.ToDouble(grvDichVu.GetDataRow(e.RowHandle)["DON_GIA"]));
                        grvDichVu.UpdateCurrentRow();
                    }
                    catch
                    {
                    }
                    Commons.Modules.SQLString = "";
                }
                else if (e.Column.FieldName == "DON_GIA")
                {
                    try
                    {
                        Commons.Modules.SQLString = "0Load";
                        grvDichVu.SetRowCellValue(e.RowHandle, "THANH_TIEN", Convert.ToDouble(grvDichVu.GetDataRow(e.RowHandle)["SO_LUONG"]) * Convert.ToDouble(grvDichVu.GetDataRow(e.RowHandle)["DON_GIA"]));
                        grvDichVu.UpdateCurrentRow();
                        Commons.Modules.SQLString = "";
                    }
                    catch
                    {
                    }
                    Commons.Modules.SQLString = "";
                }
            }
        }
        private void grvDichVu_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvDichVu_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                if (grvDichVu.GetDataRow(e.RowHandle)["NOI_DUNG_SERVICE"] == null)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NOI_DUNG_SERVICE_NULL", Commons.Modules.TypeLanguage), this.Text);
                    grvDichVu.FocusedColumn = grvDichVu.Columns["NOI_DUNG_SERVICE"];
                    e.Valid = false;
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(grvDichVu.GetDataRow(e.RowHandle)["NOI_DUNG_SERVICE"].ToString()))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NOI_DUNG_SERVICE_NULL", Commons.Modules.TypeLanguage),
                            this.Text);
                        grvDichVu.FocusedColumn = grvDichVu.Columns["NOI_DUNG_SERVICE"];
                        e.Valid = false;
                        return;
                    }
                }

                if (grvDichVu.GetDataRow(e.RowHandle)["TEN_RUT_GON"].ToString() == null)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MS_KH_NULL", Commons.Modules.TypeLanguage), this.Text);
                    grvDichVu.FocusedColumn = grvDichVu.Columns["TEN_RUT_GON"];
                    e.Valid = false;
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(grvDichVu.GetDataRow(e.RowHandle)["MS_KH"].ToString()))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MS_KH_NULL", Commons.Modules.TypeLanguage), this.Text);
                        grvDichVu.FocusedColumn = grvDichVu.Columns["TEN_RUT_GON"];
                        e.Valid = false;
                        return;
                    }
                }

                try
                {
                    if (Convert.ToDouble(grvDichVu.GetDataRow(e.RowHandle)["SO_LUONG"].ToString()) <= 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmEOR", "MsgNotNum", Commons.Modules.TypeLanguage), this.Text);
                        grvDichVu.FocusedColumn = grvDichVu.Columns["SO_LUONG"];
                        e.Valid = false;
                    }
                    else if (Convert.ToDouble(grvDichVu.GetDataRow(e.RowHandle)["DON_GIA"].ToString()) < 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmEOR", "MsgNotNum1", Commons.Modules.TypeLanguage), this.Text);
                        grvDichVu.FocusedColumn = grvDichVu.Columns["DON_GIA"];
                        e.Valid = false;
                    }
                }
                catch
                {
                }
            }
            catch { }
        }

        private void grvDichVu_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT NGOAI_TE FROM NGOAI_TE WHERE MAC_DINH = 1"));
                grvDichVu.SetRowCellValue(e.RowHandle, "NGOAI_TE", dt.Rows[0]["NGOAI_TE"]);
                grvDichVu.SetRowCellValue(e.RowHandle, "STT", null);
                grvDichVu.UpdateCurrentRow();
            }
            catch
            {
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (blnDv == true)
            {
                AddDichVu();
                LoadDichVu();
            }
            else
            {
                AddCongViecDichVu();
                AddPhuTungDichVu();
            }
            blnDv = false;
            bThem = -1;
            grvDichVu.OptionsBehavior.Editable = false;
            grvPhuTung.OptionsBehavior.Editable = false;
            grvCongViec.OptionsBehavior.Editable = false;
            grvDichVu.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            HideButton(true);
            HideDelete(false);
            HideSave(false);
            grdCongViec.Enabled = true;
            grdPhuTung.Enabled = true;
            grdDanhGia.Enabled = true;
            grdDichVu.Enabled = true;
            DropTable4();

        }

        private void AddDichVu()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sBTam = "DichVu_TMP" + Commons.Modules.UserName;
                dtTmp = (DataTable)grdDichVu.DataSource;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
                string sSql = null;
                sSql = "";
                sSql = "UPDATE PHIEU_BAO_TRI_SERVICE SET [MS_PHIEU_BAO_TRI] = '" + sMsPBT + "' , [NOI_DUNG_SERVICE] = A.[NOI_DUNG_SERVICE], [MS_KH] = A.[MS_KH], [SO_LUONG] = A.[SO_LUONG], [DON_GIA] = A.[DON_GIA], [NGOAI_TE] = A.[NGOAI_TE], [TY_GIA] = A.[TY_GIA], [TY_GIA_USD] = A.[TY_GIA_USD], [MnR] = 0 FROM " + sBTam + " A INNER JOIN PHIEU_BAO_TRI_SERVICE B ON A.STT = B.STT AND A.STT <> -1";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "INSERT INTO PHIEU_BAO_TRI_SERVICE([MS_PHIEU_BAO_TRI] ,[NOI_DUNG_SERVICE] ,[MS_KH] ,[SO_LUONG] ,[DON_GIA] ,[NGOAI_TE] ,[TY_GIA] ,[TY_GIA_USD] ,[MnR]) SELECT '" + sMsPBT + "' ,[NOI_DUNG_SERVICE] ,[MS_KH] ,[SO_LUONG] ,[DON_GIA] ,[NGOAI_TE] ,[TY_GIA] ,[TY_GIA_USD] ,0 FROM " + sBTam + " WHERE STT IS NULL";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.XoaTable(sBTam);
            }
            catch { }
        }

        private void AddCongViecDichVu()
        {
            try
            {

                DataTable dtTmp = new DataTable();
                string sBTam = "CongViec_TMP" + Commons.Modules.UserName;
                dtTmp = (DataTable)grdCongViec.DataSource;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
                string sSql = null;
                sSql = "";
                sSql = "UPDATE [PHIEU_BAO_TRI_CONG_VIEC] SET [SO_GIO_KH] = A.[SO_GIO_KH], [HANG_MUC_ID] = A.[HANG_MUC_ID], [EOR_ID] = A.[EOR_ID], [GHI_CHU] = A.[GHI_CHU],[SO_GIO_PB] = A.[SO_GIO_PB],[DINH_MUC_PB] = A.[DINH_MUC_PB],[BAC_THO] = A.[BAC_THO],[THUC_KIEM] = A.[THUC_KIEM] FROM " + sBTam + " A INNER JOIN PHIEU_BAO_TRI_CONG_VIEC B ON B.MS_PHIEU_BAO_TRI = '" + sMsPBT + "' AND B.MS_CV = A.MS_CV AND B.MS_BO_PHAN = A.MS_BO_PHAN";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC(MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, SO_GIO_KH, HANG_MUC_ID, EOR_ID, STT_SERVICE, SO_GIO_PB, DINH_MUC_PB, BAC_THO, GHI_CHU, DINH_MUC_KH,THUC_KIEM) SELECT '" + sMsPBT + "', MS_CV, MS_BO_PHAN, SO_GIO_KH, HANG_MUC_ID, EOR_ID, STT_EOR, SO_GIO_PB, DINH_MUC_PB, BAC_THO, GHI_CHU, DINH_MUC_KH,THUC_KIEM FROM " + sBTam + " A WHERE NOT EXISTS (SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC B WHERE B.MS_CV = A.MS_CV AND B.MS_BO_PHAN = A.MS_BO_PHAN AND B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI AND B.STT_SERVICE = A.STT_EOR)";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "DELETE B FROM PHIEU_BAO_TRI_CONG_VIEC B WHERE MS_PHIEU_BAO_TRI = '" + sMsPBT + "' AND STT_SERVICE = " + grvDichVu.GetFocusedDataRow()["STT"] + " AND NOT EXISTS (SELECT * FROM " + sBTam + " A WHERE B.MS_CV = A.MS_CV AND B.MS_BO_PHAN = A.MS_BO_PHAN AND B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI)";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                Commons.Modules.ObjSystems.XoaTable(sBTam);
            }
            catch
            {
            }
        }

        private void AddPhuTungDichVu()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sSql = "";

                string sBTam = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" + Commons.Modules.UserName;
                sSql = "UPDATE [PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG] SET [SL_KH] = A.[SL_KH],[SL_TT] = A.[SL_TT], [GHI_CHU] = A.[GHI_CHU] FROM " + sBTam + " A INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG B ON B.MS_PHIEU_BAO_TRI = '" + sMsPBT + "' AND B.MS_CV = A.MS_CV AND B.MS_BO_PHAN = A.MS_BO_PHAN AND B.MS_PT = A.MS_PT";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG(MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, SL_KH, SL_TT, GHI_CHU)  SELECT  '" + sMsPBT + "', MS_CV, MS_BO_PHAN, MS_PT, SL_KH, SL_TT, GHI_CHU FROM " + sBTam + " A WHERE NOT EXISTS (SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG B WHERE B.MS_CV = A.MS_CV AND B.MS_BO_PHAN = A.MS_BO_PHAN AND B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI AND B.MS_PT = A.MS_PT)";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "UPDATE [PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET] SET [SL_TT] = A.[SL_TT], GHI_CHU = A.[GHI_CHU] FROM " + sBTam + " A INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET B ON B.MS_PHIEU_BAO_TRI = '" + sMsPBT + "' AND B.MS_CV = A.MS_CV AND B.MS_BO_PHAN = A.MS_BO_PHAN AND B.MS_PT = A.MS_PT AND A.MS_VI_TRI_PT = B.MS_VI_TRI_PT";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET(MS_PHIEU_BAO_TRI, MS_CV, MS_BO_PHAN, MS_PT, MS_VI_TRI_PT, SL_KH, SL_TT) SELECT '" + sMsPBT + "', MS_CV, MS_BO_PHAN, MS_PT, MS_VI_TRI_PT,  SL_KH, SL_TT FROM " + sBTam + " A WHERE NOT EXISTS (SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET B WHERE B.MS_CV = A.MS_CV AND B.MS_BO_PHAN = A.MS_BO_PHAN AND B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI AND B.MS_PT = A.MS_PT AND B.MS_VI_TRI_PT = A.MS_VI_TRI_PT)";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "DELETE B FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET B INNER JOIN PHIEU_BAO_TRI_CONG_VIEC C ON B.MS_PHIEU_BAO_TRI = C.MS_PHIEU_BAO_TRI AND B.MS_CV = C.MS_CV AND B.MS_BO_PHAN = C.MS_BO_PHAN WHERE B.MS_PHIEU_BAO_TRI = '" + sMsPBT + "' AND STT_SERVICE = " + grvDichVu.GetFocusedDataRow()["STT"] + " AND NOT EXISTS (SELECT * FROM " + sBTam + " A WHERE B.MS_CV = A.MS_CV AND B.MS_BO_PHAN = A.MS_BO_PHAN AND B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI AND B.MS_PT = A.MS_PT AND B.MS_VI_TRI_PT = A.MS_VI_TRI_PT)";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "DELETE B FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG B INNER JOIN PHIEU_BAO_TRI_CONG_VIEC C ON B.MS_PHIEU_BAO_TRI = C.MS_PHIEU_BAO_TRI AND B.MS_CV = C.MS_CV AND B.MS_BO_PHAN = C.MS_BO_PHAN WHERE B.MS_PHIEU_BAO_TRI = '" + sMsPBT + "' AND STT_SERVICE = " + grvDichVu.GetFocusedDataRow()["STT"] + " AND NOT EXISTS (SELECT * FROM " + sBTam + " A WHERE B.MS_CV = A.MS_CV AND B.MS_BO_PHAN = A.MS_BO_PHAN AND B.MS_PHIEU_BAO_TRI = A.MS_PHIEU_BAO_TRI AND B.MS_PT = A.MS_PT)";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            }
            catch { }
        }

        bool blnDv = false;
        int bThem = -1;
        private void HideButton(bool flg)
        {
            btnDanhGia.Visible = flg;
            btnThemSuaCV.Visible = flg;
            btnThemSuaDV.Visible = flg;
            btnThoat.Visible = flg;
            btnXoa.Visible = flg;
            btnChonCongViec.Visible = !flg;
            btnPTThayThe.Visible = !flg;
        }
        private void HideDelete(bool flg)
        {
            btnXoaDichVu.Visible = flg;
            btnXoaCongViec.Visible = flg;
            btnXoaPhuTung.Visible = flg;
            btnKhongXoa4.Visible = flg;
        }
        private void HideSave(bool chon)
        {
            btnGhi.Visible = chon;
            btnKhongGhi.Visible = chon;

            if (bThem == 4 & blnDv)
            {
                btnChonTuROA_5.Visible = false;
                // chon
                btnChonCongViec.Visible = !chon;
                btnPTThayThe.Visible = !chon;
            }
            else if (bThem == 4 & !blnDv)
            {
                btnChonTuROA_5.Visible = false;
                // Not chon
                btnChonCongViec.Visible = chon;
                btnPTThayThe.Visible = chon;
            }
            else
            {
                btnChonTuROA_5.Visible = false;
                btnChonCongViec.Visible = false;
                btnPTThayThe.Visible = false;
            }
        }
        private void EnableButton(bool bln)
        {
            btnXoa.Enabled = bln;
            btnThemSuaCV.Enabled = bln;
            btnThemSuaDV.Enabled = bln;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            HideDelete(true);
            HideButton(false);
            HideSave(false);
        }

        private void grvCongViec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            BindDataPhuTung();
        }

        private void BindDataPhuTung()
        {

            if (grvCongViec.RowCount == 0) return;

            DataTable dt = new DataTable();
            try
            {
                grdPhuTung.DataSource = null;
                grvPhuTung.Columns.Clear();
            }
            catch
            { }


            if (btnGhi.Visible)
            {
                string str = "SELECT distinct TMP.MS_PHIEU_BAO_TRI, TMP.MS_CV,TMP.MS_BO_PHAN, TMP.MS_PT, TMP.TEN_PT,TMP.MS_VI_TRI_PT,SL_KH,SL_TT, TON_TAI,MS_PT_CHA, SL_CUM,GHI_CHU,MS_PT_NCC,MS_PT_CTY " + " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" + Commons.Modules.UserName + " TMP  " + " WHERE TMP.MS_BO_PHAN='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"] + "' AND TMP.MS_CV='" + grvCongViec.GetFocusedDataRow()["MS_CV"] + "'";
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                Commons.Modules.SQLString = "0Load";
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPhuTung, grvPhuTung, dt, true, false, false, false, true, "FrmPhieuBaoTri_New");
                Commons.Modules.SQLString = "";

            }
            else
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAIs", sMsMay, sMsPBT, grvCongViec.GetFocusedDataRow()["MS_CV"], grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"]));
                Commons.Modules.SQLString = "0Load";
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPhuTung, grvPhuTung, dt, false, false, false, false, true, "FrmPhieuBaoTri_New");
                Commons.Modules.SQLString = "";
            }

            if (grvPhuTung.Columns["SL_CUM"].Visible == false) return;

            for (int i = 0; i < grvPhuTung.Columns.Count; i++)
            {
                grvPhuTung.Columns[i].OptionsColumn.ReadOnly = true;
                grvPhuTung.Columns[i].OptionsColumn.AllowEdit = false;
            }
      
           

            grvPhuTung.Columns["TEN_PT"].Width = 165;
            grvPhuTung.Columns["SL_TT"].Width = 70;
            grvPhuTung.Columns["SL_TT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            grvPhuTung.Columns["MS_VI_TRI_PT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grvPhuTung.Columns["MS_VI_TRI_PT"].Width = 100;
            grvPhuTung.Columns["GHI_CHU"].OptionsColumn.ReadOnly = false;
            grvPhuTung.Columns["SL_TT"].OptionsColumn.ReadOnly = false;
            grvPhuTung.Columns["GHI_CHU"].OptionsColumn.AllowEdit = true;
            grvPhuTung.Columns["SL_TT"].OptionsColumn.AllowEdit = true;
            grvPhuTung.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
            grvPhuTung.Columns["MS_CV"].Visible = false;
            grvPhuTung.Columns["MS_BO_PHAN"].Visible = false;
            grvPhuTung.Columns["TON_TAI"].Visible = false;
            grvPhuTung.Columns["MS_PT_CHA"].Visible = false;
            grvPhuTung.Columns["MS_VI_TRI_PT"].Visible = true;
            grvPhuTung.Columns["SL_KH"].Visible = false;
            grvPhuTung.Columns["SL_CUM"].Visible = false;
            try
            {
                grvPhuTung.Columns["STT"].Visible = false;

            }
            catch
            {
            }

        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            blnDv = false;
            HideButton(true);
            HideDelete(false);
            HideSave(false);
            grvDichVu.OptionsBehavior.Editable = false;
            grvCongViec.OptionsBehavior.Editable = false;
            grvPhuTung.OptionsBehavior.Editable = false;
            grvDichVu.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            grdCongViec.Enabled = true;
            grdPhuTung.Enabled = true;
            grdDanhGia.Enabled = true;
            grdDichVu.Enabled = true;
            DropTable4();
        }

        public void DropTable4()
        {
            Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_SERVICE_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_TMP1" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CV_PHU_TRO_TMP1" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" + Commons.Modules.UserName);
        }

        public void ThemSuaCV()
        {
            blnDv = false;
            bThem = 4;
            HideButton(false);
            HideDelete(false);
            HideSave(true);
            LoadTableTmp4();
            grvCongViec.OptionsBehavior.Editable = true;
            grvPhuTung.OptionsBehavior.Editable = true;

            grdCongViec.Enabled = true;
            grdPhuTung.Enabled = true;
            grdDanhGia.Enabled = true;
            grdDichVu.Enabled = false;
        }
        private void btnKhongXoa4_Click(object sender, EventArgs e)
        {
            HideButton(true);
            HideDelete(false);
            HideSave(false);
        }


        private void LoadTableTmp4()
        {
            string str = "";
            try
            {
                try
                {
                    str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" + Commons.Modules.UserName;
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }
                str = "CREATE TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" + Commons.Modules.UserName + " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV INT, MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(30),STT INT ,MS_VI_TRI_PT NVARCHAR(50),SL_KH FLOAT, SL_TT FLOAT,SL_CUM FLOAT,THAY_SUA BIT) ";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                try
                {
                    str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" + Commons.Modules.UserName;
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }
                str = "CREATE TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_TMP1" + Commons.Modules.UserName + " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV INT, MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(30),STT INT ,MS_VI_TRI_PT NVARCHAR(50),SL_KH FLOAT, SL_TT FLOAT,SL_CUM FLOAT,THAY_SUA BIT) ";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                try
                {
                    str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_TMP1" + Commons.Modules.UserName;
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }
                str = "CREATE TABLE PHIEU_BAO_TRI_CONG_VIEC_TMP1" + Commons.Modules.UserName + " (MS_PHIEU_BAO_TRI NVARCHAR(30),MS_CV INT, MA_CV NVARCHAR(255),MS_BO_PHAN NVARCHAR(50),TEN_BO_PHAN NVARCHAR(255),SO_GIO_KH FLOAT,DINH_MUC_KH VARCHAR(50), SO_GIO_PB float,DINH_MUC_PB float,HANG_MUC_ID INT ,EOR_ID NVARCHAR(30),BAC_THO int,THUC_KIEM NVARCHAR(1000),GHI_CHU NVARCHAR(255),STT_EOR INT,MSCVBT NVARCHAR(1000),TON_TAI BIT,THAO_TAC NVARCHAR(1000),TIEU_CHUAN_KT NVARCHAR(1000)) ";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

                try
                {
                    str = "DROP TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" + Commons.Modules.UserName;
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }
                str = "CREATE TABLE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" + Commons.Modules.UserName + " (MS_PHIEU_BAO_TRI NVARCHAR(20),MS_CV int,MS_BO_PHAN NVARCHAR(50),MS_PT NVARCHAR(25),TEN_PT NVARCHAR(100),MS_VI_TRI_PT NVARCHAR(50),MS_PT_NCC NVARCHAR(255),MS_PT_CTY NVARCHAR(255),SL_KH FLOAT,SL_TT FLOAT,GHI_CHU NVARCHAR(255),MS_PT_CHA NVARCHAR(50),TON_TAI BIT,SL_CUM FLOAT)";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

                try
                {
                    str = "DROP TABLE PTB_DANH_GIA_SERVICE" + Commons.Modules.UserName;
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }
                str = "CREATE TABLE PTB_DANH_GIA_SERVICE" + Commons.Modules.UserName + " ([MS_PBT] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[STT_EOR] [int] NOT NULL,[NOI_DUNG] [nvarchar] (50),[MS_DANH_GIA] [int] NOT NULL,[DIEM] [float] NULL) ON [PRIMARY]";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

                try
                {
                    str = "DROP TABLE PHIEU_BAO_TRI_SERVICE_TMP" + Commons.Modules.UserName;

                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }
                str = "CREATE TABLE [dbo].[PHIEU_BAO_TRI_SERVICE_TMP" + Commons.Modules.UserName + "] ([MS_PHIEU_BAO_TRI] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,[STT] [int] NOT NULL, " + "[NOI_DUNG_SERVICE] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,[MS_KH] [nvarchar] (7) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,[NGUOI_GIAO_DICH] [int] NULL , " + "[SO_LUONG] [int] NULL ,[DON_GIA] [float] NULL ,[NGOAI_TE] [nvarchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,[TY_GIA] [float] NULL ,[TY_GIA_USD] [float] NULL ,[EOR_ID] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL , " + "[STT_EOR] [int] NULL ,[MnR] [bit] NULL ,[BAO_HANH_DEN] [datetime] NULL ,[DIEM] [int] NULL ,[NOI_DUNG_DANH_GIA] [nvarchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,[SO_HOP_DONG] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL , " + "[NGAY_HOAN_THANH] [datetime] NULL ,[GHI_CHU] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,[TON_TAI] [BIT])";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                try
                {
                    str = "DROP PROC [dbo].InsertTAM181" + Commons.Modules.UserName;
                    SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch
                {
                }
                str = "CREATE PROC [dbo].[InsertTAM181" + Commons.Modules.UserName + "] " + " @MS_PHIEU_BAO_TRI NVARCHAR(50),@MS_CV INT, @MA_CV NVARCHAR(255),@MS_BO_PHAN NVARCHAR(50),@TEN_BO_PHAN NVARCHAR(255),@SO_GIO_KH FLOAT, " + " @HANG_MUC_ID INT ,@TEN_HANG_MUC NVARCHAR(255),@EOR_ID NVARCHAR(50),@STT_EOR INT,@TEN_CHUYEN_MON NVARCHAR(200),@TEN_BAC_THO NVARCHAR(200),@THUC_KIEM NVARCHAR(1000),@GHI_CHU NVARCHAR(255),@TON_TAI BIT " + " as insert into PHIEU_BAO_TRI_CONG_VIEC_TMP1" + Commons.Modules.UserName + " (MS_PHIEU_BAO_TRI,MS_CV,MA_CV,MS_BO_PHAN,TEN_BO_PHAN,SO_GIO_KH,HANG_MUC_ID,TEN_HANG_MUC,EOR_ID,STT_EOR,TEN_CHUYEN_MON ,TEN_BAC_THO,THUC_KIEM,GHI_CHU ,TON_TAI ) " + " values(@MS_PHIEU_BAO_TRI ,@MS_CV , @MA_CV ,@MS_BO_PHAN ,@TEN_BO_PHAN ,@SO_GIO_KH ,@HANG_MUC_ID ,@TEN_HANG_MUC ,@EOR_ID,@STT_EOR,@TEN_CHUYEN_MON ,@TEN_BAC_THO ,@THUC_KIEM,@GHI_CHU ,@TON_TAI)";




                str = " CREATE PROC [dbo].[InsertTAM181" + Commons.Modules.UserName + "]  " + " @MS_PHIEU_BAO_TRI NVARCHAR(30),@MS_CV INT,@MA_CV NVARCHAR(255),@MS_BO_PHAN NVARCHAR(50), " + " @TEN_BO_PHAN NVARCHAR(255),@SO_GIO_KH FLOAT,@DINH_MUC_KH varchar(50),@SO_GIO_PB float,@DINH_MUC_PB float,@HANG_MUC_ID INT, " + " @EOR_ID NVARCHAR(30),@BAC_THO int,@THUC_KIEM NVARCHAR(1000),@GHI_CHU NVARCHAR(255),@STT_EOR INT, " + " @MSCVBT NVARCHAR(1000),@TON_TAI BIT , @THAO_TAC NVARCHAR(1000), @TIEU_CHUAN_KT NVARCHAR(1000)  " + " as insert into PHIEU_BAO_TRI_CONG_VIEC_TMP1" + Commons.Modules.UserName + " (MS_PHIEU_BAO_TRI,MS_CV,MA_CV, " + " MS_BO_PHAN,TEN_BO_PHAN,SO_GIO_KH, DINH_MUC_KH,SO_GIO_PB,DINH_MUC_PB,HANG_MUC_ID,EOR_ID,BAC_THO,THUC_KIEM,GHI_CHU,STT_EOR, " + " MSCVBT, TON_TAI,THAO_TAC ,TIEU_CHUAN_KT  )   " + " values(@MS_PHIEU_BAO_TRI,@MS_CV,@MA_CV,@MS_BO_PHAN,@TEN_BO_PHAN,@SO_GIO_KH,Null,@SO_GIO_PB, " + " @DINH_MUC_PB,@HANG_MUC_ID,@EOR_ID,@BAC_THO,@THUC_KIEM,@GHI_CHU,@STT_EOR,@MSCVBT,@TON_TAI,@THAO_TAC,@TIEU_CHUAN_KT ) ";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                for (int i = 0; i <= grvCongViec.RowCount - 1; i++)
                {
                    string tmp = "";
                    if (grvCongViec.GetDataRow(i)["SO_GIO_KH"] == null)
                    {
                        tmp = null;
                    }
                    else
                    {
                        tmp = grvCongViec.GetDataRow(i)["SO_GIO_KH"].ToString();
                    }
                    try
                    {
                        int vstt = -1;
                        try
                        {
                            vstt = Convert.ToInt32(grvCongViec.GetDataRow(i)["STT_EOR"]);

                        }
                        catch
                        {
                        }
                        SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "InsertTAM181" + Commons.Modules.UserName, (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["MS_PHIEU_BAO_TRI"].ToString()) ? null : grvCongViec.GetDataRow(i)["MS_PHIEU_BAO_TRI"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["MS_CV"].ToString()) ? null : grvCongViec.GetDataRow(i)["MS_CV"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["MA_CV"].ToString()) ? null : grvCongViec.GetDataRow(i)["MA_CV"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["MS_BO_PHAN"].ToString()) ? null : grvCongViec.GetDataRow(i)["MS_BO_PHAN"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["TEN_BO_PHAN"].ToString()) ? null : grvCongViec.GetDataRow(i)["TEN_BO_PHAN"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["SO_GIO_KH"].ToString()) ? null : grvCongViec.GetDataRow(i)["SO_GIO_KH"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["DINH_MUC_KH"].ToString()) ? null : grvCongViec.GetDataRow(i)["DINH_MUC_KH"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["SO_GIO_PB"].ToString()) ? null : grvCongViec.GetDataRow(i)["SO_GIO_PB"]),
                        (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["DINH_MUC_PB"].ToString()) ? null : grvCongViec.GetDataRow(i)["DINH_MUC_PB"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["HANG_MUC_ID"].ToString()) ? null : grvCongViec.GetDataRow(i)["HANG_MUC_ID"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["EOR_ID"].ToString()) ? null : grvCongViec.GetDataRow(i)["EOR_ID"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["BAC_THO"].ToString()) ? null : grvCongViec.GetDataRow(i)["BAC_THO"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["THUC_KIEM"].ToString()) ? null : grvCongViec.GetDataRow(i)["THUC_KIEM"]), (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["GHI_CHU"].ToString()) ? null : grvCongViec.GetDataRow(i)["GHI_CHU"]), vstt, (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["MSCVBT"].ToString()) ? null : grvCongViec.GetDataRow(i)["MSCVBT"]), 1, (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["THAO_TAC"].ToString()) ? null : grvCongViec.GetDataRow(i)["THAO_TAC"]),
                        (string.IsNullOrEmpty(grvCongViec.GetDataRow(i)["TIEU_CHUAN_KT"].ToString()) ? null : grvCongViec.GetDataRow(i)["TIEU_CHUAN_KT"]));
                    }
                    catch
                    {
                    }
                }
                //lay toan bo phieu bao tri cong viec phu tung thuê ngoài luu vao bang tam 
                str = "INSERT INTO PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" + Commons.Modules.UserName + " SELECT DISTINCT PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV, " + " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN, PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT, TEN_PT,TMP.MS_VI_TRI_PT,MS_PT_NCC,MS_PT_CTY , " + "(SELECT PBTCT.SL_KH FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET PBTCT WHERE " + " PBTCT.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND PBTCT.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND " + " PBTCT.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND PBTCT.MS_VI_TRI_PT=TMP.MS_VI_TRI_PT AND PBTCT.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV)AS SL_KH " + " ,(SELECT PBTCT.SL_TT FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET PBTCT WHERE  " + " PBTCT.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND PBTCT.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND " + " PBTCT.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND PBTCT.MS_VI_TRI_PT=TMP.MS_VI_TRI_PT AND PBTCT.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV)AS SL_TT," + " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.GHI_CHU, (CASE WHEN CAU_TRUC_THIET_BI_PHU_TUNG.MS_VI_TRI_PT IS NULL THEN 'N' ELSE 'Y' END) AS MS_PT_CHA ,CONVERT(BIT,1)" + " ,CASE WHEN (SELECT CTTBPT.MS_VI_TRI_PT FROM CAU_TRUC_THIET_BI_PHU_TUNG CTTBPT WHERE CTTBPT.MS_MAY=N'" + sMsMay + "' AND CTTBPT.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN " + " AND CTTBPT.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND CTTBPT.MS_VI_TRI_PT=TMP.MS_VI_TRI_PT)IS NULL THEN " + " (SELECT CTTB.SO_LUONG FROM CAU_TRUC_THIET_BI CTTB WHERE CTTB.MS_MAY= '" + sMsMay + "' AND CTTB.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND CTTB.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT) ELSE " + " (SELECT CTTBPT.SO_LUONG FROM CAU_TRUC_THIET_BI_PHU_TUNG CTTBPT WHERE CTTBPT.MS_MAY=N'" + sMsMay + "' AND CTTBPT.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN " + " AND CTTBPT.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT AND CTTBPT.MS_VI_TRI_PT=TMP.MS_VI_TRI_PT ) END AS SL_CUM " + " FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG INNER JOIN " + " IC_PHU_TUNG ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = IC_PHU_TUNG.MS_PT LEFT OUTER JOIN " + " CAU_TRUC_THIET_BI_PHU_TUNG ON  " + " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = CAU_TRUC_THIET_BI_PHU_TUNG.MS_BO_PHAN AND " + " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI_PHU_TUNG.MS_PT AND " + " CAU_TRUC_THIET_BI_PHU_TUNG.MS_MAY=N'" + sMsMay + "' " + " INNER JOIN PHIEU_BAO_TRI_CONG_VIEC ON PHIEU_BAO_TRI_CONG_VIEC.MS_PHIEU_BAO_TRI= PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI AND " + " PHIEU_BAO_TRI_CONG_VIEC.MS_CV= PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND PHIEU_BAO_TRI_CONG_VIEC.MS_BO_PHAN= PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN AND PHIEU_BAO_TRI_CONG_VIEC.STT_SERVICE IS  NOT NULL " + " LEFT OUTER JOIN CAU_TRUC_THIET_BI ON PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = CAU_TRUC_THIET_BI.MS_BO_PHAN AND " + " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = CAU_TRUC_THIET_BI.MS_PT AND CAU_TRUC_THIET_BI.MS_MAY ='" + sMsMay + "' " + " LEFT JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET TMP ON TMP.MS_PHIEU_BAO_TRI=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI " + " AND TMP.MS_CV=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV AND TMP.MS_BO_PHAN=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN " + " AND TMP.MS_PT=PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT " + " LEFT join PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET ON " + " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PHIEU_BAO_TRI AND  " + " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_CV = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_CV AND  " + " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PT = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_PT AND  " + " PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_BO_PHAN = PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET.MS_BO_PHAN " + " WHERE PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG.MS_PHIEU_BAO_TRI='" + sMsPBT + "'";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
                //LẤY TOÀN BỘ CÁC ĐÁNH GIÁ CỦA TỪNG SERVICE ĐƯA VÀO BẢNG TẠM
                str = "INSERT INTO PTB_DANH_GIA_SERVICE" + Commons.Modules.UserName + " SELECT PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT,PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR,DANH_GIA_SERVICE.NOI_DUNG,DANH_GIA_SERVICE.ID,PHIEU_BAO_TRI_DANH_GIA_SERVICE.DIEM " + "FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE INNER JOIN DANH_GIA_SERVICE ON DANH_GIA_SERVICE.ID=PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA " + "WHERE PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT='" + sMsPBT + "'";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

            }
            catch
            {
            }
        }

        private void grvPhuTung_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (btnThemSuaCV.Visible == true) return;
            string sBTam = "PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_TMP1" + Commons.Modules.UserName;
            try
            {
                Convert.ToDouble(grvPhuTung.GetDataRow(e.RowHandle)["SL_TT"].ToString());
                string sql = "UPDATE " + sBTam + " SET SL_TT = " + grvPhuTung.GetDataRow(e.RowHandle)["SL_TT"].ToString() + ", GHI_CHU = N'" + grvPhuTung.GetDataRow(e.RowHandle)["GHI_CHU"].ToString() + "' WHERE MS_CV = '" + grvCongViec.GetFocusedDataRow()["MS_CV"].ToString() + "' AND MS_BO_PHAN = '" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString() + "' AND MS_PT = '" + grvPhuTung.GetDataRow(e.RowHandle)["MS_PT"].ToString() + "' AND MS_VI_TRI_PT = N'" + grvPhuTung.GetDataRow(e.RowHandle)["MS_VI_TRI_PT"].ToString() + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql);
            }
            catch
            {
                e.Valid = false;
            }
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDichVu.RowCount == 0) return;
                btnGhiDanhGia.Visible = true;
                btnKGhiDanhGia.Visible = true;
                btnDanhGia.Visible = false;
                panel1.Enabled = false;
                grdCongViec.Enabled = false;
                grdDichVu.Enabled = false;
                grdPhuTung.Enabled = false;
                LoadDanhGia();
            }
            catch { }
        }

        private void LoadDanhGia()
        {
            DataTable dt = new DataTable();
            string str = "";
            if (grvDichVu.RowCount == 0) return;
            if (btnGhiDanhGia.Visible == true)
            {
                str = "SELECT TMP.* FROM (SELECT PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT,PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR,DANH_GIA_SERVICE.ID,DANH_GIA_SERVICE.NOI_DUNG,PHIEU_BAO_TRI_DANH_GIA_SERVICE.DIEM FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE INNER JOIN DANH_GIA_SERVICE ON DANH_GIA_SERVICE.ID=PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA WHERE PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT='" + sMsPBT + "' AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR=" + grvDichVu.GetFocusedDataRow()["STT"].ToString() + " " + "UNION " + "SELECT '" + sMsPBT + "' AS MS_PBT," + grvDichVu.GetFocusedDataRow()["STT"].ToString() + " AS STT_EOR,DANH_GIA_SERVICE.ID,DANH_GIA_SERVICE.NOI_DUNG,0 AS DIEM FROM DANH_GIA_SERVICE " + "WHERE ID NOT IN (SELECT DANH_GIA_SERVICE.ID FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE INNER JOIN DANH_GIA_SERVICE ON DANH_GIA_SERVICE.ID=PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA WHERE PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT='" + sMsPBT + "' AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR=" + grvDichVu.GetFocusedDataRow()["STT"].ToString() + ")) TMP WHERE TMP.ID > 0 " + (btnGhiDanhGia.Enabled == true ? "" : "AND TMP.DIEM>0") + " ORDER BY ID";
            }
            else
            {

                str = "SELECT PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT,PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR,DANH_GIA_SERVICE.ID,DANH_GIA_SERVICE.NOI_DUNG,PHIEU_BAO_TRI_DANH_GIA_SERVICE.DIEM FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE INNER JOIN DANH_GIA_SERVICE ON DANH_GIA_SERVICE.ID=PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_DANH_GIA WHERE DIEM>0 AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.MS_PBT='" + sMsPBT + "' AND PHIEU_BAO_TRI_DANH_GIA_SERVICE.STT_EOR=" + grvDichVu.GetFocusedDataRow()["STT"].ToString();
            }
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
            }
            catch
            { }
            dt.Columns["DIEM"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDanhGia, grvDanhGia, dt, btnGhiDanhGia.Visible ? true : false, true, true, true, true, "FrmPhieuBaoTri_New");
            try
            {
                grvDanhGia.Columns["MS_PBT"].Visible = false;
                grvDanhGia.Columns["STT_EOR"].Visible = false;
                grvDanhGia.Columns["ID"].Visible = false;
                grvDanhGia.Columns["NOI_DUNG"].OptionsColumn.AllowEdit = false;
                grvDanhGia.Columns["DIEM"].Width = 50;
            }
            catch
            {
            }
        }

        private void btnGhiDanhGia_Click(object sender, EventArgs e)
        {
            SqlConnection sConn = new SqlConnection(Commons.IConnections.ConnectionString);
            if (sConn.State != ConnectionState.Open)
            {
                sConn.Open();
            }
            SqlTransaction trans = null;
            try
            {
                string str = "";
                for (int i = 0; i <= grvDanhGia.RowCount - 1; i++)
                {
                    trans = sConn.BeginTransaction();
                    if (Convert.ToInt32(grvDanhGia.GetDataRow(i)["DIEM"]) > 0)
                    {
                        str = "UPDATE PHIEU_BAO_TRI_DANH_GIA_SERVICE SET DIEM=" + grvDanhGia.GetDataRow(i)["DIEM"].ToString() + " WHERE MS_PBT='" + sMsPBT + "' AND STT_EOR=" + grvDichVu.GetFocusedDataRow()["STT"].ToString() + " AND MS_DANH_GIA=" + grvDanhGia.GetDataRow(i)["ID"];
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, str);

                        str = "INSERT INTO PHIEU_BAO_TRI_DANH_GIA_SERVICE(MS_PBT, STT_EOR, MS_DANH_GIA, DIEM) " +
                            " SELECT '" + sMsPBT + "', " + grvDichVu.GetFocusedDataRow()["STT"].ToString() + ", " + grvDanhGia.GetDataRow(i)["ID"].ToString() + ", " + grvDanhGia.GetDataRow(i)["DIEM"].ToString() + " WHERE NOT EXISTS (SELECT * FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE T WHERE T.MS_PBT='" + sMsPBT + "' AND T.STT_EOR=" + grvDichVu.GetFocusedDataRow()["STT"].ToString() + " AND T.MS_DANH_GIA=" + grvDanhGia.GetDataRow(i)["ID"] + ")";
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, str);
                    }
                    else
                    {
                        str = "DELETE FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE WHERE MS_PBT='" + sMsPBT + "' AND STT_EOR=" + grvDichVu.GetFocusedDataRow()["STT"].ToString() + " AND MS_DANH_GIA=" + grvDanhGia.GetDataRow(i)["ID"];
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, str);
                    }
                    trans.Commit();
                }
                if (sConn.State == ConnectionState.Open)
                {
                    sConn.Close();
                }
                btnGhiDanhGia.Visible = false;
                btnKGhiDanhGia.Visible = false;
                btnDanhGia.Visible = true;
                panel1.Enabled = true;
                grdCongViec.Enabled = true;
                grdDichVu.Enabled = true;
                grdPhuTung.Enabled = true;
                grdDanhGia.Enabled = true;
                LoadDanhGia();
            }
            catch { trans.Rollback(); }
        }

        private void btnKGhiDanhGia_Click(object sender, EventArgs e)
        {
            btnGhiDanhGia.Visible = false;
            btnKGhiDanhGia.Visible = false;
            btnDanhGia.Visible = true;
            panel1.Enabled = true;
            grdCongViec.Enabled = true;
            grdDichVu.Enabled = true;
            grdPhuTung.Enabled = true;
            grdDanhGia.Enabled = true;
            LoadDanhGia();
        }

        private void grvDanhGia_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(grvDanhGia.GetDataRow(e.RowHandle)["DIEM"].ToString()) < 0 || Convert.ToDouble(grvDanhGia.GetDataRow(e.RowHandle)["DIEM"].ToString()) > 10)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "THANG_DIEM_KHONG_HOP_LE", Commons.Modules.TypeLanguage), this.Text);
                    e.Valid = false;
                }
            }
            catch
            {
                e.Valid = false;
            }
        }

        private void grvDanhGia_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            if (grvDichVu.RowCount < 1)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_New", "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage));
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_New", "msgKT10", Commons.Modules.TypeLanguage), ParentForm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            string str = "";

            if (Convert.ToBoolean(grvDichVu.GetFocusedDataRow()["MnR"].ToString()))
            {
                str = "UPDATE EOR_SERVICE_MNR SET MS_PHIEU_BAO_TRI=NULL " + " WHERE EOR_ID='" + grvDichVu.GetFocusedDataRow()["EOR_ID"] + "' AND STT=" + grvDichVu.GetFocusedDataRow()["STT"];

            }
            else
            {
                str = "UPDATE EOR_SERVICE_CHUNG SET MS_PHIEU_BAO_TRI=NULL " + " WHERE EOR_ID='" + grvDichVu.GetFocusedDataRow()["EOR_ID"] + "' AND STT=" + grvDichVu.GetFocusedDataRow()["STT"];

            }
            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);

            try
            {
                str = " DELETE T1 FROM PHIEU_BAO_TRI_CONG_VIEC T INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET T1 ON T.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI WHERE STT_SERVICE =" + grvDichVu.GetFocusedDataRow()["STT"] + ")";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }

            try
            {
                str = " DELETE T1 FROM PHIEU_BAO_TRI_CONG_VIEC T INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG T1 ON T.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI WHERE STT_SERVICE =" + grvDichVu.GetFocusedDataRow()["STT"] + ")";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }


            try
            {
                str = "  DELETE T1 FROM PHIEU_BAO_TRI_CONG_VIEC T INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU_CHI_TIET T1 ON T.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI WHERE STT_SERVICE =" + grvDichVu.GetFocusedDataRow()["STT"] + ")";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }


            try
            {
                str = "DELETE T1 FROM PHIEU_BAO_TRI_CONG_VIEC T INNER JOIN PHIEU_BAO_TRI_CONG_VIEC_NHAN_SU T1 ON T.MS_PHIEU_BAO_TRI = T1.MS_PHIEU_BAO_TRI WHERE STT_SERVICE =" + grvDichVu.GetFocusedDataRow()["STT"] + ")";
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }

            try
            {
                str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_PHIEU_BAO_TRI= N'" + sMsPBT + "' AND STT_SERVICE=" + grvDichVu.GetFocusedDataRow()["STT"];
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }

            try
            {
                str = "DELETE FROM PHIEU_BAO_TRI_DANH_GIA_SERVICE WHERE MS_PBT='" + sMsPBT + "' AND STT_EOR=" + grvDichVu.GetFocusedDataRow()["STT"];
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }

            try
            {
                str = "DELETE FROM PHIEU_BAO_TRI_SERVICE WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND STT=" + grvDichVu.GetFocusedDataRow()["STT"];
                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, str);
            }
            catch
            {
            }
            grvDichVu.DeleteRow(grvDichVu.FocusedRowHandle);
            grvDichVu_FocusedRowChanged(null, null);
            if (grvDichVu.RowCount == 0)
            {
                grdDanhGia.DataSource = null;
                btnDanhGia.Enabled = false;
            }
            try
            {
                if (grvDichVu.RowCount <= 0) btnThemSuaCV.Enabled = false; else btnThemSuaCV.Enabled = true;
            }
            catch
            { btnThemSuaCV.Visible = true; }

        }

        private void btnXoaCongViec_Click(object sender, EventArgs e)
        {

            if (grvCongViec.RowCount == 0)
            {

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_New", "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage));
                return;
            }
            else
            {
                clsPHIEU_BAO_TRIController objPHIEU_BAO_TRIController = new clsPHIEU_BAO_TRIController();
                if (!objPHIEU_BAO_TRIController.CheckPHIEU_BAO_TRI_CONG_VIEC(sMsPBT, Convert.ToInt32(grvCongViec.GetFocusedDataRow()["MS_CV"].ToString()), grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString()))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_New", "MsgCongViecDaSD", Commons.Modules.TypeLanguage));
                    return;
                }
                else
                {

                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_New", "MsgXoaCongViec", Commons.Modules.TypeLanguage), ParentForm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC(sMsPBT, Convert.ToInt32(grvCongViec.GetFocusedDataRow()["MS_CV"].ToString()), grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"].ToString());
                        if (!string.IsNullOrEmpty(grvCongViec.GetFocusedDataRow()["HANG_MUC_ID"].ToString()))
                        {
                            SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "DeleteKE_HOACH_TONG_CONG_VIEC", sMsMay, grvCongViec.GetFocusedDataRow()["HANG_MUC_ID"], grvCongViec.GetFocusedDataRow()["MS_CV"], grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"], sMsPBT);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(grvCongViec.GetFocusedDataRow()["EOR_ID"].ToString()))
                            {
                                SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "UPDATE EOR_CONG_VIEC SET MS_PHIEU_BAO_TRI =NULL WHERE EOR_ID='" + grvCongViec.GetFocusedDataRow()["EOR_ID"] + "' AND MS_CV=" + grvCongViec.GetFocusedDataRow()["MS_CV"] + " AND MS_BO_PHAN='" + grvCongViec.GetFocusedDataRow()["MS_BO_PHAN"] + "' AND MS_PHIEU_BAO_TRI='" + sMsPBT + "'");
                            }
                        }
                    }
                }
            }
            grvDichVu_FocusedRowChanged(null, null);
        }


        public void ShowButtonXoa()
        {
            HideDelete(true);
            HideButton(false);
            HideSave(false);
        }

        private void btnXoaPhuTung_Click(object sender, EventArgs e)
        {
            if (grvPhuTung.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_New", "MsgKhongCoDuLieu_XOA", Commons.Modules.TypeLanguage));
                return;
            }
            else
            {
                clsPHIEU_BAO_TRIController objPHIEU_BAO_TRIController = new clsPHIEU_BAO_TRIController();
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_New", "MsgXoaPT", Commons.Modules.TypeLanguage), ParentForm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (grvPhuTung.GetFocusedDataRow()["MS_VI_TRI_PT"] == null || grvPhuTung.GetFocusedDataRow()["MS_VI_TRI_PT"].ToString() == "")
                    {
                        SqlDataReader dtReader = default(SqlDataReader);
                        dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_MAY,MS_BO_PHAN,MS_PT FROM CAU_TRUC_THIET_BI WHERE MS_MAY=N'" + sMsMay + "' AND MS_BO_PHAN='" + grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"] + "'");
                        while (dtReader.Read())
                        {
                            string str = "DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvPhuTung.GetFocusedDataRow()["MS_CV"] + " AND MS_BO_PHAN ='" + grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"] + "' AND MS_PT='" + dtReader["MS_PT"] + "' " + " DELETE FROM PHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG WHERE MS_PHIEU_BAO_TRI='" + sMsPBT + "' AND MS_CV=" + grvPhuTung.GetFocusedDataRow()["MS_CV"] + " AND MS_BO_PHAN ='" + grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"] + "' AND MS_PT='" + dtReader["MS_PT"] + "' ";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        }
                        dtReader.Close();

                        objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_THUE_NGOAI_1(sMsPBT, Convert.ToInt32(grvPhuTung.GetFocusedDataRow()["MS_CV"].ToString()), grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString());
                    }
                    else
                    {
                        objPHIEU_BAO_TRIController.DeletePHIEU_BAO_TRI_CONG_VIEC_PHU_TUNG_CHI_TIET_THUE_NGOAI(sMsPBT, Convert.ToInt32(grvPhuTung.GetFocusedDataRow()["MS_CV"].ToString()), grvPhuTung.GetFocusedDataRow()["MS_BO_PHAN"].ToString(), grvPhuTung.GetFocusedDataRow()["MS_PT"].ToString(), Convert.ToInt32(grvPhuTung.GetFocusedDataRow()["STT"].ToString()));
                    }
                }
                grvCongViec_FocusedRowChanged(null, null);
            }
        }
    }
}
