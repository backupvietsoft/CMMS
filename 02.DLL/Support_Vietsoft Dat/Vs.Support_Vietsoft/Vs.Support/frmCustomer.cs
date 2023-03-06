using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Vs.Support.Commons;

namespace Vs.Support
{
    public partial class frmCustomer : Form
    {
        public string http = Program.http;
        private int rowIndex = 0;

        private Int64 CustomerID = -1;


        private Int64 CustomerID_TMP = -1;

        DataTable dtNN = new DataTable();

        public frmCustomer()
        {
            InitializeComponent();
        }

        #region even
        private void frmCustomer_Load(object sender, System.EventArgs e)
        {
            LoadData();
            dtNN = Program.GetDataNN(this.Name.ToString());
            LoadNN();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)(dgvCustomer.DataSource);
                if (txtSearch.TextLength > 0)
                {
                    string TextSearch = string.Format("CompanyFullName LIKE '%{0}%' OR ShortName LIKE '%{0}%' OR Address LIKE '%{0}%' OR CEO LIKE '%{0}%' OR Email LIKE '%{0}%' OR Phone LIKE '%{0}%'", txtSearch.Text);
                    try
                    {
                        dt.DefaultView.RowFilter = TextSearch;
                    }
                    catch { dt.DefaultView.RowFilter = ""; }
                }
                else { dt.DefaultView.RowFilter = ""; }
            }
            catch
            { }
        }

        private void dgvCustomer_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    //this.dgvCustomer.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                }
            }
            catch
            { }
        }
        private void dgvCustomer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        }
        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.dgvCustomer.Rows[rowIndex].Selected = true;
                frmCustomer_View frmview = new frmCustomer_View();

                try { frmview.CustomerID = string.IsNullOrEmpty(dgvCustomer.Rows[rowIndex].Cells["ID"].Value.ToString()) ? -1 : Convert.ToInt64(dgvCustomer.Rows[rowIndex].Cells["ID"].Value); } catch { }
                try { frmview.TenCT_Full = string.IsNullOrEmpty(dgvCustomer.Rows[rowIndex].Cells["CompanyFullName"].Value.ToString()) ? null : dgvCustomer.Rows[rowIndex].Cells["CompanyFullName"].Value.ToString(); } catch { }
                try { frmview.ShortN = string.IsNullOrEmpty(dgvCustomer.Rows[rowIndex].Cells["ShortName"].Value.ToString()) ? null : dgvCustomer.Rows[rowIndex].Cells["ShortName"].Value.ToString(); } catch { }
                try { frmview.Address = string.IsNullOrEmpty(dgvCustomer.Rows[rowIndex].Cells["Address"].Value.ToString()) ? null : dgvCustomer.Rows[rowIndex].Cells["Address"].Value.ToString(); } catch { }
                try { frmview.CEO = string.IsNullOrEmpty(dgvCustomer.Rows[rowIndex].Cells["CEO"].Value.ToString()) ? null : dgvCustomer.Rows[rowIndex].Cells["CEO"].Value.ToString(); } catch { }
                try { frmview.Email = string.IsNullOrEmpty(dgvCustomer.Rows[rowIndex].Cells["Email"].Value.ToString()) ? null : dgvCustomer.Rows[rowIndex].Cells["Email"].Value.ToString(); } catch { }
                try { frmview.Phone = string.IsNullOrEmpty(dgvCustomer.Rows[rowIndex].Cells["Phone"].Value.ToString()) ? null : dgvCustomer.Rows[rowIndex].Cells["Phone"].Value.ToString(); } catch { }
                try { frmview.HDBT_DA_KY = string.IsNullOrEmpty(dgvCustomer.Rows[rowIndex].Cells["HDBT_DA_KY"].Value.ToString()) ? null : dgvCustomer.Rows[rowIndex].Cells["HDBT_DA_KY"].Value.ToString(); } catch { }
                try { frmview.Ghi_Chu = string.IsNullOrEmpty(dgvCustomer.Rows[rowIndex].Cells["GHI_CHU"].Value.ToString()) ? null : dgvCustomer.Rows[rowIndex].Cells["GHI_CHU"].Value.ToString(); } catch { }


                if (frmview.ShowDialog() != DialogResult.OK)
                {
                    CustomerID_TMP = frmview.CustomerID_TMP;
                    LoadData();
                }
                else
                {
                    CustomerID_TMP = frmview.CustomerID_TMP;
                    LoadData();
                }
            }
            catch
            {

            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmCustomer_View frmview = new frmCustomer_View();
            if (frmview.ShowDialog() != DialogResult.No) return;
            LoadData();
        }
        #endregion

        #region function
        private void LoadData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/getCustomer");
                dt.Rows[0].Delete();
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                dt.AcceptChanges();
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns["HDBT_DA_KY"].Visible = false;
                if (CustomerID_TMP != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(CustomerID_TMP));
                    dgvCustomer.Rows[index].Selected = true;
                }
                Alignment();
            }
            catch
            { }
        }
        private void Alignment()
        {
            try
            {
                this.dgvCustomer.Columns["CompanyFullName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCustomer.Columns["ShortName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCustomer.Columns["Address"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCustomer.Columns["CEO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCustomer.Columns["Email"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCustomer.Columns["Phone"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCustomer.Columns["HDBT_DA_KY"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvCustomer.Columns["GHI_CHU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvCustomer.Columns["Phone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch
            { }
        }
        private void LoadNN()
        {
            try
            {

                this.Text = Program.GetNN(dtNN, this.Name, this.Name);
                this.btnThem.Text = Program.GetNN(dtNN, btnThem.Name, this.Name);
                this.btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);
                dgvCustomer.Columns["CompanyFullName"].HeaderText = Program.GetNN(dtNN, dgvCustomer.Columns["CompanyFullName"].Name, this.Name);
                dgvCustomer.Columns["ShortName"].HeaderText = Program.GetNN(dtNN, dgvCustomer.Columns["ShortName"].Name, this.Name);
                dgvCustomer.Columns["Address"].HeaderText = Program.GetNN(dtNN, dgvCustomer.Columns["Address"].Name, this.Name);
                dgvCustomer.Columns["CEO"].HeaderText = Program.GetNN(dtNN, dgvCustomer.Columns["CEO"].Name, this.Name);
                dgvCustomer.Columns["Email"].HeaderText = Program.GetNN(dtNN, dgvCustomer.Columns["Email"].Name, this.Name);
                dgvCustomer.Columns["Phone"].HeaderText = Program.GetNN(dtNN, dgvCustomer.Columns["Phone"].Name, this.Name);
                dgvCustomer.Columns["HDBT_DA_KY"].HeaderText = Program.GetNN(dtNN, dgvCustomer.Columns["HDBT_DA_KY"].Name, this.Name);
                dgvCustomer.Columns["GHI_CHU"].HeaderText = Program.GetNN(dtNN, dgvCustomer.Columns["GHI_CHU"].Name, this.Name);

            }
            catch { };
        }

        private void dgvCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (MessageBox.Show(Program.GetNN(dtNN, "msgXoa", this.Name), Program.GetNN(dtNN, "msgThongBao", this.Name), MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    int index = dgvCustomer.CurrentCell.RowIndex;
                    DataTable dt = new DataTable();
                    dt = API.getDataAPI(http + "Support/delCustomer?CustomerID=" + Convert.ToInt64(dgvCustomer.Rows[index].Cells["ID"].Value) + "");
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(dt.Rows[0][0].ToString());
                    }
                }
                catch { }
            }
        }
        #endregion
        //higlight search

    }
}
