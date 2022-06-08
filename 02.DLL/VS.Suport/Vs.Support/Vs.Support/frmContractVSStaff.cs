using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Vs.Support.Commons;
using Vs.Support.Model;

namespace Vs.Support
{
    public partial class frmContractVSStaff : Form
    {
        public string http = Program.http;
        int NNgu = 0;
        DataTable dtNN = new DataTable();

        public frmContractVSStaff( int NgonNgu )
        {
            InitializeComponent();
            NNgu = NgonNgu;
        }

        #region even
        private void frmContractVSStaff_Load(object sender, System.EventArgs e)
        {
            dtNN = Program.GetDataNN(this.Name.ToString());

            LoadCbo();
            LoadNN();
        }
        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboContractID.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaChonContract",this.Name));
                    return;
                }
                if (string.IsNullOrEmpty(cboVSStaffID.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaChonTenNV", this.Name));
                    return;
                }
                ContractVSStaff CTVSS = new ContractVSStaff();
                CTVSS.ContractID = Convert.ToInt64(cboContractID.SelectedValue);
                CTVSS.VSStaffID = Convert.ToInt32(cboVSStaffID.SelectedValue);
                CTVSS.Note = txtNote.Text.ToString();
                CTVSS.Valid = chkVaild.Checked;
                API.postWebApi(CTVSS,new Uri(http + "Support/Post_ContractVSStaff"));
                MessageBox.Show(Program.GetNN(dtNN, "msgGhiThanhCong", this.Name));
                LoadTextNull();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region function
        //Load comboVietsoftStaffID, ContractID
        private void LoadCbo()
        {
            try
            {
               
                cboVSStaffID.DataSource = API.getDataAPI(http + "Support/GetVietsoftStaff");
                cboVSStaffID.DisplayMember = "FullName";
                cboVSStaffID.ValueMember = "ID";
                cboVSStaffID.SelectedIndex = -1;

                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/GetCustomerContract?CustomerID=" + -1 + "");
                dt.Rows[0].Delete();
                cboContractID.DataSource = dt;
                cboContractID.DisplayMember = "ContractNo";
                cboContractID.ValueMember = "ID";
                cboContractID.SelectedIndex = -1;
            }
            catch { }
        }
        private void LoadTextNull()
        {
            cboContractID.SelectedIndex = -1;
            cboVSStaffID.SelectedIndex = -1;
            txtNote.Text = string.Empty;
            chkVaild.CheckState = CheckState.Unchecked;
        }
        private void LoadNN()
        {
            this.Text = Program.GetNN(dtNN,this.Name,this.Name);
            this.lblContractID.Text = Program.GetNN(dtNN,lblContractID.Name,this.Name);
            this.lblVSStaffID.Text = Program.GetNN(dtNN, lblVSStaffID.Name, this.Name);
            this.lblNote.Text = Program.GetNN(dtNN, lblNote.Name, this.Name);
            this.chkVaild.Text = Program.GetNN(dtNN, chkVaild.Name, this.Name);
            this.btnGhi.Text = Program.GetNN(dtNN, btnGhi.Name, this.Name);
            this.btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);
        }
        #endregion

    }
}
