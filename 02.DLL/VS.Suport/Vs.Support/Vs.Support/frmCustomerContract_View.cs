using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Vs.Support.Commons;
using Vs.Support.Model;

namespace Vs.Support
{
    public partial class frmCustomerContract_View : Form
    {
        public string http = Program.http;
        int NNgu = Program.NNgu;

        public Int64 iIDCTMC = -1;
        public int iID1 = -1;

        public Int64 CustomerID = -1;
        public string ContractNo = "";
        public DateTime SignedDate = DateTime.Now;
        public int TypeID = -1;
        public int SoftwareProductID = -1;
        public string license = "";
        public DateTime AcceptanceDate = DateTime.Now;
        public Int64 MainContractID = -1;
        public DateTime ValidUntil = DateTime.Now;
        public string Note = "";

        public Int64 ContractID_TMP = -1;
        public bool flag = true; // true them moi, false: double click

        DataGridViewComboBoxColumn cboFullName;
        DataTable dtNN = new DataTable();

        public frmCustomerContract_View(int NgonNgu)
        {
            InitializeComponent();
            NNgu = NgonNgu;
        }
        #region even
        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnGhi_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtContractNo.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaNhapContractNo", this.Name));
                    txtContractNo.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtNumberofLicense.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaNhapNumberofLicense", this.Name));
                    txtNumberofLicense.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboNameType.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaChonLoaiHopDong", this.Name));
                    cboNameType.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboNameSP.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaChonSanPham", this.Name));
                    cboNameSP.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboCustomerID.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaChonKhachHang", this.Name));
                    cboCustomerID.Focus();
                    return;
                }
                //Kiem trung ContractNo
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/KiemTrung?ContractNo=" + txtContractNo.Text.Trim() + "&iID=" + iIDCTMC + "");
                if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                {
                    MessageBox.Show(lblContractNo.Text + " " + Program.GetNN(dtNN, "msgDaTonTai", this.Name));
                    txtContractNo.Focus();
                    return;
                }
                CustomerContract CTMC = new CustomerContract();
                CTMC.ID = iIDCTMC;
                CTMC.ContractNo = txtContractNo.Text;

                CTMC.NumberofLicense = Convert.ToInt32(txtNumberofLicense.Text);

                if (cboMainConTractID.SelectedValue == null)
                    CTMC.MainContractID = null;
                else
                    CTMC.MainContractID = Convert.ToInt64(cboMainConTractID.SelectedValue);
                CTMC.SignedDate = txtSingnedDate.Value;
                CTMC.TypeID = Convert.ToInt32(cboNameType.SelectedValue);
                CTMC.SoftwareProductID = Convert.ToInt32(cboNameSP.SelectedValue);
                CTMC.AcceptanceDate = txtAcceptanceDate.Value;
                CTMC.ValidUntil = txtValidUntil.Value;
                CTMC.CustomerID = Convert.ToInt64(cboCustomerID.SelectedValue);
                CTMC.Note = txtNote.Text;
                ContractID_TMP = Convert.ToInt64(API.postWebApi(CTMC, new Uri(http + "Support/Post_CustomerContract")));

                // Insert ContractVSStaff
                if (dgvContractVSS.Rows.Count > 0)
                {
                    ContractVSStaff CTVSS = new ContractVSStaff();
                    for (int i = 0; i < dgvContractVSS.Rows.Count - 1; i++)
                    {
                        try { CTVSS.iID1 = Convert.ToInt32(dgvContractVSS.Rows[i].Cells["ID"].Value); } catch { }
                        try { CTVSS.ContractID = ContractID_TMP; } catch { }
                        try { CTVSS.VSStaffID = Convert.ToInt32(dgvContractVSS.Rows[i].Cells["ID"].Value); } catch { }
                        try { CTVSS.Note = Convert.ToString(dgvContractVSS.Rows[i].Cells["GHI_CHU"].Value); } catch { }
                        try { CTVSS.Valid = Convert.ToBoolean(dgvContractVSS.Rows[i].Cells["Valid"].Value); } catch { }
                        API.postWebApi(CTVSS, new Uri(http + "Support/Post_ContractVSStaff"));
                    }
                }

                if (iIDCTMC != -1) // Sửa
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgGhiThanhCong", this.Name), Program.GetNN(dtNN, "msgThongBao", this.Name));
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else // Thêm mới
                {
                    if (MessageBox.Show(Program.GetNN(dtNN, "msgGhiHDThanhCong", this.Name), Program.GetNN(dtNN, "msgThongBao", this.Name), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        LoadTextNull();
                        txtContractNo.Focus();
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCustomerContract_View_Load(object sender, System.EventArgs e)
        {
            dtNN = Program.GetDataNN(this.Name.ToString());

            LoadCbo();
            if (ContractNo == "")
            {
                LoadTextNull();
                txtContractNo.Focus();
            }
            else
            {
                LoadText();
            }
            DataTable dt = new DataTable();
            dt = API.getDataAPI(http + "Support/getContractVStaff?ContractID=" + iIDCTMC + "");
            LoadLuoi(dt);
            LoadNN();
        }

        #endregion

        #region function
        private void LoadCbo()
        {
            try
            {
                try
                {
                    //Load cboNameType
                    cboNameType.DataSource = API.getDataAPI(http + "Support/getContractType");
                    cboNameType.DisplayMember = "Name";
                    cboNameType.ValueMember = "ID";
                    cboNameType.SelectedIndex = -1;
                }
                catch { }

                try
                {
                    //Load cboNameSP
                    cboNameSP.DataSource = API.getDataAPI(http + "Support/getSoftwareProducts?NNgu=" + NNgu + "");
                    cboNameSP.DisplayMember = "ShortName";
                    cboNameSP.ValueMember = "ID";
                    cboNameSP.SelectedIndex = -1;
                }
                catch { }

                try
                {
                    //LoadcboMainContract
                    cboMainConTractID.DataSource = API.getDataAPI(http + "Support/getMainContract?CustomerID=" + CustomerID + "");
                    cboMainConTractID.DisplayMember = "ContractNo";
                    cboMainConTractID.ValueMember = "ID";
                    cboMainConTractID.SelectedIndex = -1;
                }
                catch { }

                try
                {
                    //LoadcboCustomerID
                    DataTable dt = new DataTable();
                    dt = API.getDataAPI(http + "Support/getCustomer");
                    dt.Rows[0].Delete();
                    cboCustomerID.DataSource = dt;
                    cboCustomerID.DisplayMember = "ShortName";
                    cboCustomerID.ValueMember = "ID";
                    cboCustomerID.SelectedIndex = -1;
                }
                catch { }
            }
            catch
            {

            }
        }
        private void LoadText()
        {
            try
            {
                txtContractNo.Text = ContractNo;
                txtSingnedDate.Value = SignedDate;
                cboNameType.SelectedValue = TypeID;
                cboNameSP.SelectedValue = SoftwareProductID;
                txtNumberofLicense.Text = license;
                txtAcceptanceDate.Value = AcceptanceDate;
                cboMainConTractID.SelectedValue = MainContractID;
                txtValidUntil.Value = ValidUntil;
                txtNote.Text = Note;
                cboCustomerID.SelectedValue = CustomerID;
            }
            catch
            { }
        }
        private void LoadTextNull()
        {
            txtContractNo.Text = string.Empty;
            txtNumberofLicense.Text = null;
            txtNote.Text = string.Empty;
            txtSingnedDate.Value = DateTime.Now;
            txtAcceptanceDate.Value = DateTime.Now;
            txtValidUntil.Value = DateTime.Now;
            cboCustomerID.SelectedIndex = -1;
            cboMainConTractID.SelectedIndex = -1;
            cboNameSP.SelectedIndex = -1;
            cboNameType.SelectedIndex = -1;
            txtContractNo.Focus();


        }
        private void LoadNN()
        {
            this.Text = Program.GetNN(dtNN, this.Name, this.Name);
            this.lblContractNo.Text = Program.GetNN(dtNN, lblContractNo.Name, this.Name);
            this.lblNumberofLicense.Text = Program.GetNN(dtNN, lblNumberofLicense.Name, this.Name);
            this.lblMainContractID.Text = Program.GetNN(dtNN, lblMainContractID.Name, this.Name);
            this.lblNameType.Text = Program.GetNN(dtNN, lblNameType.Name, this.Name);
            this.lblNameSP.Text = Program.GetNN(dtNN, lblNameSP.Name, this.Name);
            this.lblSignedDate.Text = Program.GetNN(dtNN, lblSignedDate.Name, this.Name);
            this.lblAcceptanceDate.Text = Program.GetNN(dtNN, lblAcceptanceDate.Name, this.Name);
            this.lblValidUntil.Text = Program.GetNN(dtNN, lblValidUntil.Name, this.Name);
            this.lblCustomerID.Text = Program.GetNN(dtNN, lblCustomerID.Name, this.Name);
            this.lblNote.Text = Program.GetNN(dtNN, lblNote.Name, this.Name);
             
            this.btnGhi.Text = Program.GetNN(dtNN, btnGhi.Name, this.Name);
            this.btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);

            lblContractVSStaff.Text = Program.GetNN(dtNN, lblContractVSStaff.Name, this.Name);
            dgvContractVSS.Columns["FullName"].HeaderText = Program.GetNN(dtNN, "FullName", this.Name);
            dgvContractVSS.Columns["Valid"].HeaderText = Program.GetNN(dtNN, dgvContractVSS.Columns["Valid"].Name, this.Name);
            dgvContractVSS.Columns["GHI_CHU"].HeaderText = Program.GetNN(dtNN, dgvContractVSS.Columns["GHI_CHU"].Name, this.Name);
        }

        #region Lưới 
        private void LoadLuoi(DataTable dt)
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    try
                    {
                        dt.Clear();
                        dt.Columns.Add("ID");
                        dt.Columns.Add("ContractVSSID");
                        dt.Columns.Add("Valid");
                        dt.Columns.Add("GHI_CHU");
                        dt.Columns["Valid"].DataType = typeof(bool);
                    }
                    catch { }
                }
                DataTable dt_temp = new DataTable();
                dt_temp = dt.Clone();
                dt_temp.Columns["ID"].ReadOnly = false;
                dt_temp.Columns["ID"].DataType = typeof(string);
                foreach (DataRow row in dt.Rows)
                {
                    DataRow drow = dt_temp.NewRow();

                    drow["ID"] = row["ID"];
                    drow["ContractVSSID"] = row["ContractVSSID"];
                    drow["Valid"] = row["Valid"];
                    drow["GHI_CHU"] = row["GHI_CHU"];
                    dt_temp.Rows.Add(drow);
                }
                dt_temp.AcceptChanges();
                dgvContractVSS.DataSource = dt_temp;
                dgvContractVSS.Columns["ID"].Visible = false;
                dgvContractVSS.Columns["ContractVSSID"].Visible = false;
                LoadcboVSStaff();

                // Di chuyển combo lên cột đầu tiên
                int indexCloumns = dgvContractVSS.Columns.Count - 1;
                dgvContractVSS.Columns[indexCloumns].DisplayIndex = 0;

                Alignment();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadcboVSStaff()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/GetVietsoftStaff");
                cboFullName = new DataGridViewComboBoxColumn();
                cboFullName.HeaderText = "FullName";
                cboFullName.Name = "FullName";
                cboFullName.DataSource = dt;
                cboFullName.DisplayMember = "FullName";
                cboFullName.ValueMember = "ID";
                cboFullName.DataPropertyName = "ID";
                dgvContractVSS.Columns.Add(cboFullName);
            }
            catch  { }
        }
        private void Alignment()
        {
            try
            {
                this.dgvContractVSS.Columns["FullName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvContractVSS.Columns["Valid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvContractVSS.Columns["GHI_CHU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch
            { }
        }
        #endregion

        #endregion

        private void dgvContractVSS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    int index = dgvContractVSS.CurrentCell.RowIndex;

                    if (dgvContractVSS.Rows.Count <= 1) return;
                    if ((string.IsNullOrEmpty(dgvContractVSS.Rows[index].Cells["ContractVSSID"].Value.ToString()) ? -1 : Convert.ToInt64(dgvContractVSS.Rows[index].Cells["ContractVSSID"].Value)) == -1)
                    {
                        dgvContractVSS.Rows.RemoveAt(index);
                        return;
                    }
                    if (MessageBox.Show(Program.GetNN(dtNN, "msgXoa", this.Name), Program.GetNN(dtNN, "msgThongBao", this.Name), MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    DataTable dt = new DataTable();
                    dt = API.getDataAPI(http + "Support/delContractVSStaff?iID=" + Convert.ToInt64(dgvContractVSS.Rows[index].Cells["ContractVSSID"].Value) + "");
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        //LoadLuoi(API.getDataAPI(http + "Support/getContractVStaff?ContractID=" + iIDCTMC + ""));
                        dgvContractVSS.Rows.RemoveAt(index);
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0][0].ToString());
                    }
                }
                catch { }
            }
        }

        private void txtNumberofLicense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
