using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportHuda.UControl
{
    public partial class ucVTKhongThayThe : DevExpress.XtraEditors.XtraUserControl
    {
        string Sql;

        public ucVTKhongThayThe()
        {
            InitializeComponent();
        }
        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnKhoAll_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvKho);
        }

        private void btnKhoNAll_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvKho);
        }
        private void TaoLuoiKho()
        {
            DataTable dtTmp = new DataTable();
            Sql = " SELECT     CONVERT(BIT,0) AS CHON, TEN_KHO,dbo.IC_KHO.MS_KHO " +
                        " FROM         dbo.IC_KHO INNER JOIN " +
                        "                       dbo.NHOM_KHO ON dbo.IC_KHO.MS_KHO = dbo.NHOM_KHO.MS_KHO INNER JOIN " +
                        "                       dbo.USERS ON dbo.NHOM_KHO.GROUP_ID = dbo.USERS.GROUP_ID " +
                        " WHERE     (dbo.USERS.USERNAME = '" + Commons.Modules.UserName + "' ) ORDER BY TEN_KHO";

            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));
            foreach (DataColumn col in dtTmp.Columns)
            {
                col.ReadOnly = true;
            }
            dtTmp.Columns["CHON"].ReadOnly = false;
            grdKho.DataSource = dtTmp;
            grvKho.Columns["MS_KHO"].Visible = false;
            grvKho.BestFitColumns();
            grvKho.Columns["CHON"].Width = 200;
            

        }
        
        private void TaoLoaiVatTu()
        {
            DataTable dtTmp = new DataTable();
            Sql = " SELECT MS_LOAI_VT, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN TEN_LOAI_VT_TV WHEN 0 THEN TEN_LOAI_VT_TA " +
                        " ELSE TEN_LOAI_VT_TH END AS TEN_LOAI_VT FROM LOAI_VT UNION SELECT '-1',' < ALL > ' ORDER BY TEN_LOAI_VT ";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));
            cmbLVT.Properties.DataSource = dtTmp;
            cmbLVT.Properties.ValueMember = "MS_LOAI_VT";
            cmbLVT.Properties.DisplayMember = "TEN_LOAI_VT";
            cmbLVT.Properties.Columns.Clear();
            cmbLVT.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_LOAI_VT"));
            cmbLVT.EditValue = "-1";
            

        }
        private void TaoKhachHang()
        {
            DataTable dtTmp = new DataTable();
            Sql = " SELECT DISTINCT MS_KH, TEN_CONG_TY FROM dbo.KHACH_HANG " +
                        " UNION SELECT '-1',' < ALL > ' ORDER BY TEN_CONG_TY ";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));
            cmbKH.Properties.DataSource = dtTmp;
            cmbKH.Properties.ValueMember = "MS_KH";
            cmbKH.Properties.DisplayMember = "TEN_CONG_TY";
            cmbKH.Properties.Columns.Clear();
            cmbKH.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_CONG_TY"));
            cmbKH.EditValue = "-1";
        }
        private void ucVTKhongThayThe_Load(object sender, EventArgs e)
        {
            try
            {
                datSNgay.DateTime = Convert.ToDateTime(DateTime.Now.AddMonths(-6));
                TaoLuoiKho();
                TaoKhachHang();
                TaoLoaiVatTu();
                grvKho.Columns["CHON"].Width = 120;


            }
            catch { }
        }

        private void InVatTuKhongThayThe()
        {
            try
            {

                DataTable dtTmp = new DataTable();
                dtTmp = ((DataTable)grdKho.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = "CHON = TRUE ";

                if (dtTmp.DefaultView.ToTable().Rows.Count == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "KhongChonKho", Commons.Modules.TypeLanguage));
                    return;
                }
                ReportHuda.Forms.frmTKVTChuaXuat frm = new ReportHuda.Forms.frmTKVTChuaXuat();
                Sql = "";
                string sTmp = "";
                foreach (DataRow rowTmp in dtTmp.DefaultView.ToTable().Rows)
                {
                    Sql = Sql + ", " + rowTmp["MS_KHO"].ToString();
                    sTmp = sTmp + ", " + rowTmp["TEN_KHO"].ToString();
                }
                Commons.Modules.ObjSystems.XoaTable("AAA_KHO");
                Sql = "SELECT MS_KHO INTO AAA_KHO FROM IC_KHO WHERE MS_KHO  IN (" + Sql.Substring(1, Sql.Length - 1) + ") ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql);
                frm._sDXuat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "TenKho", Commons.Modules.TypeLanguage) + " : " + sTmp.Substring(1, sTmp.Length - 1);

                

                //Tao Bang tam BC
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MThongKeVTKhongThayThe", datSNgay.DateTime, cmbLVT.EditValue, cmbKH.EditValue));

                frm.TableSource = dtTmp;
                frm._dNgay = lblSauNgay.Text + " : " + datSNgay.DateTime.ToShortDateString();
                frm._LoaiVT = lblLVT.Text + " : " + cmbLVT.Text;
                frm._sKho = lblKH.Text + " : " + cmbKH.Text;
                frm.ShowDialog();

            }
            catch { }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            InVatTuKhongThayThe();
            Commons.Modules.ObjSystems.XoaTable("AAA_KHO");
        }

    }
}
