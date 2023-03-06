using System;
using System.Data;
using System.Windows.Forms;
using Vs.Support.Commons;

namespace Vs.Support
{
    public partial class frmViewVStaff : Form
    {
        string http = Program.http;
        private int rowIndex = 0;
        public int iID = -1;

        DataTable dtNN = new DataTable();

        public frmViewVStaff()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmViewVStaff_Load(object sender, System.EventArgs e)
        {
            dtNN = Program.GetDataNN(this.Name);

            loadDgv();

            LoadNN();
        }
        private void loadDgv()
        {
            try
            {
                dgvVStaff.DataSource = API.getDataAPI(http + "Support/getViewVietSoftStaff?iID=" + iID + "");
                dgvVStaff.Columns["Password"].Visible = false;
                dgvVStaff.Columns["VietsoftDeptID"].Visible = false;
                dgvVStaff.Columns["ID"].Visible = false;
            }
            catch { }
        }

        private void dgvVStaff_DoubleClick(object sender, System.EventArgs e)
        {
            frmThemNguoiDung frm = new frmThemNguoiDung();
            Program.iID = string.IsNullOrEmpty(dgvVStaff.Rows[rowIndex].Cells["ID"].Value.ToString()) ? -1 : Convert.ToInt32(dgvVStaff.Rows[rowIndex].Cells["ID"].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void dgvVStaff_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.dgvVStaff.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                }
            }
            catch
            { }
        }
        private void LoadNN()
        {
            this.Text = Program.GetNN(dtNN, this.Name, this.Name);

            dgvVStaff.Columns["FullName"].HeaderText = Program.GetNN(dtNN, dgvVStaff.Columns["FullName"].Name , this.Name);
            dgvVStaff.Columns["ShortName"].HeaderText = Program.GetNN(dtNN, dgvVStaff.Columns["ShortName"].Name, this.Name);
            dgvVStaff.Columns["Email"].HeaderText = Program.GetNN(dtNN, dgvVStaff.Columns["Email"].Name, this.Name);
            dgvVStaff.Columns["Phone"].HeaderText = Program.GetNN(dtNN, dgvVStaff.Columns["Phone"].Name, this.Name);
            dgvVStaff.Columns["Zalo"].HeaderText = Program.GetNN(dtNN, dgvVStaff.Columns["Zalo"].Name, this.Name);
            dgvVStaff.Columns["DeptName"].HeaderText = Program.GetNN(dtNN, dgvVStaff.Columns["DeptName"].Name, this.Name);
            dgvVStaff.Columns["UserName"].HeaderText = Program.GetNN(dtNN, dgvVStaff.Columns["UserName"].Name, this.Name);
            dgvVStaff.Columns["InActive"].HeaderText = Program.GetNN(dtNN, dgvVStaff.Columns["InActive"].Name, this.Name);
            dgvVStaff.Columns["MaintService"].HeaderText = Program.GetNN(dtNN, dgvVStaff.Columns["MaintService"].Name, this.Name);

            btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);


        }
    }
}
