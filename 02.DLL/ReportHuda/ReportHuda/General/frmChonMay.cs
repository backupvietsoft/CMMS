using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.General
{
    public partial class frmChonMay : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtMay;
        public DataTable dtChonMay { get { return dtMay; } set { dtMay = value; } }

        private DateTime tNgay;
        public DateTime TuNgay { get { return tNgay; } set { tNgay = value; } }

        private string tGio;
        public string TuGio { get { return tGio; } set { tGio = value; } }

        private DateTime dNgay;
        public DateTime DenNgay { get { return dNgay; } set { dNgay = value; } }

        private string dGio;
        public string DenGio { get { return dGio; } set { dGio = value; } }

        public frmChonMay()
        {
            InitializeComponent();
        }

        private void frmChonMay_Load(object sender, EventArgs e)
        {

            string sql;
            sql = " SELECT CONVERT(BIT,0) AS CHON ,MS_MAY, TEN_MAY FROM MAY ORDER BY MS_MAY";

            dtMay = new DataTable();
            dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql));
            dtMay.Columns["CHON"].ReadOnly = false;
            dtMay.Columns["MS_MAY"].ReadOnly = true;
            dtMay.Columns["TEN_MAY"].ReadOnly = true;
            grdData.DataSource = dtMay;
            grvData.OptionsBehavior.Editable = true;

            grvData.PopulateColumns();
            grvData.OptionsView.ColumnAutoWidth = true;
            grvData.OptionsView.AllowHtmlDrawHeaders = true;
            grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvData.BestFitColumns();
            try
            {
                datTGio.EditValue = TuGio;
                datDGio.EditValue = DenGio;

                datTN.DateTime = TuNgay;
                datDNgay.DateTime = DenNgay;
            }
            catch { }
            Commons.Modules.ObjSystems.ThayDoiNN(this);


        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {

            DateTime TNgay, DNgay;
            try
            {
                TNgay = Convert.ToDateTime(datTN.DateTime.Date.ToShortDateString() + " " + datTGio.Text);
            }
            catch { TNgay = datTN.DateTime; }

            try
            {
                DNgay = Convert.ToDateTime(datDNgay.DateTime.Date.ToShortDateString() + " " + datDGio.Text);
            }
            catch { DNgay = datTN.DateTime; }
            if (TNgay > DNgay)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmLichTau", "TuNgayLonHonDenNgay", Commons.Modules.TypeLanguage));
                datTN.Focus();
                return;
            }





            TuNgay = datTN.DateTime;
            DenNgay = datDNgay.DateTime;
            TuGio = datTGio.Text;
            DenGio = datDGio.Text;

            DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                string dk = "";

                if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtMay.DefaultView.RowFilter = dk;

            }
            catch { dtMay.DefaultView.RowFilter = ""; }

        }


    }
}