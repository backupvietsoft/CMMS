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

namespace ReportHuda
{
    public partial class frmPhatSinhDichVu : DevExpress.XtraEditors.XtraForm
    {
        public frmPhatSinhDichVu()
        {
            InitializeComponent();
        }
        string sDuongDanHSDV = "D:\\Tai_Lieu_May\\HoSoDichVu\\";
        GridView viewChung;
        Point ptChung;

        private void frmPhatSinhDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    sDuongDanHSDV = Commons.Modules.ObjSystems.GetDUONG_DAN_HINH(1).Rows[0][0].ToString() + "\\HoSoDichVu\\";
                }
                catch { }
                try 
                {
                if (!System.IO.Directory.Exists(sDuongDanHSDV))
                    System.IO.Directory.CreateDirectory(sDuongDanHSDV);
                }
                catch 
                {
                    try
                    {
                        sDuongDanHSDV = "Du:\\Tai_Lieu_May\\HoSoDichVu\\";
                        if (!System.IO.Directory.Exists(sDuongDanHSDV))
                            System.IO.Directory.CreateDirectory(sDuongDanHSDV);
                    }
                    catch
                    {
                        sDuongDanHSDV = "c:\\Tai_Lieu_May\\HoSoDichVu\\";
                        if (!System.IO.Directory.Exists(sDuongDanHSDV))
                            System.IO.Directory.CreateDirectory(sDuongDanHSDV);
                    }
                }

                Commons.Modules.SQLString = "0LOAD";
                DateTime Ngay;
                Ngay = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
                datTNgay.DateTime = Ngay.AddMonths(-6);
                datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);

                LoadCmb();
                Commons.Modules.SQLString = "";
                TaoLuoiPSDV(-1);
                TaoLuoiPSDVNhom(-1, "-1");
                TaoLuoiPSDVPBTri(-1, "-1", "-1");
                TaoLuoiPSDVTaiLieu(-1, "-1");

                LoadCmbLuoi();
                ThemSua(0, true);
                Commons.Modules.ObjSystems.ThayDoiNN(this);
                barDangSoan.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "barDangSoan", Commons.Modules.TypeLanguage);
                barGoiProcurement.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "barGoiProcurement", Commons.Modules.TypeLanguage);
                barChuyenNAV.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "barChuyenNAV", Commons.Modules.TypeLanguage);
                barDangThucHien.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "barDangThucHien", Commons.Modules.TypeLanguage);
                barCancel.Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "barCancel", Commons.Modules.TypeLanguage);

                tabPSDV.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "tabPSDV", Commons.Modules.TypeLanguage);
                tabNhom.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "tabNhom", Commons.Modules.TypeLanguage);
                tabTL.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "tabTL", Commons.Modules.TypeLanguage);

                try
                {
                    ChuyenTrangThai(int.Parse(grvPSDV.GetFocusedRowCellValue("MS_TRANG_THAI").ToString()));
                }
                catch
                {
                    ChuyenTrangThai(int.Parse(cboTThai.EditValue.ToString()));
                }
                PSDVChange(1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LoadCmb()
        {
            string sSql = "SELECT MS_TRANG_THAI, TEN_TRANG_THAI FROM TRANG_THAI_PSDV ORDER BY MS_TRANG_THAI";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTThai, sSql, "MS_TRANG_THAI", "TEN_TRANG_THAI", "");

            sSql = "SELECT MS_CONG_NHAN, HO + ' ' + TEN AS HO_TEN FROM CONG_NHAN ORDER BY HO";
            Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboNguoiYC, sSql, "MS_CONG_NHAN", "HO_TEN", "");
        }
        private void ChuyenTrangThai(int iTThai)
        {

            barDangSoan.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barGoiProcurement.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barChuyenNAV.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barDangThucHien.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnPhanBo.Enabled = false;
            btnTThai.Enabled = true;

            btnTSuaNhom.Enabled = true;
            btnTSuaPBT.Enabled = true;
            btnXoaNhom.Enabled = true;
            btnXoaNhomPBT.Enabled = true;
            btnIn.Visible = false;
            switch (iTThai)
            {
                //Dang Soan
                case 1:
                    barGoiProcurement.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnTThai.Text = barGoiProcurement.Caption;
                    //btnIn.Visible = true;
                    break;
                //Da goi mua hang
                case 2:
                    barChuyenNAV.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnTThai.Text = barChuyenNAV.Caption;
                    break;
                //Da Goi NAV
                case 3:
                    barDangThucHien.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnTThai.Text = barDangThucHien.Caption;

                    btnPhanBo.Enabled = false;
                    btnTSuaNhom.Enabled = false;
                    btnTSuaPBT.Enabled = true;
                    btnXoaNhom.Enabled = false;
                    btnXoaNhomPBT.Enabled = false;

                    break;
                //Dang thuc Hien
                case 4:
                    btnPhanBo.Enabled = true;
                    btnTSuaNhom.Enabled = false;
                    btnTSuaPBT.Enabled = false;
                    btnXoaNhom.Enabled = false;
                    btnXoaNhomPBT.Enabled = false;

                    btnTThai.Text = barCancel.Caption;
                    break;
                //hoan thanh
                case 5:
                    barCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnTThai.Enabled = false;
                    btnTSuaNhom.Enabled = false;
                    //btnTSuaPBT.Enabled = false;
                    btnXoaNhom.Enabled = false;
                    btnXoaNhomPBT.Enabled = false;

                    btnTThai.Text = btnPhanBo.Text;
                    break;
                //cancel
                case 6:
                    barDangSoan.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnTThai.Text = barDangSoan.Caption;
                    break;
            }
                
        
        }
        private void TTDangSoan()
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacChuyenTrangThaiDangSoan",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string sLoi;
            this.Cursor = Cursors.WaitCursor;
            if (!CapNhapTT("1", out sLoi))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiLoi",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiThanhCong",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK);

            this.Cursor = Cursors.Default;
        }

        private void TTGoiProcurement()
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacChuyenTrangThaiGoiProcurement",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string sLoi;
            string sSentTo = "";
            string sSentCC = "";
            this.Cursor = Cursors.WaitCursor;

            if (!CapNhapTT("2", out sLoi))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiLoi",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (string.IsNullOrEmpty(txtMail.Text)) return;
                #region Kiem mail
                if (txtMail.Text.Length != 0)
                {
                    sLoi = "";
                    if (!KiemEmail(txtMail.Text, out sLoi, out sSentTo, out sSentCC))
                    {
                        XtraMessageBox.Show(sLoi + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "msgKhongPhaiMail", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMail.Focus();
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }

                #endregion

                #region Goi mail


                string sTieuDe = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sTieuDeGoiMaiPSDV",
                    Commons.Modules.TypeLanguage) + " " + txtMSYC.Text;
                string sYeuCauDichVu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sYeuCauDichVu",
                    Commons.Modules.TypeLanguage);
                string sBody = "";
                string sNYC = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "sNYC",
                    Commons.Modules.TypeLanguage) + " : " + cboNguoiYC.Text;
                string sND;
                sND = txtNDYC.Text.Replace("\r\n", "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                //sND = sND.Replace("\n", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");

                sBody = "<body>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sYeuCauDichVu + "<br>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sND + "<br>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + sNYC + "</body>";

                string sKetQual;
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPSDVTaiLieu", txtMSYC.Text));
                
                if (dtTmp.Rows.Count == 0)
                    sKetQual = Commons.Modules.MMail.MSendEmailNotAttachment(txtMail.Text, Commons.Modules.sMailFrom,
                                Commons.Modules.sMailFromPass, sTieuDe, sBody, Commons.Modules.sMailFromSmtp,Commons.Modules.sMailFromPort);
                else
                {
                    string sPath = "";
                    try
                    {
                        foreach (DataRow drRow in dtTmp.Rows)
                        {
                            if (System.IO.File.Exists(drRow["DUONG_DAN"].ToString()))
                                sPath += ";" + drRow["DUONG_DAN"].ToString();
                        }
                    sPath = sPath.Substring(1);
                    }
                    catch { sPath = ""; }
                    sKetQual = Commons.Modules.MMail.MSendEmail(sSentTo.Trim() + ";" + sSentCC.Trim(), "", Commons.Modules.sMailFrom,
                                Commons.Modules.sMailFromPass, sTieuDe, sBody, sPath, Commons.Modules.sMailFromSmtp,
                                Commons.Modules.sMailFromPort);
                }
                #endregion

                if (!string.IsNullOrEmpty(sKetQual))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgGoiMailKhongThanhCong",
                            Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CapNhapTT("1", out sLoi);
                }
                else
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiThanhCong",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK);

            }
            this.Cursor = Cursors.Default;
        }
        private void TTChuyenNAV()
        {
            string sSql = "";
            DataTable dtTmp = new DataTable();
            #region Kiem nhom dich vu
            sSql = "SELECT * FROM  PSDV_NHOM_DV A WHERE MS_YEU_CAU =  N'" + txtMSYC.Text + "'";
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoNhomDVNenKhongTheChuyen",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }

            #endregion

            #region Kiem PBT
            //sSql = "SELECT * FROM  (SELECT *, (SELECT COUNT(*) FROM PSDV_PHIEU_BT B WHERE A.MS_YEU_CAU = B.MS_YEU_CAU AND A.SER_GROUP_CODE = B.SER_GROUP_CODE) AS PBT FROM PSDV_NHOM_DV A WHERE MS_YEU_CAU =  N'" + txtMSYC.Text + "') T1 WHERE PBT = 0 ";
            //dtTmp = new DataTable();
            //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            //if (dtTmp.Rows.Count != 0)
            //{
            //    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoPBTKhongTheChuyenNAV",
            //            Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Cursor = Cursors.Default;
            //    return;

            //}

            #endregion

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacChuyenTrangThaiChuyenNAV",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            this.Cursor = Cursors.WaitCursor;
            #region Chuyen data trung gian
            string sConnectINT = "";
            sSql = "SELECT ISNULL(SYN_INFO,'') AS SYN_INFO  FROM THONG_TIN_CHUNG";
            try
            {
                sConnectINT = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                if (sConnectINT.ToString().Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }
            catch {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }

            sSql = "SELECT  ID_PSDV_NHOM, T1.MS_YEU_CAU, T2.SER_GROUP_CODE, T2.MS_GL, 1 AS SO_LUONG, T2.MO_TA, T1.MS_CONG_NHAN, ISNULL(CONVERT(NVARCHAR(30), T1.NGAY_YEU_CAU, 121), '')  AS NGAY_YEU_CAU, " +
                            " CONVERT(NVARCHAR(255),dbo.GetPBTPSDVGroupCode(T1.MS_YEU_CAU,SER_GROUP_CODE)) AS PBT,'" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "' AS INSERT_DATE, 'N' AS [STATUS] " +
                            " FROM         dbo.PHAT_SINH_DICH_VU AS T1 INNER JOIN " +
                            "                       dbo.PSDV_NHOM_DV AS T2 ON T1.MS_YEU_CAU = T2.MS_YEU_CAU " +
                            " WHERE     (T1.MS_YEU_CAU = '" + txtMSYC.Text + "') ";
            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoNhomDVNenKhongTheChuyen",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(sConnectINT);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
            try
            {
                foreach (DataRow drRow in dtTmp.Rows)
                {
                    SqlHelper.ExecuteNonQuery(tran, "spAddNAV_REQUEST_SERVICE", drRow["ID_PSDV_NHOM"], drRow["MS_YEU_CAU"], drRow["MS_GL"], 
                        Commons.Modules.ObjSystems.MUni2Vni(drRow["MO_TA"].ToString()), 
                        drRow["SER_GROUP_CODE"], drRow["SO_LUONG"], drRow["MS_CONG_NHAN"], drRow["NGAY_YEU_CAU"], drRow["PBT"]);
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgChuyenNAVKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tran.Rollback();
                this.Cursor = Cursors.Default;
                return;
            }
            #endregion
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch { }

            string sLoi;
            if (!CapNhapTT("3", out sLoi))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiLoi",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiThanhCong",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK);

            this.Cursor = Cursors.Default;

        }
        private void TTDangThucHien()
        {

            if (!KiemPBo(txtMSYC.Text)) return;

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacChuyenTrangThaiDangThucHien",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            this.Cursor = Cursors.WaitCursor;
            string sLoi;
            if (!CapNhapTT("4", out sLoi))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiLoi",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiThanhCong",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK);
            this.Cursor = Cursors.Default;
        }
        private void TTPhanBo()
        {
            string sLoi;
            //if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacChuyenTrangThaiPhanBo",
            //        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            this.Cursor = Cursors.WaitCursor;
            if (!CapNhapTT("5", out sLoi))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiLoi",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiThanhCong",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK);
            this.Cursor = Cursors.Default;
        }
        private void TTCancel()
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacChuyenTrangThaiCancel",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            this.Cursor = Cursors.WaitCursor;
            string sLoi;
            if (!CapNhapTT("6", out sLoi))
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiLoi",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuyenTrangThaiThanhCong",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK);
            this.Cursor = Cursors.Default;
        }

        private Boolean CapNhapTT(string sMsTT, out string sLoi )
        {
            this.Cursor = Cursors.WaitCursor ;
            try
            {
                string sSql = "UPDATE PHAT_SINH_DICH_VU SET MS_TRANG_THAI = " + sMsTT + " WHERE ID_PSDV = " + txtMS.Text + " AND MS_YEU_CAU = '" + txtMSYC.Text + "' ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                TaoLuoiPSDV(int.Parse(txtMS.Text));
                sLoi = "";
                return true;
            }
            catch  (Exception ex)
            {
                this.Cursor = Cursors.Default;
                sLoi = ex.Message;
                return false;
            }
        
        }
        private void TaoLuoiPSDV(double dID_PSDV)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPSDV", datTNgay.DateTime.Date, datDNgay.DateTime.Date));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["ID_PSDV"] };
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPSDV, grvPSDV, dtTmp, false, false, false, true);
                if (dID_PSDV != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(dID_PSDV));
                    grvPSDV.FocusedRowHandle = grvPSDV.GetRowHandle(index);
                }

                grvPSDV.Columns["ID_PSDV"].Visible = false;
                grvPSDV.Columns["MS_YEU_CAU"].Visible = false;
                grvPSDV.Columns["MS_CONG_NHAN"].Visible = false;
                grvPSDV.Columns["MS_TRANG_THAI"].Visible = false;

                grvPSDV.Columns["SO_YEU_CAU"].OptionsColumn.FixedWidth = true;
                grvPSDV.Columns["NGAY_YEU_CAU"].OptionsColumn.FixedWidth = true;
                grvPSDV.Columns["TEN_TRANG_THAI"].Width = 104;
                grvPSDV.Columns["MAIL_YC"].Width = 100;
                grvPSDV.Columns["PBT"].Width = 100;
                
                grvPSDV.Columns["NOI_DUNG_YC"].OptionsColumn.FixedWidth = true;
                if (grvPSDV.Columns["SO_YEU_CAU"].Width < 102) grvPSDV.Columns["SO_YEU_CAU"].Width = 102;

                PSDVChange(1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            
            }
            LocDuLieuPSDV();
            this.Cursor = Cursors.Default;
        }

        private void TaoLuoiPSDVNhom(double dID_PSDVNhom, string sMsPSDV)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPSDVNhom", sMsPSDV));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["ID_PSDV_NHOM"] };
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPSDVNhom, grvPSDVNhom, dtTmp, false, false, true, true);
                if (dID_PSDVNhom != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(dID_PSDVNhom));
                    grvPSDVNhom.FocusedRowHandle = grvPSDVNhom.GetRowHandle(index);
                }
                grvPSDVNhom.Columns["SER_GROUP_NAME"].OptionsColumn.ReadOnly = true;
                grvPSDVNhom.Columns["TEN_CONG_TY"].OptionsColumn.ReadOnly = true;
                grvPSDVNhom.Columns["TEN_BP_CHIU_PHI"].OptionsColumn.ReadOnly = true;
                grvPSDVNhom.Columns["CHI_PHI"].OptionsColumn.ReadOnly = true;
                grvPSDVNhom.Columns["MS_GL"].OptionsColumn.ReadOnly = true;


                grvPSDVNhom.Columns["CHI_PHI"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvPSDVNhom.Columns["CHI_PHI"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeTT.ToString() + "}";

                grvPSDVNhom.Columns["ID_PSDV_NHOM"].Visible = false;
                grvPSDVNhom.Columns["MS_YEU_CAU"].Visible = false;
                grvPSDVNhom.Columns["MS_BP_CHIU_PHI"].Visible = false;
                grvPSDVNhom.Columns["MS_KH"].Visible = false;
                grvPSDVNhom.Columns["CU_MOI"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
            
        }

        private void TaoLuoiPSDVNhomPB(double dID_PSDVNhom, string sMsPSDV)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            string sBT = "PSDVPB_TMP" + Commons.Modules.UserName;
            string sBTNAV = "PSDVPB_NAV_TMP" + Commons.Modules.UserName;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdPSDVNhom.DataSource;
                
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
                string sSql;

                string sConnectINT = "";
                sSql = "SELECT ISNULL(SYN_INFO,'') AS SYN_INFO  FROM THONG_TIN_CHUNG";
                try
                {
                    sConnectINT = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                    if (sConnectINT.ToString().Trim() == "")
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                            Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sSql = "SELECT * FROM NAV_REQUEST_SERVICE_RETURN WHERE MS_YEU_CAU = N'" +  txtMSYC.Text + "'  AND SO_LUONG > 0 ";
//                Invalid column name 'MS_BP_CHIU_PHI'.
////Invalid column name 'ID_PSDV_NHOM'.
////Invalid column name 'MS_YEU_CAU'.
////Invalid column name 'SER_GROUP_CODE'.
////Invalid column name 'MS_BP_CHIU_PHI'.


                sSql = " SELECT ID_PSDV_NHOM,MS_YEU_CAU,SER_GROUP_CODE,MS_BP_CHIU_PHI,GL_ACC, VENDOR_CODE, MS_PHIEU_BAO_TRI, SUM(AMOUNT) AS AMOUNT " +
                                " FROM            dbo.NAV_REQUEST_SERVICE_RETURN " +
                                " WHERE    MS_YEU_CAU =   N'" + txtMSYC.Text + "'  AND SO_LUONG > 0  " +
                                " GROUP BY ID_PSDV_NHOM,MS_YEU_CAU,SER_GROUP_CODE,MS_BP_CHIU_PHI, GL_ACC, VENDOR_CODE, MS_PHIEU_BAO_TRI ";
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(sConnectINT, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTNAV, dtTmp, "");

                sSql = " UPDATE " + sBT + " SET MS_GL = GL_ACC, TEN_CONG_TY = T2.TEN_CONG_TY, TEN_BP_CHIU_PHI = T2.TEN_BP_CHIU_PHI, " +
                                " 	CHI_PHI = T2.AMOUNT, MS_KH = T2.VENDOR_CODE, MS_BP_CHIU_PHI = T2.MS_BP_CHIU_PHI " +
                                " FROM " +  sBT + " T1 INNER JOIN " +
                                " (SELECT ID_PSDV_NHOM, MS_YEU_CAU,SER_GROUP_CODE,GL_ACC, VENDOR_CODE,A.MS_BP_CHIU_PHI,AMOUNT, TEN_CONG_TY,TEN_BP_CHIU_PHI FROM " + sBTNAV + " A  " +
                                " LEFT JOIN KHACH_HANG B ON A.VENDOR_CODE = B.MS_KH LEFT JOIN BO_PHAN_CHIU_PHI C ON A.MS_BP_CHIU_PHI = C.MS_BP_CHIU_PHI) T2  " +
                                " ON T2.ID_PSDV_NHOM = T1.ID_PSDV_NHOM ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                sSql = "SELECT SER_GROUP_CODE, SER_GROUP_CODE AS SER_GROUP_NAME, MO_TA, MS_GL, TEN_CONG_TY, TEN_BP_CHIU_PHI, " +
                            " CHI_PHI, ID_PSDV_NHOM , MS_YEU_CAU, MS_KH, MS_BP_CHIU_PHI, CU_MOI,ID_PSDV_NHOM FROM " + sBT;
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                try
                {
                    dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["ID_PSDV_NHOM"] };
                }
                catch { }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPSDVNhom, grvPSDVNhom, dtTmp, false, false, true, true);
                if (dID_PSDVNhom != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(dID_PSDVNhom));
                    grvPSDVNhom.FocusedRowHandle = grvPSDVNhom.GetRowHandle(index);
                }

                grvPSDVNhom.Columns["CHI_PHI"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvPSDVNhom.Columns["CHI_PHI"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeTT.ToString() + "}";

                grvPSDVNhom.Columns["ID_PSDV_NHOM"].Visible = false;
                grvPSDVNhom.Columns["MS_YEU_CAU"].Visible = false;
                grvPSDVNhom.Columns["MS_BP_CHIU_PHI"].Visible = false;
                grvPSDVNhom.Columns["MS_KH"].Visible = false;
                grvPSDVNhom.Columns["CU_MOI"].Visible = false;
                //grvPSDVNhom.Columns["ID_PSDV_NHOM"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
            Commons.Modules.ObjSystems.XoaTable(sBT);
            Commons.Modules.ObjSystems.XoaTable(sBTNAV);
        }

        private void TaoLuoiPSDVPBTri(double dID_PSDVPBT, string sMsPSDV, string sMSSerGroup)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPSDVPBT", sMsPSDV, sMSSerGroup, Commons.Modules.UserName));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["ID_PSDV_PBT"] };
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPSDVPBT, grvPSDVPBT, dtTmp, false, false, true, true);

                grvPSDVPBT.Columns["MS_PHIEU_BAO_TRI"].OptionsColumn.ReadOnly = true;
                grvPSDVPBT.Columns["MS_MAY"].OptionsColumn.ReadOnly = true;
                grvPSDVPBT.Columns["TEN_MAY"].OptionsColumn.ReadOnly = true;
                grvPSDVPBT.Columns["TEN_BP_CHIU_PHI"].OptionsColumn.ReadOnly = true;
                //grvPSDVPBT.Columns["CHI_PHI_PB"].OptionsColumn.ReadOnly = true;
                grvPSDVPBT.Columns["MS_MAY"].OptionsColumn.FixedWidth = true;
                grvPSDVPBT.Columns["MS_PHIEU_BAO_TRI"].OptionsColumn.FixedWidth = true;

                grvPSDVPBT.Columns["CHI_PHI_PB"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvPSDVPBT.Columns["CHI_PHI_PB"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeTT.ToString() + "}";


                grvPSDVPBT.Columns["ID_PSDV_PBT"].Visible = false;
                grvPSDVPBT.Columns["MS_YEU_CAU"].Visible = false;
                grvPSDVPBT.Columns["SER_GROUP_CODE"].Visible = false;
                grvPSDVPBT.Columns["CU_MOI"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;

        }

        private void TaoLuoiPSDVPBTriPB(double dID_PSDVPBT, string sMsPSDV, string sMSSerGroup)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            string sBT = "PSDVPBTPB_TMP" + Commons.Modules.UserName;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPSDVPBTAll", sMsPSDV, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");


                dtTmp = new DataTable();
                dtTmp = (DataTable)grdPSDVNhom.DataSource;
                string sBTNhom = "PS_NHOM_TMP" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.XoaTable(sBTNhom);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTNhom, dtTmp, "");
                string sSql;
                try
                {
                    sSql = " UPDATE " + sBT + " SET CHI_PHI_PB = PB " +
                    " FROM " + sBT + " T1 INNER JOIN " +
                    " (SELECT SER_GROUP_CODE, CASE (SELECT COUNT (*) FROM " + sBT + " B WHERE A.SER_GROUP_CODE = B.SER_GROUP_CODE)  " +
                    " WHEN 0 THEN 0 ELSE ROUND(CHI_PHI /(SELECT COUNT (*) FROM " + sBT + " B WHERE A.SER_GROUP_CODE = B.SER_GROUP_CODE ),0)  " +
                    " END AS PB FROM " + sBTNhom + " A   " +
                    " ) T2 ON T1.SER_GROUP_CODE = T2.SER_GROUP_CODE ";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                }
                catch { }


                sSql = "  SELECT MS_PHIEU_BAO_TRI,MS_MAY, TEN_MAY, NOI_DUNG, TEN_BP_CHIU_PHI, CHI_PHI_PB, ID_PSDV_PBT, " +
		                    " MS_YEU_CAU, SER_GROUP_CODE, CU_MOI FROM " + sBT;

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dtTmp.Columns["CHI_PHI_PB"].ReadOnly = false;
                dtTmp.DefaultView.RowFilter = "SER_GROUP_CODE = '" + sMSSerGroup + "' ";

                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["ID_PSDV_PBT"] };
                if (dID_PSDVPBT != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(dID_PSDVPBT));
                    grvPSDVPBT.FocusedRowHandle = grvPSDVPBT.GetRowHandle(index);
                }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPSDVPBT, grvPSDVPBT, dtTmp, true, false, true, true);



                grvPSDVPBT.Columns["MS_PHIEU_BAO_TRI"].OptionsColumn.ReadOnly = true;
                grvPSDVPBT.Columns["MS_MAY"].OptionsColumn.ReadOnly = true;
                grvPSDVPBT.Columns["TEN_MAY"].OptionsColumn.ReadOnly = true;
                grvPSDVPBT.Columns["TEN_BP_CHIU_PHI"].OptionsColumn.ReadOnly = true;
                //grvPSDVPBT.Columns["NOI_DUNG"].OptionsColumn.ReadOnly = true;


                grvPSDVPBT.Columns["CHI_PHI_PB"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grvPSDVPBT.Columns["CHI_PHI_PB"].DisplayFormat.FormatString = "{0:N" + Commons.Modules.iSoLeTT.ToString() + "}";


                grvPSDVPBT.Columns["ID_PSDV_PBT"].Visible = false;
                grvPSDVPBT.Columns["MS_YEU_CAU"].Visible = false;
                grvPSDVPBT.Columns["SER_GROUP_CODE"].Visible = false;
                grvPSDVPBT.Columns["CU_MOI"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
            Commons.Modules.ObjSystems.XoaTable(sBT);
        }

        private void TaoLuoiPSDVTaiLieu(double dID_PSDVTLieu, string sMsPSDV)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtTmp = new DataTable();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPSDVTaiLieu", sMsPSDV));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["ID_PSDV_TL"] };
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPSDVTLieu, grvPSDVTLieu, dtTmp, false, false, true, true);
                if (dID_PSDVTLieu != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(dID_PSDVTLieu));
                    grvPSDVTLieu.FocusedRowHandle = grvPSDVTLieu.GetRowHandle(index);
                }
                grvPSDVTLieu.Columns["DUONG_DAN"].OptionsColumn.ReadOnly = true;

                grvPSDVTLieu.Columns["ID_PSDV_TL"].Visible = false;
                grvPSDVTLieu.Columns["MS_YEU_CAU"].Visible = false;
                grvPSDVTLieu.Columns["CU_MOI"].Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;

        }

        private void KiemTraPhanBo()
        {
            string sConnectINT = "";
            string sSql = "SELECT ISNULL(SYN_INFO,'') AS SYN_INFO  FROM THONG_TIN_CHUNG";
            try
            {
                sConnectINT = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                if (sConnectINT.ToString().Trim() == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LoadSerCode()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT SER_GROUP_CODE, SER_GROUP_NAME FROM LOAI_DICH_VU ORDER BY SER_GROUP_CODE"));
                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboSerCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                cboSerCode.NullText = "";
                cboSerCode.ValueMember = "SER_GROUP_CODE";
                cboSerCode.DisplayMember = "SER_GROUP_CODE";
                cboSerCode.DataSource = dtTmp;
                if (btnGNhom.Visible)
                {
                    cboSerCode.Columns.Clear();
                    cboSerCode.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SER_GROUP_CODE"));
                    cboSerCode.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SER_GROUP_NAME"));
                    cboSerCode.PopupWidth = 625;
                    cboSerCode.Columns["SER_GROUP_CODE"].Width = 150;
                    cboSerCode.Columns["SER_GROUP_NAME"].Width = 450;
                }

                grvPSDVNhom.Columns["SER_GROUP_CODE"].ColumnEdit = cboSerCode;
                cboSerCode.EditValueChanged += new System.EventHandler(this.cboSerCode_EditValueChanged);
                cboSerCode.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(cboSerCode_EditValueChanging);

                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboTSerCode =
                            new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                cboTSerCode.NullText = "";
                cboTSerCode.ValueMember = "SER_GROUP_CODE";
                cboTSerCode.DisplayMember = "SER_GROUP_NAME";
                cboTSerCode.Columns.Clear();
                cboTSerCode.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SER_GROUP_NAME"));

                cboTSerCode.DataSource = dtTmp;
                grvPSDVNhom.Columns["SER_GROUP_NAME"].ColumnEdit = cboTSerCode;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;

        }

        private void LoadGLAcount()
        {
            DataTable dtTmp = new DataTable();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_GL, TEN_GL FROM GL_ACOUNT ORDER BY TEN_GL "));
                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboGLAcount =
                    new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                cboGLAcount.NullText = "";
                cboGLAcount.ValueMember = "MS_GL";
                cboGLAcount.DisplayMember = "TEN_GL";
                cboGLAcount.DataSource = dtTmp;
                if (btnGhi.Visible)
                {
                    cboGLAcount.Columns.Clear();
                    cboGLAcount.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_GL"));
                    cboGLAcount.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_GL"));
                    cboGLAcount.PopupWidth = 625;
                    cboGLAcount.Columns["MS_GL"].Width = 150;
                    cboGLAcount.Columns["TEN_GL"].Width = 450;
                }

                grvPSDVNhom.Columns["MS_GL"].ColumnEdit = cboGLAcount;
                cboGLAcount.EditValueChanged += new System.EventHandler(this.cboGLAcount_EditValueChanged);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;

        }

        private void LoadCmbLuoi()
        {
            LoadSerCode();
            LoadGLAcount();
        }

        private void cboSerCode_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!btnGNhom.Visible) return;
            if (grvPSDVPBT.RowCount > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgDaCoDuLieuPSDVPBTNenKhongTheThayDoi", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            string sBT = "PSDV_SEVNHOM_TMP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdPSDVNhom.DataSource, "");
            int iTT = 0;
            iTT = Convert.ToInt16(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT COUNT(*) FROM " + sBT + " WHERE SER_GROUP_CODE = '" + e.NewValue + "' "));
            if (iTT > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgSevGroupTonTai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            Commons.Modules.ObjSystems.XoaTable(sBT);

        }


        private void cboSerCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!btnGNhom.Visible) return;
                DevExpress.XtraEditors.LookUpEdit cbo = (DevExpress.XtraEditors.LookUpEdit)sender;
                grvPSDVNhom.SetFocusedRowCellValue("SER_GROUP_NAME", cbo.EditValue);
                grvPSDVNhom.SetFocusedRowCellValue("SER_GROUP_CODE", cbo.EditValue);
                if (grvPSDVNhom.GetFocusedRowCellValue("MS_YEU_CAU").ToString() == "") grvPSDVNhom.SetFocusedRowCellValue("MS_YEU_CAU", txtMSYC.Text);
            }
            catch { }

        }

        private void cboGLAcount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!btnGNhom.Visible) return;
                DevExpress.XtraEditors.LookUpEdit cbo = (DevExpress.XtraEditors.LookUpEdit)sender;
                grvPSDVNhom.SetFocusedRowCellValue("MS_GL", cbo.EditValue);
                if (grvPSDVNhom.GetFocusedRowCellValue("MS_YEU_CAU").ToString() == "") grvPSDVNhom.SetFocusedRowCellValue("MS_YEU_CAU", txtMSYC.Text);
            }
            catch { }

        }

        private void ThemSua(int iTab, Boolean bTSua)
        {
            switch (iTab)
            {
                #region Phat Sinh Dich Vu
                case 0:
                    btnTThai.Visible = bTSua;
                    btnThem.Visible = bTSua;
                    btnSua.Visible = bTSua;
                    btnXoa.Visible = bTSua;
                    btnIn.Visible = bTSua;
                    btnThoat.Visible = bTSua;
                    btnGhi.Visible =!  bTSua;
                    btnKhong.Visible =! bTSua;
                    btnChonPBT.Visible = !bTSua;


                    txtSYC.Properties.ReadOnly = bTSua;
                    cboNguoiYC.Properties.ReadOnly = bTSua;
                    datNgayYC.Properties.ReadOnly = bTSua;
                    txtNDYC.Properties.ReadOnly = bTSua;
                    txtMail.Properties.ReadOnly = bTSua;

                    txtTKiem.Properties.ReadOnly = !bTSua;
                    tableLayoutPanel2.Enabled = bTSua;
                    datTNgay.Properties.ReadOnly = !bTSua;
                    datDNgay.Properties.ReadOnly = !bTSua;

                    break;
                #endregion

                #region Phat Sinh Dich Vu Nhom
                case 1:
                    btnTSuaNhom.Visible = bTSua;
                    btnTSuaPBT.Visible = bTSua;
                    btnXoaNhom.Visible = bTSua;
                    btnXoaNhomPBT.Visible = bTSua;
                    btnThoatNhom.Visible = bTSua;

                    btnGNhom.Visible = !bTSua;
                    btnKNhom.Visible = !bTSua;

                    grdPSDVPBT.Enabled = bTSua;

                    if (bTSua) grvPSDVNhom.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False; else grvPSDVNhom.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
                    if (bTSua)
                    {
                        grvPSDVNhom.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        grvPSDVNhom.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                    }
                    else
                    {
                        grvPSDVNhom.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        grvPSDVNhom.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                    }
                    grvPSDVNhom.OptionsBehavior.Editable = !bTSua;
                    break;
                #endregion

                #region Phat Sinh Dich Vu PBT
                case 2:
                    btnTSuaNhom.Visible = bTSua;
                    btnTSuaPBT.Visible = bTSua;
                    btnXoaNhom.Visible = bTSua;
                    btnXoaNhomPBT.Visible = bTSua;
                    btnThoatNhom.Visible = bTSua;

                    btnGNhom.Visible = !bTSua;
                    btnKNhom.Visible = !bTSua;
                    btnChonPBT.Visible = !bTSua;
                    grdPSDVNhom.Enabled = bTSua;
                    if (bTSua) grvPSDVPBT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False; else grvPSDVPBT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
                    grvPSDVPBT.OptionsBehavior.Editable = !bTSua;
                    grvPSDVPBT.Columns["CHI_PHI_PB"].OptionsColumn.ReadOnly = true;
                    grvPSDVPBT.Columns["NOI_DUNG"].OptionsColumn.ReadOnly = false;
                    break;
                #endregion

                #region Phat Sinh Dich Vu Tai Lieu
                case 3:
                    btnTSuaTL.Visible = bTSua;
                    btnXoaTL.Visible = bTSua;
                    btnThoatTL.Visible = bTSua;
                    btnGhiTL.Visible = !bTSua;
                    btnKhongTL.Visible = !bTSua;
                    btnChonFileTL.Visible = !bTSua;

                    if (bTSua) grvPSDVTLieu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False; else grvPSDVTLieu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
                    grvPSDVTLieu.OptionsBehavior.Editable = !bTSua;
                    break;                
                #endregion

                #region Phan Bo
                case 5:
                    btnTSuaNhom.Visible = bTSua;
                    btnTSuaPBT.Visible = bTSua;
                    btnXoaNhom.Visible = bTSua;
                    btnXoaNhomPBT.Visible = bTSua;
                    btnThoatNhom.Visible = bTSua;
                    btnPhanBo.Visible = bTSua;

                    btnGNhom.Visible = !bTSua;
                    btnKNhom.Visible = !bTSua;

                    grvPSDVPBT.Columns["NOI_DUNG"].OptionsColumn.ReadOnly = true;
                    grvPSDVPBT.Columns["CHI_PHI_PB"].OptionsColumn.ReadOnly = false;
                    
                    break;
                #endregion

                #region Hoan Thanh
                case 6:
                    btnTSuaNhom.Visible = bTSua;
                    btnTSuaPBT.Visible = bTSua;
                    btnXoaNhom.Visible = bTSua;
                    btnXoaNhomPBT.Visible = bTSua;
                    btnThoatNhom.Visible = bTSua;
                    btnPhanBo.Visible = bTSua;

                    btnGNhom.Visible = !bTSua;
                    btnKNhom.Visible = !bTSua;

                    grvPSDVPBT.Columns["NOI_DUNG"].OptionsColumn.ReadOnly = true;
                    grvPSDVPBT.Columns["CHI_PHI_PB"].OptionsColumn.ReadOnly = false;

                    break;
                #endregion

            }

        }

        private void TaoMSPhatSinhDV()
        {
            string sMaSo;
            sMaSo = datNgayYC.DateTime.Date.ToString("yyyyMM");
            txtMSYC.Text = "PR-" + Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "spGetMSPhatSinhDV", sMaSo, "PR"));
            txtSYC.Text = txtMSYC.Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua(0, false);
            PSDVChange(-1);
            datNgayYC.DateTime = DateTime.Now.Date;
            cboNguoiYC.EditValue = Commons.Modules.sMaNhanVienMD;
            TaoMSPhatSinhDV();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMSYC.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgKhongCoDuLieuPSDVDeThemSua", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ThemSua(0, false);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (txtSYC.Text.Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgChuaNhapSoYeuCau", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSYC.Focus();
                return;
            }
            if (cboNguoiYC.Text.Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgChuaNhapNguoiYeuCau", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboNguoiYC.Focus();
                return;
            }
            if (datNgayYC.Text.Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgChuaNhapNgayYeuCau", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                datNgayYC.Focus();
                return;
            }
            if (txtMail.Text.Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgChuaNhapMailYeuCau", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMail.Focus();
                return;
            }
            else
            { 
                string sMailLoi = "";
                string sSentTo = "";
                string sSentCC = "";
                if (!KiemEmail(txtMail.Text, out sMailLoi, out sSentTo, out sSentCC))
                {
                    XtraMessageBox.Show(sMailLoi + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgKhongPhaiMail", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMail.Focus();
                    return;
                }
            }
            if (txtNDYC.Text.Trim() == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgChuaNhapNoiDungYeuCau", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNDYC.Focus();
                return;
            }

            #region "Kiem Ma truoc Khi Ghi"
            string sMaSo = txtMSYC.Text;
            
            if (txtMS.Text == "-1")
            {
                sMaSo = datNgayYC.DateTime.Date.ToString("yyyyMM");
                sMaSo = "PR-" + Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "spGetMSPhatSinhDV", sMaSo, "PR"));

                if (sMaSo.Trim() != txtMSYC.Text.Trim())
                {
                    if (txtMSYC.Text == txtSYC.Text)
                    {
                        txtMSYC.Text = sMaSo;
                        txtSYC.Text = txtMSYC.Text;
                    }
                    else
                        txtMSYC.Text = sMaSo;
                }
            }
            else
            {
                string sSql;
                sSql = "SELECT COUNT(*) FROM YEU_CAU_NSD WHERE MS_YEU_CAU = N''";
                int iCoDL;
                iCoDL = 0;
                try
                {
                    iCoDL = int.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql).ToString());
                }
                catch { iCoDL = 0;}
                if (iCoDL > 0)
                {
                    sMaSo = datNgayYC.DateTime.Date.ToString("yyyyMM");
                    sMaSo = "PR-" + Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "spGetMSPhatSinhDV", sMaSo, "PR"));
                    if (txtMSYC.Text == txtSYC.Text)
                    {
                        txtMSYC.Text = sMaSo;
                        txtSYC.Text = txtMSYC.Text;
                    }
                }

            }

            #endregion

            #region Cap Nhap PSDV
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(tran, "spCapNhapPSDV", txtMS.Text, txtMSYC.Text, txtSYC.Text, datNgayYC.DateTime.Date, cboNguoiYC.EditValue, cboTThai.EditValue,txtMail.Text, txtNDYC.Text);
                tran.Commit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgCapNhapPSDVKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.ToString() , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tran.Rollback();
            }
            #endregion

            if (con.State == ConnectionState.Open)
                con.Close();

            ThemSua(0, true);
            Commons.Modules.SQLString = "0LOAD";
            if (datNgayYC.DateTime.Date > datDNgay.DateTime.Date)
            {
                datDNgay.DateTime = datNgayYC.DateTime;
            }
            Double iSTT = Double.Parse(txtMS.Text);
            if (txtMS.Text == "-1")
            {
                iSTT = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1  ID_PSDV FROM PHAT_SINH_DICH_VU  WHERE [MS_YEU_CAU] = '" + txtMSYC.Text + "'"));
            }
            Commons.Modules.SQLString = "";
            TaoLuoiPSDV(iSTT);

        }

        public bool KiemEmail(string inputEmail, out string sLoi, out string sSentTo, out string sSentCC)
        {
            sLoi = "";
            sSentTo = "";
            sSentCC = "";

            try
            {
                string[] sMail = inputEmail.Split(new Char[] { ';' });

                inputEmail = inputEmail ?? string.Empty;
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);

                foreach (string s in sMail)
                {
                    if (s != "")
                        if (!re.IsMatch(s.Trim()))
                        {
                            sLoi = s.Trim();
                            return (false);
                        }
                    if (sSentTo == "")
                        sSentTo = s.Trim();
                    else
                        sSentCC += s.Trim() + ";";
                }
                if (sSentCC.Length > 0) sSentCC = sSentCC.Substring(0, sSentCC.Length - 1);
                return true;
            }
            catch (Exception ex)
            {
                sLoi = ex.Message;
                sSentTo = "";
                sSentCC = "";
                return false;
            }
        }

        private void grvPSDV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try 
            {
                PSDVChange(1);
            }
            catch { PSDVChange(-1); }
        }

        private void PSDVChange(int iRow)
        {
            if (iRow == -1)
            {
                txtSYC.Text = "";
                cboNguoiYC.Text = "";
                datNgayYC.Text = "";
                txtNDYC.Text = "";
                cboTThai.EditValue = 1;
                txtMS.Text = "-1";
                txtMail.Text = "";
                txtMSYC.Text = "";
            }
            else
            {
                try
                {
                    txtSYC.Text = grvPSDV.GetFocusedRowCellValue("SO_YEU_CAU").ToString();
                    cboNguoiYC.EditValue = grvPSDV.GetFocusedRowCellValue("MS_CONG_NHAN").ToString();
                    datNgayYC.DateTime = DateTime.Parse(grvPSDV.GetFocusedRowCellValue("NGAY_YEU_CAU").ToString());
                    txtMail.Text = grvPSDV.GetFocusedRowCellValue("MAIL_YC").ToString();
                    txtNDYC.Text = grvPSDV.GetFocusedRowCellValue("NOI_DUNG_YC").ToString();
                    cboTThai.EditValue = int.Parse(grvPSDV.GetFocusedRowCellValue("MS_TRANG_THAI").ToString());
                    txtMS.Text = grvPSDV.GetFocusedRowCellValue("ID_PSDV").ToString();
                    txtMSYC.Text = grvPSDV.GetFocusedRowCellValue("MS_YEU_CAU").ToString();
                }
                catch {
                    txtSYC.Text = "";
                    cboNguoiYC.Text = "";
                    datNgayYC.Text = "";
                    txtNDYC.Text = "";
                    txtMail.Text = "";
                    cboTThai.EditValue = 1;
                    txtMS.Text = "";
                    txtMSYC.Text = "";
                }
            }
            ChuyenTrangThai(int.Parse(cboTThai.EditValue.ToString()));
        }

        private void LocDuLieuPSDV()
        {
            string sDK = "";
            DataTable dtPN = new DataTable();
            dtPN = (DataTable)grdPSDV.DataSource;
            try
            {
                if (chkDangSoan.Checked && chkDaGoiMH.Checked && chkDaGoiNAV.Checked && chkDangThucHien.Checked && chkPhanBo.Checked && chkCancel.Checked)
                    sDK = "";
                else
                {
                    if (chkDangSoan.Checked)
                        sDK = " OR (MS_TRANG_THAI = 1) ";
                    if (chkDaGoiMH.Checked)
                        sDK += " OR (MS_TRANG_THAI = 2) ";
                    if (chkDaGoiNAV.Checked)
                        sDK += " OR (MS_TRANG_THAI = 3) ";
                    if (chkDangThucHien.Checked)
                        sDK += " OR (MS_TRANG_THAI = 4) ";
                    if (chkPhanBo.Checked)
                        sDK += " OR (MS_TRANG_THAI = 5) ";
                    if (chkCancel.Checked)
                        sDK += " OR (MS_TRANG_THAI = 6) ";

                    //sDK = "( " + sDK + " ) ";

                    if (sDK.Length > 0)
                        sDK = sDK.Substring(4, sDK.Length - 4);
                    else
                        sDK = "(MS_TRANG_THAI = -1) ";
                }
                if (txtTKiem.Text != "")
                {
                    if (sDK.Length > 0)
                        sDK = "( " + sDK + ") AND ( SO_YEU_CAU LIKE '%" + txtTKiem.Text + "%'  OR NOI_DUNG_YC LIKE '%" + txtTKiem.Text + "%' )";
                    else
                        sDK = "SO_YEU_CAU LIKE '%" + txtTKiem.Text + "%'  OR NOI_DUNG_YC LIKE '%" + txtTKiem.Text + "%'";
                }

                dtPN.DefaultView.RowFilter = sDK;

            }
            catch { dtPN.DefaultView.RowFilter = ""; }
        }

        private void datNgayYC_Validated(object sender, EventArgs e)
        {
            if (!btnGhi.Visible) return;
            Boolean bSoPSDV = false;
            if (txtMSYC.Text == txtSYC.Text) bSoPSDV = true;
            TaoMSPhatSinhDV();
            if (bSoPSDV) txtSYC.Text = txtMSYC.Text;
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            ThemSua(0, true);
            PSDVChange(1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvPSDV.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                                    "msgKhongDuLieuXoa", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sSql = "";
            sSql = "SELECT COUNT(*) FROM (SELECT  MS_YEU_CAU FROM PSDV_NHOM_DV WHERE MS_YEU_CAU = '" + txtMSYC.Text + "' " +
                        " UNION SELECT  MS_YEU_CAU FROM PSDV_PHIEU_BT WHERE MS_YEU_CAU = '" + txtMSYC.Text + "' " +
                        " UNION SELECT  MS_YEU_CAU FROM PSDV_TAI_LIEU WHERE MS_YEU_CAU = '" + txtMSYC.Text + "') A";
            if (Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)) > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgVanConChiTietKhongXoaDuoc", 
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaPSDV",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
            try
            {
                sSql = "DELETE FROM [PHAT_SINH_DICH_VU] WHERE (ID_PSDV = " + txtMS.Text + ") ";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);
                tran.Commit();
                
            }
            catch (Exception ex)
            {
                tran.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgXoaPSDVDangSuDung",
                    Commons.Modules.TypeLanguage) + "\n" + ex.Message , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TaoLuoiPSDV(-1);
        }

        private void chkDangSoan_CheckedChanged(object sender, EventArgs e)
        {
            LocDuLieuPSDV();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return; 
            TaoLuoiPSDV(-1);
        }

        private void tabYCSDung_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (btnGhi.Visible || btnGNhom.Visible)
            {
                e.Cancel = true;
                return;
            }
        }

        private void tabYCSDung_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabYCSDung.SelectedTabPageIndex == 1)
            {
                Commons.Modules.SQLString = "0PBT";
                TaoLuoiPSDVNhom(-1, txtMSYC.Text);
                Commons.Modules.SQLString = "";
                try
                {
                    TaoLuoiPSDVPBTri(-1, txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
                }
                catch
                {
                    TaoLuoiPSDVPBTri(-1, txtMSYC.Text, "-1");
                }
                Commons.Modules.SQLString = "";
                ThemSua(1,true);
                
            }
            if (tabYCSDung.SelectedTabPageIndex == 2)
            {
                TaoLuoiPSDVTaiLieu(-1, txtMSYC.Text);
                ThemSua(3, true);
            }
            Commons.Modules.SQLString = "";
        }

        private void btnTSuaNhom_Click(object sender, EventArgs e)
        {
            if (txtMSYC.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgKhongCoDuLieuPSDVDeThemSua", Commons.Modules.TypeLanguage) , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ThemSua(1, false);
        }

        private void btnTSuaPBT_Click(object sender, EventArgs e)
        {
            if (grvPSDVNhom.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgKhongCoDuLieuPSDVNhomDeThemSua", Commons.Modules.TypeLanguage) , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ThemSua(2, false);
            if (int.Parse(cboTThai.EditValue.ToString()) == 5)
                btnChonPBT.Enabled = false;
        }

        private void btnGNhom_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
#region ghi cua TT Phan Bo
            if (btnGNhom.Visible && grdPSDVNhom.Enabled && grdPSDVPBT.Enabled && !btnTSuaNhom.Enabled && !btnTSuaPBT.Enabled)
            {
                CapNhapPhanBo();
            }
#endregion
            else
#region ghi cua TT Phan Bo
            {
                CapNhapPSDVNhom();
            }
#endregion
            Cursor = Cursors.Default;
            btnChonPBT.Enabled = true;
        }

        private void CapNhapPhanBo()
        {
            string sBTNhom = "PSDVPB_TMP" + Commons.Modules.UserName;
            string sBTPBT = "PSDV_PBT_TMP" + Commons.Modules.UserName;
            DataTable dtTmp = new DataTable();
            string sSql;
            #region kiem du lieu phan bo
            try
            {
                dtTmp = (DataTable)grdPSDVPBT.DataSource;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTPBT, dtTmp, "");
                dtTmp = new DataTable();

                dtTmp = (DataTable)grdPSDVNhom.DataSource;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTNhom, dtTmp, "");

                sSql = " SELECT TOP 1 ID_PSDV_NHOM FROM (SELECT    ID_PSDV_NHOM, MS_YEU_CAU, SER_GROUP_CODE, ISNULL(SUM(CHI_PHI),0) AS CP_NHOM " +
                                    " FROM " + sBTNhom + " A GROUP BY ID_PSDV_NHOM,MS_YEU_CAU, SER_GROUP_CODE) A INNER JOIN " +
                                    " (SELECT MS_YEU_CAU, SER_GROUP_CODE, ISNULL(SUM(CHI_PHI_PB),0) AS CPBT FROM " + sBTPBT +
                                    " GROUP BY MS_YEU_CAU, SER_GROUP_CODE ) B ON A.MS_YEU_CAU = B.MS_YEU_CAU AND A.SER_GROUP_CODE = B.SER_GROUP_CODE " +
                                    " WHERE CP_NHOM <> CPBT ORDER BY ID_PSDV_NHOM ";
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "msgDuLieuPhanBoKhongCan", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int index = ((DataTable)grdPSDVNhom.DataSource).Rows.IndexOf(((DataTable)grdPSDVNhom.DataSource).Rows.Find(int.Parse(dtTmp.Rows[0]["ID_PSDV_NHOM"].ToString())));
                    grvPSDVNhom.FocusedRowHandle = grvPSDVNhom.GetRowHandle(index);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return;
            }
            #endregion

            #region Cap nhap csdl
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran;

            tran = con.BeginTransaction();
            try
            {
                sSql = "UPDATE PSDV_NHOM_DV SET CHI_PHI = T2.CHI_PHI, MS_KH = T2.MS_KH, MS_BP_CHIU_PHI = T2.MS_BP_CHIU_PHI, MS_GL = T2.MS_GL " +
                            " FROM PSDV_NHOM_DV T1 INNER JOIN " + sBTNhom + " T2 ON T1.ID_PSDV_NHOM = T2.ID_PSDV_NHOM ";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);

                sSql = "UPDATE PSDV_PHIEU_BT SET CHI_PHI_PB = T2.CHI_PHI_PB " +
                            " FROM PSDV_PHIEU_BT T1 INNER JOIN " + sBTPBT + " T2 ON T1.ID_PSDV_PBT = T2.ID_PSDV_PBT  " +
                            " AND T1.MS_PHIEU_BAO_TRI = T2.MS_PHIEU_BAO_TRI AND T1.MS_YEU_CAU = T2.MS_YEU_CAU";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);

                sSql = "DELETE A FROM PHIEU_BAO_TRI_SERVICE A INNER JOIN PSDV_PHIEU_BT B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI " +
                            " AND A.SER_GROUP_CODE = B.SER_GROUP_CODE WHERE ISNULL(A.SO_HOP_DONG,'') = ''  AND B.MS_YEU_CAU = '" + txtMSYC.Text + "'";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);


                sSql = "DELETE A FROM PHIEU_BAO_TRI_SERVICE A INNER JOIN PSDV_PHIEU_BT B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI " +
                            " AND A.SER_GROUP_CODE = B.SER_GROUP_CODE AND A.SO_HOP_DONG = B.MS_YEU_CAU WHERE B.MS_YEU_CAU = '" + txtMSYC.Text + "'";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);

                sSql = "INSERT INTO PHIEU_BAO_TRI_SERVICE (MS_PHIEU_BAO_TRI,NOI_DUNG_SERVICE,MS_KH,SO_LUONG,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD, SER_GROUP_CODE, SO_HOP_DONG) " +
                            " SELECT B.MS_PHIEU_BAO_TRI,C.SER_GROUP_NAME,CASE ISNULL(A.MS_KH,'') WHEN '' THEN NULL ELSE MS_KH END,1,B.CHI_PHI_PB,'VND',1,5.72E-05,A.SER_GROUP_CODE,A.MS_YEU_CAU " +
                            " FROM PSDV_NHOM_DV A INNER JOIN PSDV_PHIEU_BT B ON A.MS_YEU_CAU = B.MS_YEU_CAU AND A.SER_GROUP_CODE = B.SER_GROUP_CODE INNER JOIN  " +
                            " LOAI_DICH_VU C ON A.SER_GROUP_CODE = C.SER_GROUP_CODE WHERE A.MS_YEU_CAU = '" + txtMSYC.Text + "'";
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message);
                if (con.State == ConnectionState.Open)
                    con.Close();
                return;
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            #endregion

            #region Tao luoi PSDV
            try
            {
                TaoLuoiPSDVNhom(double.Parse(grvPSDVNhom.GetFocusedRowCellValue("ID_PSDV_NHOM").ToString()), txtMSYC.Text);
            }
            catch { TaoLuoiPSDVNhom(-1, txtMSYC.Text); }
            #endregion

            #region Tao luoi PSDV bao tri
            try
            {
                if (grvPSDVPBT.GetFocusedRowCellValue("ID_PSDV_PBT") == null)
                    TaoLuoiPSDVPBTri(-1, txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
                else
                    TaoLuoiPSDVPBTri(double.Parse(grvPSDVPBT.GetFocusedRowCellValue("ID_PSDV_PBT").ToString()), txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
            }
            catch { TaoLuoiPSDVPBTri(-1, txtMSYC.Text, "-1"); }
            #endregion

            ThemSua(5, true);
            TTPhanBo();

            Commons.Modules.ObjSystems.XoaTable(sBTNhom);
            Commons.Modules.ObjSystems.XoaTable(sBTPBT);
            btnChonPBT.Enabled = true;
            return;
        }
        private void CapNhapPSDVNhom()
        {
            string sBT = "PSDV_TMP" + Commons.Modules.UserName;
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran;

            try
            {
                if (!grdPSDVPBT.Enabled)
                {
                    #region Cap Nhap PSDV Nhom
                    sBT = "PSDV_NHOM_TMP" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdPSDVNhom.DataSource, "");
                    tran = con.BeginTransaction();
                    try
                    {
                        SqlHelper.ExecuteNonQuery(tran, "spCapNhapPSDVNhom", sBT, txtMSYC.Text);
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "msgCapNhapPSDVNhomKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    double dMaSo = -1;
                    if (grvPSDVNhom.GetFocusedRowCellValue("ID_PSDV_NHOM") == null)
                    {
                        dMaSo = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1  ID_PSDV_NHOM FROM PSDV_NHOM_DV  WHERE [MS_YEU_CAU] = '" + txtMSYC.Text + "' AND SER_GROUP_CODE = '" + grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE") + "' "));
                    }
                    ThemSua(1, true);
                    TaoLuoiPSDVNhom(dMaSo, txtMSYC.Text);
                    #endregion
                }
                else
                {
                    #region Cap Nhap PSDV Nhom PBT
                    sBT = "PSDV_PBT_TMP" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdPSDVPBT.DataSource, "");
                    tran = con.BeginTransaction();
                    try
                    {
                        SqlHelper.ExecuteNonQuery(tran, "spCapNhapPSDVPBTri", sBT, txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE"));


                        string sSql;
                        sSql = "DELETE A FROM PHIEU_BAO_TRI_SERVICE A INNER JOIN PSDV_PHIEU_BT B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI " +
                                    " AND A.SER_GROUP_CODE = B.SER_GROUP_CODE WHERE ISNULL(A.SO_HOP_DONG,'') = ''  AND B.MS_YEU_CAU = '" + txtMSYC.Text + "'";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);


                        sSql = "DELETE A FROM PHIEU_BAO_TRI_SERVICE A INNER JOIN PSDV_PHIEU_BT B ON A.MS_PHIEU_BAO_TRI = B.MS_PHIEU_BAO_TRI " +
                                    " AND A.SER_GROUP_CODE = B.SER_GROUP_CODE AND A.SO_HOP_DONG = B.MS_YEU_CAU WHERE B.MS_YEU_CAU = '" + txtMSYC.Text + "'";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);

                        sSql = "INSERT INTO PHIEU_BAO_TRI_SERVICE (MS_PHIEU_BAO_TRI,NOI_DUNG_SERVICE,MS_KH,SO_LUONG,DON_GIA,NGOAI_TE,TY_GIA,TY_GIA_USD, SER_GROUP_CODE, SO_HOP_DONG) " +
                                    " SELECT B.MS_PHIEU_BAO_TRI,C.SER_GROUP_NAME,CASE ISNULL(A.MS_KH,'') WHEN '' THEN NULL ELSE MS_KH END,1,B.CHI_PHI_PB,'VND',1,5.72E-05,A.SER_GROUP_CODE,A.MS_YEU_CAU " +
                                    " FROM PSDV_NHOM_DV A INNER JOIN PSDV_PHIEU_BT B ON A.MS_YEU_CAU = B.MS_YEU_CAU AND A.SER_GROUP_CODE = B.SER_GROUP_CODE INNER JOIN  " +
                                    " LOAI_DICH_VU C ON A.SER_GROUP_CODE = C.SER_GROUP_CODE WHERE A.MS_YEU_CAU = '" + txtMSYC.Text + "'";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);


                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "msgCapNhapPSDVNhomPBTKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (con.State == ConnectionState.Open)
                        con.Close();

                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    ThemSua(2, true);
                    try
                    {
                        TaoLuoiPSDVPBTri(-1, txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
                    }
                    catch { TaoLuoiPSDVPBTri(-1, txtMSYC.Text, "-1"); }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnKNhom_Click(object sender, EventArgs e)
        {
            #region TT Phan Bo
            if (grdPSDVNhom.Enabled && grdPSDVPBT.Enabled)
            {
                ThemSua(5, true);
                try
                {
                    try
                    {
                        TaoLuoiPSDVNhom(int.Parse(grvPSDVNhom.GetFocusedRowCellValue("ID_PSDV_NHOM").ToString()), txtMSYC.Text);
                    }
                    catch { TaoLuoiPSDVNhom(-1, txtMSYC.Text); }

                    try
                    {
                        TaoLuoiPSDVPBTri(int.Parse(grvPSDVPBT.GetFocusedRowCellValue("ID_PSDV_PBT").ToString()), txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
                    }
                    catch { TaoLuoiPSDVPBTri(-1, txtMSYC.Text, "-1"); }
                }
                catch { TaoLuoiPSDVPBTri(-1, txtMSYC.Text, "-1"); }
            }
            #endregion
            else
            {
                #region them sua SERVER GROUP CODE
                if (!grdPSDVPBT.Enabled)
                {
                    ThemSua(1, true);
                    double dMaSo = -1;
                    try
                    {
                        if (grvPSDV.GetFocusedRowCellValue("ID_PSDV_NHOM") == null)
                        {
                            dMaSo = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString,
                                    CommandType.Text, "SELECT TOP 1  ID_PSDV_NHOM FROM PSDV_NHOM_DV  WHERE [MS_YEU_CAU] = '" + txtMSYC.Text + "' AND SER_GROUP_CODE = '" +
                                    grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE") + "' "));
                        }
                    }
                    catch { dMaSo = -1; }
                    try
                    {
                        TaoLuoiPSDVNhom(dMaSo, txtMSYC.Text);
                    }
                    catch { TaoLuoiPSDVNhom(dMaSo, "-1"); }
                }
                #endregion
                #region them sua PBT
                else
                {
                    ThemSua(2, true);
                    try
                    {
                        TaoLuoiPSDVPBTri(-1, txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
                    }
                    catch { TaoLuoiPSDVPBTri(-1, txtMSYC.Text, "-1"); }
                }
                #endregion
            }
        }

        private void grvPSDVNhom_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.SQLString == "0PBT") return;
            if (btnGNhom.Visible)
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdPSDVPBT.DataSource;
                try
                {
                    if (grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString() != "")
                    {
                        dtTmp.DefaultView.RowFilter = "SER_GROUP_CODE = '" + grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString() + "' ";
                    }
                }
                catch { dtTmp.DefaultView.RowFilter = "SER_GROUP_CODE = '-1' "; }
            }
            else
            {
                try
                {
                    TaoLuoiPSDVPBTri(-1, txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
                }
                catch
                {
                    TaoLuoiPSDVPBTri(-1, txtMSYC.Text, "-1");
                }
            }

        }

        private void btnChonPBT_Click(object sender, EventArgs e)
        {
            frmChonPSDV frm = new frmChonPSDV();
            string sBT = "CHON_PBT_TMP" + Commons.Modules.UserName;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdPSDVPBT.DataSource, "");
            frm.dtDuLieu = new DataTable();
            frm.dtDuLieu.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetPhieuBTPSDV", Commons.Modules.UserName, sBT));
            try
            {
                if (frm.dtDuLieu.Columns[0].ColumnName.ToUpper() != "CHON")
                {
                    System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                    newColumn.DefaultValue = "0";
                    frm.dtDuLieu.Columns.Add(newColumn);

                    newColumn.DefaultValue = false;
                    newColumn.SetOrdinal(0);
                }
            }
            catch { }

            if (frm.ShowDialog() != DialogResult.OK) return;
            DataTable dtTmp = new DataTable();
            dtTmp = frm.dtDuLieu;
            dtTmp.DefaultView.RowFilter = "CHON = TRUE";
            dtTmp = dtTmp.DefaultView.ToTable();

            foreach (DataRow drRow in dtTmp.Rows)
            {
                grvPSDVPBT.AddNewRow();

                int rowHandle = grvPSDVPBT.GetRowHandle(grvPSDVPBT.DataRowCount);
                if (grvPSDVPBT.IsNewItemRow(rowHandle))
                {
                    //SELECT     T1.MS_PHIEU_BAO_TRI, T1.MS_MAY, T2.TEN_MAY, TEN_BP_CHIU_PHI
                     //T1.MS_PHIEU_BAO_TRI, T3.TEN_MAY, T1.NOI_DUNG, TEN_BP_CHIU_PHI, T1.CHI_PHI_PB, T1.ID_PSDV_PBT, T1.MS_YEU_CAU, T1.SER_GROUP_CODE, CONVERT(BIT,1) AS CU_MOI
                    grvPSDVPBT.SetRowCellValue(rowHandle, grvPSDVPBT.Columns["MS_YEU_CAU"], txtMSYC.Text);
                    grvPSDVPBT.SetRowCellValue(rowHandle, grvPSDVPBT.Columns["SER_GROUP_CODE"], grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
                    grvPSDVPBT.SetRowCellValue(rowHandle, grvPSDVPBT.Columns["MS_PHIEU_BAO_TRI"], drRow["MS_PHIEU_BAO_TRI"]);
                    grvPSDVPBT.SetRowCellValue(rowHandle, grvPSDVPBT.Columns["TEN_MAY"], drRow["TEN_MAY"]);
                    grvPSDVPBT.SetRowCellValue(rowHandle, grvPSDVPBT.Columns["MS_MAY"], drRow["MS_MAY"]);
                    grvPSDVPBT.SetRowCellValue(rowHandle, grvPSDVPBT.Columns["TEN_BP_CHIU_PHI"], drRow["TEN_BP_CHIU_PHI"]);
                    
                    grvPSDVPBT.UpdateCurrentRow();


                }
            }
            Commons.Modules.ObjSystems.XoaTable(sBT);
        }

        private void grvPSDVPBT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (!btnGNhom.Visible)
            {
                XoaPSDVNhomPBTri();
                return;
            }
            
            if (grvPSDVPBT.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaPSDVPBT",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            
            view.DeleteRow(view.FocusedRowHandle);
            
        }

        private void grvPSDVNhom_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (btnGNhom.Visible == false) return;
                if (grvPSDVNhom.GetFocusedRowCellValue("MS_YEU_CAU").ToString() == "") grvPSDVNhom.SetFocusedRowCellValue("MS_YEU_CAU", txtMSYC.Text);
            }
            catch { }
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            if (grvPSDVNhom.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (grvPSDVPBT.RowCount > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgConDuLieuPSDVPBT",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaPSDVNhom",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string sSql;
            try
            {
                sSql = "DELETE FROM PSDV_NHOM_DV WHERE ID_PSDV_NHOM = " + grvPSDVNhom.GetFocusedRowCellValue("ID_PSDV_NHOM").ToString();
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                TaoLuoiPSDVNhom(-1, txtMSYC.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void XoaPSDVNhom()
        {
            if (grvPSDVNhom.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (grvPSDVPBT.RowCount > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgConDuLieuPSDVPBT",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaPSDVNhom",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            this.Cursor = Cursors.WaitCursor;
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
            string sSql;
            try
            {
                sSql = "DELETE FROM PSDV_NHOM_DV WHERE ID_PSDV_NHOM = " + grvPSDVNhom.GetFocusedRowCellValue("ID_PSDV_NHOM").ToString();
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);
                tran.Commit();
                TaoLuoiPSDVNhom(-1, txtMSYC.Text);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgXoaPSDVNhomKhongThanhCong",
                    Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            this.Cursor = Cursors.Default;
        }

        private void btnXoaNhomPBT_Click(object sender, EventArgs e)
        {
            XoaPSDVNhomPBTri();
        }

        private void XoaPSDVNhomPBTri()
        { 
            if (grvPSDVPBT.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaPSDVPBT",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            this.Cursor = Cursors.WaitCursor;
            string sSql;
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
            try
            {
                sSql = "DELETE FROM PSDV_PHIEU_BT WHERE ID_PSDV_PBT = " + grvPSDVPBT.GetFocusedRowCellValue("ID_PSDV_PBT").ToString();
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);
                tran.Commit();
                TaoLuoiPSDVPBTri(-1, txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
            }
            catch (Exception ex)
            {
                tran.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgXoaPSDVNhomKhongThanhCong",
                    Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            this.Cursor = Cursors.Default;
        }

        private void grvPSDVNhom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;
            
            if (!btnGNhom.Visible)
            {
                XoaPSDVNhom();
                return;
            }

            if (grvPSDVNhom.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (grvPSDVPBT.RowCount > 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgConDuLieuPSDVPBT",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaPSDVNhom",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.DeleteRow(view.FocusedRowHandle);
            
        }

        private void grvPSDVNhom_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (btnGNhom.Visible == false) return;
            try
            {
                if (grvPSDVPBT.RowCount > 0)
                    e.Cancel = true;

            }
            catch { }   
        }

        private void btnTSuaTL_Click(object sender, EventArgs e)
        {
            if (txtMSYC.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgKhongCoDuLieuPSDVDeThemSua", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ThemSua(3, false);
        }

        private void btnGhiTL_Click(object sender, EventArgs e)
        {
            #region Cap Nhap PSDV Tai Lieu
            try
            {
                string sBT = "PSDV_TLIEU" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, (DataTable)grdPSDVTLieu.DataSource, "");
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, "spCapNhapPSDVTLieu", sBT, txtMSYC.Text);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgCapNhapPSDVNhomKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (con.State == ConnectionState.Open)
                    con.Close();


                #region Cap Nhap Tal Lieu Len server                
                string sSql = "";
                DataTable dtTmp = new DataTable();
                string sDDan = sDuongDanHSDV + DateTime.Now.Date.ToString("yyyyMMdd");
                if (!System.IO.Directory.Exists(sDDan))
                {
                    System.IO.Directory.CreateDirectory(sDDan);
                }

                sSql = "SELECT * FROM PSDV_TAI_LIEU WHERE [MS_YEU_CAU] = '" + txtMSYC.Text + "' ";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                dtTmp.Columns["DUONG_DAN"].ReadOnly = false;
                try
                {
                    foreach (DataRow drRow in dtTmp.Rows)
                    {
                        if (System.IO.File.Exists(drRow["DUONG_DAN"].ToString()))
                        {
                            string sNewPath = sDDan + "\\" + System.IO.Path.GetFileName(drRow["DUONG_DAN"].ToString()).ToString();
                            if (!System.IO.File.Exists(sNewPath))
                                Commons.Modules.ObjSystems.LuuDuongDan(drRow["DUONG_DAN"].ToString(), sNewPath);

                            sSql = " UPDATE PSDV_TAI_LIEU SET DUONG_DAN = N'" + sNewPath + "' WHERE [MS_YEU_CAU] = '" + txtMSYC.Text + "' AND DUONG_DAN = N'" + drRow["DUONG_DAN"].ToString() + "' ";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                        }
                    }
                }
                catch { }


                
                #endregion



                double dMaSo = -1;
                dMaSo = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT TOP 1  ID_PSDV_TL FROM PSDV_TAI_LIEU  WHERE [MS_YEU_CAU] = '" +
                    txtMSYC.Text + "' AND DUONG_DAN = N'" + grvPSDVTLieu.GetFocusedRowCellValue("DUONG_DAN").ToString() + "' "));

                Commons.Modules.ObjSystems.XoaTable(sBT);
                ThemSua(3, true);
                TaoLuoiPSDVTaiLieu(dMaSo, txtMSYC.Text);
            #endregion

                ThemSua(3, true);
            }
            catch { }
    

        }

        private void btnKhongTL_Click(object sender, EventArgs e)
        {
            ThemSua(3, true);
            TaoLuoiPSDVTaiLieu(-1, txtMSYC.Text);
        }

        private void btnXoaTL_Click(object sender, EventArgs e)
        {
            XoaPSDVTLieu();
        }

        private void btnChonFileTL_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Multiselect = true;

            DataTable dt = new DataTable();
            string[] sFilePath;
            

            if (oFile.ShowDialog() != DialogResult.OK) return;
            sFilePath = oFile.FileNames;

            
            

            for (int i = 0; i <= sFilePath.Length - 1; i++)
            {
                //XtraMessageBox.Show(file.Substring(file.LastIndexOf('\\')));
                grvPSDVTLieu.AddNewRow();

                int rowHandle = grvPSDVTLieu.GetRowHandle(grvPSDVTLieu.DataRowCount);
                if (grvPSDVTLieu.IsNewItemRow(rowHandle))
                {
                    grvPSDVTLieu.SetRowCellValue(rowHandle, grvPSDVTLieu.Columns["MS_YEU_CAU"], txtMSYC.Text);
                    grvPSDVTLieu.SetRowCellValue(rowHandle, grvPSDVTLieu.Columns["DUONG_DAN"], sFilePath[i]);
                    grvPSDVTLieu.UpdateCurrentRow();
                }
            }
        }

        private void grvPSDVTLieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            if (!btnGhiTL.Visible)
            {
                XoaPSDVTLieu();
                return;
            }

            if (grvPSDVTLieu.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaPSDVTLieu",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.DeleteRow(view.FocusedRowHandle);
        }

        private void grvPSDVTLieu_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);

        }

        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            
        }

        private void XoaPSDVTLieu()
        {
            if (grvPSDVTLieu.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoDuLieuXoa",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCoChacXoaPSDVTLieu",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            this.Cursor = Cursors.WaitCursor;
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
            string sSql;
            try
            {
                sSql = "DELETE FROM [PSDV_TAI_LIEU] WHERE ID_PSDV_TL = " + grvPSDVTLieu.GetFocusedRowCellValue("ID_PSDV_TL").ToString();
                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSql);
                tran.Commit();
                TaoLuoiPSDVTaiLieu(-1, txtMSYC.Text);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgXoaPSDVTLieuKhongThanhCong",
                    Commons.Modules.TypeLanguage) + "\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            this.Cursor = Cursors.Default;
        }

        private void barDangSoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TTDangSoan();
        }


        private void barGoiProcurement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TTGoiProcurement();
        }

        private void barChuyenNAV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TTChuyenNAV();
        }

        private void barDangThucHien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TTDangThucHien();
        }

        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TTCancel();
        }

        private Boolean KiemPBo(string sMaSo)
        {
            try
            {
                string sSql = "";
                string sConnectINT = "";
                sSql = "SELECT ISNULL(SYN_INFO,'') AS SYN_INFO  FROM THONG_TIN_CHUNG";
                try
                {
                    sConnectINT = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                    if (sConnectINT.ToString().Trim() == "")
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                            Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                        return false;
                    }
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoTho0ngTinKetNoiVoiDataINT",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }

                sSql = " SELECT ID_PSDV_NHOM,MS_YEU_CAU,SER_GROUP_CODE,MS_BP_CHIU_PHI,GL_ACC, VENDOR_CODE, MS_PHIEU_BAO_TRI, SUM(AMOUNT) AS AMOUNT " +
                                " FROM            dbo.NAV_REQUEST_SERVICE_RETURN " +
                                " WHERE    MS_YEU_CAU =   N'" + txtMSYC.Text + "'  AND SO_LUONG > 0  " +
                                " GROUP BY ID_PSDV_NHOM,MS_YEU_CAU,SER_GROUP_CODE,MS_BP_CHIU_PHI, GL_ACC, VENDOR_CODE, MS_PHIEU_BAO_TRI ";

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(sConnectINT, CommandType.Text, sSql));
                if (dtTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoPhanBo",
                        Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
                else
                {
                    string sBT = "PSDV_KIEM_TMP" + Commons.Modules.UserName;
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");
                    sSql = "SELECT  A.ID_PSDV_NHOM, B.ID_PSDV_NHOM  FROM PSDV_NHOM_DV A LEFT JOIN " + sBT + " B ON A.ID_PSDV_NHOM = B.ID_PSDV_NHOM " +
                                " WHERE A.MS_YEU_CAU = '" + sMaSo + "' AND ISNULL(A.ID_PSDV_NHOM,'') <> ISNULL(B.ID_PSDV_NHOM,'')";
                    dtTmp= new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count != 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgPhanBoChuaDu",
                            Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                        return false;
                    }
                }


                return true;
            }
            catch { return false; }
            
        
        }
        private void btnPhanBo_Click(object sender, EventArgs e)
        {
            if (grvPSDVNhom.RowCount == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                    "msgKhongCoDuLieuPSDVNhomDeThemSua", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                TaoLuoiPSDVNhomPB(int.Parse(grvPSDVNhom.GetFocusedRowCellValue("ID_PSDV_NHOM").ToString()), txtMSYC.Text);
            }
            catch { TaoLuoiPSDVNhomPB(-1, txtMSYC.Text); }


            try
            {
                TaoLuoiPSDVPBTriPB(int.Parse(grvPSDVPBT.GetFocusedRowCellValue("ID_PSDV_PBT").ToString()), txtMSYC.Text, grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString());
            }
            catch { TaoLuoiPSDVPBTriPB(-1, txtMSYC.Text, "-1"); }


            ThemSua(5, false);


            
        }

        private void btnTThai_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (btnTThai.Text.ToUpper() == barDangSoan.Caption.ToUpper())
            {
                TTDangSoan();
                this.Cursor = Cursors.Default;
                return;
            }
            if (btnTThai.Text.ToUpper() == barGoiProcurement.Caption.ToUpper())
            {
                TTGoiProcurement();
                this.Cursor = Cursors.Default;
                return;
            }
            if (btnTThai.Text.ToUpper() == barChuyenNAV.Caption.ToUpper())
            {
                TTChuyenNAV();
                this.Cursor = Cursors.Default;
                return;
            }
            if (btnTThai.Text.ToUpper() == barDangThucHien.Caption.ToUpper())
            {
                TTDangThucHien();
                this.Cursor = Cursors.Default;
                return;
            }
            if (btnTThai.Text.ToUpper() == btnPhanBo.Text.ToUpper())
            {
                TTPhanBo();
                this.Cursor = Cursors.Default;
                return;
            }
            if (btnTThai.Text.ToUpper() == barCancel.Caption.ToUpper())
            {
                TTCancel();
                this.Cursor = Cursors.Default;
                return;
            }


        }

        private void grdPSDVPBT_Validating(object sender, CancelEventArgs e)
        {
            if (btnGNhom.Visible && grdPSDVNhom.Enabled && grdPSDVPBT.Enabled)
            {
                DataTable dtTmp = new DataTable();
                dtTmp = (DataTable)grdPSDVPBT.DataSource;
                string sBT = "PSDV_PBT_KIEM_PB_TMP" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp,"");
                string sSql = "";
                sSql = " SELECT ISNULL(SUM(CHI_PHI_PB),0) AS CPHI FROM " + sBT + " WHERE MS_YEU_CAU = '" + txtMSYC.Text + "' AND SER_GROUP_CODE = '" + grvPSDVNhom.GetFocusedRowCellValue("SER_GROUP_CODE").ToString() + "' ";
                double flCPhi = 0;
                flCPhi = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (flCPhi != 0)
                { 
                    if( double.Parse(grvPSDVNhom.GetFocusedRowCellValue("CHI_PHI").ToString()) != flCPhi)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                            "msgDuLieuPhanBoKhongCan", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = false;
                        return;
                    }
                }
                Commons.Modules.ObjSystems.XoaTable(sBT);
            }
        }

        private void frmPhatSinhDichVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Commons.Modules.ObjSystems.XoaTable("PSDV_NHOM_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PSDV_SEVNHOM_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PSDV_PBT_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PSDV_PBT_KIEM_PB_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PSDVPBTPB_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PSDVPB_TMP" + Commons.Modules.UserName);
            Commons.Modules.ObjSystems.XoaTable("PSDVPB_PBT_TMP" + Commons.Modules.UserName);
        }

        private void grvPSDVTLieu_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvPSDVTLieu.RowCount <= 0) return;
                System.Diagnostics.Process.Start(grvPSDVTLieu.GetFocusedRowCellValue("DUONG_DAN").ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void grvPSDVNhom_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            e.ErrorText = "";
            if (Commons.Modules.sPrivate != "BARIA") return;
            GridView view = new GridView();
            view = (GridView)sender;
            if (view.FocusedColumn.FieldName.ToString() == "MO_TA")
            {
                if (e.Value.ToString().Length > 50)
                {
                    e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgLonHon50KyTu", Commons.Modules.TypeLanguage); ;
                    e.Valid = false;
                }

            }
            
        }
    }
}