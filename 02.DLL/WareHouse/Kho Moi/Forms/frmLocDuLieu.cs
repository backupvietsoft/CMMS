using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmLocDuLieu : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Khai báo chung
        /// </summary>
        private object _TbSource = new object();
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public frmLocDuLieu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// DataSource
        /// </summary>
        public object DataSource
        {
            set
            {
                DgvFilter.DataSource = value;
                string[] clFilter = new string[DgvFilter.Columns.Count];
                for (int i = 0; i < DgvFilter.Columns.Count; i++)
                {
                    clFilter[i] = DgvFilter.Columns[i].Name;
                }
                DgvFilter.ColumnFilter(clFilter);
            }
        }
        /// <summary>
        /// Thoát không lọc dữ liệu
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// Thực hiện lọc dữ liệu
        /// </summary>
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmLocDuLieu_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void txtLPN_TextChanged(object sender, EventArgs e)
        {
            BindingSource dtTmp = new BindingSource();
            try
            {
                string dk = "";
                dtTmp = (BindingSource)DgvFilter.DataSource;
                if (this.Name == "frmLocDuLieu_DX")
                {
                    if (txtLPN.Text.Length != 0) dk = dk + " OR MS_DE_XUAT LIKE '%" + txtLPN.Text + "%' ";
                    if (txtLPN.Text.Length != 0) dk = dk + " OR SO_DE_XUAT LIKE '%" + txtLPN.Text + "%' ";
                }
                if (this.Name == "frmLocDuLieuNhapKho")
                {
                    if (txtLPN.Text.Length != 0) dk = dk + " OR MS_DH_NHAP_PT LIKE '%" + txtLPN.Text + "%' ";
                    if (txtLPN.Text.Length != 0) dk = dk + " OR SO_PHIEU_XN LIKE '%" + txtLPN.Text + "%' ";
                    if (txtLPN.Text.Length != 0) dk = dk + " OR TEN_KHO LIKE '%" + txtLPN.Text + "%' ";
                    if (txtLPN.Text.Length != 0) dk = dk + " OR SO_CHUNG_TU LIKE '%" + txtLPN.Text + "%' ";
                }
                if (this.Name == "frmLocDuLieu_DDH")
                {
                    if (txtLPN.Text.Length != 0) dk = dk + " OR MS_DON_DAT_HANG LIKE '%" + txtLPN.Text + "%' ";
                    if (txtLPN.Text.Length != 0) dk = dk + " OR SO_DON_DAT_HANG LIKE '%" + txtLPN.Text + "%' ";
                }
                ((System.Data.DataTable)(dtTmp.DataSource)).DefaultView.RowFilter = dk.Substring(4, dk.Length - 4);

            }
            catch
            { ((System.Data.DataTable)(dtTmp.DataSource)).DefaultView.RowFilter  = ""; }

        }
    }
}