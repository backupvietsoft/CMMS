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
    public partial class frmChonPSDV : DevExpress.XtraEditors.XtraForm
    {
        public string sForm;
        public DataTable dtDuLieu;

        public frmChonPSDV()
        {
            InitializeComponent();
        }

        private void frmChonPSDV_Load(object sender, EventArgs e)
        {
            TaoLuoiBPT();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void TaoLuoiBPT()
        {
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdBC, grvBC, dtDuLieu, true, true, true, true);
        
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvBC);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvBC);
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)grdBC.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR TEN_BP_CHIU_PHI LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(4, dk.Length - 4);
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }
    }
}