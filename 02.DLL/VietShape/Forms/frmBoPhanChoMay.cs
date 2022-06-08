using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace VietShape
{
    public partial class frmBoPhanChoMay : XtraForm
    {
        public string MS_MAY = "";
        public DataTable dtTTPT;

        public frmBoPhanChoMay()
        {
            InitializeComponent();
        }



        private void frmChonPTTuBoPhan_Load(object sender, EventArgs e)
        {
            ShowBoPhan();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        TreeNode node = new TreeNode();
        private void ShowBoPhan()
        {
            try
            {
       
                dtTTPT = new DataTable();
                this.grdBP.DataSource = null;
                dtTTPT.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetBoPhanTheoMay", MS_MAY, sBT));
                dtTTPT.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBP, grvBP, dtTTPT, true, true, false, false, true, "");
                grvBP.Columns["TEN_BO_PHAN"].OptionsColumn.ReadOnly = true;
                grvBP.Columns["MS_BO_PHAN"].OptionsColumn.ReadOnly = true;
                grvBP.Columns["CHON"].Width = 60;
                grvBP.Columns["TEN_BO_PHAN"].Width = 500;
                grvBP.Columns["MS_BO_PHAN"].Width = 150;
                grvBP.Columns["MS_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBoPhanChoMay", "MS_BO_PHAN", Commons.Modules.TypeLanguage);
                grvBP.Columns["TEN_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBoPhanChoMay", "TEN_BO_PHAN", Commons.Modules.TypeLanguage);


            }
            catch
            {}
        }
        string sBT = "ChonBoPhanChoMay" + Commons.Modules.UserName;

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dtTTPT.Copy();
                dt.DefaultView.RowFilter = " CHON = 1 ";
                dt = dt.DefaultView.ToTable();
                if (dt.Rows.Count > 0)
                {
                    dtTTPT = new DataTable();
                    dtTTPT = dt;
                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                 
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChonBP", Commons.Modules.TypeLanguage),"");
                    return;
                }

            }
            catch { }
        }

    private void btnThoat_Click(object sender, EventArgs e)
    {
            Commons.Modules.ObjSystems.XoaTable(sBT);
            DialogResult = DialogResult.Cancel;
    }
}
}
