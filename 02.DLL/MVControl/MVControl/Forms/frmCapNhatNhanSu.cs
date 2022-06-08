using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using Microsoft.SqlServer.Server;
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
    public partial class frmCapNhatNhanSu : DevExpress.XtraEditors.XtraForm
    {
        public frmCapNhatNhanSu()
        {
            InitializeComponent();
        }
        public string sMsPBT = "WO-201404000004";
        public string sMsBP = "01.04";
        public int iMsCV = 58;
        #region load dữ liệu
        public void reset()
        {
            int rowCount = grvNhanSu.DataRowCount;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                grvNhanSu.SelectRow(i);
                grvNhanSu.DeleteSelectedRows();
            }
        }
        //load form
        private void frmCapNhatNhanSu_Load(object sender, EventArgs e)
        {
            loaddgrid();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        //hàm load
        public void loaddgrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "sp_GetDSCapNhatChoPhieuBT", Commons.Modules.UserName, sMsPBT,iMsCV, sMsBP, Commons.Modules.TypeLanguage));
                System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                newColumn.DefaultValue = "0";
                dt.Columns.Add(newColumn);
                newColumn.SetOrdinal(0);
                dt.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhanSu, grvNhanSu, dt, true, false, true, true, true, this.Name);
                grvNhanSu.Columns["MS_PHIEU_BAO_TRI"].Visible = false;
                grvNhanSu.Columns["MS_CV"].Visible = false;

                for (int i = 1; i <= grvNhanSu.Columns.Count - 1; i++)
                {
                    dt.Columns[i].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            this.Cursor = Cursors.Default;
        }
        #endregion
        #region sự kiện button
        private void btnExecute_Click_1(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdNhanSu.DataSource).Copy();
            dtTmp.DefaultView.RowFilter = "CHON = TRUE";
            dtTmp = dtTmp.DefaultView.ToTable();

            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaChonDuLieuCanCopy", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateNhanSu(dtTmp);
            this.Close();
        }
        private void btnALL_Click_1(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvNhanSu);
        }
        private void btnNotALL_Click_1(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvNhanSu);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        public DataTable datachon()
        {
            DataTable dtNhanSuReturn = new DataTable();
            dtNhanSuReturn = ((DataTable)grdNhanSu.DataSource).Copy();
            dtNhanSuReturn.DefaultView.RowFilter = "CHON = TRUE";
            dtNhanSuReturn = dtNhanSuReturn.DefaultView.ToTable();
            return dtNhanSuReturn;
        }
        public void UpdateNhanSu(DataTable dtNhanSuReturn)
        {
            String sBT = "CNNS_TMP" + Commons.Modules.UserName;
            try
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, dtNhanSuReturn, "");
                List<SqlParameter> parameter = new List<SqlParameter>()
                {
                    new SqlParameter("@MS_PhieuBaoTri",sMsPBT),
                    new SqlParameter("@MS_CV", iMsCV),
                    new SqlParameter("@MS_BO_PHAN", sMsBP),
                    new SqlParameter("@sBT", sBT),
                    new SqlParameter("@UName",Commons.Modules.UserName),
                    new SqlParameter("@NNgu",Commons.Modules.TypeLanguage)
                };
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "sp_CapNhatNhanVienChoPhieuBT", parameter.ToArray());

                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmPhieuBaoTri_NEW", "CapNhapThanhCong", Commons.Modules.TypeLanguage),this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch( Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            Commons.Modules.ObjSystems.XoaTable(sBT);
        }
    }
}
