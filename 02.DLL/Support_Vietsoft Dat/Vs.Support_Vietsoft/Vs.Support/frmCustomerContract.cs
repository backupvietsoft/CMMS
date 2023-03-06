using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Vs.Support.Commons;

namespace Vs.Support
{
    public partial class frmCustomerContract : Form
    {
        public string http = Program.http;
        int NNgu = 0;
        private int rowIndex = 0;
        private int Temp = -1; // -1 All, 1 còn hạn, 0  hết hạn
        DataTable dtNN = new DataTable();

        private string sLoad = "";

        public Int64 ContractID = -1;

        public frmCustomerContract(int NgonNgu)
        {
            InitializeComponent();
            NNgu = NgonNgu;
        }

        #region even
        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void btnThem_Click(object sender, System.EventArgs e)
        {
            frmCustomerContract_View frmview = new frmCustomerContract_View(NNgu);
            if (frmview.ShowDialog() != DialogResult.No)
            {
                LoaddgvCtmContract();
            }
            else
            {
                LoaddgvCtmContract();
            }
        }

        private void frmCustomerContract_Load(object sender, System.EventArgs e)
        {
            sLoad = "0Load";
            dtNN = Program.GetDataNN(this.Name.ToString());
            rdo_All.Checked = true;
            LoadcboCustomerID();
            LoaddgvCtmContract();
            sLoad = "";
            LoadNN();
            LoadNNDgv();
        }

        private void cboCustomerID_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoaddgvCtmContract();
        }

        private void dgvCtmContract_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                this.dgvCtmContract.Rows[rowIndex].Selected = true;
                frmCustomerContract_View frmview = new frmCustomerContract_View(NNgu);

                try { frmview.iIDCTMC = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["ID"].Value.ToString()) ? -1 : Convert.ToInt64(dgvCtmContract.Rows[rowIndex].Cells["ID"].Value); } catch { }
                try { frmview.ContractNo = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["ContractNo"].Value.ToString()) ? null : dgvCtmContract.Rows[rowIndex].Cells["ContractNo"].Value.ToString(); } catch { }
                try { frmview.SignedDate = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["SignedDate"].Value.ToString()) ? DateTime.Now : Convert.ToDateTime(dgvCtmContract.Rows[rowIndex].Cells["SignedDate"].Value); } catch { };
                try { frmview.TypeID = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["TypeID"].Value.ToString()) ? -1 : Convert.ToInt32(dgvCtmContract.Rows[rowIndex].Cells["TypeID"].Value); } catch { };
                try { frmview.SoftwareProductID = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["SoftwareProductID"].Value.ToString()) ? -1 : Convert.ToInt32(dgvCtmContract.Rows[rowIndex].Cells["SoftwareProductID"].Value); } catch { }
                try { frmview.license = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["NumberofLicense"].Value.ToString()) ? null : dgvCtmContract.Rows[rowIndex].Cells["NumberofLicense"].Value.ToString(); } catch { }
                try { frmview.AcceptanceDate = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["AcceptanceDate"].Value.ToString()) ? DateTime.Now : Convert.ToDateTime(dgvCtmContract.Rows[rowIndex].Cells["AcceptanceDate"].Value); } catch { };
                try { frmview.MainContractID = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["MainContractID"].Value.ToString()) ? -1 : Convert.ToInt64(dgvCtmContract.Rows[rowIndex].Cells["MainContractID"].Value); } catch { }
                try { frmview.ValidUntil = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["ValidUntil"].Value.ToString()) ? DateTime.Now : Convert.ToDateTime(dgvCtmContract.Rows[rowIndex].Cells["ValidUntil"].Value); } catch { };
                try { frmview.Note = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["Note"].Value.ToString()) ? null : dgvCtmContract.Rows[rowIndex].Cells["Note"].Value.ToString(); } catch { }
                try { frmview.CustomerID = string.IsNullOrEmpty(dgvCtmContract.Rows[rowIndex].Cells["CustomerID"].Value.ToString()) ? -1 : Convert.ToInt64(dgvCtmContract.Rows[rowIndex].Cells["CustomerID"].Value); } catch { }


                frmview.flag = false;

                if (frmview.ShowDialog() != DialogResult.OK)
                {
                    ContractID = frmview.ContractID_TMP;
                    LoaddgvCtmContract();
                }
                else
                {
                    ContractID = frmview.ContractID_TMP;
                    LoaddgvCtmContract();
                }

            }
            catch
            {

            }
        }

        private void dgvCtmContract_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.dgvCtmContract.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                }
            }
            catch
            { }
        }
        #endregion

        #region function
        private void LoadcboCustomerID()
        {
            try
            {
                DataTable dt = new DataTable();
                // getCustomer API
                dt = API.getDataAPI(http + "Support/getCustomer");
                cboCustomerID.DataSource = dt;
                cboCustomerID.ValueMember = "ID";
                cboCustomerID.DisplayMember = "ShortName";
            }
            catch
            {

            }
        }
        private void LoaddgvCtmContract()
        {
            try
            {
                DataTable dt = new DataTable();
                //getCTMContract API
                dt = API.getDataAPI(http + "Support/getCTMContract?NNgu=" + NNgu + "&CustomerID=" + cboCustomerID.SelectedValue + "&Temp=" + Temp + "");
                if (dt == null || dt.Rows.Count == 0)
                {
                    dt = ((DataTable)dgvCtmContract.DataSource).Clone();
                }
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                dgvCtmContract.DataSource = dt;
                dgvCtmContract.Columns["SignedDate"].Visible = true;
                dgvCtmContract.Columns["CustomerID"].Visible = false;
                dgvCtmContract.Columns["TypeID"].Visible = false;
                dgvCtmContract.Columns["SoftwareProductID"].Visible = false;
                dgvCtmContract.Columns["MainContractID"].Visible = false;

                if (ContractID != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(ContractID));
                    dgvCtmContract.Rows[index].Selected = true;
                }

                Alignment();
            }
            catch
            {

            }
        }
        private void Alignment()
        {
            try
            {
                this.dgvCtmContract.Columns["ShortName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["ContractNo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["SignedDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["NameType"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["NameSP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["NumberofLicense"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["AcceptanceDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["MainContractID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["ValidUntil"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["Note"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCtmContract.Columns["NV_HOTRO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvCtmContract.Columns["NumberofLicense"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCtmContract.Columns["SignedDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCtmContract.Columns["AcceptanceDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCtmContract.Columns["ValidUntil"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch
            { }
        }

        private void LoadNN()
        {

            this.Text = Program.GetNN(dtNN, this.Name, this.Name);
            this.lblCustomerID.Text = Program.GetNN(dtNN, lblCustomerID.Name, this.Name);
            this.btnThem.Text = Program.GetNN(dtNN, btnThem.Name, this.Name);
            this.btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);
            this.rdo_All.Text = Program.GetNN(dtNN, rdo_All.Name, this.Name);
            this.rdo_ConHan.Text = Program.GetNN(dtNN, rdo_ConHan.Name, this.Name);
            this.rdo_HetHan.Text = Program.GetNN(dtNN, rdo_HetHan.Name, this.Name);

        }
        private void LoadNNDgv()
        {
            try
            {
                dgvCtmContract.Columns["ShortName"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["ShortName"].Name, this.Name);
                dgvCtmContract.Columns["ContractNo"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["ContractNo"].Name, this.Name);
                dgvCtmContract.Columns["SignedDate"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["SignedDate"].Name, this.Name);
                dgvCtmContract.Columns["NameType"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["NameType"].Name, this.Name);
                dgvCtmContract.Columns["NameSP"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["NameSP"].Name, this.Name);
                dgvCtmContract.Columns["NumberofLicense"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["NumberofLicense"].Name, this.Name);
                dgvCtmContract.Columns["AcceptanceDate"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["AcceptanceDate"].Name, this.Name);
                dgvCtmContract.Columns["MainContractID"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["MainContractID"].Name, this.Name);
                dgvCtmContract.Columns["ValidUntil"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["ValidUntil"].Name, this.Name);
                dgvCtmContract.Columns["Note"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["Note"].Name, this.Name);
                dgvCtmContract.Columns["NV_HOTRO"].HeaderText = Program.GetNN(dtNN, dgvCtmContract.Columns["NV_HOTRO"].Name, this.Name);
            }
            catch
            { }
        }

        #endregion

        private void dgvCtmContract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (MessageBox.Show(Program.GetNN(dtNN, "msgXoa", this.Name), Program.GetNN(dtNN, "msgThongBao", this.Name), MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    int index = dgvCtmContract.CurrentCell.RowIndex;
                    DataTable dt = new DataTable();
                    dt = API.getDataAPI(http + "Support/delContract?ContractID=" + Convert.ToInt64(dgvCtmContract.Rows[index].Cells["ID"].Value) + "");
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        LoaddgvCtmContract();
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0][0].ToString());
                    }
                }
                catch { }
            }
        }

        private void dgvCtmContract_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvCtmContract.Rows.Count; i++)
                {
                    if ((Convert.ToDateTime(dgvCtmContract.Rows[i].Cells["ValidUntil"].Value)) < DateTime.Now)
                    {
                        dgvCtmContract.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(0, 255, 255);
                    }
                    //if (Convert.ToDateTime(dgvReply.Rows[i].Cells["ValidUntil"].Value) < DateTime.Now.Date)
                    //{
                    //    dgvReply.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(219, 238, 244);
                    //}
                }
            }
            catch { }
        }

        private void rdo_All_CheckedChanged(object sender, EventArgs e)
        {
            if (sLoad == "0Load") return;
            if(rdo_All.Checked == true)
            {
                Temp = -1;
                LoaddgvCtmContract();
            }
        }

        private void rdo_ConHan_CheckedChanged(object sender, EventArgs e)
        {
            if (sLoad == "0Load") return;
            if(rdo_ConHan.Checked == true)
            {
                Temp = 1;
                LoaddgvCtmContract();
            }
        }

        private void rdo_HetHan_CheckedChanged(object sender, EventArgs e)
        {
            if (sLoad == "0Load") return;
            if(rdo_HetHan.Checked == true)
            {
                Temp = 0;
                LoaddgvCtmContract();
            }
            
        }
    }
}
