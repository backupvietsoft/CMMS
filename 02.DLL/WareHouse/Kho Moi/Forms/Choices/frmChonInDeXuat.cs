using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WareHouse
{
    public partial class frmChonInDeXuat : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dtDeXuat = new DataTable();

        public frmChonInDeXuat()
        {
            InitializeComponent();
        }

        private void frmChonInDeXuat_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtDeXuat, true, true, true, true);


            for (int i = 1; i <= dtDeXuat.Columns.Count - 1; )
            {
                dtDeXuat.Columns[i].ReadOnly = true;
                grvBC.Columns[i].OptionsColumn.ReadOnly = true;
                grvBC.Columns[i].Visible = false;
                i++;
            }
            grvBC.Columns["CHON"].Visible = true;
            grvBC.Columns["GHI_CHU"].Visible = true;
            grvBC.Columns["TEN_DVT"].Visible = true;
            grvBC.Columns["QUY_CACH"].Visible = true;
            grvBC.Columns["TEN_PT"].Visible = true;
            grvBC.Columns["MS_PT"].Visible = true;


            Commons.Modules.ObjSystems.ThayDoiNN(this);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
        }
    }
}