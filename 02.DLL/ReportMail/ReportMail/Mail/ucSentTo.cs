using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Text.RegularExpressions;

namespace ReportMail.Mail
{
    public partial class ucSentTo : DevExpress.XtraEditors.XtraUserControl
    {

        //private Boolean _KiemGhi
        //{
        //    get
        //    { return KiemDL(int iID); }
        //    set
        //    {
        //       value = KiemDL(int iID);
        //    }
        //}

        public void MSetNew() 
        {
            try
            {
                txtName.Text = "";
                txtNgay.DateTime = DateTime.Now;
                chkHieuLuc.Checked = true;
                cboUsers.EditValue = "";
                cboUsers.Text = Commons.Modules.UserName;
                //cboUsers.EditValue = ((DataTable)cboUsers.Properties.DataSource).Rows[0]["USERNAME"].ToString();
                cboNNgu.EditValue = Commons.Modules.TypeLanguage;
                txtSubject.Text = "";
                txtTo.Text = "";
                txtCC.Text = "";
                txtBCC.Text = "";
                txtNDung.Text = "";
                txtSchedules.Text = "";
                txtName.Focus();
            }
            catch { }
        }

        public void MGetData(DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            try
            {
                txtName.Text = grv.GetFocusedDataRow()["MAIL_NAME"].ToString();
                txtNgay.DateTime = Convert.ToDateTime(grv.GetFocusedDataRow()["NGAY_TAO"].ToString());
                chkHieuLuc.Checked = Convert.ToBoolean(grv.GetFocusedDataRow()["HIEU_LUC"].ToString());
                cboUsers.EditValue = grv.GetFocusedDataRow()["USERNAME"].ToString();
                int iTmp = Convert.ToInt16(grv.GetFocusedDataRow()["NGON_NGU"].ToString());
                cboNNgu.EditValue = iTmp;
                txtSubject.Text = grv.GetFocusedDataRow()["TEN_BC"].ToString();
                txtTo.Text = grv.GetFocusedDataRow()["MAIL_TO"].ToString();
                txtCC.Text = grv.GetFocusedDataRow()["MAIL_CC"].ToString();
                txtBCC.Text = grv.GetFocusedDataRow()["MAIL_BCC"].ToString();
                txtNDung.Text = grv.GetFocusedDataRow()["ND_BC"].ToString();
                txtSchedules.Text = "";
            }
            catch { }
        }

        public string sName
        {
            get
            { return txtName.Text; }
            set
            {
                txtName.Text = value;
            }
        }

        public string sSubject        
        {
            get
            { return txtSubject.Text; }
            set
            { txtSubject.Text = value; }
        }

        public bool cHieuLuc
        {
            get
            {
                if (chkHieuLuc.Checked) return true; else return false;
            }
            set
            {chkHieuLuc.Checked = value;}
        }

        public string sUserName
        {
            get
            { 
                string sTmp = "";
                sTmp = (string.IsNullOrEmpty(cboUsers.Text) ? "" : cboUsers.EditValue.ToString());
                return sTmp; 
            
            }
            set
            { 
                cboUsers.EditValue = value;
            }
        }

        public string sMailTo
        {
            get
            { return txtTo.Text; }
            set
            { txtTo.Text = value; }
        }

        public string sMailCC
        {
            get
            { return txtCC.Text; }
            set
            { txtCC.Text = value; }
        }

        public string sMailBCC
        {
            get
            { return txtBCC.Text; }
            set
            { txtBCC.Text = value; }
        }

        public string sNDung
        {
            get
            { return txtNDung.Text; }
            set
            { txtNDung.Text = value; }
        }

        public int sNgonNgu
        {
            get
            {
                int sTmp = 0;
                sTmp = (string.IsNullOrEmpty(cboNNgu.Text) ? 0 : int.Parse(cboNNgu.EditValue.ToString()));
                return sTmp; 
            }
            set
            { cboNNgu.EditValue = value; }
        }

        public DateTime dNgayTao
        {
            get
            { return txtNgay.DateTime; }
            set
            { txtNgay.DateTime = value; }
        }

        public string sSchedules
        {
            get
            { return txtSchedules.Text; }
            set
            {
                txtSchedules.Text = value;
            }
        }

        public ucSentTo()
        {
            InitializeComponent();
        }

        private void ucSentTo_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetUSERS"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboUsers, dtTmp, "USERNAME", "FULL_NAME", "");
                cboUsers.EditValue = dtTmp.Rows[0]["USERNAME"].ToString();

                dtTmp = new DataTable();
                dtTmp.Columns.Add("VALUE", typeof(int));
                dtTmp.Columns.Add("DISLAY");
                dtTmp.Rows.Add(0, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSentTo", "TiengViet", Commons.Modules.TypeLanguage));
                dtTmp.Rows.Add(1, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSentTo", "TiengAnh", Commons.Modules.TypeLanguage));
                dtTmp.Rows.Add(2, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucSentTo", "TiengHoa", Commons.Modules.TypeLanguage));

                txtNgay.DateTime = DateTime.Now;

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNNgu, dtTmp, "VALUE", "DISLAY", lblNNgu.Text);
            }
            catch { }

        }

        public Boolean KiemDL(int iID)
        {
            try
            {
                string sLoi = "";
                if (txtName.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaNhapTen", Commons.Modules.TypeLanguage));
                    txtName.Focus();
                    return false;
                }
                if (txtNgay.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaNhapNgay", Commons.Modules.TypeLanguage));
                    txtNgay.Focus();
                    return false;
                }
                if (cboUsers.Text == "[EditValue is null]")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaNhapUser", Commons.Modules.TypeLanguage));
                    cboUsers.Focus();
                    return false;
                }
                if (cboNNgu.Text == "[EditValue is null]")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaNhapNgonNgu", Commons.Modules.TypeLanguage));
                    cboNNgu.Focus();
                    return false;
                }
                if (txtSubject.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaNhapSubject", Commons.Modules.TypeLanguage));
                    txtSubject.Focus();
                    return false;
                }
                if (txtTo.Text == "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "ChuaNhapMailTo", Commons.Modules.TypeLanguage));
                    txtTo.Focus();
                    return false;
                }
                else
                {
                    if (!isEmail(txtTo.Text, out sLoi))
                    {
                        XtraMessageBox.Show(sLoi + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "KhongPhaiMail", Commons.Modules.TypeLanguage));
                        txtTo.Focus();
                        return false;
                    }

                }

                if (txtCC.Text != "")
                {
                    if (!isEmail(txtCC.Text, out sLoi))
                    {
                        XtraMessageBox.Show(sLoi + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "KhongPhaiMail", Commons.Modules.TypeLanguage));
                        txtCC.Focus();
                        return false;
                    }
                }



                if (txtBCC.Text != "")
                {
                    if (!isEmail(txtBCC.Text, out sLoi))
                    {
                        XtraMessageBox.Show(sLoi + "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "KhongPhaiMail", Commons.Modules.TypeLanguage));
                        txtBCC.Focus();
                        return false;
                    }
                }

                string sSql;
                sSql = "SELECT * FROM DS_MAIL WHERE (ID_MAIL = 'ucMailBieuDoTGNMayTheoNXThang' ) " +
                        " AND (MAIL_NAME = N'" +  txtName.Text + "') AND (ID <> " + iID.ToString() + " OR -1 = " + iID.ToString() + ")";

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucSentTo", "TenBiTrung", Commons.Modules.TypeLanguage));
                    txtName.Focus();
                    return false;
                }
                
            }
            catch { return false; }
            
            return true;
        }

        public bool isEmail(string inputEmail, out string sLoi)
        {
            try
            {
                sLoi = "";
                string[] sMail = inputEmail.Split(new Char[] { ';' });

                inputEmail = inputEmail ?? string.Empty;
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);

                foreach (string s in sMail)
                {
                    if (s != "")
                        if (!re.IsMatch(s.Trim()))
                        {
                            sLoi = s.Trim();
                            return (false);
                        }
                }
                return true;
            }
            catch (Exception ex)
            {
                sLoi = ex.Message;
                return false; 
            }
        }

        public void LockUnLock(Boolean Locked)
        {
            try
            {
                txtName.Properties.ReadOnly = !Locked;
                txtNgay.Properties.ReadOnly = !Locked;
                chkHieuLuc.Enabled = Locked;
                cboUsers.Properties.ReadOnly = !Locked;
                cboNNgu.Properties.ReadOnly = !Locked;
                txtSubject.Properties.ReadOnly = !Locked;
                txtTo.Properties.ReadOnly = !Locked;
                txtCC.Properties.ReadOnly = !Locked;
                txtBCC.Properties.ReadOnly = !Locked;
                txtNDung.Properties.ReadOnly = !Locked;
            }
            catch { }
        }


    }
}
