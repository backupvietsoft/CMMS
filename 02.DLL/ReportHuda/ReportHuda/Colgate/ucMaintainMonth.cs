using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Globalization;
using DevExpress.XtraEditors;

namespace ReportHuda.Colgate
{
    public partial class ucMaintainMonth : DevExpress.XtraEditors.XtraUserControl
    {
        public ucMaintainMonth()
        {
            InitializeComponent();
        }
        private void LoadDChuyen()
        {
            try
            {
                DataTable _table = new DataTable();
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetHeThongTreeListAll", true, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadCboTreeList(ref cboDChuyen, _table, "MS_CHA", "MS_HE_THONG", "TEN_HE_THONG");
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
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
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
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
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "btnExecute", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmMaintaince_Colgate", "btnThoat", Commons.Modules.TypeLanguage);
            lblTuNgay.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "lblTuan", Commons.Modules.TypeLanguage);
        }

        private void GetData()
        {
            int day = DateTime.DaysInMonth(cmbYear.DateTime.Year, cmbYear.DateTime.Month);
            DataTable _table = new DataTable();
            //"01-01-" + cmbYear.Text , "12-31-" + cmbYear.Text
            DateTime dTNgay, dDNgay, Ngay;

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
                //tuần - chưa làm
                Ngay = Convert.ToDateTime(cboTuan.Text.Split(' ')[2].Split('_')[0]);
                dTNgay = Ngay;
                dDNgay = Ngay.AddDays(6);
            }
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "spGetBCLichBaoTriDinhKy", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                                        dTNgay.Date, dDNgay.Date, cmbNhaXuong.EditValue, cboDChuyen.EditValue, cmbCatmachine.EditValue, optLoaiBC.SelectedIndex));
            if (_table.Rows.Count == 0)
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucMaintainMonth", "Khongcodulieu", Commons.Modules.TypeLanguage), "Vietsoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable _table_NX = new DataTable();
            _table_NX = _table.DefaultView.ToTable("NHA_XUONG", true, "MS_N_XUONG", "TEN_N_XUONG");
            DataTable _table_May = new DataTable();
            DataTable _table_May_BT = new DataTable();
            DataTable _table_Mau = new DataTable();
            //bảng table mầu chứa những mầu có trong dữ liệu trừ những mầu đã có phiếu bảo trì
            _table_Mau = _table.DefaultView.ToTable(true, "THU_TU", "MS_LOAI_BT", "TEN_LOAI_BT", "R", "G", "B").AsEnumerable().Where(x => x.Field<int>("THU_TU").ToString() != "-1").CopyToDataTable();
            try
            {
                if (_table.DefaultView.ToTable(true, "THU_TU", "MS_LOAI_BT", "TEN_LOAI_BT", "R", "G", "B").AsEnumerable().Where(x => x.Field<int>("THU_TU").ToString() == "-1").CopyToDataTable().Rows.Count > 0)
                {//kiểm tra nếu có thứ tự = -1 thì thêm vào dòng tình trạng đã bảo trì
                    _table_Mau.Rows.Add(new Object[]{-1,-1,"Đã bảo trì",0,0,0});
                }
            }
            catch 
            {
                //XtraMessageBox.Show(ex.Message.ToString());
                //return;
            }
            frmMaintaince_Colgate frm = new frmMaintaince_Colgate();
            frm._tableMaintaince = _table_Mau;
            DataView dataView = new DataView(frm._tableMaintaince);
            dataView.Sort = "THU_TU";
            frm._tableMaintaince = dataView.ToTable();
            DataRow _row = frm._tableSource.NewRow();
            string date = "";
            DateTime original = cmbYear.DateTime;
            // DataColumn column;
            frm._tableSource.Columns.Add("Machine Name");
            frm._tableSource.Columns.Add("CHU_KY_DO");
            frm._tableSource.Columns.Add("NGAY_CUOI");
            CultureInfo viVn = new CultureInfo("vi-VN");

            if (optInTheoThangNam.SelectedIndex == 2)
            {
                for (int i = 1; i <= 12; i++)
                {
                    date = i.ToString();
                    frm._tableSource.Columns.Add(date);
                }
            }
            else if (optInTheoThangNam.SelectedIndex == 1)
            {
                for (int i = 1; i <= day; i++)
                {

                    date = cmbYear.DateTime.DayOfWeek.ToString().Substring(0, 1) + "_" + i + "!" + cmbYear.DateTime.DayOfWeek.ToString().Substring(0, 3).ToLower();
                    frm._tableSource.Columns.Add(date);
                    cmbYear.DateTime = cmbYear.DateTime.AddDays(1);
                    _row[date] = i;

                }
                frm._tableSource.Rows.Add(_row);

            }
            else
            {
                DateTime datetime = dTNgay;
                for (int i = 1; ; i++)
                {
                    if (datetime > dDNgay)
                    {
                        break;
                    }
                    date = "Tu!" + datetime.ToString("dd/MM");
                    frm._tableSource.Columns.Add(date);
                    datetime = datetime.AddDays(1);
                }
            }

            _row = frm._tableSource.NewRow();

            foreach (DataRow _row_nx in _table_NX.Rows)
            {
                _row["Machine Name"] = _row_nx[1];
                frm._tableSource.Rows.Add(_row);
                _table.DefaultView.RowFilter = "MS_N_XUONG='" + _row_nx[0] + "'";
                _table_May = _table.DefaultView.ToTable("MAY", true, "MS_MAY", "TEN_MAY");
                foreach (DataRow _rowMay in _table_May.Rows)
                {
                    _row = frm._tableSource.NewRow();
                    _table.DefaultView.RowFilter = "MS_N_XUONG='" + _row_nx[0] + "' AND MS_MAY ='" + _rowMay[0] + "'";
                    if (optInTheoThangNam.SelectedIndex != 1)
                    {
                        _table.DefaultView.Sort = "NGAY_KE ASC";
                    }

                    _table_May_BT = _table.DefaultView.ToTable("MAY", true, "MS_MAY", "TEN_MAY", "NGAY_KE", "CHU_KY", "NGAY_CUOI", "MS_LOAI_BT", "R", "G", "B", "THU_TU").AsEnumerable().OrderByDescending(r => r.Field<int>("THU_TU"))
                 .CopyToDataTable();
                    foreach (DataRow _row_BT in _table_May_BT.Rows)
                    {
                        //in theo năm đối với bảo trì tuần thì sort ngày asc ngày tuần nào thấp nhất thì lấy RGB insert vào và kiểm nếu có RGB rồi thì k lấy màu của tuần kế tiếp đè vào nữa
                        _row["Machine Name"] = _row_BT["MS_MAY"] + " - " + _row_BT["TEN_MAY"];
                        //kiem tra chuoi ton tai chi ky do hay chua
                        if (_row["CHU_KY_DO"].ToString().IndexOf(_row_BT["CHU_KY"].ToString()) == -1)
                        {
                            _row["CHU_KY_DO"] = _row["CHU_KY_DO"].ToString() + _row_BT["CHU_KY"] + "; ";

                        }


                        _row["NGAY_CUOI"] = _row_BT["NGAY_CUOI"];
                        if (optInTheoThangNam.SelectedIndex == 2)
                        {
                            int d = Convert.ToDateTime(_row_BT["NGAY_KE"]).Month;
                            if (_row[d + 2] == DBNull.Value || string.IsNullOrEmpty(_row[d + 2].ToString()))
                            {
                                _row[d + 2] = _row_BT["R"] + " " + _row_BT["G"] + " " + _row_BT["B"];
                            }
                        }
                        else if (optInTheoThangNam.SelectedIndex == 1)
                        {
                            int d = Convert.ToDateTime(_row_BT["NGAY_KE"]).Day;
                            _row[d + 2] = _row_BT["R"] + " " + _row_BT["G"] + " " + _row_BT["B"];
                        }
                        else
                        {
                            string d = Convert.ToDateTime(_row_BT["NGAY_KE"]).ToString("dd/MM");
                            _row["Tu!" + d] = _row_BT["R"] + " " + _row_BT["G"] + " " + _row_BT["B"];
                        }
                    }
                    _row["CHU_KY_DO"] = _row["CHU_KY_DO"].ToString().Remove(_row["CHU_KY_DO"].ToString().LastIndexOf(';'));
                    frm._tableSource.Rows.Add(_row);
                }
                _row = frm._tableSource.NewRow();
            }
            frm._tableSource.Columns.Add("Total");
            cmbYear.DateTime = original;
            frm.inTheoThangNam = optInTheoThangNam.SelectedIndex;
            frm.date = optInTheoThangNam.SelectedIndex == 2 ? cmbYear.DateTime.ToString("yyy") : optInTheoThangNam.SelectedIndex == 1 ? cmbYear.DateTime.ToString("MM/yyy") : (new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(DateTime.Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString());
            frm.sNX = lblNhaXuong.Text + " : " + cmbNhaXuong.TextValue;
            frm.sDC = lblDChuyen.Text + " : " + cboDChuyen.TextValue + "\n" + lblCatMachine.Text + " : " + cmbCatmachine.Text;
            
            frm.ShowDialog();

        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            GetData();
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
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
    }
}
