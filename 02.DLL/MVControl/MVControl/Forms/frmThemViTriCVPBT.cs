using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MVControl.Forms
{
    public partial class formThemViTri : DevExpress.XtraEditors.XtraForm
    {
        public formThemViTri()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        public DataTable dt;
        public delegate void ThemViTri(string tenViTri, DataTable dtTMP);
        public ThemViTri themViTri;

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenViTri.Text.Trim() != "")
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["MS_VI_TRI_PT"].ToString() == txtTenViTri.Text.Trim())
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTenViTriTonTai", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                         
                            return;
                        }
                    }
                    themViTri?.Invoke(txtTenViTri.Text.Trim(), dt);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgTenViTriRong", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}