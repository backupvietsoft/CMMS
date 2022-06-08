using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVControl
{
    public partial class FrmGSTT_CV : DevExpress.XtraEditors.XtraForm
    {
        string sBT = "BT_CVGS" + Commons.Modules.UserName;
        string sBTCV = "BT_CV" + Commons.Modules.UserName;
        bool themsua = false;
        DataTable tab_GSTT_CV = new DataTable();

        private void createtable()
        {
            tab_GSTT_CV.Columns.Add("CHON", typeof(bool));
            tab_GSTT_CV.Columns.Add("MS_TS_GSTT", typeof(int));
            tab_GSTT_CV.Columns.Add("MS_CV", typeof(int));
        }
        public FrmGSTT_CV()
        {
            InitializeComponent();
        }
        private void FrmGSTT_CV_Load(object sender, EventArgs e)
        {
            EnableButton(true);
            Loaddata();
            createtable();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void Loaddata()
        {
            LoadGrdGS(-1);
            LoadCbbLoaiMay();
        }
        private void LoadCbbLoaiMay()
        {
            DataTable dt1 = new DataTable();
            dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIEC_PQ", Commons.Modules.UserName));
            DataRow row = dt1.NewRow();
            row["TEN_LOAI_CV"] = " < ALL > ";
            row["MS_LOAI_CV"] = "-1";

            dt1.Rows.InsertAt(row, 0);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiCV, dt1, "MS_LOAI_CV", "TEN_LOAI_CV", "");
            cboLoaiCV.EditValue = -1;

        }
        private int GetLoaiTS()
        {
            if (optThongSo.SelectedIndex == 0) return -1;
            else if (optThongSo.SelectedIndex == 1) return 1;
            else return 0;
        }
        private void LoadGrdGS(int msgst)
        {
            try
            {
                int kieu = (btnGhi.Visible == false ? 0 : 1);
                grdTS.DataSource = null;
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetGiamSatTinhTrangCongViec", GetLoaiTS(), Commons.Modules.TypeLanguage, kieu, Commons.Modules.UserName));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MS_TS_GSTT"] };
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTS, grvTS, dt, false, true, true, true, true, this.Name);
                grvTS.Columns["MS_TS_GSTT"].Visible = false;
                if (msgst != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(msgst));
                    grvTS.FocusedRowHandle = grvTS.GetRowHandle(index);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void createBT(string sBT,DataTable tab_GSTT_CV)
        {
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, tab_GSTT_CV, "");
        }
        private void LoadGrdCV()
        {
            try
            {
                if (grdTS.DataSource == null) return;
                int kieu = (btnGhi.Visible == false ? 0 : 1);
                int msts;
                try
                {
                    msts = Convert.ToInt32(grvTS.GetFocusedRowCellValue("MS_TS_GSTT").ToString());
                }
                catch (Exception)
                {
                    msts = -1;
                }
                grdCV.DataSource = null;
                DataTable dt = new DataTable();
                if (kieu == 0)
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCongViecTheoThongSo", Commons.Modules.TypeLanguage, kieu, msts,Commons.Modules.UserName));
                }
                else
                {
                    //kiểm tra xem ms thông số có tồn tại trong table tạm
                    try
                    {
                        var n = tab_GSTT_CV.AsEnumerable().Where(x => x.Field<int>("MS_TS_GSTT") == Convert.ToInt32(grvTS.GetFocusedRowCellValue("MS_TS_GSTT"))).Count();
                        if (Convert.ToInt32(n) == 0)
                        {
                            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCongViecTheoThongSo", Commons.Modules.TypeLanguage, kieu, msts, Commons.Modules.UserName));
                        }
                        else
                        {//có bảng tạm
                            createBT(sBT,tab_GSTT_CV);
                            DataTable tempt = new DataTable();
                            tempt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCongViecTheoThongSo", Commons.Modules.TypeLanguage, kieu, msts, Commons.Modules.UserName));
                            createBT(sBTCV, tempt);
                            string sSQl = "SELECT CHON,MS_CV," + grvTS.GetFocusedRowCellValue("MS_TS_GSTT") + " AS MS_TS_GSTT,MS_LOAI_CV,MO_TA_CV FROM "+sBTCV+" WHERE MS_CV NOT IN (SELECT MS_CV FROM " + sBT+" WHERE MS_TS_GSTT = "+ grvTS.GetFocusedRowCellValue("MS_TS_GSTT") + ") UNION SELECT CHON,T1.MS_CV,MS_TS_GSTT,MS_LOAI_CV,MO_TA_CV FROM "+sBT+ " T1 INNER JOIN CONG_VIEC T2 ON T1.MS_CV = T2.MS_CV WHERE MS_TS_GSTT = "+grvTS.GetFocusedRowCellValue("MS_TS_GSTT") +" ORDER BY CHON DESC, MO_TA_CV ";
                            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,CommandType.Text,sSQl));
                        }
                    }
                    catch (Exception ex)
                    {
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCongViecTheoThongSo", Commons.Modules.TypeLanguage, kieu, msts, Commons.Modules.UserName));
                    }

                }
                if (kieu == 0)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdCV, grvCV, dt, false, false, true, true, true, this.Name);
                    grvCV.Columns["CHON"].Visible = false;
                }
                else
                {
                    dt.Columns["CHON"].ReadOnly = false;
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdCV, grvCV, dt, true, true, true, true, true, this.Name);
                    grvCV.Columns["MS_TS_GSTT"].Visible = false;
                }
                grvCV.Columns["MS_LOAI_CV"].Visible = false;
                grvCV.Columns["MS_CV"].Visible = false;
                TKLOAICV();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void optThongSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrdGS(-1);
        }
        private void EnableButton(bool resulst)
        {
            btnThemSua.Visible = resulst;
            btnThoat.Visible = resulst;

            btnChon.Visible = !resulst;
            btnUnSelect.Visible = !resulst;
            btnKhongGhi.Visible = !resulst;
            btnGhi.Visible = !resulst;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            EnableButton(false);
            try
            {
                LoadGrdGS(Convert.ToInt32(grvTS.GetFocusedRowCellValue("MS_TS_GSTT").ToString()));
            }
            catch (Exception)
            {
                LoadGrdGS(-1);
            }
            LoadGrdCV();
            themsua = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void btnChon_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvCV);
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvCV);
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            EnableButton(true);
            LoadGrdCV();
            LoadGrdGS(-1);
            themsua = false;
            try
            {
                Commons.Modules.ObjSystems.XoaTable(sBT);
                tab_GSTT_CV.Rows.Clear();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            int iMsTS;
            try
            {
                iMsTS = Convert.ToInt32(grvTS.GetFocusedRowCellValue("MS_TS_GSTT").ToString());
            }
            catch (Exception)
            {
                iMsTS = -1;
            }
            createBT(sBT,tab_GSTT_CV);
            string sSql = " INSERT INTO  GSTT_CV (MS_TS_GSTT,MS_CV) SELECT MS_TS_GSTT, MS_CV FROM " + sBT + " T1 " +
                " WHERE NOT EXISTS (SELECT * FROM GSTT_CV T2 WHERE T2.MS_TS_GSTT = T1.MS_TS_GSTT AND T2.MS_CV = T1.MS_CV) AND CHON = 1 " +
                " DELETE a FROM GSTT_CV a WHERE EXISTS(SELECT * FROM " + sBT + " b WHERE a.MS_TS_GSTT = b.MS_TS_GSTT AND a.MS_CV = b.MS_CV and  b.CHON = 0) ";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
            EnableButton(true);
            LoadGrdGS(iMsTS);
            LoadGrdCV();
            themsua = false;
            tab_GSTT_CV.Rows.Clear();
            Commons.Modules.ObjSystems.XoaTable(sBT);
            Commons.Modules.ObjSystems.XoaTable(sBTCV);
        }

        private void grvTS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadGrdCV();
        }

        private void grvCV_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (themsua == false) return;
            var gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gv.FocusedColumn.FieldName.ToUpper() == "CHON")
            {
                var n = tab_GSTT_CV.AsEnumerable().Where(x => x.Field<int>("MS_TS_GSTT") == Convert.ToInt32(grvCV.GetFocusedRowCellValue("MS_TS_GSTT")) && x.Field<int>("MS_CV") == Convert.ToInt32(grvCV.GetFocusedRowCellValue("MS_CV"))).Count();
                if(Convert.ToInt32(n) == 0)
                {
                    tab_GSTT_CV.Rows.Add(Convert.ToBoolean(grvCV.GetFocusedRowCellValue("CHON")), Convert.ToInt32(grvCV.GetFocusedRowCellValue("MS_TS_GSTT")), Convert.ToInt32(grvCV.GetFocusedRowCellValue("MS_CV")));
                }
                else
                {
                    var row = tab_GSTT_CV.AsEnumerable().Where(x => x.Field<int>("MS_TS_GSTT") == Convert.ToInt32(grvCV.GetFocusedRowCellValue("MS_TS_GSTT")) && x.Field<int>("MS_CV") == Convert.ToInt32(grvCV.GetFocusedRowCellValue("MS_CV"))).SingleOrDefault();
                    row["CHON"] = Convert.ToBoolean(grvCV.GetFocusedRowCellValue("CHON"));
                }
            }
        }
            
        private void txtTKTS_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)(grdTS.DataSource);
            try
            {
                dt.DefaultView.RowFilter = " TEN_TS_GSTT like '%" + txtTKTS.Text + "%'";
            }
            catch
            {
                dt.DefaultView.RowFilter = "";
            }
        }

        private void txtTKCV_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)(grdCV.DataSource);
            try
            {
                dt.DefaultView.RowFilter = " MO_TA_CV like '%" + txtTKCV.Text + "%'";
            }
            catch
            {
                dt.DefaultView.RowFilter = "";
            }
        }

        private void TKLOAICV()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)(grdCV.DataSource);
                try
                {
                    if (cboLoaiCV.EditValue.ToString() == "-1")
                        dt.DefaultView.RowFilter = "";
                    else
                        dt.DefaultView.RowFilter = " MS_LOAI_CV = " + cboLoaiCV.EditValue + "";
                }
                catch (Exception ex)
                {
                    dt.DefaultView.RowFilter = "";
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void cboLoaiCV_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrdCV();
            //add vào table tạm giá trị hiện tại
        }

    }
}
