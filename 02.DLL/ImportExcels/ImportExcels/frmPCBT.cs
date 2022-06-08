using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;


namespace ImportExcels
{
    public partial class frmPCBT : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtCN = new DataTable();
        public string MSTQuan;
        public string TenQuan;
        public string TenTinh;


        public frmPCBT()
        {
            InitializeComponent();
        }

        private void frmPCBT_Load(object sender, EventArgs e)
        {
            try
            {
                //MSTQuan = "HCM-001";
                txtQuan.Text = TenQuan;
                txtTinh.Text = GetTinh(MSTQuan);
                LoadCN();

                btnKhong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnKhong", Commons.Modules.TypeLanguage);
                btnSave.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnSave", Commons.Modules.TypeLanguage);
                btnThem.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnThem", Commons.Modules.TypeLanguage);
                btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "btnThoat", Commons.Modules.TypeLanguage);

                Commons.Modules.ObjSystems.ThayDoiNN(this);


            }
            catch { }
        }
        private void LoadCN()
        {
            try
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
            catch { }
        }
        private string GetTinh(string MSQuan)
        {
            try
            {
                Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
                //SqlInsert.ExecuteNonQuery(CommandType.Text, );
                DataTable  dtDL = new DataTable ();
                dtDL.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT DBO.[Get_City]('" + MSQuan + "')"));
                if (dtDL.Rows.Count == 0)
                { return ""; }
                else
                {
                    string dl="";
                    dl = dtDL.Rows[0][0].ToString();
                    return dl;
                }

            
            }
            catch { return ""; }
            
        }

        private void Enable(bool enable)
        {

            btnThoat.Enabled = !enable;
            btnThem.Enabled = !enable;
            btnKhong.Enabled = enable;
            btnSave.Enabled = enable;

            grvCN.Columns["CHON"].OptionsColumn.AllowEdit = enable;
            dtCN.Columns["CHON"].ReadOnly = !enable;
            grvCN.Columns["CHON"].OptionsColumn.ReadOnly = !enable;

        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Enable(true);
            dtCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MashjGetPCBTCNhan", MSTQuan));
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            LoadCN();
            Enable(false);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Vietsoft.SqlInfo SqlInsert = new Vietsoft.SqlInfo(Commons.IConnections.ConnectionString);
            try
            {
                SqlInsert.BeginTransaction();
                dtCN.DefaultView.RowFilter = "CHON = TRUE";
                SqlInsert.ExecuteNonQuery(CommandType.Text, "DELETE [dbo].[IC_QUOC_GIA_CONG_NHAN] WHERE [MA_QG] = '" + MSTQuan + "' ", MSTQuan);

                foreach (DataRow dr in dtCN.DefaultView.ToTable().Rows)
                {
                    SqlInsert.ExecuteNonQuery(CommandType.StoredProcedure, "MashInsPCBT", MSTQuan, dr["MS_CONG_NHAN"].ToString());
                }
                SqlInsert.CommitTransaction();
                LoadCN();
                Enable(false);
            }
            catch
            {
                SqlInsert.RollbackTransaction();
                Enable(false);
            }

        }

        private void LocData()
        {
            try
            {
                string dk = "";
                if (txtTen.Text.Length != 0) dk = " AND TEN LIKE '%" + txtTen.Text + "%' ";
                if (txtMSCN.Text.Length != 0) dk = dk + " AND MS_CONG_NHAN LIKE '%" + txtMSCN.Text + "%' ";
                dk = dk.Substring(5, dk.Length - 5);
                dtCN.DefaultView.RowFilter = dk;
            }
            catch { dtCN.DefaultView.RowFilter = ""; }
        }

        private void txtMSCN_EditValueChanged(object sender, EventArgs e)
        {
            LocData();
        }

        private void txtTen_EditValueChanged(object sender, EventArgs e)
        {
            LocData();
        }

    }
}