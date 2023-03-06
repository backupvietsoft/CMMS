using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vs.Support.Commons;

namespace Vs.Support
{
    public partial class frmReportContract : Form
    {
        public string http = Program.http;
        public int NNgu = 0;

        DataTable dtNN = new DataTable();
        public frmReportContract( int NgonNgu)
        {
            InitializeComponent();
            NNgu = NgonNgu;
        }

        #region even
        private void frmReportContract_Load(object sender, System.EventArgs e)
        {
            dtNN = Program.GetDataNN(this.Name.ToString());

            txtTNgay.Text = DateTime.Now.AddMonths(-1).ToString();
            txtDNgay.Text = DateTime.Now.ToString();
            LoadCbo();
            LoadNNForm();
        }
        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void btnIn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboCustomerID.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaChonKhachHang", this.Name));
                    return;
                }
                if (string.IsNullOrEmpty(cboTypeID.Text.Trim()))
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgChuaChonLoaiHD", this.Name));
                    return;
                }
                DataTable dt = new DataTable();
                dt = API.getDataAPI(http + "Support/ReportContract?TNgay=" + Convert.ToDateTime(txtTNgay.Text).ToString("MM/dd/yyyy") + "&DNgay=" + Convert.ToDateTime(txtDNgay.Text).ToString("MM/dd/yyyy") + "&CustomerID=" + cboCustomerID.SelectedValue + "&TypeID=" + cboTypeID.SelectedValue + "&NNgu=" + NNgu + "");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(Program.GetNN(dtNN, "msgKhongCoDuLieu", this.Name));
                }
                LoadNNDataTable(dt);
                ExportDuLieu(dt);
            }
            catch
            { }
        }
        #endregion

        #region function
        private void LoadCbo()
        {
            try
            {
                DataTable dt = new DataTable();
                // getCustomer API
                dt = API.getDataAPI(http + "Support/getCustomer");
                cboCustomerID.DataSource = dt;
                cboCustomerID.ValueMember = "ID";
                cboCustomerID.DisplayMember = "ShortName";

                DataTable dt1 = new DataTable();
                dt1 = API.getDataAPI(http + "Support/GetContractType");
                cboTypeID.DataSource = dt1;
                cboTypeID.ValueMember = "ID";
                cboTypeID.DisplayMember = "Name";
            }
            catch
            {

            }
        }
        private void ExportDuLieu(DataTable dt)
        {
            string sPath = "";
            sPath = "";
            sPath = ExportExcel.SaveFiles("Excel file (*.xls)|*.xls");
            if (sPath == "") return;
            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks excelWorkbooks = xlApp.Workbooks;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int Dong = 0;
            int idong = dt.Rows.Count;
            int icot = dt.Columns.Count;
            try
            {
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excel.Range title;

                Dong = 1;
                //tao tieu de
                ExportExcel.DinhDang(xlWorkSheet, Program.GetNN(dtNN,  "lblTieuDe", this.Name), Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, icot, 21);

                Dong++;
                //Thongtin
                //lblTNgay
                ExportExcel.DinhDang(xlWorkSheet, lblTNgay.Text + " :", Dong, 2, "@", 11, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 2, 15);
                //Data lblTuNgay
                ExportExcel.DinhDang(xlWorkSheet, txtTNgay.Text, Dong, 3, "@", 11, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 3, 15);

                //lblDNgay
                ExportExcel.DinhDang(xlWorkSheet, lblDNgay.Text + " :", Dong, 6, "@", 11, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 6, 15);
                //Data lblDNgay
                ExportExcel.DinhDang(xlWorkSheet, txtTNgay.Text, Dong, 7, "@", 11, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, 7, 15);

                Dong++;
                //lblCustomerID
                ExportExcel.DinhDang(xlWorkSheet, lblCustomerID.Text + " :", Dong, 2, "@", 11, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, 2, 15);
                //Data CustomerID
                ExportExcel.DinhDang(xlWorkSheet, cboCustomerID.Text, Dong, 3, "@", 11, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, 3, 15);

                //lblTypeID
                ExportExcel.DinhDang(xlWorkSheet, lblTypeID.Text + " :", Dong, 6, "@", 11, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, 6, 15);
                //Data TypeID
                ExportExcel.DinhDang(xlWorkSheet, cboTypeID.Text, Dong, 7, "@", 11, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, false, Dong, 7, 15);

                Dong++;
                //tao du lieu table
                title = ExportExcel.GetRange(xlWorkSheet, Dong, 1, dt.Rows.Count + Dong, dt.Columns.Count);
                ExportExcel.MExportExcel(dt, xlWorkSheet, title, true);
                //fort mat columns header
                title = ExportExcel.GetRange(xlWorkSheet, Dong, 1, Dong, icot);
                title.Font.Bold = true;
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                Dong++;
                ExportExcel.ColumnWidth(xlWorkSheet, 16, "@", true, Dong, 1, Dong + idong, 1);
                ExportExcel.ColumnWidth(xlWorkSheet, 20, "dd/mm/yyyy", true, Dong, 2, Dong + idong, 2);
                ExportExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong, 3, Dong + idong, 3);
                ExportExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong, 4, Dong + idong, 4);
                ExportExcel.ColumnWidth(xlWorkSheet, 20, "dd/mm/yyyy", true, Dong, 5, Dong + idong, 5);
                ExportExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong, 6, Dong + idong, 6);
                ExportExcel.ColumnWidth(xlWorkSheet, 20, "dd/mm/yyyy", true, Dong, 7, Dong + idong, 7);
                ExportExcel.ColumnWidth(xlWorkSheet, 20, "@", true, Dong, 8, Dong + idong, 8);

                xlApp.Visible = true;
                xlWorkBook.SaveAs(sPath);
                ExportExcel.MReleaseObject(xlWorkSheet);
                ExportExcel.MReleaseObject(xlWorkBook);
                ExportExcel.MReleaseObject(xlApp);
            }
            catch
            {
                MessageBox.Show(Program.GetNN(dtNN, "msgInKhongThanhCong", this.Name));
            }
            this.Cursor = Cursors.Default;
        }
        private void LoadNNDataTable(DataTable dt)
        {
            dt.Columns["ContractNo"].ColumnName = Program.GetNN(dtNN, "lblContractNo", this.Name);
            dt.Columns["SignedDate"].ColumnName = Program.GetNN(dtNN, "lblSignedDate", this.Name);
            dt.Columns["NameSP"].ColumnName = Program.GetNN(dtNN, "lblNameSP", this.Name);
            dt.Columns["NumberofLicense"].ColumnName = Program.GetNN(dtNN, "lblNumberofLicense", this.Name);
            dt.Columns["AcceptanceDate"].ColumnName = Program.GetNN(dtNN, "lblAcceptanceDate", this.Name);
            dt.Columns["MainContractID"].ColumnName = Program.GetNN(dtNN, "lblMainContractID", this.Name);
            dt.Columns["ValidUntil"].ColumnName = Program.GetNN(dtNN, "lblValidUntil", this.Name);
            dt.Columns["Note"].ColumnName = Program.GetNN(dtNN, "lblNote", this.Name);

        }
        private void LoadNNForm()
        {
            this.lblTNgay.Text = Program.GetNN(dtNN, lblTNgay.Name, this.Name);
            this.lblDNgay.Text = Program.GetNN(dtNN, lblDNgay.Name, this.Name);
            this.lblCustomerID.Text = Program.GetNN(dtNN, lblCustomerID.Name, this.Name);
            this.lblTypeID.Text = Program.GetNN(dtNN, lblTypeID.Name, this.Name);
            this.btnIn.Text = Program.GetNN(dtNN, btnIn.Name, this.Name);
            this.btnThoat.Text = Program.GetNN(dtNN, btnThoat.Name, this.Name);
        }
        #endregion

    }
}
