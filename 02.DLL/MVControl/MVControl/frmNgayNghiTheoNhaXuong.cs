using System;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Globalization;

namespace MVControl
{
    public partial class frmNgayNghiTheoNhaXuong : DevExpress.XtraEditors.XtraForm
    {
        public frmNgayNghiTheoNhaXuong()
        {
            InitializeComponent();
        }

        private void frmNgayNghiTheoNhaXuong_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            dtTNgay.DateTime = Convert.ToDateTime("01/01/" + DateTime.Now.Year);
            dtDNgay.DateTime = dtTNgay.DateTime.AddYears(1).AddDays(-1);
            Commons.Modules.SQLString = "";
            LoadNgay();
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongPhanQuyen", Commons.Modules.UserName));

            tvwNhaXuong.KeyFieldName = "MS_N_XUONG";
            tvwNhaXuong.ParentFieldName = "MS_CHA";


            tvwNhaXuong.DataSource = dtTmp;
            for (int i = 1; i <= tvwNhaXuong.Columns.Count - 1; i++)
            {
                tvwNhaXuong.Columns[i].Visible = false;
            }

            tvwNhaXuong.Columns["Ten_N_XUONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "Ten_N_XUONG", Commons.Modules.TypeLanguage);
            tvwNhaXuong.ExpandAll();

            Commons.Modules.ObjSystems.ThayDoiNN(this);


        }
        private void LoadNgay()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            string sSql = "SELECT NGAY_NGHI, TU_GIO, DEN_GIO, SO_PHUT , MS_N_XUONG FROM dbo.NGAY_NGHI_NX WHERE NGAY_NGHI BETWEEN '" + dtTNgay.DateTime.Date.ToString("MM/dd/yyyy") + "' AND '" + dtDNgay.DateTime.Date.ToString("MM/dd/yyyy") + "' ORDER BY NGAY_NGHI DESC  ";
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNgayNghi, grvNgayNghi, dtTmp, true, true, true, true, true, this.Text);
            grvNgayNghi.Columns["MS_N_XUONG"].Visible = false;


            DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit dtTuGioLuoi = new
                DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            dtTuGioLuoi.EditFormat.FormatString = "HH:mm";
            dtTuGioLuoi.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtTuGioLuoi.EditMask = "HH:mm";
            grvNgayNghi.Columns["TU_GIO"].ColumnEdit = dtTuGioLuoi;

            DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit dtDenGioLuoi = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            dtDenGioLuoi.EditFormat.FormatString = "HH:mm";
            dtDenGioLuoi.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtDenGioLuoi.EditMask = "HH:mm";
           
            grvNgayNghi.Columns["DEN_GIO"].ColumnEdit = dtDenGioLuoi;

            grvNgayNghi.Columns["TU_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grvNgayNghi.Columns["TU_GIO"].DisplayFormat.FormatString = "HH:mm";


            grvNgayNghi.Columns["DEN_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grvNgayNghi.Columns["DEN_GIO"].DisplayFormat.FormatString = "HH:mm";

            grvNgayNghi.Columns["SO_PHUT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvNgayNghi.Columns["SO_PHUT"].DisplayFormat.FormatString = "N0";

            grvNgayNghi.Columns["SO_PHUT"].OptionsColumn.AllowEdit = false;
            tvwNhaXuong_FocusedNodeChanged(null, null);
        }

        private void tvwNhaXuong_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (grdNgayNghi.DataSource == null) return;
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdNgayNghi.DataSource;
            try
            {
                dtTmp.DefaultView.RowFilter = " MS_N_XUONG = '" + tvwNhaXuong.FocusedNode["MS_N_XUONG"].ToString() + "' ";
            }
            catch
            {
                dtTmp.DefaultView.RowFilter = " MS_N_XUONG = '-1'";
            }

            dtTmp = dtTmp.DefaultView.ToTable();
        }

        private void dtDNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNgay();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void bThemSua(Boolean bTSua)
        {

            btnGhi.Visible = !btnGhi.Visible;
            btnKhongghi.Visible = !btnKhongghi.Visible;

            btnThemSua.Visible = !btnThemSua.Visible;
            btnXoa.Visible = !btnXoa.Visible;
            btnThoat.Visible = !btnThoat.Visible;

            if (bTSua)
            {
                grvNgayNghi.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                grvNgayNghi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                grvNgayNghi.OptionsBehavior.Editable = true;


            }
            else
            {
                grvNgayNghi.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                grvNgayNghi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                grvNgayNghi.OptionsBehavior.Editable = false;
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            if (tvwNhaXuong.DataSource == null) return;
            if (tvwNhaXuong.ViewInfo.RowsInfo.Rows.Count <= 0) return;
            bThemSua(true);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {

            string sBTam = "NN_DC_TMP" + Commons.Modules.UserName;
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdNgayNghi.DataSource;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
            SqlConnection sqlCon = new SqlConnection(Commons.IConnections.ConnectionString);
            sqlCon.Open();
            SqlTransaction sqlTran = sqlCon.BeginTransaction();

            try
            {
                string sSql = "DELETE FROM NGAY_NGHI_NX ";
                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, sSql);

                sSql = " INSERT INTO[NGAY_NGHI_NX]([NGAY_NGHI],[MS_N_XUONG],[TU_GIO],[DEN_GIO],[SO_PHUT]) " +
                                " SELECT[NGAY_NGHI],[MS_N_XUONG],[TU_GIO],[DEN_GIO],DATEDIFF(MINUTE, TU_GIO, DEN_GIO )AS[SO_PHUT] FROM " + sBTam;
                SqlHelper.ExecuteNonQuery(sqlTran, CommandType.Text, sSql);
                sqlTran.Commit();
            }
            catch
            {
                sqlTran.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "msgCapNhapKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                sqlCon.Close();
            }
            bThemSua(false);
            LoadNgay();
        }

        private void btnKhongghi_Click(object sender, EventArgs e)
        {
            bThemSua(false);
            LoadNgay();
        }

        private void grvNgayNghi_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                if (!btnGhi.Visible) return;
                if (tvwNhaXuong.DataSource == null) return;
                if (String.IsNullOrEmpty(grvNgayNghi.GetFocusedRowCellValue("MS_N_XUONG").ToString())) grvNgayNghi.SetFocusedRowCellValue("MS_N_XUONG", tvwNhaXuong.FocusedNode["MS_N_XUONG"].ToString());
            }
            catch { }
        }

        private void grvNgayNghi_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (!btnGhi.Visible) return;
            if (tvwNhaXuong.DataSource == null) return;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            grvNgayNghi.Columns.View.ClearColumnErrors();


            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, view.Columns["NGAY_NGHI"]).ToString()))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["NGAY_NGHI"], Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "msgChuaNhapNgayNghi", Commons.Modules.TypeLanguage));
                return;
            }
            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, view.Columns["TU_GIO"]).ToString()))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["TU_GIO"], Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "msgChuaNhapTuGio", Commons.Modules.TypeLanguage));
                return;
            }

            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, view.Columns["DEN_GIO"]).ToString()))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["DEN_GIO"], Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "msgChuaNhapDenGio", Commons.Modules.TypeLanguage));
                return;
            }
            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, view.Columns["MS_N_XUONG"]).ToString()))
                grvNgayNghi.SetFocusedRowCellValue("MS_N_XUONG", tvwNhaXuong.FocusedNode["MS_N_XUONG"].ToString());

            DateTime dTGio, dDGio;
            try
            {
                dTGio = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, view.Columns["TU_GIO"]).ToString(), new CultureInfo("vi-vn"));
            }
            catch
            {
                dTGio = DateTime.Now;
            }
            try
            {
                dDGio = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, view.Columns["DEN_GIO"]).ToString(), new CultureInfo("vi-vn"));
            }
            catch
            {
                dDGio = DateTime.Now;
            }

            //try
            //{
            //    DateTime.TryParse(view.GetRowCellValue(e.RowHandle, view.Columns["TU_GIO"]).ToString(), out dTGio);
            //    DateTime.TryParse(view.GetRowCellValue(e.RowHandle, view.Columns["DEN_GIO"]).ToString(), out dDGio);

            //}
            //catch { dTGio = DateTime.Now;
            //    dDGio = DateTime.Now;
            //}


            if (dTGio >= dDGio)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["DEN_GIO"], Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "msgDenGioPhaiLonHonTuGio", Commons.Modules.TypeLanguage));
                return;
            }
            else
            {
                grvNgayNghi.SetFocusedRowCellValue("SO_PHUT", (dDGio.DayOfYear - dTGio.DayOfYear));
            }


        }

        private void grvNgayNghi_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private List<string> arrTim = new List<string>();
        private void txtTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Commons.Modules.ObjSystems.HTimXtraTreeList(txtTimkiem.Text, tvwNhaXuong, "MS_N_XUONG", "Ten_N_XUONG", ref arrTim);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdNgayNghi.DataSource == null) return;

            if (grvNgayNghi.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaNgayNghi", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "spDeleteNgayNghiNhaXuong", tvwNhaXuong.FocusedNode["MS_N_XUONG"].ToString(), grvNgayNghi.GetFocusedRowCellValue("NGAY_NGHI").ToString());
                    LoadNgay();
                }
                catch (Exception ex)
                { XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
    }
}
