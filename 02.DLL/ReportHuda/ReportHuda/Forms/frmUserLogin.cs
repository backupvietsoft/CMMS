using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda
{
    public partial class frmUserLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {
            LoadData();
            grvUser.Columns["STT"].Width = 100;
            grvUser.Columns["TIME_LOGIN"].Width = 200;
            grvUser.Columns["USER_LOGIN"].Width = 200;
            

            Commons.Modules.ObjSystems.ThayDoiNN(this);

        }

        private void LoadData()
        {
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdUser, grvUser,
                "SELECT ROW_NUMBER() OVER (ORDER BY TIME_LOGIN DESC) AS STT,* FROM LOGIN ORDER BY TIME_LOGIN DESC", false, false, true, false);
            grvUser.Columns["TIME_LOGIN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            grvUser.Columns["TIME_LOGIN"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

            
        }

        private void XoaDaTa()
        {
            if (grvUser.RowCount == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuLieuXoa", Commons.Modules.TypeLanguage));
                return;
            }

            if (MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgCoChacXoaUserNay",
                    Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Commons.IConnections.ConnectionString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            System.Data.SqlClient.SqlTransaction tran = con.BeginTransaction();
            try
            {
                string sSql = "DELETE FROM [LOGIN] " +
                    " WHERE (USER_LOGIN = N'" + grvUser.GetFocusedDataRow()["USER_LOGIN"].ToString() + "') ";

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            LoadData();
        }

        private void grvUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                XoaDaTa();
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaDaTa();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}