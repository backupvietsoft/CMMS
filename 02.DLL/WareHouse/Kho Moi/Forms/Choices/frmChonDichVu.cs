using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmChonDichVu : DevExpress.XtraEditors.XtraForm
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
        public frmChonDichVu()
        {
            InitializeComponent();
        }

        private void frmChonDichVu_Load(object sender, EventArgs e)
        {
            _TbSource = new DataTable();
            Vietsoft.SqlInfo SqlDichVu = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            _TbSource.Load(SqlDichVu.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DICH_VU_DE_XUAT"));
            foreach (DataColumn ClDichVu in _TbSource.Columns)
            {
                ClDichVu.ReadOnly = true;
            }
            _TbSource.Columns["CHON"].ReadOnly = false;
            DataColumn[] clKeyDichVu = new DataColumn[1];
            clKeyDichVu[0] = _TbSource.Columns["MS_DICH_VU"];
            _TbSource.PrimaryKey = clKeyDichVu;
            for (int i = 0; i < _TbCurrent.Rows.Count; i++)
            {
                if (_TbSource.Rows.Find(_TbCurrent.Rows[i]["MS_DICH_VU"]) != null)
                {
                    _TbSource.Rows.Remove(_TbSource.Rows.Find(_TbCurrent.Rows[i]["MS_DICH_VU"]));
                }
            }
            DgvSelect.AutoGenerateColumns = false;
            DgvSelect.DataSource = _TbSource;
            foreach (DataGridViewColumn clDichVu in DgvSelect.Columns)
            {
                clDichVu.DataPropertyName = clDichVu.Name;
            }
            string[] clFilter = new string[DgvSelect.Columns.Count];
            for (int i = 0; i < DgvSelect.Columns.Count; i++)
            {
                clFilter[i] = DgvSelect.Columns[i].Name;
            }
            DgvSelect.ColumnFilter(clFilter);
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
    }
}