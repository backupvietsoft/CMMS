using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using Commons.VS.Classes.Catalogue;

namespace MVControl
{
    public partial class frmKiemKeKho : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dtVTPT;
        public frmKiemKeKho()
        {
            InitializeComponent();
        }
        private void LoadKho()
        {
            try
            {
                cboKho.Properties.DataSource = null;
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, Commons.Modules.ObjSystems.MLoadDataKho(0), "MS_KHO", "TEN_KHO", lblKho.Text);
            }
            catch { }
        }
        private void frmKiemKeKho_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            LoadKho();
            Commons.Modules.SQLString = "";
            cboKho_EditValueChanged(null, null);
            cboNgayKK_EditValueChanged(null, null);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();

        }

        private void txtTKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)grdChon.DataSource;
                try
                {
                    dt.DefaultView.RowFilter = " MS_PT LIKE '%" + txtTKiem.Text.Trim() + "%' OR TEN_PT LIKE '%" + txtTKiem.Text.Trim()
                        + "%' OR MS_PT_NCC LIKE '%" + txtTKiem.Text.Trim() + "%' OR MS_PT_CTY LIKE '%" + txtTKiem.Text.Trim() + "%'";
                    dt = dt.DefaultView.ToTable();
                }
                catch (Exception exx)
                {
                    XtraMessageBox.Show(exx.Message);
                    dt.DefaultView.RowFilter = "";
                    dt = dt.DefaultView.ToTable();
                }
            }
            catch { }
        }


        private void cboKho_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Commons.Modules.SQLString == "0LOAD") return;
                if (btnGhi.Visible == false)
                {
                    string str = "SELECT NGAY NGAYSORT, Convert(nvarchar(15), NGAY, 103) + ' ' +  Convert(nvarchar(5), GIO, 108) + '!' + Convert(nvarchar(8), GIO, 108) as NGAY, Convert(nvarchar(15), NGAY, 103) + ' ' +  Convert(nvarchar(5), GIO, 108) AS TEN_NGAY FROM KIEM_KE WHERE MS_KHO = " + cboKho.EditValue + " ORDER BY NGAYSORT DESC";
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                    Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNgayKK, dt, "NGAY", "TEN_NGAY", "");
                    if (dt.Rows.Count == 0)
                    {
                        grdChon.DataSource = null;
                        SetVisibleButton(true);                       
                    }

                    if (grvChon.RowCount == 0)
                    {
                       
                        btnSua.Enabled = false;
                        btnIn.Enabled = false;
                        btnXoa.Enabled = false;
                        btnLock.Visible = false;

                    }
                    if (grvChon.RowCount > 0 & ckLock.Checked == true)
                    {
                        btnSua.Enabled = false;
                        btnIn.Enabled = true;
                        btnXoa.Enabled = false;
                    }
                    else if (grvChon.RowCount > 0 & ckLock.Checked == false)
                    {
                        btnSua.Enabled = true;
                        btnIn.Enabled = true;
                        btnXoa.Enabled = true;
                    }

                }
            }
            catch { }
        }



        private void cboNgayKK_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Commons.Modules.SQLString == "0LOAD") return;
                if (btnGhi.Visible == false)
                {
                    if (!(cboNgayKK.EditValue == null))
                    {
                        try
                        {
                            dtNgay.EditValue = Convert.ToDateTime(cboNgayKK.EditValue.ToString().Split('!')[0], new System.Globalization.CultureInfo("vi-vn"));
                            dtGio.EditValue = cboNgayKK.EditValue.ToString().Split('!')[1];
                            LoadPhieuKiemKe();
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void SetVisibleButton(bool flag)
        {
            btnThem.Visible = flag;
            btnSua.Visible = flag;
            btnIn.Visible = flag;
            btnXoa.Visible = flag;
            btnThoat.Visible = flag;
            btnLock.Visible = flag;
            btnCapNhatSL.Visible = !flag;
            btnTinhTon.Visible = !flag;
            btnGhi.Visible = !flag;
            btnKhongGhi.Visible = !flag;
            btnTinhTon.Enabled = flag;
            if (flagAction != 2)
            {
                cboNgayKK.Visible = flag;
                dtNgay.Visible = !flag;
                dtGio.Enabled = !flag;
                cboNgayKK.Enabled = flag;
            }
        }

        public void EnableButton(bool bln)
        {
            btnThem.Enabled = bln;
            btnSua.Enabled = bln;
            btnXoa.Enabled = bln;
            btnLock.Enabled = bln;
            btnCapNhatSL.Enabled = bln;
        }


        private void LoadPhieuKiemKe()
        {
            if (cboKho.EditValue != null)
            {
                DataTable dtKiemKe = new DataTable();
                DataTable dtTable = new DataTable();
                dtKiemKe.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_PHIEU_KIEM_KE", int.Parse(cboKho.EditValue.ToString()), dtNgay.DateTime.ToString("yyy/MM/dd HH:mm")));

                Commons.VS.Classes.Catalogue.KIEM_KE_Controller objKiemKeController = new Commons.VS.Classes.Catalogue.KIEM_KE_Controller();

                if (dtKiemKe.Rows.Count > 0)
                {
                    DateTime ngayKK = Convert.ToDateTime(dtNgay.DateTime.ToString("yyy/MM/dd") + " " + Convert.ToDateTime(dtKiemKe.Rows[0]["GIO"]).ToString("HH:mm"));
                    dtTable = objKiemKeController.LOAD_PHIEU_KIEM_KE_CHI_TIET(int.Parse(cboKho.EditValue.ToString()), ngayKK, -1);
                    dtTable.DefaultView.RowFilter = "1=1";

                    try
                    {
                        grdChon.DataSource = null;
                        grvChon.Columns.Clear();

                    }
                    catch { }
                    dtTable.Columns["SL_TON_TT"].ReadOnly = false;
                    dtTable.Columns["GHI_CHU"].ReadOnly = false;
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChon, grvChon, dtTable.DefaultView.ToTable(), true, true, true, false, true, Name.ToString());
                    FormatGrid();
                    dtGio.EditValue = dtKiemKe.Rows[0]["GIO"];
                    ckLock.Checked = Convert.ToBoolean(dtKiemKe.Rows[0]["LOCK"]);
                    if (Convert.ToBoolean(dtKiemKe.Rows[0]["LOCK"]) == false)
                    {
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnLock.Visible = true;
                    }
                    else
                    {
                        btnSua.Enabled = false;
                        btnLock.Visible = false;
                        btnXoa.Enabled = false;
                    }
                }
                else
                {
                    ckLock.Checked = false;
                    btnLock.Visible = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
                
                if (grvChon.RowCount == 0)
                {
                    grdChon.DataSource = DBNull.Value;
                    btnSua.Enabled = false;
                    btnIn.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLock.Visible = false;
                    
                }
                if (grvChon.RowCount > 0 & ckLock.Checked == true)
                {
                    btnSua.Enabled = false;
                    btnIn.Enabled = true;
                    btnXoa.Enabled = false;
                }
                else if (grvChon.RowCount > 0 & ckLock.Checked == false)
                {
                    btnSua.Enabled = true;
                    btnIn.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
        }
        private void FormatGrid()
        {
            if (grvChon.RowCount > 0)
            {
                grvChon.Columns["MS_VI_TRI"].Visible = false;
                grvChon.Columns["TEN_VI_TRI"].Width = 80;
                grvChon.Columns["TEN_VI_TRI"].OptionsColumn.ReadOnly = true;
                grvChon.Columns["MS_PT"].OptionsColumn.ReadOnly = true;
                grvChon.Columns["MS_DH_NHAP_PT"].OptionsColumn.ReadOnly = true;
                grvChon.Columns["MS_DH_NHAP_PT"].Width = 100;
                grvChon.Columns["MS_PT_NCC"].OptionsColumn.ReadOnly = true;
                grvChon.Columns["MS_PT_NCC"].Width = 80;
                grvChon.Columns["MS_PT_CTY"].OptionsColumn.ReadOnly = true;
                grvChon.Columns["MS_PT_CTY"].Width = 80;
                grvChon.Columns["TEN_PT"].OptionsColumn.ReadOnly = true;
                grvChon.Columns["TEN_PT"].Width = 160;
                grvChon.Columns["DVT"].OptionsColumn.ReadOnly = true;
                grvChon.Columns["DVT"].Width = 50;
                grvChon.Columns["SL_TON_CTU"].OptionsColumn.ReadOnly = true;
                grvChon.Columns["SL_TON_CTU"].Width = 80;
                grvChon.Columns["SL_TON_CTU"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
                grvChon.Columns["SL_TON_CTU"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvChon.Columns["SL_TON_CTU"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvChon.Columns["SL_TON_TT"].Width = 80;
                grvChon.Columns["SL_TON_TT"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
                grvChon.Columns["SL_TON_TT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvChon.Columns["SL_TON_TT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                grvChon.Columns["GHI_CHU"].Width = 200;
                grvChon.Columns["ID_KK"].Visible = false;
                if ((btnGhi.Visible))
                {
                    grvChon.Columns["SL_TON_TT"].OptionsColumn.ReadOnly = false;
                    grvChon.Columns["GHI_CHU"].OptionsColumn.ReadOnly = false;
                }
                else
                {
                    grvChon.Columns["SL_TON_TT"].OptionsColumn.ReadOnly = true;
                    grvChon.Columns["GHI_CHU"].OptionsColumn.ReadOnly = true;
                }

            }

        }
        int flagAction = 0;

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (cboKho.EditValue == null)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "CHON_KHO_CAN_TINH", Commons.Modules.TypeLanguage));
                return;
            }
            flagAction = 1;
            

            dtNgay.DateTime = DateTime.Now;
            dtGio.EditValue = DateTime.Now.ToString("HH:mm");
            tableLayoutPanel2.SetColumn(cboNgayKK, tableLayoutPanel2.ColumnCount - 1);
            tableLayoutPanel2.SetColumn(dtNgay, 4);


            SetVisibleButton(false);
            btnTinhTon.Enabled = true;

            try
            {
                grdChon.DataSource = null;
            }
            catch { }
        }

        private void btnTinhTon_Click(object sender, EventArgs e)
        {
            Commons.VS.Classes.Catalogue.KIEM_KE_Controller objKiemKeController = new Commons.VS.Classes.Catalogue.KIEM_KE_Controller();

            int MS_KHO = int.Parse(cboKho.EditValue.ToString());
            DateTime ngayKK = Convert.ToDateTime(dtNgay.DateTime.ToString("yyy/MM/dd") + " " + dtGio.Text);
            if (objKiemKeController.CHECK_PHIEU_KIEM_KE_EXISTS(MS_KHO, ngayKK))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "MsgdataophieuKK", Commons.Modules.TypeLanguage));
                return;
            }
            else
            {
                if (objKiemKeController.CheckKIEM_KE_VAT_TU_CHI_TIET_LON_HON_NGAY_KIEM_KE(dtGio.Text, dtNgay.DateTime.ToString("yyy/MM/dd"), Convert.ToInt32(cboKho.EditValue)))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "msgNgayKiemKe", Commons.Modules.TypeLanguage));
                    return;
                }
                else
                {
                    if (objKiemKeController.CHECK_PHIEU_KIEM_KE_UNLOCK_EXISTS(cboKho.EditValue.ToString()))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "PHIEU_KIEM_KE_UNLOCK_EXISTS", Commons.Modules.TypeLanguage));
                        return;
                    }
                    if (objKiemKeController.CheckIC_DON_HANG_NHAP_LON_HON_NGAY_KIEM_KE(dtGio.Text, string.Format(dtNgay.EditValue.ToString(), "Short date"), Convert.ToInt32(cboKho.EditValue)))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "msgNgayNhap", Commons.Modules.TypeLanguage));
                        return;
                    }
                    else
                    {
                        if (objKiemKeController.CHECK_PHIEU_NHAP_UNLOCK_EXISTS(MS_KHO))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "PHIEU_NHAP_UNLOCK_EXISTS", Commons.Modules.TypeLanguage));
                            return;
                        }
                        if (objKiemKeController.CheckIC_DON_HANG_XUAT_LON_HON_NGAY_KIEM_KE(dtGio.Text, string.Format(dtNgay.EditValue.ToString(), "Short date"), Convert.ToInt32(cboKho.EditValue)))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "msgNgayxuat", Commons.Modules.TypeLanguage));
                            return;
                        }
                        else
                        {
                            if (objKiemKeController.CHECK_PHIEU_XUAT_UNLOCK_EXISTS(MS_KHO))
                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "PHIEU_XUAT_UNLOCK_EXISTS", Commons.Modules.TypeLanguage));
                                return;
                            }

                            if (objKiemKeController.CheckIC_KHO_LON_HON_NGAY_KIEM_KE(dtGio.Text, string.Format(dtNgay.EditValue.ToString(), "Short date"), Convert.ToInt32(cboKho.EditValue)))

                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "msgNgayKho", Commons.Modules.TypeLanguage));
                                return;
                            }
                        }
                    }
                }
            }

            try
            {
                grdChon.DataSource = null;
                grvChon.Columns.Clear();

            }
            catch { }
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_LIST_TON_KHO_VAT_TU", MS_KHO, 1, -1));
            dt.Columns["SL_TON_TT"].ReadOnly = false;
            dt.Columns["GHI_CHU"].ReadOnly = false;
           
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChon, grvChon, dt, true, true, true, false, true, Name.ToString());
            FormatGrid();
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.SetColumn(dtNgay, 0);
            tableLayoutPanel2.SetColumn(cboNgayKK, 4);
            flagAction = 0;
            cboKho.Enabled = true;   
            SetVisibleButton(true);
            try
            {
                grvChon.Columns.Clear();
                grdChon.DataSource = null;
            }
            catch { }      
            cboKho_EditValueChanged(null, null);
            
        }

        private void btnCapNhatSL_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= grvChon.RowCount - 1; i++)
            {
                try
                {
                    grvChon.SetRowCellValue(i, "SL_TON_TT", grvChon.GetDataRow(i)["SL_TON_CTU"]);
                    grvChon.UpdateCurrentRow();
                }
                catch { continue; }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                bool vcheck = false;
                if (grvChon.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "KHONG_CO_CHI_TIET_KIEM_KE", Commons.Modules.TypeLanguage), Name);
                    return;
                }

                DataTable dt = ((DataTable)grdChon.DataSource).Copy();
                dt.DefaultView.RowFilter = "SL_TON_TT <> 0";
                if (dt.DefaultView.ToTable().Rows.Count > 0)
                {
                    vcheck = true;
                }

                if (vcheck == false)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, Name, "CHUA_KIEM_TON_THUC_TE", Commons.Modules.TypeLanguage), Name, MessageBoxButtons.OK);
                    return;
                }

                Commons.VS.Classes.Catalogue.KIEM_KE_Controller objKiemKeController = new Commons.VS.Classes.Catalogue.KIEM_KE_Controller();
                DateTime ngayKK = Convert.ToDateTime(dtNgay.DateTime.ToString("yyy/MM/dd") + " " + dtGio.Text);
                if (flagAction == 1)
                {
                    SqlConnection objConnection = new SqlConnection(Commons.IConnections.ConnectionString);
                    objConnection.Open();
                    SqlTransaction objTrans = objConnection.BeginTransaction();
                    string SQLString_VI_TRI_KHO = "";
                    try
                    {
                        SqlHelper.ExecuteNonQuery(objTrans, "QL_ADD_KIEM_KE", ngayKK, double.Parse(cboKho.EditValue.ToString()), Convert.ToDateTime("1900/01/01" + " " + dtGio.Text), 0);
                        for (int i = 0; i <= dt.DefaultView.ToTable().Rows.Count - 1; i++)
                        {
                            DataRow row = dt.Rows[i];                        

                            Commons.Modules.SQLString = "INSERT INTO KIEM_KE_VAT_TU_CHI_TIET(NGAY,MS_KHO,MS_PT,STT,MS_VI_TRI,MS_DH_NHAP_PT,SL_KK_CT,SL_CHUNG_TU,GHI_CHU, ID_KK) " + "VALUES(N'" + ngayKK.ToString("yyy/MM/dd HH:mm") + "'," + double.Parse(cboKho.EditValue.ToString()) + ",N'" + row["MS_PT"].ToString() + "'," + i + 1 + "," + int.Parse(row["MS_VI_TRI"].ToString()) + ",'" + row["MS_DH_NHAP_PT"].ToString() + "'," + row["SL_TON_TT"] + "," + row["SL_TON_CTU"] + " ,'" + row["GHI_CHU"].ToString() + "'," + row["ID_KK"] + " )";

                            SQLString_VI_TRI_KHO = "UPDATE VI_TRI_KHO_VAT_TU SET SL_VT = " + row["SL_TON_TT"] + " WHERE MS_KHO = " + double.Parse(cboKho.EditValue.ToString()) + " AND MS_PT = '" + row["MS_PT"].ToString() + "' AND MS_VI_TRI = '" + int.Parse(row["MS_VI_TRI"].ToString()) + "' AND ID = " + row["ID_KK"] + " AND MS_DH_NHAP_PT = '" + row["MS_DH_NHAP_PT"].ToString() + "'";

                            SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", Commons.Modules.SQLString);
                            SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", SQLString_VI_TRI_KHO);

                        }
                        objTrans.Commit();
                    }
                    catch
                    {
                        objTrans.Rollback();
                    }
                    finally
                    {
                        objConnection.Close();
                    }
                }
                else if (flagAction == 2)
                {
                    SqlConnection objConnection = new SqlConnection(Commons.IConnections.ConnectionString);
                    objConnection.Open();
                    SqlTransaction objTrans = objConnection.BeginTransaction();
                    try
                    {
                        for (int i = 0; i <= dt.DefaultView.ToTable().Rows.Count - 1; i++)
                        {
                            DataRow row = dt.Rows[i];
                            SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_KIEM_KE_VAT_TU_CHI_TIET", ngayKK.ToString("yyy/MM/dd HH:mm"), double.Parse(cboKho.EditValue.ToString()), row["MS_PT"].ToString(), int.Parse(row["MS_VI_TRI"].ToString()), row["MS_DH_NHAP_PT"].ToString(), double.Parse(row["SL_TON_TT"].ToString()), row["GHI_CHU"].ToString(), double.Parse(row["ID_KK"].ToString()));

                            SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_VI_TRI_KHO_VAT_TU", double.Parse(cboKho.EditValue.ToString()), row["MS_PT"].ToString(), int.Parse(row["MS_VI_TRI"].ToString()), row["MS_DH_NHAP_PT"].ToString(), double.Parse(row["SL_TON_TT"].ToString()), double.Parse(row["ID_KK"].ToString()));

                        }
                        objTrans.Commit();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                        objTrans.Rollback();

                    }
                    finally
                    {
                        objConnection.Close();
                    }




                }
                flagAction = 0;
                tableLayoutPanel2.SetColumn(dtNgay, 0);
                tableLayoutPanel2.SetColumn(cboNgayKK, 4);
                SetVisibleButton(true);
                cboKho.Enabled = true;
                try
                {
                    grvChon.Columns.Clear();
                    grdChon.DataSource = null;
                }
                catch { }
                cboKho_EditValueChanged(null, null);


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flagAction = 2;
            SetVisibleButton(false);
            cboNgayKK.Enabled = false;
            dtGio.Enabled = false;

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgLockphieuKK", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "QL_LOCK_PHIEU_KIEM_KE", int.Parse(this.cboKho.EditValue.ToString()), dtNgay.DateTime);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "PHIEU_KIEM_KE_DA_DUOC_LOCK", Commons.Modules.TypeLanguage));
                this.btnLock.Visible = false;
                ckLock.Checked = true;
                btnSua.Enabled = false;
                btnIn.Enabled = true;
                btnXoa.Enabled = false;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

            DataTable dtKIEM_KE_VAT_TU = new DataTable();
            DataTable dtTIEU_DE_KIEM_KE_VAT_TU = new DataTable();

            if (grvChon.RowCount > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                dtKIEM_KE_VAT_TU = ((DataTable)(grdChon.DataSource)).Copy();

            }
            else
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KHONG_CO_DU_LIEU_IN", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Cursor = Cursors.Default;
                return;
            }



            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtKIEM_KE_VAT_TU, false, true, true, true, true, this.Name);
            grvChung.Columns["MS_VI_TRI"].Visible = false;
            grvChung.Columns["TEN_PT"].VisibleIndex = 1;
            grvChung.Columns["GHI_CHU"].VisibleIndex = 11;
            InDuLieu();



            this.Cursor = Cursors.Default;
        }


        public void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xls)|*.xls");
            //"C:\Users\Administrator\Desktop\frmrptCTY_DA_CUNG_CAP_VAT_TU.xls" '
            if (string.IsNullOrEmpty(sPath))
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();

            try
            {
                int TCot = grvChung.Columns.Count - 1;
                int TDong = grvChung.RowCount;
                int Dong = 1;

                grdChung.ExportToXls(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true,
                false, 0, true);

                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];


                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 3, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);

                
                Dong += 1;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "FrmKiemKeKho", "TIEU_DE", Commons.Modules.TypeLanguage), Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true,
                Dong, TCot);


                Dong += 1; 
                string stmp = "";
                stmp = lblKho.Text + " : " + cboKho.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 2, "@", 10, true, true, Dong, 3);

                stmp = lblNgayKK.Text + " : " + cboNgayKK.Text;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong, 4, "@", 10, true, true, Dong, 10);


                Excel.Range title = default(Excel.Range);

                Dong += 3;


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + TDong, TCot);
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                title.Interior.Color = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1).Interior.Color;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                title.Font.Bold = true;
                title.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                title.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                Commons.Modules.MExcel.ExcelEnd(excelApplication, excelWorkbook, excelWorkSheet, false, true, true, true, Excel.XlPaperSize.xlPaperA4, Excel.XlPageOrientation.xlLandscape, 30,
                30, 30, 30, 50, 50, 100);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong - 1, 1);
                title.RowHeight = 15;

                //set width for all columns'
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 1, TDong + Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 25, "@", true, Dong + 1, 2, TDong + Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", true, Dong + 1, 3, TDong + Dong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 4, TDong + Dong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 5, TDong + Dong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 1, 6, TDong + Dong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 5, "@", true, Dong + 1, 7, TDong + Dong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "@", true, Dong + 1, 8, TDong + Dong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "@", true, Dong + 1, 9, TDong + Dong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 9, "@", true, Dong + 1, 10, TDong + Dong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong + 1, 11, TDong + Dong, 11);

                Dong += 1;
                for (int i = 0; i <= TDong - 1; i++)
                {
                    stmp = "=ABS(H" + (Dong + i).ToString() + "-I" + (Dong + i).ToString() + ")";
                    Commons.Modules.MExcel.DinhDang(excelWorkSheet, stmp, Dong + i, 10, "General", 10, true, false, Dong + i, 10);
                }
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, 1, Dong + TDong - 1, TCot);
                title.Borders.LineStyle = 1;
                title.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, 1, 1, Dong + TDong, TCot);

                excelWorkbook.Save();
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);

                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch (Exception ex)
            {
                excelApplication.Visible = true;
                excelApplication.DisplayAlerts = false;
                excelApplication.Quit();
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmrptCTY_DA_CUNG_CAP_VAT_TU", "InKhongThanhCong", Commons.Modules.TypeLanguage) + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;

        }

 
        private void cboNgayKK_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cboNgayKK.EditValue == null)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoNgayKK", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboNgayKK_Click(object sender, EventArgs e)
        {
            if (cboNgayKK.EditValue == null)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoNgayKK", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        System.Windows.Forms.ProgressBar prgBar = new System.Windows.Forms.ProgressBar();
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvChon.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongcoDuLieuXoa", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);

             
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgXoaphieuKK", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Commons.VS.Classes.Catalogue.KIEM_KE_Controller objKiemKeController = new Commons.VS.Classes.Catalogue.KIEM_KE_Controller();
                prgBar = new System.Windows.Forms.ProgressBar();
                tableLayoutPanel1.RowCount = 6;
                tableLayoutPanel1.RowStyles[4].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[4].Height = 20;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
                tableLayoutPanel1.Controls.Add(prgBar);
                tableLayoutPanel1.SetRow(panel1, 5);
                tableLayoutPanel1.SetRow(prgBar, 4);
                tableLayoutPanel1.SetColumn(prgBar, 0);
                tableLayoutPanel1.SetColumnSpan(prgBar, 3);
                prgBar.Visible = true;
                prgBar.Dock = DockStyle.Fill;                
                prgBar.Maximum = 100;
                prgBar.Step = 10;
                prgBar.PerformStep();
                if (objKiemKeController.DELETE_KIEM_KE(int.Parse(this.cboKho.EditValue.ToString()), dtNgay.DateTime))
                {
                    cboKho_EditValueChanged(null, null);                   
                    if (RefreshData(int.Parse(this.cboKho.EditValue.ToString())))
                    {
                        prgBar.PerformStep();
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "DATA_DA_DUOC_REFRESH", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                  
                }
                prgBar.Value = 0;
                prgBar.Dispose();
                tableLayoutPanel1.SetRow(panel1, 4);
                tableLayoutPanel1.RowCount = 5;
                tableLayoutPanel1.RowStyles[4].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[4].Height = 36;
            }
        }


        public bool RefreshData(int MS_KHO)
        {
            DataTable dtTable = new DataTable();
            DateTime NGAY = default(DateTime);
            NGAY = System.DateTime.Parse("01/01/1900");
            SqlConnection objConnection = new SqlConnection(Commons.IConnections.ConnectionString);
            objConnection.Open();
            SqlTransaction objTrans = objConnection.BeginTransaction();
            try
            {
                string Prefix = "QL_" + Commons.Modules.UserName;
                string tableName = Prefix + "_QL_VAT_TU_TANG_GIAM";
                string sql = "IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[" + tableName + "]') AND type in (N'U')) DROP TABLE [" + tableName + "] CREATE TABLE DBO.[" + tableName + "]( [MS_DH_NHAP_PT] [NVARCHAR] (14) NOT NULL, [MS_PT] [NVARCHAR] (25) NOT NULL, [MS_VI_TRI] [INT] NOT NULL, [TANG] [FLOAT] NOT  NULL DEFAULT ((0)), [GIAM] [FLOAT] NOT NULL DEFAULT ((0)) , [ID_KK] [FLOAT] NULL)";
                SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql);
                this.prgBar.PerformStep();

                SqlDataReader dtReader = SqlHelper.ExecuteReader(objTrans, "QL_LOAD_KIEM_KE_LAST", MS_KHO);
                while (dtReader.Read())
                {
                    NGAY = System.DateTime.Parse(dtReader["NGAY"].ToString());
                    break; // TODO: might not be correct. Was : Exit While
                }
                dtReader.Close();
                prgBar.PerformStep();
                //fill data kiem ke vat tu chi tiet
                dtReader = SqlHelper.ExecuteReader(objTrans, "QL_LOAD_PHIEU_KIEM_KE_VAT_TU_CHI_TIET", MS_KHO, NGAY, -1);
                dtTable.Load(dtReader);
                dtReader.Close();
                for (int i = 0; i <= dtTable.Rows.Count - 1; i++)
                {
                    DataRow row = dtTable.Rows[i];
                    sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + row["MS_DH_NHAP_PT"].ToString() + "','" + row["MS_PT"].ToString() + "'," + row["MS_VI_TRI"].ToString() + "," + row["SL_TON_TT"].ToString() + ",0 ," + row["ID_KK"].ToString() + ")";
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql);
                }
                prgBar.PerformStep();

                //FILL DATA FROM DON HANG NHAP VAT TU CHI TIET
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_LIST_DHN_VAT_CHI_TIET_THEO_PHIEU_KIEM_KE", MS_KHO, NGAY);
                while (dtReader.Read())
                {
                    sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + dtReader["MS_DH_NHAP_PT"].ToString() + "','" + dtReader["MS_PT"].ToString() + "'," + dtReader["MS_VI_TRI"].ToString() + "," + dtReader["SL_VT"].ToString() + ",0," + dtReader["ID"].ToString() + ")";
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql);
                }
                dtReader.Close();
                prgBar.PerformStep();

                //FILL DATA FROM DON HANH XUAT VAT TU CHI TIET
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_LIST_DHX_VAT_CHI_TIET_THEO_PHIEU_KIEM_KE", MS_KHO, NGAY);
                while (dtReader.Read())
                {
                    sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + dtReader["MS_DH_NHAP_PT"].ToString() + "','" + dtReader["MS_PT"].ToString() + "'," + dtReader["MS_VI_TRI"].ToString() + ",0," + dtReader["SL_VT"].ToString() + "," + dtReader["ID_XUAT"].ToString() + ")";
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql);

                }
                dtReader.Close();
                prgBar.PerformStep();

                //FILL DATA CHUYEN DI
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_VAT_TU_CHUYEN_DI", MS_KHO, NGAY);
                while (dtReader.Read())
                {
                    sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + dtReader["MS_DH_NHAP_PT"].ToString() + "','" + dtReader["MS_PT"].ToString() + "'," + dtReader["MS_VI_TRI"].ToString() + ",0," + dtReader["SL_VT"].ToString() + "," + dtReader["ID_DC"].ToString() + ")";
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql);
                }
                dtReader.Close();
                prgBar.PerformStep();

                //FILL DATA CHUYEN DEN
                dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_VAT_TU_CHUYEN_DEN", MS_KHO, NGAY);
                while (dtReader.Read())
                {
                    sql = "INSERT INTO " + Prefix + "_QL_VAT_TU_TANG_GIAM VALUES(N'" + dtReader["MS_DH_NHAP_PT"].ToString() + "','" + dtReader["MS_PT"].ToString() + "'," + dtReader["MS_VI_TRI"].ToString() + "," + dtReader["SL_VT"].ToString() + ",0," + dtReader["ID_DC"].ToString() + ")";
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_SEARCH", sql);
                }
                dtReader.Close();
                prgBar.PerformStep();

                //Calculator and Refresh Data
                string QUERY = "SELECT MS_DH_NHAP_PT,MS_PT,MS_VI_TRI ,SUM(TANG)-SUM(GIAM) SL_VT, ID_KK FROM " + Prefix + "_QL_VAT_TU_TANG_GIAM GROUP BY MS_DH_NHAP_PT,MS_PT,MS_VI_TRI , ID_KK";
                dtReader = SqlHelper.ExecuteReader(objTrans, "QL_SEARCH", QUERY);
                DataTable dtTableTang_Giam = new DataTable();
                if (dtReader.HasRows)
                {
                    dtTableTang_Giam.Load(dtReader);
                }
                dtReader.Close();
                for (int i = 0; i <= dtTableTang_Giam.Rows.Count - 1; i++)
                {
                    DataRow dtRow = dtTableTang_Giam.Rows[i];
                    SqlHelper.ExecuteNonQuery(objTrans, "QL_UPDATE_VI_TRI_KHO_VAT_TU", MS_KHO, dtRow["MS_PT"].ToString(), int.Parse(dtRow["MS_VI_TRI"].ToString()), dtRow["MS_DH_NHAP_PT"].ToString(), double.Parse(dtRow["SL_VT"].ToString()), double.Parse(dtRow["ID_KK"].ToString()));
                }
                objTrans.Commit();
                prgBar.PerformStep();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                objTrans.Rollback();
                return false;
            }
            finally
            {
                objConnection.Close();
            }
            return true;
        }


        private void btnXemHinh_Click(object sender, EventArgs e)
        {
            if (this.grvChon.RowCount <= 0)
            {           
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "CHON_VAT_TU_CAN_XEM_HINH", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    IC_PHU_TUNG_Info objPTUNG = this.Load_Phu_Tung(grvChon.GetFocusedDataRow()["MS_PT"].ToString());
                    if (objPTUNG.ANH_PT == null | string.IsNullOrEmpty(objPTUNG.ANH_PT))
                    {
                        XtraMessageBox.Show(objPTUNG.MS_PT + " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "CHUA_CO_DUONG_DAN_HINH", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }
                    System.Diagnostics.Process.Start(objPTUNG.ANH_PT);
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgINVALID_PATH", Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private IC_PHU_TUNG_Info Load_Phu_Tung(string MS_PT)
        {
            IC_PHU_TUNG_Info objPhuTung = Commons.QL.Common.Data.QLBusinessDataController.FillObject<IC_PHU_TUNG_Info>(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "QL_LOAD_PHU_TUNG", MS_PT));
            return objPhuTung;
        }

    }
}