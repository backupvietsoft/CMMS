using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace Vs.Support
{
    public partial class frmMain : Form
    {
        string http = Program.http;
        public static frmMain _instance;

        DataTable dtNN = new DataTable();

        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            

            try
            {
                dtNN = Program.GetDataNN(this.Name);

                frmLogin frm = new frmLogin();

                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    Environment.Exit(Environment.ExitCode);
                    return;
                }

                DataTable dtParent = new DataTable();
                dtParent = Vs.Support.Commons.API.getDataAPI(http + "Support/getMenu?sUName=" + Vs.Support.Program.UNameLogin + "&iNNgu=" + Vs.Support.Program.NNgu.ToString() + "");

                AddMenuParent(dtParent);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private DataTable GetMenuData(string sSql)
        {

            //using (SqlConnection con = new SqlConnection(Program.CNStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sSql, con))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        return dt;
            //    }

            //}
            return null;
        }

        private void Item1_Menu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item1 clicked");
        }

        private void FormCloseMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Form wil be closed");
            this.Close();
        }


        private void AddMenuParent(DataTable menuData)
        {
            DataView view = new DataView(menuData);
            view.RowFilter = "MENU_PARENT IS NULL";
            foreach (DataRowView row in view)
            {

                //"SELECT T1.ID_MENU, KEY_MENU,CASE 0 WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A,''),TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H,''),T1.TEN_MENU) END AS TEN_MENU,T1.MENU_PARENT, HIDE, STT_MENU, CONTROLS,ISNULL(MENU_LINE,0) AS MENU_LINE, T1.MENU_PARAMETER,T1.HOT_KEY, MENU_FUN FROM dbo.MENU T1 	WHERE  (ISNULL(HIDE,0) = 0) AND INACTIVE = 0	ORDER BY STT_MENU";

                ToolStripMenuItem MnuStripItem;
                MnuStripItem = new ToolStripMenuItem(row["TEN_MENU"].ToString());
                MnuStripItem.Name = row["KEY_MENU"].ToString();
                MnuStripItem.Tag = row["MENU_FUN"].ToString();
                MnuStrip.Items.Add(MnuStripItem);

                AddChildMenuItems(menuData, MnuStripItem);
            }

        }
        //This code is used to recursively add child menu items by filtering by ParentID

        private void AddChildMenuItems(DataTable menuData, ToolStripMenuItem parentMenuItem)
        {
            DataView view = new DataView(menuData);
            try
            {
                view.RowFilter = "MENU_PARENT= '" + parentMenuItem.Name.ToString() + "' ";
                foreach (DataRowView row in view)
                {
                    ToolStripMenuItem SSMenu = new ToolStripMenuItem(row["TEN_MENU"].ToString(), null, new EventHandler(ChildClick));
                    SSMenu.Name = row["KEY_MENU"].ToString();
                    SSMenu.Tag = row["MENU_FUN"].ToString();
                    parentMenuItem.DropDownItems.Add(SSMenu);
                    AddChildMenuItems(menuData, SSMenu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChildClick(object sender, EventArgs e)
        {
            try
            {
                switch (((System.Windows.Forms.ToolStripItem)sender).Tag.ToString().ToLower())
                {
                    #region mnHeThong

                    case "showlogin":
                        {
                            ThemNguoiDung();
                            break;
                        }
                    case "shownngu":
                        {

                            break;
                        }
                    case "showtiengviet":
                        {
                            Program.NNgu = 0;
                            break;
                        }
                    case "showtienganh":
                        {
                            Program.NNgu = 1;
                            break;
                        }

                    case "close":
                        {
                            if (MessageBox.Show(Program.GetNN(dtNN, "msgBanCoMuonThoatKhong", this.Name), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.Close();
                            }
                            else
                                return;
                            break;


                        }
                    #endregion
                    #region mnKhachHang
                    case "showdskh":
                        {
                            ShowDSKhachHang();
                            break;
                        }
                    case "showhopdong":
                        {
                            ShowHopDong();
                            break;
                        }
                    #endregion
                    #region mnBaoCao
                    case "showreporthd":
                        {
                            ShowReportHD();
                            break;
                        }
                    case "showreportnv":
                        {
                            ShowReportNV();
                            break;
                        }
                    #endregion
                    #region mnHoTro
                    case "showyeucauht":
                        {
                            ShowYeuCauHT();
                            break;
                        }
                    case "showxemphanhoi":
                        {
                            ShowXemPhanHoi();
                            break;
                        }
                    case "showelearning":
                        {
                            ShowElearning();
                            break;
                        }
                        #endregion

                }
            }
            catch { }
        }

        private void ThemNguoiDung()
        {
            frmThemNguoiDung frm = new frmThemNguoiDung();
            ShowForm(frm);
        }
        private void ShowYeuCauHT()
        {
            frmSupport frm = new frmSupport(Program.NNgu, "admin", "Nguyen Van X", "Cong ty walh", "xyz@walh.com", "09831xx1xx", "zalo", 17, 22, "trammp335@gmail.com", "thanhthuy2612", "smtp.gmail.com", 587);
            ShowForm(frm);
        }
        private void ShowXemPhanHoi()
        {
            frmVSReply frm = new frmVSReply(Program.NNgu, "test123", "Nguyen Van Test", "Vietsoft", "vietsoft@gmail.com", "00000", "00000", -1, "skeylerhack@gmail.com", "01689561596", "smtp.gmail.com", 587);
            ShowForm(frm);
        }
        private void ShowElearning()
        {
            frmELearning frm = new frmELearning(4);
            ShowForm(frm);
        }

        private void ShowDSKhachHang()
        {
            frmCustomer frm = new frmCustomer();
            ShowForm(frm);
        }
        private void ShowHopDong()
        {
            frmCustomerContract frm = new frmCustomerContract(0);
            ShowForm(frm);
        }
        private void ShowReportHD()
        {
            frmReportContract frm = new frmReportContract(Program.NNgu);
            ShowForm(frm);
        }
        private void ShowReportNV()
        {
            frmReport_NV frm = new frmReport_NV(Program.NNgu);
            ShowForm(frm);
        }
        private void ShowForm(Form frm)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm1 in fc)
            {
                if (frm.Name == frm1.Name)
                {
                    frm1.Focus();
                    return;
                }
            }

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

    }
}
