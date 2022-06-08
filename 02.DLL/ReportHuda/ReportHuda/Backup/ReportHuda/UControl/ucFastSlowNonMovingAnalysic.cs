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
    public partial class ucFastSlowNonMovingAnalysic : DevExpress.XtraEditors.XtraUserControl
    {
        public ucFastSlowNonMovingAnalysic()
        {
            InitializeComponent();
        }

        private void ucFastSlowNonMovingAnalysic_Load(object sender, EventArgs e)
        {
             
            grpDXuat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "grDXuat", Commons.Modules.TypeLanguage);
            datTNgay.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datDNgay.DateTime = DateTime.Now;

            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetKhoUserAll", 0, Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboKho, dtTmp, "MS_KHO", "TEN_KHO", "");
            }
            catch { }


            dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDXuat" , Commons.Modules.TypeLanguage ));
            //grdDXuat.DataSource = dtTmp;

            dtTmp.Columns["CHON"].ReadOnly = false;
            dtTmp.Columns["MS_DANG_XUAT"].ReadOnly = true;
            dtTmp.Columns["TEN_DX"].ReadOnly = true;
            grdDXuat.DataSource = dtTmp;
            grvDXuat.OptionsBehavior.Editable = true;

            grvDXuat.PopulateColumns();
            grvDXuat.OptionsView.ColumnAutoWidth = true;
            grvDXuat.OptionsView.AllowHtmlDrawHeaders = true;
            grvDXuat.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvDXuat.BestFitColumns();


        }

        private void txtFast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45) e.Handled = true; 
            //if (e.KeyChar == 45) e.KeyChar = (char)0;
        }

        private void txtSlow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45) e.Handled = true; 

        }

        private void txtNon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45) e.Handled = true; 
        }

        private Boolean  KiemTra()
        {            
            double So1, So2, So3;
            if (txtNon.Text == "") So1 = 0; else So1 = double.Parse(txtNon.Text);
            if (txtSlow.Text == "") So2 = 0; else So2 = double.Parse(txtSlow.Text);
            if (txtFast.Text == "") So3 = 0; else So3 = double.Parse(txtFast.Text);

            if (So1 > So2)
            {
                txtNon.Focus();
                return false;
            }
            if (So1 > So3)
            {
                txtNon.Focus();
                return false;
            }
            if (So2 > So3)
            {
                txtSlow.Focus();
                return false;
            }
            return true;
        }

        private void txtFast_Validating(object sender, CancelEventArgs e)
        {
            //if (!KiemTra()) e.Cancel = true;
        }

        private void txtSlow_Validating(object sender, CancelEventArgs e)
        {
            //if (!KiemTra()) e.Cancel = true;
        }

        private void txtNon_Validating(object sender, CancelEventArgs e)
        {
            //if (!KiemTra()) e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DateTime TNgay,DNgay;
            if (datTNgay.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "ChuaNhapTuNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return;
            }
            if (datDNgay.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "ChuaNhapDenNgay", Commons.Modules.TypeLanguage));
                datDNgay.Focus();
                return;
            }
            TNgay = datTNgay.DateTime;
            DNgay = datDNgay.DateTime;
            if (TNgay > DNgay)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "TNgayLonHonDNgay", Commons.Modules.TypeLanguage));
                datTNgay.Focus();
                return;
            }
            if (cboKho.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "ChuaChonKho", Commons.Modules.TypeLanguage));
                cboKho.Focus();
                return;
            }
            if (txtFast.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "ChuaNhapFast", Commons.Modules.TypeLanguage));
                txtFast.Focus();
                return;
            }
            if (txtSlow.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "ChuaNhapSlow", Commons.Modules.TypeLanguage));
                txtSlow.Focus();
                return;
            }
            if (txtNon.Text == "")
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "ChuaNhapNon", Commons.Modules.TypeLanguage));
                txtNon.Focus();
                return;
            }
            if (!KiemTra())
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "KiemLaiCacGiaTri", Commons.Modules.TypeLanguage));
                //txtFast.Focus();
                return;
            }
            DataTable dtTmp = (grdDXuat.DataSource as DataTable).Copy();
            ReportHuda.Forms.frmTKVTChuaXuat frm = new ReportHuda.Forms.frmTKVTChuaXuat();
            string sql;
            sql = "";
            frm._sDXuat = "";
            dtTmp.DefaultView.RowFilter = "CHON = TRUE";
            if (dtTmp.DefaultView.ToTable().Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "ChuaChonDangXuat", Commons.Modules.TypeLanguage));
                return;
            }
            else
            {
                for (int i = 0; i <= dtTmp.DefaultView.ToTable().Rows.Count -1; i++)
                {
                    if ((Boolean)dtTmp.Rows[i]["CHON"])
                    {
                        sql = sql + " , " + dtTmp.Rows[i]["MS_DANG_XUAT"].ToString();
                        frm._sDXuat = frm._sDXuat + " ; " + dtTmp.Rows[i]["TEN_DX"].ToString();
                    }
                
                }
            }
            int MsKho;
            double N, S, F;
            frm._sDXuat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "ucFastSlowNonMovingAnalysic", "CacDangXuat", Commons.Modules.TypeLanguage) + " : " +
                frm._sDXuat.Substring (3,frm._sDXuat.Length -3) ;

            MsKho = (int)cboKho.EditValue;
            N = double.Parse(txtNon.Text);
            S = double.Parse(txtSlow.Text);
            F = double.Parse(txtFast.Text);


            sql = sql.Substring(3, sql.Length-3);

            sql = " SELECT     ROW_NUMBER() OVER (ORDER BY A.MS_PT, dbo.IC_PHU_TUNG.TEN_PT, dbo.IC_PHU_TUNG.TEN_PT_VIET) AS STT , " +
                    " A.MS_PT, dbo.IC_PHU_TUNG.TEN_PT, dbo.IC_PHU_TUNG.TEN_PT_VIET, dbo.IC_PHU_TUNG.MS_PT_NCC, dbo.IC_PHU_TUNG.MS_PT_CTY, " +
                    " dbo.IC_PHU_TUNG.QUY_CACH, A.TONG_TON, A.TAN_XUAT, A.TSL, A.PHAN_LOAI, A.VI_TRI FROM (" +
                    " SELECT DISTINCT dbo.VI_TRI_KHO_VAT_TU.MS_PT, TONG_TON, A.TAN_XUAT, B.SLX AS TSL, " +
                    "                       dbo.MGetFastSlowNon(A.TAN_XUAT, " + N + ", " + S + ", " +  F + ") AS PHAN_LOAI,  " +
                    "                       dbo.MGetViTri(dbo.VI_TRI_KHO_VAT_TU.MS_PT, dbo.VI_TRI_KHO_VAT_TU.MS_KHO) AS VI_TRI " +
                    " FROM         dbo.VI_TRI_KHO_VAT_TU LEFT JOIN  " +
                    " 	(SELECT MS_PT , SUM(dbo.VI_TRI_KHO_VAT_TU.SL_VT) AS TONG_TON FROM dbo.VI_TRI_KHO_VAT_TU  " +
                    " 		WHERE MS_KHO = " + MsKho + "  GROUP BY MS_PT ) C   " +
                    " 	ON C.MS_PT = dbo.VI_TRI_KHO_VAT_TU.MS_PT  " +
                    " LEFT JOIN ( " +
                    " SELECT     COUNT(dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT) AS TAN_XUAT, dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT " +
                    " FROM         dbo.IC_DON_HANG_XUAT_VAT_TU INNER JOIN " +
                    "                       dbo.IC_DON_HANG_XUAT ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT " +
                    " WHERE     (dbo.IC_DON_HANG_XUAT.MS_KHO = " + MsKho + ") AND (dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT  " +
                    " 	IN ( " + sql + " )) AND (dbo.IC_DON_HANG_XUAT.NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND '" + DNgay.ToString("MM/dd/yyyy") + "' ) " +
                    " GROUP BY dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT) AS A ON A.MS_PT = dbo.VI_TRI_KHO_VAT_TU.MS_PT LEFT JOIN " +
                    "                           ( " +
                    "                           SELECT     SUM(convert(float, dbo.IC_DON_HANG_XUAT_VAT_TU.SO_LUONG_THUC_XUAT)) AS SLX, dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT " +
                    " FROM         dbo.IC_DON_HANG_XUAT_VAT_TU INNER JOIN " +
                    "                       dbo.IC_DON_HANG_XUAT ON dbo.IC_DON_HANG_XUAT_VAT_TU.MS_DH_XUAT_PT = dbo.IC_DON_HANG_XUAT.MS_DH_XUAT_PT " +
                    " WHERE     (dbo.IC_DON_HANG_XUAT.MS_KHO = " + MsKho + ") AND (dbo.IC_DON_HANG_XUAT.MS_DANG_XUAT  " +
                    " 	IN (" + sql + " )) AND (dbo.IC_DON_HANG_XUAT.NGAY BETWEEN '" + TNgay.ToString("MM/dd/yyyy") + "' AND  '" + DNgay.ToString("MM/dd/yyyy") + "' ) " +
                    " GROUP BY dbo.IC_DON_HANG_XUAT_VAT_TU.MS_PT " +
                    "                           ) AS B ON B.MS_PT = dbo.VI_TRI_KHO_VAT_TU.MS_PT " +
                    " WHERE     (dbo.VI_TRI_KHO_VAT_TU.SL_VT > 0)  " +
                    " AND MS_KHO = " + MsKho + "  ) A  INNER JOIN dbo.IC_PHU_TUNG ON A.MS_PT = dbo.IC_PHU_TUNG.MS_PT " +
                    " ORDER BY A.MS_PT, dbo.IC_PHU_TUNG.TEN_PT, dbo.IC_PHU_TUNG.TEN_PT_VIET ";
            dtTmp = new DataTable();
            dtTmp.Load (SqlHelper.ExecuteReader (Commons.IConnections.ConnectionString ,CommandType.Text ,sql));

            frm.TableSource = dtTmp;
            frm._iBaoCao = 2;

            frm._dNgay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "TuNgay", Commons.Modules.TypeLanguage) + " : " + TNgay.ToString("dd/MM/yyyy")   +
                " " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "DenNgay", Commons.Modules.TypeLanguage) + " : " + DNgay.ToString("dd/MM/yyyy");
            frm._sKho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucFastSlowNonMovingAnalysic", "Kho", Commons.Modules.TypeLanguage) + " : " + cboKho.Text;

            //Ghi chú: N: Non-Moving; S: Slow; F: Fast; VF: Very Fast
            frm._LoaiVT = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucFastSlowNonMovingAnalysic", "GhiChu", Commons.Modules.TypeLanguage) + " : " +
                    Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    "ucFastSlowNonMovingAnalysic", "NSFVF", Commons.Modules.TypeLanguage);

                    
            

            frm.ShowDialog(); 

        }

        private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            try
            {
                for (int i = 0; i < view.RowCount; i++)
                {
                    view.SetRowCellValue(i, "CHON", choose);
                }
            }
            catch { }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            ChooseAll(false, grvDXuat);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ChooseAll(true, grvDXuat);
        }
    }
}
