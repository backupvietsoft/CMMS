using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
namespace ReportMain
{
    public partial class frmPhieuTamXuatTaiNhap : DevExpress.XtraEditors.XtraForm
    {
        private bool flag = false;
        public frmPhieuTamXuatTaiNhap()
        {
            InitializeComponent();
        }
        #region sự kiện control

        private void txtTK_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdData.DataSource;
                if (txtTK.Text.Length != 0) sdkien = " ( " + " MS_TX_TN LIKE '%" + txtTK.Text + "%' )";
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
            grvData_FocusedRowChanged(null, null);
        }
        #endregion

        #region các hàm private hổ trợ 
        private void LoadgrdData(Int64 id)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetDanhSachTamXuatTaiNhap", datTu_Ngay.DateTime, datDen_Ngay.DateTime));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
            if (grdData.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dt, false, false, true, true, true, this.Name);
                grvData.Columns["ID"].Visible = false;
                grvData.Columns["NGUOI_DE_NGHI"].Visible = false;
                grvData.Columns["MS_NHAN_VIEN"].Visible = false;
                grvData.Columns["TEN_BO_PHAN"].Visible = false;
                grvData.Columns["CNMD"].Visible = false;
                grvData.Columns["NOI_NHAN"].Visible = false;
                grvData.Columns["PHUONG_TIEN_VC"].Visible = false;
                grvData.Columns["TG_MANG_VE"].Visible = false;
                grvData.Columns["CNMD"].Visible = false;
                grvData.Columns["NGUOI_LAP"].Visible = false;
                grvData.Columns["NGUOI_DUYET"].Visible = false;
                grvData.Columns["GHI_CHU"].Visible = false;
                grvData.Columns["NGUOI_MANG_RA"].Visible = false;
                grvData.Columns["NGAY_DUYET"].Visible = false;
            }
            else
            {
                grdData.DataSource = dt;
            }
            if (id != -1)
            {
                int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                grvData.FocusedRowHandle = index;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnIn.Enabled = true;

            }
            else
            {
                if (grvData.RowCount == 0)
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnIn.Enabled = false;
                }
            }

            grvData_FocusedRowChanged(null, null);

        }
        private void LoadgrdDetails()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetDanhSachTamXuatTaiNhapDetails", string.IsNullOrEmpty(txtMS.Text) ? -1 : txtMS.EditValue));
            if (grvDetails.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDetails, grvDetails, dt, false, false, true, true, true, this.Name);
                grvDetails.Columns["ID"].Visible = false;
                grvDetails.Columns["ID_TNX"].Visible = false;
            }
            else
            {
                grdDetails.DataSource = dt;
            }
        }

        private void BingdingData()
        {
            if (flag == true)
            {
                //khi thêm mới
                datNgayLap.DateTime = DateTime.Now;
                datThoiGianNHV.DateTime = DateTime.Now;
                txtMsTXTN.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT [dbo].[AUTO_CREATE_SO_TAM_XUAT]('" + datNgayLap.DateTime.ToString("MM/dd/yyyy") + "')").ToString();
                txtMS.EditValue = -1;
                txtMsNhanVien.ResetText();
                txtTenNguoiDN.ResetText();
                txtBoPhan.ResetText();
                txtCMND.ResetText();
                txtNguoiMHR.ResetText();
                txtPhuongTienVC.ResetText();
                txtGhiChu.ResetText();
                txtNoiNhanHang.ResetText();
            }
            else
            {
                //sửa
                try
                {
                    txtMS.Text = grvData.GetFocusedRowCellValue("ID").ToString();
                    txtMsTXTN.Text = grvData.GetFocusedRowCellValue("MS_TX_TN").ToString();
                    txtMsNhanVien.Text = grvData.GetFocusedRowCellValue("MS_NHAN_VIEN").ToString();
                    txtTenNguoiDN.Text = grvData.GetFocusedRowCellValue("NGUOI_DE_NGHI").ToString();
                    txtBoPhan.Text = grvData.GetFocusedRowCellValue("TEN_BO_PHAN").ToString();
                    txtCMND.Text = grvData.GetFocusedRowCellValue("CNMD").ToString();
                    txtNguoiMHR.Text = grvData.GetFocusedRowCellValue("NGUOI_MANG_RA").ToString();
                    txtPhuongTienVC.Text = grvData.GetFocusedRowCellValue("PHUONG_TIEN_VC").ToString();
                    txtGhiChu.Text = grvData.GetFocusedRowCellValue("GHI_CHU").ToString();
                    txtNoiNhanHang.Text = grvData.GetFocusedRowCellValue("NOI_NHAN").ToString();
                    datNgayLap.DateTime = Convert.ToDateTime(grvData.GetFocusedRowCellValue("NGAY_LAP").ToString());
                    datThoiGianNHV.DateTime = Convert.ToDateTime(grvData.GetFocusedRowCellValue("TG_MANG_VE").ToString());

                }
                catch
                {

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
            //tx.Enabled = !flag;
            txtMS.Properties.ReadOnly = flag;
            txtMsNhanVien.Properties.ReadOnly = flag;
            txtTenNguoiDN.Properties.ReadOnly = flag;
            txtBoPhan.Properties.ReadOnly = flag;
            txtCMND.Properties.ReadOnly = flag;
            txtNguoiMHR.Properties.ReadOnly = flag;
            txtPhuongTienVC.Properties.ReadOnly = flag;
            txtGhiChu.Properties.ReadOnly = flag;
            txtNoiNhanHang.Properties.ReadOnly = flag;
            datNgayLap.Enabled = !flag;
            datThoiGianNHV.Enabled = !flag;
            grdData.Enabled = flag;

            datTu_Ngay.Enabled = flag;
            datDen_Ngay.Enabled = flag;
        }
        private void DeleteData()
        {
            if (XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgCheckDelete"), Commons.Modules.GetNNgu(this.Name, "Message"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.PHIEU_TAM_XUAT_TAI_NHAP_CHI_TIET WHERE ID = " + Convert.ToInt64(grvDetails.GetFocusedRowCellValue("ID")) + " DELETE dbo.PHIEU_TAM_XUAT_TAI_NHAP WHERE ID = " + txtMS.EditValue + " ");
                    grvData.DeleteSelectedRows();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            LoadgrdData(-1);
        }
        #endregion

        private void datNgay_Lap_Validated(object sender, EventArgs e)
        {
            //kiểu tra nếu khác tháng và năm thì thây đổi số phiếu
            if (txtMsTXTN.Text.Substring(3, 4) != datNgayLap.Text.Substring(datTu_Ngay.Text.Length - 2, 2) + datNgayLap.Text.Substring(3, 2))
                txtMsTXTN.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT [dbo].[AUTO_CREATE_SO_TAM_XUAT]('" + datNgayLap.DateTime.ToString("MM/dd/yyyy") + "')").ToString();
        }

        #region event form

        private void frmPhieuTamXuatTaiNhap_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            datTu_Ngay.DateTime = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            datDen_Ngay.DateTime = DateTime.Now.AddDays(-DateTime.Now.Day).AddMonths(1);
            visibleButon(true);
            LoadgrdData(-1);
            BingdingData();
            LoadgrdDetails();
            Commons.Modules.SQLString = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            visibleButon(false);
            flag = true;
            BingdingData();
            LoadgrdDetails();
            lblMsTXTN.Focus();
            grvDetails.OptionsBehavior.Editable = true;
            grvDetails.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            grvDetails.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            grvDetails.MoveLastVisible();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Convert.ToInt64(grvData.GetFocusedRowCellValue("ID").ToString()); } catch { }
            if (iId == -1)
            {
                XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgKhongCoDuLieu"), Commons.Modules.GetNNgu(this.Name, "Message"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (grvDetails.RowCount == 0)
            {
                DeleteData();
            }
            else
            {
                DeleteDatadetails();
            }
        }
        private void DeleteDatadetails()
        {
            if (XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgCheckDelete"), Commons.Modules.GetNNgu(this.Name, "Message"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.PHIEU_TAM_XUAT_TAI_NHAP_CHI_TIET  WHERE ID = " + Convert.ToInt64(grvDetails.GetFocusedRowCellValue("ID")) + "");
                    grvDetails.DeleteSelectedRows();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //LoadgrdData(-1);
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            visibleButon(false);
            grvDetails.OptionsBehavior.Editable = true;
            grvDetails.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            grvDetails.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            grvDetails.MoveLastVisible();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            InPhieuTamXuatTaiNhap();
        }
        private void InPhieuTamXuatTaiNhap()
        {
            try
            {
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                frmReport frmRpt = new frmReport();
                frmRpt.rptName = "rptPhieuTamXuatTaiNhap";
                DataTable dt = (DataTable)grdData.DataSource;
                dtTmp = dt.AsEnumerable().Where(x => x.Field<Int64>("ID").Equals(Convert.ToInt64(txtMS.EditValue))).CopyToDataTable();
                dtTmp.TableName = "PHIEU_TAM_XUAT_TAI_NHAP";
                frmRpt.AddDataTableSource(dtTmp);
                dtTmp = new System.Data.DataTable();
                dtTmp = (DataTable)grdDetails.DataSource;
                dtTmp.TableName = "PHIEU_TAM_XUAT_TAI_NHAP_CHI_TIET";
                frmRpt.AddDataTableSource(dtTmp);
                frmRpt.AddDataTableSource(LanguageReportTamXuatTaiNhap());
                Commons.Modules.SQLString = "0Design";
                frmRpt.ShowDialog();
                Commons.Modules.SQLString = "";
            }
            catch { }
        }
        private System.Data.DataTable LanguageReportTamXuatTaiNhap()
        {
            System.Data.DataTable vtbTitle = new System.Data.DataTable();
            vtbTitle.TableName = "TIEU_DE_TXTN";
            Int32 i = 0;
            for (i = 0; i <= 39; i++)
            {
                vtbTitle.Columns.Add();
            }
            try
            {
                vtbTitle.Columns[0].ColumnName = "MS_TX_TN";
                vtbTitle.Columns[1].ColumnName = "NGUOI_DE_NGHI";
                vtbTitle.Columns[2].ColumnName = "MS_NHAN_VIEN";
                vtbTitle.Columns[3].ColumnName = "TEN_BO_PHAN";
                vtbTitle.Columns[4].ColumnName = "CNMD";
                vtbTitle.Columns[5].ColumnName = "NGUOI_MANG_RA";
                vtbTitle.Columns[6].ColumnName = "NOI_NHAN";
                vtbTitle.Columns[7].ColumnName = "PHUONG_TIEN_VC";
                vtbTitle.Columns[8].ColumnName = "NGAY_LAP";
                vtbTitle.Columns[9].ColumnName = "NGUOI_LAP";
                vtbTitle.Columns[10].ColumnName = "NGUOI_DUYET";
                vtbTitle.Columns[11].ColumnName = "NGAY_DUYET";
                vtbTitle.Columns[12].ColumnName = "GHI_CHU";


                vtbTitle.Columns[13].ColumnName = "MS_TAI_SAN";
                vtbTitle.Columns[14].ColumnName = "TEN_TAI_SAN";
                vtbTitle.Columns[15].ColumnName = "DVT";
                vtbTitle.Columns[16].ColumnName = "SL_XUAT";
                vtbTitle.Columns[17].ColumnName = "NGAY_XUAT";
                vtbTitle.Columns[18].ColumnName = "LY_DO_XUAT";
                vtbTitle.Columns[19].ColumnName = "SL_NHAP";
                vtbTitle.Columns[20].ColumnName = "LY_DO_NHAP";
                vtbTitle.Columns[21].ColumnName = "NGAY_NHAP";
                vtbTitle.Columns[22].ColumnName = "TIEU_DE";

                vtbTitle.Columns[23].ColumnName = "TG_DK_MANG_HANG_VE";
                vtbTitle.Columns[24].ColumnName = "SUB_TIEU_DE";
                vtbTitle.Columns[25].ColumnName = "TAI_SAN";
                vtbTitle.Columns[26].ColumnName = "PHIEU_NHAP";
                vtbTitle.Columns[27].ColumnName = "PHIEU_XUAT";
                vtbTitle.Columns[28].ColumnName = "NGUOI_KIEM_TRA";
                vtbTitle.Columns[29].ColumnName = "BAO_VE";
                vtbTitle.Columns[30].ColumnName = "BAO_VE_KT";
                vtbTitle.Columns[31].ColumnName = "NGUOI_KIEM_TRA_KT";
                vtbTitle.Columns[32].ColumnName = "SO_PHIEU";
                vtbTitle.Columns[33].ColumnName = "DUYET";
                vtbTitle.Columns[34].ColumnName = "NGAY_THANG_NAM";

                vtbTitle.Columns[35].ColumnName = "TMP1";
                vtbTitle.Columns[36].ColumnName = "TMP2";
                vtbTitle.Columns[37].ColumnName = "TMP3";
                vtbTitle.Columns[38].ColumnName = "TMP4";
                vtbTitle.Columns[39].ColumnName = "TMP5";


                System.Data.DataRow vRowTitle = vtbTitle.NewRow();
                String sBC = "rptPhieuTamXuatTaiNhap";



                vRowTitle["MS_TX_TN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MS_TX_TN", Commons.Modules.TypeLanguage);
                vRowTitle["NGUOI_DE_NGHI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_DE_NGHI", Commons.Modules.TypeLanguage);
                vRowTitle["MS_NHAN_VIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MS_NHAN_VIEN", Commons.Modules.TypeLanguage);
                vRowTitle["TEN_BO_PHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_BO_PHAN", Commons.Modules.TypeLanguage);
                vRowTitle["CNMD"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "CNMD", Commons.Modules.TypeLanguage);
                vRowTitle["NGUOI_MANG_RA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_MANG_RA", Commons.Modules.TypeLanguage);
                vRowTitle["NOI_NHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NOI_NHAN", Commons.Modules.TypeLanguage);
                vRowTitle["PHUONG_TIEN_VC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHUONG_TIEN_VC", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_LAP", Commons.Modules.TypeLanguage);
                vRowTitle["NGUOI_LAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_LAP", Commons.Modules.TypeLanguage);
                vRowTitle["NGUOI_DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_DUYET", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_DUYET", Commons.Modules.TypeLanguage);
                vRowTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "GHI_CHU", Commons.Modules.TypeLanguage);

                vRowTitle["MS_TAI_SAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MS_TAI_SAN", Commons.Modules.TypeLanguage);
                vRowTitle["TEN_TAI_SAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_TAI_SAN", Commons.Modules.TypeLanguage);
                vRowTitle["DVT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DVT", Commons.Modules.TypeLanguage);
                vRowTitle["SL_XUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SL_XUAT", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_XUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_XUAT", Commons.Modules.TypeLanguage);
                vRowTitle["LY_DO_XUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LY_DO_XUAT", Commons.Modules.TypeLanguage);
                vRowTitle["SL_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SL_NHAP", Commons.Modules.TypeLanguage);
                vRowTitle["LY_DO_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LY_DO_NHAP", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_NHAP", Commons.Modules.TypeLanguage);
                vtbTitle.Rows.Add(vRowTitle);
                vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TIEU_DE", Commons.Modules.TypeLanguage);
                vRowTitle["TG_DK_MANG_HANG_VE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TG_DK_MANG_HANG_VE", Commons.Modules.TypeLanguage);

                vRowTitle["SUB_TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SUB_TIEU_DE", Commons.Modules.TypeLanguage);


                vRowTitle["TAI_SAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TAI_SAN", Commons.Modules.TypeLanguage);

                vRowTitle["PHIEU_NHAP"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHIEU_NHAP", Commons.Modules.TypeLanguage);

                vRowTitle["PHIEU_XUAT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHIEU_XUAT", Commons.Modules.TypeLanguage);


                vRowTitle["NGUOI_KIEM_TRA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_KIEM_TRA", Commons.Modules.TypeLanguage);

                vRowTitle["BAO_VE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "BAO_VE", Commons.Modules.TypeLanguage);

                vRowTitle["BAO_VE_KT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "BAO_VE_KT", Commons.Modules.TypeLanguage);


                vRowTitle["NGUOI_KIEM_TRA_KT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_KIEM_TRA_KT", Commons.Modules.TypeLanguage);

                vRowTitle["SO_PHIEU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "SO_PHIEU", Commons.Modules.TypeLanguage);

                vRowTitle["DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DUYET", Commons.Modules.TypeLanguage);

                vRowTitle["NGAY_THANG_NAM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_THANG_NAM", Commons.Modules.TypeLanguage);

                vRowTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP1", Commons.Modules.TypeLanguage);

                vRowTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP2", Commons.Modules.TypeLanguage);

                vRowTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP3", Commons.Modules.TypeLanguage);

                vRowTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP4", Commons.Modules.TypeLanguage);
                vRowTitle["TMP5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMP5", Commons.Modules.TypeLanguage);

                vtbTitle.Rows.Add(vRowTitle);
            }
            catch { }
            return vtbTitle;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            flag = false;
            //kiểm tra nếu tồn tại số phiếu thì tạo phếu mới
            int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(MS_TX_TN) FROM dbo.PHIEU_TAM_XUAT_TAI_NHAP WHERE  MS_TX_TN ='" + txtMsTXTN.EditValue.ToString().Trim() + "' AND  ID !=  " + txtMS.EditValue + " "));
            if (n > 0)
            {
                if (XtraMessageBox.Show(Commons.Modules.GetNNgu(this.Name, "MsgTrungSoPhieuTuDongCN"), Commons.Modules.GetNNgu(this.Name, "Message"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtMsTXTN.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT [dbo].[AUTO_CREATE_SO_TAM_XUAT]('" + datNgayLap.DateTime.ToString("MM/dd/yyyy") + "')").ToString();
                }
                else
                {
                    return;
                }
            }
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)grdDetails.DataSource;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "BTDetails" + Commons.Modules.UserName, dt, "");
                LoadgrdData(Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spSaveTamXuatTaiNhap",
                    txtMS.Text,
                    txtMsTXTN.Text,
                    txtTenNguoiDN.Text,
                    txtMsNhanVien.Text,
                    txtBoPhan.Text,
                    txtCMND.Text,
                    txtNguoiMHR.Text,
                    txtNoiNhanHang.Text,
                    txtPhuongTienVC.Text,
                    datThoiGianNHV.DateTime,
                    datNgayLap.DateTime,
                    txtGhiChu.Text,
                    Commons.Modules.UserName,
                    "BTDetails" + Commons.Modules.UserName
                    )));
            }
            catch
            {
                return;
            }
            visibleButon(true);
            grvDetails.OptionsBehavior.Editable = false;
            grvDetails.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }
        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.FocusedRowHandle >= 0)
                {
                    LoadgrdData(Convert.ToInt64(grvData.GetFocusedRowCellValue("ID")));
                }
            }
            catch 
            {}
            flag = false;
            visibleButon(true);
            grvDetails.OptionsBehavior.Editable = false;
            grvDetails.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        #endregion
        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            BingdingData();
            LoadgrdDetails();
        }

        private void datTu_Ngay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadgrdData(-1);
        }

        private void grdDetails_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDatadetails();
            }
        }

        private void grdData_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteData();
            }
        }
    }
}
