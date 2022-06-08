using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace ReportMain
{
    public partial class frmThemCongViec : DevExpress.XtraEditors.XtraForm
    {

        public frmThemCongViec()
        {
            InitializeComponent();
        }
        public string sMsMay = "-1";
        public string sMsBoPhan = "-1";
        public string sTenBoPhan = "-1";
        public string sMoTaCV = "-1";
        public bool bLMay = false;  // = false bat buoc nhap loai may -----  = true o bat buoc
        string sMSLoaiMay = "-1";
        public string ketQua = "-1";
        private void frmThemCongViec_Load(object sender, EventArgs e)
        {
            try
            {
                txtMsMay.Text = sMsMay;
                DataTable dtTmp = new DataTable();
                if (bLMay == false)
                {
                    string sSql = "SELECT TOP 1 ISNULL(TEN_LOAI_MAY,'') AS TEN, T2.MS_LOAI_MAY FROM MAY T1 INNER JOIN NHOM_MAY T2 ON T1.MS_NHOM_MAY = T2.MS_NHOM_MAY " +
                            " INNER JOIN LOAI_MAY T3 ON T2.MS_LOAI_MAY = T3.MS_LOAI_MAY WHERE MS_MAY = '" + sMsMay + "'";
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    if (dtTmp.Rows.Count > 0)
                    {
                        txtLMay.Text = dtTmp.Rows[0]["TEN"].ToString();
                        sMSLoaiMay = dtTmp.Rows[0]["MS_LOAI_MAY"].ToString();
                    }
                }
                else
                {
                    sMSLoaiMay = "-1";
                }

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetLOAI_CONG_VIEC_PQ", Commons.Modules.UserName));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLCV, dtTmp, "MS_LOAI_CV", "TEN_LOAI_CV", "");
                
                if (sMSLoaiMay == "-1" && bLMay == false)
                    btnThucHien.Enabled = false;

                if(sMoTaCV != "-1")
                {
                    txtMoTaCV.Text = sMoTaCV;
                }
            }
            catch(Exception EX)
            { XtraMessageBox.Show(EX.Message); }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Commons.Modules.SQLString = "-1";
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (sMSLoaiMay == "" && bLMay == false)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaCoLoaiMay", Commons.Modules.TypeLanguage));
                return;
            }
            if (txtMoTaCV.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNhapMoTaCongViec", Commons.Modules.TypeLanguage));
                return;
            }
            if (cboLCV.Text == "")
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgChuaNChonLoaiCongViec", Commons.Modules.TypeLanguage));
                return;
            }
            if (txtTGChuan.Text == "") txtTGChuan.Text = "0";
            if (Convert.ToDouble(txtTGChuan.Text) == 0)
            {
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "msgChuaNhapThoigianChuanCoMuonTiepTuc", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }


            Commons.VS.Classes.Catalogue.CONG_VIECController objCONG_VIECController = new Commons.VS.Classes.Catalogue.CONG_VIECController();
            if (objCONG_VIECController.Check_MO_TA_CONG_VIEC(sMSLoaiMay, txtMoTaCV.Text))
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgMO_TA_CV", Commons.Modules.TypeLanguage));
                txtMoTaCV.SelectAll();
                return;
            }

            string sSql = "";
            Commons.Modules.SQLString = "-1";
            try
            {
                int iMsCV = Commons.Modules.ObjSystems.GetIDInteger("CV");
                string sMoTaCV = txtMoTaCV.Text;
                if (bLMay == false)
                    sSql = "INSERT INTO [CONG_VIEC]([MS_CV],[MA_CV],[MS_LOAI_CV],[MO_TA_CV],[MO_TA_CV_ANH],[MS_LOAI_MAY],[THOI_GIAN_DU_KIEN])" +
                            " VALUES (" + iMsCV.ToString() + ", '" + iMsCV.ToString() + "', " + cboLCV.EditValue.ToString() + ", N'" + txtMoTaCV.Text + "' , N'" + txtMoTaCV.Text + "' , " +
                            " N'" + sMSLoaiMay.ToString() + "', " + txtTGChuan.Text + ")";
                else
                    sSql = "INSERT INTO [CONG_VIEC]([MS_CV],[MA_CV],[MS_LOAI_CV],[MO_TA_CV],[MO_TA_CV_ANH],[THOI_GIAN_DU_KIEN])" +
                            " VALUES (" + iMsCV.ToString() + ", '" + iMsCV.ToString() + "', " + cboLCV.EditValue.ToString() + ", N'" + txtMoTaCV.Text + "' , N'" + txtMoTaCV.Text + "' , " + txtTGChuan.Text + ")";

                SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                if (sMsBoPhan != "-1")
                {
                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                        this.Name, "msgBanCoMuonThemCongViecVaoBoPhan", Commons.Modules.TypeLanguage) + " " + sTenBoPhan, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                    {
                        sSql = "INSERT INTO [CAU_TRUC_THIET_BI_CONG_VIEC]([MS_MAY],[MS_BO_PHAN],[MS_CV],[ACTIVE],[TG_KH])" +
                                                " VALUES (N'" + sMsMay + "', N'" + sMsBoPhan + "' , " + iMsCV.ToString() + " ,1, " + txtTGChuan.Text + ")";
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.ConnectionString, CommandType.Text, sSql);
                    }
                }
                ketQua = iMsCV.ToString() + "!" + txtMoTaCV.Text.Trim() + "!" + txtTGChuan.Text.Trim();
                Commons.Modules.SQLString = iMsCV.ToString();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            catch(Exception EX)
            { XtraMessageBox.Show(EX.Message); }
            
        }

        private void txtTGChuan_Click(object sender, EventArgs e)
        {
            try { txtTGChuan.SelectAll(); }
            catch { }
            
        }
    }
}