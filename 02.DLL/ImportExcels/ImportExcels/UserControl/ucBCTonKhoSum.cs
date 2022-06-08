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
    public partial class ucBCTonKhoSum : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBCTonKhoSum()
        {
            InitializeComponent();
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (KiemTH() == false) return;


            frmBCTonKhoSum frm = new frmBCTonKhoSum();
            frm.Kho = cmbKho.Text;
            frm.TuNgay = datFromDate.DateTime;
            frm.DenNgay = datToDate.DateTime;
            string sTmp = "";
            if (Commons.Modules.ObjSystems.PBTKho == true)
                sTmp = "MashjBCTonKhoSumKM";
            else
                sTmp = "MashjBCTonKhoSum";


            frm._dtSum.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                            sTmp, cmbKho.EditValue.ToString(),
                            datFromDate.DateTime, datToDate.DateTime, Commons.Modules.TypeLanguage));
            frm._dtCost = LoadCost();
            frm.ShowDialog();

        }
        private bool KiemTH()
        {
            try
            {
                if (string.IsNullOrEmpty(datFromDate.Text))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCTonKhoSum", "VuiLongChonTuNgay", Commons.Modules.TypeLanguage));
                    datFromDate.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(datToDate.Text))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCTonKhoSum", "VuiLongChonDenNgay", Commons.Modules.TypeLanguage));
                    datToDate.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cmbKho.Text))
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCTonKhoSum", "VuiLongChonKho", Commons.Modules.TypeLanguage));
                    cmbKho.Focus();
                    return false;
                }
                if (datFromDate.DateTime > datToDate.DateTime)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCTonKhoSum", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                    return false;
                }
                return true;
            }
            catch { return false; }

        }

        private void ucBCTonKhoSum_Load(object sender, EventArgs e)
        {
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCTonKhoSum", "btnExcute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmBCTonKhoSum", "btnThoat", Commons.Modules.TypeLanguage);
            LoadKho();
            datFromDate.DateTime = DateTime.Now.Date.AddMonths(-1);
            datToDate.DateTime = DateTime.Now.Date;
            Commons.Modules.ObjSystems.ThayDoiNN(this.ParentForm);
        }
        private void LoadKho()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_KHO_ALL"));
            cmbKho.Properties.DataSource = _table;
            cmbKho.Properties.DisplayMember = "TEN_KHO";
            cmbKho.Properties.ValueMember = "MS_KHO";
            cmbKho.EditValue = -1;
           

        }

        public DataTable LoadCost()
        {
            DataTable dtDL = new DataTable();
            DataTable dtTmp = new DataTable();
            DataTable dtCost = new DataTable();
            DataTable dtKho = new DataTable();

            dtCost.Columns.Add("MS_COSTCENTER");
            dtCost.Columns.Add("TEN_COSTCENTER");
            dtDL.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                            "MashjBCTonKhoCost", cmbKho.EditValue.ToString(),
                            datFromDate.DateTime, datToDate.DateTime));
            dtKho = dtDL.DefaultView.ToTable(true, "TEN_KHO", "MS_KHO");
            dtKho.DefaultView.Sort = "MS_KHO";


            foreach (DataRow rowKho in dtKho.Rows)
            {
                //dtCost.Columns.Add(rowKho["TEN_KHO"].ToString());
                //dtCost.Columns.Add(rowKho["TEN_KHO"].ToString());
                dtCost.Columns.Add(rowKho["TEN_KHO"].ToString(), System.Type.GetType("System.Double"));

            }
            dtCost.Columns.Add("Total", System.Type.GetType("System.Double"));

            dtTmp = dtDL.DefaultView.ToTable(true, "MS_COSTCENTER", "TEN_COSTCENTER");
            dtTmp.DefaultView.Sort = "MS_COSTCENTER";
            DataTable dtGT = new DataTable();

            foreach (DataRow rowCost in dtTmp.Rows)
            {
                DataRow row = dtCost.NewRow();
                row["MS_COSTCENTER"] = rowCost["MS_COSTCENTER"];
                row["TEN_COSTCENTER"] = rowCost["TEN_COSTCENTER"];
                dtCost.Rows.Add(row);
                double Tong = 0;
                foreach (DataRow rowKho in dtKho.Rows)
                {
                    dtDL.DefaultView.RowFilter = "MS_KHO = " + rowKho["MS_KHO"].ToString() + " AND MS_COSTCENTER = '" + rowCost["MS_COSTCENTER"].ToString() + "' ";
                    dtCost.Rows[dtCost.Rows.Count - 1][rowKho["TEN_KHO"].ToString()] = dtDL.DefaultView.ToTable().Rows[0]["GT"];
                    Tong = Tong + Convert.ToDouble(dtDL.DefaultView.ToTable().Rows[0]["GT"]);

                }
                row["Total"] = Tong;

            }


            return dtCost;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }


        

    }
}
