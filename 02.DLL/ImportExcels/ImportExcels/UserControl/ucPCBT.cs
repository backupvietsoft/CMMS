using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ImportExcels.UserControl
{
    public partial class ucPCBT : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable dtCN = new DataTable();
        public string MSTQuan;

        public ucPCBT()
        {
            InitializeComponent();
        }
        private void LoadCN()
        {
            dtCN = new DataTable();
            dtCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MashjGetPCBaoTri", MSTQuan));
            grdCN.DataSource = dtCN;
            grvCN.PopulateColumns();
            grvCN.Columns["TEN"].Visible = false;
            grvCN.OptionsView.ColumnAutoWidth = true;
            grvCN.OptionsView.AllowHtmlDrawHeaders = true;
            grvCN.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvCN.BestFitColumns();

            int i = 0;
            foreach (DataColumn column in dtCN.Columns)
            {
                grvCN.Columns[i].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, column.Caption, Commons.Modules.TypeLanguage);
                i += 1;
            }
        }

        private void ucPCBT_Load(object sender, EventArgs e)
        {
            MSTQuan = "HCM-001";
            LoadCN();            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Enable(true);
            //DataTable dtCNhan = new DataTable();
            dtCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MashjGetPCBTCNhan", MSTQuan));

        }

        private void btnKGhi_Click(object sender, EventArgs e)
        {
            LoadCN();
            Enable(false);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            //MashInsPCBT
            Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            try
            {
                SqlInsert.BeginTransaction();
                dtCN.DefaultView.RowFilter = "CHON = TRUE";
                SqlInsert.ExecuteNonQuery(CommandType.Text, "DELETE [dbo].[IC_QUOC_GIA_CONG_NHAN] WHERE [MA_QG] = '" +  MSTQuan + "' ", MSTQuan);

                foreach (DataRow dr in dtCN.DefaultView.ToTable().Rows)
                {
                    SqlInsert.ExecuteNonQuery(CommandType.StoredProcedure, "MashInsPCBT", MSTQuan, dr["MS_CONG_NHAN"].ToString());
                }
                SqlInsert.CommitTransaction();
                LoadCN();
                Enable(false);
            }
            catch {
                SqlInsert.RollbackTransaction();
            }
        }

        private void Enable(bool enable)
        {
            
            btnThem.Enabled = !enable;
            btnExit.Enabled = !enable;
            btnGhi.Enabled = enable;
            btnKGhi.Enabled = enable;

            grvCN.Columns["CHON"].OptionsColumn.AllowEdit = enable;
            dtCN.Columns["CHON"].ReadOnly = !enable;
            grvCN.Columns["CHON"].OptionsColumn.ReadOnly = !enable;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        

    }
}
