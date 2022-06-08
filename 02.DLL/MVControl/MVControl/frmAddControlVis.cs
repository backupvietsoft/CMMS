using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace MVControl
{
    public partial class frmAddControlVis : DevExpress.XtraEditors.XtraForm
    {
        public frmAddControlVis()
        {
            InitializeComponent();
        }

        private void frmAddControlVis_Load(object sender, EventArgs e)
        {
            string sSql = "";
            sSql = " SELECT [ID_FORM],[ID_CONTROL],[COL_LUOI],[TEN_CONTROL],[TEN_CONTROL_A],[TEN_CONTROL_H]  " +
                        " FROM [dbo].[DS_FORM_VISIBILE] ORDER BY [ID_FORM],[ID_CONTROL]";
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, sSql, false, false, true, true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount <= 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVisibleColGrid", "KhongCoDuLieu",
                    Commons.Modules.TypeLanguage), "");
                return;
            }
            LockControl(false);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            LockControl(true);

        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            LockControl(true);
        }
        public void LockControl(Boolean bLock)
        {
            btnSua.Visible = bLock;
            btnThoat.Visible = bLock;
            btnXoa.Visible = bLock;

            btnGhi.Visible = !bLock;
            btnKhong.Visible = !bLock;

            btnALL.Visible = !bLock;
            btnNotALL.Visible = !bLock;

            grvData.OptionsBehavior.Editable = !bLock;
            cboUser.Properties.ReadOnly = !bLock;
            cboControl.Properties.ReadOnly = !bLock;
            //if (bLock)
            //    grvData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            //else
            //    grvData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}