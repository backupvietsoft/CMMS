using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;


namespace ReportMain
{
    public partial class frmTonKhoTheoPBT : DevExpress.XtraEditors.XtraForm
    {
        public string sMsPBT;

        public frmTonKhoTheoPBT()
        {
            InitializeComponent();
        }

        private void frmTonKhoTheoPBT_Load(object sender, EventArgs e)
        {
            TaoLuoi();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void TaoLuoi()
        {

            DataTable dtTmp = new DataTable();

            string sSql;
            sSql = " SELECT CONVERT(BIT,0) AS CHON, MS_KHO , TEN_KHO , CONVERT(NVARCHAR(100),MS_KHO ) AS MS_KHO_TIM FROM IC_KHO ORDER BY  TEN_KHO ";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            dtTmp.Columns["CHON"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdKho, grvKho, dtTmp, true, true, true, true);
            for (int i = 1; i < grvKho.Columns.Count; i++)
            {
                dtTmp.Columns[i].ReadOnly = true;
            }
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvKho, "frmTonKhoTheoPBT");
            grvKho.Columns["MS_KHO_TIM"].Visible = false;
            grvKho.Columns["MS_KHO"].Width = 150;
            grvKho.Columns["CHON"].Width = 100;
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvKho);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvKho);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtKho = new DataTable();
            dtKho = (DataTable)grdKho.DataSource;

            try
            {
                string dk = "";

                if (txtTKiem.Text.Length != 0) dk = " OR  MS_KHO_TIM LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_KHO LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtKho.DefaultView.RowFilter = dk;
            }
            catch { dtKho.DefaultView.RowFilter = ""; }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string sMsKho = "";
#region Lay du lieu chon in
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)grdKho.DataSource).Copy ();
            dtTmp.DefaultView.RowFilter = " CHON = 1 ";
            dtTmp = dtTmp.DefaultView.ToTable().Copy();
            if (dtTmp.Rows.Count == 0)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "frmTonKhoTheoPBT", "ChuaChonDuLieu", Commons.Modules.TypeLanguage));
                return;
            }

#endregion  
            sMsKho = "";
            foreach (DataRow drRow in dtTmp.Rows)
            {
                if (Boolean.Parse(drRow["CHON"].ToString()) == true)
                {
                    sMsKho += (sMsKho == "" ? "" : ",") +  drRow["MS_KHO"].ToString();
                }
                
            }

            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MTonKhoTheoPBT", sMsPBT, sMsKho));



        }


    }
}