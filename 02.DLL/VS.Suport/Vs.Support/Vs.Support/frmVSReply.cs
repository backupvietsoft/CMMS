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
    public partial class frmVSReply : Form
    {
        public string http = Program.http;

        int NNgu = 0;

        Int64 CustomerID = -1; // -1 vietsoft, else: khach hang
        int VSStaffID = Program.VietStaffID; // -1 ViewAll, else view theo user
        int VSSDept = Program.VSSDept; // -1 ViewAll phong`, 2  phong` ky~ thuat
        string sLoad = "0Load";
        string UserName = "";
        string FullName = "";
        string TenCT = "";
        string EMAIL = "";
        string Phone = "";
        string Zalo = "";

        string sMailFrom = "";
        string sMailPass = "";
        string sMailSMTP = "";
        int iMailPort = -1;

        private int rowIndex = 0;

        bool flag = true;
        private DataTable dt_grid = new DataTable();

        DataTable dtNN = new DataTable();


        Int64 iIDRq = -1;
        string CHUOI_CHA = "";

        System.Globalization.CultureInfo cultures = new System.Globalization.CultureInfo("en-US");
        public frmVSReply(int NgonNgu, string UName, string FName, string sTEN_CT, string sEMAIL, string sPhone, string sZalo, Int64 sCustomerID, string MailForm, string MailPass, string MailSMTP, int MailPort)
        {
            InitializeComponent();
            NNgu = NgonNgu;
            UserName = UName;
            FullName = FName;
            TenCT = sTEN_CT;
            EMAIL = sEMAIL;
            Phone = sPhone;
            Zalo = sZalo;
            CustomerID = sCustomerID;

            sMailFrom = MailForm;
            sMailPass = MailPass;
            sMailSMTP = MailSMTP;
            iMailPort = MailPort;
        }

        #region even
        private void frmVSReply_Load(object sender, EventArgs e)
        {
            dtNN = Program.GetDataNN(this.Name);
            LoadcboCustomer();
            if (CustomerID != -1)
            {
                cboCustomer.SelectedValue = CustomerID;
                cboCustomer.Enabled = false;
                LoadcboContract();
            }
            else
            {
                LoadcboContract();
            }
            sLoad = "0Load";
            txtTNgay.Text = DateTime.Now.AddMonths(-1).ToString();
            txtDNgay.Text = DateTime.Now.ToString();
            sLoad = "";
            if (Program.UNameLogin == "admin")
            {
                CustomerID = -1;
                VSStaffID = -1;
                VSSDept = -1;
            }
            dt_grid = API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + "");
            LoadgrdReply(dt_grid);
            LoadNNCDinh();
            loadNNDgv();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTNgay_ValueChanged(object sender, EventArgs e)
        {

            if (sLoad == "0Load") return;
            if (txtTNgay.Text != "" && txtTNgay != null && txtDNgay.Text != "" && txtDNgay != null)
            {
                dt_grid = API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + "");
                LoadgrdReply(dt_grid);
                flag = true;
            }
        }

        private void txtDNgay_ValueChanged(object sender, EventArgs e)
        {
            if (sLoad == "0Load") return;

            if (txtTNgay.Text != "" && txtTNgay != null && txtDNgay.Text != "" && txtDNgay != null)
            {
                dt_grid = API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + "");
                LoadgrdReply(dt_grid);
                flag = true;
            }
        }

        private void dgvReply_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvReply.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                Int64 sCustomerID = string.IsNullOrEmpty(dgvReply.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString()) ? -1 : Convert.ToInt64(dgvReply.Rows[e.RowIndex].Cells["CustomerID"].Value);
                Int64 sContractID = string.IsNullOrEmpty(dgvReply.Rows[e.RowIndex].Cells["ContractID"].Value.ToString()) ? -1 : Convert.ToInt64(dgvReply.Rows[e.RowIndex].Cells["ContractID"].Value);
                Int64 iIDTiepTuc = string.IsNullOrEmpty(dgvReply.Rows[e.RowIndex].Cells["ID"].Value.ToString()) ? -1 : Convert.ToInt32(dgvReply.Rows[e.RowIndex].Cells["ID"].Value);

                if (e.ColumnIndex == dgvReply.Columns["btnTiepTuc"].Index)
                {
                    frmSupport frmsp = new frmSupport(NNgu, UserName, FullName, TenCT, EMAIL, Phone, Zalo, sCustomerID, sContractID, sMailFrom, sMailPass, sMailSMTP, iMailPort);
                    frmsp.iIDTT = iIDTiepTuc;
                    frmsp.TrangThaiF = 1;
                    if (frmsp.ShowDialog() != DialogResult.No) return;
                    if (CHUOI_CHA == "")
                    {
                        DataTable dt_temp = new DataTable();
                        dt_temp = API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + "");
                        LoadgrdReply(dt_temp);

                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        dt = API.getDataAPI(http + "Support/GetCHUOI_CHA?iIDRq=" + iIDRq + "");
                        CHUOI_CHA = dt.Rows[0][0].ToString();
                        DataTable dt_temp1 = new DataTable();
                        dt_temp1 = API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + "");
                        LoadgrdReply(dt_temp1);
                    }
                }
            }
            catch
            { }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)(dgvReply.DataSource);

                if (txtSearch.TextLength > 0)
                {
                    string TextSearch = string.Format("ShortName LIKE '%{0}%' OR RequestName LIKE '%{0}%' OR RequestUser LIKE '%{0}%' OR RequestContent LIKE '%{0}%' OR FullName LIKE '%{0}%' OR ReplyContent LIKE '%{0}%' ", txtSearch.Text);
                    try
                    {

                        dt.DefaultView.RowFilter = TextSearch;
                    }
                    catch { dt.DefaultView.RowFilter = ""; }
                }
                else { dt.DefaultView.RowFilter = ""; }
                for (int i = 0; i < dgvReply.Rows.Count; i++)
                {
                    if ((Convert.ToInt32(dgvReply.Rows[i].Cells["PriorityID"].Value)) == 1)
                    {
                        dgvReply.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);

                    }
                    if ((Convert.ToInt32(dgvReply.Rows[i].Cells["PriorityID"].Value)) == 2)
                    {
                        dgvReply.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204);
                    }
                    if ((Convert.ToInt32(dgvReply.Rows[i].Cells["PriorityID"].Value)) == 3)
                    {
                        dgvReply.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 196, 137);
                    }
                }
            }
            catch
            {

            }
        }
        private void dgvReply_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 & e.ColumnIndex >= 0)
                {
                    e.Handled = true;
                    e.PaintBackground(e.CellBounds, true);

                    string sw = txtSearch.Text;

                    if (!string.IsNullOrEmpty(sw))
                    {
                        string val = (string)e.FormattedValue;
                        int sindx = val.ToLower().IndexOf(sw.ToLower());
                        if (sindx >= 0)
                        {
                            Rectangle hl_rect = new Rectangle();
                            hl_rect.Y = e.CellBounds.Y + 2;
                            hl_rect.Height = e.CellBounds.Height - 5;

                            string sBefore = val.Substring(0, sindx);
                            string sWord = val.Substring(sindx, sw.Length);
                            Size s1 = TextRenderer.MeasureText(e.Graphics, sBefore, e.CellStyle.Font, e.CellBounds.Size);
                            Size s2 = TextRenderer.MeasureText(e.Graphics, sWord, e.CellStyle.Font, e.CellBounds.Size);

                            if (s1.Width > 5)
                            {
                                hl_rect.X = e.CellBounds.X + s1.Width - 5;
                                hl_rect.Width = s2.Width - 6;
                            }
                            else
                            {
                                hl_rect.X = e.CellBounds.X + 2;
                                hl_rect.Width = s2.Width - 6;
                            }

                            SolidBrush hl_brush = default(SolidBrush);
                            if (((e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None))
                            {
                                hl_brush = new SolidBrush(Color.DarkGoldenrod);
                            }
                            else
                            {
                                hl_brush = new SolidBrush(Color.Yellow);
                            }

                            e.Graphics.FillRectangle(hl_brush, hl_rect);

                            hl_brush.Dispose();
                        }
                    }
                    e.PaintContent(e.CellBounds);
                }
                for (int i = 0; i < dgvReply.Rows.Count; i++)
                {
                    if ((Convert.ToInt32(dgvReply.Rows[i].Cells["PriorityID"].Value)) == 1)
                    {
                        dgvReply.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                    }
                    if ((Convert.ToInt32(dgvReply.Rows[i].Cells["PriorityID"].Value)) == 2)
                    {
                        dgvReply.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204);
                    }
                    if ((Convert.ToInt32(dgvReply.Rows[i].Cells["PriorityID"].Value)) == 3)
                    {
                        dgvReply.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 196, 137);
                    }
                    //if (Convert.ToDateTime(dgvReply.Rows[i].Cells["ValidUntil"].Value) < DateTime.Now.Date)
                    //{
                    //    dgvReply.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(219, 238, 244);
                    //}
                }
            }
            catch
            { }
        }


        #endregion

        #region function
        private void AddButton()
        {
            DataGridViewButtonColumn btnRep = new DataGridViewButtonColumn();
            btnRep.Name = "btnTiepTuc";
            btnRep.Text = "...";
            btnRep.HeaderText = "btnTiepTuc";
            btnRep.UseColumnTextForButtonValue = true;
            dgvReply.Columns.Add(btnRep);
        }
        private void LoadgrdReply(DataTable dt)
        {
            try
            {
                try
                {
                    dgvReply.Columns.Remove(dgvReply.Columns["btnTiepTuc"]);
                }
                catch
                { }

                if (dt == null || dt.Rows.Count == 0)
                {
                    dt = ((DataTable)dgvReply.DataSource).Clone();
                }
                dgvReply.DataSource = dt;
                Cal_Tong();
                try { dgvReply.Columns["RequesTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; } catch { }
                try { dgvReply.Columns["SentTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; } catch { }
                dgvReply.Columns["ID"].Visible = false;
                dgvReply.Columns["ID_RatingScore"].Visible = false;
                dgvReply.Columns["CustomerID"].Visible = false;
                dgvReply.Columns["TONGYC"].Visible = false;
                dgvReply.Columns["AGVReplyTime"].Visible = false;
                dgvReply.Columns["PriorIDCtn"].Visible = false;
                dgvReply.Columns["PriorityID"].Visible = false;
                dgvReply.Columns["ContractID"].Visible = false;

                AddButton();
                Alignment();

                //loadNNDgv();
            }
            catch
            {
            }
        }

        private void Cal_Tong()
        {
            string tongYC = "";
            string agvRep = "";
            DataTable dt = (DataTable)(dgvReply.DataSource);
            if (dt == null || dt.Rows.Count == 0)
            {
                tongYC = "0";
                agvRep = "0";
            }
            else
            {
                tongYC = dt.Rows[0]["TONGYC"].ToString();
                agvRep = dt.Rows[0]["AGVReplyTime"].ToString();
            }

            string str = Program.GetNN(dtNN, "lblSoYC", this.Name) + " " + ": " + tongYC + "      " + Program.GetNN(dtNN, "lblTGianPHoi", this.Name) + " " + ": " + agvRep + " " + Program.GetNN(dtNN, "lblPhut", this.Name);
            lblSoYC.Text = str;
        }
        private void LoadNNCDinh()
        {
            this.Text = Program.GetNN(dtNN, this.Name, this.Name);
            lblTNgay.Text = Program.GetNN(dtNN, lblTNgay.Name, this.Name);
            lblDNgay.Text = Program.GetNN(dtNN, lblDNgay.Name, this.Name);
            btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);

            lblContract.Text = Program.GetNN(dtNN, lblContract.Name, this.Name);
            lblCustomer.Text = Program.GetNN(dtNN, lblCustomer.Name, this.Name);
            chkHoanThanh.Text = Program.GetNN(dtNN, chkHoanThanh.Name, this.Name);

            mnItemXemTheoCD.Text = Program.GetNN(dtNN, mnItemXemTheoCD.Name, this.Name);
            mnItemXemCT.Text = Program.GetNN(dtNN, mnItemXemCT.Name, this.Name);
            mnItemTroLai.Text = Program.GetNN(dtNN, mnItemTroLai.Name, this.Name);
        }
        private void loadNNDgv()
        {
            try
            {
                dgvReply.Columns["ShortName"].HeaderText = Program.GetNN(dtNN, "lblShortName", this.Name);
                dgvReply.Columns["RequestName"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblRequestName", this.Name);
                dgvReply.Columns["RequestContent"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblRequestContent", this.Name);
                dgvReply.Columns["RequesTime"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblRequesTime", this.Name);
                dgvReply.Columns["RequestUser"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblRequestUser", this.Name);
                dgvReply.Columns["SentTime"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblSentTime", this.Name);
                dgvReply.Columns["FullName"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblFullName", this.Name);
                dgvReply.Columns["ReplyContent"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblReplyContent", this.Name);
                dgvReply.Columns["ReplyTime"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblReplyTime", this.Name);
                dgvReply.Columns["RatingScore"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblRatingScore", this.Name);
                dgvReply.Columns["btnTiepTuc"].HeaderText = Program.GetNN(dtNN, "frmVSReply", "lblTiepTuc", this.Name);
            } catch{ }
        }
        private void Alignment()
        {
            this.dgvReply.Columns["ReplyTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvReply.Columns["RequesTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvReply.Columns["SentTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvReply.Columns["RequestName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReply.Columns["RequestContent"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReply.Columns["RequesTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReply.Columns["RequestUser"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReply.Columns["SentTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReply.Columns["FullName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReply.Columns["ReplyContent"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReply.Columns["ReplyTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReply.Columns["TONGYC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReply.Columns["AGVReplyTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReply.Columns["RatingScore"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReply.Columns["btnTiepTuc"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void LoadcboCustomer()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/getCustomer");
                cboCustomer.DataSource = dt;
                cboCustomer.DisplayMember = "ShortName";
                cboCustomer.ValueMember = "ID";
                cboCustomer.SelectedIndex = 0;
                cboCustomer.SelectedValue = -1;
            }
            catch { }
        }

        private void LoadcboContract()
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = API.getDataAPI(http + "Support/GetCustomerContract?CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "");
                cboContract.DataSource = dt1;
                cboContract.DisplayMember = "ContractNo";
                cboContract.ValueMember = "ID";

            }
            catch { }
        }
        #endregion
        #region chuotPhai
        private void dgvReply_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.dgvReply.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                    this.dgvReply.CurrentCell = this.dgvReply.Rows[e.RowIndex].Cells["ShortName"];
                    this.dgvReply.CurrentCell = this.dgvReply.Rows[e.RowIndex].Cells["RequestName"];
                    this.dgvReply.CurrentCell = this.dgvReply.Rows[e.RowIndex].Cells["RequestContent"];
                    this.dgvReply.CurrentCell = this.dgvReply.Rows[e.RowIndex].Cells["RequesTime"];
                    this.dgvReply.CurrentCell = this.dgvReply.Rows[e.RowIndex].Cells["RequestUser"];
                    this.dgvReply.CurrentCell = this.dgvReply.Rows[e.RowIndex].Cells["SentTime"];
                    this.dgvReply.CurrentCell = this.dgvReply.Rows[e.RowIndex].Cells["FullName"];
                    this.dgvReply.CurrentCell = this.dgvReply.Rows[e.RowIndex].Cells["ReplyContent"];
                    this.dgvReply.CurrentCell = this.dgvReply.Rows[e.RowIndex].Cells["ReplyTime"];

                    this.contextMenuStrip1.Show(this.dgvReply, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            catch
            { }

        }

        private void lblXemTheoCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // lay CHUOI_CHA
                iIDRq = Convert.ToInt64(this.dgvReply.Rows[rowIndex].Cells["ID"].Value);
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/GetCHUOI_CHA?iIDRq=" + iIDRq + "");
                if (dt == null || dt.Rows.Count == 0)
                {
                    CHUOI_CHA = "";
                }
                else
                {
                    CHUOI_CHA = dt.Rows[0][0].ToString();
                }

                DataTable dt1 = new DataTable();
                dt1 = API.getDataAPI(http + "Support/GetVSReplyDetail?CHUOI_CHA=" + CHUOI_CHA + "");
                if (!this.dgvReply.Rows[this.rowIndex].IsNewRow)
                {
                    if (dt1 == null || dt1.Rows.Count == 0)
                    {
                        return;
                    }
                    dgvReply.DataSource = dt1;
                }

                LoadgrdReply(dt1);
                flag = false;
            }
            catch
            { }
        }

        private void lblTroLaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LoadgrdReply(GetVSReplyAsync());
            DataTable dt_temp = new DataTable();
            dt_temp = API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + "");
            LoadgrdReply(dt_temp);
            flag = true;
            CHUOI_CHA = "";
        }
        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (flag == true)
            {
                contextMenuStrip1.Items["mnItemTroLai"].Visible = false;
                contextMenuStrip1.Items["mnItemXemCT"].Visible = true;
                contextMenuStrip1.Items["mnItemXemTheoCD"].Visible = true;
            }
            else
            {
                contextMenuStrip1.Items["mnItemTroLai"].Visible = true;
                contextMenuStrip1.Items["mnItemXemCT"].Visible = true;
                contextMenuStrip1.Items["mnItemXemTheoCD"].Visible = false;
            }
        }

        private void mnItemXemCT_Click(object sender, EventArgs e)
        {
            try
            {

                this.dgvReply.Rows[rowIndex].Selected = true;
                int sCustomerID = string.IsNullOrEmpty(dgvReply.Rows[rowIndex].Cells["CustomerID"].Value.ToString()) ? -1 : Convert.ToInt32(dgvReply.Rows[rowIndex].Cells["CustomerID"].Value);
                Int64 iIDTiepTuc = string.IsNullOrEmpty(dgvReply.Rows[rowIndex].Cells["PriorIDCtn"].Value.ToString()) ? -1 : Convert.ToInt32(dgvReply.Rows[rowIndex].Cells["PriorIDCtn"].Value);
                Int64 sContractID = string.IsNullOrEmpty(dgvReply.Rows[rowIndex].Cells["ContractID"].Value.ToString()) ? -1 : Convert.ToInt64(dgvReply.Rows[rowIndex].Cells["ContractID"].Value);
                Int64 iIDSRQ = string.IsNullOrEmpty(dgvReply.Rows[rowIndex].Cells["ID"].Value.ToString()) ? -1 : Convert.ToInt32(dgvReply.Rows[rowIndex].Cells["ID"].Value);

                frmSupport frmsp = new frmSupport(NNgu, UserName, FullName, TenCT, EMAIL, Phone, Zalo, sCustomerID, sContractID, sMailFrom, sMailPass, sMailSMTP, iMailPort);
                frmsp.iIDTT = iIDTiepTuc;
                frmsp.iIDSRQ = iIDSRQ;
                frmsp.Usernamesp = Program.UNameLogin;

                if (CustomerID != -1) // khách hàng xem chi tiết
                {
                    frmsp.TrangThaiF = 2;
                    frmsp.TTUpdate = 1; // khách hàng đánh giá
                }
                else // vietsoft trả lời
                {
                    frmsp.TrangThaiF = 3;
                    frmsp.TTUpdate = -1; // vietsoft trả lời
                }

                if (frmsp.ShowDialog() != DialogResult.OK) return;
                if (CHUOI_CHA == "")
                {
                    LoadgrdReply(API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + ""));
                    //LoadgrdReply(API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&CustomerID=" + CustomerID + ""));
                }
                else
                {
                    LoadgrdReply(API.getDataAPI(http + "Support/GetVSReplyDetail?CHUOI_CHA=" + CHUOI_CHA + ""));
                }
            }
            catch
            { }

        }
        #endregion

        private void dgvReply_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                this.dgvReply.Rows[rowIndex].Selected = true;
                int sCustomerID = string.IsNullOrEmpty(dgvReply.Rows[rowIndex].Cells["CustomerID"].Value.ToString()) ? -1 : Convert.ToInt32(dgvReply.Rows[rowIndex].Cells["CustomerID"].Value);
                Int64 iIDTiepTuc = string.IsNullOrEmpty(dgvReply.Rows[rowIndex].Cells["PriorIDCtn"].Value.ToString()) ? -1 : Convert.ToInt32(dgvReply.Rows[rowIndex].Cells["PriorIDCtn"].Value);
                Int64 sContractID = string.IsNullOrEmpty(dgvReply.Rows[rowIndex].Cells["ContractID"].Value.ToString()) ? -1 : Convert.ToInt64(dgvReply.Rows[rowIndex].Cells["ContractID"].Value);
                Int64 iIDSRQ = string.IsNullOrEmpty(dgvReply.Rows[rowIndex].Cells["ID"].Value.ToString()) ? -1 : Convert.ToInt32(dgvReply.Rows[rowIndex].Cells["ID"].Value);

                frmSupport frmsp = new frmSupport(NNgu, UserName, FullName, TenCT, EMAIL, Phone, Zalo, sCustomerID, sContractID, sMailFrom, sMailPass, sMailSMTP, iMailPort);
                frmsp.iIDTT = iIDTiepTuc;
                frmsp.iIDSRQ = iIDSRQ;
                frmsp.Usernamesp = Program.UNameLogin;

                if (CustomerID != -1) // khách hàng xem chi tiết
                {
                    frmsp.TrangThaiF = 2;
                    frmsp.TTUpdate = 1; // khách hàng đánh giá
                }
                else // vietsoft trả lời
                {
                    frmsp.TrangThaiF = 3;
                    frmsp.TTUpdate = -1; // vietsoft trả lời
                }

                if (frmsp.ShowDialog() != DialogResult.OK) return;
                if (CHUOI_CHA == "")
                {
                    LoadgrdReply(API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + ""));
                    //LoadgrdReply(API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&CustomerID=" + CustomerID + ""));
                }
                else
                {
                    LoadgrdReply(API.getDataAPI(http + "Support/GetVSReplyDetail?CHUOI_CHA=" + CHUOI_CHA + ""));
                }
            }
            catch
            { }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sLoad == "0Load") return;
            LoadcboContract();
            DataTable dttmp = new DataTable();
            dttmp = API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + "");
            LoadgrdReply(dttmp);
            sLoad = "";
        }

        private void cboContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (sLoad == "0Load") return;
                DataTable dt_temp = new DataTable();
                dt_temp = API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + "");
                LoadgrdReply(dt_temp);

                sLoad = "";
            }
            catch { }
        }

        private void chkHoanThanh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_temp = new DataTable();
                dt_temp = API.getDataAPI(http + "Support/GetVSReply?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&ContractID=" + Convert.ToInt64(cboContract.SelectedValue) + "&finished=" + Convert.ToInt32(chkHoanThanh.Checked) + "" + "&CustomerID=" + Convert.ToInt64(cboCustomer.SelectedValue) + "&VSStaffID=" + VSStaffID + "&VSSDept=" + VSSDept + "");
                LoadgrdReply(dt_temp);
            }
            catch { }
        }
    }
}
