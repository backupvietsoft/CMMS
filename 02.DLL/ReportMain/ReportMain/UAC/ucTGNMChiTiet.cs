using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class ucTGNMChiTiet : DevExpress.XtraEditors.XtraUserControl
    {
        private Boolean bTSua;
        public Boolean bThemSua { get { return bTSua; } set { bTSua = value; } }

        private string sMay;
        public string sMsMay { get { return sMay; } set { sMay = value; } }

        private DateTime TNgay;
        public DateTime TuNgay { get { return TNgay; } set { TNgay = value; } }

        private DateTime TGio;
        public DateTime TuGio { get { return TGio; } set { TGio = value; } }

        private DateTime DNgay;
        public DateTime DenNgay { get { return DNgay; } set { DNgay = value; } }

        private DateTime DGio;
        public DateTime DenGio { get { return DGio; } set { DGio = value; } }



        public ucTGNMChiTiet()
        {
            InitializeComponent();
        }
        private void LoadCmb()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                "SELECT MS_HE_THONG, TEN_HE_THONG FROM HE_THONG  ORDER BY MS_HE_THONG"));

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboHT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cboHT.NullText = "";
            cboHT.ValueMember = "MS_HE_THONG";
            cboHT.DisplayMember = "TEN_HE_THONG";
            cboHT.DataSource = dtTmp;
            cboHT.Columns.Clear();
            cboHT.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MS_HE_THONG"));
            grvTGNMCT.Columns["MS_HE_THONG"].ColumnEdit = cboHT;
            cboHT.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(cboHT_EditValueChanging);


 
        }
        private void cboHT_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
        }

        public void ucTGNMChiTiet_Load(object sender, EventArgs e)
        {
            //bTSua = false;
            ////EXEC GetTGNMChiTiet '00327EG','10/02/2013','11:03:00','10/02/2013','12:03:00'
            //sMay = "00327EG";
            //TNgay = DateTime.Parse("02/10/2013");
            //TGio =DateTime.Parse("11:03:00");
            //DNgay = DateTime.Parse("02/10/2013");
            //DGio = DateTime.Parse("12:03:00");
            LoadData();
        }

        public void LoadData()
        {
            DataTable dtTmp = new DataTable();
            //string str;
            try
            {
                //str = "EXEC GetTGNMChiTiet '" + sMay + "','" + TNgay + "','" + TGio + "','" + DNgay + "','" + DGio + "'";
                //dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, str));
                //dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetTGNMChiTiet", sMsMay, TNgay, TGio, DNgay, DGio));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTGNMCT, grvTGNMCT, dtTmp, false, true, true, true);
                LoadCmb();
                grvTGNMCT.Columns["MS_MAY"].Visible = false;
    //            SELECT [MS_NGUYEN_NHAN],[MS_HE_THONG],[TU_NGAY_CT],[TU_GIO_CT],[DEN_NGAY_CT],[DEN_GIO_CT],
    //[THOI_GIAN_SUA_CHUA],[GHI_CHU],[MS_MAY],[NGAY],[TU_GIO],[DEN_NGAY],[DEN_GIO] 
            }catch{}
        }
    }
}
