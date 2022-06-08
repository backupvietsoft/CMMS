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
    public partial class ucVTKhongXuatKho : DevExpress.XtraEditors.XtraUserControl
    {
        string Sql;
        private Boolean LoaiBC = false;
       
        public ucVTKhongXuatKho()
        {
            InitializeComponent();
        }

        private void ucVTChuaXuatKho_Load(object sender, EventArgs e)
        {
            //@LBCao = 1 Bao Cao Vat Tu chua Xuat Kho -- true
            //@LBCao = 0 Bao Cao Vat Tu khong thay the -- false


            datSNgay.DateTime = Convert.ToDateTime("01/01/" + DateTime.Now.Year);
            if (LoaiBC) VatTuChuaXuatKho(); else VatTuKhongThayThe();
            

            
        }
        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = 0; i < view.RowCount; i++)
            {
                view.SetRowCellValue(i, "CHON", choose);
            }
        }
        private void btnKhoAll_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvKho);
        }

        private void btnKhoNAll_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvKho);
        }

        private void btnDNAll_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvChung);
        }

        private void btnDNNAll_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvChung);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //if (LoaiBC) InVatTuchuaXuat(); else                 InVatTuKhongThayThe();
            InVatTuchuaXuat();
            
        }

#region VatTuChuaXuatKho
        private void VatTuChuaXuatKho()
        {            
            TaoLuoiKho();
            TaoLuoiDangXuat();
            TaoLoaiVatTu();
        }
        private void TaoLuoiKho()
        {
            DataTable dtTmp = new DataTable();
            Sql = " SELECT CONVERT(BIT,0) AS CHON,TEN_KHO, A.MS_KHO " +
                            " FROM IC_KHO A INNER JOIN NHOM_KHO B ON A.MS_KHO = B.MS_KHO INNER JOIN " +
                            " dbo.USERS ON B.GROUP_ID = dbo.USERS.GROUP_ID " +
                            " WHERE      (dbo.USERS.USERNAME = N'" +  Commons.Modules.UserName + "') " +
                            " ORDER BY TEN_KHO ";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));
            foreach (DataColumn col in dtTmp.Columns)
            {
                col.ReadOnly = true;
            }
            dtTmp.Columns["CHON"].ReadOnly = false;
            grdKho.DataSource = dtTmp;
            grvKho.Columns["MS_KHO"].Visible = false;
            grvKho.BestFitColumns();
            grvKho.Columns["CHON"].Width = 150;

        }
        private void TaoLuoiDangXuat()
        {
            DataTable dtTmp = new DataTable();
            Sql = " SELECT CONVERT(BIT,0) AS CHON, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN DANG_XUAT_VIET WHEN 0 THEN DANG_XUAT_ANH " +
                        " ELSE DANG_XUAT_HOA END AS DANG_XUAT , MS_DANG_XUAT FROM dbo.DANG_XUAT  ORDER BY DANG_XUAT ";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));
            foreach (DataColumn col in dtTmp.Columns)
            {
                col.ReadOnly = true;
            }
            dtTmp.Columns["CHON"].ReadOnly = false;
            

            grdChung.DataSource = dtTmp;
            grvChung.PopulateColumns();
            grvChung.Columns["MS_DANG_XUAT"].Visible = false;

            grvChung.BestFitColumns();
            grvChung.Columns["CHON"].Width = 150;


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
        private void InVatTuchuaXuat()
        {
            try
            {
                
#region Kiem Kho
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
                Commons.Modules.ObjSystems.XoaTable("AAA_TMP");
                Sql = "SELECT MS_KHO INTO AAA_TMP FROM IC_KHO WHERE MS_KHO  IN (" + Sql.Substring(1, Sql.Length - 1) + ") ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql);
                frm._sKho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "TenKho", Commons.Modules.TypeLanguage) + " : " + sTmp.Substring(1, sTmp.Length - 1);

                dtTmp = new DataTable();
                dtTmp = ((DataTable)grdChung.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = "CHON = TRUE ";
#endregion
#region Kiem Dang xuat
                if (LoaiBC)
                {
//Kiem Dang xuat
                    if (dtTmp.DefaultView.ToTable().Rows.Count == 0)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "KhongChonDXuat", Commons.Modules.TypeLanguage));
                        return;
                    }
                    Sql = "";
                    sTmp = "";
                    foreach (DataRow rowTmp in dtTmp.DefaultView.ToTable().Rows)
                    {
                        Sql = Sql + ", " + rowTmp["MS_DANG_XUAT"].ToString();
                        sTmp = sTmp + ", " + rowTmp["DANG_XUAT"].ToString();

                    }
                    Commons.Modules.ObjSystems.XoaTable("AAA_DX");
                    Sql = "SELECT MS_DANG_XUAT INTO AAA_DX FROM DANG_XUAT WHERE MS_DANG_XUAT  IN (" + Sql.Substring(1, Sql.Length - 1) + ") ";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql);
                    frm._sDXuat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "DangXuat", Commons.Modules.TypeLanguage) + " : " + sTmp.Substring(1, sTmp.Length - 1);
                }
#endregion
                else
#region Kiem Loai May
                {
//Kiem Loai May
                    if (dtTmp.DefaultView.ToTable().Rows.Count == 0)
                    {
                        MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "KhongChonLMay", Commons.Modules.TypeLanguage));
                        return;
                    }
                    Sql = "";
                    sTmp = "";
                    foreach (DataRow rowTmp in dtTmp.DefaultView.ToTable().Rows)
                    {
                        Sql = Sql + ", '" + rowTmp["MS_LOAI_MAY"].ToString() + "'";
                        //sTmp = sTmp + ", " + rowTmp["TEN_LOAI_MAY"].ToString();

                    }
                    Commons.Modules.ObjSystems.XoaTable("AAA_LM");
                    Sql = "SELECT MS_LOAI_MAY INTO AAA_LM FROM LOAI_MAY WHERE MS_LOAI_MAY  IN (" + Sql.Substring(1, Sql.Length - 1) + ") ";
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql);
                    frm._sDXuat = "-111";
                    

                }
#endregion

//Tao Bang tam BC
                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MThongKeVTChuaXuatKho", datSNgay.DateTime, cmbLVT.EditValue, LoaiBC));

                frm.TableSource = dtTmp;
                frm._dNgay = lblSauNgay.Text + " : " + datSNgay.DateTime.ToShortDateString();
                frm._LoaiVT = lblLVT.Text + " : " + cmbLVT.Text;
                frm.ShowDialog();

            }
            catch { }
        }
#endregion

#region VatTuKhongThayThe
        private void VatTuKhongThayThe()
        {
            TaoLuoiKho();
            TaoLuoiLoaiMay();
            TaoLoaiVatTu();
        }
        private void TaoLuoiLoaiMay()
        {
            DataTable dtTmp = new DataTable();
            Sql = " SELECT DISTINCT CONVERT(BIT,0) AS CHON, T1.MS_LOAI_MAY, T1.TEN_LOAI_MAY " +
                        " FROM            dbo.LOAI_MAY AS T1 INNER JOIN " +
                        " dbo.NHOM_LOAI_MAY AS T2 ON T1.MS_LOAI_MAY = T2.MS_LOAI_MAY INNER JOIN " +
                        " dbo.USERS AS T3 ON T2.GROUP_ID = T3.GROUP_ID " +
                        " WHERE        (T3.USERNAME = N'" +  Commons.Modules.UserName + "') " +
                        " ORDER BY T1.TEN_LOAI_MAY ";
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, Sql));
            foreach (DataColumn col in dtTmp.Columns)
            {
                col.ReadOnly = true;
            }
            dtTmp.Columns["CHON"].ReadOnly = false;
            grdChung.DataSource = dtTmp;
            grvChung.PopulateColumns();
            grvChung.Columns["MS_LOAI_MAY"].Visible = false;

            grvChung.BestFitColumns();
            grvChung.Columns["CHON"].Width = 150;


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
                Commons.Modules.ObjSystems.XoaTable("AAA_TMP");
                Sql = "SELECT MS_KHO INTO AAA_TMP FROM IC_KHO WHERE MS_KHO  IN (" + Sql.Substring(1, Sql.Length - 1) + ") ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql);
                frm._sKho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "TenKho", Commons.Modules.TypeLanguage) + " : " + sTmp.Substring(1, sTmp.Length - 1);


                dtTmp = new DataTable();
                dtTmp = ((DataTable)grdChung.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = "CHON = TRUE ";
                if (dtTmp.DefaultView.ToTable().Rows.Count == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "KhongChonLMay", Commons.Modules.TypeLanguage));
                    return;
                }
                Sql = "";
                sTmp = "";
                foreach (DataRow rowTmp in dtTmp.DefaultView.ToTable().Rows)
                {
                    Sql = Sql + ", '" + rowTmp["MS_LOAI_MAY"].ToString()+ "'";
                    sTmp = sTmp + ", " + rowTmp["TEN_LOAI_MAY"].ToString() ;

                }
                Commons.Modules.ObjSystems.XoaTable("AAA_LM");
                Sql = "SELECT MS_LOAI_MAY INTO AAA_LM FROM LOAI_MAY WHERE MS_LOAI_MAY  IN (" + Sql.Substring(1, Sql.Length - 1) + ") ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, Sql);
                frm._sDXuat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucVTChuaXuatKho", "DangXuat", Commons.Modules.TypeLanguage) + " : " + sTmp.Substring(1, sTmp.Length - 1);


                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MThongKeVTChuaXuatKho", datSNgay.DateTime, cmbLVT.EditValue));



                frm.TableSource = dtTmp;
                frm._dNgay = lblSauNgay.Text + " : " + datSNgay.DateTime.ToShortDateString();
                frm._LoaiVT = lblLVT.Text + " : " + cmbLVT.Text;
                frm.ShowDialog();

            }
            catch { }
        }



#endregion

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
