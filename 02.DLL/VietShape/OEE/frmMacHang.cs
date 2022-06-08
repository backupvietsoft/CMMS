using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace VietShape
{
    public partial class frmMacHang : DevExpress.XtraEditors.XtraForm
    {
        private string sbt = "BTMacHang"+Commons.Modules.UserName;
        private bool bThem;
        public frmMacHang()
        {
            InitializeComponent();
        }
        private void enableButon(bool visible)
        {
            btnThem.Visible = visible;
            btnXoa.Visible = visible;
            btnSua.Visible = visible;
            btnThoat.Visible = visible;
            btnThoat.Visible = visible;

            BtnLuu.Visible = !visible;
            btnKhongLuu.Visible = !visible;

            dtDDTNgay.Enabled = visible;
            dtDDDNgay.Enabled = visible;
        }

        private void frmMacHang_Load(object sender, EventArgs e)
        {
            enableButon(true);
            Commons.Modules.SQLString = "0Load";
            dtDDTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month+"/"+ DateTime.Today.Year);
            dtDDDNgay.DateTime = dtDDTNgay.DateTime.AddMonths(1).AddDays(-1);
            Commons.Modules.SQLString = "";
            LoadgrdMacHang();
        }
        private void LoadgrdMacHang()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "OEE_spGetListMacHang", dtDDTNgay.DateTime, dtDDDNgay.DateTime));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMacHang, grvMacHang, dt, false, false, true, true, true, this.Name);
            //add combobox nhan vien
            grvMacHang.Columns["ID_MACHANG"].Visible = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            enableButon(false);
            AddnewRow(grvMacHang, true);
            bThem = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            enableButon(false);
            AddnewRow(grvMacHang, false);
            bThem = false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaMacHang();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            //grvMacHang.PostEditor();
            //grvMacHang.UpdateCurrentRow();
            Validate();
            if (grvMacHang.HasColumnErrors == true) return;
            DataTable dt = new DataTable();
            dt = (DataTable)grdMacHang.DataSource;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sbt, dt, "");
            if(SaveData()== true)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgUpdateSuccess"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTieuDeCapNhat"), MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                DeleteAddRow(grvMacHang);
                LoadgrdMacHang();
            }
            else
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgUpdateFailure"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTieuDeCapNhat"), MessageBoxButtons.OK,MessageBoxIcon.Error); return;
            }
            enableButon(true);
        }
        private bool SaveData()
        {
            bool resulst = false;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "OEE_spLuuMacHang", sbt,bThem);
                resulst = true;

            }
            catch
            {
                resulst = false;
            }
            return resulst;
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            enableButon(true);
            DeleteAddRow(grvMacHang);
        }
        private void AddnewRow(GridView view, bool add)
        {
            view.OptionsBehavior.Editable = true;
            if (add == true)
            {
                view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            }
        }
        private void DeleteAddRow(GridView view)
        {
            view.OptionsBehavior.Editable = false;
            view.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        private void grdMacHang_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                XoaMacHang();
            }
        }
        private void XoaMacHang()
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgDeleteMacHang"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTieuDeXoa"), MessageBoxButtons.YesNo) == DialogResult.No) return;
            //xóa
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.MAC_HANG WHERE ID_MACHANG = " + grvMacHang.GetFocusedRowCellValue("ID_MACHANG") + "");
                grvMacHang.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgDelDangSuDung") + "\n" + ex.Message.ToString());
            }
        }
        private void dtDDTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadgrdMacHang();
        }
        private void grvMacHang_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //khi thêm mới thì add giá trị mặc định vào user name vào ngày tạo
            grvMacHang.SetFocusedRowCellValue("NGAY_NHAP", DateTime.Now);
            grvMacHang.SetFocusedRowCellValue("NGUOI_NHAP", Commons.Modules.UserName);
        }
        private void grvMacHang_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //trước khi kiểm tra thì xóa hết colum error đang có
            grvMacHang.ClearColumnErrors();
            DevExpress.XtraGrid.Views.Grid.GridView View = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            DevExpress.XtraGrid.Columns.GridColumn sTenMacHang = View.Columns["TEN_MACHANG"];
            if (View.GetRowCellValue(e.RowHandle, sTenMacHang).ToString() == "")
            {
                //kiểm tra tên mặc hàng không trống
                e.Valid = false;
                View.SetColumnError(sTenMacHang, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTenMacHangKhongNull", Commons.Modules.TypeLanguage));
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraTenUserNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //kiểm tra tên tồn tại

            DevExpress.XtraGrid.Columns.GridColumn sMaMacHang = View.Columns["MA_MACHANG"];
            if (View.GetRowCellValue(e.RowHandle, sTenMacHang).ToString() == "")
            {
                //kiểm tra mã mặc hàng không trống
                e.Valid = false;
                View.SetColumnError(sTenMacHang, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgMaMacHangKhongNull", Commons.Modules.TypeLanguage));
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraTenUserNULL", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void grvMacHang_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
    }
}
