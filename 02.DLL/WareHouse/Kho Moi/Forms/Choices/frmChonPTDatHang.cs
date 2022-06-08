using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmChonPTDatHang : DevExpress.XtraEditors.XtraForm
    {
         /// <summary>
        /// Khai báo chung
        /// </summary> 
        private DataTable _TbSource = new DataTable();
        private DataTable _TbCurrent = new DataTable();              
        /// <summary>
        /// DataSource
        /// </summary> 
        public DataTable DataSource
        {
            get
            {
                return _TbSource;
            }            
        }
        /// <summary>
        /// DataSource
        /// </summary> 
        public DataTable CurrentSource
        {
            set
            {
                _TbCurrent = value;
            }
        }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary> 
        public frmChonPTDatHang()
        {
            InitializeComponent();
        }
        private void frmChonPTDatHang_Load(object sender, EventArgs e)
        {
            Vietsoft.SqlInfo SqlKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbKho = new DataTable();
            TbKho.Load(SqlKho.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_KHO_PT"));
            DataRow rKho = TbKho.NewRow();
            rKho["MS_KHO"] = -1;
            rKho["TEN_KHO"] = "All";
            TbKho.Rows.InsertAt(rKho, 0);
            CboKho.ValueMember = "MS_KHO";
            CboKho.DisplayMember = "TEN_KHO";
            CboKho.DataSource = TbKho;
            CboKho.SelectedItem = -1;
            
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }      
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CboKho_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboKho.SelectedValue != null)
            {
                Vietsoft.SqlInfo SqlPhuTung = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
                _TbSource = new DataTable();
                _TbSource.Load(SqlPhuTung.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_PHU_TUNG_DAT_HANG", CboKho.SelectedValue));
                foreach (DataColumn ClPhuTung in _TbSource.Columns)
                {
                    ClPhuTung.ReadOnly = true;
                }
                _TbSource.Columns["CHON"].ReadOnly = false;
                DgvSelect.AutoGenerateColumns = false;
                DgvSelect.DataSource = _TbSource;
                foreach (DataGridViewColumn clPhuTung in DgvSelect.Columns)
                {
                    clPhuTung.DataPropertyName = clPhuTung.Name;
                }
                string[] clFilter = new string[DgvSelect.Columns.Count];
                for (int i = 0; i < DgvSelect.Columns.Count; i++)
                {
                    clFilter[i] = DgvSelect.Columns[i].Name;
                }
                DgvSelect.ColumnFilter(clFilter);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DgvSelect.Rows.Count;i++ )
            {
                DgvSelect.Rows[i].Cells[0].Value = true;
                _TbSource.AcceptChanges();
            }
        }

        private void btnNotAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rPhuTung in DgvSelect.Rows)
            {
                rPhuTung.Cells[0].Value = false;
                _TbSource.AcceptChanges();
            }
        }

        private void txtMSPT_TextChanged(object sender, EventArgs e)
        {
            LocDeXuat();
        }

        private void chkDeXuat_CheckedChanged(object sender, EventArgs e)
        {
            LocDeXuat();
        }
        private void LocDeXuat()
        {
            try
            {
                string dk = "";
                if (txtMSPT.Text.Length != 0) dk = " OR  (MS_PT LIKE '%" + txtMSPT.Text + "%') " + dk;
                if (txtMSPT.Text.Length != 0) dk = " OR  (TEN_PT LIKE '%" + txtMSPT.Text + "%') " + dk;
                if (txtMSPT.Text.Length != 0) dk = " OR  (MS_PT_CTY LIKE '%" + txtMSPT.Text + "%') " + dk;
                if (txtMSPT.Text.Length != 0) dk = " OR  (MS_DE_XUAT LIKE '%" + txtMSPT.Text + "%') " + dk;

                if (dk.Length > 0)
                {
                    dk = dk.Substring(5, dk.Length - 5);
                    if (chkDeXuat.Checked) dk = "(" + dk + ")" + " AND (MS_DE_XUAT <> '' ) ";
                }
                else
                    if (chkDeXuat.Checked) dk = " (MS_DE_XUAT <> '' ) ";
                _TbSource.DefaultView.RowFilter = dk;
            }
            catch { _TbSource.DefaultView.RowFilter = ""; }
        
        }
    }
}//