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


namespace WareHouse
{
    public partial class frmTimNCTy : DevExpress.XtraEditors.XtraForm
    {
        GridView viewChung;
        Point ptChung;
        private string sMsNV;
        public string MsNV { get { return sMsNV; } set { sMsNV = value; } }

        private int iDangNhapXuat;
        public int DangNhapXuat { get { return iDangNhapXuat; } set { iDangNhapXuat = value; } }

        //iloai = 4 la tim ben nhap
        //iloai = 5 la tim ben xuat
        private int iLoai;
        public int Loai { get { return iLoai; } set { iLoai = value; } }
        
        public frmTimNCTy()
        {
            InitializeComponent();
        }
        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvNVCTy.RefreshData();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            if (grvNVCTy.RowCount == 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                MsNV = "";
                this.Close();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                try
                {
                    MsNV = grvNVCTy.GetFocusedRowCellValue("MS_KH").ToString();
                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmTimNCTy_Load(object sender, EventArgs e)
        {
            LoadData();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void LoadData()
        {

            DataTable dtTmp = new DataTable();
            dtTmp.Load (SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,"spGetTimNCTy", iLoai, Commons.Modules.UserName));
            if (iLoai == 4)
            {
                switch (iDangNhapXuat)
                {
                    case 1:
                    case 3:
                        dtTmp.DefaultView.RowFilter = "KHACH_HANG = 1";
                        break;
                    case 2:
                    case 4:
                    case 5:
                        dtTmp.DefaultView.RowFilter = "";
                        break;
                    case 6:
                    case 9:
                        dtTmp.DefaultView.RowFilter = "KHACH_HANG = 0";
                        break;
                    default:
                        dtTmp.DefaultView.RowFilter = "";
                        break;
                }
            }
            else
            {
                switch (iDangNhapXuat)
                {
                    case 1:
                    case 4:
                    case 5:
                    case 6:
                    case 8:
                    case 9:
                        dtTmp.DefaultView.RowFilter = "KHACH_HANG = 0";
                        break;
                    case 2:
                        dtTmp.DefaultView.RowFilter = "KHACH_HANG = 1";
                        break;
                    case 3:
                        dtTmp.DefaultView.RowFilter = "";
                        break;
                    default:
                        dtTmp.DefaultView.RowFilter = "";
                        break;

                }
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNVCTy, grvNVCTy, dtTmp, true, false, true, false);
            grvNVCTy.Columns["MS_KH"].Width = 100;
            grvNVCTy.Columns["TEN_CONG_TY"].Width = 250;
            grvNVCTy.Columns["TEN_RUT_GON"].Width = 190;
            grvNVCTy.Columns["DIA_CHI"].Width = 140;

        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtMay = new DataTable();
            dtMay = (DataTable)grdNVCTy.DataSource;

            try
            {
                string dk = "";
                if (txtTKiem.Text.Length != 0) dk = " OR  MS_KH LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_CONG_TY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_RUT_GON LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  DIA_CHI LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtMay.DefaultView.RowFilter = dk;
            }
            catch { dtMay.DefaultView.RowFilter = ""; }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (grvNVCTy.RowCount == 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                MsNV = "";
                this.Close();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                try
                {
                    MsNV = grvNVCTy.GetFocusedRowCellValue("MS_KH").ToString();
                    this.Close();
                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            try
            {
                MsNV = "";
                this.Close();
            }
            catch (Exception ex)
            {
                MsNV = "";
                this.Close();
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvNVCTy_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);

        }
    }
}