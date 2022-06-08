using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace Vietsoft
{

    public class MInputBox
    {
        private XtraForm frmInput = new XtraForm();
        private DevExpress.XtraEditors.SimpleButton btnOK = new DevExpress.XtraEditors.SimpleButton();
        private DevExpress.XtraEditors.TextEdit txtText = new DevExpress.XtraEditors.TextEdit();
        private DevExpress.XtraEditors.LabelControl lblPrompt = new DevExpress.XtraEditors.LabelControl();
        private DevExpress.XtraEditors.SimpleButton btnCancel = new DevExpress.XtraEditors.SimpleButton();
        private string _sText;
        public string sText
        {
            get
            {
                return _sText;
            }
            set
            {
                _sText = value;
            }
        }

        private  void InitializeComponent()
        {
            frmInput.Controls.Clear();
            txtText = new DevExpress.XtraEditors.TextEdit();
            btnOK = new DevExpress.XtraEditors.SimpleButton();
            lblPrompt = new DevExpress.XtraEditors.LabelControl();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)txtText.Properties).BeginInit();
            frmInput.SuspendLayout();
            //
            //txtText
            //
            txtText.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
            txtText.Location = new System.Drawing.Point(12, 31);
            txtText.Text = sText;
            txtText.Name = "txtText";
            txtText.Size = new System.Drawing.Size(375, 20);
            txtText.TabIndex = 0;
            //
            //btnOK
            //
            btnOK.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(231, 57);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "&OK";

            btnOK.Click += btnOK_Click;
            //
            //lblPrompt
            //
            lblPrompt.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            lblPrompt.Location = new System.Drawing.Point(12, 12);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new System.Drawing.Size(42, 13);
            lblPrompt.TabIndex = 2;
            lblPrompt.Text = "prompt";
            //
            //btnCancel
            //
            btnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(312, 57);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "&Cancel";
            //
            //XtraInputBox
            //
            frmInput.AcceptButton = btnOK;
            frmInput.CancelButton = btnCancel;
            frmInput.ClientSize = new System.Drawing.Size(399, 91);
            frmInput.Controls.Add(lblPrompt);
            frmInput.Controls.Add(btnCancel);
            frmInput.Controls.Add(btnOK);
            frmInput.Controls.Add(txtText);
            frmInput.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            frmInput.HelpButton = false;
            frmInput.MaximizeBox = false;
            frmInput.MinimizeBox = false;
            frmInput.Name = "XtraInputBox";
            frmInput.ShowInTaskbar = false;
            frmInput.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)txtText.Properties).EndInit();
            frmInput.ResumeLayout(false);
            frmInput.PerformLayout();
        }

        public MInputBox()
        {
            InitializeComponent();
            btnOK.Click += new System.EventHandler(btnOK_Click);
        }

        private  void btnOK_Click(object sender, System.EventArgs e)
        {
            frmInput.Close();
        }

        public  string Show(string Prompt)
        {
            return Show(Prompt, Application.ProductName).ToString();
        }

        public  object Show(string Prompt, string Title)
        {
            return Show(Prompt, Title, "");
        }

        public  object Show(string Prompt, string Title, string DefaultResponse)
        {
            return Show(Prompt, Title, DefaultResponse, -1);
        }

        public  object Show(string Prompt, string Title, string DefaulResponse, int XPos)
        {
            return Show(Prompt, Title, DefaulResponse, XPos, -1);
        }

        public  string Show(string Prompt, string Title, string DefaultResponse, int XPos, int YPos)
        {
            //(Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2)
            //(Screen.PrimaryScreen.WorkingArea.Height / 2) - (Me.Height / 2)

            InitializeComponent();
            lblPrompt.Text = Prompt;
            frmInput.Text = Title;
            frmInput.Top = XPos;
            frmInput.Left = YPos;
            DialogResult res = frmInput.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                return txtText.Text;
            }
            else
            {
                return DefaultResponse;
            }
        }


    }

    public class MCapNhapNgonNguAnhHoa
    {
        private static string _sNNgu = String.Empty;

        public static string sNNgu
        {
            get
            {
                return _sNNgu;
            }
            set
            {
                _sNNgu = value;
            }
        }
        public static Boolean Update(string MInputBox, string sTable, string sField, string sID, out string sLoi)
        {
            sLoi = "";
            
            try
            {
                string sSql ;
                sSql = "SELECT ISNULL(" + sField + ",'') FROM " + sTable + " "  + sID;
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, System.Data.CommandType.Text, sSql));
                Vietsoft.MInputBox a = new Vietsoft.MInputBox();
                a.sText = sSql;
                _sNNgu = a.Show(MInputBox);
                if (_sNNgu == "")
                {
                    sLoi = "Cancel";
                    return true;
                }
                SqlHelper.ExecuteNonQuery(Vietsoft.Information.ConnectionString, System.Data.CommandType.Text, "UPDATE " + sTable + " SET " + sField + " = N'" + _sNNgu + "' " + sID);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = ex.Message.ToString();
                return false;
            }
            return true;
        }

        public static Boolean Update(string MInputBox, string sTable, string sField, string sID, out string sLoi,string sform )
        {
            string sQuyen = "Full access";
            sLoi = "";
            try
            {
                sQuyen = Convert.ToString(SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, "GetNHOM_FORM_QUYEN", Vietsoft.Information.UserID, sform));
                if (sQuyen.ToUpper() != "Full access".ToUpper())
                {
                    sLoi = "NotPermission";
                    return false;
                }
            }
            catch { sQuyen = "Full access"; }
            try
            {
                string sSql;
                sSql = "SELECT ISNULL(" + sField + ",'') FROM " + sTable + " " + sID;
                sSql = Convert.ToString(SqlHelper.ExecuteScalar(Vietsoft.Information.ConnectionString, System.Data.CommandType.Text, sSql));
                Vietsoft.MInputBox a = new Vietsoft.MInputBox();
                a.sText = sSql;
                _sNNgu = a.Show(MInputBox);

                if (_sNNgu == "")
                {
                    sLoi = "Cancel";
                    return true;
                }
                SqlHelper.ExecuteNonQuery(Vietsoft.Information.ConnectionString, System.Data.CommandType.Text, "UPDATE " + sTable + " SET " + sField + " = N'" + _sNNgu + "' " + sID);
                sLoi = "";
            }
            catch (Exception ex)
            {
                sLoi = ex.Message.ToString();
                return false;
            }
            return true;
        }
    }
}




