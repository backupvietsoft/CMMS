using System.Data;
using System.Windows.Forms;
using Vs.Support.Commons;

namespace Vs.Support
{
    public partial class frmReport_NV : Form
    {
        public string http = Program.http;
        public int NNgu = 0;
        public frmReport_NV(int NgonNgu)
        {
            InitializeComponent();
            NNgu = NgonNgu;
        }

        #region even
        private void frmReport_NV_Load(object sender, System.EventArgs e)
        {
            Loadcbo();
            cboContractID.Enabled = false;
            cboCustomerID.Enabled = false;
            rdAll.Checked = true;
        }

        private void btnIn_Click(object sender, System.EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch
            { }
        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void rdCustomerID_CheckedChanged(object sender, System.EventArgs e)
        {
            cboCustomerID.Enabled = true;
            cboCustomerID.SelectedIndex = 0;

            cboContractID.Enabled = false;
            cboContractID.SelectedIndex = 0;
        }

        private void rdContractID_CheckedChanged(object sender, System.EventArgs e)
        {
            cboContractID.Enabled = true;
            cboContractID.SelectedIndex = 0;
            cboCustomerID.Enabled = false;
            cboCustomerID.SelectedIndex = 0;
        }

        private void rdAll_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                cboCustomerID.SelectedIndex = 0;
                cboContractID.SelectedIndex = 0;

                cboCustomerID.Enabled = false;
                cboContractID.Enabled = false;
            }
            catch { }
        }
        #endregion

        #region function
        private void Loadcbo()
        {
            try
            {
                // getCustomer API
                cboCustomerID.DataSource = API.getDataAPI(http + "Support/getCustomer");
                cboCustomerID.ValueMember = "ID";
                cboCustomerID.DisplayMember = "ShortName";
                cboCustomerID.SelectedIndex = 0;

                cboContractID.DataSource = API.getDataAPI(http + "Support/GetCustomerContract");
                cboContractID.DisplayMember = "ContractNo";
                cboContractID.ValueMember = "ID";
                cboContractID.SelectedIndex = 0;

            }
            catch
            { }
        }
        private void LoadData()
        {
            try
            {
                dgvThoiGianHT.DataSource = API.getDataAPI(http + "Support/Report_NV?CustomerID=" + cboCustomerID.SelectedValue + "&ContractID=" + cboContractID.SelectedValue + "");
            }
            catch
            { }
        }
        #endregion

     
    }
}
