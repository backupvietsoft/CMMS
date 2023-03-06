using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Vs.Support.Commons;
using Vs.Support.Model;

namespace Vs.Support
{
    public partial class frmCustomer_View : Form
    {
        public string http = Program.http;
        public Int64 CustomerID = -1;
        public string TenCT_Full = "";
        public string ShortN = "";
        public string Address = "";
        public string CEO = "";
        public string Email = "";
        public string Phone = "";
        public string Ghi_Chu = "";
        public string HDBT_DA_KY = "";
        public Int64 CustomerID_TMP = -1;
        DataTable dtNN = new DataTable();

        public frmCustomer_View()
        {
            InitializeComponent();
        }

        #region event
        private void frmCustomer_View_Load(object sender, System.EventArgs e)
        {
            dtNN = Program.GetDataNN(this.Name.ToString());
            if (CustomerID == -1)
            {
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/getCustomerContact?CustomerID=" + CustomerID + "");

                LoadTextNull();
                LoaddgvContact(dt);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/getCustomerContact?CustomerID=" + CustomerID + "");
                LoadText();
                LoaddgvContact(dt);
                CustomerID_TMP = CustomerID;
            }
            LoadNN();
        }

        private void btnGhi_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenCT_FullName.Text.Trim()))
                {
                    MessageBox.Show(lblTenCTY_FullName.Text + " " + Program.GetNN(dtNN, " msg_KhongDuocTrong", this.Name));
                    txtTenCT_FullName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtShortName.Text.Trim()))
                {
                    MessageBox.Show(lblShortName.Text + " " + Program.GetNN(dtNN,  " msg_KhongDuocTrong", this.Name));
                    txtShortName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
                {
                    MessageBox.Show(lblAddress.Text + " " + Program.GetNN(dtNN,  " msg_KhongDuocTrong", this.Name));
                    txtAddress.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    MessageBox.Show(lblEmail.Text + " " + Program.GetNN(dtNN, " msg_KhongDuocTrong", this.Name));
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
                {
                    MessageBox.Show(lblPhone.Text + " " + Program.GetNN(dtNN,  " msg_KhongDuocTrong", this.Name));
                    txtPhone.Focus();
                    return;
                }
                //INSERT CUSTOMER
                Customer CTM = new Customer();
                CTM.CustomerID = CustomerID;
                CTM.CompanyFullName = txtTenCT_FullName.Text;
                CTM.ShortName = txtShortName.Text;
                CTM.Address = txtAddress.Text;
                CTM.CEO = txtCEO.Text;
                CTM.Email = txtEmail.Text;
                CTM.Phone = txtPhone.Text;
                CTM.HDBT_DA_KY = txtHDBT_DA_KY.Text;
                CTM.Ghi_Chu = txtGHI_CHU.Text;

                CustomerID_TMP = Convert.ToInt64(API.postWebApi(CTM, new Uri(http + "Support/Post_Customer")));
                //INSERT CustomerContact
                if (dgvContact.Rows.Count > 0)
                {

                    for (int i = 0; i < dgvContact.Rows.Count - 1; i++)
                    {
                        CustomerContact contact = new CustomerContact();
                        try { contact.ID = Convert.ToInt64(dgvContact.Rows[i].Cells["ID"].Value); } catch { }
                        try
                        {
                            contact.CustomerID = CustomerID_TMP;
                        }
                        catch { }
                        try
                        {
                            contact.Position = dgvContact.Rows[i].Cells["Position"].Value.ToString();
                        }
                        catch { }
                        try
                        {
                            contact.ContactName = dgvContact.Rows[i].Cells["ContactName"].Value.ToString();
                        }
                        catch { }
                        try { contact.PhoneNo = dgvContact.Rows[i].Cells["PhoneNo"].Value.ToString(); } catch { }
                        try { contact.Email = dgvContact.Rows[i].Cells["Email"].Value.ToString(); } catch { }
                        API.postWebApi(contact, new Uri(http + "Support/Post_CustomerContact"));
                    }
                }

                if (MessageBox.Show(Program.GetNN(dtNN, "msgGhiThanhCong", this.Name), this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    LoadTextNull();

                    LoaddgvContact(null);
                    CustomerID = -1;
                    txtTenCT_FullName.Focus();
                    return;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    this.Close();
                }
            }
            catch
            { }
        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            //DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region function
        private void LoadText()
        {
            txtTenCT_FullName.Text = TenCT_Full;
            txtShortName.Text = ShortN;
            txtAddress.Text = Address;
            txtCEO.Text = CEO;
            txtEmail.Text = Email;
            txtPhone.Text = Phone;
            txtHDBT_DA_KY.Text = HDBT_DA_KY;
            txtGHI_CHU.Text = Ghi_Chu;
        }
        private void LoadTextNull()
        {
            txtTenCT_FullName.Text = string.Empty;
            txtShortName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCEO.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtHDBT_DA_KY.Text = string.Empty;
            txtGHI_CHU.Text = string.Empty;
        }
        private void LoaddgvContact(DataTable dt)
        {
            try
            {
                DataTable dt_tmp = new DataTable();
                if (dt == null || dt.Rows.Count == 0)
                {

                    dt.Columns.Add("ID");
                    dt.Columns.Add("Position");
                    dt.Columns.Add("ContactName");
                    dt.Columns.Add("PhoneNo");
                    dt.Columns.Add("Email");
                    dt.Columns.Add("CustomerID");

                    //dgvContact.DataSource = String.Empty;
                    //dgvContact.DataSource = null;
                    //dgvContact.ColumnCount = 6;
                    //dgvContact.Columns[0].Name = "ID";
                    //dgvContact.Columns[1].Name = "Position";
                    //dgvContact.Columns[2].Name = "ContactName";
                    //dgvContact.Columns[3].Name = "PhoneNo";
                    //dgvContact.Columns[4].Name = "Email";
                    //dgvContact.Columns[5].Name = "CustomerID";
                }
                dgvContact.DataSource = dt;
                dgvContact.Columns["ID"].Visible = false;
                try
                {
                    dgvContact.Columns["CustomerID"].Visible = false;
                }
                catch { }
                Alignment();
            }
            catch
            { }
        }
        private void Alignment()
        {
            try
            {
                this.dgvContact.Columns["Position"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvContact.Columns["ContactName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvContact.Columns["PhoneNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvContact.Columns["Email"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvContact.Columns["PhoneNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch
            { }
        }
        private void LoadNN()
        {
            try
            {
                this.Text = Program.GetNN(dtNN, this.Name, this.Name);
                this.btnGhi.Text = Program.GetNN(dtNN, btnGhi.Name, this.Name);
                this.btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);
                this.lblTenCTY_FullName.Text = Program.GetNN(dtNN, lblTenCTY_FullName.Name, this.Name);
                this.lblShortName.Text = Program.GetNN(dtNN, lblShortName.Name, this.Name);
                this.lblAddress.Text = Program.GetNN(dtNN, lblAddress.Name, this.Name);
                this.lblCEO.Text = Program.GetNN(dtNN, lblCEO.Name, this.Name);
                this.lblEmail.Text = Program.GetNN(dtNN, lblEmail.Name, this.Name);
                this.lblPhone.Text = Program.GetNN(dtNN, lblPhone.Name, this.Name);
                this.lblHDBT_DA_KY.Text = Program.GetNN(dtNN, lblHDBT_DA_KY.Name, this.Name);
                this.lblGHI_CHU.Text = Program.GetNN(dtNN, lblGHI_CHU.Name, this.Name);
                this.tabTTLienHe.Text = Program.GetNN(dtNN, tabTTLienHe.Name, this.Name);
                dgvContact.Columns["Position"].HeaderText = Program.GetNN(dtNN, dgvContact.Columns["Position"].Name, this.Name);
                dgvContact.Columns["ContactName"].HeaderText = Program.GetNN(dtNN, dgvContact.Columns["ContactName"].Name, this.Name);
                dgvContact.Columns["PhoneNo"].HeaderText = Program.GetNN(dtNN, dgvContact.Columns["PhoneNo"].Name, this.Name);
                dgvContact.Columns["Email"].HeaderText = Program.GetNN(dtNN, dgvContact.Columns["Email"].Name, this.Name);
            }
            catch
            { }
        }

        #endregion

        private void dgvContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    int index = dgvContact.CurrentCell.RowIndex;

                    DataTable dt1 = new DataTable();
                    dt1 = (DataTable)dgvContact.DataSource;
                    dt1.EndInit();

                    if (dgvContact.Rows.Count <= 1) return;
                    if ((string.IsNullOrEmpty(dgvContact.Rows[index].Cells["ID"].Value.ToString()) ? -1 : Convert.ToInt32(dgvContact.Rows[index].Cells["ID"].Value)) == -1)
                    {
                        dgvContact.Rows.RemoveAt(index);
                        return;
                    }
                    if (MessageBox.Show(Program.GetNN(dtNN, "msgXoa", this.Name), Program.GetNN(dtNN, "msgThongBao", this.Name), MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    DataTable dt = new DataTable();
                    dt = API.getDataAPI(http + "Support/delContact?iID=" + Convert.ToInt64(dgvContact.Rows[index].Cells["ID"].Value) + "");
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        LoaddgvContact(API.getDataAPI(http + "Support/getCustomerContact?CustomerID=" + CustomerID + ""));
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0][0].ToString());
                    }
                }
                catch (Exception ex) { }
            }
        }
    }
}
