using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace ReportHuda
{
    public partial class ucHieuChuan : DevExpress.XtraEditors.XtraUserControl
    {
        private string sMMay;
        public Boolean bThemSua = false;
        public ucHieuChuan()
        {
            InitializeComponent();
            
        }
        public event EventHandler ButtonClick;

        protected void Button1_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);


        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
        }

        
        private void btnGhi_Click(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdHC.DataSource;
            string sBT = "HC" + Commons.Modules.UserName;
            string sSql;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
            sSql = "SELECT COUNT(*) AS STT, ROW_NUMBER() OVER (ORDER BY MS_PT,MS_VI_TRI ) AS SATT FROM " + sBT + " GROUP BY MS_PT,MS_VI_TRI HAVING COUNT(*) > 1 ORDER BY MS_PT,MS_VI_TRI ";
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmThongtinthietbi", "MsgQuyenKT1", Commons.Modules.TypeLanguage));
                return;
            }

            Commons.Modules.ObjSystems.XoaTable(sBT);
            sBT = "HC";
            dtTmp = new DataTable();
            dtTmp = (DataTable)grdHC.DataSource;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "CapNhapHieuChuan", sMMay);

            LockControl(true);
            LoadLuoi(sMMay);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            LockControl(true);

        }

        private void LockControl(Boolean bLock)
        {
            bThemSua = !bLock;
            btnGhi.Visible = !bLock;
            btnKhong.Visible = !bLock;
            btnThemSua.Visible = bLock;
            btnXoa.Visible = bLock;
            btnExit.Visible = bLock;

            if (bLock) grvHC.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False; else grvHC.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            if (bLock)
            {
                grvHC.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                grvHC.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            }
            else
            {
                grvHC.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                grvHC.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            }
            grvHC.OptionsBehavior.Editable = !bLock;
        }

        public void LoadLuoi(string sMsMay)
        {
            sMMay = sMsMay;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHU_KY_HIEU_CHUAN", sMsMay));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdHC, grvHC, dtTmp, false, false, false, false);

            
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPHU_TUNG"));
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboPT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboPT.NullText = "";
            cboPT.ValueMember = "MS_PT";
            cboPT.DisplayMember = "MS_PT";
            cboPT.DataSource = dtTmp;
            cboPT.Columns.Clear();
            cboPT.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_PT"));
            cboPT.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_PT"));
            cboPT.PopupWidth = 625;
            cboPT.Columns["MS_PT"].Width = 150;
            cboPT.Columns["TEN_PT"].Width = 450;
            grvHC.Columns["MS_PT"].ColumnEdit = cboPT;

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetDON_VI_THOI_GIANs", Commons.Modules.TypeLanguage));
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboDVTG = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboDVTG.NullText = "";
            cboDVTG.ValueMember = "MS_DV_TG";
            cboDVTG.DisplayMember = "TEN_DV_TG";
            cboDVTG.DataSource = dtTmp;
            cboDVTG.Columns.Clear();
            cboDVTG.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_DV_TG"));
            grvHC.Columns["MS_DV_TG"].ColumnEdit = cboDVTG;




            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit txtHCNoi = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            txtHCNoi.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            txtHCNoi.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(txtHCNoi_ParseEditValue);
            txtHCNoi.EditMask = "n0";
            txtHCNoi.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtHCNoi.EditFormat.FormatString = "n0";
            txtHCNoi.DisplayFormat.FormatString = "n0";
            grvHC.Columns["CHU_KY_HC_NOI"].ColumnEdit = txtHCNoi;


            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit txtHCNgoai = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            txtHCNgoai.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            txtHCNgoai.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(txtHCNgoai_ParseEditValue);
            txtHCNgoai.EditMask = "n0";
            txtHCNgoai.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtHCNgoai.EditFormat.FormatString = "n0";
            txtHCNgoai.DisplayFormat.FormatString = "n0";
            grvHC.Columns["CHU_KY_HC_NGOAI"].ColumnEdit = txtHCNgoai;


            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit txtHCKD = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            txtHCKD.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            txtHCKD.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(txtHCKD_ParseEditValue);
            txtHCKD.EditMask = "n0";
            txtHCKD.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtHCKD.EditFormat.FormatString = "n0";
            txtHCKD.DisplayFormat.FormatString = "n0";
            grvHC.Columns["CHU_KY_KD"].ColumnEdit = txtHCKD;


            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit txtHCKT = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            txtHCKT.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            txtHCKT.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(txtHCKT_ParseEditValue);
            txtHCKT.EditMask = "n0";
            txtHCKT.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtHCKT.EditFormat.FormatString = "n0";
            txtHCKT.DisplayFormat.FormatString = "n0";
            grvHC.Columns["CHU_KY_KT"].ColumnEdit = txtHCKT;

            if (btnGhi.Visible == false)
            {
                grvHC.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                grvHC.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                grvHC.OptionsBehavior.Editable = false;
            }
            if (!grvHC.Columns["MS_PT_OLD"].Visible) return;
            grvHC.Columns["MS_PT_OLD"].Visible = false;
            grvHC.Columns["MS_VI_TRI_OLD"].Visible = false;

            grvHC.OptionsView.ColumnAutoWidth = true;
            grvHC.BestFitColumns();

            grvHC.Columns["MS_PT"].Width = 120;
            grvHC.Columns["MS_VI_TRI"].Width = 160;
            grvHC.Columns["CHU_KY_HC_NOI"].Width = 100;
            grvHC.Columns["CHU_KY_HC_NGOAI"].Width = 100;
            grvHC.Columns["CHU_KY_KD"].Width = 90;
            grvHC.Columns["CHU_KY_KT"].Width = 90;
            grvHC.Columns["MS_DV_TG"].Width = 90;
            grvHC.Columns["GHI_CHU"].Width = 160;
            //grvHC.OptionsView.ColumnAutoWidth = false;
        }

        private void grvHC_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (!btnGhi.Visible) return;
            if (!KiemDuLieu(true))
                e.Valid = false;
        }

        private Boolean KiemDuLieu(Boolean Msg)
        {

            if (grvHC.GetFocusedRowCellValue("MS_PT").ToString() == "")
            {
                if (Msg)
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmThongtinthietbi", "Msg_DUNG_CU_DO_NULL", Commons.Modules.TypeLanguage));
                return false;
            }

            if (grvHC.GetFocusedRowCellValue("MS_VI_TRI").ToString() == "")
            {
                if (Msg) XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmThongtinthietbi", "MS_VI_TRI_NULL", Commons.Modules.TypeLanguage));
                return false;
            }

            if (string.IsNullOrEmpty(grvHC.GetFocusedRowCellValue("CHU_KY_HC_NOI").ToString()) &&
                string.IsNullOrEmpty(grvHC.GetFocusedRowCellValue("CHU_KY_HC_NGOAI").ToString()) &&
                string.IsNullOrEmpty(grvHC.GetFocusedRowCellValue("CHU_KY_KD").ToString()) &&
                string.IsNullOrEmpty(grvHC.GetFocusedRowCellValue("CHU_KY_KT").ToString()))
            {
                if (Msg) XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmThongtinthietbi", "CHU_KY_NULL", Commons.Modules.TypeLanguage));
                return false;
            }
            if (string.IsNullOrEmpty(grvHC.GetFocusedRowCellValue("MS_DV_TG").ToString()))
            {
                if (Msg) XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmThongtinthietbi", "DV_TG_NULL", Commons.Modules.TypeLanguage));
                return false;
            }
            return true;
        }

        private void grvHC_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void txtHCNgoai_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = Convert.ToInt16(null);
                }
            }
            catch { e.Value = Convert.ToInt16(null); }
        }

        private void txtHCNoi_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = Convert.ToInt16(null);
                }
            }
            catch { e.Value = Convert.ToInt16(null); }
        }

        private void txtHCKD_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = Convert.ToInt16(null);
                }
            }
            catch { e.Value = Convert.ToInt16(null); }
        }

        private void txtHCKT_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.Value = Convert.ToInt16(null);
                }
            }
            catch { e.Value = Convert.ToInt16(null); }
        }

        private void grvHC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            


            //if (grvHC.RowCount != ((DataTable)grdHC.DataSource).Rows.Count)
            //{
            //    if (KiemDuLieu(false)) grvHC.AddNewRow();
            //}

            //if (_View.FocusedColumn.VisibleIndex == _View.VisibleColumns.Count - 1)
            //{
            //    if (_View.IsNewItemRow(_View.FocusedRowHandle))
            //        _View.UpdateCurrentRow();
            //    if (_View.IsLastRow)
            //        return AddNewRow();
            //}

            //if (grvHC.RowCount == grvHC.RowCount)
            //{
            //    if (grvHC.IsNewItemRow(grvHC.FocusedRowHandle))
            //        grvHC.UpdateCurrentRow();
            //    if (grvHC.IsLastRow)
            //        grvHC.AddNewRow();

            //}
        }

        private void grvHC_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!btnGhi.Visible) return;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!KiemXoa()) return;
           
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "MsgQuyenXoa16",
                    Commons.Modules.TypeLanguage),ParentForm.Name, MessageBoxButtons.YesNo) == DialogResult.No) return;

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteCHU_KY_HIEU_CHUAN", sMMay, 
                grvHC.GetFocusedRowCellValue("MS_PT").ToString(), grvHC.GetFocusedRowCellValue("MS_VI_TRI").ToString());
            LoadLuoi(sMMay);
        }
        private Boolean KiemXoa()
        {
            string sSql = "SELECT * FROM HIEU_CHUAN_DHD WHERE MS_MAY = '" + sMMay + "' " +
               " AND MS_PT = '" + grvHC.GetFocusedRowCellValue("MS_PT").ToString() + "' " +
               " AND MS_VI_TRI = '" + grvHC.GetFocusedRowCellValue("MS_VI_TRI").ToString() + "'";
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmThongtinthietbi", "MsgQuyenKT78", Commons.Modules.TypeLanguage));
                return false;
            }
            return true;
        }
        private void grvHC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (!KiemXoa()) return;
                    if (!btnGhi.Visible)
                    {
                        if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThongtinthietbi", "MsgQuyenXoa16",
                                Commons.Modules.TypeLanguage), ParentForm.Name, MessageBoxButtons.YesNo) == DialogResult.No) return;

                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteCHU_KY_HIEU_CHUAN", sMMay,
                            grvHC.GetFocusedRowCellValue("MS_PT").ToString(), grvHC.GetFocusedRowCellValue("MS_VI_TRI").ToString());
                        LoadLuoi(sMMay);
                    }
                    else
                    {


                        if (grvHC.RowCount == 0)
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                            return;
                        }
                        if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "CoXoaThietBiNay",
                            Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo) == DialogResult.No) return;

                        DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                        view.DeleteRow(view.FocusedRowHandle);
                    }
                }
            }
            catch { }
        }

        private void txtTKiem_EditValueChanging(object sender, ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdHC.DataSource;
            try
            {
                string dk = "";

                if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_VI_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;

            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

    }
}
