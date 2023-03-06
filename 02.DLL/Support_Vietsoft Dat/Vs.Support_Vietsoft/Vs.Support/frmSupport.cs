using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Vs.Support.Commons;
using Vs.Support.Model;

namespace Vs.Support
{
    public partial class frmSupport : Form
    {
        public string http = Program.http;

        public int TrangThaiF = 1; // 1: Tao moi, 2: Xem chi tiet, 3: VietSoft tra loi
        public Int64 iIDSRQ = -1;
        int NNgu = 0;

        public string Usernamesp = ""; // lay tu form VSReply

        public int TTUpdate = 1; // 1: Khach hang update Rating Score, -1 Vietsoft tra loi
        int IDVSStaff = -1;


        Int64 CustomerID = -1;
        Int64 ContractID = -1;

        string ContractNo = "";
        public Int64 iIDTT = -1;

        public string sSubject = Program.Subject;
        public string sBody = Program.Body;

        DataTable dtNN = new DataTable();

        System.Globalization.CultureInfo cultures = new System.Globalization.CultureInfo("en-US");
        public frmSupport(int NgonNgu, string UserName, string FullName, string sTEN_CT, string sEMAIL, string sPhone, string sZalo, Int64 iCustomerID, Int64 iContractID, string MailForm, string MailPass, string MailSMTP, int MailPort)
        {

            InitializeComponent();
            NNgu = NgonNgu;
            txtUSER_NAME.Text = UserName;
            txtFULL_NAME.Text = FullName;


            lblTEN_CT.Text = sTEN_CT;
            txtEMAIL.Text = sEMAIL;
            txtPhone.Text = sPhone;
            txtZalo.Text = sZalo;
            CustomerID = iCustomerID;
            ContractID = iContractID;

            SentMail.MailFrom = MailForm;
            SentMail.MailPass = MailPass;
            SentMail.MailSMTP = MailSMTP;
            SentMail.MailPort = MailPort;
        }
        #region even
        private void frmSupport_Load(object sender, EventArgs e)
        {
            dtNN = Program.GetDataNN(this.Name);
            loadCbo();
            TrangThaiForm();
            Button button = new Button();
            button.Dock = DockStyle.Right;
            button.BackColor = SystemColors.Control;
            button.Size = new Size(60, txtDUONG_DAN_TL.ClientSize.Height + 2);
            button.Text = "...";
            button.TextAlign = ContentAlignment.TopCenter;
            button.Click += button_Click;
            txtDUONG_DAN_TL.Controls.Add(button);
            LoadNN();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (TrangThaiF == 1)
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.SafeFileName;
                        txtDUONG_DAN_TL.Text = filePath;
                    }
                }
            }
            else
                return;
        }

        private void btnGui_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRequestName.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaNhapRequestName", this.Name));
                    txtRequestName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaNhapDescription", this.Name));
                    txtDescription.Focus();
                    return;
                }
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/EmptyContractID?ContractID=" + ContractID + "");
                if (dt.Rows.Count == 0 || dt == null)
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgContractKhongTonTai", this.Name));
                    return;
                }
                Data_Support dtsp = new Data_Support();
                dtsp.iIDSRQ = iIDSRQ;
                dtsp.TTUpdate = TTUpdate;
                dtsp.CustomerID = CustomerID;
                dtsp.ContractID = ContractID;
                dtsp.tenCTY = lblTEN_CT.Text;
                dtsp.UName = txtUSER_NAME.Text;
                dtsp.FullName = txtFULL_NAME.Text;
                dtsp.mail = txtEMAIL.Text;
                dtsp.phone = txtPhone.Text;
                dtsp.zalo = txtZalo.Text;
                dtsp.rqName = txtRequestName.Text;
                dtsp.rqTypeID = Convert.ToInt32(cboID_RequestType.SelectedValue);
                dtsp.rqPrioID = Convert.ToInt32(cboID_Priority.SelectedValue);
                dtsp.duongDan = txtDUONG_DAN_TL.Text;
                dtsp.Link_TL = txtLINK_TL.Text;
                dtsp.description = txtDescription.Text;
                dtsp.RequestContent = txtRequestcontent.Text;
                if (cboYEU_CAU.SelectedValue == null)
                    dtsp.PriorIDCnt = null;
                else
                    dtsp.PriorIDCnt = Convert.ToInt64(cboYEU_CAU.SelectedValue);
                dtsp.rqNamecnt = cboYEU_CAU.Text;

                if (TrangThaiF == 3)
                {
                    if (string.IsNullOrEmpty(txtReplyContent.Text.Trim()))
                    {
                        MessageBox.Show(Program.GetNN(dtNN, "msgChuaNhapNDTraLoi", this.Name));
                        txtReplyContent.Focus();
                        return;
                    }
                    try { dtsp.sentTime = DateTime.ParseExact(txtSentTime.Text, "dd/MM/yyyy HH:mm:ss", cultures); } catch(Exception ex) { }
                    dtsp.VSStaffID = IDVSStaff;
                    dtsp.VSStaffName = txtVietsoftStaffName.Text;
                    dtsp.RelContent = txtReplyContent.Text;
                    dtsp.Finish = Convert.ToBoolean(chkFinished.Checked);
                }
                if (TrangThaiF == 2)
                {
                    if (string.IsNullOrEmpty(cboRatingID.Text.Trim()))
                    {
                        MessageBox.Show(Program.GetNN(dtNN, "msgVuiLongChonDanhGia", this.Name));
                        return;
                    }
                    dtsp.Finish = Convert.ToBoolean(chkFinished.Checked);
                    dtsp.Rating = Convert.ToInt32(cboRatingID.SelectedValue);
                }

                API.postWebApi(dtsp, new Uri(http + "Support/PostData_Support/"));

                if (TrangThaiF == 1)
                {

                    try
                    {
                        // Select Email cua Staff dang ho tro Contract nay`
                        DataTable dt1 = new DataTable();
                        string chuoi = "";
                        dt1 = API.getDataAPI(http + "Support/GetContractVSStaff?ContractID=" + ContractID + "");
                        if (dt1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                chuoi += dt1.Rows[i][0].ToString() + ";";
                            }
                            string mailto = chuoi.Remove(chuoi.Length - 1).Replace("\r\n", string.Empty);
                            SentMail.ShortName = lblTEN_CT.Text;

                            string sBody = " <b>Mô tả: </b> "+txtDescription.Text+" <br/> <b> Nội dung yêu cầu: </b>"+txtRequestcontent.Text+"";
                            SentMail.SendMail(mailto, txtRequestName.Text, sBody);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Program.GetNN(dtNN, "msg_Guimailkhongthanhcong", this.Name) + ex.Message.ToString());
                    }
                    if (MessageBox.Show(Program.GetNN(dtNN, "msgChanThanhCamOn", this.Name), Program.GetNN(dtNN, "msgThongBao", this.Name), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        LoadTextNull();
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                }
                if (TrangThaiF == 2)
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgCamOnDanhGia", this.Name));
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (TrangThaiF == 3)
                {
                    SentMail.MailFrom = Program.MailFrom_VS;
                    SentMail.MailPass = Program.MailPass_VS;
                    SentMail.MailSMTP = Program.MailSMTP_VS;
                    SentMail.MailPort = Program.MailPort_VS;

                    DataTable dt2 = new DataTable();
                    dt2 = API.getDataAPI(http + "Support/getEmailCustomer?CustomerID=" + CustomerID + "");
                    string mailto = dt2.Rows[0][0].ToString() + ";" + txtEMAIL.Text;
                    SentMail.ShortName = "VietSoft";
                    SentMail.SendMail(mailto, sSubject, sBody);

                    MessageBox.Show(Program.GetNN(dtNN, "msgTraLoiThanhCong", this.Name));
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Program.GetNN(dtNN, "msgGoiDuLieuKhongThanhCong", this.Name));
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtZalo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        #region function
        private void loadCbo()
        {
            try
            {

                cboID_RequestType.DataSource = API.getDataAPI(http + "Support/GetRequestType?iNNgu=" + NNgu + "");
                cboID_RequestType.DisplayMember = "NAME";
                cboID_RequestType.ValueMember = "ID";


                cboID_Priority.DataSource = API.getDataAPI(http + "Support/GetPriority?iNNgu=" + NNgu + "");
                cboID_Priority.DisplayMember = "NAME";
                cboID_Priority.ValueMember = "ID";
                cboID_Priority.SelectedIndex = 0;

                cboYEU_CAU.DataSource = API.getDataAPI(http + "Support/GetServiceRequest?CustomerID=" + CustomerID + ""); ;
                cboYEU_CAU.DisplayMember = "RequestName";
                cboYEU_CAU.ValueMember = "ID";
                if (iIDTT == -1)
                {
                    cboYEU_CAU.Text = "";
                }
                cboYEU_CAU.SelectedValue = iIDTT;
            }
            catch
            {

            }
        }

        private void LoadTextNull()
        {

            txtRequestName.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtDUONG_DAN_TL.Text = String.Empty;
            txtLINK_TL.Text = String.Empty;
            txtReplyContent.Text = String.Empty;
            txtRequestcontent.Text = String.Empty;
            chkFinished.CheckState = CheckState.Unchecked;


            cboYEU_CAU.DataSource = API.getDataAPI(http + "Support/GetServiceRequest?CustomerID=" + CustomerID + "");
            //cboYEU_CAU.Text = txtRequestName.Text; // focus newrow
            cboYEU_CAU.SelectedValue = -1;
        }

        // trang thai form
        private void TrangThaiForm()
        {

            if (TrangThaiF == 1) // form khách hàng tạo mới phiếu
            {
                if (iIDTT != -1)
                {
                    cboYEU_CAU.Enabled = false;
                }
                tableLayoutPanel1.RowStyles[13].Height = 0;
                tableLayoutPanel1.RowStyles[14].Height = 0;
                tableLayoutPanel1.RowStyles[15].Height = 0;
                lblRequestTime.Visible = false;
                txtRequestTime.Visible = false;
                lblSentTime.Visible = false;
                txtSentTime.Visible = false;
                lblVietsoftStaffName.Visible = false;
                txtVietsoftStaffName.Visible = false;
                lblReplyContent.Visible = false;
                txtReplyContent.Visible = false;
                chkFinished.Visible = false;
                chkFinished.Visible = false;
                lblRatingID.Visible = false;
                cboRatingID.Visible = false;
            }

            // form khách hàng xem chi tiết
            if (TrangThaiF == 2)
            {
                LoadcboRating();
                LoadViewDetail();
                tableLayoutPanel1.RowStyles[0].Height = 0;
                tableLayoutPanel1.RowStyles[1].Height = 0;
                tableLayoutPanel1.RowStyles[2].Height = 0;

                lblTIEU_DE.Visible = false;
                txtEMAIL.ReadOnly = true;
                txtPhone.ReadOnly = true;
                txtZalo.ReadOnly = true;
                txtRequestName.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtRequestcontent.ReadOnly = true;
                txtDUONG_DAN_TL.ReadOnly = true;
                txtLINK_TL.ReadOnly = true;
                cboYEU_CAU.Enabled = false;
                cboID_RequestType.Enabled = false;
                cboID_Priority.Enabled = false;
                txtRequestTime.ReadOnly = true;


                txtSentTime.ReadOnly = true;
                txtVietsoftStaffName.ReadOnly = true;
                txtReplyContent.ReadOnly = true;
                chkFinished.Enabled = true;
                cboRatingID.Enabled = true;
            }

            if (TrangThaiF == 3) //vietsoft tra loi
            {
                LoadcboRating();
                LoadViewDetail();
                try
                {
                    DataTable dt = new DataTable();
                    dt = API.getDataAPI(http + "Support/getVietStaff?username=" + Usernamesp + "");
                    if (string.IsNullOrEmpty(txtVietsoftStaffName.Text))
                    {
                        txtVietsoftStaffName.Text = dt.Rows[0]["FullName"].ToString();
                    }
                    IDVSStaff = Convert.ToInt32(dt.Rows[0]["ID"]);
                    txtVietsoftStaffName.ReadOnly = false;
                }
                catch
                { }
                txtSentTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                tableLayoutPanel1.RowStyles[0].Height = 0;
                tableLayoutPanel1.RowStyles[1].Height = 0;
                tableLayoutPanel1.RowStyles[2].Height = 0;

                lblTIEU_DE.Visible = false;
                txtEMAIL.ReadOnly = true;
                txtPhone.ReadOnly = true;
                txtZalo.ReadOnly = true;
                txtRequestName.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtRequestcontent.ReadOnly = true;


                txtDUONG_DAN_TL.ReadOnly = true;
                txtLINK_TL.ReadOnly = true;
                cboYEU_CAU.Enabled = false;
                cboID_RequestType.Enabled = false;
                cboID_Priority.Enabled = false;
                txtRequestTime.ReadOnly = true;

                txtSentTime.ReadOnly = true;
                txtReplyContent.ReadOnly = false;
                chkFinished.Enabled = true;
                cboRatingID.Enabled = false;
            }
        }

        private void LoadViewDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/GetViewDetail?iIDSRQ=" + iIDSRQ + "");

                txtUSER_NAME.Text = dt.Rows[0]["RequestUser"].ToString();
                txtFULL_NAME.Text = dt.Rows[0]["RequestFullName"].ToString();
                txtEMAIL.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtZalo.Text = dt.Rows[0]["Zalo"].ToString();
                txtRequestName.Text = dt.Rows[0]["RequestName"].ToString();
                cboID_RequestType.SelectedValue = dt.Rows[0]["RequestTypeID"].ToString();
                cboID_Priority.SelectedValue = dt.Rows[0]["PriorityID"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                txtRequestcontent.Text = dt.Rows[0]["RequestContent"].ToString();
                txtDUONG_DAN_TL.Text = dt.Rows[0]["FlieLink_1"].ToString();
                txtLINK_TL.Text = dt.Rows[0]["FileLink_2"].ToString();
                cboYEU_CAU.SelectedValue = iIDTT;
                txtRequestTime.Text = dt.Rows[0]["RequesTime"].ToString();
                txtSentTime.Text = dt.Rows[0]["SentTime"].ToString();
                txtVietsoftStaffName.Text = dt.Rows[0]["FullName"].ToString();
                txtReplyContent.Text = dt.Rows[0]["ReplyContent"].ToString();
                try { chkFinished.Checked = string.IsNullOrEmpty(dt.Rows[0]["Finished"].ToString()) ? false : Convert.ToBoolean(dt.Rows[0]["Finished"]); } catch { };
                if(TrangThaiF == 3)
                {
                    cboRatingID.SelectedValue = string.IsNullOrEmpty(dt.Rows[0]["RatingID"].ToString()) ? -1 : (Convert.ToInt32(dt.Rows[0]["RatingID"]));
                }
                else
                {
                    cboRatingID.SelectedValue = string.IsNullOrEmpty(dt.Rows[0]["RatingID"].ToString()) ? 1 : (Convert.ToInt32(dt.Rows[0]["RatingID"]));
                }
            }
            catch
            { }
        }

        private void LoadcboRating()
        {
            try
            {
                btnGui.Visible = true;
                cboRatingID.DataSource = API.getDataAPI(http + "Support/GetRating");
                cboRatingID.DisplayMember = "RatingScore";
                cboRatingID.ValueMember = "ID";
                cboRatingID.SelectedIndex = 1;
            }
            catch
            { }
        }

        private void LoadNN()
        {
            lblTIEU_DE.Text = Program.GetNN(dtNN, lblTIEU_DE.Name, this.Name);
            lblDescription.Text = Program.GetNN(dtNN, lblDescription.Name, this.Name);
            lblRequestContent.Text = Program.GetNN(dtNN, lblRequestContent.Name, this.Name);
            lblDUONG_DAN_TL.Text = Program.GetNN(dtNN, lblDUONG_DAN_TL.Name, this.Name);
            lblLINK_TL.Text = Program.GetNN(dtNN, lblLINK_TL.Name, this.Name);
            lblEMAIL.Text = Program.GetNN(dtNN, lblEMAIL.Name, this.Name);
            lblFULL_NAME.Text = Program.GetNN(dtNN, lblFULL_NAME.Name, this.Name);
            lblID_Priority.Text = Program.GetNN(dtNN, lblID_Priority.Name, this.Name);
            lblID_RequestType.Text = Program.GetNN(dtNN, lblID_RequestType.Name, this.Name);
            lblPhone.Text = Program.GetNN(dtNN, lblPhone.Name, this.Name);
            lblRequestName.Text = Program.GetNN(dtNN, lblRequestName.Name, this.Name);
            lblUSER_NAME.Text = Program.GetNN(dtNN, lblUSER_NAME.Name, this.Name);
            lblYEU_CAU_TT.Text = Program.GetNN(dtNN, lblYEU_CAU_TT.Name, this.Name);
            lblZalo.Text = Program.GetNN(dtNN, lblZalo.Name, this.Name);

            lblRequestTime.Text = Program.GetNN(dtNN, lblRequestTime.Name, this.Name);
            lblSentTime.Text = Program.GetNN(dtNN, lblSentTime.Name, this.Name);
            lblVietsoftStaffName.Text = Program.GetNN(dtNN, lblVietsoftStaffName.Name, this.Name);
            lblReplyContent.Text = Program.GetNN(dtNN, lblReplyContent.Name, this.Name);
            chkFinished.Text = Program.GetNN(dtNN, chkFinished.Name, this.Name);
            lblRatingID.Text = Program.GetNN(dtNN, lblRatingID.Name, this.Name);


            btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);
            btnGui.Text = Program.GetNN(dtNN, btnGui.Name, this.Name);

        }

        #endregion

       
    }
}
