using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace ImportExcels
{
    public partial class frmPopUp : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _tbsource = new DataTable();
        public DataTable TableSource
        {
            set
            {
                _tbsource = value;
            }
        }
        // Dữ liệu được chọn
        private DataRow _dtrow;
        public DataRow RowSelected
        {
            get
            {
                return _dtrow;
            }
        }

        public frmPopUp()
        {
            InitializeComponent();
        }

        private void frmPopUp_Load(object sender, EventArgs e)
        {
            if (_tbsource.Columns.Count <6)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _tbsource, false, true, true, true);
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdSource, grvSource, _tbsource, false, true, false, true);

            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                _dtrow = ((DataRowView)grvSource.GetFocusedRow()).Row;
                this.DialogResult = DialogResult.OK;
            }
            catch { }

            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void grvSource_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _dtrow = ((DataRowView)grvSource.GetFocusedRow()).Row;
                this.DialogResult = DialogResult.OK;
            }
            catch { }

            this.Close();
        }

        GridView viewChung;
        Point ptChung;

        private void grvSource_ShownEditor(object sender, EventArgs e)
        {
            viewChung = (GridView)sender;
            ptChung = viewChung.GridControl.PointToClient(Control.MousePosition);
            viewChung.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);

        }

        private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        {
            DoRowDoubleClick(viewChung, ptChung);
            grvSource.RefreshData();
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {
        }

        private void txtMS_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            string dk = "";
            try
            {
                dtTmp = (DataTable)grdSource.DataSource;
                foreach (DataColumn col in dtTmp.Columns)
                {
                    if (col.DataType.ToString().ToUpper() == "System.String".ToUpper())
                    {
                        if (txtMS.Text.Length != 0) dk = " OR  " +  col.ColumnName.ToUpper().ToString() + " LIKE '%" + txtMS.Text + "%' " + dk;
                        
                    }
                }

                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);

                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                dtTmp.DefaultView.RowFilter = "";
            }
        }
    }
}