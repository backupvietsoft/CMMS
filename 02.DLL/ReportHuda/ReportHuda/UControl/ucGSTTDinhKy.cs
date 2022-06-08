using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Globalization;
using DevExpress.XtraEditors;
namespace ReportHuda
{
    public partial class ucGSTTDinhKy : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGSTTDinhKy()
        {
            InitializeComponent();
        }
        private void LoadDChuyen()
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, Commons.Modules.ObjSystems.MLoadDataDayChuyenTree(1), "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch (Exception ex){
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void LoadNX()
        {
            try
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetNhaXuongTreeList", false, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.MLoadCboTreeList(ref cmbNhaXuong, dt, "MS_CHA", "MS_N_XUONG", "TEN_N_XUONG");
                }
                catch(Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            LoadDChuyen();
        }
        private void LoadCatMachine()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            try
            {
                DataTable dtTmp = new DataTable();
                int iHThong = -1;
                string sNX = "-1";
                if (cboDChuyen.EditValue.ToString() != "-1") iHThong = int.Parse(cboDChuyen.EditValue.ToString());
                if (cmbNhaXuong.EditValue.ToString() != "-1") sNX = cmbNhaXuong.EditValue.ToString();

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLoaiMayTheoNXHTCoAll",
                    sNX, iHThong, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cmbCatmachine, dtTmp, "MS_LOAI_MAY", "TEN_LOAI_MAY", "");
            }
            catch { }
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "btnThoat", Commons.Modules.TypeLanguage);
            lblTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucGSTTDinhKy", "lblTuan", Commons.Modules.TypeLanguage);

        }
        private void LoadLoaiCV()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                string sSql = " SELECT T1.MS_LOAI_CV,T1.TEN_LOAI_CV FROM LOAI_CONG_VIEC T1 INNER JOIN NHOM_LOAI_CONG_VIEC T2 ON  T1.MS_LOAI_CV = T2.MS_LOAI_CV INNER JOIN USERS T3 ON T2.GROUP_ID = T3.GROUP_ID  WHERE USERNAME = 'admin'  UNION SELECT -1, ' < ALL > '  UNION SELECT -99, N'.Chưa phân loại'  ORDER BY TEN_LOAI_CV";
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiCV, dtTmp, "MS_LOAI_CV", "TEN_LOAI_CV", "");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());

            }
        }
        public void LoadNhomMay()
        {
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = Commons.Modules.ObjSystems.MLoadDataNhomMay(1, cmbCatmachine.EditValue.ToString());
            }
            catch 
            {
                dtTmp = Commons.Modules.ObjSystems.MLoadDataNhomMay(1,"-1");
            }
            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboNhomThietBiBTDK, dtTmp, "MS_NHOM_MAY", "TEN_NHOM_MAY", "");
        }
        private void GetDataGS()
        {
            int day = DateTime.DaysInMonth(cmbYear.DateTime.Year, cmbYear.DateTime.Month);
            DataTable _table = new DataTable();
            DataTable _tableMain = new DataTable();
            DateTime dTNgay, dDNgay, Ngay;
            DateTime original = cmbYear.DateTime;
            if (optInTheoThangNam.SelectedIndex == 1)
            {
                Ngay = Convert.ToDateTime("01/" + cmbYear.DateTime.Month + "/" + cmbYear.DateTime.Year);
                dTNgay = Ngay;
                dDNgay = Ngay.AddMonths(1).AddDays(-1);

            }
            else if (optInTheoThangNam.SelectedIndex == 2)
            {
                Ngay = Convert.ToDateTime("01/01/" + cmbYear.DateTime.Year);
                dTNgay = Ngay;
                dDNgay = Ngay.AddMonths(11).AddDays(30);
            }
            else
            {
                Ngay = Convert.ToDateTime(cboTuan.Text.Split(' ')[2].Split('_')[0]);
                dTNgay = Ngay;
                dDNgay = Ngay.AddDays(6);
            }
            try
            {
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetBCGSTTDenHanKiemTra", Commons.Modules.UserName, Commons.Modules.TypeLanguage, dTNgay.Date, dDNgay.Date, cmbNhaXuong.EditValue, cboDChuyen.EditValue, -1, cmbCatmachine.EditValue,CboNhomThietBiBTDK.EditValue, "-1", cboLoaiCV.EditValue, optInTheoThangNam.SelectedIndex));

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }

            if (_table.Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "Khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _tableMain.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM dbo.DON_VI_THOI_GIAN_MAU ORDER BY MS_DV_TG"));
            Colgate.frmMaintaince_Colgate frm = new Colgate.frmMaintaince_Colgate();
            DataRow _row = _table.NewRow();
            frm.inTheoThangNam = optInTheoThangNam.SelectedIndex;
            frm.iLoad = 3;
            string date = "";
            if (optInTheoThangNam.SelectedIndex == 1)
            {
                for (int i = 1; i <= day; i++)
                {
                    date = cmbYear.DateTime.DayOfWeek.ToString().Substring(0, 1) + "_" + i + "!" + cmbYear.DateTime.DayOfWeek.ToString().Substring(0, 3).ToLower();
                    //DOI TEN COLUM
                    _table.Columns[6 + i].ColumnName = date;
                    frm._tableSource.Columns.Add(date);
                    cmbYear.DateTime = cmbYear.DateTime.AddDays(1);
                    _row[date] = i;
                }
                try
                {
                    _row["MS_N_XUONG"] = "";
                    _row["MS_MAY"] = "";
                    _row["TEN_MAY"] = "";
                    _row["TEN_BO_PHAN"] = "";
                    _row["TEN_TS_GSTT"] = "";
                    _row["CHU_KY_DO"] = "";
                    _row["NGAY_KT_CUOI"] = "01/01/2019";
                    _table.Rows.Add(_row);
                    _table.DefaultView.Sort = "MS_N_XUONG";
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }

            }
            cmbYear.DateTime = original;
            frm.inTheoThangNam = optInTheoThangNam.SelectedIndex;
            frm._tableSource = _table;
            frm._tableMaintaince = _tableMain;
            frm.date = optInTheoThangNam.SelectedIndex == 2 ? cmbYear.DateTime.ToString("yyy") : optInTheoThangNam.SelectedIndex == 1 ? cmbYear.DateTime.ToString("MM/yyy") : (new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(DateTime.Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString());
            frm.sNX = lblNhaXuong.Text + " : " + cmbNhaXuong.TextValue;
            frm.sDC = lblDChuyen.Text + " : " + cboDChuyen.TextValue + "\n" + lblCatMachine.Text + " : " + cmbCatmachine.Text;
            frm.ShowDialog();
        }
        private void GetDataGSVF()
        {
            int day = DateTime.DaysInMonth(cmbYear.DateTime.Year, cmbYear.DateTime.Month);
            DataTable _table = new DataTable();
            DataTable _tableMain = new DataTable();
            DateTime dTNgay, dDNgay, Ngay;
            DateTime original = cmbYear.DateTime;
            if (optInTheoThangNam.SelectedIndex == 1)
            {
                Ngay = Convert.ToDateTime("01/" + cmbYear.DateTime.Month + "/" + cmbYear.DateTime.Year);
                dTNgay = Ngay;
                dDNgay = Ngay.AddMonths(1).AddDays(-1);

            }
            else if (optInTheoThangNam.SelectedIndex == 2)
            {
                Ngay = Convert.ToDateTime("01/01/" + cmbYear.DateTime.Year);
                dTNgay = Ngay;
                dDNgay = Ngay.AddMonths(11).AddDays(30);
            }
            else
            {
                Ngay = Convert.ToDateTime(cboTuan.Text.Split(' ')[2].Split('_')[0]);
                dTNgay = Ngay;
                dDNgay = Ngay.AddDays(6);
            }
            try
            {
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetBCGSTTDenHanKiemTraVF", Commons.Modules.UserName, Commons.Modules.TypeLanguage, dTNgay.Date, dDNgay.Date, cmbNhaXuong.EditValue, cboDChuyen.EditValue,-1, cmbCatmachine.EditValue,CboNhomThietBiBTDK.EditValue, "-1",cboLoaiCV.EditValue, optInTheoThangNam.SelectedIndex));
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            if (_table.Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "Khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _tableMain.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, "SELECT * FROM dbo.DON_VI_THOI_GIAN_MAU ORDER BY MS_DV_TG"));
            Colgate.frmMaintaince_Colgate frm = new Colgate.frmMaintaince_Colgate();
            DataRow _row = _table.NewRow();
            frm.inTheoThangNam = optInTheoThangNam.SelectedIndex;
            frm.iLoad = 3;
            string date = "";
            if (optInTheoThangNam.SelectedIndex == 1)
            {
                for (int i = 1; i <= day; i++)
                {
                    date = cmbYear.DateTime.DayOfWeek.ToString().Substring(0, 1) + "_" + i + "!" + cmbYear.DateTime.DayOfWeek.ToString().Substring(0, 3).ToLower();
                    //DOI TEN COLUM
                    _table.Columns[4 + i].ColumnName = date;
                    frm._tableSource.Columns.Add(date);
                    cmbYear.DateTime = cmbYear.DateTime.AddDays(1);
                    _row[date] = i;
                }
                try
                {
                    _row["MS_N_XUONG"] = "";
                    _row["MS_MAY"] = "";
                    _row["TEN_MAY"] = "";
                    _row["CHU_KY_DO"] = "";
                    _row["NGAY_KT_CUOI"] = "01/01/2019";
                    _table.Rows.Add(_row);
                    _table.DefaultView.Sort = "MS_N_XUONG";
                }
                catch(Exception ex){ XtraMessageBox.Show(ex.ToString()); }
            }
            cmbYear.DateTime = original;
            frm.inTheoThangNam = optInTheoThangNam.SelectedIndex;
            frm._tableSource = _table;
            frm._tableMaintaince = _tableMain;
            frm.date = optInTheoThangNam.SelectedIndex == 2 ? cmbYear.DateTime.ToString("yyy") : optInTheoThangNam.SelectedIndex == 1 ? cmbYear.DateTime.ToString("MM/yyy") : (new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(DateTime.Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString());
            frm.ShowDialog();
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (Commons.Modules.sPrivate == "VIFON")
                GetDataGSVF();
            else
                GetDataGS();
        }
        private string convertDateTime(string dateofweek)
        {
            switch (dateofweek.Substring(0, 3).ToLower())
            {
                case "mon":
                    return "H";
                case "tue":
                    return "B";
                case "wed":
                    return "T";
                case "thu":
                    return "N";
                case "fri":
                    return "S";
                case "sat":
                    return "B";
                case "sun":
                    return "CN";
            }
            return "";
        }

        private void ucMaintainMonth_Load(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "0LOAD";
            LoadNX();
            LoadTuan();
            Commons.Modules.SQLString = "";
            LoadCatMachine();
            LoadLoaiCV();
            LoadNhomMay();
            optInTheoThangNam.SelectedIndex = 0;
            optInTheoThangNam_SelectedIndexChanged(null, null);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cboDChuyen_EditValueChanged(object sender, MVControl.ucComboboxTreeList.EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            LoadCatMachine();
            Commons.Modules.SQLString = "";
        }

        private void optInTheoThangNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optInTheoThangNam.SelectedIndex == 0) //Tuần
            {
                tableLayoutPanel1.SetRow(cmbYear, 2);
                tableLayoutPanel1.SetColumn(cmbYear, 0);
                tableLayoutPanel1.SetRow(cboTuan, 2);
                tableLayoutPanel1.SetColumn(cboTuan, 2);
                cmbYear.Visible = false;
                cboTuan.Visible = true;
                lblTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "lblTuan", Commons.Modules.TypeLanguage);

            }
            else if (optInTheoThangNam.SelectedIndex == 1) //Tháng
            {
                tableLayoutPanel1.SetRow(cmbYear, 2);
                tableLayoutPanel1.SetColumn(cmbYear, 2);
                tableLayoutPanel1.SetRow(cboTuan, 3);
                tableLayoutPanel1.SetColumn(cboTuan, 0);
                cmbYear.Visible = true;
                cboTuan.Visible = false;
                lblTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "lblNgay", Commons.Modules.TypeLanguage);

                cmbYear.Properties.DisplayFormat.FormatString = "MM/yyyy";
                cmbYear.Properties.EditMask = "MM/yyyy";
                cmbYear.Properties.EditFormat.FormatString = "MM/yyyy";
                cmbYear.DateTime = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Year);
                cmbYear.MMonthYear = true;
            }
            else
            {
                tableLayoutPanel1.SetRow(cmbYear, 2);
                tableLayoutPanel1.SetColumn(cmbYear, 2);
                tableLayoutPanel1.SetRow(cboTuan, 3);
                tableLayoutPanel1.SetColumn(cboTuan, 0);
                cmbYear.Visible = true;
                cboTuan.Visible = false;
                lblTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "lblNam", Commons.Modules.TypeLanguage);

                cmbYear.Properties.DisplayFormat.FormatString = "yyyy";
                cmbYear.Properties.EditMask = "yyyy";
                cmbYear.Properties.EditFormat.FormatString = "yyyy";
                cmbYear.DateTime = DateTime.Now;
                cmbYear.MMonthYear = false;
            }
        }
        public void LoadTuan()
        {
            DataTable tb = new DataTable();
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.ConnectionString, "GetTUAN_TRONG_NAM", "01/01/" + DateTime.Now.Year.ToString(), "31/12/" + DateTime.Now.Year.ToString(), Commons.Modules.TypeLanguage).Tables[0];
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTuan, tb, "TUAN", "TEN_TUAN", "");
            try
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                cboTuan.EditValue = weekNum;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void cmbCatmachine_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
        }

    }
}
