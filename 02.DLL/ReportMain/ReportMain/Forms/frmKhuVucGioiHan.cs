using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors.Controls;

namespace ReportMain
{
    public partial class frmKhuVucGioiHan : DevExpress.XtraEditors.XtraForm
    {
        private int flag = 1;
        ucGiayPhepCatHan GPCH;
        ucGiayPhepKhuVucGioiHan KVGH;
        ucGiayPhepLamViecTrenCao LVTC;
        public frmKhuVucGioiHan()
        {
            InitializeComponent();
        }
        
        #region sự kiện control
        private void frmKhuVucGioiHan_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            LoadData();
            Commons.Modules.SQLString = "";
            LoadCboPBT();
            visibleButon(true);
            LoadgrdData(-1);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            cboPhieu_Bao_Tri.Properties.PopupFormSize = new Size(cboPhieu_Bao_Tri.Width, 360);
            rdoDuyet.Properties.Items[0].Description = Commons.Modules.GetNNgu(this.Name, "rdoAll");
            rdoDuyet.Properties.Items[1].Description = Commons.Modules.GetNNgu(this.Name, "rdodangsoan");
            rdoDuyet.Properties.Items[2].Description = Commons.Modules.GetNNgu(this.Name, "rdoDaDuyet");
            LoadPanIn();
        }
        private void LoadPanIn()
        {
            panIn.Controls.Clear();
            switch (Convert.ToInt32(cboLoai_GP.EditValue))
            {
                case 1:
                    {
                        //làm việc trên cao
                        LVTC = new ucGiayPhepLamViecTrenCao(txtMs_GP.Text.ToString().Trim(),Convert.ToInt64(txtMS.EditValue));
                        panIn.Controls.Add(LVTC);
                        LVTC.Dock = DockStyle.Fill;
                        break;
                    }
                case 2:
                    {
                        //cắt hàng
                        GPCH = new ucGiayPhepCatHan(txtMs_GP.Text.ToString().Trim(), Convert.ToInt64(txtMS.EditValue));
                        panIn.Controls.Add(GPCH);
                        GPCH.Dock = DockStyle.Fill;
                        break;
                    }
                case 3:
                    {
                        //khu vực giới hạn
                        KVGH = new ucGiayPhepKhuVucGioiHan(txtMs_GP.Text.ToString().Trim(), Convert.ToInt64(txtMS.EditValue));
                        panIn.Controls.Add(KVGH);
                        KVGH.Dock = DockStyle.Fill;
                        break;
                    }
                default:
                    break;
            }
        }

        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadCboPBT();
        }
        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (grvData.RowCount == 0) return;
            try
            {
                txtGhi_Chu.EditValue = grvData.GetFocusedRowCellValue("GHI_CHU");
                txtMs_GP.EditValue = grvData.GetFocusedRowCellValue("MS_GP");
                txtMS.EditValue = grvData.GetFocusedRowCellValue("ID");
                datNgay_Lap.EditValue = Convert.ToDateTime(grvData.GetFocusedRowCellValue("NGAY_LAP"));
                try
                {
                    datTNgayPBT.DateTime = Convert.ToDateTime("01/" + datNgay_Lap.DateTime.Month + "/" + datNgay_Lap.DateTime.Year);
                    datDNgayPBT.DateTime = datTNgayPBT.DateTime.AddMonths(1).AddDays(-1);
                }
                catch
                {
                    datTNgayPBT.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                    datDNgayPBT.DateTime = datTNgayPBT.DateTime.AddMonths(1).AddDays(-1);

                }
                if (grvData.GetFocusedRowCellValue("NGAY_DUYET").ToString() == "")
                {
                    datNgay_Duyet.EditValue = "";
                }
                else
                {
                    datNgay_Duyet.EditValue = Convert.ToDateTime(grvData.GetFocusedRowCellValue("NGAY_DUYET"));
                }
                try
                {
                    cboDDiem.SelectedIndex = cboDDiem.treeList.GetVisibleIndexByNode(cboDDiem.treeList.FindNodeByKeyID(grvData.GetFocusedRowCellValue("MS_N_XUONG").ToString()));
                }
                catch
                { cboDDiem.SelectedIndex = 0; }
                cboLoai_GP.EditValue = Convert.ToInt64(grvData.GetFocusedRowCellValue("MS_LOAI_GP"));
                cboPhieu_Bao_Tri.Text = grvData.GetFocusedRowCellValue("DS_PHIEU_BAO_TRI").ToString();
                if (Convert.ToBoolean(grvData.GetFocusedRowCellValue("DUYET")) == true)
                {
                    btnDuyet.Visible = false;
                    btnHuyDuyet.Visible = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnIn.Enabled = true;
                }
                else
                {
                    btnDuyet.Visible = true;
                    btnHuyDuyet.Visible = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnIn.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void grdData_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteData();
            }
        }
        private void txtTK_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdData.DataSource;
                if (txtTK.Text.Length != 0) sdkien = " ( " + " MS_GP LIKE '%" + txtTK.Text + "%' OR DS_PHIEU_BAO_TRI LIKE '%" + txtTK.Text + "%' )";
                dtTmp.DefaultView.RowFilter = sdkien;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }

        #endregion
        #region các hàm private hổ trợ 
        private void LoadData()
        {
            //Load ngày tim kiếm
            datTu_Ngay.DateTime = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            datDen_Ngay.DateTime = DateTime.Now.AddDays(-DateTime.Now.Day).AddMonths(1);
            //Load Loại Giấy phép
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoai_GP, "spGET_LOAI_GIAY_PHEP", "MS_LOAI_GP", "TEN_LOAI_GP", Commons.Modules.GetNNgu(this.Name, "TEN_LOAI_GP"), false, "0");
            //Load địa điểm
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(0), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
        }
        private void LoadgrdData(Int64 id)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetDanhSachGiayPhep", Commons.Modules.TypeLanguage, Commons.Modules.UserName, datTu_Ngay.DateTime, datDen_Ngay.DateTime, rdoDuyet.EditValue));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
            if (grdData.DataSource == null)
            {
                Commons.Modules.SQLString = "0Load";
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dt, false, false, true, true, true, this.Name);
                grvData.Columns["MS_LOAI_GP"].Visible = false;
                grvData.Columns["MS_N_XUONG"].Visible = false;
                grvData.Columns["DUYET"].Visible = false;
                grvData.Columns["GHI_CHU"].Visible = false;
                grvData.Columns["ID"].Visible = false;
                Commons.Modules.SQLString = "";
            }
            else
            {
                Commons.Modules.SQLString = "0Load";
                grdData.DataSource = dt;
                Commons.Modules.SQLString = "";
            }
            if (id != -1)
            {
                int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                grvData.FocusedRowHandle = grvData.GetRowHandle(index);
            }
            if (grvData.FocusedRowHandle == 0)
            {
                grvData_FocusedRowChanged(null, null);
            }
            else
            {
                if (grvData.RowCount == 0)
                {
                    btnDuyet.Visible = false;
                    btnHuyDuyet.Visible = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnIn.Enabled = false;
                    ResetData(false);
                }
            }
        }
        private void visibleButon(bool flag)
        {
            if (Commons.Modules.PermisString.ToUpper() == "READ ONLY")
            {
                btnThem.Visible = false;
                btnXoa.Visible = false;
                btnSua.Visible = false;
                btnDuyet.Visible = false;
                btnKhongGhi.Visible = false;
            }
            else
            {
                btnThem.Visible = flag;
                btnXoa.Visible = flag;
                btnSua.Visible = flag;
                btnIn.Visible = flag;
                btnThoat.Visible = flag;
                btnGhi.Visible = !flag;
                btnKhongGhi.Visible = !flag;
            }
            //eneble các control khác
            txtGhi_Chu.Enabled = !flag;
            cboDDiem.Enabled = !flag;
            cboLoai_GP.Enabled = !flag;
            cboPhieu_Bao_Tri.Enabled = !flag;
            datNgay_Lap.Enabled = !flag;
            datTNgayPBT.Enabled = !flag;
            datDNgayPBT.Enabled = !flag;
            rdoDuyet.Enabled = flag;
            datTu_Ngay.Enabled = flag;
            datDen_Ngay.Enabled = flag;
            panIn.Enabled = !flag;
        }
        private void ResetData(bool them)
        {
            txtGhi_Chu.ResetText();
            cboDDiem.SelectedIndex = 0;
            cboPhieu_Bao_Tri.ResetText();
            if (them == true)
            {
                //cboLoai_GP.EditValue = Convert.ToInt64(1);
                datNgay_Lap.DateTime = DateTime.Now;
                try
                {
                    datTNgayPBT.DateTime = Convert.ToDateTime("01/" + datNgay_Lap.DateTime.Month + "/" + datNgay_Lap.DateTime.Year);
                    datDNgayPBT.DateTime = datTNgayPBT.DateTime.AddMonths(1).AddDays(-1);
                }
                catch
                {
                    datTNgayPBT.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                    datDNgayPBT.DateTime = datTNgayPBT.DateTime.AddMonths(1).AddDays(-1);

                }

                datNgay_Duyet.EditValue = null;
            }
            else
            {
                cboLoai_GP.EditValue = null;
                datNgay_Lap.EditValue = null;
                datNgay_Duyet.EditValue = null;
                txtMs_GP.ResetText();
                txtMS.EditValue = -1;
                try
                {
                    datTNgayPBT.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                    datDNgayPBT.DateTime = datTNgayPBT.DateTime.AddMonths(1).AddDays(-1);
                }
                catch { }
            }
        }
        private void DeleteData()
        {
            if (XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgCheckDelete"), Commons.Modules.GetNNgu(this.Name, "Message"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.GIAY_PHEP WHERE ID = " + txtMS.EditValue + "");
                    grvData.DeleteSelectedRows();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        #endregion

        #region sự kiện nút và radio
        private void rdoDuyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadgrdData(-1);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (rdoDuyet.SelectedIndex != 0)
            {
                rdoDuyet.SelectedIndex = 0;
            }
            ResetData(true);
            //creat auto số phiếu
            txtMs_GP.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT [dbo].[AUTO_CREATE_SO_GIAY_PHEP]('" + datTNgayPBT.DateTime.ToString("MM/dd/yyyy") + "')").ToString();
            txtMS.EditValue = -1;
            flag = 1;
            visibleButon(false);
            cboLoai_GP_EditValueChanged(null, null);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 0;
            visibleButon(false);
            datNgay_Lap.Enabled = false;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            //kiểm tra nhà xưởng được chọn chưa
            if (cboDDiem.EditValue.ToString() == "-1")
            {
                XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgChonNhaXuong"), Commons.Modules.GetNNgu(this.Name, "Message"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboDDiem.Focus();
                return;
            }
            //kiểm loại báo cáo được nhập được
            if (cboLoai_GP.Text.ToString() == "")
            {
                XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgChonLoaiGiayPhep"), Commons.Modules.GetNNgu(this.Name, "Message"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoai_GP.Focus();
                return;
            }
            if (cboDDiem.EditValue.ToString() == "")
            {
                XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgChonLoaiGP"), Commons.Modules.GetNNgu(this.Name, "Message"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoai_GP.Focus();
                return;
            }
            //kiểm tra nếu tồn tại số phiếu thì tạo phếu mới
            int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(MS_GP) FROM dbo.GIAY_PHEP WHERE  MS_GP ='"+txtMs_GP.EditValue.ToString().Trim()+"' AND  ID !=  " + txtMS.EditValue+" "));
            if (n >0)
            {
                if (XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgTrungSoPhieuTuDongCN"), Commons.Modules.GetNNgu(this.Name, "Message"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtMs_GP.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT [dbo].[AUTO_CREATE_SO_GIAY_PHEP]('" + datNgay_Lap.DateTime.ToString("MM/dd/yyyy") + "')").ToString();
                }
                else
                {
                    return;
                }
            }
            Int64 id;
            try
            {
                    id = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditGiayPhep",
                    txtMS.EditValue,
                    txtMs_GP.EditValue,
                    cboLoai_GP.EditValue,
                    cboDDiem.EditValue,
                    cboPhieu_Bao_Tri.EditValue,
                    0,
                    Commons.Modules.UserName,
                    datNgay_Lap.EditValue,
                    txtGhi_Chu.EditValue,
                    flag));
                LoadgrdData(id);
                SaveIn(id);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            visibleButon(true);
        }
        private void SaveIn(Int64 id)
        {
            switch (Convert.ToInt32(cboLoai_GP.EditValue))
            {
                case 1:
                    {
                        //làm việc trên cao
                        LVTC.UpdateIn(id);
                        break;
                    }
                case 2:
                    {
                        //cắt hàng
                        GPCH.UpdateIn(id);
                        break;
                    }
                case 3:
                    {
                        //khu vực giới hạn
                        KVGH.UpdateIn(id);
                        break;
                    }
                default:
                    break;
            }
        }
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            visibleButon(true);
            grvData_FocusedRowChanged(null, null);
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Doc file (*.doc)|*.doc", "AT");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            switch (Convert.ToInt32(cboLoai_GP.EditValue))
            {
                case 1:
                    {
                        //làm việc trên cao
                        LVTC.IN(sPath);
                        break;
                    }
                case 2:
                    {
                        //cắt hàng
                        GPCH.IN(sPath);
                        break;
                    }
                case 3:
                    {
                        //khu vực giới hạn
                        KVGH.IN(sPath, datTu_Ngay.Text);
                        break;
                    }
                default:
                    break;
            }
            this.Cursor = Cursors.Default;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                LoadgrdData(Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditGiayPhep",
                    txtMS.EditValue,
                    txtMs_GP.EditValue,
                    cboLoai_GP.EditValue,
                    grvData.GetFocusedRowCellValue("MS_N_XUONG").ToString(),
                    cboPhieu_Bao_Tri.EditValue,
                    1,
                    Commons.Modules.UserName,
                    DateTime.Now,
                    txtGhi_Chu.EditValue,
                    0)));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHuyDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                LoadgrdData(Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditGiayPhep",txtMS.EditValue,
                    txtMs_GP.EditValue,
                    cboLoai_GP.EditValue,
                    grvData.GetFocusedRowCellValue("MS_N_XUONG").ToString(),
                    cboPhieu_Bao_Tri.EditValue,
                    0,
                    Commons.Modules.UserName,
                    datNgay_Lap.EditValue,
                    txtGhi_Chu.EditValue,
                   0)));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        TextEdit txtserch = new TextEdit();
        private void cboPhieu_Bao_Tri_Popup(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            txtserch.Visible = true;
            CheckedComboBoxEdit edit = sender as CheckedComboBoxEdit;
            txtserch.Width = edit.Width - 15;
            edit.Controls.Add(txtserch);
            txtserch.EditValueChanged += Txtserch_EditValueChanged;
        }
        private void Txtserch_EditValueChanged(object sender, EventArgs e)
        {
            CheckedListBoxControl listBox = (CheckedListBoxControl)cboPhieu_Bao_Tri.Properties.PopupControl.Controls[0];
            bool Items = listBox.Items.Contains(txtserch.Text.ToUpper());
            CheckedListBoxItem row = listBox.Items.Cast<CheckedListBoxItem>().FirstOrDefault(x => x.Value.ToString().Contains(txtserch.Text.ToUpper().ToString()));
            listBox.SelectedItem = row;
        }
        private void cboPhieu_Bao_Tri_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            txtserch.Visible = false;
        }
        private void LoadCboPBT()
        {
            //Load Phiếu bảo trì
            if (Commons.Modules.SQLString == "0Load") return;
            if (Commons.Modules.SQLString == "LoadNgayPBT") return;
            try
            {
                if (datTNgayPBT.Text == "")
                {
                    datTNgayPBT.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                    datDNgayPBT.DateTime = datTNgayPBT.DateTime.AddMonths(1).AddDays(-1);
                }
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetPhieuTheoDiaDiem", Commons.Modules.UserName, cboDDiem.EditValue, datTNgayPBT.DateTime.Date, datDNgayPBT.DateTime.Date));
                cboPhieu_Bao_Tri.Properties.DisplayMember = "MS_PHIEU_BAO_TRI";
                cboPhieu_Bao_Tri.Properties.ValueMember = "MS_PHIEU_BAO_TRI";
                cboPhieu_Bao_Tri.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void datTNgayPBT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!btnGhi.Visible) return;
                if (Commons.Modules.SQLString == "LoadNgayPBT") return;
                if (datTNgayPBT.Text == "") return;
                if (datDNgayPBT.Text == "") return;
                LoadCboPBT();
            }
            catch { }
        }

        private void datNgay_Lap_EditValueChanged(object sender, EventArgs e)
        {
        

            if (!btnGhi.Visible) return;
            Commons.Modules.SQLString = "LoadNgayPBT";
            try
            {
                datTNgayPBT.DateTime = Convert.ToDateTime("01/" + datNgay_Lap.DateTime.Month + "/" + datNgay_Lap.DateTime.Year);
                datDNgayPBT.DateTime = datTNgayPBT.DateTime.AddMonths(1).AddDays(-1);
            }
            catch
            {
                datTNgayPBT.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                datDNgayPBT.DateTime = datTNgayPBT.DateTime.AddMonths(1).AddDays(-1);

            }
            Commons.Modules.SQLString = "";
            LoadCboPBT();
        }

        private void cboLoai_GP_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadPanIn();
        }
        private void datNgay_Lap_Validated(object sender, EventArgs e)
        {
            //kiểu tra nếu khác tháng và năm thì thây đổi số phiếu
            if (txtMs_GP.Text.Substring(3,4) != datNgay_Lap.Text.Substring(datNgay_Lap.Text.Length -2,2) + datNgay_Lap.Text.Substring(3,2))
            txtMs_GP.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT [dbo].[AUTO_CREATE_SO_GIAY_PHEP]('" + datNgay_Lap.DateTime.ToString("MM/dd/yyyy") + "')").ToString();
        }
    }
}
