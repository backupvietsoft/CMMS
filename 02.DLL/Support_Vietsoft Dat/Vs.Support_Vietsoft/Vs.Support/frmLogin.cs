using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Vs.Support.Commons;

namespace Vs.Support
{
    public partial class frmLogin : Form
    {
        public string http = Program.http;
        DataTable dtNN = new DataTable();
        public string UserName = "";
        string VSStaffName = "";

        public frmLogin()
        {
            InitializeComponent();
        }


        #region even
        private void btnDangNhap_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show(Program.GetNN(dtNN, "msgChuaNhapUserName", this.Name));
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show(Program.GetNN(dtNN, "msgChuaNhapPassWord", this.Name));
                txtPassword.Focus();
                return;
            }
            DangNhap();
        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void frmLogin_Load(object sender, System.EventArgs e)
        {
            dtNN = Program.GetDataNN(this.Name);
            LoadcboDataBase();
            LoadUserPass();
            LoadNN();
        }
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        #endregion

        #region function 
        private void LoadcboDataBase()
        {
            try
            {
                //cbo_database.Properties.datas
                DataTable dt = new DataTable();
                //getDatabase API
                dt = API.getDataAPI(http + "Support/getDatabase");
                cboDatabase.DataSource = dt;
                cboDatabase.DisplayMember = "name";
                cboDatabase.ValueMember = "name";
            }
            catch
            {

            }
        }
        private void DangNhap()
        {
            if (checkLogin())
            {
                SaveLogin();
                //  SaveDatabase();
                //this.Hide();
                //if (iChangUser == 0)
                //{

                Program.UNameLogin = txtUsername.Text;
                //frmMain frm = new frmMain();
                //frm.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
                //}
                //if (iUserName != txt_user.Text)
                //{
                //    this.DialogResult = DialogResult.OK;
                //    this.Close();
                //}
                // LoadThongTinChung();
            }


        }
        private bool checkLogin()
        {
            try
            {
                string sSql;
                //kiểm tra user đã có hay chưa

                DataTable dt = new DataTable();
                //CheckEmpty API
                dt = API.getDataAPI(http + "Support/CheckEmpty?username=" + txtUsername.Text.Trim() + "");


                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgTaiKhoanChuaDangKy", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                DataTable dt1 = new DataTable();
                dt1 = API.getDataAPI(http + "Support/CheckPassword?username=" + txtUsername.Text.Trim() + "");
                //kiểm tra mật khẩu có đúng hay không
                if (Program.Decrypt(dt1.Rows[0][0].ToString(), true).ToString() != txtPassword.Text.ToString().Trim())
                {

                    MessageBox.Show(Program.GetNN(dtNN, "msgsaiPassword", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                DataTable dt2 = new DataTable();
                dt2 = API.getDataAPI(http + "Support/CheckInactive?username=" + txtUsername.Text.Trim() + "");
                //kiểm tra tài khoảng có được active hay chưa
                if (!(string.IsNullOrEmpty(dt2.Rows[0][0].ToString()) ? false : Convert.ToBoolean(dt2.Rows[0][0])))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgTaiKhoanChuaKichHoat", this.Name), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                Program.VietStaffID = Convert.ToInt32(dt.Rows[0][0].ToString());
                VSStaffName = dt.Rows[0][1].ToString();
                Program.VSSDept = Convert.ToInt32(dt.Rows[0][2].ToString());
                return true;
            }
            catch (Exception ex)
            {
                VSStaffName = "";
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void SaveLogin()
        {
            //if (chk_pass.Checked == false && chk_user.Checked == false) return;
            string user;
            string pass;
            if (chkReUser.Checked)
            {
                user = txtUsername.Text.ToString();
            }
            else
            {
                user = "";
            }
            if (chkRePassword.Checked)
            {
                //pass =  Encrypt (txtPassword.Text.ToString(),true);
                pass = txtPassword.Text.ToString();
            }
            else
            {
                pass = "";
            }
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                if (!File.Exists(path + "\\savelogin.xml"))
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    path = path + "\\savelogin.xml";
                    //System.IO.StreamWriter streamWriter = new StreamWriter(path);
                    XmlWriter xml = XmlWriter.Create(path);
                    xml.WriteStartElement("Import");
                    xml.WriteStartElement("Row");
                    xml.WriteElementString("U", user);
                    xml.WriteElementString("P", pass);
                    // xml.WriteElementString("D", cboDatabase.Text.Trim());
                    xml.WriteElementString("N", "0");
                    xml.WriteEndElement();
                    xml.WriteEndElement();
                    xml.Flush();
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");
                    ds.Tables[0].Rows[0]["U"] = user;
                    ds.Tables[0].Rows[0]["P"] = pass;
                    //  ds.Tables[0].Rows[0]["D"] = cboDatabase.Text.Trim();

                    ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UserName = txtUsername.Text;
            Program.Database = cboDatabase.Text.Trim();
        }

        private void LoadUserPass()
        {
            try
            {
                string user, pass;
                string data;
                DataSet ds = new DataSet();
                ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");
                user = ds.Tables[0].Rows[0]["U"].ToString();
                pass = ds.Tables[0].Rows[0]["P"].ToString();
                //   data = ds.Tables[0].Rows[0]["D"].ToString();
                //try
                //{
                //    Commons.Mod.TypeLanguage = Convert.ToInt16(ds.Tables[0].Rows[0]["N"].ToString());
                //}
                //catch { }
                if (!string.IsNullOrEmpty(user))
                {
                    chkReUser.Checked = true;
                    txtUsername.Text = user;

                }
                else
                {
                    chkReUser.Checked = false;
                }
                if (!string.IsNullOrEmpty(pass))
                {
                    chkRePassword.Checked = true;
                    txtPassword.Text = pass;
                }
                else
                {
                    chkRePassword.Checked = false;
                }

                //try
                //{
                //    cboDatabase.SelectedValue = data;
                //}
                //catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadNN()
        {
            this.Text = Program.GetNN(dtNN, "", this.Name, this.Name);
            lblLogin.Text = Program.GetNN(dtNN, "", lblLogin.Name, this.Name);
            lblDatabase.Text = Program.GetNN(dtNN, "", lblDatabase.Name, this.Name);
            lblUserName.Text = Program.GetNN(dtNN, "", lblUserName.Name, this.Name);
            lblPassWord.Text = Program.GetNN(dtNN, "", lblPassWord.Name, this.Name);
            chkReUser.Text = Program.GetNN(dtNN, "", chkReUser.Name, this.Name);
            chkRePassword.Text = Program.GetNN(dtNN, "", chkRePassword.Name, this.Name);
            btnDangNhap.Text = Program.GetNN(dtNN, "", btnDangNhap.Name, this.Name);
            btnThoat.Text = Program.GetNN(dtNN, "", btnThoat.Name, this.Name);
        }
        #endregion

    }
}
