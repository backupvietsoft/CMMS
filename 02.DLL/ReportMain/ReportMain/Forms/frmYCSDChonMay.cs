using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain.Forms
{
    public partial class frmYCSDChonMay : DevExpress.XtraEditors.XtraForm
    {
        public string sNXuong;
        public DataTable dtMay;
        public int iLoai;
        //iLoai = 1 Chon All co xuong
        //iLoai = 2 Chon tung may khong co NX
        //iLoai = 3 HIEU CHUAN KIEM DINH (isnull(CHU_KY_HC_TB,0) > 0)or(isnull( CHU_KY_HIEU_CHUAN_TB_NGOAI,0)>0) or (isnull(CHU_KY_KD_TB,0)>0)
        //iLoai = 4 Hiệu chuẩn đồng hồ  inner join với CHU_KY_HIEU_CHUAN
        //iLoai = 5 Tim Phieu Bao Tri
        //iLoai = 6 User login

        public frmYCSDChonMay()
        {
            InitializeComponent();
        }

        private void frmYCSDChonMay_Load(object sender, EventArgs e)
        {
            if (iLoai == 6)
            {
                TaoLuoiUser();
            }
            else
            {
                if (iLoai == 5)
                {
                    TaoLuoiPhieuBaoTri();
                }
                else
                {
                    if (iLoai == 1)
                        TaoLuoi();
                    else
                    {

                        btnALL.Visible = false;
                        btnNotALL.Visible = false;
                        TaoLuoiMay();
                    }
                }
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            if (iLoai == 6)
            {
                btnALL.Visible = false;
                btnExecute.Visible = false;
                btnNotALL.Visible = false;
                lblTKiem.Visible = false;
                txtTKiemNNNM.Visible = false;

                this.Text = "";
            }
        }

        private void TaoLuoi()
        {
            
            dtMay.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, true, true, true, true);

            for (int i = 1; i < grvMay.Columns.Count; i++)
            {
                dtMay.Columns[i].ReadOnly = true;
            }
        }

        private void TaoLuoiMay()
        {
            dtMay = new DataTable();
            dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetMayPQ", Commons.Modules.UserName, 
                    Commons.Modules.TypeLanguage, iLoai ));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, false, true, true, true);
       
        }

        private void TaoLuoiPhieuBaoTri()
        {

            dtMay = new DataTable();
            dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTimPhieuBaoTri", Commons.Modules.UserName,
                    Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, false, true, false, true);
        }

        private void TaoLuoiUser()
        {

            dtMay = new DataTable();
            string sSql = "SELECT     A.USER_LOGIN, B.FULL_NAME, C.GROUP_NAME, A.TIME_LOGIN " +
                                " FROM         dbo.LOGIN AS A INNER JOIN " +
                                " dbo.USERS AS B ON A.USER_LOGIN = B.USERNAME INNER JOIN " +
                                " dbo.NHOM AS C ON B.GROUP_ID = C.GROUP_ID ORDER BY A.TIME_LOGIN DESC ";
            dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,CommandType.Text,sSql));
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, false, true, true, true);
            grvMay.Columns["TIME_LOGIN"].DisplayFormat.FormatString = "d";
            grvMay.Columns["USER_LOGIN"].Width = 168;
            grvMay.Columns["FULL_NAME"].Width = 200;
            grvMay.Columns["GROUP_NAME"].Width = 250;
            grvMay.Columns["TIME_LOGIN"].Width = 158;
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {

                    if (iLoai == 5)
                        Commons.Modules.SQLString = grvMay.GetFocusedRowCellValue("MS_PHIEU_BAO_TRI").ToString();
                    else
                        Commons.Modules.SQLString = grvMay.GetFocusedRowCellValue("MS_MAY").ToString();

                    DialogResult = DialogResult.OK;
                    this.Close();

            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgGridViewRong", Commons.Modules.TypeLanguage));
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtTKiemNNNM_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (iLoai == 5)
                LocDuLieuPBT();
            else
                LocDuLieu();
        }
        private void LocDuLieu()
        {
            try
            {
                DataTable dtMay = new DataTable();
                dtMay = (DataTable)grdMay.DataSource;

                try
                {
                    string dk = "";

                    if (txtTKiemNNNM.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiemNNNM.Text + "%' " + dk;
                    if (txtTKiemNNNM.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiemNNNM.Text + "%' " + dk;
                    if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                    dtMay.DefaultView.RowFilter = dk;

                }
                catch { dtMay.DefaultView.RowFilter = ""; }
            }
            catch { }
        }
        private void LocDuLieuPBT()
        {
            try
            {
                DataTable dtMay = new DataTable();
                dtMay = (DataTable)grdMay.DataSource;
                try
                {
                    string dk = "";
                    if (txtTKiemNNNM.Text.Length != 0) dk = " OR  MS_PHIEU_BAO_TRI LIKE '%" + txtTKiemNNNM.Text + "%' " + dk;
                    if (txtTKiemNNNM.Text.Length != 0) dk = " OR  SO_PHIEU_BAO_TRI LIKE '%" + txtTKiemNNNM.Text + "%' " + dk;
                    if (txtTKiemNNNM.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiemNNNM.Text + "%' " + dk;
                    if (txtTKiemNNNM.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiemNNNM.Text + "%' " + dk;
                    if (txtTKiemNNNM.Text.Length != 0) dk = " OR  TEN_LOAI_BT LIKE '%" + txtTKiemNNNM.Text + "%' " + dk;
                    if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                    dtMay.DefaultView.RowFilter = dk;

                }
                catch { dtMay.DefaultView.RowFilter = ""; }
            }
            catch { }
        }


        private void grvMay_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvMay.SelectedRowsCount == 1)
                {
                    if (iLoai == 6) return;

                    if (iLoai == 5)
                        Commons.Modules.SQLString = grvMay.GetFocusedRowCellValue("MS_PHIEU_BAO_TRI").ToString();
                    else
                        Commons.Modules.SQLString = grvMay.GetFocusedRowCellValue("MS_MAY").ToString();

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch
            { }
        }

    }
}