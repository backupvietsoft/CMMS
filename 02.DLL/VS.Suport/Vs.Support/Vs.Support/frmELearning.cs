using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Vs.Support.Commons;

namespace Vs.Support
{
    public partial class frmELearning : Form
    {
        string http = Program.http;
        Int64 iIDCustomer = 1;
        public frmELearning(Int64 idCustomer)
        {
            InitializeComponent();
            iIDCustomer = idCustomer;
        }
        #region even
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmELearning_Load(object sender, EventArgs e)
        {
            LoaddtgELearning();

            try
            {
                dtgeLearning.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgeLearning.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgeLearning.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //Now that DataGridView has calculated it's Widths; we can now store each column Width values.
                for (int i = 0; i <= dtgeLearning.Columns.Count - 1; i++)
                {
                    // Store Auto Sized Widths:
                    int colw = dtgeLearning.Columns[i].Width;

                    // Remove AutoSizing:
                    dtgeLearning.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                    // Set Width to calculated AutoSize value:
                    dtgeLearning.Columns[i].Width = colw;
                }
            }
            catch
            {

            }

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)(dtgeLearning.DataSource);
                if (txtSearch.TextLength > 0)
                {
                    string TextSearch = string.Format("Description LIKE '%{0}%' OR VideoName LIKE '%{0}%'", txtSearch.Text);

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

        private void dtgeLearning_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgeLearning.Columns[dtgeLearning.CurrentCell.ColumnIndex].HeaderText.Contains("VideoLink"))
            {
                if (!String.IsNullOrEmpty(dtgeLearning.CurrentCell.EditedFormattedValue.ToString()))
                {
                    string str = dtgeLearning.CurrentCell.EditedFormattedValue.ToString();
                    if (str.Substring(0, 7) != "http://" && str.Substring(0, 8) != "https://")
                        str = "http://" + str;
                    System.Diagnostics.Process.Start(str);
                }
            }
        }
        private void dtgeLearning_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        #endregion

        #region function

        
        private void LoaddtgELearning()
        {
            try
            {

                dtgeLearning.DataSource = API.getDataAPI(http + "Support/GeteLearning?CustomerID=" + iIDCustomer + "");

                dtgeLearning.Columns["VideoLink"].Visible = false;
                dtgeLearning.Columns["ID"].Visible = false;
                dtgeLearning.Columns["Form"].Visible = false;
                DataGridViewLinkColumn col = new DataGridViewLinkColumn();
                col.DataPropertyName = "VideoLink";
                col.Name = "VideoLink";
                dtgeLearning.Columns.Add(col);
            }
            catch
            { }
        }

        #endregion

    }
}
