using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Vs.Support.Commons;
using Vs.Support.Model;

namespace Vs.Support
{
    public partial class frmThemNguoiDung : Form
    {
        
        public string fullname = "";
        string http = Program.http;
        int iID = -1;
        DataTable dtNN = new DataTable();
        public frmThemNguoiDung()
        {
            InitializeComponent();
        }
        #region even
        private void frmThemNguoiDung_Load(object sender, System.EventArgs e)
        {
            dtNN = Program.GetDataNN(this.Name);
            Button button = new Button();
            button.Dock = DockStyle.Right;
            button.BackColor = SystemColors.Control;
            button.Size = new Size(45, txtFullName.ClientSize.Height);
            button.Text = "...";
            button.TextAlign = ContentAlignment.TopCenter;
            button.Click += button_Click;
            txtFullName.Controls.Add(button);

            loadcboVSDeptID();

            LoadNN();
        }

        private void button_Click(object sender, EventArgs e)
        {
            frmViewVStaff frm = new frmViewVStaff();
            frm.iID = -1;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                iID = Program.iID;
                LoadData();
            }
        }
        private void btnGhi_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaNhapTen", this.Name));
                    txtFullName.Focus();
                    return;
                }
                //Kiem trung Username
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/kiemTrungUName?Uname=" + txtUserName.Text + "&iID= " + iID + " ");
                if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                {
                    MessageBox.Show(lblUserName.Text + " " + Program.GetNN(dtNN, "msgDaTonTai", this.Name));
                    txtUserName.Focus();
                    return;
                }
                VietsoftStaff VSS = new VietsoftStaff();
                VSS.ID = iID;
                VSS.FullName = txtFullName.Text;
                VSS.ShortName = string.IsNullOrEmpty(txtShortName.Text) ? null : txtShortName.Text;
                VSS.Email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text;
                VSS.Phone = string.IsNullOrEmpty(txtPhone.Text) ? null : txtPhone.Text;
                VSS.Zalo = string.IsNullOrEmpty(txtZalo.Text) ? null : txtZalo.Text;
                if (cboVSDeptID.SelectedIndex == 0)
                {
                    VSS.VSDeptID = null;

                }
                else
                {
                    Convert.ToInt32(cboVSDeptID.SelectedValue);
                }
                VSS.UserName = string.IsNullOrEmpty(txtUserName.Text) ? null : txtUserName.Text;
                if (txtUserName.Text != "" && txtPassword.Text == "")
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaNhapPassword", this.Name));
                    return;
                }
                VSS.Password = string.IsNullOrEmpty(txtPassword.Text) ? null : Program.Encrypt(txtPassword.Text, true);
                VSS.InActive = chkInActive.Checked;
                VSS.MainService = chkMainService.Checked;
                API.postWebApi(VSS, new Uri(http + "Support/PostVietsoftStaff"));
                if (MessageBox.Show(Program.GetNN(dtNN, "msgGhiThanhCong", this.Name), Program.GetNN(dtNN, "msgThongBao", this.Name), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    LoadTextNull();
                    txtFullName.Focus();
                    return;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    this.Close();
                }
            }
            catch { }
        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region function
        private void loadcboVSDeptID()
        {
            try
            {
                cboVSDeptID.DataSource = API.getDataAPI(http + "Support/getVietsoftDept");
                cboVSDeptID.DisplayMember = "Name";
                cboVSDeptID.ValueMember = "ID";
            }
            catch { }
        }
        private void LoadTextNull()
        {
            txtFullName.Text = string.Empty;
            txtShortName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtZalo.Text = string.Empty;
            cboVSDeptID.SelectedIndex = 0;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            chkInActive.Checked = false;
            chkMainService.Checked = false;

        }
        private void LoadData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/getViewVietSoftStaff?iID=" + iID + "");
                try { txtFullName.Text = dt.Rows[0]["FullName"].ToString(); } catch { }
                try { txtShortName.Text = dt.Rows[0]["ShortName"].ToString(); } catch { }
                try { txtEmail.Text = dt.Rows[0]["Email"].ToString(); } catch { }
                try { txtPhone.Text = dt.Rows[0]["Phone"].ToString(); } catch { }
                try { txtZalo.Text = dt.Rows[0]["Zalo"].ToString(); } catch { }
                try { cboVSDeptID.SelectedValue = dt.Rows[0]["VietsoftDeptID"].ToString(); } catch { }
                try { txtUserName.Text = dt.Rows[0]["UserName"].ToString(); } catch { }
                try { txtPassword.Text = Program.Decrypt(dt.Rows[0]["Password"].ToString(), true); } catch { }
                try { chkInActive.Checked = string.IsNullOrEmpty(dt.Rows[0]["InActive"].ToString()) ? false : Convert.ToBoolean(dt.Rows[0]["InActive"]); } catch { }
                try { chkMainService.Checked = string.IsNullOrEmpty(dt.Rows[0]["MaintService"].ToString()) ? false : Convert.ToBoolean(dt.Rows[0]["MaintService"]); } catch { }
            }
            catch
            { }
        }
        private void LoadNN()
        {
            this.Text = Program.GetNN(dtNN, this.Name, this.Name);
            lblFullName.Text = Program.GetNN(dtNN, lblFullName.Name, this.Name);
            lblShortName.Text = Program.GetNN(dtNN, lblShortName.Name, this.Name);
            lblEmail.Text = Program.GetNN(dtNN, lblEmail.Name, this.Name);
            lblPhone.Text = Program.GetNN(dtNN, lblPhone.Name, this.Name);
            lblZalo.Text = Program.GetNN(dtNN, lblZalo.Name, this.Name);
            lblVSDeptID.Text = Program.GetNN(dtNN, lblVSDeptID.Name, this.Name);
            lblUserName.Text = Program.GetNN(dtNN, lblUserName.Name, this.Name);
            lblPassword.Text = Program.GetNN(dtNN, lblPassword.Name, this.Name);
            chkInActive.Text = Program.GetNN(dtNN, chkInActive.Name, this.Name);
            chkMainService.Text = Program.GetNN(dtNN, chkMainService.Name, this.Name);
            btnGhi.Text = Program.GetNN(dtNN, btnGhi.Name, this.Name);
            btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);
        }
        #endregion
    }
}
