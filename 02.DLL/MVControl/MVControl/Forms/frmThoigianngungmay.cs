using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmThoigianngungmayNEW : Form
    {
        public string MsMay;

        public DateTime NGAY_BD = DateTime.Now;
        public DateTime GIO_BD = DateTime.Now;
        public string MS_NN = "";
        public DateTime NGAY_KT = DateTime.Now;

        public DateTime GIO_KT = DateTime.Now;

        public DateTime NGAY_SX = DateTime.Now;
        public string MS_PHIEU_BAO_TRI;
        public string sNguyenNhanNgungMay;
        public string sGiaiPhapKhacPhuc;

        public frmThoigianngungmayNEW()
        {
            InitializeComponent();
        }
        bool bLock = false, bUnLock = false;
        private void frmThoigianngungmayNEW_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 49))
                bLock = true;
            if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 50))
                bUnLock = true;
            if (!string.IsNullOrEmpty(MsMay))
            {
                if (NGAY_BD < DateTime.Now.AddMonths(-3))
                {
                    dtNgayBDLoc.DateTime = NGAY_BD.AddMonths(-3);
                    dtNgayKTLoc.DateTime = NGAY_BD.AddMonths(1);
                }
                else
                {
                    dtNgayBDLoc.DateTime = DateTime.Now.AddMonths(-3);
                    dtNgayKTLoc.DateTime = DateTime.Now.AddMonths(1);
                }
            }
            else
            {
                dtNgayBDLoc.DateTime = DateTime.Now.AddMonths(-3);
                dtNgayKTLoc.DateTime = DateTime.Now.AddMonths(1);
            }
            EnableControl(false);
            LoadDiaDiem();
            LoadMay();
            LoadCombobox();
            LoadLanNgungMay("-1");
            if (!string.IsNullOrEmpty(MsMay))
            {
                btnAdd_Click(btnAdd, EventArgs.Empty);
                cboMay.EditValue = MsMay;
                dtNgayBD.DateTime = NGAY_BD;
                LoadPhieuBaoTri();
                tGioBD.EditValue = GIO_BD.ToString("HH:mm");
                dtNgayKT.DateTime = NGAY_KT;
                tGioKT.EditValue = GIO_KT.ToString("HH:mm");
                dtNgaySX.DateTime = NGAY_SX;
                if (MS_NN.ToString() != "") cboNguyenNhan.EditValue = int.Parse(MS_NN);
                cboPhieuBaoTri.EditValue = MS_PHIEU_BAO_TRI;
                txtNNCuThe.Text = sNguyenNhanNgungMay;
                txtCachGiaiQuyet.Text = sGiaiPhapKhacPhuc;
                CapNhapNgay();
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);

        }
        //
        private void LoadDiaDiem()
        {
            //System.Data.DataTable dt = new System.Data.DataTable();
            //dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuongTreeList", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            //cboDiaDiem.KeyFieldName = "MS_N_XUONG";
            //cboDiaDiem.ParentFieldName = "MS_CHA";
            //cboDiaDiem.ColumnDisplayName = "TEN_N_XUONG";
            //cboDiaDiem.DataSource = dt;
            //cboDiaDiem.DataBind();
            KiemApp.MLoadCboTreeList(ref cboDiaDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            //DataTable _table = new DataTable();
            //_table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            KiemApp.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
        }

        private void LoadMay()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAY_SEC", Commons.Modules.UserName));
                if (dtTmp.Rows.Count > 0)
                {
                    DataRow dtRow = dtTmp.NewRow();
                    dtRow["MS_LOAI_MAY"] = -1;
                    dtRow["TEN_LOAI_MAY"] = " < ALL > ";
                    dtTmp.Rows.InsertAt(dtRow, 0);
                }
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
            try
            {
                dtTmp = new System.Data.DataTable();
                string str = "SELECT DISTINCT A.MS_MAY,A.MS_MAY + ' - ' + A.TEN_MAY AS TEN_MAY  FROM dbo.MGetMayUserNgay('" + DateTime.Now.ToString("yyyy/MM/dd") + "', '" + Commons.Modules.UserName + "','-1',-1,-1,-1,'-1','-1',0)  A";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                DataRow dtRow = dtTmp.NewRow();
                dtRow["MS_MAY"] = "";
                dtRow["TEN_MAY"] = "";
                dtTmp.Rows.InsertAt(dtRow, 0);
                cboMay.Properties.PopulateColumns();
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMay, dtTmp, "MS_MAY", "TEN_MAY", "");
            }
            catch
            {
            }
        }

        private void LoadPhieuBaoTri()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT DISTINCT MS_PHIEU_BAO_TRI FROM  dbo.PHIEU_BAO_TRI  WHERE  MS_MAY = '" + cboMay.EditValue + "' AND  NGAY_BD_KH >= '" + dtNgayBD.DateTime.ToString("yyyy/MM/dd") + "' UNION SELECT '' AS MS_PHIEU_BAO_TRI  ";
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, query));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPhieuBaoTri, dt, "MS_PHIEU_BAO_TRI", "MS_PHIEU_BAO_TRI", "");
            }
            catch
            {
            }

        }

        private void LoadCombobox()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new DataTable();
                string str = "SELECT STT, ( CASE '" + Commons.Modules.TypeLanguage.ToString() + "' WHEN 0 THEN CA WHEN 1 THEN ISNULL(CA_ANH, CA) END ) + ' (' + CONVERT(NVARCHAR(5),CAST(TU_GIO AS TIME),108) + ' - ' +  CONVERT(NVARCHAR(5),CAST(DEN_GIO AS TIME),108) + ')' AS TEN_CA FROM CA ORDER BY TU_GIO ";
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCa, dt, "STT", "TEN_CA", "");
            }
            catch { }
            try
            {
                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 3, Commons.Modules.UserName));
                dt.Select().AsEnumerable().ToList().ForEach(x => cboNguoiGiaiQuyet.Properties.Items.Add(x["HO_TEN_CONG_NHAN"]));

                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 6, Commons.Modules.UserName));
                dt.Select().AsEnumerable().ToList().ForEach(x => cboTruongCa.Properties.Items.Add(x["HO_TEN_CONG_NHAN"]));

            }
            catch { }
            try
            {
                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguyenNhan, dt, "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN", "");

                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanUserAll", 0, "-1", Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTo, dt, "MS_PB", "TEN_PB", "");
            }
            catch
            {
            }
        }
        private void LoadLanNgungMay(string MS_LAN)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_NGUNG_MAY_SO_LAN", Commons.Modules.UserName, "-1", cboLoaiMay.EditValue, cboDChuyen.EditValue, cboDiaDiem.EditValue, -1, dtNgayBDLoc.DateTime, dtNgayKTLoc.DateTime, chkIsLock.Checked ? 1 : 0));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MS_LAN"] };
                Commons.Modules.SQLString = "0Load";
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdLanNgungMay, grvLanNgungMay, dt, false, false, false, true, true, this.Name);
                Commons.Modules.SQLString = "";
                if (MS_LAN != "-1")
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(MS_LAN));
                    grvLanNgungMay.FocusedRowHandle = grvLanNgungMay.GetRowHandle(index);
                }

                foreach (GridColumn col in grvLanNgungMay.Columns)
                {
                    col.Visible = false;
                }

                grvLanNgungMay.Columns["MS_MAY"].Visible = true;
                grvLanNgungMay.Columns["NGAY"].Visible = false;
                grvLanNgungMay.Columns["NGAY_KT"].Visible = false;
                grvLanNgungMay.Columns["TU_GIO"].Visible = false;
                grvLanNgungMay.Columns["GIO_KT"].Visible = false;
                grvLanNgungMay.Columns["TNGAY_GIO"].Visible = true;
                grvLanNgungMay.Columns["DNGAY_GIO"].Visible = true;
                grvLanNgungMay.Columns["KHONG_DC"].Visible = true;
                grvLanNgungMay.Columns["TONG_TGNM"].Visible = true;
                grvLanNgungMay.Columns["TONG_TGS"].Visible = true;

                grvLanNgungMay.Columns["TNGAY_GIO"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                grvLanNgungMay.Columns["DNGAY_GIO"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                grvLanNgungMay.Columns["TNGAY_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvLanNgungMay.Columns["DNGAY_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvLanNgungMay.Columns["TNGAY_GIO"].BestFit();
                grvLanNgungMay.Columns["DNGAY_GIO"].BestFit();
                grvLanNgungMay.Columns["KHONG_DC"].BestFit();
                grvLanNgungMay.Columns["MS_MAY"].BestFit();
                grvLanNgungMay.Columns["TONG_TGNM"].BestFit();
                grvLanNgungMay.Columns["TONG_TGS"].BestFit();

                grvLanNgungMay.Columns["MS_MAY"].VisibleIndex = 1;
                grvLanNgungMay.Columns["TNGAY_GIO"].VisibleIndex = 2;
                grvLanNgungMay.Columns["DNGAY_GIO"].VisibleIndex = 3;
                grvLanNgungMay.Columns["TONG_TGNM"].VisibleIndex = 4;
                grvLanNgungMay.Columns["TONG_TGS"].VisibleIndex = 5;

                grvLanNgungMay_FocusedRowChanged(null, null);
            }
            catch
            {
            }
        }


        private void cboDiaDiem_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadLanNgungMay("-1");
        }

        private void ShowThoiGianNgung()
        {
            try
            {
                cboMay.EditValue = grvLanNgungMay.GetFocusedDataRow()["MS_MAY"].ToString();
                cboTo.EditValue = int.Parse(string.IsNullOrEmpty(grvLanNgungMay.GetFocusedDataRow()["MS_TO"].ToString()) ? "-1" : grvLanNgungMay.GetFocusedDataRow()["MS_TO"].ToString());
                cboNguyenNhan.EditValue = int.Parse(grvLanNgungMay.GetFocusedDataRow()["MS_NGUYEN_NHAN"] == null ? "-1" : grvLanNgungMay.GetFocusedDataRow()["MS_NGUYEN_NHAN"].ToString());
                try
                {
                    dtNgaySX.DateTime = Convert.ToDateTime(grvLanNgungMay.GetFocusedDataRow()["NGAY_SX"].ToString());
                }
                catch { dtNgaySX.EditValue = ""; }
                dtNgayBD.DateTime = Convert.ToDateTime(grvLanNgungMay.GetFocusedDataRow()["NGAY"].ToString());
                dtNgayKT.DateTime = Convert.ToDateTime(grvLanNgungMay.GetFocusedDataRow()["NGAY_KT"].ToString());
                tGioBD.EditValue = Convert.ToDateTime(grvLanNgungMay.GetFocusedDataRow()["TU_GIO"].ToString()).ToString("HH:mm");
                tGioKT.EditValue = Convert.ToDateTime(grvLanNgungMay.GetFocusedDataRow()["GIO_KT"].ToString()).ToString("HH:mm");
                txtCachGiaiQuyet.Text = grvLanNgungMay.GetFocusedDataRow()["NN_CGQ"].ToString();
                txtHTuong.Text = grvLanNgungMay.GetFocusedDataRow()["HIEN_TUONG"].ToString();
                chkKDChuyen.Checked = bool.Parse(grvLanNgungMay.GetFocusedDataRow()["KHONG_DC"].ToString());
                cboNguoiGiaiQuyet.Text = grvLanNgungMay.GetFocusedDataRow()["NGUOI_GIAI_QUYET"].ToString();
                txtNNCuThe.Text = grvLanNgungMay.GetFocusedDataRow()["NGUYEN_NHAN_CU_THE"].ToString();
                cboTruongCa.Text = grvLanNgungMay.GetFocusedDataRow()["TRUONG_CA"].ToString();

                if (string.IsNullOrEmpty(grvLanNgungMay.GetFocusedDataRow()["CaID"].ToString()))
                    cboCa.EditValue = -1;
                else
                    cboCa.EditValue = Convert.ToInt32(grvLanNgungMay.GetFocusedDataRow()["CaID"].ToString());

                if (grvLanNgungMay.GetFocusedDataRow()["MS_PHIEU_BAO_TRI"].ToString() != "")
                {
                    LoadPhieuBaoTri();
                    cboPhieuBaoTri.EditValue = grvLanNgungMay.GetFocusedDataRow()["MS_PHIEU_BAO_TRI"].ToString();
                }
                else
                { cboPhieuBaoTri.EditValue = ""; }

                try
                {
                    cboTo.EditValue = Convert.ToInt32(grvLanNgungMay.GetFocusedDataRow()["MS_TO"].ToString());
                }
                catch
                {
                    cboTo.EditValue = -1;
                }
            }
            catch (Exception ex)
            {
                cboMay.EditValue = "";
                cboNguyenNhan.EditValue = "-1";
                dtNgaySX.DateTime = DateTime.Now;
                dtNgayBD.DateTime = DateTime.Now;
                dtNgayKT.DateTime = DateTime.Now;
                tGioBD.EditValue = DateTime.Now.ToString("HH:mm");
                tGioKT.EditValue = DateTime.Now.AddHours(1).ToString("HH:mm");
                txtCachGiaiQuyet.Text = "";
                txtHTuong.Text = "";
                chkKDChuyen.Checked = false;
                cboNguoiGiaiQuyet.Text = "";
                txtNNCuThe.Text = "";
                cboTruongCa.Text = "";
                cboCa.EditValue = -1;
                DataTable dt = grdTGChiTiet.DataSource as DataTable;
                try
                {
                    dt.Rows.Clear();
                    cboNguyenNhan.EditValue = -1;
                }
                catch { }
                grdTGChiTiet.DataSource = dt;
                grdPTTheoMay.DataSource = null;
            }
        }
        private void grvLanNgungMay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            ShowThoiGianNgung();
            LoadNgungMayChiTiet();
            LoadBoPhanPhuTung();
        }

        private void dtNgayBDLoc_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadLanNgungMay("-1");
        }

        private void LoadNgungMayChiTiet()
        {
            try
            {
                if (grvLanNgungMay.RowCount == 0) return;
                DataTable dt = new DataTable();
                try
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_NGUNG_MAY_THEO_MAY", grvLanNgungMay.GetFocusedDataRow()["MS_LAN"]));
                }
                catch
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_NGUNG_MAY_THEO_MAY", "-1111"));
                }

                if (dt.Columns.Count > 0)
                {
                    dt.Columns["MS_HE_THONG"].AllowDBNull = true;
                    dt.Columns["MS_N_XUONG"].AllowDBNull = true;
                    dt.Columns["MS_MAY"].AllowDBNull = true;
                    dt.Columns["NGAY"].AllowDBNull = true;
                    dt.Columns["TU_GIO"].AllowDBNull = true;
                    dt.Columns["DEN_NGAY"].AllowDBNull = true;
                    dt.Columns["DEN_GIO"].AllowDBNull = true;
                    dt.Columns["MS_NGUYEN_NHAN"].AllowDBNull = true;
                    dt.Columns["TRUONG_CA"].AllowDBNull = true;
                    dt.Columns["MS_MAY_OLD"].AllowDBNull = true;
                    dt.Columns["NGAY_OLD"].AllowDBNull = true;
                    dt.Columns["TU_GIO_OLD"].AllowDBNull = true;
                    dt.Columns["DEN_NGAY_OLD"].AllowDBNull = true;
                    dt.Columns["DEN_GIO_OLD"].AllowDBNull = true;
                    dt.Columns["MS_LAN_OLD"].AllowDBNull = true;
                }

                Commons.Modules.SQLString = "0Load";
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTGChiTiet, grvTGChiTiet, dt, false, false, false, true, true, this.Name);
                Commons.Modules.SQLString = "";

                RepositoryItemDateEdit dtNgay = new RepositoryItemDateEdit();
                dtNgay.EditFormat.FormatString = "dd/MM/yyyy";
                dtNgay.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                dtNgay.EditMask = "dd/MM/yyyy";
                dtNgay.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
                grvTGChiTiet.Columns["NGAY"].ColumnEdit = dtNgay;
                grvTGChiTiet.Columns["DEN_NGAY"].ColumnEdit = dtNgay;

                grvTGChiTiet.Columns["NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";
                grvTGChiTiet.Columns["DEN_NGAY"].DisplayFormat.FormatString = "dd/MM/yyyy";
                grvTGChiTiet.Columns["NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                grvTGChiTiet.Columns["DEN_NGAY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                RepositoryItemTimeEdit timeEdit = new RepositoryItemTimeEdit();
                timeEdit.EditFormat.FormatString = "HH:mm";
                timeEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                timeEdit.EditMask = "HH:mm";
                timeEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;

                grvTGChiTiet.Columns["TU_GIO"].ColumnEdit = timeEdit;
                grvTGChiTiet.Columns["DEN_GIO"].ColumnEdit = timeEdit;

                RepositoryItemSpinEdit spinEdit = new RepositoryItemSpinEdit();
                spinEdit.IsFloatValue = false;
                spinEdit.MinValue = 0;
                spinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                spinEdit.NullText = "";
                spinEdit.EditFormat.FormatString = "N1";
                spinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;

                grvTGChiTiet.Columns["THOI_GIAN_NGUNG_MAY"].ColumnEdit = spinEdit;
                grvTGChiTiet.Columns["THOI_GIAN_SUA_CHUA"].ColumnEdit = spinEdit;

                grvTGChiTiet.Columns["THOI_GIAN_NGUNG_MAY"].Width = 80;
                grvTGChiTiet.Columns["THOI_GIAN_SUA_CHUA"].Width = 80;

                grvTGChiTiet.Columns["TU_GIO"].Width = 80;
                grvTGChiTiet.Columns["DEN_GIO"].Width = 80;
                grvTGChiTiet.Columns["NGAY"].Width = 100;
                grvTGChiTiet.Columns["DEN_NGAY"].Width = 100;

                grvTGChiTiet.Columns["MS_N_XUONG"].Width = 140;
                grvTGChiTiet.Columns["MS_HE_THONG"].Width = 160;
                grvTGChiTiet.Columns["THOI_GIAN_NGUNG_MAY"].Width = 80;
                grvTGChiTiet.Columns["THOI_GIAN_SUA_CHUA"].Width = 80;
                grvTGChiTiet.Columns["MS_N_XUONG"].Width = 140;
                grvTGChiTiet.Columns["MS_HE_THONG"].Width = 160;
                grvTGChiTiet.Columns["MS_N_XUONG"].Width = 140;
                grvTGChiTiet.Columns["MS_HE_THONG"].Width = 160;
                grvTGChiTiet.Columns["MS_NGUYEN_NHAN"].Width = 150;
                grvTGChiTiet.Columns["MS_N_XUONG"].Width = 150;
                grvTGChiTiet.Columns["MS_HE_THONG"].Width = 150;
                grvTGChiTiet.Columns["NN_CGQ"].Width = 150;
                grvTGChiTiet.Columns["HIEN_TUONG"].Width = 150;
                grvTGChiTiet.Columns["NGUYEN_NHAN_CU_THE"].Width = 150;
                grvTGChiTiet.Columns["GHI_CHU"].Width = 150;

                if (grvTGChiTiet.Columns["MS_MAY_OLD"].Visible == false) return;

                DataTable dtCol = new DataTable();
                dtCol.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_CA", Commons.Modules.TypeLanguage));
                RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
                cbo.DataSource = dtCol;
                cbo.DisplayMember = "CA";
                cbo.ValueMember = "STT";
                cbo.PopulateColumns();
                foreach (LookUpColumnInfo col in cbo.Columns) { col.Visible = false; }
                cbo.Columns["CA"].Visible = true;
                cbo.Columns["CA"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "CA", Commons.Modules.TypeLanguage);
                grvTGChiTiet.Columns["CaID"].ColumnEdit = cbo;



                dtCol = new DataTable();
                cbo = new RepositoryItemLookUpEdit();
                dtCol.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"));
                cbo.DataSource = dtCol;
                cbo.DisplayMember = "TEN_NGUYEN_NHAN";
                cbo.ValueMember = "MS_NGUYEN_NHAN";
                cbo.PopulateColumns();
                cbo.Columns["MS_NGUYEN_NHAN"].Visible = false;
                cbo.Columns["TEN_NGUYEN_NHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_NGUYEN_NHAN", Commons.Modules.TypeLanguage);
                grvTGChiTiet.Columns["MS_NGUYEN_NHAN"].ColumnEdit = cbo;


                dtCol = new DataTable();
                cbo = new RepositoryItemLookUpEdit();
                dtCol.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_N_XUONG,TEN_N_XUONG FROM NHA_XUONG"));
                cbo.DataSource = dtCol;
                cbo.DisplayMember = "TEN_N_XUONG";
                cbo.ValueMember = "MS_N_XUONG";
                cbo.PopulateColumns();
                cbo.Columns["MS_N_XUONG"].Visible = false;
                cbo.Columns["TEN_N_XUONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_N_XUONG", Commons.Modules.TypeLanguage);
                grvTGChiTiet.Columns["MS_N_XUONG"].ColumnEdit = cbo;


                dtCol = new DataTable();
                cbo = new RepositoryItemLookUpEdit();
                dtCol.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_HE_THONG, TEN_HE_THONG FROM DBO.HE_THONG ORDER BY TEN_HE_THONG"));


                DataRow dr = dtCol.NewRow();
                dr["MS_HE_THONG"] = 0;
                dr["TEN_HE_THONG"] = "";
                dtCol.Rows.InsertAt(dr, 0);

                cbo.DataSource = dtCol;
                cbo.DisplayMember = "TEN_HE_THONG";
                cbo.ValueMember = "MS_HE_THONG";
                cbo.PopulateColumns();
                cbo.Columns["MS_HE_THONG"].Visible = false;
                cbo.Columns["TEN_HE_THONG"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TEN_HE_THONG", Commons.Modules.TypeLanguage);
                grvTGChiTiet.Columns["MS_HE_THONG"].ColumnEdit = cbo;

                grvTGChiTiet.Columns["MS_MAY_OLD"].Visible = false;
                grvTGChiTiet.Columns["NGAY_OLD"].Visible = false;
                grvTGChiTiet.Columns["TU_GIO_OLD"].Visible = false;
                grvTGChiTiet.Columns["DEN_NGAY_OLD"].Visible = false;
                grvTGChiTiet.Columns["DEN_GIO_OLD"].Visible = false;
                grvTGChiTiet.Columns["MS_LAN_OLD"].Visible = false;
                grvTGChiTiet.Columns["MS_MAY"].Visible = false;
            }
            catch
            {
            }

        }
        private void LoadBoPhanPhuTung()
        {
            try
            {
                DataTable dt = new DataTable();

                try
                {
                    dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhutungTheoMay", grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString(), grvLanNgungMay.GetFocusedDataRow()["MS_MAY"].ToString()));
                }
                catch
                {
                    dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhutungTheoMay", "", ""));
                }
                dt.Columns["MS_BO_PHAN"].ReadOnly = true;
                dt.Columns["TEN_BO_PHAN"].ReadOnly = true;
                dt.Columns["MS_PT"].ReadOnly = true;
                dt.Columns["TEN_PT"].ReadOnly = true;
                dt.Columns["MS_VI_TRI_PT"].ReadOnly = true;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTheoMay, grvPTTheoMay, dt, false, false, true, true, true, this.Name);
                grvPTTheoMay.Columns["MS_LAN"].Visible = false;
                grvPTTheoMay.Columns["MS_MAY"].Visible = false;
                grvPTTheoMay.Columns["STT"].Visible = false;
                grvPTTheoMay.Columns["MS_PT"].VisibleIndex = 5;
                grvPTTheoMay.Columns["MS_VI_TRI_PT"].VisibleIndex = 6;
                grvPTTheoMay.Columns["TEN_PT"].VisibleIndex = 7;
                grvPTTheoMay.Columns["DEL"].Visible = false;
                grvPTTheoMay.Columns["MS_BO_PHAN"].Width = 150;
                grvPTTheoMay.Columns["TEN_BO_PHAN"].Width = 250;
                grvPTTheoMay.Columns["MS_PT"].Width = 155;
                grvPTTheoMay.Columns["TEN_PT"].Width = 250;
                grvPTTheoMay.Columns["MS_VI_TRI_PT"].Width = 130;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, this.Name, Commons.Modules.TypeLanguage));
            }
        }
        private void EnableControl(bool flag)
        {
            txtCachGiaiQuyet.Properties.ReadOnly = !flag;
            txtHTuong.Properties.ReadOnly = !flag;
            chkKDChuyen.Properties.ReadOnly = !flag;
            cboNguoiGiaiQuyet.Properties.ReadOnly = !flag;
            txtNNCuThe.Properties.ReadOnly = !flag;
            gbLanngungmay.Enabled = !flag;
            cboTruongCa.Properties.ReadOnly = !flag;
            cboCa.Properties.ReadOnly = !flag;
            cboMay.Enabled = flag;
            cboNguyenNhan.Enabled = flag;
            cboTo.Properties.ReadOnly = !flag;
            cboPhieuBaoTri.Enabled = flag;
            dtNgayBD.Properties.ReadOnly = !flag;
            dtNgayKT.Properties.ReadOnly = !flag;
            tGioBD.Properties.ReadOnly = !flag;
            tGioKT.Properties.ReadOnly = !flag;
            dtNgaySX.Properties.ReadOnly = !flag;
        }

        private void VisibleControl(bool flag, bool xoa)
        {
            btnAdd.Visible = flag;
            btnAddPT.Visible = flag;
            btnCopy.Visible = flag;
            btnEdit.Visible = flag;
            btnThoat.Visible = flag;
            btnXoa.Visible = flag;
            btnCapNhapTG.Visible = xoa ? flag : !flag;
            btnKhongghi.Visible = xoa ? flag : !flag;
            btnSave.Visible = xoa ? flag : !flag;
            btnTroVe.Visible = xoa ? flag : flag;
            chkIsLock.Visible = flag;
            btnXoaBoPhan.Visible = xoa;
            btnXoaCTiet.Visible = xoa;
            btnXoaLanNgungMay.Visible = xoa;
            btnTroVe.Visible = xoa;
            if (chkIsLock.Checked)
            {
                btnLock.Visible = false;
                btnUnLock.Visible = true;
            }
            else
            {
                btnLock.Visible = true;
                btnUnLock.Visible = false;

            }
        }

        private void VisibleXoa(bool flag)
        {
            btnXoa.Visible = flag;
            btnXoaBoPhan.Visible = !flag;
            btnXoaCTiet.Visible = !flag;
            btnXoaLanNgungMay.Visible = !flag;
            btnTroVe.Visible = !flag;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grvLanNgungMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            grvLanNgungMay.AddNewRow();
            grvLanNgungMay.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            grvTGChiTiet.OptionsBehavior.Editable = true;
            bThem = true;
            VisibleControl(false, false);
            EnableControl(true);
            gbLanngungmay.Enabled = false;

            DateTime Hdate = DateTime.ParseExact("01/" + DateTime.Now.ToString("MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
            string ID = (string)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "sp_get_id", "LAN", Hdate);
            grvLanNgungMay.SetFocusedRowCellValue("MS_LAN", ID);
            grvLanNgungMay.SetFocusedRowCellValue("TNGAY_GIO", Convert.ToDateTime(dtNgayBD.DateTime.ToString("yyyy/MM/dd") + " " + tGioBD.Text).ToString("dd/MM/yyyy HH:mm"));
            grvLanNgungMay.SetFocusedRowCellValue("DNGAY_GIO", Convert.ToDateTime(dtNgayKT.DateTime.ToString("yyyy/MM/dd") + " " + tGioKT.Text).ToString("dd/MM/yyyy HH:mm"));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grvLanNgungMay.RowCount == 0) return;
            VisibleControl(false, false);
            EnableControl(true);
            gbLanngungmay.Enabled = false;
            grvTGChiTiet.OptionsBehavior.Editable = true;
            cboMay.Enabled = false;
            CreateMenuThem1Dong(grdTGChiTiet);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            VisibleControl(false, true);
            VisibleXoa(false);
        }

        private bool bThem = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sStr = null;
            string sBTCT = null;
            sBTCT = "TGNMCT" + Commons.Modules.UserName;
            string sBTLan = "TGNMLAN" + Commons.Modules.UserName;
            string sBTCTiet = "TGNMCT" + Commons.Modules.UserName;
            try
            {
                if (string.IsNullOrEmpty(cboMay.Text) || cboMay.Equals(DBNull.Value))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "MsgMAYNull", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMay.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cboNguyenNhan.Text) || cboNguyenNhan.Equals(DBNull.Value))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "MsgNguyenNhanNull", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboNguyenNhan.Focus();
                    return;
                }
                try
                {
                    string value = "";
                    try
                    {
                        value = cboPhieuBaoTri.EditValue.ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    if (string.IsNullOrEmpty(value) & !string.IsNullOrEmpty(cboPhieuBaoTri.EditValue.ToString()))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "MsgPhieuBaoTri", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {
                }
                DateTime ngay = dtNgayBD.DateTime;
                DateTime gio = Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString());
                DateTime NgayKT = dtNgayKT.DateTime;
                DateTime GioKT = Convert.ToDateTime("1900/01/01 " + tGioKT.Text.ToString());
                DateTime NgaySX = dtNgaySX.DateTime;

                ngay = new DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0);
                NgayKT = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0);
                string msMay = cboMay.EditValue.ToString();
                string LoaiNM = cboNguyenNhan.EditValue.ToString();
                string PhieuBaoTri = "";
                try
                {
                    PhieuBaoTri = cboPhieuBaoTri.EditValue.ToString();
                }
                catch (Exception ex)
                {
                }

                string CA = "-1";
                try
                {
                    CA = cboCa.EditValue.ToString();
                }
                catch (Exception ex)
                {
                }


                string nguoiGQ = cboNguoiGiaiQuyet.Text.Trim();
                string nguyennhan = txtCachGiaiQuyet.Text.Trim();
                string hientuong = txtHTuong.Text.Trim();
                string NNCuThe = txtNNCuThe.Text.Trim();


                if (grvTGChiTiet.RowCount == 0)
                {

                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "MsgThoigianngungmaynull", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    grvTGChiTiet.Columns["NGAY"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    grvTGChiTiet.Columns["TU_GIO"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }
                catch (Exception ex)
                {
                }


                //Kiểm hợp lệ chi tiết
                for (int i = 0; i < grvTGChiTiet.RowCount; i++)
                {
                    DateTime vtungay = Convert.ToDateTime(grvTGChiTiet.GetDataRow(i)["NGAY"].ToString());
                    DateTime vdenngay = Convert.ToDateTime(grvTGChiTiet.GetDataRow(i)["DEN_NGAY"].ToString());
                    DateTime vtugio = Convert.ToDateTime(grvTGChiTiet.GetDataRow(i)["TU_GIO"].ToString());
                    DateTime vdengio = Convert.ToDateTime(grvTGChiTiet.GetDataRow(i)["DEN_GIO"].ToString());
                    DateTime vngaytruoc = ngay;
                    DateTime vgiotruoc = gio;

                    if (string.IsNullOrEmpty(grvTGChiTiet.GetDataRow(i)["MS_HE_THONG"].ToString()) | grvTGChiTiet.GetDataRow(i)["MS_HE_THONG"].ToString() == "0")
                    {

                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "ChuaNhapHThong", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grvTGChiTiet.FocusedRowHandle = i;
                        grvTGChiTiet.FocusedColumn = grvTGChiTiet.Columns["MS_HE_THONG"];
                        return;
                    }

                    if (string.IsNullOrEmpty(grvTGChiTiet.GetDataRow(i)["MS_N_XUONG"].ToString()))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "ChuaNhapNhaXuong", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        grvTGChiTiet.FocusedRowHandle = i;
                        grvTGChiTiet.FocusedColumn = grvTGChiTiet.Columns["MS_N_XUONG"];
                        return;
                    }

                    if (string.IsNullOrEmpty(grvTGChiTiet.GetDataRow(i)["MS_NGUYEN_NHAN"].ToString()))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "ChuaNhapMS_NNHAN", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        grvTGChiTiet.FocusedRowHandle = i;
                        grvTGChiTiet.FocusedColumn = grvTGChiTiet.Columns["MS_NGUYEN_NHAN"];
                        return;
                    }

                    if (i > 0)
                    {
                        vngaytruoc = DateTime.Parse(grvTGChiTiet.GetDataRow(i - 1)["DEN_NGAY"].ToString());
                        vgiotruoc = DateTime.Parse(grvTGChiTiet.GetDataRow(i - 1)["DEN_GIO"].ToString());
                        vngaytruoc = new DateTime(vngaytruoc.Year, vngaytruoc.Month, vngaytruoc.Day, vgiotruoc.Hour, vgiotruoc.Minute, 0);
                    }

                    vtungay = new DateTime(vtungay.Year, vtungay.Month, vtungay.Day, vtugio.Hour, vtugio.Minute, 0);
                    vdenngay = new DateTime(vdenngay.Year, vdenngay.Month, vdenngay.Day, vdengio.Hour, vdengio.Minute, 0);

                    if (vtungay > vdenngay)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "MsgTungayphainhohondenngay", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (vtungay.Date == vdenngay.Date)
                        {
                            grvTGChiTiet.FocusedRowHandle = i;
                            grvTGChiTiet.FocusedColumn = grvTGChiTiet.Columns["TU_GIO"];
                            grvTGChiTiet.FocusedColumn = grvTGChiTiet.Columns["DEN_GIO"];
                        }
                        else
                        {
                            grvTGChiTiet.FocusedRowHandle = i;
                        }
                        return;
                    }

                    int stime = (vdenngay - vtungay).Days * 24 * 60 + (vdenngay - vtungay).Hours * 60 + (vdenngay - vtungay).Minutes;
                    if (stime <= 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "MsgTungayphainhohondenngay", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if ((vtungay.Date == vdenngay.Date))
                        {
                            grvTGChiTiet.FocusedRowHandle = i;
                            grvTGChiTiet.FocusedColumn = grvTGChiTiet.Columns["TU_GIO"];
                            grvTGChiTiet.FocusedColumn = grvTGChiTiet.Columns["DEN_GIO"];
                        }
                        else
                        {
                            grvTGChiTiet.FocusedRowHandle = i;
                        }
                        return;
                    }
                    if (stime > 1440)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "MsgThoigianphainhohon24h", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grvTGChiTiet.FocusedRowHandle = i;
                        return;
                    }

                    for (int j = 0; j < grvTGChiTiet.RowCount; j++)
                    {
                        DateTime dtungay = DateTime.Parse(grvTGChiTiet.GetDataRow(j)["NGAY"].ToString());
                        DateTime ddenngay = DateTime.Parse(grvTGChiTiet.GetDataRow(j)["DEN_NGAY"].ToString());
                        DateTime dtugio = DateTime.Parse(grvTGChiTiet.GetDataRow(j)["TU_GIO"].ToString());
                        DateTime ddengio = DateTime.Parse(grvTGChiTiet.GetDataRow(j)["DEN_GIO"].ToString());
                        dtungay = new DateTime(dtungay.Year, dtungay.Month, dtungay.Day, dtugio.Hour, dtugio.Minute, 0);
                        ddenngay = new DateTime(ddenngay.Year, ddenngay.Month, ddenngay.Day, ddengio.Hour, ddengio.Minute, 0);
                        if (i == j)
                        {
                            break;
                        }
                        else
                        {
                            if (vdenngay <= dtungay || vtungay >= ddenngay)
                            {
                            }
                            else
                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "msgMaydangdungtaithoidiemnay", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grvTGChiTiet.FocusedRowHandle = i == 0 ? 0 : i;

                                return;
                            }
                        }
                    }
                    DataTable kiemtralan = new DataTable();
                    kiemtralan = new System.Data.DataTable();

                    if (bThem == false)
                    {

                        kiemtralan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "KIEM_TRA_TGNM", msMay, grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString()));
                    }
                    else
                    {
                        kiemtralan.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "KIEM_TRA_TGNM", msMay, "-1"));
                    }

                    if (kiemtralan.Rows.Count > 0)
                    {
                        foreach (DataRow row in kiemtralan.Rows)
                        {
                            DateTime dtungay = DateTime.Parse(row["NGAY"].ToString());
                            DateTime ddenngay = DateTime.Parse(row["DEN_NGAY"].ToString());
                            DateTime dtugio = DateTime.Parse(row["TU_GIO"].ToString());
                            DateTime ddengio = DateTime.Parse(row["DEN_GIO"].ToString());
                            dtungay = new DateTime(dtungay.Year, dtungay.Month, dtungay.Day, dtugio.Hour, dtugio.Minute, 0);
                            ddenngay = new DateTime(ddenngay.Year, ddenngay.Month, ddenngay.Day, ddengio.Hour, ddengio.Minute, 0);

                            if (vdenngay <= dtungay | vtungay >= ddenngay)
                            {
                            }
                            else
                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "msgMaydangdungtaithoidiemnay", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                grvTGChiTiet.FocusedRowHandle = i;
                                return;
                            }
                        }
                    }
                }

                //---------------Kiểm min max time chi tiết so với time cha

                DateTime tNgayChiTietMin = DateTime.Parse(grvTGChiTiet.GetDataRow(0)["NGAY"].ToString());
                DateTime tGioChiTietMin = DateTime.Parse(grvTGChiTiet.GetDataRow(0)["TU_GIO"].ToString());
                DateTime dNgayChiTietMax = DateTime.Parse(grvTGChiTiet.GetDataRow(grvTGChiTiet.RowCount - 1)["DEN_NGAY"].ToString());
                DateTime dGioChiTietMax = DateTime.Parse(grvTGChiTiet.GetDataRow(grvTGChiTiet.RowCount - 1)["DEN_GIO"].ToString());

                tNgayChiTietMin = new DateTime(tNgayChiTietMin.Year, tNgayChiTietMin.Month, tNgayChiTietMin.Day, tGioChiTietMin.Hour, tGioChiTietMin.Minute, 0);
                dNgayChiTietMax = new DateTime(dNgayChiTietMax.Year, dNgayChiTietMax.Month, dNgayChiTietMax.Day, dGioChiTietMax.Hour, dGioChiTietMax.Minute, 0);


                DateTime tNgayCha = new DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0);
                DateTime dNgayCha = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0);
                //Kiểm ngày giờ min của chi tiết so với ngày giờ bắt đầu của bảng cha

                int count = 0;

                if (tNgayCha != tNgayChiTietMin)
                {
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "msgNgayChaMinKhacNgayChiTiet", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        count = count + 1;
                    }
                    else
                    {
                        return;
                    }
                }


                if (count == 0)
                {
                    if (dNgayCha != dNgayChiTietMax)
                    {
                        if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "msgNgayChaMinKhacNgayChiTiet", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            count = count + 1;
                        }
                        else
                        {
                            return;
                        }
                    }
                }


                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTLan, (DataTable)grdTGChiTiet.DataSource, "");
                SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
                if (conn.State != ConnectionState.Open) conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string tlan = "";
                    string sqlLan = "SELECT MS_LAN FROM THOI_GIAN_NGUNG_MAY_SO_LAN WHERE MS_MAY=N'" + msMay + "' AND NGAY='" + ngay.ToString("MM/dd/yyyy") + "' AND TU_GIO='" + gio.ToString("hh:mm") + "'";
                    tlan = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sqlLan).ToString();
                    if (tlan != "-1" & !string.IsNullOrEmpty(tlan))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "Msgthietbinaydangduocsua", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cboMay.Focus();
                        return;
                    }

                    switch (bThem)
                    {
                        case true:
                            int result = 0;

                            if (!string.IsNullOrEmpty(grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString()))
                            {
                                result = SqlHelper.ExecuteNonQuery(trans, "AddTHOI_GIAN_NGUNG_MAY_LAN", grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString(), msMay, tNgayChiTietMin.ToShortDateString(), tGioChiTietMin.ToShortTimeString(), nguoiGQ, nguyennhan, hientuong, NNCuThe,
                                dNgayChiTietMax.ToShortDateString(), dGioChiTietMax.ToShortTimeString(), NgaySX.ToShortDateString(), cboTruongCa.Text.Trim(), Convert.ToInt32(CA), LoaiNM, PhieuBaoTri, chkKDChuyen.Checked, cboTo.Text == "" ? null : cboTo.EditValue);
                                if (result > 0)
                                {
                                    if (!string.IsNullOrEmpty(grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString()))
                                    {
                                        for (int i = 0; i <= grvTGChiTiet.RowCount - 1; i++)
                                        {
                                            DateTime vtungay = DateTime.Parse(grvTGChiTiet.GetDataRow(i)["NGAY"].ToString());
                                            DateTime vdenngay = DateTime.Parse(grvTGChiTiet.GetDataRow(i)["DEN_NGAY"].ToString());
                                            DateTime vtugio = DateTime.Parse(grvTGChiTiet.GetDataRow(i)["TU_GIO"].ToString());
                                            DateTime vdengio = DateTime.Parse(grvTGChiTiet.GetDataRow(i)["DEN_GIO"].ToString());
                                            string daychuyen = grvTGChiTiet.GetDataRow(i)["MS_HE_THONG"].ToString();
                                            string hethong = grvTGChiTiet.GetDataRow(i)["MS_N_XUONG"].ToString();
                                            string msNguyenNhan = grvTGChiTiet.GetDataRow(i)["MS_NGUYEN_NHAN"].ToString();

                                            string vghichu = null;
                                            try
                                            {
                                                vghichu = grvTGChiTiet.GetDataRow(i)["GHI_CHU"].ToString();
                                            }
                                            catch (Exception ex)
                                            {
                                                vghichu = "";
                                            }
                                            string vthoigianngungmay = grvTGChiTiet.GetDataRow(i)["THOI_GIAN_NGUNG_MAY"].ToString();
                                            string vthoigiansua = grvTGChiTiet.GetDataRow(i)["THOI_GIAN_SUA_CHUA"].ToString();
                                            int CA1 = -1;
                                            try
                                            {
                                                CA1 = string.IsNullOrEmpty(grvTGChiTiet.GetDataRow(i)["CaID"].ToString()) ? -1 : Convert.ToInt32(grvTGChiTiet.GetDataRow(i)["CaID"].ToString());

                                            }
                                            catch (Exception ex)
                                            {
                                            }

                                            result = SqlHelper.ExecuteNonQuery(trans, "AddTHOI_GIAN_NGUNG_MAY_THEO_LAN", msMay, grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString(), vtungay.ToShortDateString(), vtugio.ToShortTimeString(), vdenngay.ToShortDateString(), vdengio.ToShortTimeString(), msNguyenNhan, vghichu,
                                            daychuyen, vthoigianngungmay, hethong, vthoigiansua, grvTGChiTiet.GetDataRow(i)["NN_CGQ"].ToString(), grvTGChiTiet.GetDataRow(i)["HIEN_TUONG"].ToString(), grvTGChiTiet.GetDataRow(i)["NGUYEN_NHAN_CU_THE"].ToString(), grvTGChiTiet.GetDataRow(i)["NGUOI_GIAI_QUYET"].ToString(), grvTGChiTiet.GetDataRow(i)["TRUONG_CA"].ToString(), CA1);
                                        }
                                    }
                                }
                                trans.Commit();
                            }
                            break; // TODO: might not be correct. Was : Exit Select


                        case false:
                            result = 0;
                            result = SqlHelper.ExecuteNonQuery(trans, "UpdateTHOI_GIAN_NGUNG_MAY_LAN", msMay, grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString(), tNgayChiTietMin.ToShortDateString(), tGioChiTietMin.ToShortTimeString(), nguoiGQ, nguyennhan, hientuong, NNCuThe,
                                                    dNgayChiTietMax.ToShortDateString(), dGioChiTietMax.ToShortTimeString(), NgaySX.ToShortDateString(), cboTruongCa.Text, cboCa.EditValue == null ? -1 : Convert.ToInt32(cboCa.EditValue), PhieuBaoTri, LoaiNM, chkKDChuyen.Checked, cboTo.Text == "" ? null : cboTo.EditValue);

                            //@MS_NGUYEN_NHAN INT,
                            //@KHONG_DC BIT


                            if (result > 0)
                            {
                                if (!string.IsNullOrEmpty(grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString()))
                                {
                                    sStr = "DELETE THOI_GIAN_NGUNG_MAY WHERE MS_LAN = '" + grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString() + "'";
                                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sStr);
                                }

                                sStr = " INSERT INTO THOI_GIAN_NGUNG_MAY (MS_MAY,NGAY,TU_GIO,DEN_NGAY,DEN_GIO,MS_NGUYEN_NHAN, " + " GHI_CHU,MS_HE_THONG,  " + " THOI_GIAN_SUA_CHUA,MS_N_XUONG,MS_LAN, THOI_GIAN_SUA,HIEN_TUONG, NGUYEN_NHAN, NGUYEN_NHAN_CU_THE, NGUOI_GIAI_QUYET, TRUONG_CA, CaID) " + " SELECT '" + msMay + "' AS  MS_MAY,NGAY,TU_GIO,DEN_NGAY,DEN_GIO, MS_NGUYEN_NHAN, " + " GHI_CHU,MS_HE_THONG,  " + " THOI_GIAN_NGUNG_MAY,MS_N_XUONG, '" + grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString() + "' AS MS_LAN, THOI_GIAN_SUA_CHUA,HIEN_TUONG, NN_CGQ, NGUYEN_NHAN_CU_THE, NGUOI_GIAI_QUYET, TRUONG_CA, CaID FROM " + sBTLan;
                                try
                                {
                                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sStr);
                                }
                                catch (Exception ex)
                                {
                                }

                            }
                            trans.Commit();
                            break;
                    }
                    Commons.Modules.ObjSystems.XoaTable(sBTLan);
                }
                catch (Exception ex2)
                {
                    try
                    {
                        trans.Rollback();
                    }
                    catch (Exception ex)
                    {
                    }
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "MsgKhongtheluu", Commons.Modules.TypeLanguage) + " - " + ex2.Message, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Commons.Modules.ObjSystems.XoaTable(sBTCT);
                    Commons.Modules.ObjSystems.XoaTable(sBTLan);
                }
            }
            catch (Exception ex1)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "MsgKhongtheluu", Commons.Modules.TypeLanguage) + " - " + ex1.Message, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Commons.Modules.ObjSystems.XoaTable(sBTCT);
                Commons.Modules.ObjSystems.XoaTable(sBTLan);
                return;
            }
            string mslan = grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString();

            Commons.Modules.ObjSystems.XoaTable(sBTCT); //
            Commons.Modules.ObjSystems.XoaTable(sBTLan);

            EnableControl(false);
            VisibleControl(true, false);
            gbLanngungmay.Enabled = true;

            grvLanNgungMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            grvLanNgungMay.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grvLanNgungMay.OptionsBehavior.Editable = false;


            grvTGChiTiet.Columns["NGAY"].SortOrder = DevExpress.Data.ColumnSortOrder.None;
            grvTGChiTiet.Columns["TU_GIO"].SortOrder = DevExpress.Data.ColumnSortOrder.None;
            //int focus = ((DataTable)grdLanNgungMay.DataSource).Rows.IndexOf(((DataTable)grdLanNgungMay.DataSource).Rows.Find(mslan));
            if (bThem)
            {
                grvLanNgungMay.DeleteRow(grvLanNgungMay.FocusedRowHandle);
            }
            LoadLanNgungMay(mslan);
            grvTGChiTiet.OptionsBehavior.Editable = false;
            bThem = false;
            BarManager.Dispose();
        }

        private void btnKhongghi_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            VisibleControl(true, false);
            gbLanngungmay.Enabled = true;
            if (bThem)
            {
                grvLanNgungMay.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                grvLanNgungMay.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                grvLanNgungMay.OptionsBehavior.Editable = false;
                grvLanNgungMay.DeleteRow(grvLanNgungMay.FocusedRowHandle);
            }
            grvTGChiTiet.OptionsBehavior.Editable = false;
            bThem = false;
            LoadLanNgungMay("-1");
            BarManager.Dispose();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            VisibleControl(true, false);
        }
        bool bThemBP = false;
        private void btnAddPT_Click(object sender, EventArgs e)
        {
            if (grvLanNgungMay.RowCount > 0)
            {
                pnBoPhan.Visible = true;
                pnChiTiet.Visible = false;
                tableLayoutPanel3.Enabled = false;
                fChuaLuu = true;
                grdTGChiTiet.Enabled = false;
                bThemBP = true;
                btnChonPT_Click(btnChonPT, null);
            }
            else
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoMay", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGhi1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            SqlTransaction tran = null;
            if (bThemBP == true & dtBP.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dtBP.Rows)
                    {
                        if ((row.RowState != DataRowState.Deleted))
                        {
                            tran = sql.BeginTransaction();
                            SqlHelper.ExecuteNonQuery(tran, "spInsertThoiGianNgungMayBoPhanTheoMay", grvLanNgungMay.GetFocusedDataRow()["MS_MAY"].ToString(), grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString(), row["STT"], row["MS_BO_PHAN"], row["MS_PT"], row["MS_VI_TRI_PT"], row["DEL"]);
                            tran.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    fChuaLuu = false;
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgThemBPLoi", Commons.Modules.TypeLanguage) + Environment.NewLine + ex.Message.ToString(), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            fChuaLuu = true;
            pnBoPhan.Visible = false;
            pnChiTiet.Visible = true;
            grdTGChiTiet.Enabled = true;
            tableLayoutPanel3.Enabled = true;
            bThemBP = false;
            LoadBoPhanPhuTung();
        }

        private void btnKhongGhi1_Click(object sender, EventArgs e)
        {


            grdTGChiTiet.Enabled = true;
            tableLayoutPanel3.Enabled = true;
            LoadBoPhanPhuTung();

            bThemBP = false;
            pnBoPhan.Visible = false;
            pnChiTiet.Visible = true;
        }
        DataTable dtBP = new DataTable();
        string sBTT = "ChonPhuTungChoMay" + Commons.Modules.UserName;
        bool fChuaLuu = false;
        string sBT = "ChonBoPhanChoMay" + Commons.Modules.UserName;
        private void btnChonPT_Click(object sender, EventArgs e)
        {

            try
            {
                Commons.Modules.ObjSystems.XoaTable(sBTT);
            }
            catch
            {
            }

            try
            {
                if (fChuaLuu == false)
                {
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTT, dtBP, "");

                }
                else
                {
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTT, (DataTable)grdPTTheoMay.DataSource, "");
                }

                VietShape.frmChonPTTuBoPhan frm = new VietShape.frmChonPTTuBoPhan();
                frm.MS_MAY = grvLanNgungMay.GetFocusedDataRow()["MS_MAY"].ToString();
                frm.StartPosition = FormStartPosition.CenterParent;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.dtTTPT1.Rows.Count < 0)
                    {
                        return;
                    }
                    fChuaLuu = false;


                    dtBP = new DataTable();
                    dtBP = frm.dtTTPT1;
                    fChuaLuu = false;
                    frm.dtTTPT1.DefaultView.RowFilter = "DEL = 0";
                    frm.dtTTPT1 = frm.dtTTPT1.DefaultView.ToTable();

                    Commons.Modules.ObjSystems.XoaTable(sBTT);
                    grdPTTheoMay.DataSource = null;
                    grdPTTheoMay.DataSource = frm.dtTTPT1;

                    grvPTTheoMay.Columns["MS_LAN"].Visible = false;
                    grvPTTheoMay.Columns["MS_MAY"].Visible = false;
                    grvPTTheoMay.Columns["STT"].Visible = false;

                    grvPTTheoMay.Columns["MS_PT"].VisibleIndex = 5;
                    grvPTTheoMay.Columns["MS_VI_TRI_PT"].VisibleIndex = 6;
                    grvPTTheoMay.Columns["TEN_PT"].VisibleIndex = 7;

                    grvPTTheoMay.Columns["DEL"].Visible = false;
                    grvPTTheoMay.Columns["MS_BO_PHAN"].Width = 150;
                    grvPTTheoMay.Columns["TEN_BO_PHAN"].Width = 250;
                    grvPTTheoMay.Columns["MS_PT"].Width = 155;
                    grvPTTheoMay.Columns["TEN_PT"].Width = 250;
                    grvPTTheoMay.Columns["MS_VI_TRI_PT"].Width = 130;
                }
                else
                {
                    try
                    {
                        Commons.Modules.ObjSystems.XoaTable(sBT);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Commons.Modules.ObjSystems.XoaTable(sBTT);
                XtraMessageBox.Show(ex.Message, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, this.Name, Commons.Modules.TypeLanguage));
            }
        }

        private void cboMay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                if (btnSave.Visible)
                {
                    LoadPhieuBaoTri();
                    grvTGChiTiet.SetFocusedRowCellValue("MS_MAY", cboMay.EditValue.ToString());
                    if (string.IsNullOrEmpty(cboMay.SelectedText))
                    {
                        for (int i = 0; i <= grvTGChiTiet.RowCount - 1; i++)
                        {
                            grvTGChiTiet.SetRowCellValue(i, "MS_N_XUONG", GetNhaxuong(cboMay.EditValue.ToString(), Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["NGAY"].ToString())));
                            grvTGChiTiet.SetRowCellValue(i, "MS_HE_THONG", GetDaychuyen(cboMay.EditValue.ToString(), Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["NGAY"].ToString())));
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void cboMay_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index != 1) return;
            ReportMain.Forms.frmYCSDChonMay frm = new ReportMain.Forms.frmYCSDChonMay();
            frm.iLoai = 2;
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            cboMay.EditValue = Commons.Modules.SQLString;

        }

        private void cboCa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index != 1) return;

            Report1.frmCa frmCa = new Report1.frmCa();
            frmCa.StartPosition = FormStartPosition.CenterParent;
            if (frmCa.ShowDialog() != DialogResult.OK) return;
            DataTable dt = new DataTable();

            try
            {
                dt = new DataTable();
                string str = "SELECT STT, ( CASE '" + Commons.Modules.TypeLanguage.ToString() + "' WHEN 0 THEN CA WHEN 1 THEN ISNULL(CA_ANH, CA) END ) + ' (' + CONVERT(NVARCHAR(5),CAST(TU_GIO AS TIME),108) + ' - ' +  CONVERT(NVARCHAR(5),CAST(DEN_GIO AS TIME),108) + ')' AS TEN_CA FROM CA ORDER BY TU_GIO ";
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCa, dt, "STT", "TEN_CA", "");
            }
            catch { }

            DataTable dtCol = new DataTable();
            dtCol.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_CA", Commons.Modules.TypeLanguage));
            RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
            cbo.DataSource = dtCol;
            cbo.DisplayMember = "CA";
            cbo.ValueMember = "STT";
            cbo.PopulateColumns();
            cbo.Columns["CA"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "CA", Commons.Modules.TypeLanguage);
            grvTGChiTiet.Columns["CaID"].ColumnEdit = cbo;
        }

        private void btnCapNhapTG_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == false)
                return;
            if (string.IsNullOrEmpty(cboMay.EditValue.ToString()))
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTHOI_GIAN_NGUNG_MAY_THEO_MAY", "-1111"));
                try
                {
                    dt.Columns["MS_HE_THONG"].AllowDBNull = true;
                    dt.Columns["MS_N_XUONG"].AllowDBNull = true;
                    dt.Columns["MS_MAY"].AllowDBNull = true;
                    dt.Columns["NGAY"].AllowDBNull = true;
                    dt.Columns["TU_GIO"].AllowDBNull = true;
                    dt.Columns["DEN_NGAY"].AllowDBNull = true;
                    dt.Columns["DEN_GIO"].AllowDBNull = true;
                    dt.Columns["MS_NGUYEN_NHAN"].AllowDBNull = true;
                    dt.Columns["TRUONG_CA"].AllowDBNull = true;
                    dt.Columns["MS_MAY_OLD"].AllowDBNull = true;
                    dt.Columns["NGAY_OLD"].AllowDBNull = true;
                    dt.Columns["TU_GIO_OLD"].AllowDBNull = true;
                    dt.Columns["DEN_NGAY_OLD"].AllowDBNull = true;
                    dt.Columns["DEN_GIO_OLD"].AllowDBNull = true;
                    dt.Columns["MS_LAN_OLD"].AllowDBNull = true;
                }
                catch { }
                grdTGChiTiet.DataSource = dt;
                return;
            }

            if (grvTGChiTiet.RowCount > 0)
            {
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "DaCoThoiGianMuonLamLai", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;
            }
            if ((Convert.ToDateTime(dtNgayBD.DateTime.ToString("dd/MM/yyyy") + " " + tGioBD.Text) >= Convert.ToDateTime(dtNgayKT.DateTime.ToString("dd/MM/yyyy") + " " + tGioKT.Text)))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgTuNgayNhoHonDenNgay", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if ((cboNguyenNhan.EditValue == null))
            {
                cboNguyenNhan.EditValue = 0;
            }

            CapNhapNgay();
            Cursor = Cursors.Default;
            CreateMenuThem1Dong(grdTGChiTiet);

        }
        DataTable dtTmp;
        private void CapNhapNgay()
        {
            try
            {
                DateTime ngay = dtNgayBD.DateTime;
                DateTime gio = Convert.ToDateTime("1900/01/01 " + tGioBD.Text);
                DateTime NgayKT = dtNgayKT.DateTime;
                DateTime GioKT = Convert.ToDateTime("1900/01/01 " + tGioKT.Text);
                ngay = new DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0);
                gio = new DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0);
                NgayKT = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0);
                GioKT = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0);
                int tongNgay = (int)(NgayKT - ngay).TotalDays;
                dtTmp = new DataTable();
                dtTmp = (DataTable)grdTGChiTiet.DataSource;
                dtTmp.Rows.Clear();
                dtTmp.AcceptChanges();
                string sNX = GetNhaxuong(cboMay.EditValue.ToString(), ngay);
                int iDC = GetDaychuyen(cboMay.EditValue.ToString(), ngay);
                DataTable dtCa = new DataTable();
                dtCa.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Ca", Commons.Modules.TypeLanguage));
                for (int i = 0; i <= tongNgay; i++)
                {
                    DataRow dr;
                    DateTime TuNgay = default(DateTime);
                    DateTime DenNgay = default(DateTime);
                    int stime = 0;
                    //Không cài đặt Ca
                    if (dtCa.Rows.Count == 0)
                    {
                        dr = dtTmp.NewRow();
                        if (i == 0)
                        {
                            dr["NGAY"] = ngay.ToString("dd/MM/yyyy");
                            dr["TU_GIO"] = ngay.ToString("HH:mm:ss");
                            TuNgay = DateTime.Parse(ngay.ToString("dd/MM/yyyy") + " " + DateTime.Parse(ngay.TimeOfDay.ToString().Substring(0, 5)).ToString("HH:mm:ss"));
                        }
                        else
                        {
                            ngay = ngay.AddDays(1);
                            dr["NGAY"] = ngay.ToString("dd/MM/yyyy");
                            dr["TU_GIO"] = "00:00:00";
                            TuNgay = DateTime.Parse((ngay.ToString("dd/MM/yyyy") + " 00:00:00"));
                        }
                        dr["DEN_NGAY"] = ngay.ToString("dd/MM/yyyy");
                        if (i == tongNgay)
                        {
                            dr["DEN_GIO"] = tGioKT.Text;
                            DenNgay = DateTime.Parse(NgayKT.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(dr["DEN_GIO"]).ToString("HH:mm:ss"));
                        }
                        else
                        {
                            dr["DEN_GIO"] = "23:59:00";
                            DenNgay = DateTime.Parse(ngay.ToString("dd/MM/yyyy") + " 23:59:00");
                        }
                        stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                        dr["THOI_GIAN_NGUNG_MAY"] = stime;
                        dr["THOI_GIAN_SUA_CHUA"] = stime;
                        dr["MS_N_XUONG"] = sNX;
                        dr["MS_HE_THONG"] = iDC;
                        dr["MS_MAY"] = cboMay.EditValue;
                        dr["MS_NGUYEN_NHAN"] = cboNguyenNhan.EditValue;
                        dr["NN_CGQ"] = txtCachGiaiQuyet.Text;
                        dr["NGUYEN_NHAN_CU_THE"] = txtNNCuThe.Text;
                        dr["HIEN_TUONG"] = txtHTuong.Text;
                        dr["NGUOI_GIAI_QUYET"] = cboNguoiGiaiQuyet.Text;
                        dr["TRUONG_CA"] = cboTruongCa.Text;
                        dtTmp.Rows.Add(dr);
                        //Có cài đặt Ca
                    }
                    else
                    {
                        if (i > 0 & i < tongNgay)
                        {
                            ngay = ngay.AddDays(1);
                            foreach (DataRow row in dtCa.Rows)
                            {
                                dr = dtTmp.NewRow();
                                dr["NGAY"] = ngay.ToString("dd/MM/yyyy");
                                dr["TU_GIO"] = Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm");
                                TuNgay = DateTime.Parse(ngay.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm"));
                                if ((Convert.ToDateTime(row["TU_GIO"]) > Convert.ToDateTime(row["DEN_GIO"])))
                                {
                                    dr["DEN_NGAY"] = ngay.AddDays(1).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    dr["DEN_NGAY"] = ngay.ToString("dd/MM/yyyy");
                                }
                                dr["DEN_GIO"] = Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm");
                                DenNgay = DateTime.Parse(Convert.ToDateTime(dr["DEN_NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm"));
                                stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                                dr["THOI_GIAN_NGUNG_MAY"] = stime;
                                dr["THOI_GIAN_SUA_CHUA"] = stime;
                                dr["MS_N_XUONG"] = sNX;
                                dr["MS_HE_THONG"] = iDC;
                                dr["MS_MAY"] = cboMay.EditValue;
                                dr["MS_NGUYEN_NHAN"] = cboNguyenNhan.EditValue;
                                dr["NN_CGQ"] = txtCachGiaiQuyet.Text;
                                dr["NGUYEN_NHAN_CU_THE"] = txtNNCuThe.Text;
                                dr["HIEN_TUONG"] = txtHTuong.Text;
                                dr["NGUOI_GIAI_QUYET"] = cboNguoiGiaiQuyet.Text;
                                dr["TRUONG_CA"] = cboTruongCa.Text;
                                dr["CaID"] = row["STT"];
                                dtTmp.Rows.Add(dr);
                            }
                        }
                        else if (i == 0)
                        {
                            foreach (DataRow row in dtCa.Rows)
                            {

                                if ((tongNgay == 0))
                                {
                                    if ((Convert.ToDateTime(row["TU_GIO"]) > Convert.ToDateTime(row["DEN_GIO"])))
                                    {
                                        if ((Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["DEN_GIO"]) & Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) >= Convert.ToDateTime(row["TU_GIO"]).AddDays(-1) | Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["DEN_GIO"]).AddDays(1) & Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) >= Convert.ToDateTime(row["TU_GIO"])))
                                        {
                                            dr = dtTmp.NewRow();
                                            dr["NGAY"] = dtNgayBD.DateTime.ToString("dd/MM/yyyy");
                                            dr["TU_GIO"] = Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm");
                                            TuNgay = DateTime.Parse(dtNgayBD.DateTime.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm"));

                                            if ((Convert.ToDateTime(row["TU_GIO"]) > Convert.ToDateTime(row["DEN_GIO"])))
                                            {
                                                dr["DEN_NGAY"] = dtNgayBD.DateTime.AddDays(1).ToString("dd/MM/yyyy");
                                            }
                                            else
                                            {
                                                dr["DEN_NGAY"] = dtNgayBD.DateTime.ToString("dd/MM/yyyy");
                                            }
                                            dr["DEN_GIO"] = Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm");
                                            DenNgay = DateTime.Parse(Convert.ToDateTime(dr["DEN_NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm"));
                                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                                            dr["THOI_GIAN_NGUNG_MAY"] = stime;
                                            dr["THOI_GIAN_SUA_CHUA"] = stime;
                                            dr["MS_N_XUONG"] = sNX;
                                            dr["MS_HE_THONG"] = iDC;
                                            dr["MS_MAY"] = cboMay.EditValue;
                                            dr["MS_NGUYEN_NHAN"] = cboNguyenNhan.EditValue;
                                            dr["NN_CGQ"] = txtCachGiaiQuyet.Text;
                                            dr["NGUYEN_NHAN_CU_THE"] = txtNNCuThe.Text;
                                            dr["HIEN_TUONG"] = txtHTuong.Text;
                                            dr["NGUOI_GIAI_QUYET"] = cboNguoiGiaiQuyet.Text;
                                            dr["TRUONG_CA"] = cboTruongCa.Text;
                                            dr["CaID"] = row["STT"];
                                            dtTmp.Rows.Add(dr);
                                        }
                                    }
                                    else
                                    {
                                        if (((Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["TU_GIO"]) & Convert.ToDateTime("1900/01/01 " + tGioKT.Text.ToString()) >= Convert.ToDateTime(row["TU_GIO"])) | (Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) >= Convert.ToDateTime(row["TU_GIO"]) & Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["DEN_GIO"]))))
                                        {
                                            dr = dtTmp.NewRow();
                                            dr["NGAY"] = dtNgayBD.DateTime.ToString("dd/MM/yyyy");
                                            dr["TU_GIO"] = Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm");
                                            TuNgay = DateTime.Parse(dtNgayBD.DateTime.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm"));
                                            if ((Convert.ToDateTime(row["TU_GIO"]) > Convert.ToDateTime(row["DEN_GIO"])))
                                            {
                                                dr["DEN_NGAY"] = dtNgayBD.DateTime.AddDays(1).ToString("dd/MM/yyyy");
                                            }
                                            else
                                            {
                                                dr["DEN_NGAY"] = dtNgayBD.DateTime.ToString("dd/MM/yyyy");
                                            }
                                            dr["DEN_GIO"] = Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm");
                                            DenNgay = DateTime.Parse(Convert.ToDateTime(dr["DEN_NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm"));
                                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;

                                            dr["THOI_GIAN_NGUNG_MAY"] = stime;
                                            dr["THOI_GIAN_SUA_CHUA"] = stime;
                                            dr["MS_N_XUONG"] = sNX;
                                            dr["MS_HE_THONG"] = iDC;
                                            dr["MS_MAY"] = cboMay.EditValue;
                                            dr["MS_NGUYEN_NHAN"] = cboNguyenNhan.EditValue;
                                            dr["NN_CGQ"] = txtCachGiaiQuyet.Text;
                                            dr["NGUYEN_NHAN_CU_THE"] = txtNNCuThe.Text;
                                            dr["HIEN_TUONG"] = txtHTuong.Text;
                                            dr["NGUOI_GIAI_QUYET"] = cboNguoiGiaiQuyet.Text;
                                            dr["TRUONG_CA"] = cboTruongCa.Text;
                                            dr["CaID"] = row["STT"];
                                            dtTmp.Rows.Add(dr);
                                        }
                                    }
                                }
                                else
                                {
                                    if ((Convert.ToDateTime(row["TU_GIO"]) > Convert.ToDateTime(row["DEN_GIO"])))
                                    {
                                        if (((Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["DEN_GIO"]) & Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) >= Convert.ToDateTime(row["TU_GIO"]).AddDays(-1)) | (Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["DEN_GIO"]).AddDays(1) & Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) >= Convert.ToDateTime(row["TU_GIO"])) | (Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["TU_GIO"]) & Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["DEN_GIO"]).AddDays(1)) | (Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["TU_GIO"]).AddDays(-1) & Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) <= Convert.ToDateTime(row["DEN_GIO"]))))
                                        {
                                            dr = dtTmp.NewRow();
                                            dr["NGAY"] = dtNgayBD.DateTime.ToString("dd/MM/yyyy");

                                            dr["TU_GIO"] = Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm");
                                            TuNgay = DateTime.Parse(dtNgayBD.DateTime.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm"));

                                            if ((Convert.ToDateTime(row["TU_GIO"]) > Convert.ToDateTime(row["DEN_GIO"])))
                                            {
                                                dr["DEN_NGAY"] = dtNgayBD.DateTime.AddDays(1).ToString("dd/MM/yyyy");
                                            }
                                            else
                                            {
                                                dr["DEN_NGAY"] = dtNgayBD.DateTime.ToString("dd/MM/yyyy");
                                            }
                                            dr["DEN_GIO"] = Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm");
                                            DenNgay = DateTime.Parse(Convert.ToDateTime(dr["DEN_NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm"));
                                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                                            dr["THOI_GIAN_NGUNG_MAY"] = stime;
                                            dr["THOI_GIAN_SUA_CHUA"] = stime;
                                            dr["MS_N_XUONG"] = sNX;
                                            dr["MS_HE_THONG"] = iDC;
                                            dr["MS_MAY"] = cboMay.EditValue;
                                            dr["MS_NGUYEN_NHAN"] = cboNguyenNhan.EditValue;
                                            dr["NN_CGQ"] = txtCachGiaiQuyet.Text;
                                            dr["NGUYEN_NHAN_CU_THE"] = txtNNCuThe.Text;
                                            dr["HIEN_TUONG"] = txtHTuong.Text;
                                            dr["NGUOI_GIAI_QUYET"] = cboNguoiGiaiQuyet.Text;
                                            dr["TRUONG_CA"] = cboTruongCa.Text;
                                            dr["CaID"] = row["STT"];
                                            dtTmp.Rows.Add(dr);
                                        }
                                    }
                                    else
                                    {
                                        if ((Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) > Convert.ToDateTime(row["TU_GIO"]) & Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString()) > Convert.ToDateTime(row["DEN_GIO"])))
                                        {
                                        }
                                        else
                                        {
                                            dr = dtTmp.NewRow();
                                            dr["NGAY"] = dtNgayBD.DateTime.ToString("dd/MM/yyyy");
                                            dr["TU_GIO"] = Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm");
                                            TuNgay = DateTime.Parse(dtNgayBD.DateTime.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm"));
                                            if ((Convert.ToDateTime(row["TU_GIO"]) > Convert.ToDateTime(row["DEN_GIO"])))
                                            {
                                                dr["DEN_NGAY"] = dtNgayBD.DateTime.AddDays(1).ToString("dd/MM/yyyy");
                                            }
                                            else
                                            {
                                                dr["DEN_NGAY"] = dtNgayBD.DateTime.ToString("dd/MM/yyyy");
                                            }
                                            dr["DEN_GIO"] = Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm");
                                            DenNgay = DateTime.Parse(Convert.ToDateTime(dr["DEN_NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm"));
                                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                                            dr["THOI_GIAN_NGUNG_MAY"] = stime;
                                            dr["THOI_GIAN_SUA_CHUA"] = stime;
                                            dr["MS_N_XUONG"] = sNX;
                                            dr["MS_HE_THONG"] = iDC;
                                            dr["MS_MAY"] = cboMay.EditValue;
                                            dr["MS_NGUYEN_NHAN"] = cboNguyenNhan.EditValue;
                                            dr["NN_CGQ"] = txtCachGiaiQuyet.Text;
                                            dr["NGUYEN_NHAN_CU_THE"] = txtNNCuThe.Text;
                                            dr["HIEN_TUONG"] = txtHTuong.Text;
                                            dr["NGUOI_GIAI_QUYET"] = cboNguoiGiaiQuyet.Text;
                                            dr["TRUONG_CA"] = cboTruongCa.Text;
                                            dr["CaID"] = row["STT"];
                                            dtTmp.Rows.Add(dr);
                                        }
                                    }
                                }
                            }
                            DataView dv = new DataView(dtTmp);
                            dv.Sort = "NGAY ASC, TU_GIO ASC";
                            dtTmp = dv.ToTable();
                            if ((dtTmp.Rows.Count == 0))
                                continue;
                            DataRow row1 = dtTmp.Rows[0];
                            row1["TU_GIO"] = tGioBD.Text.ToString();
                            TuNgay = DateTime.Parse(Convert.ToDateTime(row1["NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["TU_GIO"]).ToString("HH:mm"));
                            DenNgay = DateTime.Parse(Convert.ToDateTime(row1["DEN_NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["DEN_GIO"]).ToString("HH:mm"));
                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                            row1["THOI_GIAN_NGUNG_MAY"] = stime;
                            row1["THOI_GIAN_SUA_CHUA"] = stime;
                            dv = new DataView(dtTmp);
                            dv.Sort = "NGAY ASC, TU_GIO ASC";
                            dtTmp = dv.ToTable();
                            if (tongNgay == 0)
                            {
                                jump:
                                dv = new DataView(dtTmp);
                                dv.Sort = "NGAY DESC, TU_GIO DESC";
                                dtTmp = dv.ToTable();
                                row1 = dtTmp.Rows[0];
                                row1["DEN_GIO"] = tGioKT.Text.ToString();
                                row1["DEN_NGAY"] = dtNgayKT.DateTime.ToString("dd/MM/yyyy");
                                TuNgay = DateTime.Parse(Convert.ToDateTime(row1["NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["TU_GIO"]).ToString("HH:mm"));
                                DenNgay = DateTime.Parse(dtNgayKT.DateTime.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["DEN_GIO"]).ToString("HH:mm"));
                                stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                                if ((stime < 0))
                                {
                                    dtTmp.Rows.Remove(row1);
                                    goto jump;
                                }
                                row1["THOI_GIAN_NGUNG_MAY"] = stime;
                                row1["THOI_GIAN_SUA_CHUA"] = stime;
                                dv = new DataView(dtTmp);
                                dv.Sort = "NGAY ASC, TU_GIO ASC";
                                dtTmp = dv.ToTable();
                            }
                        }
                        else if (i == tongNgay)
                        {
                            ngay = ngay.AddDays(1);
                            foreach (DataRow row in dtCa.Rows)
                            {
                                if ((Convert.ToDateTime("1900/01/01 " + tGioKT.Text.ToString()) > Convert.ToDateTime(row["TU_GIO"])))
                                {
                                    dr = dtTmp.NewRow();
                                    dr["NGAY"] = dtNgayKT.DateTime.ToString("dd/MM/yyyy");
                                    dr["TU_GIO"] = Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm");
                                    TuNgay = DateTime.Parse(ngay.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["TU_GIO"]).ToString("HH:mm"));
                                    if ((Convert.ToDateTime(row["TU_GIO"]) > Convert.ToDateTime(row["DEN_GIO"])))
                                    {
                                        dr["DEN_NGAY"] = dtNgayKT.DateTime.AddDays(1).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        dr["DEN_NGAY"] = dtNgayKT.DateTime.ToString("dd/MM/yyyy");
                                    }
                                    dr["DEN_GIO"] = Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm");
                                    DenNgay = DateTime.Parse(NgayKT.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row["DEN_GIO"]).ToString("HH:mm"));
                                    stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                                    dr["THOI_GIAN_NGUNG_MAY"] = stime;
                                    dr["THOI_GIAN_SUA_CHUA"] = stime;
                                    dr["MS_N_XUONG"] = sNX;
                                    dr["MS_HE_THONG"] = iDC;
                                    dr["MS_MAY"] = cboMay.EditValue;
                                    dr["MS_NGUYEN_NHAN"] = cboNguyenNhan.EditValue;
                                    dr["NN_CGQ"] = txtCachGiaiQuyet.Text;
                                    dr["NGUYEN_NHAN_CU_THE"] = txtNNCuThe.Text;
                                    dr["HIEN_TUONG"] = txtHTuong.Text;
                                    dr["NGUOI_GIAI_QUYET"] = cboNguoiGiaiQuyet.Text;
                                    dr["TRUONG_CA"] = cboTruongCa.Text;
                                    dr["CaID"] = row["STT"];
                                    dtTmp.Rows.Add(dr);
                                }
                            }

                            DataView dv = new DataView(dtTmp);
                            dv.Sort = "NGAY DESC, TU_GIO DESC";
                            dtTmp = dv.ToTable();
                            DataRow row1 = dtTmp.Rows[0];
                            // dtTmp.Select().OrderByDescending(Function(x) x("TU_GIO"]).Take(1).Single()
                            row1["DEN_GIO"] = tGioKT.Text.ToString();
                            row1["DEN_NGAY"] = dtNgayKT.DateTime.ToString("dd/MM/yyyy");
                            TuNgay = DateTime.Parse(Convert.ToDateTime(row1["NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["TU_GIO"]).ToString("HH:mm"));
                            DenNgay = DateTime.Parse(dtNgayKT.DateTime.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["DEN_GIO"]).ToString("HH:mm"));
                            stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                            row1["THOI_GIAN_NGUNG_MAY"] = stime;
                            row1["THOI_GIAN_SUA_CHUA"] = stime;
                            dv = new DataView(dtTmp);
                            dv.Sort = "NGAY ASC, TU_GIO ASC";
                            dtTmp = dv.ToTable();
                        }
                    }
                }
                //xoas nhung dong co phut lon hon tu ngay den ngay
                TimeSpan sp = DateTime.Parse(dtNgayKT.DateTime.ToString("dd/MM/yyyy") + " " + tGioKT.Text) - DateTime.Parse(dtNgayBD.DateTime.ToString("dd/MM/yyyy") + " " + tGioBD.Text);
                dtTmp.DefaultView.RowFilter = "THOI_GIAN_NGUNG_MAY <= " + sp.TotalMinutes + "";
                dtTmp = dtTmp.DefaultView.ToTable();
                grdTGChiTiet.DataSource = dtTmp;
            }
            catch (Exception ex) { }
        }

        private string GetNhaxuong(string may, DateTime ngay)
        {
            try
            {
                string nhaxuong = null;
                nhaxuong = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetNHA_XUONG_BY_MAY", may, ngay).ToString();
                return nhaxuong;
            }
            catch
            {
                return "";
            }
        }

        private int GetDaychuyen(string may, DateTime ngay)
        {
            try
            {
                string daychuyen = null;
                daychuyen = SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetDAY_CHUYEN_BY_MAY", may, ngay).ToString();
                return Convert.ToInt32(daychuyen);
            }
            catch
            {
                return 0;
            }
        }

        private void grvLanNgungMay_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        bool flag1 = false;
        private void btnXoaBoPhan_Click(object sender, EventArgs e)
        {
            if (grvPTTheoMay.RowCount > 0)
            {


                if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChacChanXoa", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes))
                {
                    flag1 = true;
                    try
                    {
                        string str = "DELETE THOI_GIAN_NGUNG_MAY_PHU_TUNG WHERE STT = " + grvPTTheoMay.GetFocusedDataRow()["STT"].ToString();
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);

                    }
                    catch (Exception ex1)
                    {
                        flag1 = false;
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongTheXoa", Commons.Modules.TypeLanguage) + "\\n" + ex1.Message, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (grvPTTheoMay.RowCount > 0 & flag1 == true)
                    {
                        grvPTTheoMay.DeleteRow(grvPTTheoMay.FocusedRowHandle);
                    }
                    flag1 = false;
                }
            }
            else
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaLanNgungMay_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvLanNgungMay.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                flag1 = true;
                try
                {
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgCheckDelete", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                    XoaLanNgungMay();
                }
                catch
                {
                }

                if (grvLanNgungMay.RowCount > 0)
                {
                    grvLanNgungMay.DeleteRow(grvLanNgungMay.FocusedRowHandle);
                }
                grvLanNgungMay_FocusedRowChanged(null, null);
                flag1 = false;
            }
            catch (Exception ex)
            {
            }
        }
        private void XoaLanNgungMay()
        {
            SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sStr = " DELETE THOI_GIAN_NGUNG_MAY_PHU_TUNG WHERE MS_LAN = '" + grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString() + "'";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sStr);
                SqlHelper.ExecuteNonQuery(trans, "DeleteTHOI_GIAN_NGUNG_MAY_CHI_TIET", grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString());
                SqlHelper.ExecuteNonQuery(trans, "DeleteTHOI_GIAN_NGUNG_MAY_LAN", grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString());
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgDeleteError", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnXoaCTiet_Click(object sender, EventArgs e)
        {

            try
            {
                if (grvTGChiTiet.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                flag1 = true;
                if (grvTGChiTiet.RowCount == 1)
                {
                    flag1 = false;

                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgCon1DongChiTietNenKhongTheXoa", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        XoaLanNgungMay();
                        if (grvLanNgungMay.RowCount > 0)
                        {
                            grvLanNgungMay.DeleteRow(grvLanNgungMay.FocusedRowHandle);
                        }
                        grvLanNgungMay_FocusedRowChanged(null, null);
                        return;
                    }
                    else
                    {
                        return;
                    }

                }
                SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
                if (conn.State != ConnectionState.Open) conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string sStr = "DELETE FROM THOI_GIAN_NGUNG_MAY WHERE MS_MAY = '" + grvTGChiTiet.GetFocusedDataRow()["MS_MAY"].ToString() + "' " + " AND CONVERT(NVARCHAR(10),NGAY,103) = CONVERT(NVARCHAR(10),'" + DateTime.Parse(grvTGChiTiet.GetFocusedDataRow()["NGAY"].ToString()).ToString("dd/MM/yyyy") + "',103)  " + " AND CONVERT(NVARCHAR(10),TU_GIO,108) = CONVERT(NVARCHAR(10), CONVERT(DATETIME,'" + DateTime.Parse(grvTGChiTiet.GetFocusedDataRow()["TU_GIO"].ToString()).ToString("HH:mm:ss") + "'),108)  " + " AND CONVERT(NVARCHAR(10),DEN_NGAY,103) = CONVERT(NVARCHAR(10),'" + DateTime.Parse(grvTGChiTiet.GetFocusedDataRow()["DEN_NGAY"].ToString()).ToString("dd/MM/yyyy") + "',103)  " + " AND CONVERT(NVARCHAR(10),DEN_GIO,108) = CONVERT(NVARCHAR(10),CONVERT(DATETIME,'" + DateTime.Parse(grvTGChiTiet.GetFocusedDataRow()["DEN_GIO"].ToString()).ToString("HH:mm:ss") + "'),108)" + " AND MS_LAN = '" + grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString() + "'";
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sStr);
                    trans.Commit();
                }
                catch (Exception ex1)
                {
                    trans.Rollback();
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgDeleteError", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if ((grvTGChiTiet.RowCount > 0 & flag1 == true))
                {
                    grvTGChiTiet.DeleteRow(grvTGChiTiet.FocusedRowHandle);
                }
                flag1 = false;

            }
            catch (Exception ex)
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = grdLanNgungMay.DataSource as DataTable;
            try
            {
                string sDK = null;
                if (!string.IsNullOrEmpty(txtSearch.Text))
                    sDK = "MS_MAY like '%" + txtSearch.Text + "%' ";
                else
                    sDK = "";
                dt.DefaultView.RowFilter = sDK;
                dt = dt.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                dt.DefaultView.RowFilter = "";
            }
            grvLanNgungMay_FocusedRowChanged(null, null);
        }

        private void grvTGChiTiet_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (grvTGChiTiet.RowCount <= 0) return;
            double thoiGian = 0;
            try
            {
                thoiGian = Convert.ToInt32(grvTGChiTiet.GetFocusedDataRow()["THOI_GIAN_NGUNG_MAY"].ToString());
                if (thoiGian < 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigianngungmaykodung", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Valid = false;
                    return;
                }
                if (thoiGian > 1440)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigianngungmayphainhohon24h", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Valid = false;
                    return;
                }
            }
            catch
            {
                if (grvTGChiTiet.GetFocusedDataRow()["THOI_GIAN_NGUNG_MAY"].ToString() != "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigianngungmaykodung", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Valid = false;
                    return;
                }
            }
            thoiGian = 0;
            try
            {
                thoiGian = Convert.ToInt32(grvTGChiTiet.GetFocusedDataRow()["THOI_GIAN_SUA_CHUA"].ToString());
                if (thoiGian < 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigiansuachuasai", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Valid = false;
                    return;
                }

            }
            catch
            {
                if (grvTGChiTiet.GetFocusedDataRow()["THOI_GIAN_SUA_CHUA"].ToString() != "")
                {

                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigiansuachuasai", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEW", "frmThoigianngungmayNEW", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Valid = false;
                    return;
                }
            }


        }

        private void grvTGChiTiet_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void btnLock_Click(object sender, EventArgs e)
        {

            if (grvLanNgungMay.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgBanCoMuonLockTGNM", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            string sSql = null;
            try
            {
                sSql = "UPDATE THOI_GIAN_NGUNG_MAY_SO_LAN SET LOCK = 1 WHERE MS_LAN = '" + grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString() + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                grvLanNgungMay.DeleteRow(grvLanNgungMay.FocusedRowHandle);
                if (grvLanNgungMay.RowCount == 1) grvLanNgungMay_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCapNhapLockTGNMKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvTGChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!btnSave.Visible) return;
            if (e.Column.FieldName == "NGAY" || e.Column.FieldName == "DEN_NGAY" || e.Column.FieldName == "TU_GIO" || e.Column.FieldName == "DEN_GIO")
            {
                try
                {
                    DateTime TuNgay = DateTime.Parse((DateTime.Parse(grvTGChiTiet.GetFocusedDataRow()["NGAY"].ToString()).ToString("dd/MM/yyyy") + " ") + DateTime.Parse(grvTGChiTiet.GetFocusedDataRow()["TU_GIO"].ToString()).ToString("HH:mm:ss"));
                    DateTime DenNgay = DateTime.Parse((DateTime.Parse(grvTGChiTiet.GetFocusedDataRow()["DEN_NGAY"].ToString()).ToString("dd/MM/yyyy") + " ") + DateTime.Parse(grvTGChiTiet.GetFocusedDataRow()["DEN_GIO"].ToString()).ToString("HH:mm:ss"));
                    int stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                    grvTGChiTiet.SetFocusedRowCellValue("THOI_GIAN_NGUNG_MAY", stime);
                    grvTGChiTiet.SetFocusedRowCellValue("THOI_GIAN_SUA_CHUA", stime);
                }
                catch
                {
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHTuong_Validated(object sender, EventArgs e)
        {
            for (int i = 0; i <= grvTGChiTiet.RowCount - 1; i++)
            {
                string str = "";
                try
                {
                    str = grvTGChiTiet.GetDataRow(i)["HIEN_TUONG"].ToString();
                }
                catch
                {
                }
                if ((string.IsNullOrEmpty(str.Trim())))
                {
                    grvTGChiTiet.SetRowCellValue(i, "HIEN_TUONG", txtHTuong.Text);
                }
            }
        }

        private void txtNNCuThe_Validated(object sender, EventArgs e)
        {
            for (int i = 0; i <= grvTGChiTiet.RowCount - 1; i++)
            {
                string str = "";
                try
                {
                    str = grvTGChiTiet.GetDataRow(i)["NGUYEN_NHAN_CU_THE"].ToString();
                }
                catch
                {
                }
                if ((string.IsNullOrEmpty(str.Trim())))
                {
                    grvTGChiTiet.SetRowCellValue(i, "NGUYEN_NHAN_CU_THE", txtNNCuThe.Text);
                }
            }
        }

        private void txtCachGiaiQuyet_Validated(object sender, EventArgs e)
        {
            for (int i = 0; i <= grvTGChiTiet.RowCount - 1; i++)
            {
                string str = "";
                try
                {
                    str = grvTGChiTiet.GetDataRow(i)["NN_CGQ"].ToString();
                }
                catch
                {
                }
                if ((string.IsNullOrEmpty(str.Trim())))
                {
                    grvTGChiTiet.SetRowCellValue(i, "NN_CGQ", txtCachGiaiQuyet.Text);
                }
            }
        }
        DevExpress.XtraBars.BarManager BarManager = new DevExpress.XtraBars.BarManager();
        private void CreateMenuThem1Dong(GridControl grd)
        {
            try
            {
                foreach (Control control in grd.Controls)
                {
                    if (control.GetType() == typeof(DevExpress.XtraBars.BarDockControl))
                    {
                        return;
                    }
                }
            }
            catch
            {
            }
            BarManager = new DevExpress.XtraBars.BarManager();
            BarManager.Form = grd;
            BarManager.ItemClick += barManager_ItemClick;
            BarManager.BeginUpdate();
            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(BarManager);
            BarManager.SetPopupContextMenu(grd, popup);
            string sStr = null;
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmThoigianngungmayNEWNew", "mnuAddMoreRowDownTime", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuAddRow = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuAddRow.Name = "mnuAddRow";
            popup.AddItems(new DevExpress.XtraBars.BarItem[] { mnuAddRow });
            BarManager.EndUpdate();
        }


        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                switch (e.Item.Name)
                {
                    case "mnuAddRow":
                        AddThemThoiGianChiTiet();
                        break;
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void AddThemThoiGianChiTiet()
        {
            try
            {
                DateTime ngay = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["NGAY"].ToString(), new System.Globalization.CultureInfo("vi-vn"));
                DateTime gio = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["DEN_GIO"].ToString(), new System.Globalization.CultureInfo("vi-vn")).AddMinutes(1);
                DateTime NgayKT = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["DEN_NGAY"].ToString(), new System.Globalization.CultureInfo("vi-vn"));
                DateTime GioKT = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["DEN_GIO"].ToString(), new System.Globalization.CultureInfo("vi-vn")).AddMinutes(1);
                object MS_N_XUONG = grvTGChiTiet.GetFocusedDataRow()["MS_N_XUONG"].ToString();
                object MS_HE_THONG = grvTGChiTiet.GetFocusedDataRow()["MS_HE_THONG"].ToString();
                object MS_MAY = grvTGChiTiet.GetFocusedDataRow()["MS_MAY"].ToString();
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdTGChiTiet.DataSource;
                DateTime vtungay = new DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0);
                DateTime vdenngay = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0);
                int stime = (vdenngay - vtungay).Days * 24 * 60 + (vdenngay - vtungay).Hours * 60 + (vdenngay - vtungay).Minutes;
                DataRow dr = dtTmp.NewRow();
                dr["NGAY"] = gio.ToString("HH:mm") == "00:00" ? ngay.AddDays(1).ToString("dd/MM/yyyy") : ngay.ToString("dd/MM/yyyy");
                dr["TU_GIO"] = gio.ToString("HH:mm:ss");
                dr["DEN_NGAY"] = GioKT.ToString("HH:mm") == "00:00" ? NgayKT.AddDays(1).ToString("dd/MM/yyyy") : NgayKT.ToString("dd/MM/yyyy");
                dr["DEN_GIO"] = GioKT.ToString("HH:mm:ss");
                dr["THOI_GIAN_NGUNG_MAY"] = stime;
                dr["THOI_GIAN_SUA_CHUA"] = stime;
                dr["MS_N_XUONG"] = MS_N_XUONG;
                dr["MS_HE_THONG"] = MS_HE_THONG;
                dr["MS_MAY"] = MS_MAY;
                dr["MS_NGUYEN_NHAN"] = grvTGChiTiet.GetFocusedDataRow()["MS_NGUYEN_NHAN"].ToString();
                dr["NN_CGQ"] = grvTGChiTiet.GetFocusedDataRow()["NN_CGQ"].ToString();
                dr["HIEN_TUONG"] = grvTGChiTiet.GetFocusedDataRow()["HIEN_TUONG"].ToString();
                dr["NGUYEN_NHAN_CU_THE"] = grvTGChiTiet.GetFocusedDataRow()["NGUYEN_NHAN_CU_THE"].ToString();
                dr["GHI_CHU"] = grvTGChiTiet.GetFocusedDataRow()["GHI_CHU"].ToString();
                dr["NGUOI_GIAI_QUYET"] = grvTGChiTiet.GetFocusedDataRow()["NGUOI_GIAI_QUYET"].ToString();
                dr["TRUONG_CA"] = grvTGChiTiet.GetFocusedDataRow()["TRUONG_CA"].ToString();
                dr["CaID"] = grvTGChiTiet.GetFocusedDataRow()["CaID"].ToString();
                dtTmp.Rows.InsertAt(dr, grvTGChiTiet.FocusedRowHandle + 1);
                int focus = grvTGChiTiet.FocusedRowHandle;
                grdTGChiTiet.DataSource = dtTmp;
                grvTGChiTiet.FocusedRowHandle = focus + 1;
            }
            catch (Exception ex)
            {
            }
        }
        private void LoadCa()
        {
            try
            {
                DataTable dtTable = new DataTable();
                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCaTheoGio", "1900/01/01 " + tGioKT.Text.ToString(), Commons.Modules.TypeLanguage));
                if ((dtTable.Rows.Count > 0))
                {
                    cboCa.EditValue = dtTable.Rows[0][0].ToString();
                }
                else
                {
                    cboCa.EditValue = "-1";
                }
            }
            catch (Exception ex)
            {
                cboCa.EditValue = "-1";
            }
        }
        private void tGioBD_EditValueChanged(object sender, EventArgs e)
        {
            if (btnSave.Visible == true)
            {
                LoadCa();
            }
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            if (grvLanNgungMay.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgBanCoMuonUnLockTGNM", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            string sSql = null;
            try
            {
                sSql = "UPDATE THOI_GIAN_NGUNG_MAY_SO_LAN SET LOCK = 0 WHERE MS_LAN = '" + grvLanNgungMay.GetFocusedDataRow()["MS_LAN"].ToString() + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                grvLanNgungMay.DeleteRow(grvLanNgungMay.FocusedRowHandle);
                if (grvLanNgungMay.RowCount == 1) grvLanNgungMay_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCapNhapUnLockTGNMKhongThanhCong", Commons.Modules.TypeLanguage) + "/n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Form GetParentForm(Control parent, string formName)
        {
            Form frm = parent as Form;
            if (frm != null)
            {
                if (frm.Name == formName)
                {
                    return frm;
                }
            }
            if (parent != null)
            {
                return GetParentForm(parent.Parent, formName);
            }
            return frm; ;
        }


        private void cboPhieuBaoTri_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                if (cboPhieuBaoTri.EditValue == null) return;
                if (cboPhieuBaoTri.Text.Trim() == "") return;
                Commons.Hyperlink.ToPhieuBaoTri(this, cboPhieuBaoTri.Text);
            }
        }

        private void cboNguyenNhan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) return;
            Report1.frmNguyenNhanDungMay frm = new Report1.frmNguyenNhanDungMay();
            frm.ShowDialog();

            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY ORDER BY TEN_NGUYEN_NHAN"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguyenNhan, dt, "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN", "");
            }
            catch
            {
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            frmChonMay frm = new frmChonMay();
            if (frm.ShowDialog() == DialogResult.Cancel) return;
            DataTable dt = new DataTable();
            dt = frm.dtMayReturn;
        }

        private void grdTGChiTiet_ProcessGridKey(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Delete)
            {
                if (btnEdit.Visible == true) return;
                grvTGChiTiet.DeleteSelectedRows();
            }
        }

        private void ckLock_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIsLock.Checked)
                {
                    btnLock.Visible = false;
                    btnUnLock.Visible = true;
                    btnAdd.Visible = false;
                    btnAddPT.Visible = false;
                    btnCopy.Visible = false;
                    btnEdit.Visible = false;
                    btnThoat.Visible = true;
                    btnXoa.Visible = false;
                    btnCapNhapTG.Visible = false;
                    btnKhongghi.Visible = false;
                    btnSave.Visible = false;
                    btnTroVe.Visible = false;
                    btnXoaBoPhan.Visible = false;
                    btnXoaCTiet.Visible = false;
                    btnXoaLanNgungMay.Visible = false;
                    btnTroVe.Visible = false;
                }
                else
                {
                    btnLock.Visible = true;
                    btnUnLock.Visible = false;
                    btnAdd.Visible = true;
                    btnAddPT.Visible = true;
                    btnCopy.Visible = true;
                    btnEdit.Visible = true;
                    btnThoat.Visible = true;
                    btnXoa.Visible = true;
                    btnCapNhapTG.Visible = false;
                    btnKhongghi.Visible = false;
                    btnSave.Visible = false;
                    btnTroVe.Visible = false;
                    btnXoaBoPhan.Visible = false;
                    btnXoaCTiet.Visible = false;
                    btnXoaLanNgungMay.Visible = false;
                    btnTroVe.Visible = false;
                }
                LoadLanNgungMay("-1");
            }
            catch
            {
            }
        }
    }
}
