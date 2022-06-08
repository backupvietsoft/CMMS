using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraEditors.Repository;
using System.Linq;
using Report1;
using DevExpress.XtraPrinting;
using MVControl;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid.Views.Grid;

namespace Vietsoft.Reminder
{

    public partial class frmReminder_new : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraBars.BarButtonItem mnuPBT = new DevExpress.XtraBars.BarButtonItem();
        DevExpress.XtraBars.BarButtonItem mnuGSTTCN = new DevExpress.XtraBars.BarButtonItem();
        string KhongKho;
        DataTable v_all = new DataTable();
        private bool isChange = false;
        public frmReminder_new()
        {
            InitializeComponent();
            if (Commons.Modules.sPrivate != "REMINGTON")
            {
                TabReminder.TabPages.Remove(TabGSTTBTDK);
            }
        }
        //Load form
        private void frmReminder_Load(object sender, EventArgs e)
        {
            KhongKho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongKho", Commons.Modules.TypeLanguage);
            Commons.Modules.SQLString = "0LOAD";
            isChange = true;
            this.Cursor = Cursors.WaitCursor;
            string s = "";
            try
            {
                Commons.Modules.SQLString = "0LOAD";
                SetDefaullValue();
                s = "1";
                BinDataNX();
                s = "2";
                BinDataHT();
                s = "3";
                BinDataLTB(); s = "4";
                BinDataLHC(); s = "5";
                BinDataLPT(); s = "6";
                BinDataDSYC(); s = "7";
                BinDataGSTT(); s = "8";
                BinDataBTDKGSTT(); s = "9";
                CreateMenuGSTT(gdTSGSTT); s = "10";
                CreateMenuDSYC(GridControlDuyet); s = "11";
                BindMay(cboMay1); s = "12";
                Commons.Modules.SQLString = ""; s = "13";
                BinDataTBDHHC(cboMay1.EditValue.ToString()); s = "14";
                BinDataDCDDHHC(cboMay1.EditValue.ToString()); s = "15";
                Commons.Modules.SQLString = ""; s = "";
                BinDataVTPTSLNHTTT(); s = "";
                this.CboLPT6.EditValueChanged += new System.EventHandler(this.CboLPT6_SelectedValueChanged); s = "";
            }
            catch //(Exception ex)
            {
                //XtraMessageBox.Show(s);
            }

            if (Commons.Modules.sPrivate == "BARIA")
                chkTonTT.Visible = true;
            else
                chkTonTT.Visible = false;
            this.Cursor = Cursors.Default;
            try
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    Commons.Modules.ObjSystems.ThayDoiNN(this);
                }));
            }
            catch
            { }
            CreateMenuGSTT(grdGSTTDenHang);


            DataTable dtTmp = new  DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 2, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguoiLap, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "");

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetCNVaiTroUsers", 3, Commons.Modules.UserName));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNGSat, dtTmp, "MS_CONG_NHAN", "HO_TEN_CONG_NHAN", "");

            cboNguoiLap.EditValue = Commons.Modules.sMaNhanVienMD;
            cboNGSat.EditValue = Commons.Modules.sMaNhanVienMD;
            LoadLogoCTy();
        }

        MemoryStream mem;
        private void LoadLogoCTy()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, System.Data.CommandType.Text, " SELECT LOGO FROM THONG_TIN_CHUNG"));
            Byte[] data = new Byte[0];
            data = (Byte[])(dtTmp.Rows[0][0]);            
            mem = new MemoryStream(data);            
        }

        //Khởi tạo dữ liệu ban đầu
        private void SetDefaullValue()
        {
            DateTime dtNgay, dtDNgay;
            dtNgay = Convert.ToDateTime("01/" + DateTime.Now.Date.Month.ToString() + "/" + DateTime.Now.Date.Year.ToString());
            dtDNgay = dtNgay.AddMonths(1).AddDays(-1);

            TxtTN1.DateTime = dtNgay.Date;
            TxtDN1.DateTime = dtDNgay.Date;

            TxtTN4.DateTime = dtNgay.Date;
            TxtDN4.DateTime = dtDNgay.Date;

            if (Commons.Modules.sPrivate == "VIFON")
            {
                TxtTN5.DateTime = DateTime.Now.Date.AddDays(-10);
                TxtDN5.DateTime = DateTime.Now.Date;
            }
            else {
                TxtTN5.DateTime = dtNgay.Date;
                TxtDN5.DateTime = dtDNgay.Date;

            }
            datTNgay.DateTime = dtNgay.Date;
            datDNgay.DateTime = dtDNgay.Date;

            dtpTNGSTT.DateTime = dtNgay.Date;
            dtpDNGSTT.DateTime = dtDNgay.Date;

            DatTNBTDKGSTT.DateTime = dtNgay.Date;
            DatDNBTDKGSTT.DateTime = dtDNgay.Date;
        }
        //Lấy loại thiết bị
        private void BinDataLTB()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboLTB, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
        }
        //Lấy địa điểm lắp đặt
        private void BinDataNX()
        {
            KiemApp.MLoadCboTreeList(ref CboNX, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            try
            {
                CboNX.SelectedIndex = 1;
            }
            catch
            {
            }
        }
        //Lấy dấy chuyền lắp đặt
        private void BinDataHT()
        {
            KiemApp.MLoadCboTreeList(ref CboHT, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
        }
        //==========================================
        //Thiết bị đến hạn hiệu chuẩn
        //===========================================
        //Lấy loại hiệu chuẩn
        private void BinDataLHC()
        {
            DataTable TbLHC = new DataTable();
            TbLHC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MashjGetLOAI_HIEU_CHUAN"));

            TbLHC.Rows.Add(-1, " < ALL > ");
            TbLHC.DefaultView.Sort = "TEN_LOAI_HIEU_CHUAN";
            TbLHC = TbLHC.DefaultView.ToTable();
            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboLHC1, TbLHC, "MS_LOAI_HIEU_CHUAN", "TEN_LOAI_HIEU_CHUAN", "");
        }


        private void BindMay(DevExpress.XtraEditors.LookUpEdit cboMay)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable TbTB = new DataTable();
                try
                {
                    TbTB.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_MAY", Commons.Modules.UserName, Commons.Modules.TypeLanguage, CboLTB.EditValue,
                            CboNX.EditValue, CboHT.EditValue, "-1", "-1", "-1"));
                    TbTB.Rows.Add("-1", " < ALL > ", "-1");
                    TbTB.DefaultView.Sort = "MS_MAY";
                    TbTB = TbTB.DefaultView.ToTable();


                    Commons.Modules.SQLString = "0LOAD";
                    Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboMay, TbTB, "MS_MAY", "TEN_MAY", "");
                    cboMay.Properties.Columns["MS_MAY1"].Visible = false;
                    cboMay.EditValue = "-1";

                }
                catch { }
                this.Cursor = Cursors.Default;
            }
            catch { }
            Commons.Modules.SQLString = "";
        }

        //Lấy dữ liệu thiết bị đến hạn hiệu chuẩn
        private void BinDataTBDHHC(string MsMay)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (MsMay == "") return;

            this.Cursor = Cursors.WaitCursor;
            DataTable TbTBDHHC = new DataTable();
            try
            {
                TbTBDHHC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_TBDHHC", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                        TxtTN1.DateTime.Date, TxtDN1.DateTime.Date, CboNX.EditValue, CboHT.EditValue,
                        CboLTB.EditValue, MsMay, "-1", "-1", "-1", CboLHC1.EditValue));
                LoadGrid(grdDenHanhieuChuan, grvDenHanhieuChuan, TbTBDHHC);
                grvDenHanhieuChuan.Columns["MS_TINH"].Visible = false;
                grvDenHanhieuChuan.Columns["MS_QUAN"].Visible = false;
                grvDenHanhieuChuan.Columns["MS_DUONG"].Visible = false;
                grvDenHanhieuChuan.Columns["NGAY_HC"].BestFit();
                grvDenHanhieuChuan.Columns["NGAY_HC_KE"].BestFit();
                grvDenHanhieuChuan.Columns["MS_MAY"].Width = 100;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        //Lấy dữ liệu thiết bị đến hạn hiệu chuẩn

        private void BinDataDCDDHHC(string MsMay)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (MsMay == "") return;

            this.Cursor = Cursors.WaitCursor;
            DataTable TbDCDDHHC = new DataTable();
            DataView DtvHC = new DataView();
            try
            {
                TbDCDDHHC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_DCDDHHC", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                        TxtTN1.DateTime.Date, TxtDN1.DateTime.Date, CboNX.EditValue, CboHT.EditValue,
                        CboLTB.EditValue, MsMay, Commons.Modules.UserName, "-1",
                        "-1", "-1", CboLHC1.EditValue));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            LoadGrid(grdDungCuDoDHHC, grvDungCuDoDHHC, TbDCDDHHC);
            grvDungCuDoDHHC.Columns["MS_MAY"].Width = 100;
            grvDungCuDoDHHC.Columns["MS_PT"].Width = 100;
            grvDungCuDoDHHC.Columns["NOI"].Visible = false;

            this.Cursor = Cursors.Default;
        }

        //==========================================
        //Phiếu bảo trì trong ngày
        //===========================================       


        //Lấy dữ liệu phiếu bảo trì trong ngày
        private void BinDataPBTTN(string MsMay)
        {

            if (Commons.Modules.SQLString == "0LOAD") return;
            if (MsMay == "") return;

            this.Cursor = Cursors.WaitCursor;
            DataTable TbPBTTN = new DataTable();
            try
            {
                TbPBTTN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_PBTTN", Commons.Modules.UserName, Commons.Modules.TypeLanguage, CboNX.EditValue, CboHT.EditValue, CboLTB.EditValue, MsMay, "-1", "-1", "-1"));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            LoadGrid(grdPBTTrongNgay, grvPBTTrongNgay, TbPBTTN);
            grvPBTTrongNgay.Columns["MS_MAY"].Width = 100;
            grvPBTTrongNgay.Columns["TEN_MAY"].Width = 300;
            grvPBTTrongNgay.Columns["MS_PHIEU_BAO_TRI"].Width = 130;

            this.Cursor = Cursors.Default;
        }
        //Thay đổi dữ liệu

        //==========================================
        //Phiếu bảo trì quá hạn kết thúc
        //===========================================       

        //Lấy dữ liệu phiếu bảo trì trong ngày
        private void BinDataPBTQHKT(string MsMay)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (MsMay == "") return;

            this.Cursor = Cursors.WaitCursor;
            DataTable TbPBTQHKT = new DataTable();
            try
            {
                TbPBTQHKT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_PBQHKT", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                        CboNX.EditValue, CboHT.EditValue, CboLTB.EditValue, MsMay, "-1", "-1", "-1"));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            LoadGrid(grdPBTQuaHan, grvPBTQuaHan, TbPBTQHKT);

            grvPBTQuaHan.Columns["MS_MAY"].Width = 100;
            grvPBTQuaHan.Columns["TEN_MAY"].Width = 300;
            grvPBTQuaHan.Columns["MS_PHIEU_BAO_TRI"].Width = 130;

            this.Cursor = Cursors.Default;

        }

        //============================
        //Bảo trì định kỳ
        //=============================

        //Lấy bảo trì định kỳ
        private void BinDataBTDK(string MsMay)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (MsMay == "") return;

            this.Cursor = Cursors.WaitCursor;
            DataTable TbBTDK = new DataTable();
            try
            {
                TbBTDK.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKHTT", TxtTN4.DateTime.Date, TxtDN4.DateTime.Date,CboNX.EditValue, CboHT.EditValue,CboLTB.EditValue, "-1", MsMay,Commons.Modules.UserName,Commons.Modules.TypeLanguage,0));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            bool bFi = false;
            TbBTDK.Columns["chkChon"].ReadOnly = false;

            if (grdBTDKCanThucHien.DataSource == null) bFi = true;

            LoadGrid(grdBTDKCanThucHien, grvBTDKCanThucHien, TbBTDK);






            if (bFi)
            {
                //Commons.Modules.ObjSystems.MLoadXtraGrid(grdBTDKCanThucHien, grvBTDKCanThucHien, TbBTDK, true, true, true, true);
                grvBTDKCanThucHien.OptionsBehavior.Editable = true;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvBTDKCanThucHien.Columns)
                {

                    if ( col.FieldName == "chkChon"){
                        col.Width = 50;
                        col.OptionsColumn.AllowEdit = true;
                        col.OptionsColumn.ReadOnly = false;
                        col.OptionsColumn.AllowEdit = true;
                    }
                    else{
                        col.OptionsColumn.AllowEdit = false;
                        col.OptionsColumn.ReadOnly = true;
                        col.OptionsColumn.AllowEdit = false;
                    }

                    col.AppearanceHeader.Options.UseTextOptions = true;
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    col.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKehoachtongthe_odd", col.FieldName, Commons.Modules.TypeLanguage);
                }

                grvBTDKCanThucHien.Columns["Ten_N_XUONG"].Visible = false;
                grvBTDKCanThucHien.Columns["TEN_HE_THONG"].Visible = false;
                grvBTDKCanThucHien.Columns["MS_LOAI_BT"].Visible = false;
                grvBTDKCanThucHien.Columns["THU_TU"].Visible = false;
                grvBTDKCanThucHien.Columns["MUC_UU_TIEN"].Visible = false;
               try
                {
                    DevExpress.XtraGrid.Columns.GridColumn col1 = grvBTDKCanThucHien.Columns["Ten_N_XUONG"];
                    DevExpress.XtraGrid.Columns.GridColumn col2 = grvBTDKCanThucHien.Columns["TEN_HE_THONG"];
                    grvBTDKCanThucHien.OptionsCustomization.AllowGroup = true;

                    grvBTDKCanThucHien.BeginSort();

                    grvBTDKCanThucHien.ClearGrouping();
                    col1.GroupIndex = 0;
                    col2.GroupIndex = 1;
                }
                catch
                {

                }
                finally
                {
                    grvBTDKCanThucHien.EndSort();
                }
            } else
                grdBTDKCanThucHien.DataSource = TbBTDK;

            grvBTDKCanThucHien.ExpandAllGroups();

            this.Cursor = Cursors.Default;
        }

        //=============================
        //Thông số giám sát tình trạng
        //=============================

        //Lấy thông số giám sát tình trạng
        private void BinDataTSGSTTDHKT()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboMay5.Text == "") return;
            this.Cursor = Cursors.WaitCursor;
            DataTable TbTSGSTT = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Connection = conn;
                sqlcommand.CommandTimeout = 999999;
                if (Commons.Modules.sPrivate == "VINAONE")
                {
                    sqlcommand.CommandText = "spGetGSTTVNO";
                }
                else
                {
                    sqlcommand.CommandText = "spGetGSTT";
                }
                sqlcommand.Parameters.AddWithValue("@USERNAME", Commons.Modules.UserName);
                sqlcommand.Parameters.AddWithValue("@LANGUAGE", Commons.Modules.TypeLanguage);
                sqlcommand.Parameters.AddWithValue("@TU_NGAY", TxtTN5.DateTime.Date);
                sqlcommand.Parameters.AddWithValue("@DEN_NGAY", TxtDN5.DateTime.Date);
                sqlcommand.Parameters.AddWithValue("@MS_NHA_XUONG", CboNX.EditValue);
                sqlcommand.Parameters.AddWithValue("@MS_HE_THONG", CboHT.EditValue);
                sqlcommand.Parameters.AddWithValue("@MS_LOAI_MAY", CboLTB.EditValue);
                sqlcommand.Parameters.AddWithValue("@MS_MAY", cboMay5.EditValue);
                sqlcommand.Parameters.AddWithValue("@MS_LOAI_CV", cboLCV.EditValue);
                TbTSGSTT.Load(sqlcommand.ExecuteReader());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            if (grdGSTTDenHang.DataSource == null)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    grdGSTTDenHang.DataSource = TbTSGSTT;
                    try
                    {
                        RepositoryItemMemoEdit repoMemo = new RepositoryItemMemoEdit();
                        repoMemo.WordWrap = true;
                        repoMemo.AutoHeight = true;
                        //repoMemo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        repoMemo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        repoMemo.BeginInit();
                        grdGSTTDenHang.RepositoryItems.Add(repoMemo);
                        foreach (DevExpress.XtraGrid.Columns.GridColumn column in grvGSTTDenHang.Columns)
                        {
                            column.ColumnEdit = repoMemo;
                        }

                    }
                    catch { }
                    Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvGSTTDenHang, this.Name.ToString());
                    grvGSTTDenHang.OptionsView.ColumnAutoWidth = false;
                    grvGSTTDenHang.Columns["STT_BP"].Visible = false;
                    if (Commons.Modules.sPrivate == "VINHHOAN")
                    {
                        grvGSTTDenHang.Columns["STT"].Visible = false;
                        grvGSTTDenHang.Columns["TEN_BO_PHAN"].Visible = false;
                    }
                    try
                    {
                        grvGSTTDenHang.Columns["MS_TS_GSTT"].Visible = false;
                    }
                    catch (Exception) { }
                    grvGSTTDenHang.Columns["CACH_THUC_HIEN"].Visible = false;
                    grvGSTTDenHang.Columns["MS_NHA_XUONG"].Visible = false;
                    grvGSTTDenHang.Columns["MS_HE_THONG"].Visible = false;
                    grvGSTTDenHang.Columns["MS_LOAI_MAY"].Visible = false;
                    grvGSTTDenHang.Columns["MS_MAY_FIL"].Visible = false;
                    grvGSTTDenHang.Columns["MS_LOAI_CV"].Visible = false;
                    grvGSTTDenHang.Columns["DAT"].Visible = false;
                    grvGSTTDenHang.Columns["TNGAY"].Visible = false;
                    grvGSTTDenHang.Columns["DNGAY"].Visible = false;
                    grvGSTTDenHang.Columns["STT"].Width = 40;
                    grvGSTTDenHang.Columns["MS_MAY"].Width = 100;
                    grvGSTTDenHang.Columns["TEN_MAY"].Width = 200;
                    if (Commons.Modules.sPrivate == "REMINGTON")
                    {
                        grvGSTTDenHang.Columns["TEN_BO_PHAN"].Visible = false;
                    }
                    try
                    {
                        grvGSTTDenHang.Columns["TEN_BO_PHAN_CHA"].Width = 250;
                    }
                    catch (Exception)
                    {
                    }
                    grvGSTTDenHang.Columns["TEN_BO_PHAN"].Width = 150;
                    grvGSTTDenHang.Columns["TEN_TS_GSTT"].Width = 250;
                    grvGSTTDenHang.Columns["CHU_KY_DO"].Width = 80;
                    grvGSTTDenHang.Columns["NGAY_KT_CUOI"].Width = 120;
                    grvGSTTDenHang.Columns["TEN_GIA_TRI"].Width = 80;
                    grvGSTTDenHang.Columns["NGAY_KT_KE"].Width = 120;
                    if (Commons.Modules.sPrivate == "VINAONE")
                    {
                        grvGSTTDenHang.Columns["SN"].Visible = false;
                        grvGSTTDenHang.Columns["TINH_TRANG"].Width = 120;
                    }
                    grvGSTTDenHang.Columns["CACH_THUC_HIEN"].Width = 200;
                    grvGSTTDenHang.Columns["THOI_GIAN"].Width = 75;
                    grvGSTTDenHang.Columns["TEN_GT_GSTT"].Width = 200;
                }));
            }
            else
            {
                grdGSTTDenHang.DataSource = TbTSGSTT;
            }
            LocDK();
            this.Cursor = Cursors.Default;
        }
        private void BinDataLPT()
        {
            DataTable TbLPT = new DataTable();
            TbLPT.Columns.Add("VALUE", typeof(int));
            TbLPT.Columns.Add("DISLAY");
            TbLPT.Rows.Add(-1, " < ALL > ");
            switch (Commons.Modules.TypeLanguage)
            {
                case 1:
                    TbLPT.Rows.Add(1, "Material");
                    TbLPT.Rows.Add(0, "Spare part");
                    break;
                case 2:
                    TbLPT.Rows.Add(1, "Material");
                    TbLPT.Rows.Add(0, "Spare part");
                    break;
                default:
                    TbLPT.Rows.Add(1, "Vật tư");
                    TbLPT.Rows.Add(0, "Phụ tùng");
                    break;
            }
            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboLPT6, TbLPT, "VALUE", "DISLAY", "");
            try
            {
                DataTable dtKho = new DataTable();

                dtKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_KHOs"));
                dtKho.Rows.Add(-1, " < ALL > ");
                dtKho.Rows.Add(0, " < Khong Kho > ");
                dtKho.DefaultView.Sort = "TEN_KHO ASC";
                dtKho = dtKho.DefaultView.ToTable();

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, dtKho, "MS_KHO", "TEN_KHO", "");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        //lấy danh sách yêu cầu
        private void BinDataDSYC()
        {
            try
            {
                if (Commons.Modules.SQLString == "0LOAD") return;
                
                try
                {
                    string filename = System.IO.Path.Combine(Directory.GetCurrentDirectory() + @"\reports\images", "attachment.jpg");
                    byte[] img = System.IO.File.ReadAllBytes(filename);
                    DataTable DSYeuCau = new DataTable();
                    DSYeuCau.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_TinhHinhYeuCauBT", 0, Commons.Modules.UserName, Commons.Modules.TypeLanguage, "Chưa xem xét", img, datTNgay.EditValue, datDNgay.EditValue, CboNX.EditValue, CboLTB.EditValue));

                    Commons.Modules.ObjSystems.MLoadXtraGrid(GridControlDuyet, GridViewDuyet, DSYeuCau, false, false, false, true, true, this.Name);
                    GridViewDuyet.Columns["CHON"].Width = 100;
                    RepositoryItemPictureEdit imgTaiLieu = new RepositoryItemPictureEdit();
                    imgTaiLieu.NullText = " ";
                    GridViewDuyet.Columns["TAI_LIEU"].ColumnEdit = imgTaiLieu;
                    GridViewDuyet.Columns["TAI_LIEU"].OptionsColumn.AllowEdit = false;
                    GridViewDuyet.Columns["TAI_LIEU"].OptionsColumn.AllowFocus = false;
                    GridViewDuyet.Columns["TAI_LIEU"].OptionsColumn.AllowSize = false;
                    GridViewDuyet.Columns["NGAY_DBT"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                    GridViewDuyet.Columns["MS_YEU_CAU"].OptionsColumn.FixedWidth = true;
                    GridViewDuyet.Columns["SO_YEU_CAU"].OptionsColumn.FixedWidth = true;
                    GridViewDuyet.Columns["NGAY_DBT"].OptionsColumn.FixedWidth = true;
                    GridViewDuyet.Columns["NGAY_BD_KH"].OptionsColumn.FixedWidth = true;
                    GridViewDuyet.Columns["NGAY_KT_KH"].OptionsColumn.FixedWidth = true;
                }
                catch
                { }
                GridViewDuyet.Columns["MS_YEU_CAU"].OptionsColumn.FixedWidth = true;
                GridViewDuyet.Columns["MS_MAY"].OptionsColumn.FixedWidth = true;
                GridViewDuyet.Columns["SO_YEU_CAU"].OptionsColumn.FixedWidth = true;
                GridViewDuyet.Columns["NGAY_DBT"].OptionsColumn.FixedWidth = true;
                GridViewDuyet.Columns["NGAY_BD_KH"].OptionsColumn.FixedWidth = true;
                GridViewDuyet.Columns["NGAY_KT_KH"].OptionsColumn.FixedWidth = true;
                GridViewDuyet.Columns["TAI_LIEU"].Width = 55;
                GridViewDuyet.Columns["MS_MAY"].Width = 100;
                GridViewDuyet.Columns["TEN_MAY"].Width = 130;
                GridViewDuyet.Columns["MO_TA_TINH_TRANG"].Width = 320;
                GridViewDuyet.Columns["YEU_CAU"].Width = 320;
                GridViewDuyet.Columns["TEN_LOAI_YEU_CAU_BT"].Width = 120;
                GridViewDuyet.Columns["TEN_NGUYEN_NHAN"].Width = 120;
                GridViewDuyet.Columns["TEN_UU_TIEN"].Width = 98;
                GridViewDuyet.Columns["MS_YEU_CAU"].Width = 120;
                GridViewDuyet.Columns["CHON"].Visible = false;
                GridViewDuyet.Columns["STT"].Visible = false;
                GridViewDuyet.Columns["STT_VAN_DE"].Visible = false;
                GridViewDuyet.Columns["MS_UU_TIEN"].Visible = false;
                GridViewDuyet.Columns["MS_CACH_TH"].Visible = false;
                GridViewDuyet.Columns["MS_CONG_NHAN"].Visible = false;
                GridViewDuyet.Columns["TINH_TRANG_PBT"].Visible = false;
                GridViewDuyet.Columns["HANG_MUC_ID_KE_HOACH"].Visible = false;
                // GridViewDuyet.Columns["MS_YEU_CAU"].Visible = False
                GridViewDuyet.Columns["SO_YEU_CAU"].Visible = false;
                GridViewDuyet.Columns["Ten_N_XUONG"].Visible = false;
                GridViewDuyet.Columns["MS_CACH_TH"].Visible = false;
                GridViewDuyet.Columns["TEN_TIENG_VIET"].Visible = false;
                GridViewDuyet.Columns["TEN_HANG_MUC"].Visible = false;
                GridViewDuyet.Columns["MS_PBT"].Visible = false;
                GridViewDuyet.Columns["EMAIL_DBT"].Visible = false;
                GridViewDuyet.Columns["MS_CONG_NHAN"].Visible = false;
                GridViewDuyet.Columns["NGUOI_PHU_TRACH"].Visible = false;
                GridViewDuyet.Columns["TEN_TINH_TRANG"].Visible = false;
                GridViewDuyet.Columns["USERNAME_DSX"].Visible = false;
                GridViewDuyet.Columns["THOI_GIAN_DSX"].Visible = false;
                GridViewDuyet.Columns["Y_KIEN_DSX"].Visible = false;
                GridViewDuyet.Columns["USERNAME_DBT"].Visible = false;
                GridViewDuyet.Columns["NGAY_DBT"].Visible = false;
                GridViewDuyet.Columns["Y_KIEN_DBT"].Visible = false;
                //GridViewDuyet.Columns["NGAY_GIO_YEU_CAU"].Visible = false;
                GridViewDuyet.Columns["NGAY_BD_KH"].Visible = false;
                GridViewDuyet.Columns["NGAY_KT_KH"].Visible = false;
            }
            catch //(Exception ex)
            {
                //XtraMessageBox.Show(ex.Message);
            }

        }

        private void CreateMenuDSYC(DevExpress.XtraGrid.GridControl grd)
        {
            DevExpress.XtraBars.BarManager BarManager = new DevExpress.XtraBars.BarManager();
            BarManager.Form = grd;
            BarManager.ItemClick += BarManager_ItemClick;
            BarManager.BeginUpdate();
            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(BarManager);
            BarManager.SetPopupContextMenu(grd, popup);
            string sStr;
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReminder_new", "mnuHyperLinkmnuDSYC", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuDSYC = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuDSYC.Name = "mnuDSYC";
            popup.AddItems(new DevExpress.XtraBars.BarItem[] { mnuDSYC });
            BarManager.EndUpdate();

        }

        private void CreateMenuGSTT(DevExpress.XtraGrid.GridControl grd)
        {
            DevExpress.XtraBars.BarManager BarManager = new DevExpress.XtraBars.BarManager();
            BarManager.Form = grd;
            BarManager.ItemClick += BarManager_ItemClick;
            BarManager.BeginUpdate();
            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(BarManager);
            BarManager.SetPopupContextMenu(grd, popup);
            //AddHandler popup.BeforePopup, AddressOf popupMenu1_BeforePopup
            popup.BeforePopup += popupMenu1_BeforePopup;

            string sStr;
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTT", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuGSTT = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuGSTT.Name = "mnuGSTT";



            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTTCNhap", Commons.Modules.TypeLanguage);
            mnuGSTTCN = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuGSTTCN.Name = "mnuGSTTCN";

            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkPhieuBaoTri", Commons.Modules.TypeLanguage);
            //DevExpress.XtraBars.BarButtonItem mnuPBT = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuPBT = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuPBT.Name = "mnuPBT";


            popup.AddItems(new DevExpress.XtraBars.BarItem[] { mnuGSTT, mnuGSTTCN, mnuPBT });
            BarManager.EndUpdate();





        }
        private void BarManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmYeuCauBT frmYeuCauBaoTri = new frmYeuCauBT();
            DevExpress.XtraBars.BarSubItem subMenu = e.Item as DevExpress.XtraBars.BarSubItem;
            DevExpress.XtraBars.BarManager barMenu = sender as DevExpress.XtraBars.BarManager;
            DevExpress.XtraGrid.GridControl grd = this.Controls.Find(barMenu.Form.Name, true).FirstOrDefault() as DevExpress.XtraGrid.GridControl;
            DevExpress.XtraGrid.Views.Grid.GridView grv = grd.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            DataTable dt = new DataTable();
            try
            {
                switch (e.Item.Name.ToUpper().ToString())
                {
                    case "MNUMAY":
                        {
                            Commons.Hyperlink.ToMay(this, grv.GetFocusedRowCellValue("MS_MAY").ToString());
                            break;
                        }
                    case "MNUPBTBTDK":
                        {
                            LapPBTBTDK();
                            break;
                        }
                    case "MNUGSTT":
                        {
                            Commons.Hyperlink.ToGSTT(this, grv.GetFocusedRowCellValue("MS_TS_GSTT").ToString());
                            break;
                        }
                    case "MNUGSTTCN":
                        {
                            Point ptChung;
                            ptChung = grv.GridControl.PointToClient(Control.MousePosition);
                            if (grv.RowCount == 0) return;
                            DoRowDoubleClick(grv, ptChung);
                            break;
                        }
                    case "MNUPBT":
                        {
                            if (optGQGSTT.SelectedIndex == 2)
                            {
                                Commons.Hyperlink.ToPhieuBaoTri(this, grv.GetFocusedRowCellValue("MS_PBT").ToString());
                                return;
                            }
                            LapPBTGSTT();
                            break;
                        }
                    case "MNUDSYC":
                        {
                            string str = "select * from NHOM_MENU WHERE MENU_ID = N'mnuYeucauNSD_DBT' AND GROUP_ID = (SELECT GROUP_ID FROM USERS WHERE USERNAME = '" + Commons.Modules.UserName + "')";
                            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                            if ((dt.Rows.Count == 0))
                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "MsgNotMenu", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, frmYeuCauBaoTri.Name);
                            string sMaSo = "";
                            sMaSo = grv.GetFocusedRowCellValue("MS_MAY").ToString();
                            frmYeuCauBaoTri.stt = grv.GetFocusedRowCellValue("STT").ToString();
                            frmYeuCauBaoTri.sttVanDe = grv.GetFocusedRowCellValue("STT_VAN_DE").ToString();
                            frmYeuCauBaoTri.msmay = sMaSo;
                            frmYeuCauBaoTri.fromday = Convert.ToDateTime(grv.GetFocusedRowCellValue("NGAY_GIO_YEU_CAU").ToString()).AddDays(-1);
                            frmYeuCauBaoTri.today = Convert.ToDateTime(grv.GetFocusedRowCellValue("NGAY_GIO_YEU_CAU").ToString());
                            frmMain.ShowForm(frmYeuCauBaoTri);
                            break;
                        }
                }
            }
            catch
            { }
        }

        private void popupMenu1_BeforePopup(object sender, System.EventArgs e)
        {

            DevExpress.XtraBars.PopupMenu popup = sender as DevExpress.XtraBars.PopupMenu;
            //DevExpress.XtraBars.PopupMenu popup = sender as  DevExpress.XtraBars.PopupMenu();


            if (Commons.Modules.PermisString.Equals("Read only"))
                return;
            //bo qua
            if (optGQGSTT.SelectedIndex == 1)
                popup.ItemLinks[2].Item.Enabled = false;
            else
                popup.ItemLinks[2].Item.Enabled = true;

            //da giai quyet
            if (optGQGSTT.SelectedIndex == 2)
                popup.ItemLinks[2].Item.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkPhieuBaoTri", Commons.Modules.TypeLanguage);
            else
                popup.ItemLinks[2].Item.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkLapPhieuBaoTri", Commons.Modules.TypeLanguage);

            //chua giai quyet
            if (optGQGSTT.SelectedIndex == 0)
                popup.ItemLinks[1].Item.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkmnuGSTTCNhap", Commons.Modules.TypeLanguage);
            else
                popup.ItemLinks[1].Item.Caption = optGQGSTT.Properties.Items[0].Description;
        }

        private void LapPBTGSTT()
        {
            Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "FrmPhieuBaoTri_New");

            if (Commons.Modules.PermisString.Equals("Read only")) return;

            gvTSGSTT.UpdateCurrentRow();
            DataTable dtTmp = new DataTable();
            DataTable dtLuoi = new DataTable();
            dtLuoi = (DataTable)gdTSGSTT.DataSource;
            dtTmp = dtLuoi.Copy();

            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();

            if (dtTmp.Rows.Count < 1)
            {

                if (Convert.ToBoolean(gvTSGSTT.GetFocusedRowCellValue("CHON").ToString()) == false)
                {
                    gvTSGSTT.SetFocusedRowCellValue("CHON", 1);
                    gvTSGSTT.UpdateCurrentRow();
                }
                dtTmp = new DataTable();
                dtLuoi = new DataTable();
                dtLuoi = (DataTable)gdTSGSTT.DataSource;
                dtTmp = dtLuoi.Copy();

                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count < 1)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonGiamSatCanThucHien", Commons.Modules.TypeLanguage));
                    return;
                }

            }

            if (dtTmp.Rows.Count < 1)
            {
                if (Convert.ToBoolean(gvTSGSTT.GetFocusedRowCellValue("CHON").ToString()) == false)
                {
                    gvTSGSTT.SetFocusedRowCellValue("CHON", 1);
                    gvTSGSTT.UpdateCurrentRow();
                }
                dtTmp = new DataTable();
                dtLuoi = (DataTable)gdTSGSTT.DataSource;
                dtLuoi.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtLuoi.DefaultView.ToTable().Copy();
                dtLuoi.DefaultView.RowFilter = "";
                if (dtTmp.Rows.Count < 1)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonGiamSatCanThucHien", Commons.Modules.TypeLanguage));
                    return;
                }
            }

            dtLuoi = new DataTable();
            dtLuoi = dtTmp.DefaultView.ToTable(true, "MS_MAY", "NGAY_GIO_KT_MAX");
            if (dtLuoi.Rows.Count > 1)
            {
                Commons.MssBox.Show(this.Name, "msgCoTren2MayHayNgayKiemTra");
                return;
            }

            AddsbtChonTS();
            Report1.frmLapphieubaotri_CS frm = new frmLapphieubaotri_CS();
            frm.MS_MAY = gvTSGSTT.GetFocusedRowCellValue("MS_MAY").ToString();
            frm.bCoCV = true;
            frm.bLockMSMay = true;
            frm.iMsLoaiBT = 3;
            string sLyDo = "";
            if (Commons.Modules.sPrivate == "VIFON")
            {
                foreach (DataRow dr in dtTmp.Rows)
                {
                    sLyDo = sLyDo + dr["TEN_BO_PHAN"].ToString() + " : " + dr["TEN_TS_GSTT"].ToString() +
                        (string.IsNullOrEmpty(dr["GT_DT"].ToString()) ? "" : " - " + dr["GT_DT"].ToString()) +
                        (string.IsNullOrEmpty(dr["GT_DL"].ToString()) ? "" : " - " + dr["GT_DL"].ToString()) + ". ";
                }
            }
            else
            {
                foreach (DataRow dr in dtTmp.Rows)
                {
                    sLyDo = gvTSGSTT.Columns["TEN_TS_GSTT"].Caption + "-" + dr["TEN_TS_GSTT"].ToString() + ", " +
                        (string.IsNullOrEmpty(dr["GT_DT"].ToString()) ? "" : " " + gvTSGSTT.Columns["GT_DT"].Caption + "-" + dr["GT_DT"].ToString()) +
                        (string.IsNullOrEmpty(dr["GT_DL"].ToString()) ? "" : " " + gvTSGSTT.Columns["GT_DL"].Caption + "-" + dr["GT_DL"].ToString()) + ". ";
                }
            }

            if (sLyDo.Length > 5000)
            {
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgLyDoBaoTriQuaDai"), this.Text, MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            else
                frm.sLyDo = sLyDo;


            if (frm.ShowDialog() != DialogResult.OK) return;
            string sNHTH = "", sSql = "";
            string sPBT = Commons.Modules.SQLString;
            foreach (DataRow dr in dtTmp.Rows)
            {
                try
                {
                    if (String.IsNullOrEmpty(dr["GT_DT"].ToString()) || String.IsNullOrEmpty(dr["STT_GT"].ToString()) ||
                                    String.IsNullOrEmpty(dr["STT_GT"].ToString().Trim().ToString()))
                    {
                        sSql = "UPDATE GIAM_SAT_TINH_TRANG_TS SET MS_PBT='" + sPBT + "',MS_CACH_TH='04', " +
                                    " USERNAME='" + Commons.Modules.UserName + "',MS_CONG_NHAN='" + sNHTH + "',  " +
                                    " TG_XU_LY= GETDATE() WHERE STT=" + dr["STT"].ToString() + " AND MS_MAY=N'" + dr["MS_MAY"].ToString() + "' " +
                                    " AND MS_TS_GSTT='" + dr["MS_TS_GSTT"].ToString() + "' AND MS_BO_PHAN = N'" + dr["MS_BO_PHAN"].ToString() + "' ";
                    }
                    else
                    {
                        sSql = "UPDATE GIAM_SAT_TINH_TRANG_TS_DT SET MS_PBT='" + sPBT + "',MS_CACH_TH='04', " +
                                " USERNAME='" + Commons.Modules.UserName + "',MS_CONG_NHAN='" + sNHTH + "', " +
                                " TG_XU_LY= GETDATE() WHERE STT=" + dr["STT"].ToString() + " AND MS_MAY=N'" + dr["MS_MAY"].ToString() + "'  " +
                                " AND MS_TS_GSTT='" + dr["MS_TS_GSTT"].ToString() + "' AND MS_BO_PHAN = N'" + dr["MS_BO_PHAN"].ToString() + "' " +
                                " AND STT_GT=" + dr["STT_GT"].ToString();
                    }
                }
                catch { }
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                Commons.Modules.SQLString = "";
                dtpTNGSTT_EditValueChanged(null, null);
            }
        }

        private void LapPBTBTDK()
        {
            Commons.Modules.PermisString = Commons.Modules.ObjGroups.GetNHOM_FORM_QUYEN(Commons.Modules.UserName, "FrmPhieuBaoTri_New");

            if (Commons.Modules.PermisString.Equals("Read only")) return;
            try
            {
                grvBTDKCanThucHien.UpdateCurrentRow();
                DataTable dtTmp = new DataTable();
                DataTable dtLuoi = new DataTable();
                dtLuoi = (DataTable)grdBTDKCanThucHien.DataSource;
                dtTmp = dtLuoi.Copy();

                dtTmp.DefaultView.RowFilter = "chkChon = 1";
                dtTmp = dtTmp.DefaultView.ToTable();

                if (dtTmp.Rows.Count < 1)
                {
                    try
                    {
                        if (Convert.ToBoolean(grvBTDKCanThucHien.GetFocusedRowCellValue("chkChon").ToString()) == false)
                        {
                            grvBTDKCanThucHien.SetFocusedRowCellValue("chkChon", 1);
                            grvBTDKCanThucHien.UpdateCurrentRow();
                        }
                    }
                    catch { }


                    dtTmp = new DataTable();
                    dtLuoi = new DataTable();
                    dtLuoi = (DataTable)grdBTDKCanThucHien.DataSource;
                    dtTmp = dtLuoi.Copy();

                    dtTmp.DefaultView.RowFilter = "chkChon = 1";
                    dtTmp = dtTmp.DefaultView.ToTable();
                    if (dtTmp.Rows.Count < 1)
                    {
                        Commons.MssBox.Show("frmKehoachtongthe_odd", "MsgQuyenKT22");
                        return;
                    }

                }
                if (string.IsNullOrEmpty(cboNguoiLap.Text))
                {
                    Commons.MssBox.Show("frmKehoachtongthe_odd", "msgChuaChonNguoiLap");
                    return;
                }
                if (string.IsNullOrEmpty(cboNGSat.Text))
                {
                    Commons.MssBox.Show("frmKehoachtongthe_odd", "msgChuaChonNguoiGiamSat");
                    return;
                }
                try
                {
                    Cursor = Cursors.WaitCursor;
                    if (Commons.Modules.ObjSystems.LapBPTDinhKy(dtTmp, cboNguoiLap.EditValue.ToString(), cboNGSat.EditValue.ToString()))
                    {
                        BinDataBTDK(cboMay4.EditValue.ToString());
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKehoachtongthe_odd", "msgLapPhieuBaoTriKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), "frmKehoachtongthe_odd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmKehoachtongthe_odd", "msgLapPhieuBaoTriKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), "frmKehoachtongthe_odd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Commons.Modules.SQLString = "";
            Cursor = Cursors.Default;


        }

        private void AddsbtChonTS()
        {
            string sbt = "TEMPT" + Commons.Modules.UserName;
            try
            {
                Commons.Modules.ObjSystems.XoaTable(sbt);
            }
            catch
            { }
            DataTable tempt = new DataTable();
            tempt = (DataTable)gdTSGSTT.DataSource;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sbt, tempt, "");
        }

        //lấy thông số giám sát không đạt
        private void BinDataGSTT()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboMayGSTT.Text == "") return;
            this.Cursor = Cursors.WaitCursor;
            DataTable dtTable = new DataTable();
            // chua giai quyet
            try
            {

                dtTable.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                            "spGetGiamSatKhongDat", CboNX.EditValue.ToString(), CboHT.EditValue, CboLTB.EditValue, "-1", cboMayGSTT.EditValue, optGQGSTT.SelectedIndex + 1, dtpTNGSTT.DateTime.Date, dtpDNGSTT.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                dtTable.Columns["CHON"].ReadOnly = false;
                if (gdTSGSTT.DataSource is null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(gdTSGSTT, gvTSGSTT, dtTable, true, false, true, true, true, this.Name);
                    for (int i = 1; i < gvTSGSTT.Columns.Count; i++)
                        gvTSGSTT.Columns[i].OptionsColumn.AllowEdit = false;
                    gvTSGSTT.Columns["CHON"].OptionsColumn.AllowEdit = true;
                }
                else
                    gdTSGSTT.DataSource = dtTable;
            }
            catch
            { }



            this.Cursor = Cursors.Default;
            gvTSGSTT.Columns["MS_CACH_TH"].Visible = false;
            gvTSGSTT.Columns["MS_TS_GSTT"].Visible = false;
            gvTSGSTT.Columns["MS_CONG_NHAN"].Visible = false;
            gvTSGSTT.Columns["MS_BO_PHAN"].Visible = false;
            gvTSGSTT.Columns["STT"].Visible = false;
            gvTSGSTT.Columns["MS_TT"].Visible = false;
            gvTSGSTT.Columns["STT_GT"].Visible = false;
            //gvTSGSTT.Columns["CHON"].Visible = false;
            gvTSGSTT.Columns["NGAY_GIO_KT_MAX"].DisplayFormat.FormatString = "MM/dd/yyyy";
            gvTSGSTT.Columns["NGAY_GIO_KT_MAX"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
        }
        //danh sách giám sát tình trạng bảo trì định kỳ
        private void BinDataBTDKGSTT()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboMayGSTTBTDK.Text == "") return;

            this.Cursor = Cursors.WaitCursor;
            grdGSTTBTDK.DataSource = null;
            grvGSTTBTDK.Columns.Clear();
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Connection = conn;
                sqlcommand.CommandTimeout = 999999;
                sqlcommand.CommandText = "spGetGSTTBTDK";
                sqlcommand.Parameters.AddWithValue("@NGAY_BAT_DAU", DatTNBTDKGSTT.DateTime.Date);
                sqlcommand.Parameters.AddWithValue("@NGAY_KET_THUC", DatDNBTDKGSTT.DateTime.Date);
                sqlcommand.Parameters.AddWithValue("@MS_NHA_XUONG", CboNX.EditValue);
                sqlcommand.Parameters.AddWithValue("@MsHThong", CboHT.EditValue);
                sqlcommand.Parameters.AddWithValue("@MsLMay", CboLTB.EditValue);
                sqlcommand.Parameters.AddWithValue("@MsMay", cboMayGSTTBTDK.EditValue);
                sqlcommand.Parameters.AddWithValue("@MS_LOAI_CV", -1);
                sqlcommand.Parameters.AddWithValue("@iLoaiIn", -1);
                sqlcommand.Parameters.AddWithValue("@USERNAME", Commons.Modules.UserName);
                sqlcommand.Parameters.AddWithValue("@TYPELANG", Commons.Modules.TypeLanguage);
                sqlcommand.Parameters.AddWithValue("@LoaiBC", rdoBaoCao.SelectedIndex);
                //@USERNAME NVARCHAR(50) = 'admin',
                //@TYPELANG INT = 0,
                //@LoaiBC INT = 1
                //dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetGSTTBTDK", DatTNBTDKGSTT.DateTime.Date, DatDNBTDKGSTT.DateTime.Date, CboNX.EditValue, CboHT.EditValue, CboLTB.EditValue, cboMayGSTTBTDK.EditValue, -1, -1, Commons.Modules.UserName, Commons.Modules.TypeLanguage,rdoBaoCao.SelectedIndex));
                dt.Load(sqlcommand.ExecuteReader());
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                }
                if (rdoBaoCao.SelectedIndex == 0)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdGSTTBTDK, grvGSTTBTDK, dt, false, false, false, true, true, this.Name);
                    grvGSTTBTDK.Columns["STT"].Width = 50;
                    grvGSTTBTDK.Columns["MS_MAY"].Width = 100;
                    grvGSTTBTDK.Columns["TEN_MAY"].Width = 150;
                    grvGSTTBTDK.Columns["TEN_BO_PHAN"].Width = 150;
                    grvGSTTBTDK.Columns["TEN_TS_GSTT"].Width = 150;
                    grvGSTTBTDK.Columns["TEN_GT_GSTT"].Width = 120;
                    grvGSTTBTDK.Columns["CHU_KY_DO"].Width = 70;
                    grvGSTTBTDK.Columns["NGAY_KT_CUOI"].Width = 120;
                    grvGSTTBTDK.Columns["NGAY_KT"].Width = 100;
                    grvGSTTBTDK.Columns["TG_TH"].Width = 100;
                    grvGSTTBTDK.Columns["NGUOI_TH"].Width = 140;
                    grvGSTTBTDK.Columns["XN_DVSD"].Width = 120;
                    grvGSTTBTDK.Columns["GHI_CHU"].Width = 100;
                    RepositoryItemMemoEdit meno = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                    meno.WordWrap = true;
                    meno.AutoHeight = true;
                    meno.BeginInit();
                    grvGSTTBTDK.Columns["TEN_TS_GSTT"].ColumnEdit = meno;
                    grvGSTTBTDK.Columns["TEN_MAY"].ColumnEdit = meno;
                    grvGSTTBTDK.Columns["TEN_BO_PHAN"].ColumnEdit = meno;
                    grdGSTTBTDK.RepositoryItems.Add(meno);
                }
                else
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdGSTTBTDK, grvGSTTBTDK, dt, false, false, false, true, true, this.Name);
                    grvGSTTBTDK.Columns["STT"].Width = 50;
                    grvGSTTBTDK.Columns["MS_MAY"].Width = 100;
                    grvGSTTBTDK.Columns["TEN_MAY"].Width = 150;
                    grvGSTTBTDK.Columns["LOAI_BT"].Width = 100;
                    grvGSTTBTDK.Columns["CHU_KY_DO"].Width = 120;
                    grvGSTTBTDK.Columns["NGAY_KT_CUOI"].Width = 120;
                    grvGSTTBTDK.Columns["NGAY_KT_KE"].Width = 120;
                    grvGSTTBTDK.Columns["Ten_N_XUONG"].Width = 100;
                    grvGSTTBTDK.Columns["TEN_HE_THONG"].Width = 100;
                    grvGSTTBTDK.Columns["TEN_NHOM_MAY"].Width = 100;
                    grvGSTTBTDK.Columns["NGAY_DUA_VAO_SD"].Width = 150;
                    grvGSTTBTDK.Columns["GHI_CHU"].Width = 100;
                    RepositoryItemMemoEdit meno = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                    meno.WordWrap = true;
                    meno.AutoHeight = true;
                    meno.BeginInit();
                    grvGSTTBTDK.Columns["TEN_MAY"].ColumnEdit = meno;
                    grdGSTTBTDK.RepositoryItems.Add(meno);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        //Lấy bảo trì định kỳ
        private void BinDataVTPTSLNHTTT()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboKho.Text == "") return;
            if (cboKho.Properties.DataSource == null) return;

            this.Cursor = Cursors.WaitCursor;
            DataTable TbVTPTSLNHTTT = new DataTable();
            try
            {
                if (Commons.Modules.sPrivate == "BARIA")
                {
                    TbVTPTSLNHTTT = TonTheoBaria();
                }
                else
                {
                    TbVTPTSLNHTTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_VTPT_SLNH_SLTTT",
                        Commons.Modules.TypeLanguage, CboLPT6.EditValue, KhongKho, cboKho.EditValue, Commons.Modules.UserName));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            string sDK = "";
            LocDataTonBaria(out sDK);
            TbVTPTSLNHTTT.DefaultView.RowFilter = sDK;
            TbVTPTSLNHTTT = TbVTPTSLNHTTT.DefaultView.ToTable();
            LoadGrid(grdVTPT, grvVTPT, TbVTPTSLNHTTT);
            grvVTPT.Columns["MS_PT"].Width = 100;
            grvVTPT.Columns["TEN_PT"].Width = 250;
            grvVTPT.Columns["MS_KHO"].Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void CboLPT6_SelectedValueChanged(object sender, EventArgs e)
        {
            BinDataVTPTSLNHTTT();
        }
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            string sTDe = "";
            string sTL = "";
            string sTGian = "";
            string n = TabReminder.SelectedTabPage.Name;
            switch (n)
            {
                case "TabPTBDHHC":
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "TIEU_DE", Commons.Modules.TypeLanguage) ;
                    sTL = "DHHC";
                    sTGian = LabTN1.Text + " : " + TxtTN1.Text + "   " + LabDN1.Text + " : " + TxtDN1.Text;
                    break;
                case "TabPPBTTN":
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "TIEU_DE", Commons.Modules.TypeLanguage);
                    sTL = "BTTN";
                    sTGian = DateTime.Now.Date.ToShortDateString();
                    break;
                case "TabPPBTQHKT":
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "TIEU_DE", Commons.Modules.TypeLanguage);
                    sTL = "QHKT";
                    sTGian = "";
                    break;
                case "TabPBTDKCTH":
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TIEU_DE", Commons.Modules.TypeLanguage);
                    sTGian = LabTN4.Text + " : " + TxtTN4.Text + "   " + LabDN4.Text + " : " + TxtDN4.Text;
                    sTL = "BTCTH";
                    break;
                case "TabPGSTTDHKT":
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage);
                    sTGian = LabTN5.Text + " : " + TxtTN5.Text + "   " + LabDN5.Text + " : " + TxtDN5.Text;
                    sTL = "DHKT";
                    break;
                case "TabPVTPTSLNTTT":
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TIEU_DE", Commons.Modules.TypeLanguage);
                    sTGian = "";
                    sTL = "TTT";
                    break;
                case "tabGSTTKD":
                    sTDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptGIAM_SAT_TINH_TINH_TRANG_KHONG_DAT", "TIEU_DE", Commons.Modules.TypeLanguage);
                    sTL = "TSKD";
                    break;
            }

            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 16, FontStyle.Bold);

            
            if (sTGian == "")
            {
                RectangleF rec11 = new RectangleF(150, 10, e.Graph.ClientPageSize.Width - 350, 40);
                e.Graph.DrawString(sTDe, Color.Black, rec11, BorderSide.None);
                
            }
            else {
                RectangleF rec11 = new RectangleF(150, 0, e.Graph.ClientPageSize.Width - 350, 40);
                e.Graph.DrawString(sTDe, Color.Black, rec11, BorderSide.None);

                e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 14, FontStyle.Bold);
                RectangleF rec12 = new RectangleF(150, 25, e.Graph.ClientPageSize.Width - 350, 40);
                e.Graph.DrawString(sTGian, Color.Black, rec12, BorderSide.None);
            }
            
            RectangleF rec1 = new RectangleF(0, 0, 150, 50);
            e.Graph.DrawImage(Image.FromStream(mem), rec1);

            RectangleF rec2 = new RectangleF(e.Graph.ClientPageSize.Width - 180, 0, 200, 15);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 9, FontStyle.Italic);
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "sSTL" + sTL), Color.Black, rec2, BorderSide.None);

            RectangleF rec3 = new RectangleF(e.Graph.ClientPageSize.Width - 180, 15, 200, 15);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 9, FontStyle.Italic);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sPhienBan" + sTL, Commons.Modules.TypeLanguage), Color.Black, rec3, BorderSide.None);

            RectangleF rec4 = new RectangleF(e.Graph.ClientPageSize.Width - 180, 30, 200, 15);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 9, FontStyle.Italic);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sNgayApDung" + sTL, Commons.Modules.TypeLanguage), Color.Black, rec4, BorderSide.None);



        }

        private void InReportBTDK(DevExpress.XtraGrid.Views.Grid.GridView grv, DevExpress.XtraGrid.GridControl grd)
        {
            try
            {
                grv.Columns[0].Visible = false;
                CompositeLink composLink = new CompositeLink(new PrintingSystem());
                composLink.Margins.Left = 50;
                composLink.Margins.Right = 50;
                composLink.Margins.Top = 80;
                composLink.Margins.Bottom = 50;
                composLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
                composLink.Landscape = true;
                composLink.Margins.Clone();

                string leftColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sTrang", Commons.Modules.TypeLanguage) + "[Page # of Pages #]";
                string middleColumn = "User: " + Commons.Modules.UserName;
                string rightColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sNgayIn", Commons.Modules.TypeLanguage) + "[Date Printed]";

                // Create a PageHeaderFooter object and initializing it with
                // the link's PageHeaderFooter.
                PageHeaderFooter phf = composLink.PageHeaderFooter as PageHeaderFooter;

                // Clear the PageHeaderFooter's contents.
                phf.Footer.Content.Clear();

                // Add custom information to the link's header.
                phf.Footer.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
                phf.Footer.LineAlignment = BrickAlignment.Far;

                PageHeaderArea header = new PageHeaderArea();
                composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(CreateMarginalHeaderArea);


                Link linkGrid1Report = new Link();
                linkGrid1Report.CreateDetailArea += new CreateAreaEventHandler(ReporChung_CreateDetailArea);

                

                grv.OptionsPrint.AutoWidth = true;
                printableComponentLink1.Component = grd;
                //printableComponentLink1.CreateDocument();
                //printableComponentLink1.ShowRibbonPreview(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                composLink.Links.Add(linkGrid1Report);

                composLink.Links.Add(printableComponentLink1);
                composLink.ShowPreviewDialog();


                //MemoryStream stream = new MemoryStream();
                //compositeLink.PrintingSystem.ExportToXlsx(stream);
                //stream.Position = 0;




                //XlsxExportOptions exportOptions = new XlsxExportOptions();
                //exportOptions.ExportMode = XlsxExportMode.SingleFilePageByPage;
                //linkedLink.ExportToXlsx(fileName, exportOptions);


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void InReportGSTT(DevExpress.XtraGrid.Views.Grid.GridView grv, DevExpress.XtraGrid.GridControl grd)
        {
            try
            {
                if (grv.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));
                    return;
                }
                CompositeLink composLink = new CompositeLink(new PrintingSystem());
                composLink.Margins.Left = 50;
                composLink.Margins.Right = 50;
                composLink.Margins.Top = 80;
                composLink.Margins.Bottom = 50;
                composLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
                composLink.Landscape = true;
                composLink.Margins.Clone();

                string leftColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sTrang", Commons.Modules.TypeLanguage) + "[Page # of Pages #]";
                string middleColumn = "User: " + Commons.Modules.UserName;
                string rightColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sNgayIn", Commons.Modules.TypeLanguage) + "[Date Printed]";

                // Create a PageHeaderFooter object and initializing it with
                // the link's PageHeaderFooter.
                PageHeaderFooter phf = composLink.PageHeaderFooter as PageHeaderFooter;

                // Clear the PageHeaderFooter's contents.
                phf.Footer.Content.Clear();

                // Add custom information to the link's header.
                phf.Footer.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
                phf.Footer.LineAlignment = BrickAlignment.Far;

                PageHeaderArea header = new PageHeaderArea();
                composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(CreateMarginalHeaderArea);

                Link linkGrid1Report = new Link();
                linkGrid1Report.CreateDetailArea += new CreateAreaEventHandler(ReporChung_CreateDetailArea);

                grv.OptionsPrint.AutoWidth = true;
                printableComponentLink1.Component = grd;
                //printableComponentLink1.CreateDocument();
                //printableComponentLink1.ShowRibbonPreview(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                composLink.Links.Add(linkGrid1Report);

                composLink.Links.Add(printableComponentLink1);
                composLink.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void InReportBTDKGSTT(DevExpress.XtraGrid.Views.Grid.GridView grv, DevExpress.XtraGrid.GridControl grd)
        {
            if (grvGSTTBTDK.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));
                return;
            }
            try
            {
                CompositeLink composLink = new CompositeLink(new PrintingSystem());
                composLink.Margins.Left = 50;
                composLink.Margins.Right = 50;
                composLink.Margins.Top = 80;
                composLink.Margins.Bottom = 50;
                composLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
                composLink.Landscape = true;
                composLink.Margins.Clone();

                string leftColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sTrang", Commons.Modules.TypeLanguage) + "[Page # of Pages #]";
                string middleColumn = "User: " + Commons.Modules.UserName;
                string rightColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sNgayIn", Commons.Modules.TypeLanguage) + "[Date Printed]";
                PageHeaderFooter phf = composLink.PageHeaderFooter as PageHeaderFooter;
                phf.Footer.Content.Clear();
                phf.Footer.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
                phf.Footer.LineAlignment = BrickAlignment.Far;

                composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(composLink_CreateMarginalHeaderArea);
                composLink.CreateDetailFooterArea += new CreateAreaEventHandler(composLink_CreateMarginalFooterArea);

                Link linkMainReport = new Link();
                linkMainReport.CreateDetailArea +=
                    new CreateAreaEventHandler(linkMainReport_CreateDetailArea);
                Link linkGrid1Report = new Link();
                linkGrid1Report.CreateDetailArea += new CreateAreaEventHandler(linkGrid1Report_CreateDetailArea);

                Link linkGrid2Report = new Link();
                linkGrid2Report.CreateDetailArea += new CreateAreaEventHandler(linkGrid2Report_CreateDetailArea);

                printableComponentLink1.Component = this.grdGSTTBTDK;
                composLink.Links.Add(linkGrid1Report);

                composLink.Links.Add(linkGrid2Report);
                composLink.Links.Add(printableComponentLink1);
                composLink.Links.Add(linkMainReport);

                // Create the report and show the preview window.
                composLink.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void InReport(DevExpress.XtraGrid.Views.Grid.GridView grv, DevExpress.XtraGrid.GridControl grd)
        {
            try
            {
                //if (grv.RowCount == 0)
                //{
                //    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));
                //    return;
                //}
                CompositeLink composLink = new CompositeLink(new PrintingSystem());
                composLink.Margins.Left = 50;
                composLink.Margins.Right = 50;
                composLink.Margins.Top = 80;
                composLink.Margins.Bottom = 50;
                composLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
                composLink.Landscape = true;
                composLink.Margins.Clone();

                string leftColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sTrang", Commons.Modules.TypeLanguage) + "[Page # of Pages #]";
                string middleColumn = "User: " + Commons.Modules.UserName;
                string rightColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sNgayIn", Commons.Modules.TypeLanguage) + "[Date Printed]";

                // Create a PageHeaderFooter object and initializing it with
                // the link's PageHeaderFooter.
                PageHeaderFooter phf = composLink.PageHeaderFooter as PageHeaderFooter;

                // Clear the PageHeaderFooter's contents.
                phf.Footer.Content.Clear();

                // Add custom information to the link's header.
                phf.Footer.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
                phf.Footer.LineAlignment = BrickAlignment.Far;

                PageHeaderArea header = new PageHeaderArea();
                composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(CreateMarginalHeaderArea);

                Link linkGrid1Report = new Link();
                linkGrid1Report.CreateDetailArea += new CreateAreaEventHandler(ReporChung_CreateDetailArea);

                grv.OptionsPrint.AutoWidth = true;
                printableComponentLink1.Component = grd;
                //printableComponentLink1.CreateDocument();
                //printableComponentLink1.ShowRibbonPreview(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                composLink.Links.Add(linkGrid1Report);

                composLink.Links.Add(printableComponentLink1);
                composLink.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        void composLink_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            //e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            //e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 16, FontStyle.Bold);
            //RectangleF rec = new RectangleF(150, 0, e.Graph.ClientPageSize.Width - 150, 40);
            //e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TIEU_DE", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);

        }
        void composLink_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 12, FontStyle.Bold);
            RectangleF rec = new RectangleF(150, 0, e.Graph.ClientPageSize.Width - 350, 60);

            if (rdoBaoCao.SelectedIndex == 0)
            {
                e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TIEU_DE", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);
            }
            else
            {
                e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TIEU_DE_TQ", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);
            }
            
            RectangleF rec1 = new RectangleF(0, 0, 150, 50);
            e.Graph.DrawImage(Image.FromStream(mem), rec1);

            // tạo 
            string sTmp = "";
            RectangleF rec2 = new RectangleF(e.Graph.ClientPageSize.Width - 200, 0, 200, 15);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 9, FontStyle.Italic);
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
            if (rdoBaoCao.SelectedIndex == 0) sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSTLNhacViecCT", Commons.Modules.TypeLanguage); else sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sSoTaiLieuTQ", Commons.Modules.TypeLanguage);
            e.Graph.DrawString(sTmp, Color.Black, rec2, BorderSide.None);

            RectangleF rec3 = new RectangleF(e.Graph.ClientPageSize.Width - 200, 15, 200, 15);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 9, FontStyle.Italic);
            if (rdoBaoCao.SelectedIndex == 0) sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sPhienBanNhacViecCT", Commons.Modules.TypeLanguage); else sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sPhienBanTQ", Commons.Modules.TypeLanguage);
            e.Graph.DrawString(sTmp, Color.Black, rec3, BorderSide.None);

            RectangleF rec4 = new RectangleF(e.Graph.ClientPageSize.Width - 200, 30, 200, 15);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 9, FontStyle.Italic);
            if (rdoBaoCao.SelectedIndex == 0) sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sNgayApDungNhacViecCT", Commons.Modules.TypeLanguage); else sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sNgayApDungTQ", Commons.Modules.TypeLanguage);
            e.Graph.DrawString(sTmp, Color.Black, rec4, BorderSide.None);
        }

        void ReporChung_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            string sMay = "";
            string sNX = "";
            string sHT = "";
            string sLTB = "";

            sNX = LabNX.Text + " : " + CboNX.TextValue;
            sHT = LabHT.Text + " : " + CboHT.TextValue;
            sLTB = LabLTB.Text + " : " + CboLTB.Text;

            string n = TabReminder.SelectedTabPage.Name;
            switch (n)
            {
                case "TabPTBDHHC":
                    sMay =  LabTB1.Text + " : " + cboMay1.Text;
                    break;
                case "TabPPBTTN":
                    sMay = LabTB2.Text + " : " + cboMay2.Text;
                    break;
                case "TabPPBTQHKT":
                    sMay = LabTB3.Text + " : " + cboMay3.Text;
                    break;
                case "TabPBTDKCTH":
                    sMay = LabTB4.Text + " : " + cboMay4.Text;
                    break;
                case "TabPGSTTDHKT":
                    sMay = LabTB5.Text + " : " + cboMay5.Text;
                    break;
                case "TabPVTPTSLNTTT":
                    sMay = "";
                    sNX = LabLPT6.Text + " : " + CboLPT6.Text;
                    sHT = lblKho.Text + " : " + cboKho.Text;
                    sLTB = "";
                    break;

            }


                e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
                e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 12, FontStyle.Bold);
                //


                RectangleF rec2 = new RectangleF(100, 10, 400, 25);
                e.Graph.DrawString(sNX, Color.Black, rec2, BorderSide.None);

                RectangleF rec21 = new RectangleF(500, 10, 400, 25);
                e.Graph.DrawString(sHT, Color.Black, rec21, BorderSide.None);

                RectangleF rec31 = new RectangleF(100, 35, 400, 25);
                e.Graph.DrawString(sLTB, Color.Black, rec31, BorderSide.None);


                RectangleF rec32 = new RectangleF(500, 35, 500, 25);
                e.Graph.DrawString(sMay, Color.Black, rec32, BorderSide.None);

            
            ////
            //RectangleF rec3 = new RectangleF(300, 65, 500, 25);
            //e.Graph.DrawString(lblLMay.Text + " : " + cboLMay.Text, Color.Black, rec3, BorderSide.None);

            //RectangleF rec31 = new RectangleF(800, 65, 500, 25);
            //e.Graph.DrawString(lblNMay.Text + " : " + cboNMay.Text, Color.Black, rec31, BorderSide.None);

            //RectangleF rec32 = new RectangleF(1300, 65, 500, 25);
            //e.Graph.DrawString(lblHienTrangSD.Text + " : " + cboHienTrangSD.Text, Color.Black, rec32, BorderSide.None);



            ////
            //RectangleF rec4 = new RectangleF(300, 90, 500, 25);
            //e.Graph.DrawString(lblBaoHanh.Text + " : " + cboBaoHanh.Text, Color.Black, rec4, BorderSide.None);

            //RectangleF rec41 = new RectangleF(800, 90, 500, 25);
            //e.Graph.DrawString(lblKhauHao.Text + " : " + cboKhauHao.Text, Color.Black, rec41, BorderSide.None);

            //RectangleF rec42 = new RectangleF(1300, 90, 500, 25);
            //e.Graph.DrawString(lblDamBaoAT.Text + " : " + cboDamBaoAT.Text, Color.Black, rec42, BorderSide.None);





        }

        //void linkGrid1ReportGSTT_CreateDetailArea(object sender, CreateAreaEventArgs e)
        //{
        //    TextBrick tb = new TextBrick();
        //    tb.Text = LabTN5.Text + " : " + TxtTN5.Text + "   " + LabDN5.Text + " : " + TxtDN5.Text + "\n" + LabNX.Text + " : " + CboNX.TextValue + "   " + LabHT.Text + " : " + CboHT.TextValue + "   " + LabLTB.Text + " : " + CboLTB.Text + "   " + LabTB5.Text + " : " + cboMay5.Text + "   " + LblThuocloaicongviec.Text + " : " + cboLCV.Text;
        //    tb.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 10);
        //    tb.Rect = new RectangleF(0, 10, e.Graph.ClientPageSize.Width, 40);
        //    tb.BorderWidth = 0;
        //    tb.BackColor = Color.Transparent;
        //    tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
        //    e.Graph.DrawBrick(tb);
        //}

        void linkGrid1Report_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = lblTNgay.Text + " : " + DatTNBTDKGSTT.Text + "   " + lblDenngay.Text + " : " + DatDNBTDKGSTT.Text + "\n" + LabNX.Text + " : " + CboNX.TextValue + "   " + LabHT.Text + " : " + CboHT.TextValue + "   " + LabLTB.Text + " : " + CboLTB.Text + "   " + lblMay.Text + " : " + cboMayGSTTBTDK.Text;
            tb.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 10);
            tb.Rect = new RectangleF(0, 10, e.Graph.ClientPageSize.Width, 40);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }
        void linkGrid2Report_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            DataTable table = (DataTable)grdGSTTBTDK.DataSource;
            int n = table.AsEnumerable().Select(x => x.Field<string>("MS_MAY")).Distinct().Count();
            TextBrick tb1 = new TextBrick();
            tb1.Text = "Tổng số máy thực hiện: " + n.ToString();
            tb1.Rect = new RectangleF(0, 0, 200, 20);
            tb1.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 10);
            tb1.BorderWidth = 0;
            tb1.BackColor = Color.Transparent;
            e.Graph.DrawBrick(tb1);
            if (rdoBaoCao.SelectedIndex == 0)
            {
                TextBrick tb = new TextBrick();
                tb.Text = "Ghi chú: Hỏng(D); Kém(C); Trung Bình(B); Tốt(A)";
                tb.Rect = new RectangleF(e.Graph.ClientPageSize.Width / 2, 0, e.Graph.ClientPageSize.Width / 2, 20);
                tb.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 10);
                tb.BorderWidth = 0;
                tb.BackColor = Color.Transparent;
                tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Far;
                e.Graph.DrawBrick(tb);
            }
        }
        // Creates an interval between the grids and fills it with color.
        void linkMainReport_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            TextBrick nk = new TextBrick();
            nk.Text = "Quản Lý Bảo Trì";
            nk.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 10, FontStyle.Bold);
            nk.Rect = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100);
            nk.BorderWidth = 1;
            nk.BackColor = Color.Transparent;
            nk.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            nk.VertAlignment = DevExpress.Utils.VertAlignment.Top;
            e.Graph.DrawBrick(nk);
        }
        private void BtnIn_Click(object sender, EventArgs e)
        {
            string n = TabReminder.SelectedTabPage.Name;
            switch (n)
            {
                case "TabPTBDHHC":
                    //InDCDDHHC();
                    InReport(grvDenHanhieuChuan, grdDenHanhieuChuan);
                    break;
                case "TabPPBTTN":
                    //InPBTTN();
                    InReport(grvPBTTrongNgay, grdPBTTrongNgay);
                    break;
                case "TabPPBTQHKT":
                    //InPBQHKT();
                    InReport(grvPBTQuaHan, grdPBTQuaHan);
                    break;
                case "TabPBTDKCTH":

                    //if (grvBTDKCanThucHien.RowCount == 0)
                    //{
                    //    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));
                    //    return;
                    //}
                    InReportBTDK(grvBTDKCanThucHien, grdBTDKCanThucHien);

                    break;
                case "TabPGSTTDHKT":
                    //InGSTT();
                    InReportGSTT(grvGSTTDenHang, grdGSTTDenHang);
                    break;
                case "TabPVTPTSLNTTT":
                    //InVTPT();
                    InReport(grvVTPT, grdVTPT);
                    break;
                case "tabGSTTKD":
                    InReport(gvTSGSTT, gdTSGSTT);
                    break;
                case "tabGSTTK":
                    InReport(gvTSGSTT, gdTSGSTT);
                    break;
                case "TabGSTTBTDK":
                    InReportBTDKGSTT(grvGSTTBTDK, grdGSTTBTDK);
                    break;
            }
        }
        private void InDCDDHHC()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbTBDHHC = new DataTable();
            TbTBDHHC = (DataTable)grdDenHanhieuChuan.DataSource;
            DataTable TBDCDDHHC1 = new DataTable();
            TBDCDDHHC1 = (DataTable)grdDungCuDoDHHC.DataSource;

            DataTable vtbLg = new DataTable();
            vtbLg = RefeshLangua1();
            frmReport frm = new frmReport();
            frm.rptName = "rptTHIET_BI_DEN_HAN_HIEU_CHUAN";

            if (TbTBDHHC.Rows.Count > 0 || TBDCDDHHC1.Rows.Count > 0)
            {
                TbTBDHHC.TableName = "THIET_BI_DEN_HAN_HIEU_CHUAN";
                TBDCDDHHC1.TableName = "DUNG_CU_DO_DEN_HAN_HIEU_CHUAN";
                vtbLg.TableName = "TIEU_DE_THIET_BI_DEN_HAN_HIEU_CHUAN";
                frm.AddDataTableSource(TbTBDHHC);
                frm.AddDataTableSource(TBDCDDHHC1);
                frm.AddDataTableSource(vtbLg);
                try
                {
                    frm.Show();
                }
                catch { }
            }
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));

            this.Cursor = Cursors.Default;
        }
        private void InPBTTN()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbPBTTN = new DataTable();
            TbPBTTN = (DataTable)grdPBTTrongNgay.DataSource;

            DataTable vtbLg = new DataTable();
            vtbLg = RefeshLangua2();
            vtbLg.TableName = "TIEU_DE_BAO_TRI_TRONG_NGAY";
            frmReport frm = new frmReport();
            frm.rptName = "rptBAO_TRI_TRONG_NGAY";
            TbPBTTN.TableName = "BAO_TRI_TRONG_NGAY";

            if (TbPBTTN.Rows.Count > 0)
            {
                frm.AddDataTableSource(TbPBTTN);
                frm.AddDataTableSource(vtbLg);
                frm.Show();
            }
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));
            this.Cursor = Cursors.Default;
        }
        private void InPBQHKT()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbPBTQHKT = new DataTable();
            TbPBTQHKT = (DataTable)(grdPBTQuaHan.DataSource);
            DataTable vtbLg = new DataTable();
            frmReport frm = new frmReport();
            frm.rptName = "rptPHIEU_BAO_TRI_QUA_HAN_KT";

            if (TbPBTQHKT.Rows.Count > 0)
            {
                vtbLg = RefeshLangua3();
                vtbLg.TableName = "TIEU_DE_PHIEU_BAO_TRI_QUA_HAN_KT";
                TbPBTQHKT.TableName = "PHIEU_BAO_TRI_QUA_HAN_KT";
                frm.AddDataTableSource(TbPBTQHKT);
                frm.AddDataTableSource(vtbLg);
                try
                {
                    frm.Show();
                }
                catch { }
            }
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));

            this.Cursor = Cursors.Default;
        }
        private void InPBTCTT()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbBTDK = new DataTable();
            TbBTDK = (DataTable)grdBTDKCanThucHien.DataSource;

            DataTable vtbLg = new DataTable();
            frmReport frm = new frmReport();
            frm.rptName = "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN";

            if (TbBTDK.Rows.Count > 0)
            {
                vtbLg = RefeshLangua4();
                vtbLg.TableName = "TIEU_DE_BAO_TRI_DINH_KY_CAN_THUC_HIEN";
                TbBTDK.TableName = "BAO_TRI_DINH_KY_CAN_THUC_HIEN";
                frm.AddDataTableSource(TbBTDK);
                frm.AddDataTableSource(vtbLg);
                frm.Show();
            }
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));

            this.Cursor = Cursors.Default;
        }
        private void InGSTT()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbTSGSTT = new DataTable();
            TbTSGSTT = (DataTable)grvGSTTDenHang.DataSource;
            DataTable vtbLg = new DataTable();
            vtbLg = RefeshLangua5();
            frmReport frm = new frmReport();

            frm.rptName = "rptTINH_TRANG_THIET_BI";

            if (Commons.Modules.sPrivate.ToUpper() == "VECO")
                frm.rptName = "rptTINH_TRANG_THIET_BI_VECO";

            if (Commons.Modules.sPrivate.ToUpper() == "PILMICO")
                frm.rptName = "rptTINH_TRANG_THIET_BI_PIL";

            if (TbTSGSTT.Rows.Count > 0)
            {
                TbTSGSTT.TableName = "TINH_TRANG_THIET_BI";
                vtbLg.TableName = "TIEU_DE_TINH_TRANG_THIET_BI";
                frm.AddDataTableSource(TbTSGSTT);
                frm.AddDataTableSource(vtbLg);
                Commons.Modules.SQLString = "0Design";
                frm.Show();
                Commons.Modules.SQLString = "";
            }
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));
            this.Cursor = Cursors.Default;
        }
        private void InVTPT()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbVTPTSLNHTTT = new DataTable();
            try
            {
                if (Commons.Modules.sPrivate == "BARIA")
                {
                    TbVTPTSLNHTTT = TonTheoBaria();
                }
                else
                {
                    //TbVTPTSLNHTTT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_VTPT_SLNH_SLTTT",
                    //    Commons.Modules.TypeLanguage, CboLPT6.EditValue, KhongKho, cboKho.EditValue, Commons.Modules.UserName));

                    TbVTPTSLNHTTT = (DataTable)grdVTPT.DataSource;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            DataTable vtbLg = new DataTable();
            frmReport frm = new frmReport();
            if (Commons.Modules.sPrivate == "VIFON")
                frm.rptName = "rptVTPT_NHO_HON_TON_TOI_THIEU_VF";
            else
                frm.rptName = "rptVTPT_NHO_HON_TON_TOI_THIEU";

            if (TbVTPTSLNHTTT.Rows.Count > 0)
            {
                TbVTPTSLNHTTT.TableName = "VTPT_NHO_HON_TON_TOI_THIEU";
                vtbLg = RefeshLangua6();
                vtbLg.TableName = "TIEU_DE_VTPT_NHO_HON_TON_TOI_THIEU";
                frm.AddDataTableSource(TbVTPTSLNHTTT);
                frm.AddDataTableSource(vtbLg);
                frm.Show();
            }
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));

            this.Cursor = Cursors.Default;
        }

        private DataTable RefeshLangua1()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 14; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "TU_NGAY";
            vtb.Columns[2].ColumnName = "DEN_NGAY";
            vtb.Columns[3].ColumnName = "DieuKienLoc";
            vtb.Columns[4].ColumnName = "ThietBiDenHan";
            vtb.Columns[5].ColumnName = "ThietBi";
            vtb.Columns[6].ColumnName = "ViTri";
            vtb.Columns[7].ColumnName = "NgayChuanCuoi";
            vtb.Columns[8].ColumnName = "ChuKy";
            vtb.Columns[9].ColumnName = "NgayChuanKeTiep";
            vtb.Columns[10].ColumnName = "Noi";
            vtb.Columns[11].ColumnName = "TenNhaXuong";
            vtb.Columns[12].ColumnName = "MaVatTu";
            vtb.Columns[13].ColumnName = "TenVatTu";

            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["TU_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "TU_NGAY", Commons.Modules.TypeLanguage) + "  " + TxtTN1.Text;
            vRowTitle["DEN_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "DEN_NGAY", Commons.Modules.TypeLanguage) + "  " + TxtDN1.Text;
            vRowTitle["DieuKienLoc"] = LabNX.Text + ": " + CboNX.Text + " - " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "LoaiThietBi", Commons.Modules.TypeLanguage) +
                        ": " + CboLTB.Text;
            vRowTitle["ThietBiDenHan"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "ThietBiDenHan", Commons.Modules.TypeLanguage);
            vRowTitle["ThietBi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "ThietBi", Commons.Modules.TypeLanguage);
            vRowTitle["ViTri"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "ViTri", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "NgayChuanCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["ChuKy"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "ChuKy", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanKeTiep"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "NgayChuanKeTiep", Commons.Modules.TypeLanguage);
            vRowTitle["Noi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "Noi", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhaXuong"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "TenNhaXuong", Commons.Modules.TypeLanguage);
            vRowTitle["MaVatTu"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "MaVatTu", Commons.Modules.TypeLanguage);
            vRowTitle["TenVatTu"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "TenVatTu", Commons.Modules.TypeLanguage);


            vtb.Rows.Add(vRowTitle);
            return vtb;
        }
        private DataTable RefeshLangua2()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 9; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "DieuKienLoc";
            vtb.Columns[2].ColumnName = "MSPhieuBaoTri";
            vtb.Columns[3].ColumnName = "LoaiBT";
            vtb.Columns[4].ColumnName = "Ten_May";
            vtb.Columns[5].ColumnName = "NgayChuanCuoi";
            vtb.Columns[6].ColumnName = "ChuKy";
            vtb.Columns[7].ColumnName = "NgayBDKeTiep";
            vtb.Columns[8].ColumnName = "TenNhaXuong";

            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["DieuKienLoc"] = LabNX.Text + "  " + " : " + CboNX.Text + " - " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "LoaiThietBi", Commons.Modules.TypeLanguage) + " : " + CboLTB.Text;
            vRowTitle["MSPhieuBaoTri"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "MSPhieuBaoTri", Commons.Modules.TypeLanguage);
            vRowTitle["LoaiBT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "LoaiBT", Commons.Modules.TypeLanguage);
            vRowTitle["Ten_May"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "Ten_May", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "NgayChuanCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["ChuKy"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "ChuKy", Commons.Modules.TypeLanguage);
            vRowTitle["NgayBDKeTiep"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "NgayBDKeTiep", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhaXuong"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "TenNhaXuong", Commons.Modules.TypeLanguage);
            vtb.Rows.Add(vRowTitle);
            return vtb;
        }
        private DataTable RefeshLangua3()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 9; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "DieuKienLoc";
            vtb.Columns[2].ColumnName = "MSPhieuBaoTri";
            vtb.Columns[3].ColumnName = "LoaiBT";
            vtb.Columns[4].ColumnName = "Ten_May";
            vtb.Columns[5].ColumnName = "NgayChuanCuoi";
            vtb.Columns[6].ColumnName = "ChuKy";
            vtb.Columns[7].ColumnName = "NgayBDKeTiep";
            vtb.Columns[8].ColumnName = "TenNhaXuong";

            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["DieuKienLoc"] = LabNX.Text + "  " + " : " + CboNX.Text + " - " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "LoaiThietBi", Commons.Modules.TypeLanguage) + " : " + CboLTB.Text;
            vRowTitle["MSPhieuBaoTri"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "MSPhieuBaoTri", Commons.Modules.TypeLanguage);
            vRowTitle["LoaiBT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "LoaiBT", Commons.Modules.TypeLanguage);
            vRowTitle["Ten_May"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "Ten_May", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "NgayChuanCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["NgayBDKeTiep"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "NgayBDKeTiep", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhaXuong"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "TenNhaXuong", Commons.Modules.TypeLanguage);
            vtb.Rows.Add(vRowTitle);
            return vtb;
        }
        private DataTable RefeshLangua4()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 12; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "TU_NGAY";
            vtb.Columns[2].ColumnName = "DEN_NGAY";
            vtb.Columns[3].ColumnName = "DieuKienLoc";
            vtb.Columns[4].ColumnName = "MS_MAY";
            vtb.Columns[5].ColumnName = "TEN_MAY";
            vtb.Columns[6].ColumnName = "LOAI_BT";
            vtb.Columns[7].ColumnName = "NgayChuanCuoi";
            vtb.Columns[8].ColumnName = "ChuKy";
            vtb.Columns[9].ColumnName = "NgayChuanKeTiep";
            vtb.Columns[10].ColumnName = "TenNhaXuong";
            vtb.Columns[11].ColumnName = "TenNhomMay";

            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["TU_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TU_NGAY", Commons.Modules.TypeLanguage) + " " + TxtTN1.Text;
            vRowTitle["DEN_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "DEN_NGAY", Commons.Modules.TypeLanguage) + " " + TxtDN1.Text;
            vRowTitle["DieuKienLoc"] = LabNX.Text +
                "  " + " : " + CboNX.Text + " - " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "LoaiThietBi", Commons.Modules.TypeLanguage) + " : " + CboLTB.Text;
            vRowTitle["MS_MAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "MS_MAY", Commons.Modules.TypeLanguage);
            vRowTitle["TEN_MAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TEN_MAY", Commons.Modules.TypeLanguage);
            vRowTitle["LOAI_BT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "LOAI_BT", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "NgayChuanCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["ChuKy"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "ChuKy", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanKeTiep"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "NgayChuanKeTiep", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhaXuong"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TenNhaXuong", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhomMay"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TenNhomMay", Commons.Modules.TypeLanguage);
            vtb.Rows.Add(vRowTitle);
            return vtb;
        }
        private DataTable RefeshLangua5()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 30; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "TU_NGAY";
            vtb.Columns[2].ColumnName = "DEN_NGAY";
            vtb.Columns[3].ColumnName = "DieuKienLoc";
            vtb.Columns[4].ColumnName = "BoPhan";
            vtb.Columns[5].ColumnName = "ThongSoGiamSat";
            vtb.Columns[6].ColumnName = "GiaTri";
            vtb.Columns[7].ColumnName = "Dat";
            vtb.Columns[8].ColumnName = "NgayGSCuoi";
            vtb.Columns[9].ColumnName = "ChuKy";
            vtb.Columns[10].ColumnName = "NgayGSKe";
            vtb.Columns[11].ColumnName = "KetQuaKT";
            vtb.Columns[12].ColumnName = "DiaDiem";
            vtb.Columns[13].ColumnName = "ThietBi";
            vtb.Columns[14].ColumnName = "NgayKT";
            vtb.Columns[15].ColumnName = "NguoiKT";
            vtb.Columns[16].ColumnName = "MAU_SO";
            vtb.Columns[17].ColumnName = "LAN_BH";
            vtb.Columns[18].ColumnName = "NGAY_BH";
            vtb.Columns[19].ColumnName = "TMP1";
            vtb.Columns[20].ColumnName = "TMP2";
            vtb.Columns[21].ColumnName = "TMP3";

            vtb.Columns[22].ColumnName = "TMP4";
            vtb.Columns[23].ColumnName = "TMP5";
            vtb.Columns[24].ColumnName = "TMP6";
            vtb.Columns[25].ColumnName = "TMP7";
            vtb.Columns[26].ColumnName = "TMP8";
            vtb.Columns[27].ColumnName = "TMP9";
            vtb.Columns[28].ColumnName = "TMP10";
            vtb.Columns[29].ColumnName = "STT";

            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage);


            if (TxtDN5.DateTime != TxtTN5.DateTime)
            {
                vRowTitle["TU_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TU_NGAY", Commons.Modules.TypeLanguage) + " " + TxtTN5.Text;
                vRowTitle["DEN_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "DEN_NGAY", Commons.Modules.TypeLanguage) + " " + TxtDN5.Text;
            }
            else
            {
                vRowTitle["TU_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "sNgay", Commons.Modules.TypeLanguage) + " " + TxtTN5.Text;
                vRowTitle["DEN_NGAY"] = "";
            }


            if (Commons.Modules.sPrivate.ToUpper() == "VECO")
            {
                vRowTitle["DieuKienLoc"] = LabNX.Text;
            }
            else
            {

                vRowTitle["DieuKienLoc"] = LabNX.Text + " : " + CboNX.Text + "\n" +
                                       LabHT.Text + " : " + CboHT.Text +
                                       "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "LoaiThietBi", Commons.Modules.TypeLanguage) + " : " + CboLTB.Text +
                                       (cboLCV.EditValue.ToString() == "-99" ? "" : "\n" + LblThuocloaicongviec.Text + " : " + cboLCV.Text
                                       );
            }
            vRowTitle["TMP4"] = CboNX.Text;
            vRowTitle["TMP5"] = LblThuocloaicongviec.Text;
            vRowTitle["TMP6"] = cboLCV.Text;

            vRowTitle["TMP7"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "LoaiThietBi", Commons.Modules.TypeLanguage);
            vRowTitle["TMP8"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP8", Commons.Modules.TypeLanguage);
            vRowTitle["TMP9"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP9", Commons.Modules.TypeLanguage);
            vRowTitle["TMP10"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP10", Commons.Modules.TypeLanguage);

            vRowTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "STT", Commons.Modules.TypeLanguage);




            //(TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter)
            vRowTitle["BoPhan"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "BoPhan", Commons.Modules.TypeLanguage);
            vRowTitle["ThongSoGiamSat"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "ThongSoGiamSat", Commons.Modules.TypeLanguage);
            vRowTitle["GiaTri"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "GiaTri", Commons.Modules.TypeLanguage);
            vRowTitle["Dat"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "Dat", Commons.Modules.TypeLanguage);
            vRowTitle["NgayGSCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NgayGSCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["ChuKy"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "ChuKy", Commons.Modules.TypeLanguage);
            vRowTitle["NgayGSKe"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NgayGSKe", Commons.Modules.TypeLanguage);
            vRowTitle["KetQuaKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "KetQuaKT", Commons.Modules.TypeLanguage);
            vRowTitle["DiaDiem"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "DiaDiem", Commons.Modules.TypeLanguage);
            vRowTitle["ThietBi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "ThietBi", Commons.Modules.TypeLanguage);
            vRowTitle["NgayKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NgayKT", Commons.Modules.TypeLanguage);
            vRowTitle["NguoiKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NguoiKT", Commons.Modules.TypeLanguage);

            vRowTitle["MAU_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "MAU_SO", Commons.Modules.TypeLanguage);
            vRowTitle["LAN_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "LAN_BH", Commons.Modules.TypeLanguage);
            vRowTitle["NGAY_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NGAY_BH", Commons.Modules.TypeLanguage);
            vRowTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP1", Commons.Modules.TypeLanguage);
            vRowTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP2", Commons.Modules.TypeLanguage);
            vRowTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP3", Commons.Modules.TypeLanguage);



            vtb.Rows.Add(vRowTitle);

            return vtb;
        }

        private DataTable RefeshLangua6()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 17; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "DieuKienLoc";
            vtb.Columns[2].ColumnName = "MS_VTPT";
            vtb.Columns[3].ColumnName = "TEN_VTPT";
            vtb.Columns[4].ColumnName = "LOAI_VTPT";
            vtb.Columns[5].ColumnName = "TON_TOI_THIEU";
            vtb.Columns[6].ColumnName = "TON_HIEN_TAI";
            vtb.Columns[7].ColumnName = "VAT_TU";
            vtb.Columns[8].ColumnName = "STT";
            vtb.Columns[9].ColumnName = "MS_PT_NCC";
            vtb.Columns[10].ColumnName = "QUY_CACH";
            vtb.Columns[11].ColumnName = "TEN_KHO";
            vtb.Columns[12].ColumnName = "TON_KHO_MAX";
            vtb.Columns[13].ColumnName = "TMP1";
            vtb.Columns[14].ColumnName = "TMP2";
            vtb.Columns[15].ColumnName = "TMP3";
            vtb.Columns[16].ColumnName = "TMP4";


            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["DieuKienLoc"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "DieuKienLoc", Commons.Modules.TypeLanguage) + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "LoaiThietBi", Commons.Modules.TypeLanguage) + ": " + CboLTB.Text;
            vRowTitle["MS_VTPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "MS_VTPT", Commons.Modules.TypeLanguage);
            vRowTitle["TEN_VTPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TEN_VTPT", Commons.Modules.TypeLanguage);
            vRowTitle["LOAI_VTPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "LOAI_VTPT", Commons.Modules.TypeLanguage);
            vRowTitle["TON_TOI_THIEU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TON_TOI_THIEU", Commons.Modules.TypeLanguage);
            vRowTitle["TON_HIEN_TAI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TON_HIEN_TAI", Commons.Modules.TypeLanguage);
            vRowTitle["VAT_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "VAT_TU", Commons.Modules.TypeLanguage);
            vRowTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "STT", Commons.Modules.TypeLanguage);
            vRowTitle["MS_PT_NCC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "MS_PT_NCC", Commons.Modules.TypeLanguage);
            vRowTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "QUY_CACH", Commons.Modules.TypeLanguage);
            vRowTitle["TEN_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TEN_KHO", Commons.Modules.TypeLanguage);



            vRowTitle["TON_KHO_MAX"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TON_KHO_MAX", Commons.Modules.TypeLanguage);
            vRowTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TMP1", Commons.Modules.TypeLanguage);
            vRowTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TMP2", Commons.Modules.TypeLanguage);
            vRowTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TMP3", Commons.Modules.TypeLanguage);
            vRowTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TMP4", Commons.Modules.TypeLanguage);



            vtb.Rows.Add(vRowTitle);

            return vtb;
        }
        public void RemoveArbitraryRow(TableLayoutPanel panel, int rowIndex)
        {
            if (panel.RowCount == 2) return;
            if (rowIndex >= panel.RowCount)
            {
                return;
            }

            // delete all controls of row that we want to delete
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                var control = panel.GetControlFromPosition(i, rowIndex);
                panel.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            for (int i = rowIndex + 1; i < panel.RowCount; i++)
            {
                for (int j = 0; j < panel.ColumnCount; j++)
                {
                    var control = panel.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        panel.SetRow(control, i - 1);
                    }
                }
            }

            var removeStyle = panel.RowCount - 1;

            if (panel.RowStyles.Count > removeStyle)
                panel.RowStyles.RemoveAt(removeStyle);

            panel.RowCount--;
        }
        #region Nhu Y
        private void BindMay()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            int index = TabReminder.SelectedTabPageIndex;
            int iCount;

            //((System.Collections.IList)cboMay1.Properties.DataSource).Count == 0 || 

            switch (index)
            {
                case 0:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay1.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 1:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay2.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 2:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay3.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 3:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay4.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 4:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay5.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 7:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMayGSTT.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 5:
                    try
                    {
                        iCount = ((DataTable)CboLPT6.Properties.DataSource).Rows.Count;
                    }

                    catch { iCount = 0; }
                    break;
                case 8:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMayGSTTBTDK.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                default:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay1.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
            }

            Commons.Modules.SQLString = "0LOAD";

            switch (index)
            {
                case 0:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMay1);
                        Commons.Modules.SQLString = "";
                        BinDataTBDHHC(cboMay1.EditValue.ToString()); ;
                        BinDataTBDHHC(cboMay1.EditValue.ToString()); ;
                    }
                    break;
                
                case 1:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMay2);
                        Commons.Modules.SQLString = "";
                        BinDataPBTTN(cboMay2.EditValue.ToString());
                    }
                    break;
                case 2:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMay3);
                        Commons.Modules.SQLString = "";
                        BinDataPBTQHKT(cboMay3.EditValue.ToString());
                    }
                    break;
                case 3:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMay4);
                        Commons.Modules.SQLString = "";
                        BinDataBTDK(cboMay4.EditValue.ToString());
                    }
                    break;
                case 4:
                    if (iCount == 0 || isChange)
                    {
                        if (Commons.Modules.sPrivate != "VINAONE")
                        {
                            RemoveArbitraryRow(TblTSGSTT5, 1);
                        }
                        BindMay(cboMay5);
                        Commons.Modules.SQLString = "";
                        BinDataTSGSTTDHKT();
                    }
                    break;
                case 5:
                    if (iCount == 0 || isChange)
                    {
                        Commons.Modules.SQLString = "";
                        BinDataVTPTSLNHTTT();
                    }
                    break;
                case 7:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMayGSTT);
                        Commons.Modules.SQLString = "";
                    }
                    break;
                case 8:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMayGSTTBTDK);
                        Commons.Modules.SQLString = "";
                        if (grvGSTTBTDK.RowCount > 0) return;
                        BinDataBTDKGSTT();
                    }
                    break;
                default:
                    if (iCount == 0 || isChange)
                        BindMay(cboMay1);
                    break;
            }
            isChange = false;
            Commons.Modules.SQLString = "";
        }

        private void LockTab(Boolean Locked)
        {
            CboHT.Enabled = Locked;
            CboLTB.Enabled = Locked;
            CboNX.Enabled = Locked;
        }





        private void CboTB5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BinDataTSGSTTDHKT();
        }

        private void CboLTB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = TabReminder.SelectedTabPageIndex;
            Commons.Modules.SQLString = "0LOAD";
            BindMay();
            Commons.Modules.SQLString = "";
            switch (index)
            {
                case 0:
                    if (cboMay1.Text == "") return;
                    BinDataTBDHHC(cboMay1.EditValue.ToString());
                    BinDataDCDDHHC(cboMay1.EditValue.ToString());
                    break;
                case 1:
                    if (cboMay2.Text == "") return;
                    BinDataPBTTN(cboMay2.EditValue.ToString());
                    break;
                case 2:
                    if (cboMay3.Text == "") return;
                    BinDataPBTQHKT(cboMay3.EditValue.ToString());
                    break;
                case 3:
                    if (cboMay4.Text == "") return;
                    BinDataBTDK(cboMay4.EditValue.ToString());
                    break;
                case 4:
                    BinDataTSGSTTDHKT();
                    break;
                case 5:
                    BinDataVTPTSLNHTTT();
                    break;
                case 6:
                    BinDataDSYC();
                    break;
                case 7:
                    BinDataGSTT();
                    break;
                case 8:
                    if (cboMayGSTTBTDK.Text == "") return;
                    BinDataBTDKGSTT();
                    break;

            }
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtPT = new DataTable();
            try
            {
                string dk = "";

                int index = TabReminder.SelectedTabPageIndex;
                switch (index)
                {
                    case 0:
                        dtPT = (DataTable)grdDungCuDoDHHC.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_VI_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  LOAI_HC LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 1:
                        dtPT = (DataTable)grdPBTTrongNgay.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_BT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 2:
                        dtPT = (DataTable)grdPBTQuaHan.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_BT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 3:
                        dtPT = (DataTable)grdBTDKCanThucHien.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_NHOM_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_BT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' " + dk;

                        break;
                    case 4:
                        dtPT = (DataTable)grdGSTTDenHang.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_BO_PHAN LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 5:
                        dtPT = (DataTable)grdVTPT.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  QUY_CACH LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT_NCC LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_VT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 6:
                        dtPT = (DataTable)GridControlDuyet.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_YEU_CAU LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  SO_YEU_CAU LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 7:
                        dtPT = (DataTable)gdTSGSTT.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_BO_PHAN LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_TS_GSTT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                }

                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtPT.DefaultView.RowFilter = dk;

                switch (index)
                {
                    case 0:
                        DataTable dtTmp1 = new DataTable();
                        dtTmp1 = (DataTable)grdDenHanhieuChuan.DataSource;
                        dk = "";
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_HIEU_CHUAN LIKE '%" + txtTKiem.Text + "%' " + dk;

                        if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                        try
                        {
                            dtTmp1.DefaultView.RowFilter = dk;

                        }
                        catch { dtTmp1.DefaultView.RowFilter = ""; }
                        break;
                }

            }
            catch { dtPT.DefaultView.RowFilter = ""; }
            this.Cursor = Cursors.Default;
        }

        private void cboKho_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboKho.EditValue.ToString() == "System.Data.DataRowView")
                return;

            BinDataVTPTSLNHTTT();
        }



        private void CboKL_SelectionChangeCommitted(object sender, EventArgs e)
        {
            isChange = true;
            BindMay();

        }

        private DataTable TonTheoBaria()
        {

            string sINTConnect = "";
            string sSql = "";
            string sBT = "TON_TOI_THIEU_TMP" + Commons.Modules.UserName;
            string sBTdata = "TON_TT_TMP" + Commons.Modules.UserName;
            try
            {
                sSql = "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG";
                sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                if (sINTConnect == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgChuaCoThongTinCuaDataINT", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                //Lay du lieu ton tu data NIKITA
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(sINTConnect, "sp_PHU_TUNG_SL"));
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");

                Commons.Modules.ObjSystems.XoaTable(sBTdata);

                sSql = "";
                //if (cboKho.EditValue.ToString() == "-1" || cboKho.EditValue.ToString() == "0")
                sSql = " SELECT A.MS_PT,A.MS_KHO, SUM(SL) AS SL_VT INTO  " + sBTdata + " FROM " + sBT + " A INNER JOIN ( ";

                if (cboKho.EditValue.ToString() == "-1" || cboKho.EditValue.ToString() == "0")
                {
                    if (cboKho.EditValue.ToString() == "-1")
                    {
                        sSql += " SELECT DISTINCT T2.MS_KHO, T1.MS_PT FROM dbo.IC_PHU_TUNG AS T1 CROSS JOIN dbo.IC_KHO AS T2 " +
                                        " WHERE     (T1.THEO_KHO = 0) " +
                                        " UNION " +
                                        " SELECT DISTINCT T2.MS_KHO, T1.MS_PT FROM dbo.IC_PHU_TUNG AS T1 INNER JOIN IC_PHU_TUNG_KHO T2 ON T1.MS_PT = T2.MS_PT " +
                                        " WHERE     (T1.THEO_KHO = 1) ";
                    }
                    else
                    {
                        sSql += " SELECT DISTINCT T2.MS_KHO, T1.MS_PT FROM dbo.IC_PHU_TUNG AS T1 CROSS JOIN dbo.IC_KHO AS T2 " +
                                        " WHERE     (T1.THEO_KHO = 0) ";
                    }
                }
                else

                    sSql += " SELECT DISTINCT T2.MS_KHO, T1.MS_PT FROM dbo.IC_PHU_TUNG AS T1 INNER JOIN IC_PHU_TUNG_KHO T2 ON T1.MS_PT = T2.MS_PT " +
                                    " WHERE     (T1.THEO_KHO = 1) AND MS_KHO = " + cboKho.EditValue.ToString();

                sSql += " ) B ON A.MS_PT = B.MS_PT AND A.MS_KHO = B.MS_KHO GROUP BY A.MS_PT,A.MS_KHO ";
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_VTPT_SLNH_SLTTT_BARIA",
                                Commons.Modules.TypeLanguage, CboLPT6.EditValue, KhongKho, cboKho.EditValue, sBTdata));


                Commons.Modules.ObjSystems.XoaTable(sBTdata);
                Commons.Modules.ObjSystems.XoaTable(sBT);
                return dtTmp;
            }
            catch (Exception EX)
            {
                Commons.Modules.ObjSystems.XoaTable(sBTdata);
                Commons.Modules.ObjSystems.XoaTable(sBT);
                DevExpress.XtraEditors.XtraMessageBox.Show(EX.Message);
                return null;
            }


        }

        private void chkTonTT_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdVTPT.DataSource);
            string sDK = "";
            LocDataTonBaria(out sDK);
            dtTmp.DefaultView.RowFilter = sDK;
            dtTmp = dtTmp.DefaultView.ToTable();

        }
        private void LocDataTonBaria(out string sLoc)
        {
            //--(VI_TRI_KHO_VAT_TU_TMP.TON_TOI_THIEU > VI_TRI_KHO_VAT_TU_TMP.SL_VTPT) AND 

            string sDK = "";
            string sKho = "";
            if (Commons.Modules.sPrivate == "BARIA")
            {
                sDK = (chkTonTT.Checked ? sDK = " TON_TOI_THIEU > TON_TT " : "");
            }
            try
            {


                if (cboKho.EditValue.ToString() != "-1")
                {
                    sKho = " MS_KHO = " + Convert.ToInt16(cboKho.EditValue.ToString());
                }

                sDK = (sDK.ToString().Length == 0 ? sKho : (sKho.ToString().Length == 0 ? sDK : sDK + " AND " + sKho));



                //dtTmp.DefaultView.RowFilter = "MS_KHO = " + Convert.ToInt16(cboKho.EditValue.ToString());
                sLoc = sDK;
            }
            catch { sLoc = ""; }

        }

        private void cboMay1_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboMay1.Text == "") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataTBDHHC(cboMay1.EditValue.ToString()); ;
                BinDataDCDDHHC(cboMay1.EditValue.ToString());
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }

            this.Cursor = Cursors.Default;
        }

        private void cboMay2_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboMay2.Text == "") return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataPBTTN(cboMay2.EditValue.ToString());
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void cboMay3_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboMay3.Text == "") return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataPBTQHKT(cboMay3.EditValue.ToString());
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void cboMay4_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboMay4.Text == "") return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataBTDK(cboMay4.EditValue.ToString());
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void TxtTN4_Validated(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboMay4.Text == "") return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataBTDK(cboMay4.EditValue.ToString());
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void cboMay5_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            

            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataTSGSTTDHKT();
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;

        }

        private void TxtTN5_Validated(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataTSGSTTDHKT();
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }

            this.Cursor = Cursors.Default;
        }
        private bool KiemLoadGSTT()
        {
            try
            {
                if (grvGSTTDenHang.RowCount > 0)
                {
                    if (
                        DateTime.Parse(grvGSTTDenHang.GetFocusedRowCellValue("TNGAY").ToString()).Date.ToString("dd/MM/yyy") == TxtTN5.DateTime.Date.ToString("dd/MM/yyyy") &&
                        DateTime.Parse(grvGSTTDenHang.GetFocusedRowCellValue("DNGAY").ToString()).Date.ToString("dd/MM/yyy") == TxtDN5.DateTime.Date.ToString("dd/MM/yyyy") &&
                        grvGSTTDenHang.GetFocusedRowCellValue("MS_NHA_XUONG").ToString() == CboNX.EditValue.ToString() &&
                    grvGSTTDenHang.GetFocusedRowCellValue("MS_HE_THONG").ToString() == CboHT.EditValue.ToString() &&
                    grvGSTTDenHang.GetFocusedRowCellValue("MS_LOAI_MAY").ToString() == CboLTB.EditValue.ToString() &&
                    grvGSTTDenHang.GetFocusedRowCellValue("MS_MAY_FIL").ToString() == cboMay5.EditValue.ToString() &&
                    grvGSTTDenHang.GetFocusedRowCellValue("MS_LOAI_CV").ToString() == cboLCV.EditValue.ToString())
                        return true;
                }
            }
            catch { }
            return false;
        }

        private void TabReminder_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //btnHuy.Visible = true;
            try
            {
                if (TabReminder.SelectedTabPageIndex == 7)
                {
                    btnHuy.Visible = true;
                    btnLapPBT.Visible = true;
                    btnCapNhap.Visible = true;

                    optGQGSTT_SelectedIndexChanged(null, null);

                }
                else {
                    btnHuy.Visible = false;
                    btnLapPBT.Visible = false;
                    btnCapNhap.Visible = false;
                }

                if (TabReminder.SelectedTabPageIndex == 4)
                {
                    LockTab(true);
                    btnLapPBT.Visible = true;
                    if (KiemLoadGSTT()) return;
                    Commons.Modules.SQLString = "0LOAD";

                    DataTable dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                " SELECT T1.MS_LOAI_CV,T1.TEN_LOAI_CV FROM LOAI_CONG_VIEC T1 INNER JOIN NHOM_LOAI_CONG_VIEC T2 ON " +
                                " T1.MS_LOAI_CV = T2.MS_LOAI_CV INNER JOIN USERS T3 ON T2.GROUP_ID = T3.GROUP_ID " +
                                " WHERE USERNAME = '" + Commons.Modules.UserName + "' " +
                                " UNION SELECT -1, ' < ALL > '  UNION SELECT -99, N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "sDN", Commons.Modules.TypeLanguage) + "' " +
                                " ORDER BY TEN_LOAI_CV"));
                    Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLCV, dtTmp, "MS_LOAI_CV", "TEN_LOAI_CV", "");
                    Commons.Modules.SQLString = "";
                    
                }
                BindMay();
                if (TabReminder.SelectedTabPageIndex == 5 )
                {
                    LockTab(false);
                    try
                    {
                        if (grvVTPT.DataSource == null)
                        {
                            BinDataVTPTSLNHTTT();
                        }
                    }
                    catch { }
                }
                else LockTab(true);

                if (TabReminder.SelectedTabPageIndex == 3 ) btnLapPBT.Visible = true;

            }
            catch
            { }
            this.Cursor = Cursors.Default;
        }

        private void grvDenHanhieuChuan_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip mnu = new ContextMenuStrip();
                Image img = null;
                mnu.Items.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReminder_new", "mnuLapPBT", Commons.Modules.TypeLanguage) + " : " +
                    grvDenHanhieuChuan.GetFocusedRowCellValue("MS_MAY").ToString(), img, new System.EventHandler(mnuHCMayClick));
                mnu.Show(grdDenHanhieuChuan, new Point(e.X, e.Y));
            }
        }
        private void mnuHCMayClick(Object sender, System.EventArgs e)
        {
            Commons.Modules.SQLString = "frmReminder_new";
            frmLapphieubaotri_CS frm = new frmLapphieubaotri_CS();
            frm.MS_MAY = grvDenHanhieuChuan.GetFocusedRowCellValue("MS_MAY").ToString();
            frm.ShowDialog();
            Commons.Modules.SQLString = "";
        }

        private void grvDungCuDoDHHC_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip mnu = new ContextMenuStrip();
                Image img = null;
                mnu.Items.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReminder_new", "mnuLapPBT", Commons.Modules.TypeLanguage) + " : " +
                    grvDungCuDoDHHC.GetFocusedRowCellValue("MS_MAY").ToString(), img, new System.EventHandler(mnuHCDCDClick));
                mnu.Show(grdDungCuDoDHHC, new Point(e.X, e.Y));
            }
        }

        private void mnuHCDCDClick(Object sender, System.EventArgs e)
        {
            Commons.Modules.SQLString = "frmReminder_newDCD";
            frmLapphieubaotri_CS frm = new frmLapphieubaotri_CS();
            frm.MS_MAY = grvDungCuDoDHHC.GetFocusedRowCellValue("MS_MAY").ToString();
            frm.sMsVatTu = grvDungCuDoDHHC.GetFocusedRowCellValue("MS_PT").ToString();
            frm.ShowDialog();
            Commons.Modules.SQLString = "";
        }
        private void TxtTN1_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            if (cboMay1.Text == "") return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataTBDHHC(cboMay1.EditValue.ToString());
                BinDataDCDDHHC(cboMay1.EditValue.ToString());
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }
        private void LoadGrid(DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv, DataTable dtLuoi)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;

            if (grd.DataSource == null)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grd, grv, dtLuoi, false, true, true, false, true, this.Name.ToString());
            else
                grd.DataSource = dtLuoi;

        }

        private void CboLPT6_EditValueChanged(object sender, EventArgs e)
        {
            BinDataVTPTSLNHTTT();
        }

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataDSYC();
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void btnXemBangChung1_Click(object sender, EventArgs e)
        {

        }


        private void dtpTNGSTT_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataGSTT();
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }
        private void CboNX_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            CboLTB_SelectionChangeCommitted(null, null);
        }
        private void LocDK()
        {
            if (Commons.Modules.sPrivate != "VINAONE") return;
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;
                string sql = "";
                try
                {
                    if (chkQuaHanHon2Tuan.Checked)
                    {
                        sql += " OR (SN < -14) ";
                    }
                    if (chkQuaHanTrong2Tuan.Checked)
                    {
                        sql += " OR (SN >= -14 AND SN < 0 ) ";
                    }

                    if (chkSapToiHanTrongTuan.Checked)
                    {
                        sql += " OR (SN > 0 AND SN <=7) ";
                    }
                    if (chkSapToiHanTrenTuan.Checked)
                    {
                        sql += " OR (SN > 7) ";
                    }

                    if (sql == "")
                        sql = " SN = -99999";
                    else
                        sql = sql.Substring(4, sql.Length - 4);

                    //sql = "( " + sql + ")";
                }
                catch { sql = ""; }
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)(grdGSTTDenHang.DataSource);
                dtTmp.DefaultView.RowFilter = sql;


            }
            catch
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)(grdGSTTDenHang.DataSource);
                dtTmp.DefaultView.RowFilter = "SN = -99999";
            }
        }
        private void grvGSTTDenHang_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (Commons.Modules.sPrivate != "VINAONE") return;
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in view.Columns)
                {
                    if (col.Name == "colSN")
                    {
                        if (e.RowHandle >= 0)
                        {
                            if (e.Column.FieldName == "TINH_TRANG")
                            {

                                int SN;
                                SN = int.Parse(view.GetRowCellDisplayText(e.RowHandle, col));
                                if (SN < 0)
                                {
                                    if (SN > -14)
                                    {
                                        e.Appearance.BackColor = Color.Yellow;

                                    }
                                    else
                                    {
                                        e.Appearance.BackColor = Color.Tomato;

                                    }
                                }
                                else
                                {
                                    if (SN <= 7)
                                    {
                                        e.Appearance.BackColor = Color.FromArgb(155, 187, 89);
                                    }
                                    else
                                    {
                                        e.Appearance.BackColor = Color.LightSkyBlue;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch { }
        }

        private void chkQuaHanHon2Tuan_CheckedChanged(object sender, EventArgs e)
        {
            LocDK();
        }

        private void cboMayGSTTBTDK_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataBTDKGSTT();
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void rdoBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMayGSTTBTDK.Text == "") return;
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataBTDKGSTT();
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void frmReminder_new_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                int index = TabReminder.SelectedTabPageIndex;
                switch (index)
                {
                    case 0:
                        BinDataTBDHHC(cboMay1.EditValue.ToString()); ;
                        BinDataTBDHHC(cboMay1.EditValue.ToString()); ;
                        break;
                    case 1:
                        BinDataPBTTN(cboMay2.EditValue.ToString());
                        break;
                    case 2:
                        BinDataPBTQHKT(cboMay3.EditValue.ToString());
                        break;
                    case 3:
                        BinDataBTDK(cboMay4.EditValue.ToString());
                        break;
                    case 4:
                        if (Commons.Modules.sPrivate != "VINAONE")
                        {
                            RemoveArbitraryRow(TblTSGSTT5, 1);
                        }
                        BinDataTSGSTTDHKT();
                        break;
                    case 5:
                        BinDataVTPTSLNHTTT();
                        break;
                    case 8:
                        BinDataBTDKGSTT();
                        break;
                    default:
                        break;
                }
            }
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            if (Commons.Modules.PermisString.Equals("Read only")) return;

            if (optGQGSTT.SelectedIndex == 1)
            {
                btnHuy_Click_1(null, null);
                return;
            }


            frmChonThucHienGSTT frm = new frmChonThucHienGSTT();
            gvTSGSTT.UpdateCurrentRow();
            DataTable dtTmp = new DataTable();
            DataTable dtLuoi = new DataTable();
            dtLuoi = (DataTable)gdTSGSTT.DataSource;
            dtTmp = dtLuoi.Copy();

            dtTmp.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtTmp.DefaultView.ToTable();


            if (dtTmp.Rows.Count < 1)
            {
                if (Convert.ToBoolean(gvTSGSTT.GetFocusedRowCellValue("CHON").ToString()) == false)
                {
                    gvTSGSTT.SetFocusedRowCellValue("CHON", 1);
                    gvTSGSTT.UpdateCurrentRow();
                }
                dtTmp = new DataTable();
                dtLuoi = new DataTable();
                dtLuoi = (DataTable)gdTSGSTT.DataSource;
                dtTmp = dtLuoi.Copy();

                dtTmp.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtTmp.DefaultView.ToTable();
                if (dtTmp.Rows.Count < 1)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonGiamSatCanThucHien", Commons.Modules.TypeLanguage));
                    return;
                }
            }
            DataTable distinctDT = dtTmp.DefaultView.ToTable(true, "MS_MAY", "NGAY_GIO_KT_MAX");
            if (distinctDT.Rows.Count > 1)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCoTren2MayHayNgayKiemTra", Commons.Modules.TypeLanguage));
                return;
            }

            frm.dtTSGSTT = dtTmp;

            frm.drGSTT = gvTSGSTT.GetDataRow(gvTSGSTT.FocusedRowHandle);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;


            dtpTNGSTT_EditValueChanged(null, null);
        }

        private void gvTSGSTT_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                if (Commons.Modules.PermisString.Equals("Read only")) return;
                GridView viewChung;
                Point ptChung;
                viewChung = (GridView)sender;
                ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
                //viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);
                if (viewChung.RowCount == 0) return;
                DoRowDoubleClick(viewChung, ptChung);
            }
            catch { }
        }

        private void btnLapPBT_Click(object sender, EventArgs e)
        {
            if (TabReminder.SelectedTabPageIndex == 7)
            {
                LapPBTGSTT();
            }
            if (TabReminder.SelectedTabPageIndex == 3)
            {
                LapPBTBTDK();
            }
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {


            try
            {
                if (Commons.Modules.PermisString.Equals("Read only")) return;
                GridView viewChung;
                Point ptChung;
                viewChung = grvBTDKCanThucHien;
                ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
                if (viewChung.RowCount == 0) return;
                DoRowDoubleClick(viewChung, ptChung);
            }
            catch { }


        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {

            gvTSGSTT.UpdateCurrentRow();
            if (gvTSGSTT.RowCount == 0)
                return;


            gvTSGSTT.UpdateCurrentRow();
            DataTable dtTmp = new DataTable();
            DataTable dtLuoi = new DataTable();
            dtLuoi = (DataTable)gdTSGSTT.DataSource;
            dtLuoi.DefaultView.RowFilter = "CHON = 1";
            dtTmp = dtLuoi.DefaultView.ToTable().Copy();
            dtLuoi.DefaultView.RowFilter = "";
            if (dtTmp.Rows.Count < 1)
            {

                if (Convert.ToBoolean(gvTSGSTT.GetFocusedRowCellValue("CHON").ToString()) == false)
                {
                    gvTSGSTT.SetFocusedRowCellValue("CHON", 1);
                    gvTSGSTT.UpdateCurrentRow();
                }
                dtTmp = new DataTable();
                dtLuoi = new DataTable();
                dtLuoi = (DataTable)gdTSGSTT.DataSource;
                dtLuoi.DefaultView.RowFilter = "CHON = 1";
                dtTmp = dtLuoi.DefaultView.ToTable();
                dtLuoi.DefaultView.RowFilter = "";
                if (dtTmp.Rows.Count < 1)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonGiamSatCanThucHien", Commons.Modules.TypeLanguage));
                    return;
                }

            }

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgHuyVeChuaGiaQuyet", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "TSGSTT" + Commons.Modules.UserName, dtTmp, "");

            string str = @" UPDATE GIAM_SAT_TINH_TRANG_TS_DT
                            SET 
                                MS_CACH_TH = NULL,
                                USERNAME = NULL,
                                TG_XU_LY = NULL,
                                MS_PBT = NULL,
                                HANG_MUC_ID_KE_HOACH = NULL,
                                MS_CONG_NHAN = NULL
                            FROM GIAM_SAT_TINH_TRANG_TS_DT T INNER JOIN " + "TSGSTT" + Commons.Modules.UserName + @" T1 ON T1.STT = T.STT AND T1.MS_MAY = T.MS_MAY AND T.MS_TS_GSTT = T1.MS_TS_GSTT AND T.MS_TT = T1.MS_TT AND T1.STT_GT = T.STT_GT AND T1.MS_BO_PHAN = T.MS_BO_PHAN
                  
                UPDATE GIAM_SAT_TINH_TRANG_TS
                SET 
                    MS_CACH_TH = NULL,
                    USERNAME = NULL,
                    TG_XU_LY = NULL,
                    MS_PBT = NULL,
                    HANG_MUC_ID_KE_HOACH = NULL,
                    MS_CONG_NHAN = NULL
                    FROM GIAM_SAT_TINH_TRANG_TS T INNER JOIN " + "TSGSTT" + Commons.Modules.UserName + @" T1 ON 
                    T1.STT = T.STT AND T1.MS_MAY = T.MS_MAY AND T.MS_TS_GSTT = T1.MS_TS_GSTT AND 
                    T.MS_TT = T1.MS_TT AND T1.MS_BO_PHAN = T.MS_BO_PHAN ";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
            Commons.Modules.ObjSystems.XoaTable("TSGSTT" + Commons.Modules.UserName);
            BinDataGSTT();
        }

        private void optGQGSTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabReminder.SelectedTabPageIndex != 7) return;
            btnCapNhap.Enabled = true;
            btnHuy.Enabled = true;
            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                btnCapNhap.Visible = false;
                btnHuy.Visible = false;
            }
            else
            {
                if (optGQGSTT.SelectedIndex == 1 || optGQGSTT.SelectedIndex == 2)
                {

                    btnCapNhap.Visible = false;
                    btnHuy.Visible = true;
                }
                else
                {
                    btnCapNhap.Visible = true;
                    btnHuy.Visible = false;
                }
            }
            BinDataGSTT();
        }

        private void grvBTDKCanThucHien_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right) return;
                CreateMenuGridBaoTri(grdBTDKCanThucHien);


            }
            catch { }
        }

        private void CreateMenuGridBaoTri(DevExpress.XtraGrid.GridControl grd)
        {
            DevExpress.XtraBars.BarManager BarManager = new DevExpress.XtraBars.BarManager();
            BarManager.Form = grd;
            BarManager.ItemClick += BarManager_ItemClick;
            BarManager.BeginUpdate();
            DevExpress.XtraBars.PopupMenu popup = new DevExpress.XtraBars.PopupMenu(BarManager);
            BarManager.SetPopupContextMenu(grd, popup);
            string sStr;
            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuHyperLinkMay", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuMay = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuMay.Name = "mnuMay";

            sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMain", "mnuLapPhieuBaoTri", Commons.Modules.TypeLanguage);
            DevExpress.XtraBars.BarButtonItem mnuPBTBTDK = new DevExpress.XtraBars.BarButtonItem(BarManager, sStr);
            mnuPBTBTDK.Name = "mnuPBTBTDK";

            popup.AddItems(new DevExpress.XtraBars.BarItem[] { mnuMay, mnuPBTBTDK });
            BarManager.EndUpdate();
        }

        private void cboMay1_Click(object sender, EventArgs e)
        {
            try
            {
                ((DevExpress.XtraEditors.LookUpEdit)sender).SelectAll();
            }
            catch { }
        }
        
    }
    #endregion
}