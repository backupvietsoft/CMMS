using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace ReportHuda
{
    public partial class ucBangKePBT : DevExpress.XtraEditors.XtraUserControl
    {
        string sBC = "ucBangKePBT";
        public ucBangKePBT()
        {
            InitializeComponent();
        }
        #region Load Du Lieu


        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }

        private void LoadNX()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", false, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDDiem, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadDChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, _table, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");

            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, Commons.Modules.ObjSystems.MLoadDataLoaiMay(1), "MS_LOAI_MAY", "TEN_LOAI_MAY", lblLMay.Text);
            }
            catch { }
        }

        private void LoadLoaiBT()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetLoaiBaoTri"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLBTri, _table, "MS_LOAI_BT", "TEN_LOAI_BT", lblLBaoTri.Text);
            }
            catch { }
        }

        private void LoadMay()
        {
            if (Commons.Modules.SQLString == "0Load") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DateTime TNgay, DNgay;
                try
                { TNgay = datTNgay.DateTime; }
                catch { TNgay = DateTime.Parse("01/01/2000"); }
                try
                { DNgay = datDNgay.DateTime; }
                catch { DNgay = DateTime.Parse("01/01/2000"); }


                string NXuong = "-1";
                string LMay = "-1";
                int HThong = -1;
                try
                {
                    if (cboDDiem.TextValue == "") NXuong = "-1"; else NXuong = cboDDiem.EditValue.ToString();
                }
                catch
                { NXuong = "-1"; }

                try
                { if (cboLMay.Text == "") LMay = "-1"; else LMay = cboLMay.EditValue.ToString(); }
                catch { LMay = "-1"; }
                try
                { if (cboDChuyen.TextValue == "") HThong = -1; else HThong = int.Parse(cboDChuyen.EditValue.ToString()); }
                catch { HThong = -1; }

                DataTable dtMay = new DataTable();

                dtMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetMayNXuongHThongLMay", Commons.Modules.UserName, NXuong, HThong, -1, LMay, "-1", "-1",
                        DNgay, Commons.Modules.TypeLanguage));
                System.Data.DataColumn newColumn = new System.Data.DataColumn("CHON", typeof(System.Boolean));
                newColumn.DefaultValue = "1";
                dtMay.Columns.Add(newColumn);
                newColumn.SetOrdinal(0);

                dtMay.Columns["CHON"].ReadOnly = false;

                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dtMay, true, false, true, true, true, sBC);

                for (int i = 1; i <= grvMay.Columns.Count - 1; i++)
                {
                    grvMay.Columns[i].Visible = false;
                    dtMay.Columns[i].ReadOnly = true;
                }






                grvMay.Columns["MS_MAY"].Visible = true;
                grvMay.Columns["TEN_NHOM_MAY"].Visible = true;
                grvMay.Columns["TEN_LOAI_MAY"].Visible = true;
                grvMay.Columns["TEN_HE_THONG"].Visible = true;
                grvMay.Columns["Ten_N_XUONG"].Visible = true;
                grvMay.Columns["TEN_MAY"].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void ucBangKePBT_Load(object sender, EventArgs e)
        {
            try
            {//D:\00.Code\01.CMMS\00 CMMS Kho Moi V9\bin\Debug\reports\images\ucBangKePBT.jpg
                Commons.Modules.ObjSystems.Xoahinh(Application.StartupPath + @"\reports\images\ucBangKePBT.jpg");
            }
            catch { }
            Commons.Modules.SQLString = "0Load";
            DateTime Ngay;
            Ngay = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            datTNgay.DateTime = Ngay;
            datDNgay.DateTime = Ngay.AddMonths(1).AddDays(-1);
            LoadNX();
            LoadDChuyen();
            LoadLoaiMay();
            LoadLoaiBT();
            Commons.Modules.SQLString = "";
            LoadMay();
            grdChung.Visible = false;

        }
        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
        private void cboDDiem_EditValuedChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            LoadMay();
        }


        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            try
            {
                string dk = "";
                dtTmp = (DataTable)grdMay.DataSource;
                if (txtTKiem.Text.Length != 0) dk = " MS_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_NHOM_MAY LIKE '%" + txtTKiem.Text + "%' OR TEN_LOAI_MAY LIKE '%" +
                    txtTKiem.Text + "%' OR TEN_HE_THONG LIKE '%" + txtTKiem.Text + "%' OR Ten_N_XUONG LIKE '%" + txtTKiem.Text + "%' OR TEN_MAY LIKE '%" + txtTKiem.Text + "%' ";
                dtTmp.DefaultView.RowFilter = dk;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMay);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMay);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (datDNgay.DateTime < datTNgay.DateTime)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgTuNgayLonHonDenNgay",
                    Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                datDNgay.Focus();
                return;
            }
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = ((DataTable)grdMay.DataSource).Copy();
                dtTmp.DefaultView.RowFilter = "CHON = TRUE ";
                if (dtTmp.DefaultView.ToTable().Rows.Count == 0 && int.Parse(cboLBTri.EditValue.ToString()) != -2)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgChuaChonMay", Commons.Modules.TypeLanguage));
                    return;
                }


this.Cursor = Cursors.WaitCursor;


                string sBTam;
                sBTam = "MAY_BK_CV_BT_TMP" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTam, dtTmp, "");

                SqlConnection conn = new SqlConnection(Commons.IConnections.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 999999;
                if (optBCao.SelectedIndex == 0) cmd.CommandText = "spBangKeCongViecBaoTri"; else cmd.CommandText = "spBangKeTGNM";
                cmd.Parameters.Add(new SqlParameter("@MayTmp", sBTam));
                cmd.Parameters.Add(new SqlParameter("@MsLBTri", cboLBTri.EditValue));
                cmd.Parameters.Add(new SqlParameter("@TNgay", datTNgay.DateTime.Date));
                cmd.Parameters.Add(new SqlParameter("@DNgay", datDNgay.DateTime.Date));
                cmd.Parameters.Add(new SqlParameter("@NNgu", Commons.Modules.TypeLanguage));
                try
                {
                    dtTmp = new DataTable();
                    dtTmp.Load(cmd.ExecuteReader());
                }
                catch (Exception EX)
                {
                    this.Cursor = Cursors.Default;
                    XtraMessageBox.Show(EX.Message.ToString());
                    return;
                }
                if (dtTmp.Rows.Count == 0)
                {
                    this.Cursor = Cursors.Default;
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, sBC, "msgKhongCoDuLieu", Commons.Modules.TypeLanguage), sBC);
                    this.Cursor = Cursors.Default;
                    return;
                }



                ReportHuda.Colgate.frmMaintaince_Colgate frm = new Colgate.frmMaintaince_Colgate();
                frm._tableSource = dtTmp;
                frm.iLoad = 1;
                if (optBCao.SelectedIndex == 0) frm.iLoad = 1; else frm.iLoad = 2;
                frm.ShowDialog();

                ////////////this.Cursor = Cursors.Default;
                ////////////DataTable dt = new DataTable();
                ////////////dt = dtTmp.Clone();
                ////////////Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dt, false, true, true, true, true, sBC);
                ////////////if (optBCao.SelectedIndex == 0) InDuLieuPBT(dtTmp); else InDuLieuTGNM(dtTmp);


            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
            
        }



        private void datDNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadMay();
        }
    }
}
