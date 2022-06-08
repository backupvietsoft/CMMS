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
    public partial class ucBCTonKho : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBCTonKho()
        {
            InitializeComponent();
        }

        private void ucBCTonKho_Load(object sender, EventArgs e)
        {
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCTonKhoVTri", "btnExcute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCTonKhoVTri", "btnThoat", Commons.Modules.TypeLanguage);
            LoadKho();
            datFromDate.DateTime = DateTime.Now.Date.AddMonths(-1);
            datToDate.DateTime = DateTime.Now.Date;
        }
        private void LoadKho()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_KHO_ALL"));
            cmbKho.Properties.DataSource = _table;
            cmbKho.Properties.DisplayMember = "TEN_KHO";
            cmbKho.Properties.ValueMember = "MS_KHO";
            cmbKho.EditValue = -1;
            //cmbKho.Text = "ALL";
            Commons.Modules.ObjSystems.ThayDoiNN(this.ParentForm);
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (KiemTH() == false) return;

            frmBCTonKhoVTri frm = new frmBCTonKhoVTri();
            frm.Kho = cmbKho.Text;
            frm.TuNgay = datFromDate.DateTime;
            frm.DenNgay = datToDate.DateTime;
            string sTmp = "";
            if (Commons.Modules.ObjSystems.PBTKho == true)
                sTmp = "MashjBCTonKhoTheoViTriKM";
            else
                sTmp = "MashjBCTonKhoTheoViTri";
            frm._TableSource.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                            sTmp, cmbKho.EditValue.ToString(),
                            datFromDate.DateTime, datToDate.DateTime, Commons.Modules.TypeLanguage));
            frm.ShowDialog();
        }
        private bool KiemTH()
        {
            try 
            {
                if (string.IsNullOrEmpty(datFromDate.Text))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "VuiLongChonTuNgay", Commons.Modules.TypeLanguage));
                    datFromDate.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(datToDate.Text)) 
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "VuiLongChonDenNgay", Commons.Modules.TypeLanguage));
                    datToDate.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cmbKho.Text))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "VuiLongChonKho", Commons.Modules.TypeLanguage));
                    cmbKho.Focus();
                    return false;
                }
                if (datFromDate.DateTime > datToDate.DateTime)
                {
                    MessageBox.Show (Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                    return false;
                }
                return true;
            }
            catch { return false; }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
