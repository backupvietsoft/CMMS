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
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmTGNM : Form
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

        private static int AutoDowtime = 0;
        private Int64 IDNM = -1;
        private Int64 IDNMOLD = -1;
        //0 là không phân tích
        //1 là theo ca khi tổng là 1440
        //2 theo ngày khi bằng 0
        public frmTGNM()
        {
            InitializeComponent();
        }
        bool bLock = false, bUnLock = false;
        private void frmTGNM_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 49))
                bLock = true;
            if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 50))
                bUnLock = true;

            dtNgayBDLoc.DateTime = DateTime.Now.AddMonths(-3);
            dtNgayKTLoc.DateTime = DateTime.Now.AddMonths(1);

            EnableControl(false);
            LoadDiaDiem();
            LoadMay();
            LoadCombobox();
            LoadLanNgungMay(false);
            ShowThoiGianNgung(true);
            if (!string.IsNullOrEmpty(MsMay))
            {
                btnAdd_Click(btnAdd, EventArgs.Empty);
                cboMay.EditValue = MsMay;
                dtNgayBD.DateTime = NGAY_BD;
                LoadPhieuBaoTri();
                tGioBD.EditValue = GIO_BD.ToString("HH:mm");
                dtNgayKT.DateTime = NGAY_KT;
                tGioKT.EditValue = GIO_KT.ToString("HH:mm");
                if (MS_NN.ToString() != "") cboNguyenNhan.EditValue = int.Parse(MS_NN);
                cboPhieuBaoTri.EditValue = MS_PHIEU_BAO_TRI;
                txtNNCuThe.Text = sNguyenNhanNgungMay;
                txtCachGiaiQuyet.Text = sGiaiPhapKhacPhuc;
            }
            //set Loại insert 
            int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ISNULL( SUM (DATEDIFF(MINUTE,TU_GIO,CASE CA_DEM WHEN 1 THEN DATEADD(DAY,1,DEN_GIO) ELSE	 DEN_GIO END )),0) FROM dbo.CA"));
            switch (n)
            {
                case 0: { AutoDowtime = 0; break; }
                case 1440: { AutoDowtime = 1; break; }
                default:
                    { AutoDowtime = 2; break; }
                    break;
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            Commons.Modules.SQLString = "";
        }
        //
        private void LoadDiaDiem()
        {
            KiemApp.MLoadCboTreeList(ref cboDiaDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
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
            LoadComboCa();
            LoadCongNhan();
            LoadLoaiNN();
            LoadNN();
        }
        private void LoadLanNgungMay(bool forcus)
        {
            Commons.Modules.SQLString = "0Load";
            DataTable dt = new DataTable();
            try
            {
                try
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetListDownTimeByDate", Commons.Modules.UserName, Commons.Modules.TypeLanguage, cboLoaiMay.EditValue, cboDChuyen.EditValue, cboDiaDiem.EditValue, dtNgayBDLoc.DateTime.Date, dtNgayKTLoc.DateTime.Date, chkIsLock.Checked));
                }
                catch
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetListDownTimeByDate", Commons.Modules.UserName, Commons.Modules.TypeLanguage, cboLoaiMay.EditValue, cboDChuyen.EditValue, cboDiaDiem.EditValue, DateTime.Now.Date, DateTime.Now.Date, chkIsLock.Checked));
                }

                dt.PrimaryKey = new DataColumn[] { dt.Columns["MS_MAY"], dt.Columns["NGAY"] };

                if (grdTHOI_GIAN_DUNG_MAY.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTHOI_GIAN_DUNG_MAY, grvTHOI_GIAN_DUNG_MAY, dt, false, true, true, false, true, this.Name);
                }
                else
                    grdTHOI_GIAN_DUNG_MAY.DataSource = dt;
                Commons.Modules.SQLString = "";
                if (forcus)
                {
                    object[] keyVals = new object[] { cboMay.EditValue, dtNgayBD.DateTime.ToString("dd/MM/yyyy") };
                    int index = dt.Rows.IndexOf(dt.Rows.Find(keyVals));
                    grvTHOI_GIAN_DUNG_MAY.FocusedRowHandle = grvTHOI_GIAN_DUNG_MAY.GetRowHandle(index);
                }
                else
                {
                    if (grvTHOI_GIAN_DUNG_MAY.FocusedRowHandle < 1)
                    {
                        LoadNgungMayChiTiet(IDNMOLD);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void cboDiaDiem_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadLanNgungMay(false);
        }

        private void ShowThoiGianNgung(bool bload)
        {
            try
            {
                if (bload)
                {
                    IDNM = int.Parse(grvTGChiTiet.GetFocusedDataRow()["ID"] == null ? "-1" : grvTGChiTiet.GetFocusedDataRow()["ID"].ToString());
                    cboMay.EditValue = grvTGChiTiet.GetFocusedDataRow()["MS_MAY"].ToString();
                    cboTo.EditValue = int.Parse(string.IsNullOrEmpty(grvTGChiTiet.GetFocusedDataRow()["MS_TO"].ToString()) ? "-1" : grvTGChiTiet.GetFocusedDataRow()["MS_TO"].ToString());
                    cboNguyenNhan.EditValue = int.Parse(grvTGChiTiet.GetFocusedDataRow()["MS_NGUYEN_NHAN"] == null ? "-1" : grvTGChiTiet.GetFocusedDataRow()["MS_NGUYEN_NHAN"].ToString());
                    cboLoaiNN.EditValue = int.Parse(grvTGChiTiet.GetFocusedDataRow()["ID_DownType"] == null ? "-1" : grvTGChiTiet.GetFocusedDataRow()["ID_DownType"].ToString());
                    dtNgayBD.DateTime = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["NGAY"].ToString());
                    dtNgayKT.DateTime = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["DEN_NGAY"].ToString());
                    tGioBD.EditValue = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["TU_GIO"].ToString()).ToString("HH:mm");
                    tGioKT.EditValue = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["DEN_GIO"].ToString()).ToString("HH:mm");
                    txtTHOI_GIAN_SUA.EditValue = grvTGChiTiet.GetFocusedDataRow()["THOI_GIAN_NGUNG_MAY"];
                    txtTHOI_GIAN_SUA_CHUA.EditValue = grvTGChiTiet.GetFocusedDataRow()["THOI_GIAN_SUA_CHUA"];

                    txtCachGiaiQuyet.Text = grvTGChiTiet.GetFocusedDataRow()["GHI_CHU"].ToString();
                    txtHTuong.Text = grvTGChiTiet.GetFocusedDataRow()["HIEN_TUONG"].ToString();
                    cboNguoiGiaiQuyet.Text = grvTGChiTiet.GetFocusedDataRow()["NGUOI_GIAI_QUYET"].ToString();
                    txtNNCuThe.Text = grvTGChiTiet.GetFocusedDataRow()["NGUYEN_NHAN_CU_THE"].ToString();
                    cboTruongCa.Text = grvTGChiTiet.GetFocusedDataRow()["TRUONG_CA"].ToString();
                    chkTiepTuc.Checked = KiemTra_TiepTuc(IDNM);

                    //kiểm tra id có tồn tại trong id cha không nếu không mới thêm poup
                    if (!KiemTra_IDCHA(IDNM))
                    {
                        CreateMenuThem1Dong(grdTGChiTiet);
                    }
                    else
                    {
                        BarManager.Dispose();
                    }

                    if (string.IsNullOrEmpty(grvTGChiTiet.GetFocusedDataRow()["CaID"].ToString()))
                        cboCa.EditValue = -1;
                    else
                        cboCa.EditValue = Convert.ToInt32(grvTGChiTiet.GetFocusedDataRow()["CaID"].ToString());

                    if (grvTGChiTiet.GetFocusedDataRow()["MS_PHIEU_BAO_TRI"].ToString() != "")
                    {
                        LoadPhieuBaoTri();
                        cboPhieuBaoTri.EditValue = grvTGChiTiet.GetFocusedDataRow()["MS_PHIEU_BAO_TRI"].ToString();
                    }
                    else
                    { cboPhieuBaoTri.EditValue = ""; }

                    try
                    {
                        cboTo.EditValue = Convert.ToInt32(grvTGChiTiet.GetFocusedDataRow()["MS_TO"].ToString());
                    }
                    catch
                    {
                        cboTo.EditValue = -1;
                    }
                }
                else
                {
                    cboMay.EditValue = "";
                    cboNguyenNhan.EditValue = "-1";
                    dtNgayBD.DateTime = DateTime.Now;
                    dtNgayKT.DateTime = DateTime.Now;
                    tGioBD.EditValue = DateTime.Now.ToString("HH:mm");
                    tGioKT.EditValue = DateTime.Now.AddHours(1).ToString("HH:mm");
                    txtCachGiaiQuyet.Text = "";
                    txtHTuong.Text = "";
                    cboNguoiGiaiQuyet.Text = "";
                    txtNNCuThe.Text = "";
                    cboTruongCa.Text = "";
                    cboCa.EditValue = -1;
                    cboNguyenNhan.EditValue = -1;
                    chkTiepTuc.Checked = false;
                    DataTable dt = new DataTable();
                    dt = (DataTable)grdTGChiTiet.DataSource;
                    try
                    {
                        DataTable dtm = dt.Copy();
                        dtm.Rows.Clear();
                        grdTGChiTiet.DataSource = dtm;
                    }
                    catch { }


                    dt = new DataTable();
                    dt = grdPTTheoMay.DataSource as DataTable;
                    try
                    {
                        dt.Rows.Clear();
                    }
                    catch { }
                    grdPTTheoMay.DataSource = dt;
                }
            }
            catch
            {

            }
        }
        private bool KiemTra_IDCHA(Int64 ID)
        {
            bool Tiep_Tuc = false;
            try
            {
                Tiep_Tuc = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT 1 AS TIEP_TUC FROM dbo.THOI_GIAN_NGUNG_MAY WHERE ID_CHA = " + ID + ""));
            }
            catch { return false; }
            return Tiep_Tuc;
        }
        private bool KiemTra_TiepTuc(Int64 ID)
        {
            bool Tiep_Tuc = false;
            try
            {
                Tiep_Tuc = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 1 FROM (SELECT 1 AS TIEP_TUC FROM dbo.THOI_GIAN_NGUNG_MAY WHERE ID = " + ID + " AND ISNULL(ID_CHA, 0) <> 0 UNION SELECT 1 AS TIEP_TUC FROM dbo.THOI_GIAN_NGUNG_MAY WHERE ID_CHA = " + ID + ") A"));
            }
            catch { return false; }
            return Tiep_Tuc;
        }

        private void grvLanNgungMay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadNgungMayChiTiet(IDNMOLD);
            //LoadBoPhanPhuTung();
        }

        private void dtNgayBDLoc_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadLanNgungMay(false);
        }

        private void LoadNgungMayChiTiet(Int64 iIDNN)
        {
            Commons.Modules.SQLString = "0Load";
            try
            {
                DataTable dt = new DataTable();
                try
                {
                    dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListDownTime", Commons.Modules.UserName, Commons.Modules.TypeLanguage, grvTHOI_GIAN_DUNG_MAY.GetFocusedRowCellValue("MS_MAY").ToString(), Convert.ToDateTime(grvTHOI_GIAN_DUNG_MAY.GetFocusedRowCellValue("NGAY")).Date));
                }
                catch
                {
                    dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListDownTime", Commons.Modules.UserName, Commons.Modules.TypeLanguage, "-99", DateTime.Now));
                }

                if (dt.Rows.Count == 0)
                {
                    ShowThoiGianNgung(false);
                }

                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                if (grdTGChiTiet.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTGChiTiet, grvTGChiTiet, dt, false, false, true, true, true, this.Name);
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


                    DataTable dtCol = new DataTable();
                    dtCol.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_CA", Commons.Modules.TypeLanguage));
                    RepositoryItemLookUpEdit cbo = new RepositoryItemLookUpEdit();
                    cbo.DataSource = dtCol;
                    cbo.DisplayMember = "CA";
                    cbo.ValueMember = "STT";
                    cbo.PopulateColumns();
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
                    grvTGChiTiet.Columns["MS_MAY"].Visible = false;
                    grvTGChiTiet.Columns["ID"].Visible = false;
                    //grvTGChiTiet.Columns["CaID"].Visible = false;
                    grvTGChiTiet.Columns["ID_DownType"].Visible = false;
                    grvTGChiTiet.Columns["ID_CHA"].Visible = false;
                    grvTGChiTiet.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
                    grvTGChiTiet.Columns["MS_TO"].Visible = false;
                }
                else
                {
                    grdTGChiTiet.DataSource = dt;
                }
                Commons.Modules.SQLString = "";
                if (iIDNN != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(iIDNN));
                    grvTGChiTiet.FocusedRowHandle = grvTGChiTiet.GetRowHandle(index);
                }
                if (grvTGChiTiet.FocusedRowHandle < 1)
                {
                    LoadBoPhanPhuTung();
                    ShowThoiGianNgung(true);
                }
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
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetPhutungTheoMay", grvTGChiTiet.GetFocusedDataRow()["ID"].ToString(), grvTGChiTiet.GetFocusedDataRow()["MS_MAY"].ToString()));
                }
                catch
                {
                    dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhutungTheoMay", -1, ""));
                }
                dt.Columns["MS_BO_PHAN"].ReadOnly = true;
                dt.Columns["TEN_BO_PHAN"].ReadOnly = true;
                dt.Columns["MS_PT"].ReadOnly = true;
                dt.Columns["TEN_PT"].ReadOnly = true;
                dt.Columns["MS_VI_TRI_PT"].ReadOnly = true;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPTTheoMay, grvPTTheoMay, dt, false, false, true, true, true, this.Name);
                grvPTTheoMay.Columns["MS_MAY"].Visible = false;
                grvPTTheoMay.Columns["STT"].Visible = false;
                grvPTTheoMay.Columns["MS_PT"].VisibleIndex = 5;
                grvPTTheoMay.Columns["MS_VI_TRI_PT"].VisibleIndex = 6;
                grvPTTheoMay.Columns["TEN_PT"].VisibleIndex = 7;
                grvPTTheoMay.Columns["DEL"].Visible = false;
                grvPTTheoMay.Columns["ID_TGNM"].Visible = false;
            }
            catch (Exception ex)
            {
            }
        }
        private void EnableControl(bool flag)
        {
            txtCachGiaiQuyet.Properties.ReadOnly = !flag;
            txtHTuong.Properties.ReadOnly = !flag;
            //txtTHOI_GIAN_SUA.Properties.ReadOnly = !flag;
            txtTHOI_GIAN_SUA_CHUA.Properties.ReadOnly = !flag;
            cboNguoiGiaiQuyet.Properties.ReadOnly = !flag;
            txtNNCuThe.Properties.ReadOnly = !flag;
            gbLanngungmay.Enabled = !flag;
            cboTruongCa.Properties.ReadOnly = !flag;
            cboCa.Properties.ReadOnly = !flag;
            cboMay.Properties.ReadOnly = !flag;
            cboNguyenNhan.Properties.ReadOnly = !flag;
            cboLoaiNN.Properties.ReadOnly = !flag;
            cboTo.Properties.ReadOnly = !flag;
            cboPhieuBaoTri.Properties.ReadOnly = !flag;
            dtNgayBD.Properties.ReadOnly = !flag;
            dtNgayKT.Properties.ReadOnly = !flag;
            tGioBD.Properties.ReadOnly = !flag;
            tGioKT.Properties.ReadOnly = !flag;
        }

        private void VisibleControl(bool flag, bool xoa)
        {
            btnAdd.Visible = flag;
            btnAddPT.Visible = xoa ? flag : !flag;
            btnEdit.Visible = flag;
            btnThoat.Visible = flag;
            btnXoa.Visible = flag;
            btnKhongghi.Visible = xoa ? flag : !flag;
            btnSave.Visible = xoa ? flag : !flag;
            btnTroVe.Visible = xoa ? flag : flag;
            chkIsLock.Visible = flag;
            btnXoaBoPhan.Visible = xoa;
            btnXoaCT.Visible = xoa;
            btnTroVe.Visible = xoa;
            btnLock.Visible = flag;
            btnUnLock.Visible = flag;
            if (flag)
            {
                if (!chkIsLock.Checked)
                {
                    btnLock.Visible = true;
                    btnUnLock.Visible = false;
                }
            }
        }

        private void VisibleXoa(bool flag)
        {
            btnXoa.Visible = flag;
            btnXoaBoPhan.Visible = !flag;
            btnXoaCT.Visible = !flag;
            btnTroVe.Visible = !flag;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IDNM = -1;
            VisibleControl(false, false);
            EnableControl(true);
            gbLanngungmay.Enabled = false;
            ShowThoiGianNgung(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grvTHOI_GIAN_DUNG_MAY.RowCount == 0) return;
            VisibleControl(false, false);
            EnableControl(true);
            gbLanngungmay.Enabled = false;
            grdTGChiTiet.Enabled = false;
            grvTGChiTiet.OptionsBehavior.Editable = true;
            cboMay.Enabled = false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            VisibleControl(false, true);
            VisibleXoa(false);
        }


        private bool CheckSaveData(DateTime datBD, DateTime datKT)
        {
            try
            {
                int n = 0;
                //kiểm tra đến ngày hợp lệ
                if (datKT < datBD)
                {
                    dxErrorProvider1.SetError(dtNgayBD, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTungayphainhohondenngay", Commons.Modules.TypeLanguage));
                    dtNgayBD.Focus();
                    dxErrorProvider1.SetError(dtNgayKT, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTungayphainhohondenngay", Commons.Modules.TypeLanguage));
                    return false;
                }
                //kiểm tra lớn hơn 24 h
                if ((datKT - datBD).TotalHours > 24)
                {
                    dxErrorProvider1.SetError(dtNgayBD, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigianphainhohon24h", Commons.Modules.TypeLanguage));
                    dtNgayBD.Focus();
                    dxErrorProvider1.SetError(dtNgayKT, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigianphainhohon24h", Commons.Modules.TypeLanguage));
                    return false;
                }
                //kiểm tra từ ngày đến ngày năm trong một ca hiện tại

                //kiểm tra ngày bắc đầu nằm giữa từ ngày đến ngày

                //kiểm tra ngày kết thúc nằm giữa từ ngày đến ngày

                //kiểm dữ liệu nằm ở 2 mé ngoài

                return true;
            }
            catch
            {
                return false;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider1.ClearErrors();
                //kiểm tra mấy không trống
                if (string.IsNullOrEmpty(cboMay.Text) || cboMay.Equals(DBNull.Value))
                {
                    dxErrorProvider1.SetError(cboMay, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgMAYNull", Commons.Modules.TypeLanguage));
                    cboMay.Focus();
                    return;
                }

                //nguyên nhân không trông
                if (string.IsNullOrEmpty(cboNguyenNhan.Text) || cboNguyenNhan.Equals(DBNull.Value))
                {
                    dxErrorProvider1.SetError(cboNguyenNhan, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNguyenNhanNull", Commons.Modules.TypeLanguage));
                    cboNguyenNhan.Focus();
                    return;
                }

                //kiểm tra thời gian sửa chữa không lớn hơn thời gian sữa
                if (Convert.ToDecimal(txtTHOI_GIAN_SUA_CHUA.EditValue) > Convert.ToDecimal(txtTHOI_GIAN_SUA.EditValue))
                {
                    dxErrorProvider1.SetError(txtTHOI_GIAN_SUA_CHUA, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgThoigiansuachuakhonglonhonthoigiansua", Commons.Modules.TypeLanguage));
                    txtTHOI_GIAN_SUA_CHUA.Focus();
                    return;
                }
                DateTime ngayBD = dtNgayBD.DateTime;
                DateTime gio = Convert.ToDateTime("1900/01/01 " + tGioBD.Text.ToString());
                DateTime NgayKT = dtNgayKT.DateTime;
                DateTime GioKT = Convert.ToDateTime("1900/01/01 " + tGioKT.Text.ToString());
                ngayBD = new DateTime(ngayBD.Year, ngayBD.Month, ngayBD.Day, gio.Hour, gio.Minute, 0);
                NgayKT = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0);
                //kiểm tra đến ngày lớn hơn
                if (ngayBD >= NgayKT)
                {
                    dtNgayKT.ErrorText = Commons.Modules.GetNNgu(this.Name, "MsgTungayphainhohondenngay");
                    return;
                }
                DataTable dt = new DataTable();
                if (AutoDowtime == 2 || cboMay.Enabled == false)
                {
                    if ((string.IsNullOrEmpty(cboCa.Text) || cboCa.Equals(DBNull.Value)) && AutoDowtime != 0)
                    {
                        cboCa.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgCaNotNull", Commons.Modules.TypeLanguage);
                        cboCa.Focus();
                        return;
                    }
                    if (!CheckSaveData(ngayBD, NgayKT))
                    {
                        return;
                    }
                    {
                        DataView dv = new DataView((DataTable)grdTGChiTiet.DataSource);
                        dt = new DataTable();
                        dt = dv.ToTable(false, "NGAY", "TU_GIO", "DEN_NGAY", "DEN_GIO", "CaID");
                        dt.Rows.Clear();

                        DataRow row = dt.NewRow();
                        row["NGAY"] = ngayBD;
                        row["TU_GIO"] = gio;
                        row["DEN_NGAY"] = NgayKT;
                        row["DEN_GIO"] = GioKT;
                        row["CaID"] = cboCa.EditValue;
                        dt.Rows.Add(row);
                    }
                }
                else
                {
                    dt = CapNhapNgay(dtNgayBD.DateTime, gio, dtNgayKT.DateTime, GioKT);
                }
                SqlConnection conn = new SqlConnection(Commons.IConnections.CNStr);
                if (conn.State != ConnectionState.Open) conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    //tạo bảng tạm ngày 
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "sBTNgay" + Commons.Modules.UserName, dt, "");
                    ////tạo bảng tạm phụ tùng
                    //Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "sBTNPT" + Commons.Modules.UserName, (DataTable)grdPTTheoMay.DataSource, "");

                    //tạo bảng tạm chi tiết
                    //Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "sBTCT" + Commons.Modules.UserName, (DataTable)grdTGChiTiet.DataSource, "");

                    //tạo bảng tạm PT
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "sBTPT" + Commons.Modules.UserName, (DataTable)grdPTTheoMay.DataSource, "");

                    IDNMOLD = Convert.ToInt64(SqlHelper.ExecuteScalar(trans, "spSaveThoiGianNgungMay", IDNM, cboTo.Properties.ReadOnly ? grvTGChiTiet.GetFocusedDataRow()["ID"] : null, cboMay.EditValue, cboNguyenNhan.EditValue, cboNguyenNhan.Text, txtNNCuThe.Text, txtHTuong.Text, txtCachGiaiQuyet.Text, cboTruongCa.Text, cboNguoiGiaiQuyet.Text, cboPhieuBaoTri.Text, cboTo.EditValue, txtTHOI_GIAN_SUA.EditValue, txtTHOI_GIAN_SUA_CHUA.EditValue, "sBTNgay" + Commons.Modules.UserName, "sBTPT" + Commons.Modules.UserName));
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return;
                }

                EnableControl(false);
                VisibleControl(true, false);
                gbLanngungmay.Enabled = true;
                grdTGChiTiet.Enabled = true;

                LoadLanNgungMay(true);
                grvTGChiTiet.OptionsBehavior.Editable = false;
                cboMay.Enabled = true;
                IDNMOLD = -1;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnKhongghi_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            EnableControl(false);
            VisibleControl(true, false);
            gbLanngungmay.Enabled = true;
            grdTGChiTiet.Enabled = true;
            cboMay.Enabled = true;
            grvTGChiTiet.OptionsBehavior.Editable = false;
            LoadLanNgungMay(true);
            //BarManager.Dispose();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            VisibleControl(true, false);
        }
        private void btnAddPT_Click(object sender, EventArgs e)
        {
            if (cboMay.Text.Trim() != "")
            {
                //tableLayoutPanel3.Enabled = false;
                fChuaLuu = true;
                //grdTGChiTiet.Enabled = false;
                btnChonPT_Click(null, null);
            }
            else
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoMay", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                frm.MS_MAY = cboMay.EditValue.ToString();
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

                    grvPTTheoMay.Columns["MS_MAY"].Visible = false;
                    grvPTTheoMay.Columns["STT"].Visible = false;
                    grvPTTheoMay.Columns["MS_PT"].VisibleIndex = 5;
                    grvPTTheoMay.Columns["MS_VI_TRI_PT"].VisibleIndex = 6;
                    grvPTTheoMay.Columns["TEN_PT"].VisibleIndex = 7;
                    grvPTTheoMay.Columns["DEL"].Visible = false;
                    grvPTTheoMay.Columns["ID_TGNM"].Visible = false;
                    //thêm phụ tùng

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

        private DataTable CapNhapNgay(DateTime ngay, DateTime gio, DateTime NgayKT, DateTime GioKT)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                ngay = new DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0);
                gio = new DateTime(ngay.Year, ngay.Month, ngay.Day, gio.Hour, gio.Minute, 0);
                NgayKT = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0);
                GioKT = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, GioKT.Hour, GioKT.Minute, 0);
                int tongNgay = (int)(NgayKT - ngay).TotalDays;
                dtTmp = new DataTable();
                DataView dv = new DataView((DataTable)grdTGChiTiet.DataSource);
                dtTmp = dv.ToTable(true, "NGAY", "TU_GIO", "DEN_NGAY", "DEN_GIO", "CaID");
                dtTmp.Rows.Clear();
                dtTmp.AcceptChanges();
                DataTable dtCa = new DataTable();
                dtCa.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "Get_Ca", Commons.Modules.TypeLanguage));
                for (int i = 0; i <= tongNgay; i++)
                {
                    DataRow dr;
                    DateTime TuNgay = default(DateTime);
                    DateTime DenNgay = default(DateTime);
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
                        if (i == tongNgay)
                        {
                            dr["DEN_NGAY"] = ngay.ToString("dd/MM/yyyy");
                            dr["DEN_GIO"] = tGioKT.Text;
                            DenNgay = DateTime.Parse(NgayKT.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(dr["DEN_GIO"]).ToString("HH:mm:ss"));
                        }
                        else
                        {
                            dr["DEN_NGAY"] = ngay.AddDays(1).ToString("dd/MM/yyyy");
                            dr["DEN_GIO"] = "00:00:00";
                            DenNgay = DateTime.Parse(ngay.AddDays(1).ToString("dd/MM/yyyy") + " 00:00:00");

                        }
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
                                            dr["CaID"] = row["STT"];
                                            dtTmp.Rows.Add(dr);
                                        }
                                    }
                                }
                            }
                            dv = new DataView(dtTmp);
                            dv.Sort = "NGAY ASC, TU_GIO ASC";
                            dtTmp = dv.ToTable();
                            if ((dtTmp.Rows.Count == 0))
                                continue;
                            DataRow row1 = dtTmp.Rows[0];
                            row1["TU_GIO"] = tGioBD.Text.ToString();
                            TuNgay = DateTime.Parse(Convert.ToDateTime(row1["NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["TU_GIO"]).ToString("HH:mm"));
                            DenNgay = DateTime.Parse(Convert.ToDateTime(row1["DEN_NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["DEN_GIO"]).ToString("HH:mm"));
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
                                int stime = (DenNgay - TuNgay).Days * 24 * 60 + (DenNgay - TuNgay).Hours * 60 + (DenNgay - TuNgay).Minutes;
                                if ((stime < 0))
                                {
                                    dtTmp.Rows.Remove(row1);
                                    goto jump;
                                }
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
                                    dr["CaID"] = row["STT"];
                                    dtTmp.Rows.Add(dr);
                                }
                            }

                            dv = new DataView(dtTmp);
                            dv.Sort = "NGAY DESC, TU_GIO DESC";
                            dtTmp = dv.ToTable();
                            DataRow row1 = dtTmp.Rows[0];
                            // dtTmp.Select().OrderByDescending(Function(x) x("TU_GIO"]).Take(1).Single()
                            row1["DEN_GIO"] = tGioKT.Text.ToString();
                            row1["DEN_NGAY"] = dtNgayKT.DateTime.ToString("dd/MM/yyyy");
                            TuNgay = DateTime.Parse(Convert.ToDateTime(row1["NGAY"]).ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["TU_GIO"]).ToString("HH:mm"));
                            DenNgay = DateTime.Parse(dtNgayKT.DateTime.ToString("dd/MM/yyyy") + " " + Convert.ToDateTime(row1["DEN_GIO"]).ToString("HH:mm"));

                            dv = new DataView(dtTmp);
                            dv.Sort = "NGAY ASC, TU_GIO ASC";
                            dtTmp = dv.ToTable();
                        }
                    }
                }
                //xoas nhung dong co phut lon hon tu ngay den ngay
                //TimeSpan sp = DateTime.Parse(dtNgayKT.DateTime.ToString("dd/MM/yyyy") + " " + tGioKT.Text) - DateTime.Parse(dtNgayBD.DateTime.ToString("dd/MM/yyyy") + " " + tGioBD.Text);
                //dtTmp.DefaultView.RowFilter = "THOI_GIAN_NGUNG_MAY <= " + sp.TotalMinutes + "";
                //dtTmp = dtTmp.DefaultView.ToTable();
                //grdTGChiTiet.DataSource = dtTmp;
            }
            catch (Exception ex) { }
            return dtTmp;
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
        private void btnXoaBoPhan_Click(object sender, EventArgs e)
        {
            if (grvPTTheoMay.RowCount > 0)
            {
                if ((XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChacChanXoa", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes))
                {
                    try
                    {
                        string str = "DELETE THOI_GIAN_NGUNG_MAY_PHU_TUNG WHERE STT = " + grvPTTheoMay.GetFocusedDataRow()["STT"].ToString();
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                        grvPTTheoMay.DeleteSelectedRows();
                    }
                    catch (Exception ex1)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongTheXoa", Commons.Modules.TypeLanguage) + "\\n" + ex1.Message, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaLanNgungMay()
        {
            SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sStr = " DELETE THOI_GIAN_NGUNG_MAY_PHU_TUNG WHERE  ID_TGNM IN(SELECT * FROM  dbo.fnGetNguyenNhanNM(" + grvTGChiTiet.GetFocusedDataRow()["ID"].ToString() + "))";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sStr);
                sStr = "DELETE FROM THOI_GIAN_NGUNG_MAY WHERE ID IN(SELECT * FROM  dbo.fnGetNguyenNhanNM(" + grvTGChiTiet.GetFocusedDataRow()["ID"].ToString() + "))";
                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sStr);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgDeleteError", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnXoaCTiet_Click(object sender, EventArgs e)
        {

            try
            {
                if (grvTGChiTiet.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (chkTiepTuc.Checked)
                {
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgXoaNgungMayLienQuan"), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
                XoaLanNgungMay();
                LoadLanNgungMay(false);
            }
            catch (Exception ex)
            {
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = grdTHOI_GIAN_DUNG_MAY.DataSource as DataTable;
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
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigianngungmaykodung", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Valid = false;
                    return;
                }
                if (thoiGian > 1440)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigianngungmayphainhohon24h", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Valid = false;
                    return;
                }
            }
            catch
            {
                if (grvTGChiTiet.GetFocusedDataRow()["THOI_GIAN_NGUNG_MAY"].ToString() != "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigianngungmaykodung", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigiansuachuasai", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Valid = false;
                    return;
                }

            }
            catch
            {
                if (grvTGChiTiet.GetFocusedDataRow()["THOI_GIAN_SUA_CHUA"].ToString() != "")
                {

                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgThoigiansuachuasai", Commons.Modules.TypeLanguage), Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNM", "frmTGNM", Commons.Modules.TypeLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

            if (grvTGChiTiet.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgBanCoMuonLockTGNM", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            string sSql = null;
            try
            {
                sSql = "UPDATE THOI_GIAN_NGUNG_MAY SET LOCK = 1 WHERE ID IN(SELECT * FROM  dbo.fnGetNguyenNhanNM(" + grvTGChiTiet.GetFocusedDataRow()["ID"].ToString() + "))";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                chkIsLock.Checked = true;
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
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmTGNMNew", "mnuAddMoreRowDownTime", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuAddRow = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuAddRow.Name = "mnuAddRow";
            popup.AddItems(new DevExpress.XtraBars.BarItem[] { mnuAddRow });
            BarManager.EndUpdate();
        }



        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IDNM = -1;
            VisibleControl(false, false);
            EnableControl(true);
            gbLanngungmay.Enabled = false;
            grdTGChiTiet.Enabled = false;
            cboMay.Properties.ReadOnly = true;
            cboTo.Properties.ReadOnly = true;
            dtNgayBD.DateTime = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["DEN_NGAY"].ToString());
            tGioBD.EditValue = Convert.ToDateTime(grvTGChiTiet.GetFocusedDataRow()["DEN_GIO"].ToString()).ToString("HH:mm");
            dtNgayKT.DateTime = DateTime.Now;
            tGioKT.EditValue = DateTime.Now.AddHours(1).ToString("HH:mm");
            chkTiepTuc.Checked = true;
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
                Tinh_THOI_GIAN_SUA();
            }
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            if (grvTHOI_GIAN_DUNG_MAY.RowCount <= 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgBanCoMuonUnLockTGNM", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            string sSql = null;
            try
            {
                sSql = "UPDATE THOI_GIAN_NGUNG_MAY SET LOCK = 0 WHERE ID IN(SELECT * FROM  dbo.fnGetNguyenNhanNM(" + grvTGChiTiet.GetFocusedDataRow()["ID"].ToString() + "))";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                chkIsLock.Checked = false;
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
            Report1.frmNguyenNhanNgungMay frm = new Report1.frmNguyenNhanNgungMay();
            frm.ShowDialog();

            try
            {
                LoadNN();
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

        private void cboLoaiNN_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) return;
            Report1.frmDowtimeType frm = new Report1.frmDowtimeType();
            frm.ShowDialog();
            LoadLoaiNN();
        }


        private void LoadComboCa()
        {
            try
            {
                DataTable dt = new DataTable();
                string str = "SELECT STT, ( CASE '" + Commons.Modules.TypeLanguage.ToString() + "' WHEN 0 THEN CA WHEN 1 THEN ISNULL(CA_ANH, CA) END ) + ' (' + CONVERT(NVARCHAR(5),CAST(TU_GIO AS TIME),108) + ' - ' +  CONVERT(NVARCHAR(5),CAST(DEN_GIO AS TIME),108) + ')' AS TEN_CA FROM CA ORDER BY TU_GIO ";
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCa, dt, "STT", "TEN_CA", "");
            }
            catch
            {
            }
        }

        private void LoadCongNhan()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 3, Commons.Modules.UserName));
                dt.Select().AsEnumerable().ToList().ForEach(x => cboNguoiGiaiQuyet.Properties.Items.Add(x["HO_TEN_CONG_NHAN"]));

                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 6, Commons.Modules.UserName));
                dt.Select().AsEnumerable().ToList().ForEach(x => cboTruongCa.Properties.Items.Add(x["HO_TEN_CONG_NHAN"]));

            }
            catch { }
        }

        private void LoadLoaiNN()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT ID,CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN DownTimeTypeName WHEN 1 THEN DownTimeTypeNameA ELSE DownTimeTypeNameH END AS DownTimeTypeName FROM dbo.DownTimeType"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiNN, dt, "ID", "DownTimeTypeName", "");
            }
            catch
            {
            }
        }

        private void LoadNN()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_NGUYEN_NHAN,CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN TEN_NGUYEN_NHAN ELSE ISNULL(NULLIF(TEN_NGUYEN_NHAN_ANH,''),TEN_NGUYEN_NHAN) END AS TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY WHERE DownTimeTypeID = " + cboLoaiNN.EditValue + " ORDER BY TEN_NGUYEN_NHAN "));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguyenNhan, dt, "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN", "");

                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetPhongBanUserAll", 0, "-1", Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTo, dt, "MS_PB", "TEN_PB", "");
            }
            catch
            {
            }
        }
        private void grvTGChiTiet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            ShowThoiGianNgung(true);
            LoadBoPhanPhuTung();
        }

        private void dtNgayBD_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Visible == true)
                {
                    LoadCa();
                    Tinh_THOI_GIAN_SUA();
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        private void Tinh_THOI_GIAN_SUA()
        {
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;

                DateTime TuNgay = DateTime.Parse(dtNgayBD.DateTime.ToString("dd/MM/yyyy") + " " + tGioBD.Text);
                DateTime DenNgay = DateTime.Parse(dtNgayKT.DateTime.ToString("dd/MM/yyyy") + " " + tGioKT.Text);

                TimeSpan THOI_GIAN_SUA = DenNgay - TuNgay;

                txtTHOI_GIAN_SUA.EditValue = THOI_GIAN_SUA.TotalMinutes;
                txtTHOI_GIAN_SUA_CHUA.EditValue = THOI_GIAN_SUA.TotalMinutes;
            }
            catch { }
        }

        private void cboLoaiNN_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadNN();
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
                    btnEdit.Visible = false;
                    btnThoat.Visible = true;
                    btnXoa.Visible = false;
                    btnKhongghi.Visible = false;
                    btnSave.Visible = false;
                    btnTroVe.Visible = false;
                    btnXoaBoPhan.Visible = false;
                    btnXoaCT.Visible = false;
                    btnTroVe.Visible = false;
                }
                else
                {
                    btnLock.Visible = true;
                    btnUnLock.Visible = false;
                    btnAdd.Visible = true;
                    btnAddPT.Visible = false;
                    btnEdit.Visible = true;
                    btnThoat.Visible = true;
                    btnXoa.Visible = true;
                    btnKhongghi.Visible = false;
                    btnSave.Visible = false;
                    btnTroVe.Visible = false;
                    btnXoaBoPhan.Visible = false;
                    btnXoaCT.Visible = false;
                    btnTroVe.Visible = false;
                }
                LoadLanNgungMay(true);
            }
            catch
            {
            }
        }
    }
}
