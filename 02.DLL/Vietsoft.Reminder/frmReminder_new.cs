using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
//using DevExpress.XtraEditors;

namespace Vietsoft.Reminder
{
    public partial class frmReminder_new : DevExpress.XtraEditors.XtraForm
    {
        string KhongKho;
        DataTable v_all = new DataTable();
        private bool isChange = false;

        public frmReminder_new()
        {
            InitializeComponent();
        }
        //Load form
        private void frmReminder_Load(object sender, EventArgs e)
        {
            KhongKho = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KhongKho", Commons.Modules.TypeLanguage);
            Commons.Modules.SQLString = "0LOAD";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Commons.Modules.SQLString = "0LOAD";
                SetDefaullValue();
                BinDataNX();
                BinDataHT();
                BinDataLTB();
                BinDataLHC();
                BinDataLPT();
                BindMay();
                Commons.Modules.SQLString = "";
                BinDataTBDHHC(cboMay1.EditValue.ToString());
                BinDataDCDDHHC(cboMay1.EditValue.ToString()); ;
                Commons.Modules.SQLString = "";
                BinDataVTPTSLNHTTT();
                this.CboLPT6.SelectedValueChanged += new System.EventHandler(this.CboLPT6_SelectedValueChanged);
            }
            catch
            {
                this.Close();
            }
            this.Cursor = Cursors.Default;
            DgvTBDHHC1.ColumnHeadersDefaultCellStyle.Font = new Font(DgvTBDHHC1.ColumnHeadersDefaultCellStyle.Font.Name, DgvTBDHHC1.ColumnHeadersDefaultCellStyle.Font.Size, FontStyle.Bold);
            DgvDCDDHHC1.ColumnHeadersDefaultCellStyle.Font = new Font(DgvDCDDHHC1.ColumnHeadersDefaultCellStyle.Font.Name, DgvDCDDHHC1.ColumnHeadersDefaultCellStyle.Font.Size, FontStyle.Bold);
            DgvPBTTN2.ColumnHeadersDefaultCellStyle.Font = new Font(DgvPBTTN2.ColumnHeadersDefaultCellStyle.Font.Name, DgvPBTTN2.ColumnHeadersDefaultCellStyle.Font.Size, FontStyle.Bold);
            DgvPBTQHKT3.ColumnHeadersDefaultCellStyle.Font = new Font(DgvPBTQHKT3.ColumnHeadersDefaultCellStyle.Font.Name, DgvPBTQHKT3.ColumnHeadersDefaultCellStyle.Font.Size, FontStyle.Bold);
            DgvBTDK4.ColumnHeadersDefaultCellStyle.Font = new Font(DgvBTDK4.ColumnHeadersDefaultCellStyle.Font.Name, DgvBTDK4.ColumnHeadersDefaultCellStyle.Font.Size, FontStyle.Bold);
            DgvGSTTDHKT5.ColumnHeadersDefaultCellStyle.Font = new Font(DgvGSTTDHKT5.ColumnHeadersDefaultCellStyle.Font.Name, DgvGSTTDHKT5.ColumnHeadersDefaultCellStyle.Font.Size, FontStyle.Bold);
            DgvVTPTNHTTT6.ColumnHeadersDefaultCellStyle.Font = new Font(DgvVTPTNHTTT6.ColumnHeadersDefaultCellStyle.Font.Name, DgvVTPTNHTTT6.ColumnHeadersDefaultCellStyle.Font.Size, FontStyle.Bold);



            if (Commons.Modules.sPrivate == "BARIA")
                chkTonTT.Visible = true;
            else
                chkTonTT.Visible = false;

            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        //Khởi tạo dữ liệu ban đầu
        private void SetDefaullValue()
        {
            DateTime dtNgay, dtDNgay;
            dtNgay = Convert.ToDateTime("01/" + DateTime.Now.Date.Month.ToString() + "/" + DateTime.Now.Date.Year.ToString());
            dtDNgay = dtNgay.AddMonths(1).AddDays(-1);


            TxtTN1.Value = dtNgay.Date;
            TxtDN1.Value = dtDNgay.Date;

            TxtTN4.Value = dtNgay.Date;
            TxtDN4.Value = dtDNgay.Date;

            TxtTN5.Value = dtNgay.Date;
            TxtDN5.Value = dtDNgay.Date;
        }
        //Lấy loại thiết bị
        private void BinDataLTB()
        {
            DataTable TbLTB = new DataTable();
            Vietsoft.Admin.Sqlvs sqlLTB = new Vietsoft.Admin.Sqlvs();
            try
            {
                CboLTB.DataSource = Commons.Modules.ObjSystems.MLoadDataLoaiMay(1);
                CboLTB.ValueMember = "MS_LOAI_MAY";
                CboLTB.DisplayMember = "TEN_LOAI_MAY";
            }
            catch { }

        }
        //Lấy địa điểm lắp đặt
        private void BinDataNX()
        {
            CboNX.DataSource = Commons.Modules.ObjSystems.MLoadDataNhaXuong(1, "-1", "-1", "-1");
            CboNX.DisplayMember = "TEN_N_XUONG";
            CboNX.ValueMember = "MS_N_XUONG";

        }
        //Lấy dấy chuyền lắp đặt
        private void BinDataHT()
        {
            CboHT.DataSource = Commons.Modules.ObjSystems.MLoadDataDayChuyen(1);
            CboHT.ValueMember = "MS_HE_THONG";
            CboHT.DisplayMember = "TEN_HE_THONG";
        }


        //==========================================
        //Thiết bị đến hạn hiệu chuẩn
        //===========================================
        //Lấy loại hiệu chuẩn
        private void BinDataLHC()
        {
            DataTable TbLHC = new DataTable();
            TbLHC.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MashjGetLOAI_HIEU_CHUAN"));

            TbLHC.Rows.Add(-1, " < ALL > ");
            TbLHC.DefaultView.Sort = "TEN_LOAI_HIEU_CHUAN";
            TbLHC = TbLHC.DefaultView.ToTable();
            Commons.Modules.ObjSystems.MLoadLookUpEdit(CboLHC1, TbLHC, "MS_LOAI_HIEU_CHUAN", "TEN_LOAI_HIEU_CHUAN", "");
        }


        private void BindMay(DevExpress.XtraEditors.LookUpEdit cboMay)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable TbTB = new DataTable();
                Vietsoft.Admin.Sqlvs sqlTB = new Vietsoft.Admin.Sqlvs();
                try
                {
                    TbTB.Load(sqlTB.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_MAY", Commons.Modules.UserName, Commons.Modules.TypeLanguage, CboLTB.SelectedValue,
                            CboNX.SelectedValue, CboHT.SelectedValue, "-1", "-1", "-1"));

                    TbTB.Rows.Add("-1", " < ALL > ", "-1");
                    TbTB.DefaultView.Sort = "MS_MAY";
                    TbTB = TbTB.DefaultView.ToTable();


                    Commons.Modules.SQLString = "0LOAD";
                    Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboMay, TbTB, "MS_MAY", "TEN_MAY", "");
                    cboMay.Properties.Columns["MS_MAY1"].Visible = false;
                    cboMay.EditValue = "-1";

                }
                catch { }
                this.Cursor = Cursors.Default;
            }
            catch { }
            Commons.Modules.SQLString = "";
        }

        //Lấy dữ liệu thiết bị đến hạn hiệu chuẩn
        private void BinDataTBDHHC(string MsMay)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;

            this.Cursor = Cursors.WaitCursor;
            DataTable TbTBDHHC = new DataTable();
            Vietsoft.Admin.Sqlvs sqlTBDHHC = new Vietsoft.Admin.Sqlvs();
            try
            {
                TbTBDHHC.Load(sqlTBDHHC.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TBDHHC", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                        TxtTN1.Value.Date, TxtDN1.Value.Date, CboNX.SelectedValue, CboHT.SelectedValue,
                        CboLTB.SelectedValue, MsMay, "-1", "-1", "-1", CboLHC1.EditValue));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DgvTBDHHC1.AutoGenerateColumns = false;
            DgvTBDHHC1.DataSource = TbTBDHHC;

            foreach (DataGridViewColumn Dgvcl in DgvTBDHHC1.Columns)
            {
                Dgvcl.DataPropertyName = Dgvcl.Name.Replace("_1", String.Empty);
            }

            this.Cursor = Cursors.Default;
        }

        //Lấy dữ liệu thiết bị đến hạn hiệu chuẩn

        private void BinDataDCDDHHC(string MsMay)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;

            this.Cursor = Cursors.WaitCursor;
            DataTable TbDCDDHHC = new DataTable();
            DataView DtvHC = new DataView();
            Vietsoft.Admin.Sqlvs sqlDCDDHHC = new Vietsoft.Admin.Sqlvs();
            try
            {
                TbDCDDHHC.Load(sqlDCDDHHC.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_DCDDHHC", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                        TxtTN1.Value.Date, TxtDN1.Value.Date, CboNX.SelectedValue, CboHT.SelectedValue,
                        CboLTB.SelectedValue, MsMay, Vietsoft.Admin.Adminvs.IpAddress, "-1",
                        "-1", "-1", CboLHC1.EditValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DgvDCDDHHC1.AutoGenerateColumns = false;
            DgvDCDDHHC1.DataSource = TbDCDDHHC;

            foreach (DataGridViewColumn Dgvcl in DgvDCDDHHC1.Columns)
            {
                Dgvcl.DataPropertyName = Dgvcl.Name.Replace("_11", String.Empty);
            }

            this.Cursor = Cursors.Default;
        }

        //==========================================
        //Phiếu bảo trì trong ngày
        //===========================================       


        //Lấy dữ liệu phiếu bảo trì trong ngày
        private void BinDataPBTTN(string MsMay)
        {

            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            DataTable TbPBTTN = new DataTable();
            Vietsoft.Admin.Sqlvs sqlPBTTN = new Vietsoft.Admin.Sqlvs();


            try
            {
                TbPBTTN.Load(sqlPBTTN.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_PBTTN", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                        CboNX.SelectedValue, CboHT.SelectedValue, CboLTB.SelectedValue, MsMay, "-1", "-1", "-1"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DgvPBTTN2.AutoGenerateColumns = false;
            DgvPBTTN2.DataSource = TbPBTTN;
            foreach (DataGridViewColumn Dgvcl in DgvPBTTN2.Columns)
            {
                Dgvcl.DataPropertyName = Dgvcl.Name.Replace("_2", String.Empty);
            }
            this.Cursor = Cursors.Default;
        }
        //Thay đổi dữ liệu

        //==========================================
        //Phiếu bảo trì quá hạn kết thúc
        //===========================================       

        //Lấy dữ liệu phiếu bảo trì trong ngày
        private void BinDataPBTQHKT(string MsMay)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;

            this.Cursor = Cursors.WaitCursor;
            DataTable TbPBTQHKT = new DataTable();
            Vietsoft.Admin.Sqlvs sqlPBTQHKT = new Vietsoft.Admin.Sqlvs();

            try
            {
                TbPBTQHKT.Load(sqlPBTQHKT.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_PBQHKT", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                        CboNX.SelectedValue, CboHT.SelectedValue, CboLTB.SelectedValue, MsMay, "-1", "-1", "-1"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DgvPBTQHKT3.AutoGenerateColumns = false;
            DgvPBTQHKT3.DataSource = TbPBTQHKT;
            foreach (DataGridViewColumn Dgvcl in DgvPBTQHKT3.Columns)
            {
                Dgvcl.DataPropertyName = Dgvcl.Name.Replace("_3", String.Empty);
            }
            this.Cursor = Cursors.Default;
        }

        //============================
        //Bảo trì định kỳ
        //=============================

        //Lấy bảo trì định kỳ
        private void BinDataBTDK(string MsMay)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            DataTable TbBTDK = new DataTable();
            Vietsoft.Admin.Sqlvs sqlBTDK = new Vietsoft.Admin.Sqlvs();
            //List<dbNhacViecDataContext.SP_Y_GET_BTDK_NHAC_VIEC_NEWResult> lst = new List<dbNhacViecDataContext.SP_Y_GET_BTDK_NHAC_VIEC_NEWResult>();
            try
            {
                TbBTDK.Load(sqlBTDK.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_BTDK_NHAC_VIEC", Commons.Modules.UserName,
                        TxtTN4.Value.Date, TxtDN4.Value.Date, CboLTB.SelectedValue, CboNX.SelectedValue, CboHT.SelectedValue, MsMay,
                        Commons.Modules.UserName, "-1", "-1", "-1"));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            DgvBTDK4.AutoGenerateColumns = false;
            DgvBTDK4.DataSource = TbBTDK;
            DgvBTDK4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn Dgvcl in DgvBTDK4.Columns)
            {
                Dgvcl.DataPropertyName = Dgvcl.Name.Replace("_4", String.Empty);
            }
            DgvBTDK4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.Cursor = Cursors.Default;
        }

        //=============================
        //Thông số giám sát tình trạng
        //=============================

        //Lấy thông số giám sát tình trạng
        private void BinDataTSGSTTDHKT()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            DataTable TbTSGSTT = new DataTable();
            Vietsoft.Admin.Sqlvs sqlTSGSTT = new Vietsoft.Admin.Sqlvs();

            try
            {
                TbTSGSTT.Load(sqlTSGSTT.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_TSGSTTDHKT", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                        TxtTN5.Value.Date, TxtDN5.Value.Date,
                        CboNX.SelectedValue, CboHT.SelectedValue, CboLTB.SelectedValue, cboMay5.EditValue, "-1", "-1", "-1", cboLCV.EditValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DgvGSTTDHKT5.AutoGenerateColumns = false;
            DgvGSTTDHKT5.DataSource = TbTSGSTT;
            foreach (DataGridViewColumn Dgvcl in DgvGSTTDHKT5.Columns)
            {
                Dgvcl.DataPropertyName = Dgvcl.Name.Replace("_5", String.Empty);
            }
            this.Cursor = Cursors.Default;
        }
        //============================
        //Vật tư phụ tùng có số lượng tồn nhỏ hơn tồn tối thiểu
        //=============================
        //Lấy loại hiệu chuẩn
        private void BinDataLPT()
        {
            DataTable TbLPT = new DataTable();
            TbLPT.Columns.Add("VALUE", typeof(int));
            TbLPT.Columns.Add("DISLAY");
            TbLPT.Rows.Add(-1, " < ALL > ");
            switch (Commons.Modules.TypeLanguage)
            {
                case 1:
                    TbLPT.Rows.Add(1, "Material");
                    TbLPT.Rows.Add(0, "Spare part");
                    break;
                case 2:
                    TbLPT.Rows.Add(1, "Material");
                    TbLPT.Rows.Add(0, "Spare part");
                    break;
                default:
                    TbLPT.Rows.Add(1, "Vật tư");
                    TbLPT.Rows.Add(0, "Phụ tùng");
                    break;
            }
            CboLPT6.DataSource = TbLPT;
            CboLPT6.ValueMember = "VALUE";
            CboLPT6.DisplayMember = "DISLAY";

            try
            {
                DataTable dtKho = new DataTable();

                dtKho.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "GetIC_KHOs"));
                dtKho.Rows.Add(-1, " < ALL > ");
                dtKho.Rows.Add(0, " < Khong Kho > ");
                dtKho.DefaultView.Sort = "TEN_KHO ASC";
                dtKho = dtKho.DefaultView.ToTable();

                cboKho.DataSource = dtKho;
                cboKho.ValueMember = "MS_KHO";
                cboKho.DisplayMember = "TEN_KHO";

            }
            catch { }

        }
        //Lấy bảo trì định kỳ
        private void BinDataVTPTSLNHTTT()
        {
            if (Commons.Modules.SQLString == "0LOAD") return;


            if (cboKho.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            this.Cursor = Cursors.WaitCursor;
            DataTable TbVTPTSLNHTTT = new DataTable();
            Vietsoft.Admin.Sqlvs sqlVTPTSLNHTTT = new Vietsoft.Admin.Sqlvs();
            try
            {
                if (Commons.Modules.sPrivate == "BARIA")
                {
                    TbVTPTSLNHTTT = TonTheoBaria();
                }
                else
                {
                    TbVTPTSLNHTTT.Load(sqlVTPTSLNHTTT.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_VTPT_SLNH_SLTTT",
                        Commons.Modules.TypeLanguage, CboLPT6.SelectedValue, KhongKho, cboKho.SelectedValue, Commons.Modules.UserName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DgvVTPTNHTTT6.AutoGenerateColumns = false;


            string sDK = "";
            LocDataTonBaria(out sDK);

            TbVTPTSLNHTTT.DefaultView.RowFilter = sDK;
            TbVTPTSLNHTTT = TbVTPTSLNHTTT.DefaultView.ToTable();


            DgvVTPTNHTTT6.DataSource = TbVTPTSLNHTTT;
            foreach (DataGridViewColumn Dgvcl in DgvVTPTNHTTT6.Columns)
            {
                Dgvcl.DataPropertyName = Dgvcl.Name.Replace("_6", String.Empty);
            }

            this.Cursor = Cursors.Default;
        }
        private void CboLPT6_SelectedValueChanged(object sender, EventArgs e)
        {
            BinDataVTPTSLNHTTT();
        }
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnIn_Click(object sender, EventArgs e)
        {
            string n = TabReminder.SelectedTabPage.Name;
            switch (n)
            {
                case "TabPTBDHHC":
                    InDCDDHHC();
                    break;
                case "TabPPBTTN":
                    InPBTTN();
                    break;
                case "TabPPBTQHKT":
                    InPBQHKT();

                    break;
                case "TabPBTDKCTH":
                    InPBTCTT();
                    break;
                case "TabPGSTTDHKT":
                    InGSTT();
                    break;
                case "TabPVTPTSLNTTT":
                    InVTPT();
                    break;
            }
        }
        private void InDCDDHHC()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbTBDHHC = new DataTable();
            Vietsoft.Admin.Sqlvs sqlTBDHHC = new Vietsoft.Admin.Sqlvs();
            try
            {
                TbTBDHHC = new Business().MyTable(DgvTBDHHC1);


            }
            catch { }


            DataTable TBDCDDHHC1 = new DataTable();
            try
            {
                TBDCDDHHC1 = new Business().MyTable(DgvDCDDHHC1);
            }
            catch { }

            DataTable vtbLg = new DataTable();
            vtbLg = RefeshLangua1();
            frmReport frm = new frmReport();
            frm.rptName = "rptTHIET_BI_DEN_HAN_HIEU_CHUAN";

            if (TbTBDHHC.Rows.Count > 0 || TBDCDDHHC1.Rows.Count > 0)
            {
                TbTBDHHC.TableName = "THIET_BI_DEN_HAN_HIEU_CHUAN";
                TBDCDDHHC1.TableName = "DUNG_CU_DO_DEN_HAN_HIEU_CHUAN";
                vtbLg.TableName = "TIEU_DE_THIET_BI_DEN_HAN_HIEU_CHUAN";
                frm.AddDataTableSource(TbTBDHHC);
                frm.AddDataTableSource(TBDCDDHHC1);
                frm.AddDataTableSource(vtbLg);
                try
                {
                    frm.Show();
                }
                catch { }
            }
            else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));

            this.Cursor = Cursors.Default;
        }
        private void InPBTTN()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbPBTTN = new DataTable();
            Vietsoft.Admin.Sqlvs sqlPBTTN = new Vietsoft.Admin.Sqlvs();
            try
            {
                TbPBTTN = new Business().MyTable(DgvPBTTN2);
                foreach (DataColumn col in TbPBTTN.Columns)
                    col.ColumnName = col.ColumnName.Replace("_2", "");
            }
            catch { }


            DataTable vtbLg = new DataTable();
            vtbLg = RefeshLangua2();
            vtbLg.TableName = "TIEU_DE_BAO_TRI_TRONG_NGAY";
            frmReport frm = new frmReport();
            frm.rptName = "rptBAO_TRI_TRONG_NGAY";
            TbPBTTN.TableName = "BAO_TRI_TRONG_NGAY";

            if (TbPBTTN.Rows.Count > 0)
            {
                frm.AddDataTableSource(TbPBTTN);
                frm.AddDataTableSource(vtbLg);
                frm.Show();
            }
            else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));
            this.Cursor = Cursors.Default;
        }
        private void InPBQHKT()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbPBTQHKT = new DataTable();
            Vietsoft.Admin.Sqlvs sqlPBTQHKT = new Vietsoft.Admin.Sqlvs();
            try
            {
                TbPBTQHKT = new Business().MyTable(DgvPBTQHKT3);
                foreach (DataColumn col in TbPBTQHKT.Columns)
                    col.ColumnName = col.ColumnName.Replace("_3", "");
            }
            catch { }

            DataTable vtbLg = new DataTable();
            frmReport frm = new frmReport();
            frm.rptName = "rptPHIEU_BAO_TRI_QUA_HAN_KT";

            if (TbPBTQHKT.Rows.Count > 0)
            {
                vtbLg = RefeshLangua3();
                vtbLg.TableName = "TIEU_DE_PHIEU_BAO_TRI_QUA_HAN_KT";
                TbPBTQHKT.TableName = "PHIEU_BAO_TRI_QUA_HAN_KT";
                frm.AddDataTableSource(TbPBTQHKT);
                frm.AddDataTableSource(vtbLg);
                try
                {
                    frm.Show();
                }
                catch { }
            }
            else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));

            this.Cursor = Cursors.Default;
        }
        private void InPBTCTT()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbBTDK = new DataTable();
            Vietsoft.Admin.Sqlvs sqlBTDK = new Vietsoft.Admin.Sqlvs();
            try
            {
                TbBTDK = new Business().MyTable(DgvBTDK4);
                foreach (DataColumn col in TbBTDK.Columns)
                    col.ColumnName = col.ColumnName.Replace("_4", "");
            }
            catch { }

            DataTable vtbLg = new DataTable();
            frmReport frm = new frmReport();
            frm.rptName = "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN";

            if (TbBTDK.Rows.Count > 0)
            {
                vtbLg = RefeshLangua4();
                vtbLg.TableName = "TIEU_DE_BAO_TRI_DINH_KY_CAN_THUC_HIEN";
                TbBTDK.TableName = "BAO_TRI_DINH_KY_CAN_THUC_HIEN";
                frm.AddDataTableSource(TbBTDK);
                frm.AddDataTableSource(vtbLg);
                frm.Show();
            }
            else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));

            this.Cursor = Cursors.Default;
        }
        private void InGSTT()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbTSGSTT = new DataTable();
            Vietsoft.Admin.Sqlvs sqlTSGSTT = new Vietsoft.Admin.Sqlvs();
            try
            {
                TbTSGSTT = new Business().MyTable(DgvGSTTDHKT5);
                foreach (DataColumn col in TbTSGSTT.Columns)
                    col.ColumnName = col.ColumnName.Replace("_5", "");
            }
            catch { }



            DataTable vtbLg = new DataTable();
            vtbLg = RefeshLangua5();
            frmReport frm = new frmReport();
            if (Commons.Modules.sPrivate.ToUpper() == "VECO")
                frm.rptName = "rptTINH_TRANG_THIET_BI_VECO";
            else
                frm.rptName = "rptTINH_TRANG_THIET_BI";


            if (TbTSGSTT.Rows.Count > 0)
            {

                TbTSGSTT.TableName = "TINH_TRANG_THIET_BI";
                vtbLg.TableName = "TIEU_DE_TINH_TRANG_THIET_BI";
                frm.AddDataTableSource(TbTSGSTT);
                frm.AddDataTableSource(vtbLg);
                Commons.Modules.SQLString = "0Design";
                frm.Show();
                Commons.Modules.SQLString = "";
            }
            else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));

            this.Cursor = Cursors.Default;
        }
        private void InVTPT()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable TbVTPTSLNHTTT = new DataTable();
            Vietsoft.Admin.Sqlvs sqlVTPTSLNHTTT = new Vietsoft.Admin.Sqlvs();
            try
            {
                if (Commons.Modules.sPrivate == "BARIA")
                {
                    TbVTPTSLNHTTT = TonTheoBaria();
                }
                else
                {

                    TbVTPTSLNHTTT.Load(sqlVTPTSLNHTTT.ExecuteReader(CommandType.StoredProcedure, "SP_Y_GET_VTPT_SLNH_SLTTT",
                        Commons.Modules.TypeLanguage, CboLPT6.SelectedValue, KhongKho, cboKho.SelectedValue, Commons.Modules.UserName));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DataTable vtbLg = new DataTable();
            frmReport frm = new frmReport();
            frm.rptName = "rptVTPT_NHO_HON_TON_TOI_THIEU";

            if (TbVTPTSLNHTTT.Rows.Count > 0)
            {
                TbVTPTSLNHTTT.TableName = "VTPT_NHO_HON_TON_TOI_THIEU";
                vtbLg = RefeshLangua6();
                vtbLg.TableName = "TIEU_DE_VTPT_NHO_HON_TON_TOI_THIEU";
                frm.AddDataTableSource(TbVTPTSLNHTTT);
                frm.AddDataTableSource(vtbLg);
                frm.Show();
            }
            else
                MessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "KoCoDuLieuDeIn", Commons.Modules.TypeLanguage));

            this.Cursor = Cursors.Default;
        }

        private DataTable RefeshLangua1()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 14; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "TU_NGAY";
            vtb.Columns[2].ColumnName = "DEN_NGAY";
            vtb.Columns[3].ColumnName = "DieuKienLoc";
            vtb.Columns[4].ColumnName = "ThietBiDenHan";
            vtb.Columns[5].ColumnName = "ThietBi";
            vtb.Columns[6].ColumnName = "ViTri";
            vtb.Columns[7].ColumnName = "NgayChuanCuoi";
            vtb.Columns[8].ColumnName = "ChuKy";
            vtb.Columns[9].ColumnName = "NgayChuanKeTiep";
            vtb.Columns[10].ColumnName = "Noi";
            vtb.Columns[11].ColumnName = "TenNhaXuong";
            vtb.Columns[12].ColumnName = "MaVatTu";
            vtb.Columns[13].ColumnName = "TenVatTu";

            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["TU_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "TU_NGAY", Commons.Modules.TypeLanguage) + "  " + TxtTN1.Text;
            vRowTitle["DEN_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "DEN_NGAY", Commons.Modules.TypeLanguage) + "  " + TxtDN1.Text;
            vRowTitle["DieuKienLoc"] = LabNX.Text + ": " + CboNX.Text + " - " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "LoaiThietBi", Commons.Modules.TypeLanguage) +
                        ": " + CboLTB.Text;
            vRowTitle["ThietBiDenHan"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "ThietBiDenHan", Commons.Modules.TypeLanguage);
            vRowTitle["ThietBi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "ThietBi", Commons.Modules.TypeLanguage);
            vRowTitle["ViTri"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "ViTri", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "NgayChuanCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["ChuKy"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "ChuKy", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanKeTiep"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "NgayChuanKeTiep", Commons.Modules.TypeLanguage);
            vRowTitle["Noi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "Noi", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhaXuong"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "TenNhaXuong", Commons.Modules.TypeLanguage);
            vRowTitle["MaVatTu"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "MaVatTu", Commons.Modules.TypeLanguage);
            vRowTitle["TenVatTu"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "TenVatTu", Commons.Modules.TypeLanguage);


            vtb.Rows.Add(vRowTitle);
            return vtb;
        }
        private DataTable RefeshLangua2()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 9; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "DieuKienLoc";
            vtb.Columns[2].ColumnName = "MSPhieuBaoTri";
            vtb.Columns[3].ColumnName = "LoaiBT";
            vtb.Columns[4].ColumnName = "Ten_May";
            vtb.Columns[5].ColumnName = "NgayChuanCuoi";
            vtb.Columns[6].ColumnName = "ChuKy";
            vtb.Columns[7].ColumnName = "NgayBDKeTiep";
            vtb.Columns[8].ColumnName = "TenNhaXuong";

            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["DieuKienLoc"] = LabNX.Text + "  " + " : " + CboNX.Text + " - " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "LoaiThietBi", Commons.Modules.TypeLanguage) + " : " + CboLTB.Text;
            vRowTitle["MSPhieuBaoTri"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "MSPhieuBaoTri", Commons.Modules.TypeLanguage);
            vRowTitle["LoaiBT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "LoaiBT", Commons.Modules.TypeLanguage);
            vRowTitle["Ten_May"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "Ten_May", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "NgayChuanCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["ChuKy"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "ChuKy", Commons.Modules.TypeLanguage);
            vRowTitle["NgayBDKeTiep"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "NgayBDKeTiep", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhaXuong"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_TRONG_NGAY", "TenNhaXuong", Commons.Modules.TypeLanguage);
            vtb.Rows.Add(vRowTitle);
            return vtb;
        }
        private DataTable RefeshLangua3()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 9; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "DieuKienLoc";
            vtb.Columns[2].ColumnName = "MSPhieuBaoTri";
            vtb.Columns[3].ColumnName = "LoaiBT";
            vtb.Columns[4].ColumnName = "Ten_May";
            vtb.Columns[5].ColumnName = "NgayChuanCuoi";
            vtb.Columns[6].ColumnName = "ChuKy";
            vtb.Columns[7].ColumnName = "NgayBDKeTiep";
            vtb.Columns[8].ColumnName = "TenNhaXuong";

            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["DieuKienLoc"] = LabNX.Text + "  " + " : " + CboNX.Text + " - " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "LoaiThietBi", Commons.Modules.TypeLanguage) + " : " + CboLTB.Text;
            vRowTitle["MSPhieuBaoTri"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "MSPhieuBaoTri", Commons.Modules.TypeLanguage);
            vRowTitle["LoaiBT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "LoaiBT", Commons.Modules.TypeLanguage);
            vRowTitle["Ten_May"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "Ten_May", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "NgayChuanCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["NgayBDKeTiep"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "NgayBDKeTiep", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhaXuong"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptPHIEU_BAO_TRI_QUA_HAN_KT", "TenNhaXuong", Commons.Modules.TypeLanguage);
            vtb.Rows.Add(vRowTitle);
            return vtb;
        }
        private DataTable RefeshLangua4()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 12; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "TU_NGAY";
            vtb.Columns[2].ColumnName = "DEN_NGAY";
            vtb.Columns[3].ColumnName = "DieuKienLoc";
            vtb.Columns[4].ColumnName = "MS_MAY";
            vtb.Columns[5].ColumnName = "TEN_MAY";
            vtb.Columns[6].ColumnName = "LOAI_BT";
            vtb.Columns[7].ColumnName = "NgayChuanCuoi";
            vtb.Columns[8].ColumnName = "ChuKy";
            vtb.Columns[9].ColumnName = "NgayChuanKeTiep";
            vtb.Columns[10].ColumnName = "TenNhaXuong";
            vtb.Columns[11].ColumnName = "TenNhomMay";

            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["TU_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TU_NGAY", Commons.Modules.TypeLanguage) + " " + TxtTN1.Text;
            vRowTitle["DEN_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "DEN_NGAY", Commons.Modules.TypeLanguage) + " " + TxtDN1.Text;
            vRowTitle["DieuKienLoc"] = LabNX.Text +
                "  " + " : " + CboNX.Text + " - " + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "LoaiThietBi", Commons.Modules.TypeLanguage) + " : " + CboLTB.Text;
            vRowTitle["MS_MAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "MS_MAY", Commons.Modules.TypeLanguage);
            vRowTitle["TEN_MAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TEN_MAY", Commons.Modules.TypeLanguage);
            vRowTitle["LOAI_BT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "LOAI_BT", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "NgayChuanCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["ChuKy"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "ChuKy", Commons.Modules.TypeLanguage);
            vRowTitle["NgayChuanKeTiep"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "NgayChuanKeTiep", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhaXuong"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TenNhaXuong", Commons.Modules.TypeLanguage);
            vRowTitle["TenNhomMay"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptBAO_TRI_DINH_KY_CAN_THUC_HIEN", "TenNhomMay", Commons.Modules.TypeLanguage);
            vtb.Rows.Add(vRowTitle);
            return vtb;
        }
        private DataTable RefeshLangua5()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 30; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "TU_NGAY";
            vtb.Columns[2].ColumnName = "DEN_NGAY";
            vtb.Columns[3].ColumnName = "DieuKienLoc";
            vtb.Columns[4].ColumnName = "BoPhan";
            vtb.Columns[5].ColumnName = "ThongSoGiamSat";
            vtb.Columns[6].ColumnName = "GiaTri";
            vtb.Columns[7].ColumnName = "Dat";
            vtb.Columns[8].ColumnName = "NgayGSCuoi";
            vtb.Columns[9].ColumnName = "ChuKy";
            vtb.Columns[10].ColumnName = "NgayGSKe";
            vtb.Columns[11].ColumnName = "KetQuaKT";
            vtb.Columns[12].ColumnName = "DiaDiem";
            vtb.Columns[13].ColumnName = "ThietBi";
            vtb.Columns[14].ColumnName = "NgayKT";
            vtb.Columns[15].ColumnName = "NguoiKT";
            vtb.Columns[16].ColumnName = "MAU_SO";
            vtb.Columns[17].ColumnName = "LAN_BH";
            vtb.Columns[18].ColumnName = "NGAY_BH";
            vtb.Columns[19].ColumnName = "TMP1";
            vtb.Columns[20].ColumnName = "TMP2";
            vtb.Columns[21].ColumnName = "TMP3";

            vtb.Columns[22].ColumnName = "TMP4";
            vtb.Columns[23].ColumnName = "TMP5";
            vtb.Columns[24].ColumnName = "TMP6";
            vtb.Columns[25].ColumnName = "TMP7";
            vtb.Columns[26].ColumnName = "TMP8";
            vtb.Columns[27].ColumnName = "TMP9";
            vtb.Columns[28].ColumnName = "TMP10";
            vtb.Columns[29].ColumnName = "STT";
   
            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TIEU_DE", Commons.Modules.TypeLanguage);


            if (TxtDN5.Value != TxtTN5.Value)
            {
                vRowTitle["TU_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TU_NGAY", Commons.Modules.TypeLanguage) + " " + TxtTN5.Text;
                vRowTitle["DEN_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "DEN_NGAY", Commons.Modules.TypeLanguage) + " " + TxtDN5.Text;
            }
            else
            {
                vRowTitle["TU_NGAY"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "sNgay", Commons.Modules.TypeLanguage) + " " + TxtTN5.Text;
                vRowTitle["DEN_NGAY"] = "";
            }


            if (Commons.Modules.sPrivate.ToUpper() == "VECO")
            {
                vRowTitle["DieuKienLoc"] = LabNX.Text;
            }
            else
            {

                vRowTitle["DieuKienLoc"] = LabNX.Text + " : " + CboNX.Text + "\n" +
                                       LabHT.Text + " : " + CboHT.Text + 
                                       "\n" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "LoaiThietBi", Commons.Modules.TypeLanguage) + " : " + CboLTB.Text +
                                       (cboLCV.EditValue.ToString() == "-99" ? "" : "\n" + LblThuocloaicongviec.Text + " : " + cboLCV.Text 
                                       );
            }
            vRowTitle["TMP4"] = CboNX.Text;
            vRowTitle["TMP5"] = LblThuocloaicongviec.Text;
            vRowTitle["TMP6"] = cboLCV.Text;

            vRowTitle["TMP7"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "LoaiThietBi", Commons.Modules.TypeLanguage);
            vRowTitle["TMP8"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP8", Commons.Modules.TypeLanguage);
            vRowTitle["TMP9"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP9", Commons.Modules.TypeLanguage);
            vRowTitle["TMP10"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP10", Commons.Modules.TypeLanguage);

            vRowTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "STT", Commons.Modules.TypeLanguage);

         


            //(TCot > 16 ? Excel.XlHAlign.xlHAlignCenter : Excel.XlHAlign.xlHAlignCenter)
            vRowTitle["BoPhan"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "BoPhan", Commons.Modules.TypeLanguage);
            vRowTitle["ThongSoGiamSat"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "ThongSoGiamSat", Commons.Modules.TypeLanguage);
            vRowTitle["GiaTri"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "GiaTri", Commons.Modules.TypeLanguage);
            vRowTitle["Dat"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "Dat", Commons.Modules.TypeLanguage);
            vRowTitle["NgayGSCuoi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NgayGSCuoi", Commons.Modules.TypeLanguage);
            vRowTitle["ChuKy"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "ChuKy", Commons.Modules.TypeLanguage);
            vRowTitle["NgayGSKe"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NgayGSKe", Commons.Modules.TypeLanguage);
            vRowTitle["KetQuaKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "KetQuaKT", Commons.Modules.TypeLanguage);
            vRowTitle["DiaDiem"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "DiaDiem", Commons.Modules.TypeLanguage);
            vRowTitle["ThietBi"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "ThietBi", Commons.Modules.TypeLanguage);
            vRowTitle["NgayKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NgayKT", Commons.Modules.TypeLanguage);
            vRowTitle["NguoiKT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NguoiKT", Commons.Modules.TypeLanguage);

            vRowTitle["MAU_SO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "MAU_SO", Commons.Modules.TypeLanguage);
            vRowTitle["LAN_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "LAN_BH", Commons.Modules.TypeLanguage);
            vRowTitle["NGAY_BH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "NGAY_BH", Commons.Modules.TypeLanguage);
            vRowTitle["TMP1"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP1", Commons.Modules.TypeLanguage);
            vRowTitle["TMP2"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP2", Commons.Modules.TypeLanguage);
            vRowTitle["TMP3"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTINH_TRANG_THIET_BI", "TMP3", Commons.Modules.TypeLanguage);



            vtb.Rows.Add(vRowTitle);

            return vtb;
        }

        private DataTable RefeshLangua6()
        {
            DataTable vtb = new DataTable();
            for (int i = 0; i < 12; i++)
            {
                vtb.Columns.Add();
            }
            vtb.Columns[0].ColumnName = "TIEU_DE";
            vtb.Columns[1].ColumnName = "DieuKienLoc";
            vtb.Columns[2].ColumnName = "MS_VTPT";
            vtb.Columns[3].ColumnName = "TEN_VTPT";
            vtb.Columns[4].ColumnName = "LOAI_VTPT";
            vtb.Columns[5].ColumnName = "TON_TOI_THIEU";
            vtb.Columns[6].ColumnName = "TON_HIEN_TAI";
            vtb.Columns[7].ColumnName = "VAT_TU";
            vtb.Columns[8].ColumnName = "STT";

            vtb.Columns[9].ColumnName = "MS_PT_NCC";
            vtb.Columns[10].ColumnName = "QUY_CACH";
            vtb.Columns[11].ColumnName = "TEN_KHO";


            DataRow vRowTitle = vtb.NewRow();
            vRowTitle["TIEU_DE"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TIEU_DE", Commons.Modules.TypeLanguage);
            vRowTitle["DieuKienLoc"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "DieuKienLoc", Commons.Modules.TypeLanguage) + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "LoaiThietBi", Commons.Modules.TypeLanguage) + ": " + CboLTB.Text;
            vRowTitle["MS_VTPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "MS_VTPT", Commons.Modules.TypeLanguage);
            vRowTitle["TEN_VTPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TEN_VTPT", Commons.Modules.TypeLanguage);
            vRowTitle["LOAI_VTPT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "LOAI_VTPT", Commons.Modules.TypeLanguage);
            vRowTitle["TON_TOI_THIEU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TON_TOI_THIEU", Commons.Modules.TypeLanguage);
            vRowTitle["TON_HIEN_TAI"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TON_HIEN_TAI", Commons.Modules.TypeLanguage);
            vRowTitle["VAT_TU"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "VAT_TU", Commons.Modules.TypeLanguage);
            vRowTitle["STT"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "STT", Commons.Modules.TypeLanguage);
            vRowTitle["MS_PT_NCC"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "MS_PT_NCC", Commons.Modules.TypeLanguage);
            vRowTitle["QUY_CACH"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "QUY_CACH", Commons.Modules.TypeLanguage);
            vRowTitle["TEN_KHO"] = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptVTPT_NHO_HON_TON_TOI_THIEU", "TEN_KHO", Commons.Modules.TypeLanguage);

            vtb.Rows.Add(vRowTitle);

            return vtb;
        }

        #region Nhu Y

        private void BindMay()
        {

            int index = TabReminder.SelectedTabPageIndex;
            int iCount;

            //((System.Collections.IList)cboMay1.Properties.DataSource).Count == 0 || 

            switch (index)
            {
                case 0:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay1.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 1:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay2.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 2:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay3.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 3:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay4.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 4:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay5.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
                case 5:
                    try
                    {
                        iCount = CboLPT6.Items.Count;
                    }
                    catch { iCount = 0; }
                    break;
                default:
                    try
                    {
                        iCount = ((System.Collections.IList)cboMay1.Properties.DataSource).Count;
                    }
                    catch { iCount = 0; }
                    break;
            }

            Commons.Modules.SQLString = "0LOAD";

            switch (index)
            {
                case 0:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMay1);
                        Commons.Modules.SQLString = "";
                        BinDataTBDHHC(cboMay1.EditValue.ToString()); ;
                        BinDataTBDHHC(cboMay1.EditValue.ToString()); ;
                    }
                    break;
                case 1:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMay2);
                        Commons.Modules.SQLString = "";
                        BinDataPBTTN(cboMay2.EditValue.ToString());
                    }
                    break;
                case 2:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMay3);
                        Commons.Modules.SQLString = "";
                        BinDataPBTQHKT(cboMay3.EditValue.ToString());
                    }
                    break;
                case 3:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMay4);
                        Commons.Modules.SQLString = "";
                        BinDataBTDK(cboMay4.EditValue.ToString());
                    }
                    break;
                case 4:
                    if (iCount == 0 || isChange)
                    {
                        BindMay(cboMay5);
                        Commons.Modules.SQLString = "";
                        BinDataTSGSTTDHKT();
                    }
                    break;
                case 5:
                    if (iCount == 0 || isChange)
                    {
                        Commons.Modules.SQLString = "";
                        BinDataVTPTSLNHTTT();
                    }
                    break;
                default:
                    if (iCount == 0 || isChange)
                        BindMay(cboMay1);
                    break;
            }
            isChange = false;
            Commons.Modules.SQLString = "";
        }

        private void LockTab(Boolean Locked)
        {
            CboHT.Enabled = Locked;
            CboLTB.Enabled = Locked;
            CboNX.Enabled = Locked;
        }





        private void CboTB5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BinDataTSGSTTDHKT();
        }

        private void CboLTB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = TabReminder.SelectedTabPageIndex;
            switch (index)
            {
                case 0:
                    BinDataTBDHHC(cboMay1.EditValue.ToString());
                    BinDataDCDDHHC(cboMay1.EditValue.ToString());
                    break;
                case 1:
                    BinDataPBTTN(cboMay2.EditValue.ToString());
                    break;
                case 2:
                    BinDataPBTQHKT(cboMay3.EditValue.ToString()); ;
                    break;
                case 3:
                    BinDataBTDK(cboMay4.EditValue.ToString());
                    break;
                case 4:
                    BinDataTSGSTTDHKT();
                    break;
                case 5:
                    BinDataVTPTSLNHTTT();
                    break;

            }
        }

        private void txtTKiem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataTable dtPT = new DataTable();
            try
            {
                string dk = "";

                int index = TabReminder.SelectedTabPageIndex;
                switch (index)
                {
                    case 0:
                        dtPT = (DataTable)DgvDCDDHHC1.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_VI_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  LOAI_HC LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 1:
                        dtPT = (DataTable)DgvPBTTN2.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_BT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 2:
                        dtPT = (DataTable)DgvPBTQHKT3.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PHIEU_BAO_TRI LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_BT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 3:
                        dtPT = (DataTable)DgvBTDK4.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 4:
                        dtPT = (DataTable)DgvGSTTDHKT5.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_MAY LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_BO_PHAN LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                    case 5:
                        dtPT = (DataTable)DgvVTPTNHTTT6.DataSource;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_PT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  QUY_CACH LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  MS_PT_NCC LIKE '%" + txtTKiem.Text + "%' " + dk;
                        if (txtTKiem.Text.Length != 0) dk = " OR  TEN_LOAI_VT LIKE '%" + txtTKiem.Text + "%' " + dk;
                        break;
                }


                //dtPT = (DataTable)DgvVTPTNHTTT6.DataSource;
                if (dk.Length > 0) dk = dk.Substring(5, dk.Length - 5);
                dtPT.DefaultView.RowFilter = dk;


            }
            catch { dtPT.DefaultView.RowFilter = ""; }
        }

        private void cboKho_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboKho.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            BinDataVTPTSLNHTTT();
        }

        private void CboLPT6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BinDataVTPTSLNHTTT();
        }

        private void CboKL_SelectionChangeCommitted(object sender, EventArgs e)
        {
            isChange = true;
            BindMay();

        }




        private void DgvTBDHHC1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Commons.Modules.sPrivate == "BARIA" || Commons.Modules.sPrivate == "VIETSOFT")
            {

                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip mnu = new ContextMenuStrip();
                    Image img = null;
                    int currentMouseOverRow = DgvTBDHHC1.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow >= 0)
                    {
                        mnu.Items.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReminder_new", "mnuLapPBT", Commons.Modules.TypeLanguage) + " : " +
                            DgvTBDHHC1[0, DgvTBDHHC1.CurrentRow.Index].Value.ToString(), img, new System.EventHandler(mnuHCMayClick));
                    }
                    mnu.Show(DgvTBDHHC1, new Point(e.X, e.Y));
                }
            }
        }

        private void mnuHCMayClick(Object sender, System.EventArgs e)
        {
            Commons.Modules.SQLString = "frmReminder_new";
            //Commons.Modules.SQLString = "frmReminder_newDCD";

            frmLapphieubaotri_CS frm = new frmLapphieubaotri_CS();
            frm.MS_MAY = DgvTBDHHC1[0, DgvTBDHHC1.CurrentRow.Index].Value.ToString();
            //frm.sMsVatTu = DgvDCDDHHC1[2, DgvTBDHHC1.CurrentRow.Index].Value.ToString();
            frm.ShowDialog();
            Commons.Modules.SQLString = "";
        }

        private void DgvDCDDHHC1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Commons.Modules.sPrivate == "BARIA" || Commons.Modules.sPrivate == "VIETSOFT")
            {

                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip mnu = new ContextMenuStrip();
                    //a = new ContextMenuStrip();
                    Image img = null;
                    int currentMouseOverRow = DgvDCDDHHC1.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow >= 0)
                    {
                        mnu.Items.Add(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmReminder_new", "mnuLapPBT", Commons.Modules.TypeLanguage) + " : " +
                            DgvDCDDHHC1[0, DgvDCDDHHC1.CurrentRow.Index].Value.ToString(), img, new System.EventHandler(mnuHCDCDClick));
                    }
                    mnu.Show(DgvDCDDHHC1, new Point(e.X, e.Y));
                }
            }
        }


        private void mnuHCDCDClick(Object sender, System.EventArgs e)
        {

            Commons.Modules.SQLString = "frmReminder_newDCD";
            frmLapphieubaotri_CS frm = new frmLapphieubaotri_CS();
            frm.MS_MAY = DgvTBDHHC1[0, DgvTBDHHC1.CurrentRow.Index].Value.ToString();
            frm.sMsVatTu = DgvDCDDHHC1[2, DgvTBDHHC1.CurrentRow.Index].Value.ToString();
            frm.ShowDialog();
            Commons.Modules.SQLString = "";
        }



        private DataTable TonTheoBaria()
        {
            string sINTConnect = "";
            string sSql = "";
            string sBT = "TON_TOI_THIEU_TMP" + Commons.Modules.UserName;
            string sBTdata = "TON_TT_TMP" + Commons.Modules.UserName;
            try
            {
                sSql = "SELECT TOP 1 SYN_INFO FROM THONG_TIN_CHUNG";
                sINTConnect = Commons.Modules.ObjSystems.GiaiMaDL(Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql)));
                if (sINTConnect == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name,
                        "msgChuaCoThongTinCuaDataINT", Commons.Modules.TypeLanguage), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                //Lay du lieu ton tu data NIKITA
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(sINTConnect, "sp_PHU_TUNG_SL"));
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");

                Commons.Modules.ObjSystems.XoaTable(sBTdata);

                sSql = "";
                //if (cboKho.SelectedValue.ToString() == "-1" || cboKho.SelectedValue.ToString() == "0")
                sSql = " SELECT A.MS_PT,A.MS_KHO, SUM(SL) AS SL_VT INTO  " + sBTdata + " FROM " + sBT + " A INNER JOIN ( ";

                if (cboKho.SelectedValue.ToString() == "-1" || cboKho.SelectedValue.ToString() == "0")
                {
                    if (cboKho.SelectedValue.ToString() == "-1")
                    {
                        sSql += " SELECT DISTINCT T2.MS_KHO, T1.MS_PT FROM dbo.IC_PHU_TUNG AS T1 CROSS JOIN dbo.IC_KHO AS T2 " +
                                        " WHERE     (T1.THEO_KHO = 0) " +
                                        " UNION " +
                                        " SELECT DISTINCT T2.MS_KHO, T1.MS_PT FROM dbo.IC_PHU_TUNG AS T1 INNER JOIN IC_PHU_TUNG_KHO T2 ON T1.MS_PT = T2.MS_PT " +
                                        " WHERE     (T1.THEO_KHO = 1) ";
                    }
                    else
                    {
                        sSql += " SELECT DISTINCT T2.MS_KHO, T1.MS_PT FROM dbo.IC_PHU_TUNG AS T1 CROSS JOIN dbo.IC_KHO AS T2 " +
                                        " WHERE     (T1.THEO_KHO = 0) ";
                    }
                }
                else

                    sSql += " SELECT DISTINCT T2.MS_KHO, T1.MS_PT FROM dbo.IC_PHU_TUNG AS T1 INNER JOIN IC_PHU_TUNG_KHO T2 ON T1.MS_PT = T2.MS_PT " +
                                    " WHERE     (T1.THEO_KHO = 1) AND MS_KHO = " + cboKho.SelectedValue.ToString();

                sSql += " ) B ON A.MS_PT = B.MS_PT AND A.MS_KHO = B.MS_KHO GROUP BY A.MS_PT,A.MS_KHO ";
                SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql);

                dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "SP_Y_GET_VTPT_SLNH_SLTTT_BARIA",
                                Commons.Modules.TypeLanguage, CboLPT6.SelectedValue, KhongKho, cboKho.SelectedValue, sBTdata));


                Commons.Modules.ObjSystems.XoaTable(sBTdata);
                Commons.Modules.ObjSystems.XoaTable(sBT);
                return dtTmp;
            }
            catch (Exception EX)
            {
                Commons.Modules.ObjSystems.XoaTable(sBTdata);
                Commons.Modules.ObjSystems.XoaTable(sBT);
                DevExpress.XtraEditors.XtraMessageBox.Show(EX.Message);
                return null;
            }


        }

        private void chkTonTT_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp = ((DataTable)DgvVTPTNHTTT6.DataSource);
            string sDK = "";
            LocDataTonBaria(out sDK);
            dtTmp.DefaultView.RowFilter = sDK;
            dtTmp = dtTmp.DefaultView.ToTable();

        }
        private void LocDataTonBaria(out string sLoc)
        {
            //--(VI_TRI_KHO_VAT_TU_TMP.TON_TOI_THIEU > VI_TRI_KHO_VAT_TU_TMP.SL_VTPT) AND 

            string sDK = "";
            string sKho = "";
            if (Commons.Modules.sPrivate == "BARIA")
            {
                sDK = (chkTonTT.Checked ? sDK = " TON_TOI_THIEU > TON_TT " : "");
            }
            try
            {


                if (cboKho.SelectedValue.ToString() != "-1")
                {
                    sKho = " MS_KHO = " + Convert.ToInt16(cboKho.SelectedValue.ToString());
                }

                sDK = (sDK.ToString().Length == 0 ? sKho : (sKho.ToString().Length == 0 ? sDK : sDK + " AND " + sKho));



                //dtTmp.DefaultView.RowFilter = "MS_KHO = " + Convert.ToInt16(cboKho.SelectedValue.ToString());
                sLoc = sDK;
            }
            catch { sLoc = ""; }

        }

        private void cboMay1_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataTBDHHC(cboMay1.EditValue.ToString()); ;
                BinDataDCDDHHC(cboMay1.EditValue.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            this.Cursor = Cursors.Default;
        }

        private void TxtTN1_Validating(object sender, CancelEventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataTBDHHC(cboMay1.EditValue.ToString()); ;
                BinDataDCDDHHC(cboMay1.EditValue.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void cboMay2_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataPBTTN(cboMay2.EditValue.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void cboMay3_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataPBTQHKT(cboMay3.EditValue.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void cboMay4_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataBTDK(cboMay4.EditValue.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void TxtTN4_Validated(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataBTDK(cboMay4.EditValue.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }

        private void cboMay5_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataTSGSTTDHKT();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;

        }

        private void TxtTN5_Validated(object sender, EventArgs e)
        {
            if (Commons.Modules.SQLString == "0LOAD") return;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BinDataTSGSTTDHKT();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            this.Cursor = Cursors.Default;
        }

        private void TabReminder_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (TabReminder.SelectedTabPageIndex == 4)
                {
                    Commons.Modules.SQLString = "0LOAD";
                    DataTable dtTmp = new DataTable();
                    dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text,
                                " SELECT T1.MS_LOAI_CV,T1.TEN_LOAI_CV FROM LOAI_CONG_VIEC T1 INNER JOIN NHOM_LOAI_CONG_VIEC T2 ON " +
                                " T1.MS_LOAI_CV = T2.MS_LOAI_CV INNER JOIN USERS T3 ON T2.GROUP_ID = T3.GROUP_ID " +
                                " WHERE USERNAME = '" + Commons.Modules.UserName + "' " +
                                " UNION SELECT -1, ' < ALL > '  UNION SELECT -99, N'" + Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "rptTHIET_BI_DEN_HAN_HIEU_CHUAN", "sDN", Commons.Modules.TypeLanguage) + "' " +
                                " ORDER BY TEN_LOAI_CV"));
                    Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLCV, dtTmp, "MS_LOAI_CV", "TEN_LOAI_CV", "");
                    Commons.Modules.SQLString = "";
                }
                BindMay();
                if (TabReminder.SelectedTabPageIndex == 5) LockTab(false); else LockTab(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
    #endregion
}