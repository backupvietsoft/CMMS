using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.Kido
{
    public partial class frmPhieuBaoTri_TuDong : DevExpress.XtraEditors.XtraForm
    {
        public bool isSuccess = false;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        public frmPhieuBaoTri_TuDong()
        {
            InitializeComponent();
        }
        private void LoadNguoiNghiemThu()
        {
            DataTable _tableCongNhan = new DataTable();
            _tableCongNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHANs2"));
            cmbNguoiNghiemThu.Properties.DisplayMember = "HO_TEN_CONG_NHAN";
            cmbNguoiNghiemThu.Properties.ValueMember = "MS_CONG_NHAN";
            cmbNguoiNghiemThu.Properties.DataSource = _tableCongNhan;

            cmbNguoiNghiemThu.Properties.Columns.Clear();
            cmbNguoiNghiemThu.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HO_TEN_CONG_NHAN"));

            DataTable _tableCongNhanEdit = new DataTable();
            _tableCongNhanEdit = _tableCongNhan.Copy();
            repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.NullText = "";
            repositoryItemLookUpEdit1.DisplayMember = "HO_TEN_CONG_NHAN";
            repositoryItemLookUpEdit1.ValueMember = "MS_CONG_NHAN";
            repositoryItemLookUpEdit1.DataSource = _tableCongNhanEdit;
            repositoryItemLookUpEdit1.Columns.Clear();
            repositoryItemLookUpEdit1.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HO_TEN_CONG_NHAN"));
            repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            repositoryItemDateEdit1.EditMask="dd/MM/yyyy HH:mm";
            repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            repositoryItemDateEdit1.LookAndFeel.SkinName = "Blue";
            repositoryItemDateEdit1.LookAndFeel.UseDefaultLookAndFeel = false;
            repositoryItemDateEdit1.Mask.EditMask = "dd/MM/yyyy HH:mm";
            repositoryItemDateEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
        }
        public DataTable _tableSource = new DataTable();
        private void frmPhieuBaoTri_TuDong_Load(object sender, EventArgs e)
        {
            LoadNguoiNghiemThu();
            txtNgayNghiemThu.DateTime = DateTime.Now;
            gridControl1.DataSource = _tableSource;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            {
                col.AppearanceHeader.Options.UseTextOptions = true;
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                col.Width = 150;
                col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, col.FieldName, Commons.Modules.TypeLanguage);
                if (col.FieldName.Equals("Nguoi_Nghiem_Thu") || col.FieldName.Equals("Ngay_Nghiem_Thu")
                                  || col.FieldName.Equals("Tinh_Trang_Sau_BT") || col.FieldName.Equals("Chon"))
                {
                    if (col.FieldName.Equals("Nguoi_Nghiem_Thu"))
                    {
                        col.ColumnEdit = repositoryItemLookUpEdit1;
                    }
                    if (col.FieldName.Equals("Ngay_Nghiem_Thu"))
                    {
                        col.ColumnEdit = repositoryItemDateEdit1;
                    }
                    col.OptionsColumn.AllowEdit = true;
                }
                else
                    col.OptionsColumn.AllowEdit = false;

            }

            btnExecute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnExecute", Commons.Modules.TypeLanguage);
            btnCancel.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnCancel", Commons.Modules.TypeLanguage);
            btnUpdate.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnUpdate", Commons.Modules.TypeLanguage);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string nguoiNghiemThu = Convert.ToString(cmbNguoiNghiemThu.EditValue);
            string tinhtrang = txtTinhTrang.Text;
            if (!string.IsNullOrEmpty(nguoiNghiemThu))
            {
                if (!string.IsNullOrEmpty(tinhtrang))
                {
                    DataTable _table = new DataTable();
                    _table = _tableSource.Copy();

                    _table.DefaultView.RowFilter = "Chon=True";
                    _table = _table.DefaultView.ToTable();
                    if (_table.Rows.Count > 0)
                    {
                        foreach (DataRow _row in _tableSource.Rows)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(_row["Chon"])))
                            {
                                if (Convert.ToBoolean(_row["Chon"]))
                                {
                                    _row["Nguoi_Nghiem_Thu"] = nguoiNghiemThu;
                                    _row["Ngay_Nghiem_Thu"] = txtNgayNghiemThu.DateTime;
                                    _row["Tinh_Trang_Sau_BT"] = tinhtrang;
                                }
                            }

                        }
                        btnExecute.Enabled = true;
                    }
                    else
                    {
                        btnExecute.Enabled = false;
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaChonPBT", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    btnExecute.Enabled = false;
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TinhTrangBaoTri", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTinhTrang.Focus();
                }
            }
            else
            {
                btnExecute.Enabled = false;
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChonNguoiNghiemThu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNguoiNghiemThu.Focus();
            }
        }
        private bool IsUseKho
        {
            get
            {
                string sql = "SELECT PBT_KHO FROM THONG_TIN_CHUNG";
                var a = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sql);
                if (Convert.ToInt16(a) == 0)
                    return false;
                        return true;
            }
        }
        private bool IsValidNgayNghiemThu
        {
            get
            {
                DateTime _ngay_kt = DateTime.Now;
                bool isCheck = false;
                string tmp = "";
                string ms_phieu = "";
                DataTable _table, _table_pt, _table_vt, _table_pt_xuat;
                DateTime ngay_nghiem_thu = DateTime.Now;
                gridControl1.DataSource = _tableSource;
                for (int j = 0; j < gridView1.RowCount; j++)
                {
                    tmp = Convert.ToString(gridView1.GetRowCellValue(j, "Chon"));
                    if (string.IsNullOrEmpty(tmp))
                        isCheck = false;
                    else
                        isCheck = Convert.ToBoolean(gridView1.GetRowCellValue(j, "Chon"));
                    if (isCheck)
                    {
                        _ngay_kt = Convert.ToDateTime(gridView1.GetRowCellValue(j, "NGAY_KT_KH"));
                        tmp = Convert.ToString(gridView1.GetRowCellValue(j, "Ngay_Nghiem_Thu"));
                        if (string.IsNullOrEmpty(tmp))
                        {
                            gridView1.FocusedRowHandle = j;
                            gridView1.FocusedColumn = gridView1.Columns["Ngay_Nghiem_Thu"];
                            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "vuilongnhapdulieudaydu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        ngay_nghiem_thu = Convert.ToDateTime(tmp);
                        tmp = Convert.ToString(gridView1.GetRowCellValue(j, "Nguoi_Nghiem_Thu"));
                        if (string.IsNullOrEmpty(tmp))
                        {
                            gridView1.FocusedRowHandle = j;
                            gridView1.FocusedColumn = gridView1.Columns["Nguoi_Nghiem_Thu"];
                            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "vuilongnhapdulieudaydu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        tmp = Convert.ToString(gridView1.GetRowCellValue(j, "Tinh_Trang_Sau_BT"));
                        if (string.IsNullOrEmpty(tmp))
                        {
                            gridView1.FocusedRowHandle = j;
                            gridView1.FocusedColumn = gridView1.Columns["Tinh_Trang_Sau_BT"];
                            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "vuilongnhapdulieudaydu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        
                        if (_ngay_kt > ngay_nghiem_thu)
                        {
                            gridView1.FocusedRowHandle = j;
                            gridView1.FocusedColumn = gridView1.Columns["NGAY_KT_KH"];
                            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NgayNghiemThuNhoHonNgayKTKH", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            ms_phieu = gridView1.GetRowCellValue(j, "MS_PHIEU_BAO_TRI").ToString();
                            _table = new DataTable();
                            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_DS_PT_KIDO", ms_phieu));
                            _table_pt = new DataTable();
                            _table_pt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "[SP_GET_PTSD_PBT_CHI_TIET]", ms_phieu));
                            _table_pt_xuat = new DataTable();
                            _table_pt_xuat.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_GET_PT_XUAT_PTSD", ms_phieu));
                            int check_cv = -1;
                            check_cv = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_CHECK_CONG_VIEC_KHONG_THUC_HIEN", ms_phieu, true));
                            if (check_cv > 0)
                            {
                                gridView1.FocusedRowHandle = j;
                                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaCoPTChoKH", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;

                            }
                            else
                            {
                                if (IsUseKho)
                                {
                                    if (_table_pt_xuat.Rows.Count > 0)
                                    {
                                        foreach (DataRow _row in _table_pt_xuat.Rows)
                                        {
                                            if (!_row["SL_TT"].Equals(_row["SL_VT"]))
                                            {
                                                gridView1.FocusedRowHandle = j;
                                                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "soluongkhongcan", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        gridView1.FocusedRowHandle = j;
                                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "chuacoxuatkho", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                              
                            }
                            if (IsUseKho)
                            {
                                _table_vt = new DataTable();
                                _table_vt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_GetDanhSachVatTuXuatBaoTri", ms_phieu));
                                if (_table_vt.Rows.Count > 0)
                                {
                                    foreach (DataRow _row in _table_vt.Rows)
                                    {
                                        if (string.IsNullOrEmpty(Convert.ToString(_row["SO_LUONG_THUC_XUAT"])))
                                        {
                                            gridView1.FocusedRowHandle = j;
                                            MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "soluongkhongcan", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    gridView1.FocusedRowHandle = j;
                                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "chuaxuatkho", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }

                        }

                    }
                }
                return true;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (IsValidNgayNghiemThu)
            {
                DataTable _table_copy = new DataTable();
                _table_copy = _tableSource.Copy();
                _table_copy.DefaultView.RowFilter = "Chon=True";
                _table_copy = _table_copy.DefaultView.ToTable();
                if (_table_copy.Rows.Count > 0)
                {
                    DataTable _table_value;
                    double chi_phi_nc_vnd, chi_phi_nc_usd, chi_phi_vt, chi_phi_vt_usd, chi_phi_pt, chi_phi_pt_usd, chi_phi_dv, chi_phi_dv_usd;
                    bool isDinhMuc = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetPBT_CPNC")) == 0 ? false : true;

                    string ms_phieu_bt = "", nguoi_nghiem_thu = "", tinh_trang_sau_bt="",tmp="";
                
                    string sql = "";
                    DateTime ngay_nghiem_thu = DateTime.Now;
                    System.Data.SqlClient.SqlConnection objConnection = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);

                    objConnection.Open();
                    System.Data.SqlClient.SqlTransaction objTrans = objConnection.BeginTransaction();
                    foreach (DataRow _row in _table_copy.Rows)
                    {
                        ms_phieu_bt = Convert.ToString(_row["MS_PHIEU_BAO_TRI"]);
                        tmp = Convert.ToString(_row["NGAY_NGHIEM_THU"]);
                        
                        tinh_trang_sau_bt = Convert.ToString(_row["Tinh_Trang_Sau_BT"]);
                        nguoi_nghiem_thu = Convert.ToString(_row["Nguoi_Nghiem_Thu"]);
                          ngay_nghiem_thu = Convert.ToDateTime(_row["NGAY_NGHIEM_THU"]);
                      
                        #region cập nhật chi phí cho bảo trì
                        #region chi phí nhân công
                        if (isDinhMuc)
                        {
                            DataTable _table_chi_phi = new DataTable();
                            _table_chi_phi.Load(SqlHelper.ExecuteReader(objTrans, "GetPHIEU_BAO_TRI_CPNC_NEW", ms_phieu_bt, ngay_nghiem_thu));
                            if (_table_chi_phi.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(_table_chi_phi.Rows[0]["TI_GIA"])))
                            {
                                chi_phi_nc_vnd = Double.Parse(_table_chi_phi.Rows[0]["TI_GIA"].ToString());
                                chi_phi_nc_usd = Double.Parse(_table_chi_phi.Rows[0]["TI_GIA_USD"].ToString());
                            }
                            else
                            {
                                chi_phi_nc_vnd = 0;
                                chi_phi_nc_usd = 0;
                            }

                        }
                        else
                        {

                            DataTable _table_ti_gia = new DataTable();
                            double luong = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LUONG_NHAN_CONG", ms_phieu_bt));
                            _table_ti_gia.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_TI_GIA", ngay_nghiem_thu));
                            double ti_gia = 0;
                            chi_phi_nc_vnd = chi_phi_nc_usd = 0;
                            try
                            {
                                ti_gia = Convert.ToDouble(_table_ti_gia.Rows[0]["TI_GIA"]);
                                chi_phi_nc_vnd = luong * ti_gia;
                            }
                            catch
                            {
                                ti_gia = 0;
                            }
                            double ti_gia_usd = 0;
                            try
                            {
                                ti_gia_usd = Convert.ToDouble(_table_ti_gia.Rows[0]["TI_GIA_USD"]);
                                chi_phi_nc_usd = luong * ti_gia_usd;
                            }
                            catch
                            {
                                ti_gia_usd = 0;
                            }
                        }
                        #endregion
                        #region chi phí vật tư
                        _table_value = new DataTable();
                        if (IsUseKho)
                            _table_value.Load(SqlHelper.ExecuteReader(objTrans, "GET_TONG_CHI_PHI_VT", ms_phieu_bt));
                        else
                            _table_value.Load(SqlHelper.ExecuteReader(objTrans, "SP_NHU_Y_GET_CHI_PHI_VT_PT_KHONG_SD_KHO", ms_phieu_bt,1));
                        chi_phi_vt = 0;
                        chi_phi_vt_usd = 0;
                        foreach (DataRow _row_vt in _table_value.Rows)
                        {
                            chi_phi_vt += Convert.ToString(_row_vt[0]) == "" ? 0 : Convert.ToDouble(_row_vt[0]);
                            chi_phi_vt_usd += Convert.ToString(_row_vt[1]) == "" ? 0 : Convert.ToDouble(_row_vt[1]);

                        }
                       
                        #endregion
                        #region chi phí phụ tùng
                        _table_value = new DataTable();
                        if (IsUseKho)
                      
                             _table_value.Load(SqlHelper.ExecuteReader(objTrans, "SP_NHU_Y_GET_TONG_CHI_PHI_VT", ms_phieu_bt));
                        else
                            _table_value.Load(SqlHelper.ExecuteReader(objTrans, "SP_NHU_Y_GET_CHI_PHI_VT_PT_KHONG_SD_KHO", ms_phieu_bt,0));
                        chi_phi_pt = 0;
                        chi_phi_pt_usd = 0;
                        try
                        {
                            chi_phi_pt = Convert.ToDouble(_table_value.Rows[0][0]);
                            chi_phi_pt_usd = Convert.ToDouble(_table_value.Rows[0][1]);
                        }
                        catch
                        {
                            chi_phi_pt = 0;
                            chi_phi_pt_usd = 0;
                        }
                        
                       
                        #endregion
                        #region chi phí dịch vụ
                        chi_phi_dv = 0; chi_phi_dv_usd = 0;
                        _table_value = new DataTable();
                        _table_value.Load(SqlHelper.ExecuteReader(objTrans, "SP_NHU_Y_GET_TONG_CP_DV", ms_phieu_bt));
                        try
                        {
                            chi_phi_dv = Convert.ToDouble(_table_value.Rows[0]["CHI_PHI_DV"]);
                            chi_phi_dv_usd = Convert.ToDouble(_table_value.Rows[0]["CHI_PHI_DV_USD"]);
                        }
                        catch
                        {
                            chi_phi_dv = 0;
                            chi_phi_dv_usd = 0;
                        }
                        #endregion
                        #endregion
                      
                          
                            #region Insert dữ liệu
                            try
                            {
                                sql = "UPDATE PHIEU_BAO_TRI SET TINH_TRANG_PBT=3 WHERE MS_PHIEU_BAO_TRI='" + ms_phieu_bt + "'";
                                SqlHelper.ExecuteNonQuery(objTrans, "SP_NHU_Y_UPDATE_PBT_TU_DONG", ngay_nghiem_thu, nguoi_nghiem_thu, Commons.Modules.UserName, ms_phieu_bt, tinh_trang_sau_bt);

                                sql = "UPDATE PHIEU_BAO_TRI_CONG_VIEC SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" + ngay_nghiem_thu + "',103) WHERE MS_PHIEU_BAO_TRI='" + ms_phieu_bt + "' AND NGAY_HOAN_THANH IS NULL";
                                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql);
                                sql = "UPDATE PHIEU_BAO_TRI_CV_PHU_TRO SET NGAY_HOAN_THANH=CONVERT(DATETIME,'" + ngay_nghiem_thu + "',103) WHERE MS_PHIEU_BAO_TRI='" + ms_phieu_bt + "' AND NGAY_HOAN_THANH IS NULL";
                                SqlHelper.ExecuteNonQuery(objTrans, CommandType.Text, sql);
                                try
                                {
                                    SqlHelper.ExecuteNonQuery(objTrans, "AddPHIEU_BAO_TRI_CHI_PHI", ms_phieu_bt, chi_phi_pt, chi_phi_pt_usd, chi_phi_vt, chi_phi_vt_usd, chi_phi_nc_vnd, chi_phi_nc_usd, chi_phi_dv, chi_phi_dv_usd);
                                }
                                catch
                                {
                                    SqlHelper.ExecuteNonQuery(objTrans, "UpdatePHIEU_BAO_TRI_CHI_PHI", ms_phieu_bt, chi_phi_pt, chi_phi_pt_usd, chi_phi_vt, chi_phi_vt_usd, chi_phi_nc_vnd, chi_phi_nc_usd, chi_phi_dv, chi_phi_dv_usd);
                                }
                            }
                            catch (Exception ex)
                            {
                                objTrans.Rollback();
                                MessageBox.Show(ex.Message);
                                return;
                            }
                            #endregion
                     
                    }

                    objTrans.Commit();
                    objConnection.Close();
                    isSuccess = true;
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lapphieubaotrithanhcong", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK);

                    _tableSource.DefaultView.RowFilter = "Chon=False";
                }
                else
                {
                   // btnExecute.Enabled = false;
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaChonPBT", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           
        }
    }
}