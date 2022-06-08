using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using MVControl;

namespace ReportMain.Forms
{
    public partial class frmYeuCauCuaNSD : DevExpress.XtraEditors.XtraForm
    {
        GridView viewChung;
        Point ptChung;
        Boolean bThem = false;
        bool duyetTuDong = false;
        bool duyetLapPhieu = false;
        int iMsNNChung, iMucUTChung;

        public frmYeuCauCuaNSD()
        {
            InitializeComponent();
            
        }
        #region Load du lieu
        private void LoadNhaXuong()
        {
            try
            {
                KiemApp.MLoadCboTreeList(ref cboNXuong, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(0), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch (Exception)
            {

            }
        }

        private void LoadNguoiYC()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNYCau, "SELECT DISTINCT NGUOI_YEU_CAU, NGUOI_YEU_CAU as HO_TEN FROM YEU_CAU_NSD " +
                " UNION SELECT '-1', ' < ALL > ' ORDER BY HO_TEN", "NGUOI_YEU_CAU", "HO_TEN", lblNguoiYC.Text);
        }

        private void LoadLuoiYCSD(int STT, string sNguoiYC, string sTNgay, string sDNgay)
        {
            //0 -1,1 -1,2 - 0
            int iloai = 0;
            switch (rdoGroupDuyet.SelectedIndex)
            {
                case 0:
                    {
                        iloai = -1; break;
                    }
                case 1:
                    {
                        iloai = 1; break;
                    }
                case 2:
                    {
                        iloai = 0; break;
                    }
                default:
                    {
                        iloai = -1;
                        break;
                    }
            }

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD", sNguoiYC, sTNgay, sDNgay, iloai,
                    Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["STT"] };
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdYCSD, grvYCSD, dtTmp, false, false, true, true, true, this.Name);
            if (STT != -1)
            {
                int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(STT));
                grvYCSD.FocusedRowHandle = grvYCSD.GetRowHandle(index);
            }
            if (grvYCSD.FocusedRowHandle == 0)
            {
                LoadText();
            }
            //grvYCSD.Columns["MS_YEU_CAU"].OptionsColumn.FixedWidth = true;
            //grvYCSD.Columns["SO_YEU_CAU"].OptionsColumn.FixedWidth = true;
            grvYCSD.Columns["NGAY"].OptionsColumn.FixedWidth = true;
            grvYCSD.Columns["GIO_YEU_CAU"].OptionsColumn.FixedWidth = true;
            grvYCSD.Columns["NGAY_HOAN_THANH"].OptionsColumn.FixedWidth = true;

            if (!grvYCSD.Columns["MS_N_XUONG"].Visible) return;

            grvYCSD.Columns["MS_YEU_CAU"].Visible = false;
            grvYCSD.Columns["DA_KIEM_TRA"].Visible = false;
            grvYCSD.Columns["MS_N_XUONG"].Visible = false;
            grvYCSD.Columns["DA_KIEM_TRA"].Visible = false;
            grvYCSD.Columns["USERNAME"].Visible = false;
            grvYCSD.Columns["THUC_HIEN_DSX"].Visible = false;
            grvYCSD.Columns["USER_LAP"].Visible = false;
            grvYCSD.Columns["REVIEWER_COMMENT"].Visible = false;
            grvYCSD.Columns["USER_COMMENT"].Visible = false;
            grvYCSD.Columns["STT"].Visible = false;
            grvYCSD.Columns["GIO_YEU_CAU"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvYCSD.Columns["GIO_YEU_CAU"].DisplayFormat.FormatString = "HH:mm:ss";


            grvYCSD.Columns["MS_YEU_CAU"].Width = 110;
            grvYCSD.Columns["SO_YEU_CAU"].Width = 110;


            grvYCSD.Columns["NGAY"].Width = 90;


        }

        private void LoadLuoiChiTiet(int STT)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getYEU_CAU_NSD_CHI_TIET", STT, Commons.Modules.UserName));
            dtTmp.Columns["MS_NGUYEN_NHAN"].AllowDBNull = true;
            dtTmp.Columns["MS_NGUYEN_NHAN"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCTiet, grvCTiet, dtTmp, true, false, true, false);
            grvCTiet.Columns["GIO_XAY_RA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvCTiet.Columns["GIO_XAY_RA"].DisplayFormat.FormatString = "HH:mm:ss";

            if (btnGhi.Visible)
            {
                grvCTiet.OptionsBehavior.Editable = true;
                grvCTiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            }
            else
                grvCTiet.OptionsBehavior.Editable = false;

            if (grvCTiet.Columns["STT"].Visible == false) return;

            grvCTiet.OptionsView.ColumnAutoWidth = false;
            grvCTiet.Columns["STT"].Visible = false;
            grvCTiet.Columns["STT_VAN_DE"].Visible = false;
            grvCTiet.Columns["THUC_HIEN_DSX"].Visible = false;
            grvCTiet.Columns["MS_MAY_OLD"].Visible = false;
            grvCTiet.Columns["STT_VAN_DE_OLD"].Visible = false;
            grvCTiet.Columns["MS_MAY"].Width = 120;
            grvCTiet.Columns["TEN_MAY"].Width = 250;
            grvCTiet.Columns["MO_TA_TINH_TRANG"].Width = 150;
            grvCTiet.Columns["YEU_CAU"].Width = 120;
            grvCTiet.Columns["NGAY_XAY_RA"].Width = 90;
            grvCTiet.Columns["GIO_XAY_RA"].Width = 80;
            grvCTiet.Columns["MS_UU_TIEN"].Width = 90;
            grvCTiet.Columns["TEN_MAY"].OptionsColumn.ReadOnly = true;
            grvCTiet.Columns["TEN_MAY"].Visible = false;
        }

        private void LoadLuoiChiTietHinh(int STT, int STTVDe, string MsMay)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_HINHs", STT, MsMay, STTVDe));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdYCSDHinh, grvYCSDHinh, dtTmp, false, false, true, false, true, this.Name.ToString());
            if (!btnGhi.Visible)
            {
                grvYCSDHinh.OptionsBehavior.Editable = true;
                grvYCSDHinh.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            }
            else
                grvYCSDHinh.OptionsBehavior.Editable = false;

            if (!grvYCSDHinh.Columns["STT"].Visible) return;
            grvYCSDHinh.OptionsView.ColumnAutoWidth = false;
            grvYCSDHinh.Columns["GHI_CHU"].Width = 1000;
            grvYCSDHinh.Columns["DUONG_DAN"].Width = 800;
            grvYCSDHinh.Columns["STT"].Visible = false;
            grvYCSDHinh.Columns["MS_MAY"].Visible = false;
            grvYCSDHinh.Columns["STT_VAN_DE"].Visible = false;
            grvYCSDHinh.Columns["HINH"].Visible = false;
            grvYCSDHinh.Columns["STT_HINH"].Visible = false;

            if (dtTmp.Rows.Count == 0)
            {
                btnXemHinh.Visible = false;
            }
            else
                btnXemHinh.Visible = true;
        }

        private void LoadLuoiXuLy(int STT)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            DataTable dtTmp = new DataTable();
            string sMay = "-1";
            try
            { sMay = grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString(); }
            catch
            { }
            if (menuClick == false) return;
            MVControl.frmShowThongTinYCNSD frm = new MVControl.frmShowThongTinYCNSD();
            frm.STT = STT.ToString();
            frm.MS_MAY = sMay;
            frm.MS_PBT = "-1";
            frm.STT_VAN_DE = grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            menuClick = false;
        }

        private void LoadText()
        {
            if (grvYCSD.RowCount == 0)
            {
                LoadTextTrang();
                return;
            }
            try
            {
                txtSTT.Text = grvYCSD.GetFocusedRowCellValue("STT").ToString();
            }
            catch
            { txtSTT.Text = ""; }
            try
            {

                txtMYC.Text = grvYCSD.GetFocusedRowCellValue("MS_YEU_CAU").ToString();
            }
            catch
            { txtMYC.Text = ""; }

            try
            {
                txtSYCau.Text = grvYCSD.GetFocusedRowCellValue("SO_YEU_CAU").ToString();
            }
            catch
            { txtSYCau.Text = ""; }

            try
            {
                datNYCau.DateTime = DateTime.Parse(grvYCSD.GetFocusedRowCellValue("NGAY").ToString());
            }
            catch
            { datNYCau.Text = ""; }
            try
            {
                txtGioYC.Time = DateTime.Parse(grvYCSD.GetFocusedRowCellValue("GIO_YEU_CAU").ToString());
            }
            catch
            { txtGioYC.Text = ""; }
            try
            {
                txtNYCau.Text = grvYCSD.GetFocusedRowCellValue("NGUOI_YEU_CAU").ToString();
                //cboNguoiYeuCau.Text = grvYCSD.GetFocusedRowCellValue("NGUOI_YEU_CAU").ToString();
            }
            catch
            {
                txtNYCau.Text = "";
                //cboNguoiYeuCau.EditValue = 0;
            }
            try
            {
                if (grvYCSD.GetFocusedRowCellValue("NGAY_HOAN_THANH").ToString() != "")
                    datNHThanh.DateTime = DateTime.Parse(grvYCSD.GetFocusedRowCellValue("NGAY_HOAN_THANH").ToString());
                else
                    datNHThanh.Text = "";
            }
            catch
            { datNHThanh.Text = ""; }

            try
            {
                cboNXuong.SelectedIndex = cboNXuong.treeList.GetVisibleIndexByNode(cboNXuong.treeList.FindNodeByKeyID(grvYCSD.GetFocusedRowCellValue("MS_N_XUONG").ToString()));
            }
            catch
            { cboNXuong.EditValue = ""; }
            try
            {
                txtMail.Text = grvYCSD.GetFocusedRowCellValue("EMAIL_NSD").ToString();
            }
            catch
            { txtMail.Text = ""; }

            if (!duyetLapPhieu) return;
            //kiểm tra stt 
            if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.YEU_CAU_NSD_CHI_TIET WHERE STT = " + txtSTT.EditValue + " AND ISNULL(USERNAME_DSX,'') = '' ")) == 0)
            {
                btnDuyet.Enabled = btnKhongDuyet.Enabled = false;
            }
            else
            {
                btnDuyet.Enabled = btnKhongDuyet.Enabled = true;
            }
            //kiểm tra hiện tình trạng hiện tại của nó
            if (Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 ISNULL(DUYET,0)  FROM dbo.YEU_CAU_NSD WHERE STT = " + txtSTT.EditValue + "")))
            {
                btnDuyet.Visible = false;
                btnKhongDuyet.Visible = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 117);
                //kiểm tra phiếu đã được duyệt hay chưa
            }
            else
            {
                btnDuyet.Visible = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 117);
                btnKhongDuyet.Visible = false;
            }
        }
        private void LoadTextTrang()
        {
            txtSTT.Text = "";
            txtMYC.Text = "";
            txtSYCau.Text = "";
            datNYCau.Text = "";
            txtGioYC.Text = "";
            txtNYCau.Text = "";
            //cboNguoiYeuCau.Text = "";
            datNHThanh.Text = "";
            //cboNXuong.EditValue = "";
            //txtUComment.Text = ""; 
            txtMail.Text = "";
        }

        private void LockControl(Boolean bLock)
        {
            txtSTT.Properties.ReadOnly = bLock;
            txtSYCau.Properties.ReadOnly = bLock;
            datNYCau.Properties.ReadOnly = bLock;
            txtGioYC.Properties.ReadOnly = bLock;
            txtNYCau.Properties.ReadOnly = bLock;
            datNHThanh.Properties.ReadOnly = bLock;
            cboNXuong.Enabled = !bLock;
            cboNguoiYeuCau.Properties.ReadOnly = bLock;
            //txtUComment.Properties.ReadOnly = bLock;
            txtMail.Properties.ReadOnly = bLock;
            btnGhi.Visible = !bLock;
            btnKhong.Visible = !bLock;
            btnThem.Visible = bLock;
            btnSua.Visible = bLock;
            btnXoa.Visible = bLock;
            if (bLock == false)
            {
                btnDuyet.Visible = false;
                btnKhongDuyet.Visible = false;
            }
            btnThoat.Visible = bLock;
            btnIN.Visible = bLock;
            btnChonMay.Visible = !bLock;

            btnGoiMai.Enabled = bLock;
            if (bLock) grvCTiet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False; else grvCTiet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            if (bLock)
            {
                grvCTiet.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                grvCTiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;

                grvYCSDHinh.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                grvYCSDHinh.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            }
            else
            {
                grvCTiet.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                grvCTiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;

                grvYCSDHinh.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                grvYCSDHinh.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;

            }
            grvCTiet.OptionsBehavior.Editable = !bLock;
            grvYCSDHinh.OptionsBehavior.Editable = bLock;


        }
        #endregion

        private void grvYCSDHinh_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);
        }

        private void grvYCSDHinh_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (KiemKyTu(grvYCSDHinh.GetFocusedRowCellValue("GHI_CHU").ToString(), "'"))
            {
                e.Valid = false;
                return;
            }
            if (grvYCSDHinh.GetFocusedRowCellValue("DUONG_DAN").ToString() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmYeuCauCuaNSD", "ChuaChonDuongDan", Commons.Modules.TypeLanguage));
                e.Valid = false;
                return;
            }

            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "UpdateYEU_CAU_NSD_CHI_TIET_HINH_GHI_CHU",
                        Int32.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString(),
                        Int32.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()),
                        grvYCSDHinh.GetFocusedRowCellValue("STT_HINH").ToString(),
                        grvYCSDHinh.GetFocusedRowCellValue("GHI_CHU").ToString());
        }


        private bool KiemKyTu(string strInput, string strChuoi)
        {
            string ChuoiKTMa = "':*?<>|\\/";
            if (strChuoi == "") strChuoi = ChuoiKTMa;

            for (int i = 0; i < strInput.Length; i++)
            {
                for (int j = 0; j < strChuoi.Length; j++)
                {
                    if (strInput[i] == strChuoi[j])
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvYCSDHinh.RefreshData();
            try
            {

                if (grvYCSDHinh.RowCount == 0)
                    btnXemHinh.Visible = false;
                else
                    btnXemHinh.Visible = true;
            }
            catch (Exception)
            {


            }


        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(pt);
                int col = -1;
                col = info.Column.AbsoluteIndex;
                if (col == 4)
                {
                    if (grvCTiet.RowCount == 0)
                        return;

                    OpenFileDialog oFile = new OpenFileDialog();
                    oFile.Multiselect = true;
                    oFile.Filter = "All Files (*.*)|*.*"; //"XLS Files|*.xls,*.xlsx  |XLSX Files|*.xlsx";
                    if (oFile.ShowDialog() == DialogResult.OK)
                    {
                        //grvCTiet.SetFocusedRowCellValue("DUONG_DAN", oFile.FileName);
                        string sDuongDanYCSD, sSql, sMay;
                        string[] sFilePath;
                        sFilePath = oFile.FileNames;
                        sMay = grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString();
                        sDuongDanYCSD = Commons.Modules.ObjSystems.CapnhatTL(false, sMay);
                        sSql = "SELECT TOP 1 DUONG_DAN FROM YEU_CAU_NSD_CHI_TIET_HINH " +
                            " WHERE  MS_MAY=N'" + sMay + "' ORDER BY STT_HINH DESC";
                        int iSTTHinh = Commons.Modules.ObjSystems.LaySTTChoTaiLieu(sSql);

                        //for (int i = 0 sFilePath.Length -1; i++)
                        for (int i = 0; i <= sFilePath.Length - 1; i++)
                        {
                            string sNewPath;
                            sNewPath = DateTime.Now.Day.ToString();

                            sNewPath = sDuongDanYCSD + "\\" + "YCNSD" + "_" + sMay + "_" + DateTime.Now.Day.ToString() +
                            DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "_" + iSTTHinh.ToString() +
                            Commons.Modules.ObjSystems.LayDuoiFile(sFilePath[i]);

                            Commons.Modules.ObjSystems.LuuDuongDan(sFilePath[i], sNewPath);
                            try
                            {
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "AddYEU_CAU_NSD_CHI_TIET_HINH",
                                   Int32.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString(),
                                   Int32.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()),
                                sNewPath, "");
                            }
                            catch { }
                        }
                        if (grvCTiet.RowCount == 0)
                        {
                            LoadLuoiChiTietHinh(-1, -1, "-1");
                            btnThemBP.Enabled = false;
                        }
                        else
                        {
                            LoadLuoiChiTietHinh(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                                int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
                            btnThemBP.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmYeuCauCuaNSD_Load(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.SQLString = "0Load";
                //DUYET_TAO_YC  = TRUE la bat buoc fai duyet phieu tao yeu cau 
                //DUYET_YC
                duyetLapPhieu = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 ISNULL(DUYET_TAO_YC,0)  FROM dbo.THONG_TIN_CHUNG"));

                iMsNNChung = 0;
                iMucUTChung = 0;
                try
                {
                    iMsNNChung = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 MS_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY WHERE TEN_NGUYEN_NHAN LIKE N'%Khác%' ORDER BY MS_NGUYEN_NHAN"));
                }
                catch { }
                try
                {
                    iMucUTChung = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 MS_UU_TIEN FROM MUC_UU_TIEN WHERE TEN_UU_TIEN LIKE N'%Trung bình/Medium%' ORDER BY MS_UU_TIEN"));
                }
                catch { }

                DateTime Ngay;
                Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
                datTNgay.DateTime = Ngay;
                datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);

                datTNgay.DateTime = DateTime.Now.AddMonths(-1);
                datDNgay.DateTime = DateTime.Now;

                LoadNhaXuong();
                LoadNguoiYC();
                LoadCongNhan();
                //kiểm tra trong thông tin chung có duyệt không 
                if (duyetLapPhieu)
                {
                    btnDuyet.Enabled = Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 117);
                    btnKhongDuyet.Enabled = btnDuyet.Enabled;
                }
                else
                {
                    btnDuyet.Visible = false;
                    btnKhongDuyet.Visible = false;
                    rdoGroupDuyet.Visible = false;
                }
                LoadLuoiYCSD(-1, cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));


                //LoadText();
                ThemBP(false);
                btnThemBP.BringToFront();
                //pnYeuCau.Visible = true;
                LockControl(true);
                LoadLuoiChiTiet(-1);
                LoadCmbLuoi();
                LoadLuoiChiTietHinh(-1, -1, "-1");
                LoadLuoiXuLy(-1);

                Commons.Modules.ObjSystems.ThayDoiNN(this);
                tabYCSDung.TabPages[0].Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TabYeucaucuaNSD", Commons.Modules.TypeLanguage);
                tabYCSDung.TabPages[1].Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TabChitietyeucau", Commons.Modules.TypeLanguage);
                btnXemHinh.Visible = false;
                this.WindowState = FormWindowState.Maximized;
                duyetTuDong = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT ISNULL(DUYET_YC, 0) FROM THONG_TIN_CHUNG"));



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Commons.Modules.SQLString = "";



        }

        private void LoadCongNhan()
        {
            DataTable dtTmp = new DataTable();


            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_NHAN_UserAll", "-1", "-1", 1, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguoiYeuCau, dtTmp, "HO_TEN", "HO_TEN", "");
            }
            catch { }

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboMay =
                new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

        }
        private void LoadCmbMay()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                if (btnGhi.Visible)
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayYeuCauNSD",
                        Commons.Modules.UserName, cboNXuong.EditValue.ToString() == "" ? cboNXuong.treeList.Nodes.FirstNode["MS_N_XUONG"].ToString() : cboNXuong.EditValue, (txtSTT.Text == "" ? -1 : int.Parse(txtSTT.Text))));
                else
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayYeuCauNSD",
                        Commons.Modules.UserName, "-1", -1));
            }
            catch { }

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboMay =
                new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboMay.NullText = "";
            cboMay.ValueMember = "MS_MAY";
            cboMay.DisplayMember = "MS_MAY";
            cboMay.DataSource = dtTmp;


            if (btnGhi.Visible)
            {
                cboMay.Columns.Clear();
                cboMay.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_MAY"));
                cboMay.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_MAY"));
                cboMay.PopupWidth = 625;
                cboMay.Columns["MS_MAY"].Width = 150;
                cboMay.Columns["TEN_MAY"].Width = 450;
            }

            grvCTiet.Columns["MS_MAY"].ColumnEdit = cboMay;
            cboMay.EditValueChanged += new System.EventHandler(this.cboMay_EditValueChanged);

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboTMay =
                        new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboTMay.NullText = "";
            cboTMay.ValueMember = "MS_MAY";
            if (btnGhi.Visible)
            {
                cboTMay.DisplayMember = "TEN_MAY";
                cboTMay.Columns.Clear();
                cboTMay.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_MAY"));
            }
            else
                cboTMay.DisplayMember = "MSMAY";

            cboTMay.DataSource = dtTmp;
            grvCTiet.Columns["TEN_MAY"].ColumnEdit = cboTMay;

            if (dtTmp.Rows.Count > 10)
            {
                cboMay.DropDownRows = 15;
                cboTMay.DropDownRows = 15;
            }
            else
            {
                cboMay.DropDownRows = 10;
                cboTMay.DropDownRows = 10;
            }
        }

        private void LoadCmbLoaiYeuCauBT()
        {
            DataTable dtTmp = new DataTable();

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiYeuCauBaoTriAll", 0));
            //MS_LOAI_YEU_CAU_BT, TEN_LOAI_YEU_CAU_BT
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboLYCBT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboLYCBT.NullText = "";
            cboLYCBT.ValueMember = "MS_LOAI_YEU_CAU_BT";
            cboLYCBT.DisplayMember = "TEN_LOAI_YEU_CAU_BT";
            cboLYCBT.DataSource = dtTmp;
            //if (btnGhi.Visible)
            {
                cboLYCBT.Columns.Clear();
                cboLYCBT.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_LOAI_YEU_CAU_BT"));
                cboLYCBT.PopupWidth = 625;
                cboLYCBT.Columns["TEN_LOAI_YEU_CAU_BT"].Width = 450;
            }


            grvCTiet.Columns["MS_LOAI_YEU_CAU_BT"].ColumnEdit = cboLYCBT;
            cboLYCBT.EditValueChanged += new System.EventHandler(this.cboLYCBT_EditValueChanged);
        }

        private void LoadCmbLuoi()
        {
            LoadCmbMay();
            LoadCmbLoaiYeuCauBT();

            DataTable dtTmp = new DataTable();
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "H_YEU_CAU_NSD_MUC_UU_TIEN"));
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboMUTien =
                new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboMUTien.NullText = "";
            cboMUTien.ValueMember = "MS_UU_TIEN";
            cboMUTien.DisplayMember = "TEN_UU_TIEN";
            cboMUTien.DataSource = dtTmp;
            cboMUTien.Columns.Clear();
            cboMUTien.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_UU_TIEN"));

            try
            {
                if (iMucUTChung == 0) iMucUTChung = Convert.ToInt16(dtTmp.Rows[0]["MS_UU_TIEN"].ToString());
            }
            catch { }
            grvCTiet.Columns["MS_UU_TIEN"].ColumnEdit = cboMUTien;
            DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit datTimeEdit = new
                DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            grvCTiet.Columns["GIO_XAY_RA"].ColumnEdit = datTimeEdit;
            DataTable dtTmpNN = new DataTable();
            dtTmpNN = new DataTable();
            dtTmpNN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT MS_NGUYEN_NHAN,TEN_NGUYEN_NHAN FROM NGUYEN_NHAN_DUNG_MAY UNION SELECT -1,'' ORDER BY TEN_NGUYEN_NHAN"));
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboMsNNhan =
                new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            try
            {
                if (iMsNNChung == 0) iMsNNChung = Convert.ToInt16(dtTmpNN.Rows[1]["MS_NGUYEN_NHAN"].ToString());
            }
            catch { }
            cboMsNNhan.NullText = "";
            cboMsNNhan.ValueMember = "MS_NGUYEN_NHAN";
            cboMsNNhan.DisplayMember = "TEN_NGUYEN_NHAN";
            cboMsNNhan.DataSource = dtTmpNN;
            cboMsNNhan.Columns.Clear();
            cboMsNNhan.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_NGUYEN_NHAN"));
            grvCTiet.Columns["MS_NGUYEN_NHAN"].ColumnEdit = cboMsNNhan;


        }

        private void cboMay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!btnGhi.Visible) return;
                DevExpress.XtraEditors.LookUpEdit cbo = (DevExpress.XtraEditors.LookUpEdit)sender;
                if (grvCTiet.GetFocusedRowCellValue("MS_MAY_OLD").ToString() == "")
                    grvCTiet.SetFocusedRowCellValue("MS_MAY_OLD", "-1");
                grvCTiet.SetFocusedRowCellValue("TEN_MAY", cbo.EditValue);
            }
            catch { }

        }

        private void cboLYCBT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!btnGhi.Visible) return;
                DevExpress.XtraEditors.LookUpEdit cbo = (DevExpress.XtraEditors.LookUpEdit)sender;
                grvCTiet.SetFocusedRowCellValue("TEN_LOAI_YEU_CAU_BT", cbo.EditValue);
            }
            catch { }

        }

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                if (datTNgay.DateTime > datDNgay.DateTime)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "frmYeuCauCuaNSD", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                }

                if (Commons.Modules.SQLString == "0Load") return;
                LoadLuoiYCSD(-1, cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));
            }
            catch { LoadLuoiYCSD(-1, "-1", "01/01/1900", "01/01/2222"); }
        }
        private void datDNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            if (datTNgay.DateTime > datDNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmYeuCauCuaNSD", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                return;
            }
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;
                LoadLuoiYCSD(-1, cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));
            }
            catch { LoadLuoiYCSD(-1, "-1", "01/01/1900", "01/01/2222"); }

        }
        private void cboNYCau_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;
                LoadLuoiYCSD(-1, cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));
            }
            catch { LoadLuoiYCSD(-1, "-1", "01/01/1900", "01/01/2222"); }

        }
        private void grvYCSD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            LoadText();
        }

        private void datTNgay_Validating(object sender, CancelEventArgs e)
        {
            if (datTNgay.DateTime > datDNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmYeuCauCuaNSD", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
            }
        }

        private void datDNgay_Validating(object sender, CancelEventArgs e)
        {
            if (datTNgay.DateTime > datDNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmYeuCauCuaNSD", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                e.Cancel = true;
            }
        }

        private void tabYCSDung_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            btnThemBP.Enabled = false;
            if (!btnXoa.Visible)
            {
                if (tabYCSDung.SelectedTabPageIndex == 0)
                {
                    btnXoaYC.Enabled = true;
                    btnXoaCTYeuCau.Enabled = false;
                    btnXoaHinh.Enabled = false;

                }
                else
                {
                    if (tabYCSDung.SelectedTabPageIndex == 1)
                    {
                        btnXoaYC.Enabled = false;
                        btnXoaCTYeuCau.Enabled = true;
                        btnXoaHinh.Enabled = true;
                        //btnThemBP.Visible = false;

                    }
                    else
                    {
                        btnXoaYC.Enabled = false;
                        btnXoaCTYeuCau.Enabled = false;
                        btnXoaHinh.Enabled = false;
                    }
                }
            }
            btnXemHinh.Visible = false;
            if (tabYCSDung.SelectedTabPageIndex == 1)
            {
                Commons.Modules.SQLString = "0Load";
                try
                {
                    LoadLuoiChiTiet(int.Parse(grvYCSD.GetFocusedRowCellValue("STT").ToString()));
                }
                catch { LoadLuoiChiTiet(-1); }
                Commons.Modules.SQLString = "";
                if (grvCTiet.RowCount == 0)
                {
                    LoadLuoiChiTietHinh(-1, -1, "-1");
                    btnThemBP.Enabled = false;
                }
                else
                {
                    btnThemBP.Enabled = true;
                    LoadLuoiChiTietHinh(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                     int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
                }

                try
                {
                    LoadBP(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                       int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
                }
                catch
                {
                    LoadBP(-1, -1, "-1");
                }


                DataTable dt = (DataTable)grdYCSDHinh.DataSource;
                if (dt.Rows.Count > 0)
                    btnXemHinh.Visible = true;
                else
                    btnXemHinh.Visible = false;
            }
            if (tabYCSDung.SelectedTabPageIndex == 2)
            {
                try
                {
                    LoadLuoiXuLy(int.Parse(grvYCSD.GetFocusedRowCellValue("STT").ToString()));
                }
                catch { LoadLuoiXuLy(-1); }
            }
            Commons.Modules.SQLString = "";
            txtTK.Text = "";
        }
        private void LoadBP(int STT, int STT_VAN_DE, string MS_MAY)
        {
            try
            {
                if (Commons.Modules.SQLString == "0Load") return;
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_BO_PHAN", STT, MS_MAY, STT_VAN_DE));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBP, grvBP, dtTmp, false, false, true, false, true, "");

                grvBP.Columns["STT"].Visible = false;
                grvBP.Columns["MS_MAY"].Visible = false;
                grvBP.Columns["STT_VAN_DE"].Visible = false;
                grvBP.Columns["DEL"].Visible = false;
                grvBP.Columns["STT_BO_PHAN"].Visible = false;
                grvBP.Columns["MS_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_BO_PHAN", Commons.Modules.TypeLanguage);
                grvBP.Columns["TEN_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_BO_PHAN", Commons.Modules.TypeLanguage);
                grvBP.Columns["TEN_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_PT", Commons.Modules.TypeLanguage);
                grvBP.Columns["MS_PT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_PT", Commons.Modules.TypeLanguage);

            }
            catch
            { }
        }
        private void grvCTiet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0Load") return;
            try
            {
                LoadLuoiChiTietHinh(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                    int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
            }
            catch
            {
                LoadLuoiChiTietHinh(-1, -1, "-1");
            }

            try
            {
                LoadBP(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                   int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
            }
            catch
            {
                LoadBP(-1, -1, "-1");
            }
            for (int i = 0; i < grvCTiet.Columns.Count; i++)
            {
                grvCTiet.Columns[i].OptionsColumn.ReadOnly = false;
            }
            grvCTiet.Columns["TEN_MAY"].OptionsColumn.ReadOnly = true;
            try
            {
                string sSql = " SELECT COUNT(*) FROM YEU_CAU_NSD_CHI_TIET WHERE STT = " + txtSTT.Text + " AND ISNULL(THUC_HIEN_DSX,0) = 1 " +
                            " AND MS_MAY = N'" + grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString() + "' ";

                if (Convert.ToInt32((SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql))) != 0)
                {
                    for (int i = 0; i < grvCTiet.Columns.Count; i++)
                    {
                        grvCTiet.Columns[i].OptionsColumn.ReadOnly = true;
                    }
                }
            }
            catch { }
            grvCTiet.Columns["TEN_MAY"].OptionsColumn.ReadOnly = true;
            Commons.Modules.SQLString = "";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0Load";
            if (rdoGroupDuyet.SelectedIndex != 0) rdoGroupDuyet.SelectedIndex = 0;
            string s = "-1";
            try
            {
                s = cboNXuong.EditValue.ToString();
            }
            catch { }
            tabYCSDung.SelectedTabPageIndex = 1;
            Commons.Modules.SQLString = "";
            LoadLuoiChiTiet(-1);
            LoadLuoiChiTietHinh(-1, -1, "-1");
            LoadTextTrang();
            txtSTT.Text = "-1";
            btnThemBP.Visible = false;
            LockControl(false);
            //WR-201306000001
            //DateTime Ngay;
            //Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
            //int iMax = (int)SqlHelper.ExecuteScalar[Commons.IConnections.ConnectionString, "MGetIDYCSD", "WR", Ngay.ToString("MM/dd/yyyy"));
            //txtMYC.Text = "WR-" + Ngay.ToString("yyyyMM") + iMax.ToString("000000");

            txtMYC.Text = TaoMaYCSD();
            datNYCau.DateTime = DateTime.Now.Date;
            txtGioYC.Time = DateTime.Now;

            LoadCmbMay();
            if (Commons.Modules.iDefault == 1 | Commons.Modules.iDefault == 2) txtSYCau.Text = txtMYC.Text;
            if (Commons.Modules.iDefault == 2) txtSYCau.Enabled = false;

            if (!string.IsNullOrEmpty( Commons.Modules.sTenNhanVienMD))
            {
                txtNYCau.Text = Commons.Modules.sTenNhanVienMD;
                //cboNguoiYeuCau.Text = Commons.Modules.sTenNhanVienMD;
            }
            else txtNYCau.Text = Commons.Modules.UserName;

            //try
            //{
            //    cboNXuong.EditValue = ((DataTable)cboNXuong.DataSource).Rows[0]["MS_N_XUONG"].ToString();
            //    cboNXuong.SelectedIndex = 0;
            //}
            //catch
            //{

            //}
            bThem = true;
            Commons.Modules.SQLString = "";
        }

        private string TaoMaYCSD()
        {
            DateTime Ngay;
            string MsYC = "";
            int iMax = 0;
            Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
            try
            {
                iMax = (int)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "MGetIDYCSD", "WR", Ngay.ToString("MM/dd/yyyy"));
                MsYC = "WR-" + Ngay.ToString("yyyyMM") + iMax.ToString("000000");
            }
            catch { MsYC = "WR-" + Ngay.ToString("yyyyMM") + 1.ToString("000000"); }
            if (KiemMaYCSD(MsYC))
            {
                iMax = iMax + 1;
                MsYC = "WR-" + Ngay.ToString("yyyyMM") + iMax.ToString("000000");
            }
            if (KiemMaYCSD(MsYC))
            {
                iMax = iMax + 1;
                MsYC = "WR-" + Ngay.ToString("yyyyMM") + iMax.ToString("000000");
            }
            return MsYC;
        }
        private Boolean KiemMaYCSD(string MsYC)
        {
            string sSql = "";
            sSql = "SELECT COUNT(*)  FROM YEU_CAU_NSD WHERE MS_YEU_CAU = '" + MsYC + "'";
            try
            {
                if (int.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql).ToString()) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return true;
            }
        }
        private Boolean KiemYCSDTheoUser(string MsYC, string user)
        {
            string sSql = "";
            sSql = "SELECT count(*)  FROM YEU_CAU_NSD WHERE MS_YEU_CAU = '" + MsYC + "' and USER_LAP = '" + user + "'";
            try
            {
                if (int.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql).ToString()) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvYCSD.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "khongcodulieusua", Commons.Modules.TypeLanguage));
                return;
            }

            if (KiemYCSDTheoUser(grvYCSD.GetFocusedRowCellValue("MS_YEU_CAU").ToString(), Commons.Modules.UserName) == false)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "msgKhongcoquyensuaxoa", Commons.Modules.TypeLanguage));
                return;
            }

            Commons.Modules.SQLString = "0Load";
            tabYCSDung.SelectedTabPageIndex = 1;
            btnThemBP.Visible = false;
            Commons.Modules.SQLString = "";
            LockControl(false);
            LoadCmbMay();
            txtSTT.Text = grvYCSD.GetFocusedRowCellValue("STT").ToString();
            if (Boolean.Parse(grvYCSD.GetFocusedRowCellValue("THUC_HIEN_DSX").ToString()))
            {
                txtSTT.Properties.ReadOnly = true;
                txtSYCau.Properties.ReadOnly = true;
                datNYCau.Properties.ReadOnly = true;
                txtGioYC.Properties.ReadOnly = true;
                txtNYCau.Properties.ReadOnly = true;
                datNHThanh.Properties.ReadOnly = true;
                cboNXuong.ReadOnly = true;
                cboNguoiYeuCau.Properties.ReadOnly = true;
                //txtMail.Properties.ReadOnly = true;
            }
            if (Commons.Modules.iDefault == 2) txtSYCau.Enabled = false;

            Commons.Modules.SQLString = "";
            bThem = false;
            cboNXuong.ReadOnly = true;
        }
        private void AnHienXoa(Boolean bLocked)
        {
            btnXoaYC.Visible = bLocked;
            btnXoaCTYeuCau.Visible = bLocked;
            btnXoaHinh.Visible = bLocked;
            btnXoaBoPhan.Visible = bLocked;
            btnTroVe.Visible = bLocked;
            btnThem.Visible = !bLocked;
            btnSua.Visible = !bLocked;
            btnXoa.Visible = !bLocked;
            btnThoat.Visible = !bLocked;
            btnIN.Visible = !bLocked;


            if (tabYCSDung.SelectedTabPageIndex == 0)
            {
                btnXoaYC.Enabled = true;
                btnXoaCTYeuCau.Enabled = false;
                btnXoaHinh.Enabled = false;
                btnXoaBoPhan.Enabled = false;
            }
            else
            {
                if (tabYCSDung.SelectedTabPageIndex == 1)
                {
                    btnXoaYC.Enabled = false;
                    btnXoaCTYeuCau.Enabled = true;
                    btnXoaHinh.Enabled = true;
                    btnXoaBoPhan.Enabled = true;
                }
                else
                {
                    btnXoaYC.Enabled = false;
                    btnXoaCTYeuCau.Enabled = false;
                    btnXoaHinh.Enabled = false;
                    btnXoaBoPhan.Enabled = false;
                }
            }
            if (btnTroVe.Visible)
            {
                btnGoiMai.Enabled = false;
                btnXemHinh.Visible = false;
            }
            else
            {
                btnXemHinh.Visible = false;
                btnGoiMai.Enabled = true;
                if (tabYCSDung.SelectedTabPageIndex == 1)
                {
                    btnXemHinh.Visible = true;
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdYCSD.DataSource == null)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "msgKhongCoDuLieuXoa", Commons.Modules.TypeLanguage));
                    return;
                }
                if (grvYCSD.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "msgKhongCoDuLieuXoa", Commons.Modules.TypeLanguage));
                    return;
                }
                if (KiemYCSDTheoUser(grvYCSD.GetFocusedRowCellValue("MS_YEU_CAU").ToString(), Commons.Modules.UserName) == false)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "msgKhongcoquyensuaxoa", Commons.Modules.TypeLanguage));
                    return;
                }
                btnThemBP.Visible = false;
                AnHienXoa(true);
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //GoiMailYeuCau(6);
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string s = cboNXuong.EditValue.ToString();
            if (!KiemGhi()) return;
            int iSTT = -1;
            string sBTam, sSql;
            sBTam = "ZZZ_YCSD_CT" + Commons.Modules.UserName;
            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)grdCTiet.DataSource;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");
            DataRow[] result = dtTmp.Select("ISNULL(MO_TA_TINH_TRANG,'') = '' OR ISNULL(MS_UU_TIEN,0) = 0  OR ISNULL(MS_MAY,'') = '' OR ISNULL(MS_NGUYEN_NHAN,0) = 0 ");
            if (result.Length > 0)
            {
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["STT_VAN_DE"] };
                int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(result[0]["STT_VAN_DE"]));
                grvCTiet.FocusedRowHandle = grvCTiet.GetRowHandle(index);

                if (grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "BanChuaNhapMay",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (grvCTiet.GetFocusedRowCellValue("MO_TA_TINH_TRANG").ToString() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "BanChuaNhapMoTaTinhTrang",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (grvCTiet.GetFocusedRowCellValue("MS_NGUYEN_NHAN").ToString() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "BanChuaChonNguyenNhan",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (grvCTiet.GetFocusedRowCellValue("MS_UU_TIEN").ToString() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "BanChuaNhapMucUuTien",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            sSql = "SELECT * FROM " + sBTam + " WHERE ISNULL(MO_TA_TINH_TRANG,'') = '' OR ISNULL(MS_UU_TIEN,'') = ''  OR ISNULL(MS_MAY,'') = '' ";
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "BanChuaNhapDuDuLieu",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #region Cap Nhap CSDL

            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            SqlTransaction tran;
            sSql = "";

            if (KiemMaYCSD(txtMYC.Text))
            {
                txtMYC.Text = TaoMaYCSD();
                if (Commons.Modules.iDefault == 1 | Commons.Modules.iDefault == 2) txtSYCau.Text = txtMYC.Text;
            }
            if (con.State == ConnectionState.Closed)
                con.Open();
            tran = con.BeginTransaction();

            try
            {

                string nHThanh;
                nHThanh = (datNHThanh.Text == "" ? "NULL" : datNHThanh.DateTime.ToString("MM/dd/yyyy"));

                iSTT = Convert.ToInt32((SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "AddYEU_CAU_NSD", txtMYC.Text, txtSYCau.Text,
                    datNYCau.DateTime.Date, DateTime.Parse(txtGioYC.Text), (datNHThanh.Text == "" ? null : datNHThanh.DateTime.ToString("yyyy/MM/dd")),
                    txtNYCau.Text, cboNXuong.EditValue, "", txtMail.Text, int.Parse(txtSTT.Text), Commons.Modules.UserName)));

                sSql = "  DELETE FROM YEU_CAU_NSD_CHI_TIET WHERE (STT = " + iSTT.ToString() + ") " +
                             " AND NOT EXISTS (SELECT * FROM " + sBTam + " B WHERE  YEU_CAU_NSD_CHI_TIET.MS_MAY = B.MS_MAY_OLD AND " +
                             " YEU_CAU_NSD_CHI_TIET.STT = B.STT AND YEU_CAU_NSD_CHI_TIET.STT_VAN_DE = B.STT_VAN_DE_OLD ) ";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);

                sSql = " INSERT INTO [YEU_CAU_NSD_CHI_TIET] (MS_MAY, MO_TA_TINH_TRANG, YEU_CAU, NGAY_XAY_RA, GIO_XAY_RA, MS_UU_TIEN, STT, MS_LOAI_YEU_CAU_BT,MS_NGUYEN_NHAN) " +
                            " SELECT MS_MAY, MO_TA_TINH_TRANG, YEU_CAU, NGAY_XAY_RA, GIO_XAY_RA, MS_UU_TIEN, " + iSTT.ToString() + ", MS_LOAI_YEU_CAU_BT, " +
                            " CASE ISNULL(MS_NGUYEN_NHAN,-1) WHEN -1 THEN NULL ELSE MS_NGUYEN_NHAN END" +
                            " FROM " + sBTam + " A " +
                            " WHERE MS_MAY_OLD = '-1' ";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);


                sSql = " UPDATE YEU_CAU_NSD_CHI_TIET SET YEU_CAU_NSD_CHI_TIET.MS_MAY = B.MS_MAY, " +
                        " YEU_CAU_NSD_CHI_TIET.MO_TA_TINH_TRANG = B.MO_TA_TINH_TRANG, " +
                        " YEU_CAU_NSD_CHI_TIET.YEU_CAU = B.YEU_CAU, " +
                        " YEU_CAU_NSD_CHI_TIET.NGAY_XAY_RA = B.NGAY_XAY_RA, " +
                        " YEU_CAU_NSD_CHI_TIET.GIO_XAY_RA = B.GIO_XAY_RA, " +
                        " YEU_CAU_NSD_CHI_TIET.MS_UU_TIEN = B.MS_UU_TIEN, " +
                        " YEU_CAU_NSD_CHI_TIET.MS_LOAI_YEU_CAU_BT = B.MS_LOAI_YEU_CAU_BT, " +
                        " YEU_CAU_NSD_CHI_TIET.MS_NGUYEN_NHAN = CASE ISNULL(B.MS_NGUYEN_NHAN,-1) WHEN -1 THEN NULL ELSE B.MS_NGUYEN_NHAN END " +
                        " FROM dbo.YEU_CAU_NSD_CHI_TIET AS A INNER JOIN " + sBTam + " AS B ON A.MS_MAY = B.MS_MAY_OLD AND A.STT_VAN_DE = B.STT_VAN_DE_OLD " +
                        " WHERE MS_MAY_OLD <> '-1' AND  A.STT = " + iSTT.ToString();
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);
                tran.Commit();
                con.Close();
            }
            catch
            {
                tran.Rollback();
                con.Close();
            }
            #endregion



            Commons.Modules.ObjSystems.XoaTable(sBTam);
            btnThemBP.Visible = true;
            LockControl(true);
            Commons.Modules.SQLString = "0Load";
            sSql = cboNYCau.EditValue.ToString();
            LoadNguoiYC();
            cboNYCau.EditValue = sSql;
            LoadLuoiYCSD(iSTT, cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));
            try
            {
                LoadLuoiChiTiet(int.Parse(grvYCSD.GetFocusedRowCellValue("STT").ToString()));
            }
            catch { LoadLuoiChiTiet(-1); }

            if (grvCTiet.RowCount == 0)
            {
                btnThemBP.Enabled = false;
                LoadLuoiChiTietHinh(-1, -1, "-1");
                LoadBP(-1, -1, "-1");
            }
            else
            {
                LoadLuoiChiTietHinh(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                    int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());

                LoadBP(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                    int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
                btnThemBP.Enabled = true;
            }
            LoadCmbMay();
            Commons.Modules.SQLString = "";
            //LoadText();
            #region "GoiMail"
            if (duyetLapPhieu == false)
            {
                if (duyetTuDong == true)
                {
                    if (bThem)
                        GoiMail();
                    else
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoMuonGoiMailLai",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) GoiMail();
                }
            }
            #endregion
            //nếu user có quyền duyệt trên phiếu lập(1) và có quyền bên duyệt(2) thì cập nhật tự động duyệt
            #region "Cap nhap tu dong duyet"
            if (duyetTuDong == true)
            {
                if (duyetLapPhieu == false)
                {
                    //nếu là không có chức năng duyệt trong thông tin chung
                    if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 13))
                    {
                        if (bThem)
                            DuyetYeuCau(iSTT);
                        else
                            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoMuonGoiMailTuDongDuyetlai",
                                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) DuyetYeuCau(iSTT);
                    }
                }
                else
                {

                    //kiểm tra the
                    if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 13) && Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 117))
                    {
                        btnDuyet_Click(null, null);
                    }
                }
            }
            #endregion
            Commons.Modules.ObjSystems.XoaTable(sBTam);
            bThem = false;
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            btnThemBP.Visible = true;
            LockControl(true);

            try
            {
                LoadLuoiYCSD(int.Parse(txtSTT.Text), cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));
            }
            catch
            {
                LoadLuoiYCSD(-1, cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));
            }
            Commons.Modules.SQLString = "";
            //LoadText();
            try
            {
                LoadLuoiChiTiet(int.Parse(grvYCSD.GetFocusedRowCellValue("STT").ToString()));
            }
            catch { LoadLuoiChiTiet(-1); }

            if (grvCTiet.RowCount == 0)
            {
                btnThemBP.Enabled = false;
                LoadLuoiChiTietHinh(-1, -1, "-1");
                LoadBP(-1, -1, "-1");
            }
            else
            {
                LoadLuoiChiTietHinh(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                    int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());

                LoadBP(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                    int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
                btnThemBP.Enabled = true;
            }
            try
            {
                LoadLuoiXuLy(int.Parse(grvYCSD.GetFocusedRowCellValue("STT").ToString()));
            }
            catch { LoadLuoiXuLy(-1); }
            LoadCmbMay();

            bThem = false;

        }

        private void tabYCSDung_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (btnGhi.Visible || !btnThemBP.Visible)
            {
                e.Cancel = true;
                return;
            }
        }

        private void grvCTiet_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (btnGhi.Visible == false) return;
                if (txtSTT.Text == "-1")
                    grvCTiet.GetDataRow(grvCTiet.FocusedRowHandle)["STT"] = "-1";
                else
                    grvCTiet.GetDataRow(grvCTiet.FocusedRowHandle)["STT"] = txtSTT.Text;

                grvCTiet.SetFocusedRowCellValue("THUC_HIEN_DSX", 0);

                if (iMsNNChung!=0 )grvCTiet.SetFocusedRowCellValue("MS_NGUYEN_NHAN", iMsNNChung);
                if (iMucUTChung != 0) grvCTiet.SetFocusedRowCellValue("MS_UU_TIEN", iMucUTChung);

            }
            catch { }
        }

        private Boolean KiemGhi()
        {
            try
            {
                DateTime dNKiem;
                #region Kiem Ma so yeu cau
                if (txtMYC.Text.Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaNhapMaSoYeuCau",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMYC.Focus();
                    return false;
                }
                #endregion

                #region Kiem so yeu cau
                if (txtSYCau.Text.Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaNhapSoYeuCau",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSYCau.Focus();
                    return false;
                }
                #endregion

                #region Kiem So yeu cau
                if (txtSYCau.Text.Trim() != "" && txtSTT.Text == "-1")
                {
                    string sSql = "SELECT * FROM YEU_CAU_NSD WHERE SO_YEU_CAU = N'" + txtSYCau.Text + "' ";
                    DataTable dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TrungSoYeuCau",
                            Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSYCau.Focus();
                        return false;
                    }
                }
                #endregion

                #region Kiem Ngay yeu cau
                if (datNYCau.Text.Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NgayYeuCauKhongDuocTrong",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    datNYCau.Focus();
                    return false;
                }

                try
                {
                    if (!DateTime.TryParse(datNYCau.Text, out dNKiem))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NgayYeuCauKhongPhaiKieuNgay",
                            Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        datNYCau.Focus();
                        return false;

                    }
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NgayYeuCauKhongPhaiKieuNgay",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    datNYCau.Focus();
                    return false;
                }
                #endregion

                #region Kiem Gio yeu cau
                if (txtGioYC.Text.Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra10",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGioYC.Focus();
                    return false;
                }

                try
                {
                    if (!DateTime.TryParse(txtGioYC.Text, out dNKiem))
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "GioYeuCauKhongPhaiKieuGio",
                            Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtGioYC.Focus();
                        return false;

                    }
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaNhapGioYeuCau",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGioYC.Focus();
                    return false;

                }
                #endregion

                #region Kiem Ngay hoan thanh
                if (datNHThanh.Text.Trim() != "")
                {
                    try
                    {
                        if (!DateTime.TryParse(datNHThanh.Text, out dNKiem))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "NgayHoanThanhKhongPhaiKieuNgay",
                                                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            datNHThanh.Focus();
                            return false;

                        }
                        else
                        {
                            if (datNYCau.DateTime.Date > datNHThanh.DateTime.Date)
                            {
                                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra4",
                                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                datNHThanh.Focus();
                                return false;
                            }
                        }
                    }
                    catch
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra4",
                            Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        datNHThanh.Focus();
                        return false;
                    }
                }
                #endregion

                #region Kiem Nguoi yeu cau
                if (txtNYCau.Text.Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra8",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboNguoiYeuCau.Focus();
                    return false;
                }
                #endregion

                #region Kiem Nguoi yeu cau
                if (cboNXuong.TextValue.Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaNhapNhaXuong",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboNXuong.Focus();
                    return false;
                }
                #endregion

                #region Kiem mail
                if (txtMail.Text.Length != 0)
                {
                    //string[] sMail = String.Split(txtMail.Text, ";");
                    string[] sMail = txtMail.Text.Split(new Char[] { ';' });
                    for (int i = 0; i <= sMail.Length - 1; i++)
                    {
                        if (Commons.Modules.ObjSystems.MCheckEmail(sMail[i]) == false)
                        {
                            string sTmp;
                            sTmp = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongPhaiMail", Commons.Modules.TypeLanguage);
                            XtraMessageBox.Show(sMail[i] + " " + sTmp, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMail.Focus();
                            return false;
                        }
                    }

                }
                #endregion
            }
            catch { return false; }
            return true;
        }



        private void cboNXuong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {


        }

        private void grvYCSDHinh_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            grvYCSDHinh.SetFocusedRowCellValue("STT", grvCTiet.GetFocusedRowCellValue("STT").ToString());
            grvYCSDHinh.SetFocusedRowCellValue("MS_MAY", grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
            grvYCSDHinh.SetFocusedRowCellValue("STT_VAN_DE", grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString());
        }

        private void grvYCSDHinh_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            btnThemBP.Visible = true;
            AnHienXoa(false);
            if (grvYCSDHinh.RowCount == 0)
            {
                btnXemHinh.Visible = false;
            }
            else
                btnXemHinh.Visible = true;

        }

        private void btnXoaYC_Click(object sender, EventArgs e)
        {
            if (grvYCSD.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                    "MsgNoData", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Boolean.Parse(grvYCSD.GetFocusedRowCellValue("THUC_HIEN_DSX").ToString()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                    "DaDSXKhongXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                "MsgQuyenXoa1", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_HINHs",
                    (int)grvYCSD.GetFocusedRowCellValue("STT"), "-1", -1));
                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    Commons.Modules.ObjSystems.Xoahinh(dtTmp.Rows[i]["DUONG_DAN"].ToString());
                }


                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteYEU_CAU_NSD", (int)grvYCSD.GetFocusedRowCellValue("STT"));
                Commons.Modules.SQLString = "0Load";

                LoadNguoiYC();
                Commons.Modules.SQLString = "";
                LoadLuoiYCSD(-1, cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));
                LoadText();
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                    "XoaKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoaCTYeuCau_Click(object sender, EventArgs e)
        {
            if (grvCTiet.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                    "MsgNoData", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Boolean.Parse(grvCTiet.GetFocusedRowCellValue("THUC_HIEN_DSX").ToString()))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                    "DaDSXKhongXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                "MsgQuyenXoa2", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetYEU_CAU_NSD_CHI_TIET_HINHs",
                    (int)grvYCSD.GetFocusedRowCellValue("STT"), grvCTiet.GetFocusedRowCellValue("MS_MAY"),
                    (int)grvCTiet.GetFocusedRowCellValue("STT_VAN_DE")));
                for (int i = 0; i < dtTmp.Rows.Count; i++)
                {
                    Commons.Modules.ObjSystems.Xoahinh(dtTmp.Rows[i]["DUONG_DAN"].ToString());
                }


                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteYEU_CAU_NSD_CHI_TIET",
                    (int)grvYCSD.GetFocusedRowCellValue("STT"), grvCTiet.GetFocusedRowCellValue("MS_MAY"),
                    (int)grvCTiet.GetFocusedRowCellValue("STT_VAN_DE"));

                Commons.Modules.SQLString = "0Load";
                try
                {
                    LoadLuoiChiTiet(int.Parse(grvYCSD.GetFocusedRowCellValue("STT").ToString()));
                }
                catch { LoadLuoiChiTiet(-1); }
                Commons.Modules.SQLString = "";
                if (grvCTiet.RowCount == 0)
                {
                    btnThemBP.Enabled = false;
                    LoadLuoiChiTietHinh(-1, -1, "-1");
                    LoadBP(-1, -1, "-1");
                }
                else
                {
                    LoadLuoiChiTietHinh(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                        int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());

                    LoadBP(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                        int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
                    btnThemBP.Enabled = true;
                }
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                    "XoaKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaHinh_Click(object sender, EventArgs e)
        {
            if (grvYCSDHinh.RowCount == 1)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                    "MsgNoData", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string sSql = "";
            sSql = "SELECT STT_YC_NSD FROM EOR_REFFERENCE WHERE STT_YC_NSD=" + grvYCSDHinh.GetFocusedRowCellValue("STT_HINH").ToString() +
                " UNION  SELECT STT_GSTT FROM PHIEU_BAO_TRI_HINH WHERE STT_YC_NSD=" + grvYCSDHinh.GetFocusedRowCellValue("STT_HINH").ToString();
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                    "MsgTonTai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                "MsgQuyenXoa3", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                Commons.Modules.ObjSystems.Xoahinh(grvYCSDHinh.GetFocusedRowCellValue("DUONG_DAN").ToString());
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, "DeleteYEU_CAU_NSD_CHI_TIET_HINH",
                    (int)grvYCSD.GetFocusedRowCellValue("STT"), grvCTiet.GetFocusedRowCellValue("MS_MAY"),
                    (int)grvCTiet.GetFocusedRowCellValue("STT_VAN_DE"), (int)grvYCSDHinh.GetFocusedRowCellValue("STT_HINH"));
                if (grvCTiet.RowCount == 0)
                {
                    LoadLuoiChiTietHinh(-1, -1, "-1");
                    btnThemBP.Enabled = false;
                }
                else
                {
                    LoadLuoiChiTietHinh(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                        int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
                    btnThemBP.Enabled = true;
                }
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                    "XoaKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvYCSDHinh.RowCount <= 1) return;
                System.Diagnostics.Process.Start(grvYCSDHinh.GetFocusedRowCellValue("DUONG_DAN").ToString());
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtra9",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGoiMai_Click(object sender, EventArgs e)
        {
            GoiMail();
        }
        private void GoiMail()
        {
            try
            {
                if (grvYCSD.RowCount == 0)
                {
                    //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    //        "KhongCoDuLieuGoiMail", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboNXuong.EditValue.ToString() == "")
                {
                    //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    //        "ChuaChonNhaXuong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadLuoiChiTiet(int.Parse(grvYCSD.GetFocusedRowCellValue("STT").ToString()));
                if (grvCTiet.RowCount == 0)
                {
                    //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    //        "KhongCoChiTiet", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Commons.Modules.iLoaiGoiMail == 1 || Commons.Modules.iLoaiGoiMail == 3)
                {
                    if (Commons.Modules.sMailFrom == "" || Commons.Modules.sMailFromPass == "" ||
                        Commons.Modules.sMailFromSmtp == "" || Commons.Modules.sMailFromPort == "")
                    {
                        //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        //        "KhongCoThongTinMailGoi", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                frmPBTBanHanh frm = new frmPBTBanHanh();
                DataTable dtMay = new DataTable();
                frm.iLoai = 2;
                string sSql;
                string sNXuong;
                sSql = "SELECT DBO.MGetNXUongCha( N'" + cboNXuong.EditValue.ToString() + "')";
                sNXuong = (string)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                string[] sMsNx = sNXuong.Split(new Char[] { ';' });
                sSql = "";
                sNXuong = "";
                for (int i = 0; i < sMsNx.Length; i++)
                {
                    sSql = sSql + (sSql == "" ? "" : " UNION ") +
                            "SELECT EMAIL FROM dbo.NHA_XUONG_EMAIL WHERE (MS_LOAI_EMAIL = 1) AND (MS_N_XUONG = N'" + sMsNx.GetValue(i).ToString() + "')";
                }
                sSql = " DECLARE @listStr1 VARCHAR(1000) " +
                            " SELECT @listStr1 = COALESCE(ISNULL( RTRIM(LTRIM(@listStr1)),'') ,'') +  " +
                            " + CASE LEN(ISNULL(RTRIM(LTRIM(@listStr1)),'')) WHEN 0 THEN '' ELSE ';' END + " +
                            " ISNULL(EMAIL,'')  " +
                            " FROM (" + sSql + ") A  " +
                            " SELECT ISNULL(@listStr1,'') AS EMAIL ";


                sNXuong = sNXuong + (sNXuong == "" ? "" : ";") + (string)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                sSql = "SELECT EMAIL FROM dbo.NHA_XUONG_EMAIL WHERE (MS_LOAI_EMAIL = 1) AND (MS_N_XUONG = N'" + cboNXuong.EditValue.ToString() + "')";
                sNXuong = sNXuong + (sNXuong == "" ? "" : ";") + (string)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql);



                sNXuong = sNXuong + (sNXuong == "" ? "" : ";") + (string)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT ISNULL(USER_MAIL,'') FROM dbo.USERS WHERE	USERNAME = '" + Commons.Modules.UserName + "'");

                sNXuong = sNXuong + (sNXuong == "" ? "" : ";") + txtMail.Text;


                sNXuong = Commons.Modules.ObjSystems.MBoMailUser(sNXuong);

                frm.sNXuong = sNXuong;
                frm.dtTmp = new DataTable();
                frm.dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMailYCNSDung",
                    (int)grvYCSD.GetFocusedRowCellValue("STT"), (int)Commons.Modules.TypeLanguage));
                if (frm.dtTmp.Rows.Count == 0)
                {
                    //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    //        "KhongCoDuLieuBaoCao", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frm.sNXuong = sNXuong;
                if (sNXuong == "" && frm.dtTmp.Rows[0]["MAIL_USER_LAP"].ToString() == "")
                {
                    //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    //        "KhongCoMail", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frm.ShowDialog();
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "GoiMailKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnChonMay_Click(object sender, EventArgs e)
        {
            if (cboNXuong.TextValue == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "ChuaChonNhaXuong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dtMay = new DataTable();
            DataTable dtMayLuoi = new DataTable();
            string sBTMay, sBTLuoi, sSql;
            sBTMay = "ZZZ_MAY" + Commons.Modules.UserName;
            sBTLuoi = "ZZZ_MAY_LUOI" + Commons.Modules.UserName;

            dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMAY_LOC_NHA_XUONG_New",
                    Commons.Modules.UserName, cboNXuong.EditValue, "-1", "-1", "-1", 0));
            dtMayLuoi = (DataTable)grdCTiet.DataSource;

            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTMay, dtMay, "");
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTLuoi, dtMayLuoi, "");
            sSql = "SELECT CONVERT(BIT,0) AS CHON, MS_MAY, TEN_MAY,TEN_NHOM_MAY, TEN_LOAI_MAY FROM " + sBTMay +
                        "  WHERE MS_MAY NOT IN(SELECT MS_MAY FROM " + sBTLuoi + ") ORDER BY MS_MAY";
            frmYCSDChonMay frm = new frmYCSDChonMay();
            frm.dtMay = new DataTable();
            frm.dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            for (int i = 1; i <= frm.dtMay.Columns.Count - 1; i++)
            {
                frm.dtMay.Columns[i].ReadOnly = true;
            }
            Commons.Modules.SQLString = "";
            frm.iLoai = 1;
            if (frm.ShowDialog() == DialogResult.Cancel) return;
            DataRow drMayLuoi;
            frm.dtMay.DefaultView.RowFilter = "CHON = 1";
            foreach (DataRow drRow in frm.dtMay.DefaultView.ToTable().Rows)
            {
                drMayLuoi = dtMayLuoi.NewRow();
                drMayLuoi["MS_MAY"] = drRow["MS_MAY"].ToString();
                drMayLuoi["TEN_MAY"] = drRow["MS_MAY"].ToString();
                drMayLuoi["MS_MAY_OLD"] = "-1";
                drMayLuoi["STT"] = txtSTT.Text;
                if (iMsNNChung != 0) drMayLuoi["MS_NGUYEN_NHAN"]= iMsNNChung;
                if (iMucUTChung != 0) drMayLuoi["MS_UU_TIEN"]= iMucUTChung;
                dtMayLuoi.Rows.Add(drMayLuoi);
            }

        }

        private void grvCTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (!btnGhi.Visible) return;
            if (e.KeyCode == Keys.Delete)
            {

                if (grvCTiet.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "KhongDuLieuXoa", Commons.Modules.TypeLanguage));
                    return;
                }
                try
                {
                    if (grvCTiet.GetFocusedRowCellValue("THUC_HIEN_DSX").ToString() != "")
                    {
                        if (Boolean.Parse(grvCTiet.GetFocusedRowCellValue("THUC_HIEN_DSX").ToString()))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                                "DaDSXKhongXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                catch { }
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "CoXoaThietBiNay",
                    Commons.Modules.TypeLanguage), this.Name, MessageBoxButtons.YesNo) == DialogResult.No) return;




                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }

        }

        private void grvCTiet_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                if (Boolean.Parse(grvCTiet.GetFocusedRowCellValue("THUC_HIEN_DSX").ToString()))
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }



        private void frmYeuCauCuaNSD_FormClosing(object sender, FormClosingEventArgs e)
        {
            Commons.Modules.ObjSystems.XoaTable("ZZZ_MAY" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("ZZZ_MAY_LUOI" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("ZZZ_YCSD_CT" + Commons.Modules.UserName);
        }

        private void DuyetYeuCau(int iSTT)
        {
            string sSql = "";
            sSql = txtSTT.Text;
            DateTime NGio;
            try
            {
                NGio = DateTime.Parse(datNYCau.DateTime.Date.ToShortDateString() + " " + txtGioYC.Text);
            }
            catch { NGio = DateTime.Now; }

            sSql = "UPDATE YEU_CAU_NSD_CHI_TIET SET USERNAME_DSX = '" + Commons.Modules.UserName + "' , " +
                        " THOI_GIAN_DSX = '" + NGio.ToString("MM/dd/yyyy HH:mm:ss") + "' , " +
                        " THUC_HIEN_DSX = 1 FROM YEU_CAU_NSD_CHI_TIET WHERE STT = " + iSTT.ToString();
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.YEU_CAU_NSD SET DUYET = 1 WHERE STT = " + txtSTT.EditValue + " ");
            //GoiMailYeuCau(iSTT);
        }
        private void GoiMailYeuCau(int iSTT)
        {
            if (Commons.Modules.iLoaiGoiMail == 1 || Commons.Modules.iLoaiGoiMail == 3)
            {
                if (Commons.Modules.sMailFrom == "" || Commons.Modules.sMailFromPass == "" ||
                    Commons.Modules.sMailFromSmtp == "" || Commons.Modules.sMailFromPort == "")
                {
                    //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    //        "KhongCoThongTinMailGoi", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            string sNXuong, sMail, sSql;
            if (grvCTiet.RowCount == 0)
            {
                //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                //        "KhongCoDuLieuGoiMail", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sSql = "";
            //txtMail.Text = "thichxehoi@yahoo.com";
            if (txtMail.Text != "") sSql = sSql + ";" + txtMail.Text;
            sNXuong = (string)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                        " SELECT TOP 1 MS_N_XUONG FROM YEU_CAU_NSD WHERE STT = " + iSTT.ToString());
            sMail = (string)SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text,
                " SELECT ISNULL(USER_MAIL ,'') AS USER_MAIL FROM YEU_CAU_NSD A INNER JOIN USERS B ON A.USER_LAP = " +
                " B.USERNAME WHERE STT = " + iSTT.ToString());

            sSql = (sSql == "" ? "" : sSql + ";") + sMail;

            sNXuong = Commons.Modules.ObjSystems.MLoadMailNX(sNXuong, "", 2);

            sSql = (sNXuong == "" ? "" : ";" + sNXuong) + sSql;
            if (sSql == "")
            {
                //MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmDuyetSanXuat", "KhongCoMailGoi", Commons.Modules.TypeLanguage)];
                return;
            }

            frmPBTBanHanh frm = new frmPBTBanHanh();
            frm.iLoai = 3;

            sSql = Commons.Modules.ObjSystems.MBoMailUser(sSql);
            frm.sNXuong = sSql;
            frm.dtTmp = new DataTable();
            Commons.Modules.ObjSystems.XoaTable("DSX");
            sSql = " SELECT STT,STT_VAN_DE , MS_MAY INTO DSX FROM YEU_CAU_NSD_CHI_TIET WHERE STT = " + iSTT.ToString();
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            frm.dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMailDuyetYCBT", Commons.Modules.TypeLanguage, 0));
            Commons.Modules.ObjSystems.XoaTable("DSX");
            if (frm.dtTmp.Rows.Count == 0)
            {
                //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                //    "KhongCoDuLieuGoiMail", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frm.ShowDialog();
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            if (txtMYC.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                    Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "msgKhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                return;
            }
            try
            {
                //Commons.Modules.sPrivate = "ADC";
                if (Commons.Modules.sPrivate.Trim().ToUpper() == "VINHHOAN")
                {
                    InYeuCauNguoiSuDungVinhHoan();
                    return;
                }

                DataTable dtTmp = new DataTable();
                DataSet dtSet = new DataSet();
                dtSet = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetBCYeuCauNguoiSuDung",
                    Commons.Modules.UserName, txtMYC.Text, datNYCau.DateTime, Commons.Modules.TypeLanguage);


                frmReport frmBCao = new frmReport();
                if (Commons.Modules.sPrivate.Trim().ToUpper() == "ADC")
                {
                    frmBCao.rptName = "rptYeucauNguoiSuDung_ADC";
                }
                else if (Commons.Modules.sPrivate.Trim().ToUpper() == "VECO")
                {
                    frmBCao.rptName = "rptYeucauNguoiSuDung_VECO";
                }
                else
                {
                    frmBCao.rptName = "rptYeucauNguoiSuDung";

                }


                dtTmp = new DataTable();
                dtTmp = dtSet.Tables[0];
                dtTmp.TableName = "NSD";
                frmBCao.AddDataTableSource(dtTmp);


                dtTmp = new DataTable();
                dtTmp = dtSet.Tables[1];
                dtTmp.TableName = "NSD_CT";
                frmBCao.AddDataTableSource(dtTmp);

                if (dtSet.Tables[0].Rows.Count == 0 && dtSet.Tables[1].Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(
                        Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "msgKhongCoDuLieuIn", Commons.Modules.TypeLanguage));
                    return;
                }
                DataTable TbTieuDe = new DataTable();
                TbTieuDe = TieuDeYCSD();
                frmBCao.AddDataTableSource(TbTieuDe);
                frmBCao.ShowDialog(this);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "msgInLoi",
                    Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable TieuDeYCSD()
        {

            DataTable TbTieuDe = new DataTable();
            TbTieuDe.Columns.Add("TIEU_DE_YC");
            TbTieuDe.Columns.Add("MS_YC");
            TbTieuDe.Columns.Add("NGAY_YC");
            TbTieuDe.Columns.Add("NGUOI_YC");
            TbTieuDe.Columns.Add("DIA_DIEM");
            TbTieuDe.Columns.Add("MS_MAY");
            TbTieuDe.Columns.Add("TEN_MAY");
            TbTieuDe.Columns.Add("TEN_DC_YC");
            TbTieuDe.Columns.Add("TT_TB_TRUOC_SAU");
            TbTieuDe.Columns.Add("NOI_DUNG_YC");
            TbTieuDe.Columns.Add("NGUOI_YC_KT");
            TbTieuDe.Columns.Add("NGUOI_DUYET_YC");
            TbTieuDe.Columns.Add("KY_HO_TEN");
            TbTieuDe.Columns.Add("APPROVED_BY");

            TbTieuDe.Columns.Add("MS_BO_PHAN");
            TbTieuDe.Columns.Add("TEN_BO_PHAN");
            TbTieuDe.Columns.Add("MS_PT");
            TbTieuDe.Columns.Add("TEN_PT");
            TbTieuDe.Columns.Add("QUY_CACH");

            TbTieuDe.Columns.Add("TMP1");
            TbTieuDe.Columns.Add("TMP2");
            TbTieuDe.Columns.Add("TMP3");
            TbTieuDe.Columns.Add("TMP4");
            TbTieuDe.Columns.Add("TMP5");


            TbTieuDe.Columns.Add("TMP6");
            TbTieuDe.Columns.Add("TMP7");
            TbTieuDe.Columns.Add("TMP8");
            TbTieuDe.Columns.Add("TMP9");
            TbTieuDe.Columns.Add("TMP10");



            DataRow rTitle = TbTieuDe.NewRow();
            rTitle["MS_YC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_YC", Commons.Modules.TypeLanguage);
            rTitle["TIEU_DE_YC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TIEU_DE_YC", Commons.Modules.TypeLanguage);
            rTitle["NGAY_YC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "NGAY_YC", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_YC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "NGUOI_YC", Commons.Modules.TypeLanguage);
            rTitle["DIA_DIEM"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "DIA_DIEM", Commons.Modules.TypeLanguage);

            rTitle["MS_MAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_MAY", Commons.Modules.TypeLanguage);
            rTitle["TEN_MAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_MAY", Commons.Modules.TypeLanguage);
            rTitle["TEN_DC_YC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_DC_YC", Commons.Modules.TypeLanguage);
            rTitle["TT_TB_TRUOC_SAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TT_TB_TRUOC_SAU", Commons.Modules.TypeLanguage);
            rTitle["NOI_DUNG_YC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "NOI_DUNG_YC", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_YC_KT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "NGUOI_YC_KT", Commons.Modules.TypeLanguage);
            rTitle["NGUOI_DUYET_YC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "NGUOI_DUYET_YC", Commons.Modules.TypeLanguage);
            rTitle["KY_HO_TEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "KY_HO_TEN", Commons.Modules.TypeLanguage);
            rTitle["APPROVED_BY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "APPROVED_BY", Commons.Modules.TypeLanguage);
            rTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "YEU_CAU_CHUNG", Commons.Modules.TypeLanguage);
            rTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "STT", Commons.Modules.TypeLanguage);
            rTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TMP3", Commons.Modules.TypeLanguage);
            rTitle["TMP4"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TMP4", Commons.Modules.TypeLanguage);

            rTitle["MS_BO_PHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_BO_PHAN", Commons.Modules.TypeLanguage);
            rTitle["TEN_BO_PHAN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_BO_PHAN", Commons.Modules.TypeLanguage);
            rTitle["MS_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MS_PT", Commons.Modules.TypeLanguage);
            rTitle["TEN_PT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "TEN_PT", Commons.Modules.TypeLanguage);
            rTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "QUY_CACH", Commons.Modules.TypeLanguage);

            rTitle["TMP5"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MAU_SO", Commons.Modules.TypeLanguage);
            rTitle["TMP6"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "NGAY_BH", Commons.Modules.TypeLanguage);
            rTitle["TMP7"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "LAN_BH", Commons.Modules.TypeLanguage);
            rTitle["TMP8"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "MAU_SO1", Commons.Modules.TypeLanguage);
            rTitle["TMP9"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "NGAY_BH1", Commons.Modules.TypeLanguage);
            rTitle["TMP10"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "LAN_BH1", Commons.Modules.TypeLanguage);



            //TbTieuDe.Columns.Add("");
            //TbTieuDe.Columns.Add("TEN_BO_PHAN");
            //TbTieuDe.Columns.Add("");
            //TbTieuDe.Columns.Add("");
            //TbTieuDe.Columns.Add("");

            TbTieuDe.TableName = "TD_IN_YCSD";
            TbTieuDe.Rows.Add(rTitle);
            return TbTieuDe;

        }


        #region InYeuCauNguoiSuDungVinhHoan
        private void InYeuCauNguoiSuDungVinhHoan()
        {
            try
            {
                System.Data.DataTable dtTmp = new System.Data.DataTable();
                frmReport frmRpt = new frmReport();
                frmRpt.rptName = "rptYEUCAUNGUOISUDUNG_VH";
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
                connection.Open();

                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandText = "SP_YEUCAUNGUOISUDUNG";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MS_YEU_CAU", txtMYC.Text));


                System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                DataSet dsTmp = new DataSet();

                try
                {
                    adapter.Fill(dsTmp);
                }
                catch { }
                Int32 i = 0;
                for (i = 0; i <= dsTmp.Tables.Count - 1; i++)
                {
                    dtTmp = new System.Data.DataTable();
                    dtTmp = dsTmp.Tables[i];
                    switch (i)
                    {
                        case 0:
                            dtTmp.TableName = "YCNSD_INFO1";
                            break;

                        case 1:
                            dtTmp.TableName = "YCNSD_INFO2";
                            break;

                        case 2:
                            dtTmp.TableName = "YCNSD_DETAIL";
                            break;
                    }
                    frmRpt.AddDataTableSource(dtTmp);

                }
                frmRpt.AddDataTableSource(LanguageReportYeuCauNguoiSuDungVINHHOAN());
                Commons.Modules.SQLString = "0Design";
                frmRpt.ShowDialog();
                Commons.Modules.SQLString = "";
            }
            catch { }
        }
        private System.Data.DataTable LanguageReportYeuCauNguoiSuDungVINHHOAN()
        {
            System.Data.DataTable vtbTitle = new System.Data.DataTable();
            vtbTitle.TableName = "TIEU_DE_YCNSD";
            Int32 i = 0;
            for (i = 0; i <= 25; i++)
            {
                vtbTitle.Columns.Add();
            }
            try
            {
                vtbTitle.Columns[0].ColumnName = "YEU_CAU_NGUOI_SU_DUNG";
                vtbTitle.Columns[1].ColumnName = "MA_SO";
                vtbTitle.Columns[2].ColumnName = "NGAY_HIEU_LUC";
                vtbTitle.Columns[3].ColumnName = "LAN_SOAT_XET";

                vtbTitle.Columns[4].ColumnName = "STT";
                vtbTitle.Columns[5].ColumnName = "TEN_THIET_BI";
                vtbTitle.Columns[6].ColumnName = "MA";

                vtbTitle.Columns[7].ColumnName = "NOI_DUNG_YEU_CAU";
                vtbTitle.Columns[8].ColumnName = "MUC_DICH_YEU_CAU";

                vtbTitle.Columns[9].ColumnName = "MO_TA_CHI_TIET";
                vtbTitle.Columns[10].ColumnName = "THOI_HAN_THUC_HIEN";
                vtbTitle.Columns[11].ColumnName = "GHI_CHU";


                vtbTitle.Columns[12].ColumnName = "NGUOI_YEU_CAU";
                vtbTitle.Columns[13].ColumnName = "PHONG";
                vtbTitle.Columns[14].ColumnName = "DUYET";
                vtbTitle.Columns[15].ColumnName = "NGAY_LAP_PHIEU_YEU_CAU";


                vtbTitle.Columns[16].ColumnName = "NGUOI_THUC_HIEN";
                vtbTitle.Columns[17].ColumnName = "PHONG_THUC_HIEN";
                vtbTitle.Columns[18].ColumnName = "DUYET_THUC_HIEN";
                vtbTitle.Columns[19].ColumnName = "NGAY_HOAN_THANH";


                vtbTitle.Columns[20].ColumnName = "TMPA";
                vtbTitle.Columns[21].ColumnName = "TMPB";
                vtbTitle.Columns[22].ColumnName = "TMPC";
                vtbTitle.Columns[23].ColumnName = "TMPD";
                vtbTitle.Columns[24].ColumnName = "TMPE";

                System.Data.DataRow vRowTitle = vtbTitle.NewRow();
                String sBC = "rptYEUCAUNGUOISUDUNG_VH";

                vRowTitle["YEU_CAU_NGUOI_SU_DUNG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "YEU_CAU_NGUOI_SU_DUNG", Commons.Modules.TypeLanguage);


                vRowTitle["MA_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA_SO", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_HIEU_LUC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_HIEU_LUC", Commons.Modules.TypeLanguage);
                vRowTitle["LAN_SOAT_XET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "LAN_SOAT_XET", Commons.Modules.TypeLanguage);

                vRowTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "STT", Commons.Modules.TypeLanguage);
                vRowTitle["TEN_THIET_BI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TEN_THIET_BI", Commons.Modules.TypeLanguage);
                vRowTitle["MA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MA", Commons.Modules.TypeLanguage);
                vRowTitle["NOI_DUNG_YEU_CAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NOI_DUNG_YEU_CAU", Commons.Modules.TypeLanguage);
                vRowTitle["MUC_DICH_YEU_CAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MUC_DICH_YEU_CAU", Commons.Modules.TypeLanguage);
                vRowTitle["MO_TA_CHI_TIET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "MO_TA_CHI_TIET", Commons.Modules.TypeLanguage);
                vRowTitle["THOI_HAN_THUC_HIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "THOI_HAN_THUC_HIEN", Commons.Modules.TypeLanguage);
                vRowTitle["GHI_CHU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "GHI_CHU", Commons.Modules.TypeLanguage);


                vRowTitle["NGUOI_YEU_CAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_YEU_CAU", Commons.Modules.TypeLanguage);
                vRowTitle["PHONG"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHONG", Commons.Modules.TypeLanguage);
                vRowTitle["DUYET"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DUYET", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_LAP_PHIEU_YEU_CAU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_LAP_PHIEU_YEU_CAU", Commons.Modules.TypeLanguage);

                vRowTitle["NGUOI_THUC_HIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGUOI_THUC_HIEN", Commons.Modules.TypeLanguage);
                vRowTitle["PHONG_THUC_HIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "PHONG_THUC_HIEN", Commons.Modules.TypeLanguage);
                vRowTitle["DUYET_THUC_HIEN"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "DUYET_THUC_HIEN", Commons.Modules.TypeLanguage);
                vRowTitle["NGAY_HOAN_THANH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "NGAY_HOAN_THANH", Commons.Modules.TypeLanguage);

                vRowTitle["TMPA"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMPA", Commons.Modules.TypeLanguage);
                vRowTitle["TMPB"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMPB", Commons.Modules.TypeLanguage);
                vRowTitle["TMPC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMPC", Commons.Modules.TypeLanguage);
                vRowTitle["TMPD"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMPD", Commons.Modules.TypeLanguage);
                vRowTitle["TMPE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "TMPE", Commons.Modules.TypeLanguage);

                vtbTitle.Rows.Add(vRowTitle);
            }
            catch { }
            return vtbTitle;

        }
        #endregion

        private void grvYCSD_HiddenEditor(object sender, EventArgs e)
        {
            (sender as GridView).BestFitColumns();
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            bool validColumn = false;
            if (e.SelectedControl != grdCTiet)
                return;

            GridHitInfo hitInfo = grvCTiet.CalcHitInfo(e.ControlMousePosition);

            if (hitInfo.InRow == false)
                return;

            if (hitInfo.Column == null)
                return;

            //concern only the following fields
            if (hitInfo.Column.FieldName == "MS_MAY")
                validColumn = true;

            if (!validColumn)
                return;

            string toolTip = string.Empty;
            SuperToolTipSetupArgs toolTipArgs = new SuperToolTipSetupArgs();
            toolTipArgs.Title.Text = string.Empty;

            int row = hitInfo.RowHandle;
            string values = grvCTiet.GetRowCellDisplayText(row, "TEN_MAY").ToString();


            toolTipArgs.Contents.Text = values;
            e.Info = new ToolTipControlInfo();
            e.Info.Object = hitInfo.HitTest.ToString() + hitInfo.RowHandle.ToString();
            e.Info.ToolTipType = ToolTipType.SuperTip;
            e.Info.SuperTip = new SuperToolTip();
            e.Info.SuperTip.Setup(toolTipArgs);

        }
        private void DoRowDoubleClick_XuLy(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                menuClick = true;
                try
                {
                    LoadLuoiXuLy(int.Parse(grvYCSD.GetFocusedRowCellValue("STT").ToString()));
                }
                catch { LoadLuoiXuLy(-1); }
                GridViewInfo gv = (GridViewInfo)view.GetViewInfo();
                GridCellInfo cell = gv.GetGridCellInfo((grvCTiet.GetSelectedRows())[0], 0);
                Point p = new Point(Control.MousePosition.X - (info.HitPoint.X - cell.Bounds.Location.X), Control.MousePosition.Y + (20 - (info.HitPoint.Y - cell.Bounds.Location.Y)));

            }
        }
        private void DoRowMouseUp_XuLy(GridView view, Point pt)
        {

            GridHitInfo info = view.CalcHitInfo(pt);
            menuClick = true;
            try
            {
                LoadLuoiXuLy(int.Parse(grvYCSD.GetFocusedRowCellValue("STT").ToString()));
            }
            catch { LoadLuoiXuLy(-1); }
            GridViewInfo gv = (GridViewInfo)view.GetViewInfo();
            GridCellInfo cell = gv.GetGridCellInfo((grvCTiet.GetSelectedRows())[0], 0);
            Point p = new Point(Control.MousePosition.X - (info.HitPoint.X - cell.Bounds.Location.X), Control.MousePosition.Y + (20 - (info.HitPoint.Y - cell.Bounds.Location.Y)));

        }
        private void DoRowDoubleClick_YCSD(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                tabYCSDung.SelectedTabPage = tabYCSDung.TabPages[1];
            }
        }




        private void grvCTiet_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);

            DoRowDoubleClick_XuLy(view, pt);
        }

        private void grvYCSD_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick_YCSD(view, pt);
        }

        private void grvCTiet_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                DataTable DT = (DataTable)grdYCSDHinh.DataSource;
                if (DT.Rows.Count == 0)
                {
                    btnXemHinh.Visible = false;
                }
                else
                    btnXemHinh.Visible = true;
                //for (int counter = 0; counter < grdCTiet.ViewCollection.Count; counter++)
                //{
                //    if (grdCTiet.ViewCollection[counter].GetType() == typeof(GridView))
                //    {

                //        GridView view = (GridView)grdCTiet.ViewCollection[counter] as GridView;
                //        Point pt = view.GridControl.PointToClient(Control.MousePosition);

                //        DoRowMouseUp_XuLy(view, pt);
                //        break;
                //    }
                //}

            }
            catch (Exception)
            {


            }
        }

        private void txtMail_EditValueChanged(object sender, EventArgs e)
        {

        }
        bool bThemBP = false;
        DataTable dtBP = new DataTable();
        string sBT = "ChonBoPhanChoMay" + Commons.Modules.UserName;

        bool fChuaLuu = false;
        private void btnThemBP_Click(object sender, EventArgs e)
        {
            if (grvCTiet.RowCount > 0)
            {
                fChuaLuu = true;
                //pnYeuCau.Visible = false;
                ThemBP(true);


                btnThemBP.Visible = false;
                txtSTT.Properties.ReadOnly = true;
                txtSYCau.Properties.ReadOnly = true;
                datNYCau.Properties.ReadOnly = true;
                txtGioYC.Properties.ReadOnly = true;
                txtNYCau.Properties.ReadOnly = true;
                datNHThanh.Properties.ReadOnly = true;
                cboNXuong.ReadOnly = true;
                cboNguoiYeuCau.Properties.ReadOnly = true;
                grdCTiet.Enabled = false;
                grdHinh.Enabled = false;
                btnGoiMai.Enabled = false;

                try
                {
                    Commons.Modules.ObjSystems.XoaTable(sBTT);
                }
                catch { }
                try
                {

                    if (fChuaLuu == false)
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTT, dtBP, "");

                    else
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTT, (DataTable)grdBP.DataSource, "");

                    VietShape.frmChonPTTuBoPhan frm = new VietShape.frmChonPTTuBoPhan();
                    frm.MS_MAY = grvCTiet.GetFocusedDataRow()["MS_MAY"].ToString();
                    frm.StartPosition = FormStartPosition.CenterParent;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.dtTTPT1.Rows.Count < 0) return;
                        dtBP = new DataTable();
                        dtBP = frm.dtTTPT1;
                        frm.dtTTPT1.DefaultView.RowFilter = "DEL = 0";
                        frm.dtTTPT1 = frm.dtTTPT1.DefaultView.ToTable();
                        fChuaLuu = false;
                        Commons.Modules.ObjSystems.XoaTable(sBTT);
                        bThemBP = true;
                        Commons.Modules.ObjSystems.MLoadXtraGrid(grdBP, grvBP, frm.dtTTPT1, false, true, true, true, true, "");
                        grvBP.Columns["STT_VAN_DE"].Visible = false;
                        grvBP.Columns["STT_BO_PHAN"].Visible = false;
                        grvBP.Columns["MS_MAY"].Visible = false;
                        grvBP.Columns["STT"].Visible = false;
                        grvBP.Columns["DEL"].Visible = false;
                    }
                    else
                    {
                        try
                        {
                            Commons.Modules.ObjSystems.XoaTable(sBT);
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    Commons.Modules.ObjSystems.XoaTable(sBTT);
                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                      "MsgNoYeuCauCT", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ThemBP(Boolean ThemSua)
        {
            btnChonPT.Visible = ThemSua;
            btnGhi1.Visible = ThemSua;
            btnKhongGhi1.Visible = ThemSua;



            btnThem.Visible = !ThemSua;
            btnSua.Visible = !ThemSua;
            btnXoa.Visible = !ThemSua;
            btnThoat.Visible = !ThemSua;
            btnIN.Visible = !ThemSua;

            try
            {
                if (((DataTable)grdYCSDHinh.DataSource).Rows.Count > 0)
                    btnXemHinh.Visible = true;
                else
                    btnXemHinh.Visible = false;
            }
            catch
            {
                btnXemHinh.Visible = false;
            }

        }
        private void btnGhi1_Click(object sender, EventArgs e)
        {

            SqlConnection sql = new SqlConnection(Commons.IConnections.ConnectionString);
            if (sql.State == ConnectionState.Closed)
                sql.Open();

            SqlTransaction tran = null;
            if (bThemBP = true && dtBP.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in dtBP.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            tran = sql.BeginTransaction();

                            SqlHelper.ExecuteNonQuery(tran, "spInsertYeuCauNSDBoPhanTheoMay", Convert.ToInt32(grvCTiet.GetFocusedDataRow()["STT"].ToString()),
                                Convert.ToInt32(grvCTiet.GetFocusedDataRow()["STT_VAN_DE"].ToString()),
                                grvCTiet.GetFocusedDataRow()["MS_MAY"].ToString(),
                                row["MS_BO_PHAN"], row["STT_BO_PHAN"], row["MS_PT"], row["DEL"]);
                            tran.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    fChuaLuu = false;
                    tran.Rollback();
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD", "msgThemBPLoi",
                      Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //pnYeuCau.Visible = true;
            ThemBP(false);

            btnThemBP.Visible = true;
            fChuaLuu = true;
            txtSTT.Properties.ReadOnly = false;
            txtSYCau.Properties.ReadOnly = false;
            datNYCau.Properties.ReadOnly = false;
            txtGioYC.Properties.ReadOnly = false;
            txtNYCau.Properties.ReadOnly = false;
            datNHThanh.Properties.ReadOnly = false;
            cboNXuong.ReadOnly = false;
            cboNguoiYeuCau.Properties.ReadOnly = false;
            btnGoiMai.Enabled = true;
            grdCTiet.Enabled = true;
            grdHinh.Enabled = true;
            grvCTiet_FocusedRowChanged(grvCTiet, null);
        }

        private void btnKhongGhi1_Click(object sender, EventArgs e)
        {
            ThemBP(false);
            btnThemBP.Visible = true;

            txtSTT.Properties.ReadOnly = false;
            txtSYCau.Properties.ReadOnly = false;
            datNYCau.Properties.ReadOnly = false;
            txtGioYC.Properties.ReadOnly = false;
            txtNYCau.Properties.ReadOnly = false;
            datNHThanh.Properties.ReadOnly = false;
            cboNXuong.ReadOnly = false;
            cboNguoiYeuCau.Properties.ReadOnly = false;
            grdCTiet.Enabled = true;
            grdHinh.Enabled = true;
            btnGoiMai.Enabled = true;
            grvCTiet_FocusedRowChanged(grvCTiet, null);
        }

        private void btnXoaBoPhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBP.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                        "MsgNoData", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                "MsgQuyenXoa6", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                try
                {
                    string str = "DELETE YEU_CAU_NSD_CHI_TIET_BO_PHAN WHERE STT_BO_PHAN = " + grvBP.GetFocusedDataRow()["STT_BO_PHAN"];
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    LoadBP(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                            int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
                        "XoaKhongThanhCong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            { }
        }

        private void cboNguoiYeuCau_EditValueChanged(object sender, EventArgs e)
        {
            txtNYCau.Text = cboNguoiYeuCau.EditValue.ToString();
        }

        private void grvBP_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Delete) return;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (btnGhi1.Visible)
            {
                XoaBoPhanTrenLuoi();
                view.DeleteRow(view.FocusedRowHandle);
            }
        }

        private void XoaBoPhanTrenLuoi()
        {
            if (grvBP.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgNoData",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
            "MsgQuyenXoa6", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            this.Cursor = Cursors.WaitCursor;


            try
            {
                string str = "";
                try
                {
                    str = "DELETE " + sBT + " WHERE MS_BO_PHAN = " + grvBP.GetFocusedDataRow()["MS_BO_PHAN"];
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                }
                catch { }
                try
                {
                    str = "DELETE YEU_CAU_NSD_CHI_TIET_BO_PHAN WHERE STT_BO_PHAN = " + grvBP.GetFocusedDataRow()["STT_BO_PHAN"];
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, str);
                    //LoadBP(int.Parse(grvCTiet.GetFocusedRowCellValue("STT").ToString()),
                    //        int.Parse(grvCTiet.GetFocusedRowCellValue("STT_VAN_DE").ToString()), grvCTiet.GetFocusedRowCellValue("MS_MAY").ToString());
                }
                catch { }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "XoaKhongThanhCong",
                    Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }
        private void btnChonBP_Click(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.ObjSystems.XoaTable(sBT);
            }
            catch { }
            try
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdBP.DataSource, "");

                VietShape.frmBoPhanChoMay frm = new VietShape.frmBoPhanChoMay();
                frm.MS_MAY = grvCTiet.GetFocusedDataRow()["MS_MAY"].ToString();
                frm.StartPosition = FormStartPosition.CenterParent;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.dtTTPT.Rows.Count < 0) return;
                    dtBP = new DataTable();
                    dtBP = (DataTable)grdBP.DataSource;

                    foreach (DataRow drRow in frm.dtTTPT.Rows)
                    {
                        try
                        {
                            DataRow dr = dtBP.NewRow();
                            dr["MS_BO_PHAN"] = drRow["MS_BO_PHAN"];
                            dr["MS_MAY"] = grvCTiet.GetFocusedDataRow()["MS_MAY"].ToString();
                            dr["STT_VAN_DE"] = grvCTiet.GetFocusedDataRow()["STT_VAN_DE"].ToString();
                            dr["STT"] = grvCTiet.GetFocusedDataRow()["STT"].ToString();
                            dr["STT_BO_PHAN"] = -1;
                            dr["TEN_BO_PHAN"] = drRow["TEN_BO_PHAN"];
                            dr["MS_PT"] = "";
                            dtBP.Rows.Add(dr);
                        }
                        catch { }
                    }
                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    bThemBP = true;
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdBP, grvBP, dtBP, false, true, true, true, true, "");
                    grvBP.Columns["STT_VAN_DE"].Visible = false;
                    grvBP.Columns["STT_BO_PHAN"].Visible = false;
                    grvBP.Columns["MS_MAY"].Visible = false;
                    grvBP.Columns["STT"].Visible = false;
                }
                else
                {
                    try
                    {
                        Commons.Modules.ObjSystems.XoaTable(sBT);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Commons.Modules.ObjSystems.XoaTable(sBT);
                MessageBox.Show(ex.Message);
            }
        }

        string sBTT = "ChonPhuTungChoMay" + Commons.Modules.UserName;
        private void btnChonPT_Click(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.ObjSystems.XoaTable(sBTT);
            }
            catch { }
            try
            {

                if (fChuaLuu == false)
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTT, dtBP, "");

                else
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTT, (DataTable)grdBP.DataSource, "");

                VietShape.frmChonPTTuBoPhan frm = new VietShape.frmChonPTTuBoPhan();
                frm.MS_MAY = grvCTiet.GetFocusedDataRow()["MS_MAY"].ToString();
                frm.StartPosition = FormStartPosition.CenterParent;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.dtTTPT1.Rows.Count < 0) return;
                    dtBP = new DataTable();
                    dtBP = frm.dtTTPT1;
                    frm.dtTTPT1.DefaultView.RowFilter = "DEL = 0";
                    frm.dtTTPT1 = frm.dtTTPT1.DefaultView.ToTable();
                    fChuaLuu = false;
                    Commons.Modules.ObjSystems.XoaTable(sBTT);
                    bThemBP = true;
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdBP, grvBP, frm.dtTTPT1, false, true, true, true, true, "");
                    grvBP.Columns["STT_VAN_DE"].Visible = false;
                    grvBP.Columns["STT_BO_PHAN"].Visible = false;
                    grvBP.Columns["MS_MAY"].Visible = false;
                    grvBP.Columns["STT"].Visible = false;
                    grvBP.Columns["DEL"].Visible = false;
                }
                else
                {
                    try
                    {
                        Commons.Modules.ObjSystems.XoaTable(sBT);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Commons.Modules.ObjSystems.XoaTable(sBTT);
                MessageBox.Show(ex.Message);
            }

        }



        bool menuClick = false;
        private void MenuViewTiepNhanThongTin_Click(object sender, EventArgs e)
        {
            menuClick = true;
            DoRowDoubleClick_XuLy(grvTmp, ptTmp);

        }
        GridView grvTmp;
        Point ptTmp;
        private void grvCTiet_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = ((GridView)(sender)).CalcHitInfo(new Point(e.X, e.Y));
            if (((e.Button & MouseButtons.Right) != 0) && (hitInfo.InRow) &&
                (!((GridView)(sender)).IsGroupRow(hitInfo.RowHandle)))
            {
                ((GridView)(sender)).FocusedRowHandle = hitInfo.RowHandle;

                ViewMenu menu = new ViewMenu(((GridView)(sender)));
                DXMenuItem menuItem = new DXMenuItem(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "menuViewTiepNhanThongTin",
                    Commons.Modules.TypeLanguage),
                  new EventHandler(MenuViewTiepNhanThongTin_Click));
                menuItem.Tag = ((GridView)(sender));
                menu.Items.Add(menuItem);
                menu.Show(hitInfo.HitPoint);
                grvTmp = ((GridView)(sender));
                ptTmp = new Point(e.X, e.Y);
            }
        }

        private void txtTK_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            DataTable dtTmp = new DataTable();
            if (tabYCSDung.SelectedTabPageIndex == 0)
            {
                dtTmp = (DataTable)grdYCSD.DataSource;
            }
            else
            {
                dtTmp = (DataTable)grdCTiet.DataSource;
            }
            try
            {
                string dk = "";
                if (tabYCSDung.SelectedTabPageIndex == 0)
                {

                    if (txtTK.Text.Length != 0) dk = " OR  MS_YEU_CAU LIKE '%" + txtTK.Text + "%' " + dk;
                    if (txtTK.Text.Length != 0) dk = " OR  SO_YEU_CAU LIKE '%" + txtTK.Text + "%' " + dk;
                    if (txtTK.Text.Length != 0) dk = " OR  TEN_N_XUONG LIKE '%" + txtTK.Text + "%' " + dk;
                    if (txtTK.Text.Length != 0) dk = " OR  NGUOI_YEU_CAU LIKE '%" + txtTK.Text + "%' " + dk;
                }
                else
                {
                    if (txtTK.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTK.Text + "%' " + dk;
                    if (txtTK.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTK.Text + "%' " + dk;


                }
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

        private void cboNXuong_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            if (!btnGhi.Visible) return;
            LoadCmbMay();
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (txtSTT.Text == "") return;
            //kiem tra phieu da duyet ben 2 chua
            if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.YEU_CAU_NSD_CHI_TIET WHERE STT = " + txtSTT.EditValue + " AND ISNULL(USERNAME_DSX,'') = '' ")) == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
    "MsgYeuCauDaDuocDuyet", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            //duyệt lập yêu cầu
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.YEU_CAU_NSD SET DUYET = 1 WHERE STT = " + txtSTT.EditValue + " ");
                LoadLuoiYCSD(Convert.ToInt32(txtSTT.EditValue), cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));
                if (duyetTuDong == true)
                {
                    GoiMail();
                }
                #region "Cap nhap tu dong duyet"
                if (duyetTuDong == true)
                {
                    //kiểm tra the
                    if (Commons.Modules.ObjSystems.MGetQuyenChucNang(Commons.Modules.UserName, 13))
                    {
                        if (bThem)
                            DuyetYeuCau(int.Parse(txtSTT.Text));
                        else
                            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoMuonGoiMailTuDongDuyetlai",
                                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) DuyetYeuCau(int.Parse(txtSTT.Text));
                    }
                }
                #endregion

            }



            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }

        }

        private void btnKhongDuyet_Click(object sender, EventArgs e)
        {
            if (txtSTT.Text == "") return;
            //duyệt lập yêu cầu
            //kiem tra phieu da duyet ben 2 chua
            if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.YEU_CAU_NSD_CHI_TIET WHERE STT = " + txtSTT.EditValue + " AND ISNULL(USERNAME_DSX,'') = '' ")) == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmYeuCauCuaNSD",
        "MsgYeuCauDaDuocDuyet", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.YEU_CAU_NSD SET DUYET = 0 WHERE STT = " + txtSTT.EditValue + " ");
                LoadLuoiYCSD(Convert.ToInt32(txtSTT.EditValue), cboNYCau.EditValue.ToString(), datTNgay.DateTime.ToString("yyyy/MM/dd"), datDNgay.DateTime.ToString("yyyy/MM/dd"));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
    }
}






