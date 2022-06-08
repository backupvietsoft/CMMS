using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MVControl
{
    public partial class frmKeHoachSanXuat : DevExpress.XtraEditors.XtraForm
    {
        private int co = 0;
        public frmKeHoachSanXuat()
        {
            InitializeComponent();
        }
        private void frmKeHoachSanXuat_Load(object sender, EventArgs e)
        {
            LoadCbbLoai();
            LoadCbbHeThong(getDatatable());
            LockControl(true);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void LockControl(Boolean Locked)
        {
            btnThem.Visible = Locked;
            btnSua.Visible = Locked;
            btnXoa.Visible = Locked;
            btnThoat.Visible = Locked;
            grdData.Enabled = Locked;
            btnGhi.Visible = !Locked;
            btnKhongGhi.Visible = !Locked;
            LockUnLock(!Locked);
        }
        private void ResttextBox()
        {
            txt_GiaTri.ResetText();
            txtGhiChu.ResetText();
        }
        public void LockUnLock(Boolean Locked)
        {
            try
            {
                txtGhiChu.Properties.ReadOnly = !Locked;
                txt_GiaTri.Properties.ReadOnly = !Locked;
                cmbNgay.Properties.ReadOnly = !Locked;
                cmbNgayD.Properties.ReadOnly = !Locked;
                cmbYear.Properties.ReadOnly = !Locked;
                cmbYearD.Properties.ReadOnly = !Locked;
                cboLoai.Properties.ReadOnly = false;
                cbbHeThong.Properties.ReadOnly = !Locked;
            }
            catch { }
        }
        private DataTable getDatatable()
        {
            DataTable tempt = new DataTable();
            tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongAll", 0, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return tempt;
        }
        #region Load dữ liệu
        private void LoadCbbLoai()
        {
            try
            {
                DataTable tempt = new DataTable();
                tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiKHSX",Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoai, tempt, "ID_LOAI", "TEN_LOAI", "TEN_LOAI");

            }
            catch (Exception ex)
            {

            }
        }
        private void LoadCbbHeThong(DataTable tempt)
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cbbHeThong, tempt, "MS_HE_THONG", "TEN_HE_THONG", "TEN_HE_THONG");
        }
        private void LoadGrdData(DataTable tempt, int iLoai, int id)
        {
            try
            {
                grdData.DataSource = null;
                tempt.PrimaryKey = new DataColumn[] { tempt.Columns["ID"] };
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, tempt, false, false, true, false);
                if (iLoai != 1)
                {
                    //grvData.Columns["NHOM"].Visible = false;
                    //grvData.Columns["TEN_HE_THONG"].Visible = true;
                }
                //else
                //{
                //    grvData.Columns["NHOM"].Visible = true;
                //    grvData.Columns["TEN_HE_THONG"].Visible = false;
                //}
                if (id != -1)
                {
                    int index = tempt.Rows.IndexOf(tempt.Rows.Find(id));
                    grvData.FocusedRowHandle = grvData.GetRowHandle(index);
                    bindingdulieu();
                }
                grvData.Columns["MS_HE_THONG"].Visible = false;
                grvData.Columns["MS_N_XUONG"].Visible = false;
                grvData.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private DataTable LoadData(int iLoai)
        {
            DataTable tempt = new DataTable();
            try
            {
                tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKeHoachSanXuat", Commons.Modules.UserName, Commons.Modules.TypeLanguage, iLoai));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            return tempt;
        }
        #endregion
        private void cboLoai_EditValueChanged(object sender, EventArgs e)
        {
            //1 target
            LoadGrdData(LoadData(Convert.ToInt32(cboLoai.EditValue)), Convert.ToInt32(cboLoai.EditValue), -1);
            if (Convert.ToInt32(cboLoai.EditValue) == 1)
            {
                tableLayoutPanel1.SetRow(cmbYear, 2);
                tableLayoutPanel1.SetColumn(cmbYear, 2);
                tableLayoutPanel1.SetRow(cmbNgay, 3);
                tableLayoutPanel1.SetColumn(cmbNgay, 0);

                tableLayoutPanel1.SetRow(cmbYearD, 2);
                tableLayoutPanel1.SetColumn(cmbYearD, 3);
                tableLayoutPanel1.SetRow(cmbNgayD, 4);
                tableLayoutPanel1.SetColumn(cmbNgayD, 0);
                cmbYear.Visible = true;
                cmbNgay.Visible = false;

                cmbYearD.Visible = true;
                cmbNgayD.Visible = false;

                lblHeThong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachSanXuat", "Nhom", Commons.Modules.TypeLanguage);
                lblNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "lblNam", Commons.Modules.TypeLanguage);
                DataTable tempt = new DataTable();
                string resulst = Commons.Modules.TypeLanguage == 0 ? "Nhóm ": "Group ";
                tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DISTINCT NHOM_IN AS MS_HE_THONG,N'"+resulst+" ' + CONVERT(NVARCHAR(100),NHOM_IN) AS TEN_HE_THONG FROM dbo.HE_THONG"));
                LoadCbbHeThong(tempt);
                cmbYear.Properties.DisplayFormat.FormatString = "yyyy";
                cmbYear.Properties.EditMask = "yyyy";
                cmbYear.Properties.EditFormat.FormatString = "yyyy";
                cmbYear.DateTime = DateTime.Now;
                cmbYear.MMonthYear = false;

                cmbYearD.Properties.DisplayFormat.FormatString = "yyyy";
                cmbYearD.Properties.EditMask = "yyyy";
                cmbYearD.Properties.EditFormat.FormatString = "yyyy";
                cmbYearD.DateTime = DateTime.Now;
                cmbYearD.MMonthYear = false;
            }
            else
            if (Convert.ToInt32(cboLoai.EditValue) == 2)
            {//2 sản lượng cuối tháng
                tableLayoutPanel1.SetRow(cmbYear, 2);
                tableLayoutPanel1.SetColumn(cmbYear, 2);
                tableLayoutPanel1.SetRow(cmbNgay, 3);
                tableLayoutPanel1.SetColumn(cmbNgay, 0);

                tableLayoutPanel1.SetRow(cmbYearD, 2);
                tableLayoutPanel1.SetColumn(cmbYearD, 3);
                tableLayoutPanel1.SetRow(cmbNgayD, 4);
                tableLayoutPanel1.SetColumn(cmbNgayD, 0);
                cmbYear.Visible = true;
                cmbNgay.Visible = false;
                cmbYearD.Visible = true;
                cmbNgayD.Visible = false;

                lblHeThong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachSanXuat", "HeThong", Commons.Modules.TypeLanguage);
                lblNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "lblNgay", Commons.Modules.TypeLanguage);
                LoadCbbHeThong(getDatatable());
                cmbYear.Properties.DisplayFormat.FormatString = "MM/yyyy";
                cmbYear.Properties.EditMask = "MM/yyyy";
                cmbYear.Properties.EditFormat.FormatString = "MM/yyyy";
                cmbYear.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
                cmbYear.MMonthYear = true;

                cmbYearD.Properties.DisplayFormat.FormatString = "MM/yyyy";
                cmbYearD.Properties.EditMask = "MM/yyyy";
                cmbYearD.Properties.EditFormat.FormatString = "MM/yyyy";
                cmbYearD.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
                cmbYearD.MMonthYear = true;
            }
            else
            {
                tableLayoutPanel1.SetRow(cmbYear, 2);
                tableLayoutPanel1.SetColumn(cmbYear, 0);
                tableLayoutPanel1.SetRow(cmbNgay, 2);
                tableLayoutPanel1.SetColumn(cmbNgay, 2);

                tableLayoutPanel1.SetRow(cmbYearD, 3);
                tableLayoutPanel1.SetColumn(cmbYearD, 0);
                tableLayoutPanel1.SetRow(cmbNgayD, 2);
                tableLayoutPanel1.SetColumn(cmbNgayD, 3);
                cmbYear.Visible = false;
                cmbNgay.Visible = true;
                cmbYearD.Visible = false;
                cmbNgayD.Visible = true;
                cmbNgay.DateTime = DateTime.Now;
                cmbNgayD.DateTime = DateTime.Now;
                lblHeThong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKeHoachSanXuat", "HeThong", Commons.Modules.TypeLanguage);
                lblNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBangtygia", "LblNgay", Commons.Modules.TypeLanguage);
                LoadCbbHeThong(getDatatable());
            }
            bindingdulieu();
        }

        private void bindingdulieu()
        {
            try
            {
                txt_GiaTri.Text = grvData.GetFocusedRowCellValue("GIO_KH").ToString();
                txtGhiChu.Text = grvData.GetFocusedRowCellValue("GHI_CHU").ToString();
                cmbNgay.DateTime = Convert.ToDateTime(grvData.GetFocusedRowCellValue("NGAY"));
                cmbNgayD.DateTime = Convert.ToDateTime(grvData.GetFocusedRowCellValue("NGAY"));
                cmbYear.DateTime = Convert.ToDateTime(grvData.GetFocusedRowCellValue("NGAY"));
                cmbYearD.DateTime = Convert.ToDateTime(grvData.GetFocusedRowCellValue("NGAY"));
                if (Convert.ToInt32(cboLoai.EditValue) == 0 || Convert.ToInt32(cboLoai.EditValue) == 3)
                    cbbHeThong.EditValue = Convert.ToInt32(grvData.GetFocusedRowCellValue("MS_HE_THONG"));
                else
                    cbbHeThong.EditValue = Convert.ToInt32(grvData.GetFocusedRowCellValue("MS_N_XUONG"));
            }
            catch (Exception)
            {

            }
        }
        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            bindingdulieu();
        }
        //thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResttextBox();
            LockControl(false);
            cboLoai.Properties.ReadOnly = false;
            co = 1;
        }
        //sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
            cboLoai.Properties.ReadOnly = true;
            cbbHeThong.Properties.ReadOnly = true;
            cmbNgayD.Properties.ReadOnly = true;
            cmbYearD.Properties.ReadOnly = true;
            co = 2;
        }
        //xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChiPhiTheoThang", "MsgCheckDelete", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string sSql;
            try
            {
                sSql = "DELETE dbo.KHSX_NGAY WHERE ID =" + Convert.ToInt32(grvData.GetFocusedRowCellValue("ID")) + "";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                LoadGrdData(LoadData(Convert.ToInt32(cboLoai.EditValue)), Convert.ToInt32(cboLoai.EditValue), -1);
            }
            catch (Exception ex)
            {

            }
        }
        //thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //lưu
        private bool kiemtraDuLieu(int iloai)
        {
            int resulst = 0;
            try
            {
                resulst = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "KiemTraKeHoachSanXuat", cboLoai.EditValue, iloai == 0 ? cmbNgay.DateTime : iloai == 1 ? Convert.ToDateTime("01/01/" + cmbYear.DateTime.Year + "") : Convert.ToDateTime("01/" + cmbYear.DateTime.Month + "/" + cmbYear.DateTime.Year + ""), iloai == 0 ? cmbNgayD.DateTime : iloai == 1 ? Convert.ToDateTime("31/12/" + cmbYear.DateTime.Year + "") : Convert.ToDateTime("01/" + cmbYearD.DateTime.Month + "/" + cmbYearD.DateTime.Year + "").AddMonths(1).AddDays(-1), cbbHeThong.EditValue));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }

            if (resulst == 0)
                return true;
            else
                return false;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            int id =-1;
            int iloai = Convert.ToInt32(cboLoai.EditValue);
            if (iloai != 0)
            {
                if(cmbYear.DateTime > cmbYearD.DateTime)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmThongtinthietbi", "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (cmbNgay.DateTime > cmbNgayD.DateTime)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmThongtinthietbi", "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (string.IsNullOrEmpty(txt_GiaTri.Text.ToString()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNullGiaTri", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (co == 1)
            {
                //kiểm tra tồn tại thông báo gì đè
                if (kiemtraDuLieu(iloai) == false)
                {
                    //if (iloai == 1)
                    //{
                        DialogResult dl = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgDuLieuThemDaTonTai", Commons.Modules.TypeLanguage),this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dl == DialogResult.No)
                        { return; }
                    //}
                }
                try
                {

                   id = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "CapNhatKeHoachSanXuat", cboLoai.EditValue, iloai == 0 ? cmbNgay.DateTime : iloai == 1 ? Convert.ToDateTime("01/01/" + cmbYear.DateTime.Year + "") : Convert.ToDateTime("01/" + cmbYear.DateTime.Month + "/" + cmbYear.DateTime.Year + ""), iloai == 0 ? cmbNgayD.DateTime : iloai == 1 ? Convert.ToDateTime("31/12/" + cmbYearD.DateTime.Year + "") : Convert.ToDateTime("01/" + cmbYearD.DateTime.Month + "/" + cmbYearD.DateTime.Year + "").AddMonths(1).AddDays(-1), cbbHeThong.EditValue, txt_GiaTri.EditValue, txtGhiChu.EditValue));
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            if (co == 2)
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "SuaKeHoachSanXuat", Convert.ToInt32(grvData.GetFocusedRowCellValue("ID")), iloai == 0 ? cmbNgay.DateTime : iloai == 1 ? Convert.ToDateTime("01/01/" + cmbYear.DateTime.Year + "") : Convert.ToDateTime("01/" + cmbYear.DateTime.Month + "/" + cmbYear.DateTime.Year + ""), txt_GiaTri.EditValue, txtGhiChu.EditValue);
                id = Convert.ToInt32(grvData.GetFocusedRowCellValue("ID"));
            }
            LoadGrdData(LoadData(Convert.ToInt32(cboLoai.EditValue)), Convert.ToInt32(cboLoai.EditValue), id);
            LockControl(true);
        }
        //không lưu
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            LockControl(true);
        }
        private void txt_GiaTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
               (e.KeyChar == '.' && (txt_GiaTri.Text.Length == 0 || txt_GiaTri.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }


    }
}
