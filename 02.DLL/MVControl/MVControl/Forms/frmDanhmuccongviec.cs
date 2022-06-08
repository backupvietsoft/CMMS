using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using Commons.VS.Classes.Catalogue;
namespace MVControl
{
    public partial class frmDanhmuccongviec : XtraForm
    {
        //int mscm;
        int rowhandle = 0;
        int xacnhan_btn = -1;
        public string MS_CVIEC = "-1";
        public frmDanhmuccongviec()
        {
            InitializeComponent();
        }

        private void sbtn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LockData(bool blnLock)
        {
            txt_motaCV.Properties.ReadOnly = blnLock;
            txtE_kihieuCV.Properties.ReadOnly = blnLock;
            TxtPATH_HD.Properties.ReadOnly = blnLock;
            mm_cachthuochien.Properties.ReadOnly = blnLock;
            spE_songthamgia.Properties.ReadOnly = blnLock;
            mm_yeucaudungcu.Properties.ReadOnly = blnLock;
            mm_yeucaunhansu.Properties.ReadOnly = blnLock;
            spE_thoigianchuan.Properties.ReadOnly = blnLock;
            mm_tieuchuankiemtra.Properties.ReadOnly = blnLock;
            mm_ghichu.Properties.ReadOnly = blnLock;
            chxAnToan.Enabled = !blnLock;        
            cbb_bactho.Enabled = !blnLock;
            BtnBacTho.Enabled = !blnLock;
            cbb_yeucauchuyenmon.Enabled = !blnLock;
            BtnChuyenmon.Enabled = !blnLock;
            cbb_thuocloaicongviec.Enabled = !blnLock;
            BtnLoaiCV.Enabled = !blnLock;
            cbb_thuocloaithietbi.Enabled = !blnLock;
            BtnLoaiTB.Enabled = !blnLock;
            GrdDanhmuccongviec.Enabled = blnLock;
            cbb_loai_thietbi.Enabled = blnLock;
            cbb_congviec.Enabled = blnLock;
            txtE_timkiem.Enabled = blnLock;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel5.ColumnStyles[0].Width = 0;
            tableLayoutPanel5.ColumnStyles[tableLayoutPanel5.ColumnCount - 1].Width = 0;

            fLoad = true;
            //tableLayoutPanel2.Enabled = true; = false;
            TxtMS_CV.Hide();
            loadthietbi();
            loadcongviec();
            load_cbb_thuocloaithietbi();
            load_cbb_yeucauchuyenmon();
            load_cbb_loaicongviec();
            
            load_cbb_bactho();
            loadgridfull(-1);
            cbb_thuocloaithietbi.Enabled = false;
            cbb_bactho.Enabled = false;
            cbb_thuocloaicongviec.Enabled = false;
            cbb_yeucauchuyenmon.Enabled = false;
            BtnBacTho.Enabled = false;
            BtnChuyenmon.Enabled = false;
            BtnLoaiCV.Enabled = false;
            BtnLoaiTB.Enabled = false;
            TxtPATH_HD.Enabled = false;
            chxAnToan.Enabled = false;
            
            Commons.Modules.ObjSystems.DinhDang();
            btnGhi.Hide();
            btnKhongghi.Hide();
            Commons.Modules.PermisString = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, "GetNHOM_FORM_QUYEN", Commons.Modules.UserName, this.Name));
            if (Commons.Modules.PermisString.Equals("Read only"))
            {
                btnThem.Enabled = false;
                btnMerge.Enabled = false;
                btnCTruc.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                
            }
            else
            {
                btnThem.Enabled = true;
                btnMerge.Enabled = true;
                btnCTruc.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }


            if ((MS_CVIEC.Equals("-1")))
            {
                loadgridfull(-1);
                if (this.gridView_MoTaCongViec.RowCount > 0)
                {
                    gridView_MoTaCongViec.FocusedRowHandle = rowhandle;
                }
            }
            else
            {
                findCongViec();
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            LockData(true);
            fLoad = false;
            BtnLoaiTB.Text = "...";
            BtnChuyenmon.Text = "...";
            BtnLoaiCV.Text = "...";
            BtnBacTho.Text = "...";
            try
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : " + gridView_MoTaCongViec.RowCount.ToString();

            }
            catch
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : 0";
            }
        }


        public void loadthietbi()
        {
            DataTable dt_loaithietbi = new DataTable();
            dt_loaithietbi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_LOC_LOAI_MAY"));
            DataRow row = dt_loaithietbi.NewRow();
            row["TEN_LOAI_MAY"] = "";
            row["MS_LOAI_MAY"] = "-99";
            dt_loaithietbi.Rows.Add(row);
            dt_loaithietbi.DefaultView.Sort = "TEN_LOAI_MAY";
            dt_loaithietbi = dt_loaithietbi.DefaultView.ToTable();

            Commons.Modules.ObjSystems.MLoadLookUpEdit(cbb_loai_thietbi, dt_loaithietbi, "MS_LOAI_MAY", "TEN_LOAI_MAY", this.Name);
            cbb_loai_thietbi.EditValue = "-1";


        }



        public void loadcongviec()
        {
            DataTable dt1 = new DataTable();
            dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIEC_PQ", Commons.Modules.UserName));
            DataRow row = dt1.NewRow();
            row["TEN_LOAI_CV"] = " < ALL > ";
            row["MS_LOAI_CV"] = "-1";

            dt1.Rows.InsertAt(row, 0);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cbb_congviec, dt1, "MS_LOAI_CV", "TEN_LOAI_CV", "");
            cbb_congviec.EditValue = -1;


        }
        bool fLoad = false;
        public void loadgridfull(int iMS_CV)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCONG_VIEC_LOAI_MAY", cbb_loai_thietbi.EditValue, cbb_congviec.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));


            dt.PrimaryKey = new DataColumn[] { dt.Columns["MS_CV"] };


            Commons.Modules.ObjSystems.MLoadXtraGrid(GrdDanhmuccongviec, gridView_MoTaCongViec, dt, false, false, true, true, true, "");
            if (iMS_CV != -1)
            {
                int index = dt.Rows.IndexOf(dt.Rows.Find(iMS_CV));
                gridView_MoTaCongViec.FocusedRowHandle = gridView_MoTaCongViec.GetRowHandle(index);
            }
            try
            {
                gridView1_FocusedRowChanged(null, null);
            }
            catch { }
            try
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : " + gridView_MoTaCongViec.RowCount.ToString();

            }
            catch {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : 0";
            }

        }

        private void LUE_loai_thietbi_EditValueChanged(object sender, EventArgs e)
        {
            if (fLoad == true) return;
            loadgridfull(-1);
            ShowCongViec();

        }

        private void sbtn_thoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        public void load_cbb_thuocloaithietbi()
        {
            DataTable dt_loaithietbi = new DataTable();
            dt_loaithietbi.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_MAY_CV_PQ", Commons.Modules.UserName));
            DataRow row = dt_loaithietbi.NewRow();
            row["TEN_LOAI_MAY"] = "";
            row["MS_LOAI_MAY"] = "-99";
            dt_loaithietbi.Rows.Add(row);
            dt_loaithietbi.DefaultView.Sort = "TEN_LOAI_MAY";
            dt_loaithietbi = dt_loaithietbi.DefaultView.ToTable();
            
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cbb_thuocloaithietbi, dt_loaithietbi, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            cbb_thuocloaithietbi.EditValue = "-99";
        }
        public void load_cbb_yeucauchuyenmon()
        {
            DataTable dt1 = new DataTable();
            dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCHUYEN_MONs"));
            cbb_yeucauchuyenmon.Properties.DataSource = dt1;
            cbb_yeucauchuyenmon.Properties.DisplayMember = "TEN_CHUYEN_MON";
            cbb_yeucauchuyenmon.Properties.ValueMember = "MS_CHUYEN_MON";
        }

        public void ShowCongViec()
        {

            try
            {
                txt_motaCV.Text = gridView_MoTaCongViec.GetFocusedDataRow()["MO_TA_CV"].ToString();
                TxtMS_CV.Text = gridView_MoTaCongViec.GetFocusedDataRow()["MS_CV"].ToString();
                TxtPATH_HD.Text = gridView_MoTaCongViec.GetFocusedDataRow()["PATH_HD"].ToString();
                mm_cachthuochien.Text = gridView_MoTaCongViec.GetFocusedDataRow()["THAO_TAC"].ToString();
                spE_songthamgia.Text = gridView_MoTaCongViec.GetFocusedDataRow()["SO_NGUOI"].ToString();
                mm_yeucaudungcu.Text = gridView_MoTaCongViec.GetFocusedDataRow()["YEU_CAU_DUNG_CU"].ToString();
                mm_yeucaunhansu.Text = gridView_MoTaCongViec.GetFocusedDataRow()["YEU_CAU_NS"].ToString();
                spE_thoigianchuan.Text = gridView_MoTaCongViec.GetFocusedDataRow()["THOI_GIAN_DU_KIEN"].ToString();
                mm_tieuchuankiemtra.Text = gridView_MoTaCongViec.GetFocusedDataRow()["TIEU_CHUAN_KT"].ToString();
                mm_ghichu.Text = gridView_MoTaCongViec.GetFocusedDataRow()["GHI_CHU"].ToString();

                try
                {
                    cbb_bactho.EditValue = gridView_MoTaCongViec.GetFocusedDataRow()["MS_BAC_THO"].ToString() == "" ? Convert.ToInt32("99") : Convert.ToInt32(gridView_MoTaCongViec.GetFocusedDataRow()["MS_BAC_THO"].ToString());
                }
                catch { cbb_bactho.EditValue = "-1"; }

                try
                {
                    cbb_yeucauchuyenmon.EditValue = Convert.ToInt32(gridView_MoTaCongViec.GetFocusedDataRow()["MS_CHUYEN_MON"].ToString());
                }
                catch { cbb_yeucauchuyenmon.EditValue = -1; }
                try
                {
                    cbb_thuocloaicongviec.EditValue = Convert.ToInt16(gridView_MoTaCongViec.GetFocusedDataRow()["MS_LOAI_CV"].ToString());
                }
                catch { cbb_thuocloaicongviec.EditValue = Convert.ToInt16(-1); }
                cbb_thuocloaithietbi.EditValue = gridView_MoTaCongViec.GetFocusedDataRow()["MS_LOAI_MAY"].ToString();
                txtE_kihieuCV.Text = gridView_MoTaCongViec.GetFocusedDataRow()["KY_HIEU_CV"].ToString();
                chxAnToan.Checked = Convert.ToBoolean(gridView_MoTaCongViec.GetFocusedDataRow()["AN_TOAN"].ToString());
            }
            catch
            { }
        }

        public void load_cbb_loaicongviec()
        {
            DataTable dt1 = new DataTable();
            dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIEC_PQ", Commons.Modules.UserName));
            DataRow row = dt1.NewRow();
            row["TEN_LOAI_CV"] = "  ";
            row["MS_LOAI_CV"] = 99;

            dt1.Rows.Add(row);

            Commons.Modules.ObjSystems.MLoadLookUpEdit(cbb_thuocloaicongviec, dt1, "MS_LOAI_CV", "TEN_LOAI_CV", "");
            cbb_thuocloaicongviec.EditValue = Convert.ToInt32("99");
        }
        public void load_cbb_bactho()
        {
            DataTable dt_bactho = new DataTable();
            dt_bactho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetBAC_THOs"));
            DataRow row = dt_bactho.NewRow();
            row["TEN_BAC_THO"] = "  ";
            row["MS_BAC_THO"] = 99;
            dt_bactho.Rows.Add(row);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cbb_bactho, dt_bactho, "MS_BAC_THO", "TEN_BAC_THO", "");
            cbb_thuocloaicongviec.EditValue = Convert.ToInt32("99");

        }
        public void reset_end_load()
        {
            // edit show
            btnThem.Hide();
            btnSua.Hide();
            btnCTruc.Hide();
            btnMerge.Hide();
            btnXoa.Hide();
            btnGhi.Show();
            btnKhongghi.Show();
            btnThoat.Hide();

            cbb_bactho.Enabled = true;
            cbb_thuocloaicongviec.Enabled = true;
            cbb_thuocloaithietbi.Enabled = true;
            cbb_yeucauchuyenmon.Enabled = true;
            BtnBacTho.Enabled = true;
            BtnChuyenmon.Enabled = true;
            BtnLoaiCV.Enabled = true;
            BtnLoaiTB.Enabled = true;
            chxAnToan.Enabled = true;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            xacnhan_btn = 0;
            reset_text();
            reset_end_load();
            LockData(false);
            cbb_thuocloaithietbi.EditValue = "99";
            cbb_thuocloaicongviec.EditValue = Convert.ToInt16("99");
            cbb_bactho.EditValue = Convert.ToInt32("99");
            Commons.OSystems obj = new Commons.OSystems();
            TxtMS_CV.Text = obj.GetIDInteger("CV").ToString();
            txt_motaCV.Focus();
        }

        private void btnKhongghi_Click(object sender, EventArgs e)
        {
            reset_button();
            reset_enable();
            LockData(true);
            ShowCongViec();
        }

        public void reset_enable()
        {
            cbb_bactho.Enabled = false;
            cbb_thuocloaicongviec.Enabled = false;
            cbb_thuocloaithietbi.Enabled = false;
            cbb_yeucauchuyenmon.Enabled = false;
            BtnBacTho.Enabled = false;
            BtnChuyenmon.Enabled = false;
            BtnLoaiCV.Enabled = false;
            BtnLoaiTB.Enabled = false;
            chxAnToan.Enabled = false;
        }
        public void reset_button()
        {
            btnThem.Show();
            btnSua.Show();
            btnCTruc.Show();
            btnMerge.Show();
            btnXoa.Show();
            btnGhi.Hide();
            btnKhongghi.Hide();
            btnThoat.Show();
        }
        public bool isValidated()
        {

            if (string.IsNullOrEmpty(txt_motaCV.Text.Trim()))
            {
                txt_motaCV.Focus();

                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenGhi2", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            if (cbb_thuocloaicongviec.EditValue == null || cbb_thuocloaicongviec.EditValue.ToString() == "99" || string.IsNullOrEmpty(cbb_thuocloaicongviec.EditValue.ToString()))
            {
                cbb_thuocloaicongviec.Focus();
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "ChuaNhapLoaiCV", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValidated())
                {
                    DataTable dtTmp = new DataTable();

                    CONG_VIECInfo objCONG_VIECInfo = new CONG_VIECInfo();
                    CONG_VIECController objCONG_VIECController = new CONG_VIECController();
                    try
                    {
                        objCONG_VIECInfo.MO_TA_CV =  txt_motaCV.Text;
                        if (string.IsNullOrEmpty(cbb_bactho.Text.Trim()))
                        {
                            objCONG_VIECInfo.MS_BT = null;
                        }
                        else
                        {
                            objCONG_VIECInfo.MS_BT = cbb_bactho.EditValue.ToString();
                        }
                        if (string.IsNullOrEmpty(cbb_yeucauchuyenmon.Text.Trim()))
                        {
                            objCONG_VIECInfo.MS_CM = null;
                        }
                        else
                        {
                            objCONG_VIECInfo.MS_CM = cbb_yeucauchuyenmon.EditValue.ToString();
                        }
                        if (string.IsNullOrEmpty(cbb_thuocloaicongviec.Text.Trim()))
                        {
                            objCONG_VIECInfo.MS_LOAI_CV = -1;
                        }
                        else
                        {
                            objCONG_VIECInfo.MS_LOAI_CV = Convert.ToInt16(cbb_thuocloaicongviec.EditValue);
                        }
                        if (string.IsNullOrEmpty(cbb_thuocloaithietbi.Text.Trim()))
                        {
                            objCONG_VIECInfo.MS_LOAI_MAY = null;
                        }
                        else
                        {
                            objCONG_VIECInfo.MS_LOAI_MAY = cbb_thuocloaithietbi.EditValue.ToString();
                        }

                        if (chxAnToan.Checked == false)
                        {
                            objCONG_VIECInfo.AN_TOAN = 0;
                        }
                        else
                        {
                            objCONG_VIECInfo.AN_TOAN = 1;
                        }
                        //objCONG_VIECInfo.MA_CV = TxtMA_CV.Text;
                        objCONG_VIECInfo.PATH_HD = TxtPATH_HD.Text;
                        objCONG_VIECInfo.THAO_TAC = mm_cachthuochien.Text;

                        if (spE_songthamgia.Text.Length > 0)
                            objCONG_VIECInfo.SO_NGUOI = int.Parse(spE_songthamgia.EditValue.ToString());
                        else
                            objCONG_VIECInfo.SO_NGUOI = 0;
                        objCONG_VIECInfo.YEU_CAU_DUNG_CU = mm_yeucaudungcu.Text;
                        objCONG_VIECInfo.YEU_CAU_NS = mm_yeucaunhansu.Text;

                        objCONG_VIECInfo.TIEU_CHUAN_KT = mm_tieuchuankiemtra.Text;
                        objCONG_VIECInfo.GhiChu = mm_ghichu.Text;

                        objCONG_VIECInfo.MA_CV = TxtMS_CV.Text;
                        
                        objCONG_VIECInfo.KY_HIEU_CV = txtE_kihieuCV.EditValue.ToString();
                        objCONG_VIECInfo.MO_TA_CV = txt_motaCV.Text;

                        string sSql = "";
                        if (cbb_thuocloaithietbi.EditValue.ToString() == "99")
                        {
                            sSql = "SELECT * FROM CONG_VIEC WHERE MS_CV <> " + TxtMS_CV.Text + " AND MO_TA_CV = N'" + txt_motaCV.Text + "' " +
                                " AND MS_LOAI_CV = " + cbb_thuocloaicongviec.EditValue.ToString();
                        }
                        else
                        {
                            sSql = "SELECT * FROM CONG_VIEC WHERE MS_CV <> " + TxtMS_CV.Text + " AND MO_TA_CV = N'" + txt_motaCV.Text + "' " +
                                        " AND MS_LOAI_MAY = '" + cbb_thuocloaithietbi.EditValue.ToString() + "' AND MS_LOAI_CV = " + cbb_thuocloaicongviec.EditValue.ToString();
                        }

                        dtTmp = new DataTable();
                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                        if (dtTmp.Rows.Count > 0)
                        {
                            if (dtTmp.Rows.Count > 0)
                            {
                                string MsTTai = null;
                                try
                                {
                                    MsTTai = LblMotacongviec.Text + " - " + dtTmp.Rows[0][0].ToString();
                                }
                                catch
                                {
                                    MsTTai = "";
                                }

                                // Công việc của loại thiết bị này đã tồn tại, bạn vui lòng nhập công việc khác !
                                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgMO_TA_CV", Commons.Modules.TypeLanguage) + MsTTai, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.txt_motaCV.Focus();
                                this.txt_motaCV.SelectAll();
                                return;
                            }
                        }


                        if (xacnhan_btn == 1)
                        {
                            objCONG_VIECInfo.MS_CV = Convert.ToInt32(TxtMS_CV.Text.Trim());
                            objCONG_VIECInfo.THOI_GIAN_DU_KIEN = Convert.ToDouble(spE_thoigianchuan.EditValue);
                            objCONG_VIECController.UpdateCONG_VIEC(objCONG_VIECInfo, this.Name, this.Text);
                            if (TxtPATH_HD.Text != "")
                            {
                                if (!string.IsNullOrEmpty(TxtMS_CV.Text))
                                {
                                    string strduongDanTmp = Commons.Modules.ObjSystems.CapnhatTL(true, TxtMS_CV.Text);
                                    System.IO.Directory.Delete(strduongDanTmp, true);
                                }
                                Commons.Modules.ObjSystems.LuuDuongDan(strDuongDan, TxtPATH_HD.Text);
                            }
                        }
                        else if (xacnhan_btn == 0)
                        {
                            objCONG_VIECInfo.THOI_GIAN_DU_KIEN = Convert.ToDouble(spE_thoigianchuan.EditValue);
                            
                            objCONG_VIECInfo.MS_CV = int.Parse(TxtMS_CV.Text);
                            objCONG_VIECController.AddCONG_VIEC(objCONG_VIECInfo, this.Name);


                            string sql = null;
                            sql = "update cong_viec set mo_ta_cv_anh = N'" + Vietsoft.MCapNhapNgonNguAnhHoa.sNNgu + "' where ms_cv =N'" + TxtMS_CV.Text + "'";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sql);
                        }
                        if (TxtPATH_HD.Text != "")
                        {
                            Commons.Modules.ObjSystems.LuuDuongDan(strDuongDan, TxtPATH_HD.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    int iMsCV ;
                    try
                    {
                        int.TryParse(TxtMS_CV.Text, out iMsCV);
                        loadgridfull(iMsCV);
                    }
                    catch
                    {
                        loadgridfull(-1);
                    }
                    reset_text();
                    reset_button();
                    reset_enable();
                    LockData(true);
          
                    //for (int i = 0; i < gridView_MoTaCongViec.RowCount; i++)
                    //{
                    //    if ((gridView_MoTaCongViec.GetDataRow(i)["MS_CV"].ToString() == objCONG_VIECInfo.MS_CV.ToString()))
                    //    {
                    //        gridView_MoTaCongViec.FocusedRowHandle = i;
                    //        MS_CVIEC = "-1";
                    //        break;
                    //    }
                    //}
                    ShowCongViec();
                }
            }
            catch
            { }

        }
        public void reset_text()
        {
            txt_motaCV.Text = "";
            TxtPATH_HD.Text = "";
            txtE_kihieuCV.Text = "";
            mm_cachthuochien.Text = "";
            mm_ghichu.Text = "";
            mm_tieuchuankiemtra.Text = "";
            mm_yeucaudungcu.Text = "";
            mm_yeucaunhansu.Text = "";
            cbb_bactho.Properties.NullText = "";
            cbb_thuocloaicongviec.Properties.NullText = "";
            cbb_thuocloaithietbi.Properties.NullText = "";
            cbb_yeucauchuyenmon.Properties.NullText = "";
            chxAnToan.Checked = false;
            spE_thoigianchuan.Text = "0";
            spE_songthamgia.Text = "0";
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            xacnhan_btn = 1;
            cbb_bactho.Enabled = true;
            cbb_thuocloaicongviec.Enabled = true;
            cbb_yeucauchuyenmon.Enabled = true;
            reset_end_load();
            LockData(false);
            cbb_thuocloaithietbi.Enabled = true;
            txt_motaCV.Focus();            
        }

        public void findCongViec()
        {
            if (btnGhi.Visible == true)
                return;
            int iMsCV = -1;
            try
            { int.TryParse(MS_CVIEC, out iMsCV); }
            catch { iMsCV = -1; }
            loadgridfull(iMsCV);        
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string SQL = "";
            Commons.VS.Classes.Catalogue.CONG_VIECController objCONG_VIECController = new Commons.VS.Classes.Catalogue.CONG_VIECController();
            DialogResult traloi = System.Windows.Forms.DialogResult.No;
            SqlDataReader dtReader = default(SqlDataReader);
            if (gridView_MoTaCongViec.RowCount <= 0)
            {
                MessageBox.Show((Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa1", Commons.Modules.TypeLanguage)));
                return;
            }

            SQL = "SELECT * FROM MAY_LOAI_BTPN_CONG_VIEC WHERE MS_CV=" + TxtMS_CV.Text;
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL);
            while (dtReader.Read())
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage));
                //Interaction.MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa2", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, this.Text);
                dtReader.Close();
                return;
            }
            dtReader.Close();

            // Tăng thêm 21/04/2007
            SQL = "SELECT * FROM CAU_TRUC_THIET_BI_CONG_VIEC WHERE MS_CV=" + TxtMS_CV.Text;
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL);
            while (dtReader.Read())
            {

                // Công việc này đang được sử dụng trong cấu trúc thiết bị công việc ! Bạn không thể xóa !
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa6", Commons.Modules.TypeLanguage));
                //Interaction.MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa6", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, this.Text);
                dtReader.Close();
                return;
            }
            dtReader.Close();

            SQL = "SELECT * FROM KE_HOACH_TONG_CONG_VIEC WHERE MS_CV=" + TxtMS_CV.Text;
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL);
            while (dtReader.Read())
            {
                // Công việc này đang được sử dụng trong kế hoạch tổng công việc ! Bạn không thể xóa !
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa7", Commons.Modules.TypeLanguage));
                //Interaction.MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa7", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, this.Text);
                dtReader.Close();
                return;
            }
            dtReader.Close();

            SQL = "SELECT * FROM PHIEU_BAO_TRI_CONG_VIEC WHERE MS_CV=" + TxtMS_CV.Text;
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL);
            while (dtReader.Read())
            {
                // Công việc này đang được sử dụng trong công việc của phiếu bảo trì ! Bạn không thể xóa !
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa8", Commons.Modules.TypeLanguage));
                //Interaction.MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa8", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, this.Text);
                dtReader.Close();
                return;
            }
            dtReader.Close();

            SQL = "SELECT * FROM EOR_CONG_VIEC WHERE MS_CV=" + TxtMS_CV.Text;
            dtReader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL);
            while (dtReader.Read())
            {
                // Công việc này đang được sử dụng trong ROA ! Bạn không thể xóa !
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa9", Commons.Modules.TypeLanguage));
                //Interaction.MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa9", Commons.Modules.TypeLanguage), MsgBoxStyle.Exclamation, this.Text);
                dtReader.Close();
                return;
            }
            dtReader.Close();
            //Message(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,this.Name,"MsgQuyenXoa5",Commons.Modules.TypeLanguage));
            //traloi = Interaction.MsgBox(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa5", Commons.Modules.TypeLanguage), MsgBoxStyle.YesNo, this.Text);
            traloi = MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgQuyenXoa5", Commons.Modules.TypeLanguage), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.No)
                return;
            objCONG_VIECController.DeleteCONG_VIEC(Convert.ToInt32(TxtMS_CV.Text), this.Name);
            Commons.Modules.ObjSystems.Xoahinh(TxtPATH_HD.Text);
            //Refesh();
            int tmp = rowhandle;
            loadgridfull(-1);



            //-------------------------------------------------------



        }

        private void txtE_timkiem_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)(GrdDanhmuccongviec.DataSource);
            try
            {
                dt.DefaultView.RowFilter = " MO_TA_CV like '%" + txtE_timkiem.Text + "%' OR KY_HIEU_CV like '%" + txtE_timkiem.Text + "%'  " +
                    " OR Convert(MS_CV, 'System.String') LIKE '%" + txtE_timkiem.Text + "%' ";



            }
            catch
            {
                dt.DefaultView.RowFilter = "";

            }
            if (gridView_MoTaCongViec.RowCount == 0)
            {
                reset_text();
            }
            else
            {
                ShowCongViec();
            }
            try
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : " + gridView_MoTaCongViec.RowCount.ToString();

            }
            catch
            {
                lbT.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblTongSo", Commons.Modules.TypeLanguage) + " : 0";
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowCongViec();
        }

        private void cbb_congviec_EditValueChanged(object sender, EventArgs e)
        {
            if (fLoad == true) return;
            loadgridfull(-1);
            ShowCongViec();
        }

        string strDuongDan = "";
        public void LayDuongDan(string path)
        {
            string strPath_DH = "";
            strPath_DH = TxtPATH_HD.Text;
            strDuongDan = path;

            if (!string.IsNullOrEmpty(TxtMS_CV.Text))
            {
                string sLuu = "";
                string strduongDanTmp = Commons.Modules.ObjSystems.CapnhatTL(true, TxtMS_CV.Text);
                sLuu = strduongDanTmp + "\\" + "CV_" + TxtMS_CV.Text + Commons.Modules.ObjSystems.LayDuoiFile(strDuongDan);
                TxtPATH_HD.Text = sLuu;
            }
            
        }

        private void btnTaiLieu_Click(object sender, EventArgs e)
        {
            if (btnGhi.Visible == true)
            {

                OpenFileDialog ofdChonHinh = new OpenFileDialog();
                ofdChonHinh.ShowDialog();
                if (ofdChonHinh.FileName == "")
                {
                    TxtPATH_HD.Text = "";
                    return;
                }
                else
                    LayDuongDan(ofdChonHinh.FileName);
            }
            else
            {
                Commons.Modules.ObjSystems.OpenHinh(TxtPATH_HD.Text);
            }
        }

        private void TxtPATH_HD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Commons.Modules.ObjSystems.OpenHinh(TxtPATH_HD.Text);
        }

        private void BtnLoaiTB_Click(object sender, EventArgs e)
        {
            Report1.frmThietBi frm = new Report1.frmThietBi();
            frm.ShowDialog();
            load_cbb_thuocloaithietbi();
           
        }

        private void BtnLoaiCV_Click(object sender, EventArgs e)
        {
            Report1.frmLoaicongviec frmLoaicongviec = new Report1.frmLoaicongviec();
            frmLoaicongviec.ShowDialog();
            load_cbb_loaicongviec();

        }

        private void BtnChuyenmon_Click(object sender, EventArgs e)
        {

            Report1.frmChuyenmon frm = new Report1.frmChuyenmon();
            frm.ShowDialog();
            load_cbb_yeucauchuyenmon();
          
        }

        private void BtnBacTho_Click(object sender, EventArgs e)
        {
            Report1.frmBactho frmBactho = new Report1.frmBactho();
            frmBactho.ShowDialog();

            load_cbb_bactho();
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMS_CV.Text))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoCongViecMerge", Commons.Modules.TypeLanguage));
                return;
            }
            ReportHuda.frmMergeCongViec frm = new ReportHuda.frmMergeCongViec();
            frm.iMsCV = Convert.ToInt32(TxtMS_CV.Text);
            frm.sMsLMay = cbb_thuocloaithietbi.EditValue.ToString();
            frm.sTenCV = txt_motaCV.Text;
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            loadgridfull(-1);
        }

        private void btnCTruc_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtMS_CV.Text))
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongCoMSCV", Commons.Modules.TypeLanguage));
                TxtMS_CV.Focus();
                return;
            }
            Report1.frmPhuTungMay frm = new Report1.frmPhuTungMay();
            frm.iLoai = 2;
            frm.MsPT = TxtMS_CV.Text;
            frm.btnCtruc = btnCTruc;
            frm.ShowDialog();
        }

        private void txt_motaCV_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_motaCV.Text.Trim()))
                return;
            string sLoi = "";

            if (Vietsoft.MCapNhapNgonNguAnhHoa.Update(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblfrmDanhmuccongviec_Anh", Commons.Modules.TypeLanguage), "CONG_VIEC", "MO_TA_CV_ANH", " WHERE MS_CV = N'" + TxtMS_CV.Text + "'",out sLoi, "frmDanhmuccongviec") == false)
            {
                MessageBox.Show(sLoi);
            }
        }
        
    }
}

