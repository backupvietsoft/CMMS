using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmDanhsachDDHtuDexuat : DevExpress.XtraEditors.XtraForm
    {
        private string title = "";
        public frmDanhsachDDHtuDexuat(string msdx)
        {
            title = msdx;
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDanhsachDDHtuDexuat_Load(object sender, EventArgs e)
        {           
            Vietsoft.SqlInfo SqlKho = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            DataTable TbKho = new DataTable();
            TbKho.Load(SqlKho.ExecuteReader(CommandType.StoredProcedure, "DEXUAT_DDH", title));

            gvDondathang.DataSource = TbKho;

            Commons.Modules.ObjSystems.ThayDoiNN(this);
            lblTitle.Text = title;           

        }
    }
}