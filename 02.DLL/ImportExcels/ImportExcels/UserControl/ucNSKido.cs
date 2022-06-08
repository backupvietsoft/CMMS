using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace ImportExcels.UserControl
{
    public partial class ucNSKido : DevExpress.XtraEditors.XtraUserControl
    {
        public ucNSKido()
        {
            InitializeComponent();
        }
        DataTable dtCN = new DataTable();

        private void LoadTinh()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "S_Tinh"));
            cmbCity.Properties.DataSource = _table;
            cmbCity.Properties.DisplayMember = "TEN_QG";
            cmbCity.Properties.ValueMember = "MA_QG";
            cmbCity.EditValue = "-1";

        }
        private void LoadDistrict()
        {
            DataTable _table = new DataTable();
            if (cmbCity.EditValue.ToString().Equals("-1"))
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT ma_qg,ten_qg FROM Y_DISTRICT WHERE MS_CHA='-1' UNION SELECT '-1','All'"));
            else
                _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString,
                    "S_District", cmbCity.EditValue.ToString()));
            cmbDistrict.Properties.DataSource = _table;
            cmbDistrict.Properties.DisplayMember = "ten_qg";
            cmbDistrict.Properties.ValueMember = "ma_qg";
            cmbDistrict.EditValue = "-1";
        }
        private void LoadNX()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "NHA_XUONG_DEVICE_INFO", "Administrator", cmbCity.EditValue.ToString(), cmbDistrict.EditValue, "-1"));
            cmbNhaXuong.Properties.ValueMember = "MS_N_XUONG";
            cmbNhaXuong.Properties.DisplayMember = "TEN_N_XUONG";
            cmbNhaXuong.Properties.DataSource = _table;
            cmbNhaXuong.EditValue = "-1";
        }

        private void LoadCatMachine()
        {
            DataTable _table = new DataTable();
            _table.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT MS_LOAI_MAY,TEN_LOAI_MAY FROM LOAI_MAY UNION SELECT '-1','All' ORDER BY TEN_LOAI_MAY "));
            cmbCatmachine.Properties.DataSource = _table;
            cmbCatmachine.Properties.DisplayMember = "TEN_LOAI_MAY";
            cmbCatmachine.Properties.ValueMember = "MS_LOAI_MAY";
            cmbCatmachine.EditValue = "-1";
        }

        private void cmbCity_EditValueChanged(object sender, EventArgs e)
        {
            LoadDistrict();
            LoadNX();
            LoadCatMachine();
        }

        private void cmbDistrict_EditValueChanged(object sender, EventArgs e)
        {
            LoadNX();
        }

        private void ucNSKido_Load(object sender, EventArgs e)
        {
            LoadTinh();
            LoadNX();
            LoadCatMachine();
            LoadCN();

            datFromDate.DateTime = Convert.ToDateTime("01/" + DateTime.Now.Year);
            datToDate.DateTime = DateTime.Now;

            btnExcute.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "btnExcute", Commons.Modules.TypeLanguage);
            btnChon.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "btnChon", Commons.Modules.TypeLanguage);
            btnKhong.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "btnKhong", Commons.Modules.TypeLanguage);
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "btnThoat", Commons.Modules.TypeLanguage);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.ParentForm.Close();
        }
        private void LoadCN()
        {
            String SQL;
            dtCN = new DataTable();
            SQL = " SELECT CONVERT (BIT , 0) AS CHON,  dbo.CONG_NHAN.MS_CONG_NHAN, " +
                    " dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS HO_TEN, dbo.[TO].TEN_TO,  " +
                    " dbo.TO_PHONG_BAN.TEN_TO AS TEN_PB, dbo.CONG_NHAN.TEN, dbo.CONG_NHAN.HO " +
                    " FROM         dbo.CONG_NHAN INNER JOIN " +
                    " dbo.[TO] ON dbo.CONG_NHAN.MS_TO = dbo.[TO].MS_TO1 INNER JOIN " +
                    " dbo.TO_PHONG_BAN ON dbo.[TO].MS_TO = dbo.TO_PHONG_BAN.MS_TO " +
                    " ORDER BY dbo.CONG_NHAN.TEN, dbo.CONG_NHAN.HO ";
            dtCN.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, SQL));

            dtCN.Columns["CHON"].ReadOnly = false;
            grdCN.DataSource = dtCN;
            
            grvCN.PopulateColumns();
            grvCN.OptionsView.ColumnAutoWidth = true;
            grvCN.OptionsView.AllowHtmlDrawHeaders = true;
            grvCN.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            grvCN.BestFitColumns();
             
            grvCN.Columns["TEN"].Visible = false;
            grvCN.Columns["HO"].Visible = false;

            grvCN.Columns["MS_CONG_NHAN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "MS_CONG_NHAN", Commons.Modules.TypeLanguage);
            grvCN.Columns["HO_TEN"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "HO_TEN", Commons.Modules.TypeLanguage);
            grvCN.Columns["TEN_TO"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "TEN_TO", Commons.Modules.TypeLanguage);
            grvCN.Columns["TEN_PB"].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "TEN_PB", Commons.Modules.TypeLanguage);

            grvCN.Columns["MS_CONG_NHAN"].OptionsColumn.ReadOnly = true;
            grvCN.Columns["HO_TEN"].OptionsColumn.ReadOnly = true;
            grvCN.Columns["TEN_TO"].OptionsColumn.ReadOnly = true;
            grvCN.Columns["TEN_PB"].OptionsColumn.ReadOnly = true;            
            
            grvCN.Columns["CHON"].OptionsColumn.AllowEdit = true;
            dtCN.Columns["CHON"].ReadOnly = false;
            grvCN.Columns["CHON"].OptionsColumn.ReadOnly = false;



            grvCN.Columns["CHON"].Width = 50;
            grvCN.Columns["MS_CONG_NHAN"].Width = 75;
            grvCN.Columns["TEN_TO"].Width = 85;
            grvCN.Columns["TEN_PB"].Width = 85;
        }
        private void CapNhap(Boolean Chon)
        {
            try            
            {
                for (int i = 0; i < grvCN.RowCount;i++ )
                {
                    grvCN.GetDataRow(i)["CHON"] = Chon;
                }
            }
            catch { }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            CapNhap(true);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            CapNhap(false);
        }
        private void LocData(string GT)
        {
            if (GT == "")
            {
                dtCN.DefaultView.RowFilter = "" ;
            }
            else
            {
                dtCN.DefaultView.RowFilter = "MS_CONG_NHAN LIKE '%" + GT + "%' OR TEN LIKE '%" + GT + "%' ";
            }
        }

        private void txtMSCN_EditValueChanged(object sender, EventArgs e)
        {
            LocData(txtMSCN.Text);
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime TN = datFromDate.DateTime;
                DateTime DN = datToDate.DateTime;
                string Tinh = cmbCity.EditValue.ToString();
                string Quan = cmbDistrict.EditValue.ToString();
                string NX = cmbNhaXuong.EditValue.ToString();
                string LM = cmbCatmachine.EditValue.ToString();

                if (string.IsNullOrEmpty(Tinh)) 
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "CHUA_CHON_TINH", Commons.Modules.TypeLanguage));

                if (string.IsNullOrEmpty(Quan))
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "CHUA_CHON_QUAN", Commons.Modules.TypeLanguage));

                if (string.IsNullOrEmpty(NX))
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "CHUA_CHON_NX", Commons.Modules.TypeLanguage));

                if (string.IsNullOrEmpty(LM))
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "CHUA_CHON_LM", Commons.Modules.TypeLanguage));

                if (DN.Subtract(TN).Days > 365)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "WA_1_NAM", Commons.Modules.TypeLanguage));
                    return;
                }


                string tmp = "";
                tmp = dtCN.DefaultView.RowFilter;
                dtCN.TableName = "CN" + Commons.Modules.UserName;
                dtCN.DefaultView.RowFilter = "CHON = TRUE";
                if( dtCN.DefaultView.ToTable().Rows.Count == 0)
                {
                    dtCN.DefaultView.RowFilter = tmp;
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "KHONG_CHON", Commons.Modules.TypeLanguage));
                    return;
                }

                DataSet myDataSet = new DataSet();
                myDataSet.Tables.Add(dtCN.DefaultView.ToTable());
                dtCN.DefaultView.RowFilter = tmp;
                tmp = " CN" + Commons.Modules.UserName;

                try
                {
                    SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                        "DROP TABLE " + tmp);
                }
                catch{ }
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                    "SELECT MS_CONG_NHAN INTO " + tmp + " FROM CONG_NHAN WHERE MS_CONG_NHAN = '1' ");

                var adapterForTable1 = new SqlDataAdapter("SELECT MS_CONG_NHAN FROM " + tmp, 
                    Commons.IConnections.ConnectionString);

                var builderForTable1 = new SqlCommandBuilder(adapterForTable1);
                adapterForTable1.Update(myDataSet, tmp.ToString().Trim());
                string sSelect = " SELECT ROW_NUMBER() OVER (ORDER BY dbo.CONG_NHAN.TEN  ASC , A.MS_CONG_NHAN ASC) AS STT, " +
                    " A.MS_CONG_NHAN, dbo.CONG_NHAN.HO + ' ' + dbo.CONG_NHAN.TEN AS HO_TEN, " +
                    " dbo.MashjGetQuocGiaCN(A.MS_CONG_NHAN) AS KHU_VUC,  ";

                string sFrom = " FROM " + tmp + " AS A INNER JOIN " +
                    " dbo.CONG_NHAN ON A.MS_CONG_NHAN = dbo.CONG_NHAN.MS_CONG_NHAN ";

                string sSumBT = "";
                string sSumSC = "";

                TN = new DateTime(datFromDate.DateTime.Year, datFromDate.DateTime.Month, 1, 0, 0, 0);
                DN = new DateTime(datToDate.DateTime.Year, datToDate.DateTime.Month, 1, 0, 0, 0);
                DateTime TNgay ;
                DateTime DNgay;
                string  t = TN.Month + "" + TN.Year ;

                for (DateTime i = TN; i <= DN; i = i.AddMonths (1) )
                {

                    t = i.Month < 10 ? "0" + i.Month.ToString() + i.Year  : i.Month + "" + i.Year;


                    TNgay = new DateTime(i.Year, i.Month, 1);
                    DNgay = TNgay.AddMonths(1).AddDays(-1);

                    sSelect = sSelect + " BT" + t + " , SC" + t + " , ";
                    sSumBT = sSumBT + " + ISNULL(BT" + t + ",0) ";
                    sSumSC = sSumSC + " + ISNULL(SC" + t + ",0) ";
                    sFrom = sFrom + " LEFT JOIN (SELECT B.MS_CONG_NHAN, BT AS BT" + t + ", SC AS SC" + t +
                                " FROM [dbo].[MashjGetThongKeBTSC] ('" + Tinh + "','" + Quan + "','" + NX +
                                "','" + LM + "','" + TNgay.Date.ToString("MM/dd/yyyy") + "','" + DNgay.Date.ToString("MM/dd/yyyy") + "') AS A  " +
                                " INNER JOIN " + tmp + " B ON A.MS_CONG_NHAN = B.MS_CONG_NHAN  " +
                                " ) T" + t + " ON A.MS_CONG_NHAN = T" + t + ".MS_CONG_NHAN ";

                }
                string Sql;
                sSumBT =  " (" + sSumBT.Substring(2, sSumBT.Length - 2) + ") AS TOTAL_BC , " ;
                sSumSC = " (" + sSumSC.Substring(2, sSumSC.Length - 2) + ") AS TOTAL_SC";

                Sql = sSelect + sSumBT + sSumSC + sFrom + " ORDER BY dbo.CONG_NHAN.TEN , A.MS_CONG_NHAN ";

                
                
                frmBCNSKido frm = new frmBCNSKido();
                frm.Tinh = cmbCity.Text;
                frm.Quan = cmbDistrict.Text;
                frm.NXuong = cmbNhaXuong.Text;
                frm.LTBi = cmbCatmachine.Text;
                //i.Month < 10 ? "0" + i.Month.ToString() + i.Year : i.Month + "" + i.Year;
                frm.TThang = datFromDate.DateTime.Month < 10 ? 
                    "0" + datFromDate.DateTime.Month.ToString() + "/" + datFromDate.DateTime.Year.ToString() : 
                    datFromDate.DateTime.Month.ToString() + "/" + datFromDate.DateTime.Year.ToString();
                frm.DThang = datToDate.DateTime.Month<10? 
                    "0" + datToDate.DateTime.Month.ToString() + "/" + datToDate.DateTime.Year.ToString():
                    datToDate.DateTime.Month.ToString() + "/" + datToDate.DateTime.Year.ToString();

                frm._dtNSKD.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, 
                    CommandType.Text, Sql));
                if (frm._dtNSKD.Rows.Count == 0)
                {
                    MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucHCKD", "KhongCoDuLieuDeIn", Commons.Modules.TypeLanguage), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucNSKido", "THUC_HIEN_KHONG_DUOC", Commons.Modules.TypeLanguage));
                return;

            }
        }

    }
}
