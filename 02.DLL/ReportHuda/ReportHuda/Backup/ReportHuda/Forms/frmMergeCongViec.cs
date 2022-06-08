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

namespace ReportHuda
{
    public partial class frmMergeCongViec : DevExpress.XtraEditors.XtraForm
    {
        GridView viewChung;
        Point ptChung;


        public string sMsLMay;
        public int iMsCV;
        public string sTenCV;

        public frmMergeCongViec()
        {
            InitializeComponent();
        }

        private void grvCV_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);

        }

        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvCViec.RefreshData();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            MergeCV();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
            DataTable dtCV = new DataTable();
            try
            {
                string dk = "";
                dtCV = (DataTable)grdCViec.DataSource;

                if (txtTKiem.Text.Length != 0) dk = " OR  MSCV_TK LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  MO_TA_CV LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtCV.DefaultView.RowFilter = dk;

            }
            catch 
            {
                try
                {
                    dtCV.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }

        private void frmMergeCongViec_Load(object sender, EventArgs e)
        {

            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCongViec", iMsCV, sMsLMay));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCViec, grvCViec, dtTmp, true, false, true, false);
                for (int i = 0; i <= dtTmp.Columns.Count - 1; i++)
                {
                    dtTmp.Columns[i].ReadOnly = true;
                }
                Commons.Modules.ObjSystems.ThayDoiNN(this);

                grvCViec.Columns["MS_CV"].Width = 50;
                grvCViec.Columns["THOI_GIAN_DU_KIEN"].Width = 70;
                grvCViec.Columns["MO_TA_CV"].Width = 150;

                grvCViec.Columns["MSCV_TK"].Visible = false;

                lblMaSo.Text = lblMaSo.Text + " : " + iMsCV.ToString();
                lblTenCV.Text = lblTenCV.Text + " : " + sTenCV;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            MergeCV();
        }

        private void MergeCV()
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCoChacMergeCV",
                    Commons.Modules.TypeLanguage) + " " + sTenCV , this.Name, MessageBoxButtons.YesNo) == DialogResult.No) return;



            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            SqlTransaction tran;
            if (con.State == ConnectionState.Closed)
                con.Open();
            tran = con.BeginTransaction();


            try
            {
                int iMsCVCopy = int.Parse(grvCViec.GetFocusedRowCellValue("MS_CV").ToString());
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(tran, "spCheckMergeCongViec", iMsCV, iMsCVCopy));
                if (dtTmp.Rows.Count > 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "msgTrungCongViecTrongPBTCV", Commons.Modules.TypeLanguage));
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                }
                //update lai ms 
                SqlHelper.ExecuteNonQuery(tran, "spMergeCongViec", iMsCV, iMsCVCopy);
                //delete ms
                SqlHelper.ExecuteNonQuery(tran, "DeleteCONG_VIEC", iMsCV);

                tran.Commit();
                con.Close();

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgThucHienThanhCong", Commons.Modules.TypeLanguage));
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "msgThucHienKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" + Ex.Message);
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                tran.Rollback();
                con.Close();
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

    }
}