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
    public partial class ucBCTHThoiGianNgungMay : DevExpress.XtraEditors.XtraUserControl
    {
        public Boolean KgLoad = true;

        public ucBCTHThoiGianNgungMay()
        {
            InitializeComponent();
        }

        private void LoadNX()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetNhaXuong", Commons.Modules.UserName, "-1", "-1", "-1"));
                cboDDiem.Properties.ValueMember = "MS_N_XUONG";
                cboDDiem.Properties.DisplayMember = "TEN_N_XUONG";
                cboDDiem.Properties.DataSource = _table;
                cboDDiem.Properties.Columns.Clear();
                cboDDiem.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_N_XUONG"));
                cboDDiem.EditValue = "-1";

            }
            catch { }
        }
        private void LoadLoaiMay()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_LOAI_MAY,TEN_LOAI_MAY FROM LOAI_MAY UNION SELECT '-1',' < ALL > ' ORDER BY TEN_LOAI_MAY "));
                cboLMay.Properties.DataSource = _table;
                cboLMay.Properties.DisplayMember = "TEN_LOAI_MAY";
                cboLMay.Properties.ValueMember = "MS_LOAI_MAY";
                cboLMay.Properties.Columns.Clear();
                cboLMay.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_LOAI_MAY"));
                cboLMay.EditValue = "-1";
            }
            catch { }
        }
        private void LoadDayChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT MS_HE_THONG, TEN_HE_THONG FROM HE_THONG UNION SELECT -1,' < ALL > ' ORDER BY TEN_HE_THONG "));
                cboDChuyen.Properties.DataSource = _table;
                cboDChuyen.Properties.DisplayMember = "TEN_HE_THONG";
                cboDChuyen.Properties.ValueMember = "MS_HE_THONG";
                cboDChuyen.Properties.Columns.Clear();
                cboDChuyen.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_HE_THONG"));
                cboDChuyen.EditValue = -1;
            }
            catch { }
        }
        private void LoadMay()
        {
            try
            {
                if (KgLoad) return;
                DateTime TNgay, DNgay;
                try
                { TNgay = datTNgay.DateTime; }
                catch { TNgay = DateTime.Parse("01/01/2000"); }
                try
                { DNgay = datDNgay.DateTime; }
                catch { DNgay = DateTime.Parse("01/01/2050"); }
                if (TNgay > DNgay)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCTHThoiGianNgungMay", "TngayLonHonDNgay", Commons.Modules.TypeLanguage));
                    return;
                }

                string NXuong = "-1";
                string LMay = "-1";
                int HThong = -1;
                try
                {
                    if (cboDDiem.Text == "") NXuong = "-1"; else NXuong = cboDDiem.EditValue.ToString();
                }
                catch
                { }

                try
                { if (cboLMay.Text == "") LMay = "-1"; else LMay = cboLMay.EditValue.ToString(); }
                catch { }
                try
                { if (cboDChuyen.Text == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { }

                DataTable dtMay = new DataTable();
                dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "getMayTGNgungMay",
                            Commons.Modules.UserName, NXuong, LMay, HThong,TNgay,DNgay, Commons.Modules.TypeLanguage));

                for (int i = 1; i <= dtMay.Columns.Count - 1; i++)
                {
                    dtMay.Columns[i].ReadOnly = true;
                }
                dtMay.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dtMay, true, false, true, false);
                //A.Ten_N_XUONG, A.TEN_HE_THONG, A.TEN_LOAI_MAY
                grvChung.Columns["Ten_N_XUONG"].Visible = false;
                grvChung.Columns["TEN_HE_THONG"].Visible = false;
                grvChung.Columns["TEN_LOAI_MAY"].Visible = false;

                grvChung.Columns["CHON"].Width = 100;
                grvChung.Columns["MS_MAY"].Width = 200;

                grvChung.Columns["TEN_MAY"].Width = 400;

                try
                {
                    lblTSo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucBCTHThoiGianNgungMay", "lblTSo", Commons.Modules.TypeLanguage) + " : " + dtMay.Rows.Count + "   ";
                }
                catch { }
            }
            catch { }
        }

        private void ucBCTHThoiGianNgungMay_Load(object sender, EventArgs e)
        {
            try
            {
                KgLoad = true;
                DateTime Ngay;
                Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);

                datTNgay.DateTime = Ngay.AddMonths(-6);
                datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
                LoadNX();
                LoadLoaiMay();
                LoadDayChuyen();
                KgLoad = false;
                LoadMay();
                try
                {
                    grvChung.Columns["CHON"].Width = 100;
                    grvChung.Columns["MS_MAY"].Width = 200;
                    lblTSo.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        "ucBCTHThoiGianNgungMay", "lblTSo", Commons.Modules.TypeLanguage) + " : " + grvChung.RowCount.ToString() + "   ";
                }
                catch { lblTSo.Text = ""; }
            }
            catch { }

        }

       private void cboDDiem_EditValueChanged(object sender, EventArgs e)
       {
           LoadMay();
       }

       private void cboLMay_EditValueChanged(object sender, EventArgs e)
       {
           LoadMay();
       }

       private void cboDChuyen_EditValueChanged(object sender, EventArgs e)
       {
           LoadMay();
       }

       private void btnThoat_Click(object sender, EventArgs e)
       {
           this.ParentForm.Close();
       }

       private void btnAll_Click(object sender, EventArgs e)
       {
           ChooseAll(true, grvChung);
       }

       private void btnNo_Click(object sender, EventArgs e)
       {
           ChooseAll(false, grvChung);
       }
       private void ChooseAll(bool choose, DevExpress.XtraGrid.Views.Grid.GridView view)
       {
           try
           {
               for (int i = 0; i < view.RowCount; i++)
               {
                   view.SetRowCellValue(i, "CHON", choose);
                   view.UpdateCurrentRow();
               }
               
           }
           catch { }
           
       }

       private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
       {
           DataTable dtMay = new DataTable();
           try
           {
               string dk = "";
               dtMay = (DataTable)grdChung.DataSource;

               if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
               if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
               if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
               dtMay.DefaultView.RowFilter = dk;

           }
           catch { dtMay.DefaultView.RowFilter = ""; }
       }

       private void btnExecute_Click(object sender, EventArgs e)
       {
           try
           {
               string sql;
               DataTable dtMay = new DataTable();
               dtMay = ((DataTable)grdChung.DataSource).Copy();
               dtMay.DefaultView.RowFilter = "CHON = TRUE ";
               if (dtMay.DefaultView.ToTable().Rows.Count == 0)
               {
                   MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCTHThoiGianNgungMay", "KhongChonMay", Commons.Modules.TypeLanguage));
                   return;
               }

               

               string sBTam;
               sBTam = "MAY_TGNM_TMP" + Commons.Modules.UserName;
               Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtMay, "");

               DateTime TNgay, DNgay;
               TNgay = Convert.ToDateTime("01/" + datTNgay.Text);
               DNgay = Convert.ToDateTime("01/" + datDNgay.Text).AddMonths (1).AddDays (-1);



               sql = " SELECT DISTINCT TGNM.MS_MAY, A.TEN_MAY, TGNM.NGAY, CONVERT(NVARCHAR(10), TGNM.TU_GIO, 108) AS TU_GIO, " +
                           " 		TGNM.DEN_NGAY, CONVERT(NVARCHAR(10), TGNM.DEN_GIO, 108) AS DEN_GIO,  " +
                           " 		TGNM.THOI_GIAN_SUA_CHUA, B.HIEN_TUONG, D.TEN_NGUYEN_NHAN AS NGUYEN_NHAN, B.NGUYEN_NHAN_CU_THE, B.NGUOI_GIAI_QUYET, TGNM.MS_PHIEU_BAO_TRI, TGNM.GHI_CHU,  " +
                           " 		A.TEN_LOAI_MAY, A.TEN_HE_THONG, A.Ten_N_XUONG " +
                           " FROM    dbo.THOI_GIAN_NGUNG_MAY AS TGNM INNER JOIN " +
                           " 		dbo.THOI_GIAN_NGUNG_MAY_SO_LAN AS B ON TGNM.MS_LAN = B.MS_LAN AND TGNM.MS_MAY = B.MS_MAY INNER JOIN " +
                           " 		dbo.NGUYEN_NHAN_DUNG_MAY AS D ON TGNM.MS_NGUYEN_NHAN = D.MS_NGUYEN_NHAN INNER JOIN " +
                           " 		(SELECT * FROM " + sBTam + " WHERE ISNULL(CHON,0) = 1 ) AS A ON A.MS_MAY = TGNM.MS_MAY " +
                           " WHERE     (TGNM.NGAY BETWEEN  '" + TNgay.ToString("yyyyMMdd") + "' AND '" + DNgay.ToString("yyyyMMdd") + "' ) ";

               frmBCTHThoiGianNgungMay frm = new frmBCTHThoiGianNgungMay();
               frm._dtChung = new DataTable();
               frm._dtChung.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sql));

               Commons.Modules.ObjSystems.XoaTable(sBTam);

               frm._Ngay = lblFromDate.Text + " : " + datTNgay.Text + " " + lblFromDate.Text + " : " + datDNgay.Text;
               frm._DDiem = lblDiaDiem.Text + " : " + cboDDiem.Text;
               frm._LMay = lblLoaiMay.Text + " : " + cboLMay.Text;
               frm._DChuyen = lblDChuyen.Text + " : " + cboDChuyen.Text;

               frm.ShowDialog();
           }
           catch {
               MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBCTHThoiGianNgungMay", "InKhongThanhCong", Commons.Modules.TypeLanguage));

           }
       }

       private void datTNgay_EditValueChanged(object sender, EventArgs e)
       {
           LoadMay(); 
       }

       private void datDNgay_EditValueChanged(object sender, EventArgs e)
       {
           LoadMay();
       }
    }
}
