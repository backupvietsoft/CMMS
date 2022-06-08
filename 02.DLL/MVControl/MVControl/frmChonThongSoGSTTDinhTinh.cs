using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MVControl
{
    public partial class frmChonThongSoGSTTDinhTinh : DevExpress.XtraEditors.XtraForm
    {
        //List<GiamSatTinhTrangTS> listtr = new List<GiamSatTinhTrangTS>();
        string sBTamGiaTri = "GIA_TRI_TMP" + Commons.Modules.UserName;
        DataTable dtGTTS = new DataTable();
        public frmChonThongSoGSTTDinhTinh()
        {
            InitializeComponent();
        }
        private void LoadNX()
        {
            try
            {
                KiemApp.MLoadCboTreeList(ref cboDDiem, Commons.Modules.ObjSystems.MLoadDataNhaXuongTree(1), "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
            }
            catch { }
          
        }

        private void LoadDChuyen()
        {
            try
            {
                //Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
                KiemApp.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch { }
        }

        private void LoadLoaiMay()
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetLoaiMayTheoNXHTCoAll", (cboDDiem.TextValue == "" ? "-1" : cboDDiem.EditValue), (cboDChuyen.TextValue == "" ? "-1" : cboDChuyen.EditValue), Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                    Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLMay, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
                }
                catch { }
            }
            catch { }
        }

        private void LoadMay()
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboLMay.Text.ToString())) return;
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetMayTheoLMNXHT", Commons.Modules.UserName, (cboLMay.Text == "" ? "-1" : cboLMay.EditValue), "-1", (cboDDiem.TextValue == "" ? "-1" : cboDDiem.EditValue), (cboDChuyen.TextValue == "" ? "-1" : cboDChuyen.EditValue), 0, 0));
                    //Commons.Modules.ObjSystems.MLoadLookUpEdit(cboThietbi, dt, "MS_MAY", "MS_MAY", "");
                    //Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboThietbi, dt, "MS_MAY", "TEN_MAY", "");

                    cboThietbi.Properties.DataSource = dt;
                    cboThietbi.Properties.DisplayMember = "TEN_MAY";
                    cboThietbi.Properties.ValueMember = "MS_MAY";
                    cboThietbi.EditValue = dt.Rows[0][0];

                    cboThietbi.Properties.View.Columns["MS_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "MS_MAY", Commons.Modules.TypeLanguage);
                    cboThietbi.Properties.View.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "TEN_MAY", Commons.Modules.TypeLanguage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch { }
        }

        private void cboDChuyen_EditValuedChanged(object sender, ucComboboxTreeList.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                LoadLoaiMay();
            }
            catch { }
        }

        private void cboLoaithietbi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboDChuyen.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboDDiem.TextValue.ToString())) return;
                if (string.IsNullOrEmpty(cboLMay.Text.ToString())) return;
                LoadMay();
            }
            catch { }
        }
        //loại công việc
        public void LoadCViec()
        {
            string s = " Select T1.MS_LOAI_CV,T1.TEN_LOAI_CV FROM LOAI_CONG_VIEC T1 INNER JOIN NHOM_LOAI_CONG_VIEC T2 On " +
                " T1.MS_LOAI_CV = T2.MS_LOAI_CV INNER JOIN USERS T3 On T2.GROUP_ID = T3.GROUP_ID " +
                " WHERE USERNAME = '" + Commons.Modules.UserName + "' " +
                " UNION SELECT -1, ' < ALL > '  UNION SELECT -99, N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "sDN", Commons.Modules.TypeLanguage) + "' " +
                " ORDER BY TEN_LOAI_CV";

            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, s));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiCV, dt, "MS_LOAI_CV", "TEN_LOAI_CV", "");


        }

        #region load form
        private void frmChonThongSoGSTTDinhTinh_Load(object sender, EventArgs e)
        {
            dtNgay.EditValue = DateTime.Now;
            Commons.Modules.SQLString = "0Load";
            
            LoadNX();
            LoadDChuyen();
            LoadCViec();
            LoadLoaiMay();
            Commons.Modules.SQLString = "";
            TaoTree();
            //nếu là remington thì hiện lên button all B
            if(Commons.Modules.sPrivate == "REMINGTON")
            {
                btnAllB.Visible = true;
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        //load tree view thiết bị
        private void TaoTree()
        {
            if (Commons.Modules.SQLString == "0Load") return;

            DataTable dtTmp = new DataTable();
            if (chkHangMucDenHangGS.Checked == false)
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCTTBThongSoGSTTDT", (string.IsNullOrEmpty(cboThietbi.Text) ? "-1" : cboThietbi.EditValue), cboLoaiCV.EditValue));
            }
            else
            {
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetCTTBThongSoDenNgay", (string.IsNullOrEmpty(cboThietbi.Text) ? "-1" : cboThietbi.EditValue), cboLoaiCV.EditValue, dtNgay.EditValue));
            }
            grdDanhsachTSGSTT.DataSource = null;
            tvGiamsat.KeyFieldName = "MS_BO_PHAN";
            tvGiamsat.ParentFieldName = "MS_BO_PHAN_CHA";
            tvGiamsat.DataSource = dtTmp;
            tvGiamsat.Columns["TEN_BO_PHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Text, "TEN_BO_PHAN", Commons.Modules.TypeLanguage);
            tvGiamsat.Columns["MS_TS_GSTT"].Visible = false;
            tvGiamsat.Columns["MSBP"].Visible = false;
            tvGiamsat.ExpandAll();
        }
        #endregion

        static DataTable ConvertToDatatable(List<GiamSatTinhTrangTS> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CHON", typeof(Boolean));
            dt.Columns.Add("TEN_GIA_TRI", typeof(string));
            dt.Columns.Add("DAT", typeof(Boolean));
            dt.Columns.Add("GHI_CHU", typeof(string));
            dt.Columns.Add("MS_MAY", typeof(string));
            dt.Columns.Add("MS_TS_GSTT", typeof(string));
            dt.Columns.Add("MSBP", typeof(string));

            foreach (var item in list)
            {
                dt.Rows.Add(item.CHON, item.TEN_GIA_TRI, item.DAT, item.GHI_CHU, item.MS_MAY, item.MS_TS_GSTT, item.MS_BO_PHAN);
            }
            return dt;
        }

        private GiamSatTinhTrangTS GetEmpDataTableRow(DataRow dr)
        {
            GiamSatTinhTrangTS oEmp = new GiamSatTinhTrangTS();
            oEmp.TEN_GIA_TRI = dr["TEN_GIA_TRI"].ToString();
            oEmp.CHON = Boolean.Parse(dr["CHON"].ToString());
            oEmp.DAT = Boolean.Parse(dr["DAT"].ToString());
            return oEmp;
        }
        private void cboThietbi_EditValueChanged(object sender, EventArgs e)
        {
            TaoTree();
        }
        private void btnAllOK_Click(object sender, EventArgs e)
        {
            XtraMessageBoxForm frm = new XtraMessageBoxForm();
            if (chkHangMucDenHangGS.Checked == true)
            {
                CapNhapDuLieuDenHan(true,0);
            }
            else
            {
                CapNhapDuLieu(true,0);
            }
        }
        private void CapNhapDuLieu(Boolean bCoMay,int allB)
        {
            string sMsNX, sMsHT, sMsLM, sMsMay, sMsBP, sMsTS, sSql;
            int iLCV = -1;
            try { sMsNX = cboDDiem.EditValue.ToString(); }
            catch
            { sMsNX = "-1"; }

            try { sMsHT = cboDChuyen.EditValue.ToString(); }
            catch
            { sMsHT = "-1"; }

            try { sMsLM = cboLMay.EditValue.ToString(); }
            catch
            { sMsLM = "-1"; }

            try { sMsMay = cboThietbi.EditValue.ToString(); }
            catch
            { sMsMay = "-1"; }

            try { sMsBP = tvGiamsat.FocusedNode["MSBP"].ToString(); }
            catch
            { sMsBP = "-1"; }

            try { sMsTS = tvGiamsat.FocusedNode["MS_TS_GSTT"].ToString(); }
            catch
            { sMsTS = "-1"; }

            try { iLCV = int.Parse(cboLoaiCV.EditValue.ToString()); }
            catch
            { iLCV = -1; }


        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "getDSThongSoGS", sMsNX, sMsHT, sMsLM, (bCoMay ? sMsMay : "-1"), iLCV, Commons.Modules.UserName, chkDat.Checked, sBTamGiaTri,allB);
            LoadGTTS();
        }

        private void CapNhapDuLieuDenHan(Boolean bCoMay,int allB)
        {
            string sMsNX, sMsHT, sMsLM, sMsMay, sMsBP, sMsTS, sSql;
            int iLCV = -1;
            try { sMsNX = cboDDiem.EditValue.ToString(); }
            catch
            { sMsNX = "-1"; }

            try { sMsHT = cboDChuyen.EditValue.ToString(); }
            catch
            { sMsHT = "-1"; }

            try { sMsLM = cboLMay.EditValue.ToString(); }
            catch
            { sMsLM = "-1"; }

            try { sMsMay = cboThietbi.EditValue.ToString(); }
            catch
            { sMsMay = "-1"; }

            try { sMsBP = tvGiamsat.FocusedNode["MSBP"].ToString(); }
            catch
            { sMsBP = "-1"; }

            try { sMsTS = tvGiamsat.FocusedNode["MS_TS_GSTT"].ToString(); }
            catch
            { sMsTS = "-1"; }

            try { iLCV = int.Parse(cboLoaiCV.EditValue.ToString()); }
            catch
            { iLCV = -1; }
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "getDSThongSoGSDenHan", sMsNX, sMsHT, sMsLM, (bCoMay ? sMsMay : "-1"), iLCV, Commons.Modules.UserName, chkDat.Checked, dtNgay.DateTime, sBTamGiaTri,allB);
            LoadGTTS();

        }
        private string getpattree()
        {
            List<string> danhsachcacnode = new List<string>();
            string s = "";
            try
            {
                var nodes = tvGiamsat.Selection;
                List<string> values = new List<string>();
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in nodes)
                {
                    TreeListNode resulst = node;
                    do
                    {
                        if (resulst.ParentNode is Nullable)
                        {
                            danhsachcacnode.Add(resulst.GetValue("TEN_BO_PHAN").ToString());
                            break;
                        }
                        else
                        {
                            danhsachcacnode.Add(resulst.GetValue("TEN_BO_PHAN").ToString());
                            resulst = resulst.ParentNode;
                        }
                    } while (!(resulst.ParentNode is Nullable));
                }
            }
            catch (Exception)
            {
            }
            s="";
            for (int i = danhsachcacnode.Count; i >= 0; i--)
            {
                try
                {
                    s +="/"+ danhsachcacnode[i].ToString();

                }
                catch (Exception)
                {
                    
                }
            }
            return s;
        }
        private void tvGiamsat_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            LoadGTTS();
            tvGiamsat.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            tvGiamsat.Appearance.FocusedCell.BackColor = System.Drawing.Color.CornflowerBlue;
            txtDuongdan.Text = getpattree();
        }
        private void LoadGTTS()
        {
            string sMsTS = "-1";
            string sMsMay = "-1";
            string sMsBP = "-1";
            string sSql;
            try { sMsTS = tvGiamsat.FocusedNode["MS_TS_GSTT"].ToString(); }
            catch
            { sMsTS = "-1"; }

            try { sMsMay = cboThietbi.EditValue.ToString(); }
            catch
            { sMsMay = "-1"; }

            try { sMsBP = tvGiamsat.FocusedNode["MSBP"].ToString(); }
            catch
            { sMsBP = "-1"; }

            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetGiaTriThongSo", sMsMay, sMsBP, sMsTS, sBTamGiaTri));
            dtTmp.Columns["CHON"].ReadOnly = false;
            grdDanhsachTSGSTT.DataSource = null;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdDanhsachTSGSTT, grvDanhsachTSGSTT, dtTmp, true, true, true, true, true, this.Name);
                //grvDanhsachTSGSTT.Columns[i].e = false;
                dtTmp.Columns["TEN_GIA_TRI"].ReadOnly = true;

            grvDanhsachTSGSTT.Columns["STT"].Visible = false;
            grvDanhsachTSGSTT.Columns["MS_MAY"].Visible = false;
            grvDanhsachTSGSTT.Columns["MS_TS_GSTT"].Visible = false;
            grvDanhsachTSGSTT.Columns["MS_BO_PHAN"].Visible = false;
            grvDanhsachTSGSTT.Columns["MS_TT"].Visible = false;
            grvDanhsachTSGSTT.Columns["DAT"].Visible = false;
            grvDanhsachTSGSTT.Columns["THOI_GIAN"].Visible = false;
            grvDanhsachTSGSTT.Columns["TG_TT"].Visible = false;

            //grvDanhsachTSGSTT.Columns["TG_TT"].DisplayFormat.FormatString = Commons.Modules.ObjSystems.sDinhDangSoLe(0);
            //grvDanhsachTSGSTT.Columns["TG_TT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        private void chkDenHan_CheckedChanged(object sender, EventArgs e)
        {
            dtNgay.Enabled = chkHangMucDenHangGS.Checked;
            cboThietbi_EditValueChanged(null, null);
        }
        System.Collections.Generic.List<string> arrTim = new System.Collections.Generic.List<string>();
        private void txtTenBoPhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Commons.Modules.ObjSystems.HTimXtraTreeList(txtTenBoPhan.Text, tvGiamsat, "MS_BO_PHAN", "TEN_BO_PHAN", ref arrTim);
        }

        private void grvDanhsachTSGSTT_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            grvDanhsachTSGSTT.UpdateCurrentRow();
            if (view.FocusedColumn.FieldName.ToUpper() == "CHON")
            {
                string sMsTS = "-1";
                string sMsMay = "-1";
                string sMsBP = "-1";
                //string sGhiChu = "";
                Boolean bDat = false;
                int iSTTGT = -1;
                string sSql;

                try { sMsTS = tvGiamsat.FocusedNode["MS_TS_GSTT"].ToString(); }
                catch
                { sMsTS = "-1"; }

                try { sMsMay = cboThietbi.EditValue.ToString(); }
                catch
                { sMsMay = "-1"; }

                try { sMsBP = tvGiamsat.FocusedNode["MSBP"].ToString(); }
                catch
                { sMsBP = "-1"; }

                try { bDat = Boolean.Parse(grvDanhsachTSGSTT.GetFocusedRowCellValue("DAT").ToString()); }
                catch
                { bDat = false; }

                try { iSTTGT = int.Parse(grvDanhsachTSGSTT.GetFocusedRowCellValue("STT").ToString()); }
                catch
                { iSTTGT = -1; }
                //try { sGhiChu = grvDanhsachTSGSTT.GetFocusedRowCellValue("GHI_CHU").ToString(); }
                //catch
                //{ iSTTGT = -1; }
                //sSql = "UPDATE " + sBTamGiaTri + " SET  GHI_CHU = N'" + sGhiChu + "' WHERE MS_MAY= N'" + sMsMay + "' AND MS_BO_PHAN = N'" + sMsBP + "' AND MS_TS_GSTT = N'" + sMsTS + "'  AND STT = " + iSTTGT.ToString();
                //SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                if (Boolean.Parse(e.Value.ToString()))
                {
                    //kiểm tra xem trong bảng tạm có giá trị theo đạt hay chưa(nếu dạt =1 thì where bằng 0 <>)
                    sSql = "SELECT TOP 1 * FROM  " + sBTamGiaTri + " WHERE MS_MAY= N'" + sMsMay + "' AND MS_BO_PHAN = N'" + sMsBP + "' AND MS_TS_GSTT = N'" + sMsTS + "' AND DAT = " + (bDat ? 0 : 1) + " AND ISNULL(CHON,0) = 1 AND STT <>  " + iSTTGT.ToString();
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    //có tồi tại rồi thì không cho check
                    if (dt.Rows.Count > 0)
                    {
                        if (bDat == true)
                            //không cho chọn giá trị đạt
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgDat", Commons.Modules.TypeLanguage), this.Text);
                        else
                            //không thể chọn giá trị không đạt vì đã tồn tại giá trị đạt
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKhongDat", Commons.Modules.TypeLanguage), this.Text);
                        e.Value = !Boolean.Parse(e.Value.ToString());
                        grvDanhsachTSGSTT.SetFocusedRowCellValue("CHON", !Boolean.Parse(e.Value.ToString()));

                        //cập nhật lại không check
                        sSql = "UPDATE " + sBTamGiaTri + " SET CHON = 0 WHERE MS_MAY= N'" + sMsMay + "' AND MS_BO_PHAN = N'" + sMsBP + "' AND MS_TS_GSTT = N'" + sMsTS + "'  AND STT = " + iSTTGT.ToString();
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                        return;
                    }
                }
                //cập nhật lại cột chọn trong bảng tạm
                sSql = "UPDATE " + sBTamGiaTri + " SET CHON = " + (Boolean.Parse(grvDanhsachTSGSTT.GetFocusedRowCellValue("CHON").ToString()) ? "0" : "1") + " WHERE MS_MAY= N'" + sMsMay + "' AND MS_BO_PHAN = N'" + sMsBP + "' AND MS_TS_GSTT = N'" + sMsTS + "'  AND STT = " + iSTTGT.ToString();
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
            }
        }
        private void btDatall_Click_1(object sender, EventArgs e)
        {
            if (chkHangMucDenHangGS.Checked)
            {
                //sử lý chọn all theo thông số đến hạn
                if (cboDChuyen.EditValue.ToString() == "-1" && cboDDiem.EditValue.ToString() == "-1" && cboLMay.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCanPhaiChonMotTrongBaDieuKienDeChonTatCa", Commons.Modules.TypeLanguage), this.Text);
                }
                else
                {
                    CapNhapDuLieuDenHan(false,0);
                }
            }
            else
            {
                //sử lý chọn all theo dây chuyền or địa điểm or mấy
                if (cboDChuyen.EditValue.ToString() == "-1" && cboDDiem.EditValue.ToString() == "-1" && cboLMay.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgBanCanPhaiChonMotTrongBaDieuKienDeChonTatCa", Commons.Modules.TypeLanguage), this.Text);
                }
                else
                {
                    CapNhapDuLieu(false,0);
                }
            }
        }
        //thoat
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //thuc hien

        private void BtnThucHien_Click(object sender, EventArgs e)
        {
            grvDanhsachTSGSTT_ValidateRow(grvDanhsachTSGSTT, null);
            DialogResult = DialogResult.OK;
            this.Close();
        }


        private void grvDanhsachTSGSTT_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DAT"]);
                if (category == "Checked")
                {
                    e.Appearance.ForeColor = Color.LimeGreen;
                    grvDanhsachTSGSTT.Appearance.FocusedCell.ForeColor = System.Drawing.Color.LimeGreen;
                    if (e.RowHandle == grvDanhsachTSGSTT.FocusedRowHandle)
                    {
                        grvDanhsachTSGSTT.Appearance.FocusedCell.ForeColor = System.Drawing.Color.LimeGreen;
                        grvDanhsachTSGSTT.Appearance.FocusedRow.ForeColor = System.Drawing.Color.LimeGreen;
                    }
                    else
                    {
                        grvDanhsachTSGSTT.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
                        grvDanhsachTSGSTT.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
                    }
                }
                else
                {
                    //e.Appearance.ForeColor = Color.Salmon;
                }
            }
        }

        private void grvDanhsachTSGSTT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            grvDanhsachTSGSTT.PostEditor(); 
            grvDanhsachTSGSTT.UpdateCurrentRow();
            int msthongso; string msmay; string msbp; string ghichu; int mstt; int sttgiatri;
            try
            {
                msthongso = int.Parse(grvDanhsachTSGSTT.GetFocusedRowCellValue("MS_TS_GSTT").ToString());
            }
            catch { msthongso = -1; }

            try
            {
                msmay = grvDanhsachTSGSTT.GetFocusedRowCellValue("MS_MAY").ToString();
            }
            catch { msmay = "-1"; }

            try
            {
                msbp = grvDanhsachTSGSTT.GetFocusedRowCellValue("MS_BO_PHAN").ToString();
            }
            catch { msbp = "-1"; }
            try
            {
                ghichu = grvDanhsachTSGSTT.GetFocusedRowCellValue("GHI_CHU").ToString();
            }
            catch { ghichu = "-1"; }
            try
            {
                mstt = int.Parse(grvDanhsachTSGSTT.GetFocusedRowCellValue("MS_TT").ToString());
            }
            catch { mstt = -1; }

            try
            {
                sttgiatri = int.Parse(grvDanhsachTSGSTT.GetFocusedRowCellValue("STT").ToString());
            }
            catch { sttgiatri = -1; }
            string query = "UPDATE " + sBTamGiaTri + " SET GHI_CHU = N'" + ghichu + "' WHERE MS_MAY ='" + msmay + "' AND MS_TS_GSTT =" + msthongso + " AND MS_BO_PHAN ='" + msbp + "' AND MS_TT = " + mstt + "AND STT = " + sttgiatri;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, query);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }

        private void btnAllB_Click(object sender, EventArgs e)
        {
            XtraMessageBoxForm frm = new XtraMessageBoxForm();
            if (chkHangMucDenHangGS.Checked == true)
            {
                CapNhapDuLieuDenHan(true,1);
            }
            else
            {
                CapNhapDuLieu(true,1);
            }
        }
    }

}
