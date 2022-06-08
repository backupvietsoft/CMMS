using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.NMN_TD
{
    public partial class UCXuatNhapTon_TD : UserControl
    {
        private bool isFirst = false;
        public UCXuatNhapTon_TD()
        {
            InitializeComponent();
        }

        private void UCXuatNhapTon_TD_Load(object sender, EventArgs e)
        {
            txtFrom.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            txtTo.DateTime = DateTime.Now;
            isFirst = true;
            DataTable tblKho = new DataTable();
            tblKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_LIST_KHO", Commons.Modules.UserName));
            cmbKho.Properties.DataSource = tblKho;
            cmbKho.Properties.DisplayMember = "TEN_KHO";
            cmbKho.Properties.ValueMember = "MS_KHO";
            cmbKho.EditValue = -1;
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "btnThoat", Commons.Modules.TypeLanguage);
        }
        private void txtFrom_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {

                    if ((DateTime)e.NewValue > txtTo.DateTime)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }
        private void txtTo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (isFirst)
                {
                    if ((DateTime)e.NewValue < txtFrom.DateTime)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "MsgToDateLonFromDate", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }

                }
            }
            catch { }
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            frmXuatNhapTon_TD obj = new frmXuatNhapTon_TD();
            obj.TuNgay = lblTuNgay.Text + " " + txtFrom.Text + " " + lblDenNgay.Text + " " + txtTo.Text;
            obj.Kho = lblKho.Text + " " + cmbKho.Text;
            obj._Table_Source = new DataTable();
            
            obj._Table_Source.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_NHU_Y_GET_XUAT_NHAP_KHO", cmbKho.EditValue,
                                  Convert.ToDateTime(txtFrom.DateTime.ToShortDateString()), Convert.ToDateTime(txtTo.DateTime.ToShortDateString()).AddDays(1), Commons.Modules.TypeLanguage, 1));
            if(obj._Table_Source.Rows.Count>0)
                obj.ShowDialog();
            else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmXuatNhapTon_TD", "Khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
