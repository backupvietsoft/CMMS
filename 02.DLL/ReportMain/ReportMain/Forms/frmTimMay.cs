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

namespace ReportMain
{
    public partial class frmTimMay : DevExpress.XtraEditors.XtraForm
    {
        GridView viewChung;
        Point ptChung;
        private string sMsMay;
        public string MsMay { get { return sMsMay; } set { sMsMay = value; } }
        private string sLoaiMay;
        public string LoaiMay { get { return sLoaiMay; } set { sLoaiMay = value; } }

        private string sMsNhomMay = "-1";
        public string MsNMay { get { return sMsNhomMay; } set { sMsNhomMay = value; } }

        private string sMsLoaiMay = "-1";
        public string MsLoaiMay { get { return sMsLoaiMay; } set { sMsLoaiMay = value; } }

        private int iLoai = 1;
        public int iLoaiBC { get { return iLoai; } set { iLoai = value; } }
//iLoaiBC = 99 la tim phieu bao tri
//iLoaiBC = 98 la chuyen ke hoach dang do vao ke hoach thang

        private DateTime TNgay;
        public DateTime TuNgay { get { return TNgay; } set { TNgay = value; } }
        private DateTime DNgay;
        public DateTime DenNgay { get { return DNgay; } set { DNgay = value; } }

        private int iHThong = -1;
        public int iHeThong { get { return iHThong; } set { iHThong = value; } }

        private string sDDiem = "-1";
        public string sDiaDiem { get { return sDDiem; } set { sDDiem = value; } }

        private int iBPhan = 1;
        public int iBoPhan { get { return iBPhan; } set { iBPhan = value; } }

        private int iKHNam = -1;
        public int iKeHoachNam { get { return iKHNam; } set { iKHNam = value; } }

        private int iKHThang = -1;
        public int iKeHoachThang { get { return iKHThang; } set { iKHThang = value; } }


        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvMay.RefreshData();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            if (grvMay.RowCount == 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                MsMay = "";
                this.Close();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                try
                {
                    MsMay = grvMay.GetFocusedRowCellValue("MS_MAY").ToString();
                    LoaiMay = cboLMay.EditValue.ToString();
                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public frmTimMay()
        {
            InitializeComponent();
        }

        private void LoadLoaiMay()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayTheoNXHT",
                    Commons.Modules.UserName, sDDiem, iHThong));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadNhomMay()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhomMayTheoLMNXHT",
                    Commons.Modules.UserName, sDDiem, iHThong, cboLMay.EditValue));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, dtTmp, "MS_NHOM_MAY", "TEN_NHOM_MAY", lblLMay.Text);
            }
            catch { }

        }

        private void LoadMay(string MsLMay, string MsNhomMay)
        {
            DataTable dtTmp = new DataTable();

            try
            {
                if (iLoai == 1)
                {
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayTheoLMNXHT", Commons.Modules.UserName,
                        MsLMay, MsNhomMay, sDDiem, iHThong, 1, 0));
                }
                else
                {
                    string sLmay = "-1";
                    string sNhomMay = "-1";

                    if (iLoai == 98)
                    {
                        try
                        {
                            if (cboLMay.EditValue.ToString() != "-1") sLmay = cboLMay.EditValue.ToString();
                            if (cboNhomMay.EditValue.ToString() != "-1") sNhomMay = cboNhomMay.EditValue.ToString();
                        }
                        catch { }

                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKeHoachCVDangDo",
                            iKHNam, iKHThang, sNhomMay, sLmay, Commons.Modules.UserName));
                    }
                    else
                    {
                        if (cboLMay.EditValue.ToString() != "-1") sLmay = cboLMay.EditValue.ToString();
                        if (cboNhomMay.EditValue.ToString() != "-1") sNhomMay = cboNhomMay.EditValue.ToString();

                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetMayBCChiPhi", TNgay, DNgay,
                            iHThong, sDDiem, iBPhan, sLmay, sNhomMay, Commons.Modules.UserName, 2));
                    }
                }
                
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message);
            }


            for (int i = 0; i <= dtTmp.Columns.Count - 1; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }


            if (iLoai == 98)
            {
                try
                {
                    dtTmp.Columns[0].ReadOnly = false;
                }
                catch { }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, false, false, true);
            }
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtTmp, true, false, true, false);

            LocDuLieu();
            
        }

        private void frmTimMay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLoaiMay();
                if (sMsLoaiMay != "-1") cboLMay.EditValue = sMsLoaiMay;
                if (sMsNhomMay != "-1") cboNhomMay.EditValue = sMsNhomMay;
                Commons.Modules.ObjSystems.ThayDoiNN(this);

                if (iLoai == 98)
                {
                    btnALL.Visible = true;
                    btnNotALL.Visible = true;
                    chkKhongHM.Visible = true;
                    chkHangMuc.Visible = true;

                    grvMay.Columns["CHON"].Width = 60;
                    grvMay.Columns["MS_MAY"].Width = 80;
                    grvMay.Columns["TEN_MAY"].Width = 180;
                    grvMay.Columns["MS_BO_PHAN"].Width = 100;
                    grvMay.Columns["TEN_BO_PHAN"].Width = 140;
                    grvMay.Columns["MO_TA_CV"].Width = 230;
                    grvMay.Columns["TGKH"].Width = 70;
                    grvMay.Columns["MS_PHIEU_BAO_TRI"].Width = 105;
                    grvMay.Columns["NGAY_LAP"].Width = 90;
                    grvMay.Columns["NGAY_BD_KH"].Width = 90;
                    grvMay.Columns["NGAY_KT_KH"].Width = 90;
                    grvMay.Columns["CP_VT_NN_NGOAI_DM"].Width = 110;
                    grvMay.Columns["CP_VT_NGOAI_DM"].Width = 110;
                    grvMay.Columns["CP_THUE_NGOAI"].Width = 110;
                    grvMay.Columns["HANG_MUC_ID"].Visible = false;
                    grvMay.Columns["MS_CV"].Visible = false;
                    grvMay.Columns["MS_LOAI_BT"].Visible = false;
                    grvMay.Columns["ID"].Visible = false;

                    grvMay.Columns["HM"].Visible = false;
                    grvMay.Columns["MODEL"].Visible = false;

                    lblTieuDe.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "TieuDeChonCongViecDangDo", Commons.Modules.TypeLanguage);
                    this.Text =  lblTieuDe.Text.Substring(0,1).ToUpper() + lblTieuDe.Text.ToLower().Substring(1);
                }
            }
            catch { }

        }

        private void cboLMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }

        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadMay(cboLMay.EditValue.ToString(), cboNhomMay.EditValue.ToString());
            }
            catch
            { LoadMay("-0", "-0"); }
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LocDuLieu();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (iLoai == 98)
            {
                if (grvMay.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "KhongCoDuLieu", Commons.Modules.TypeLanguage));
                    return;
                }
                DataTable dTTmp = new DataTable();
                dTTmp = ((DataTable)grdMay.DataSource).Copy();
                dTTmp.DefaultView.RowFilter = " CHON = TRUE";
                dTTmp = dTTmp.DefaultView.ToTable();
                if (dTTmp.Rows.Count == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "ChuaChonMay", Commons.Modules.TypeLanguage));
                    return;
                }



                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, "CV_DANG_DO", dTTmp, "");    

                SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
                SqlTransaction tran;

                if (con.State == ConnectionState.Closed)
                    con.Open();
                tran = con.BeginTransaction();

                try
                {
                    
                    SqlHelper.ExecuteNonQuery(tran, "InsKeHoachTongTheChuaHoanThanh", Commons.Modules.UserName, iKHNam, iKHThang);
                    tran.Commit();
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "ThucHienThanhCong", Commons.Modules.TypeLanguage));

                }
                catch  (Exception ex)
                {
                    tran.Rollback();
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "ThucHienKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + ex);
                    return;
                }
                LoadMay(cboLMay.EditValue.ToString(), cboNhomMay.EditValue.ToString());
                DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }
            else
            {
                if (grvMay.RowCount == 0)
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    MsMay = "";
                    this.Close();
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    try
                    {
                        MsMay = grvMay.GetFocusedRowCellValue("MS_MAY").ToString();
                        LoaiMay = cboLMay.EditValue.ToString();
                        this.Close();
                    }

                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult != DialogResult.OK) DialogResult = System.Windows.Forms.DialogResult.Cancel;
            try
            {
                MsMay = "";
                this.Close();
            }
            catch (Exception ex)
            {
                MsMay = "";
                this.Close();
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvMay_ShownEditor(object sender, EventArgs e)
        {
            if (iLoai == 98) return;

            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);

        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }

        private void chkKhongHM_CheckedChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void chkHangMuc_CheckedChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void LocDuLieu()
        {
            DataTable dtMay = new DataTable();
            dtMay = (DataTable)grdMay.DataSource;
            try
            {
                string dk = "";


                if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MODEL LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                if (iLoai == 98)
                {
                    if (dk.Length == 0) dk = " 1 = 1 "  ;
                    if (chkHangMuc.Checked == true && chkKhongHM.Checked == true) dk =  " (" + dk + ") AND (1 = 1) ";
                    if (chkHangMuc.Checked == false && chkKhongHM.Checked == true) dk = " (" + dk + ") AND (HM = 0) ";
                    if (chkHangMuc.Checked == true && chkKhongHM.Checked == false) dk = " (" + dk + ") AND (HM = 1) ";
                    if (chkHangMuc.Checked == false && chkKhongHM.Checked == false) dk = " (" + dk + ") AND (0 = 1) ";
                }


                dtMay.DefaultView.RowFilter = dk;
            }
            catch { dtMay.DefaultView.RowFilter = ""; }
        
        }
        
    }
}