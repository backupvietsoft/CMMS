using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

namespace PhucHoiDLKho
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private FileInfo vFile = new FileInfo("AnhNhat.txt");
        private StreamWriter FileStr;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadKho();
         
        }
        
        void LoadKho()
        {
            DataTable vtb = new DataTable();
            vtb.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, "Select MS_KHO,TEN from IC_KHO"));
            cboKho.DisplayMember = "TEN";
            cboKho.ValueMember = "MS_KHO";
            cboKho.DataSource = vtb;
        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable vtb = new DataTable();
                vtb.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, "Select MS_VI_TRI,TEN_VI_TRI from VI_TRI_KHO WHERE MS_KHO = '" + cboKho.SelectedValue.ToString() + "'"));
                cboVitriKho.DisplayMember = "TEN_VI_TRI";
                cboVitriKho.ValueMember = "MS_VI_TRI";
                cboVitriKho.DataSource = vtb;
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //FileStr = vFile.CreateText();

            CapNhatSLNKho(cboKho.SelectedValue.ToString());
            CapNhatSLNKhoChiTiet(cboKho.SelectedValue.ToString());
            CapNhatSLXKho(cboKho.SelectedValue.ToString());
            CapNhatSLXKhoChiTiet(cboKho.SelectedValue.ToString());
            XoaKhoKiemKe();
            CapNhatVitriKhoNull(cboKho.SelectedValue.ToString());
            XoaTonKho(cboKho.SelectedValue.ToString());
            XoaViTriXuatKho(cboKho.SelectedValue.ToString());
            TinhLaiDuLieu(cboKho.SelectedValue.ToString());
            //CloseFile();
            
        }

        void CapNhatSLNKhoChiTiet(string _kho)
        {
            lbaStatus.Text = "Cập nhật số lượng nhập kho chi tiết";
            string sql = "UPDATE dbo.NHAP_NPL_VI_TRI_IC SET so_luong = round (so_luong, 2) " +
                         " where   so_luong <> convert (INT,  so_luong) AND dbo.NHAP_NPL_VI_TRI_IC.MS_DHN IN " +
                         " ( SELECT dbo.NHAP_NPL_IC.MS_DHN FROM  dbo.NHAP_NPL_IC " +
                         " WHERE dbo.NHAP_NPL_IC.MS_KHO = '"+ _kho +"')";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sql);
        }
        void CapNhatSLXKhoChiTiet(string _kho)
        {
            lbaStatus.Text = "Cập nhật số lượng xuất kho chi tiết";
            string sql = "UPDATE dbo.XUAT_NPL_CHI_TIET_IC SET so_luong = round (so_luong, 2) " +
                         " where   so_luong <> convert (INT,  so_luong) AND dbo.XUAT_NPL_CHI_TIET_IC.MS_DHX IN " +
                         " ( SELECT dbo.XUAT_NPL_IC.MS_DHX FROM  dbo.XUAT_NPL_IC " +
                         " WHERE dbo.XUAT_NPL_IC.MS_KHO = '" + _kho + "')";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sql);
        }
        void CapNhatSLNKho(string _kho)
        {
            lbaStatus.Text = "Cập nhật số lượng nhập kho ";
            string sql = "UPDATE dbo.NHAP_NPL_CHI_TIET_IC SET SLTN = round (SLTN, 2) " +
                         " where   SLTN <> convert (INT,  SLTN) AND dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN IN " +
                         " ( SELECT dbo.NHAP_NPL_IC.MS_DHN FROM  dbo.NHAP_NPL_IC " +
                         " WHERE dbo.NHAP_NPL_IC.MS_KHO = '" + _kho + "')";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sql);
        }

        void XoaKhoKiemKe()
        {
            string sql = "DELETE dbo.KIEM_KE_VAT_TU_CHI_TIET WHERE  dbo.KIEM_KE_VAT_TU_CHI_TIET.MS_KHO NOT IN (SELECT dbo.IC_KHO.MS_KHO FROM dbo.IC_KHO)";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sql);
            string sql1 = "DELETE dbo.KIEM_KE WHERE  dbo.KIEM_KE.MS_KHO NOT IN (SELECT dbo.IC_KHO.MS_KHO FROM dbo.IC_KHO)";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sql1);
        }

        void CapNhatSLXKho(string _kho)
        {
            string sql = "Update dbo.XUAT_NPL_CHI_TIET_IC set SO_LUONG = round (SO_LUONG, 3) " +
                         " where SO_LUONG <> convert (INT,  SO_LUONG) AND dbo.XUAT_NPL_CHI_TIET_IC.MS_DHX IN " +
                         " (SELECT MS_DHX  FROM  dbo.XUAT_NPL_IC WHERE dbo.XUAT_NPL_IC.MS_KHO = '" + _kho + "')";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text,sql);
        }

        void CapNhatVitriKhoNull(string _kho)
        {

            //KIEM TRA LAI

            string sqlDelete1 = "DELETE dbo.NHAP_NPL_VI_TRI_IC " +
                              " WHERE ROUND(dbo.NHAP_NPL_VI_TRI_IC.SO_LUONG, 3) = 0 " +
                              " AND dbo.NHAP_NPL_VI_TRI_IC.MS_DHN IN (SELECT dbo.NHAP_NPL_IC.MS_DHN FROM dbo.NHAP_NPL_IC WHERE MS_KHO = '" + _kho + "')";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlDelete1);

            string sqlDelet_HDMH = "DELETE dbo.NHAP_NPL_HDMH_IC WHERE (ROUND(dbo.NHAP_NPL_HDMH_IC.SLTN,3) = 0 OR dbo.NHAP_NPL_HDMH_IC.SLTN IS NULL ) AND " +
                " dbo.NHAP_NPL_HDMH_IC.MS_DHN IN (SELECT dbo.NHAP_NPL_IC.MS_DHN FROM dbo.NHAP_NPL_IC WHERE MS_KHO = '" + _kho + "')";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlDelet_HDMH);

            string sqlDelete2 = "DELETE dbo.NHAP_NPL_CHI_TIET_IC " +
                                " WHERE dbo.NHAP_NPL_CHI_TIET_IC.SLTN = 0 " +
                                " AND dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN IN (SELECT dbo.NHAP_NPL_IC.MS_DHN FROM dbo.NHAP_NPL_IC WHERE MS_KHO  = '" + _kho + "')";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlDelete2);


            string sql = "SELECT dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN, dbo.NHAP_NPL_CHI_TIET_IC.MS_VT, dbo.NHAP_NPL_CHI_TIET_IC.MAU_VT, " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.KHO_VT, dbo.NHAP_NPL_CHI_TIET_IC.DVT, dbo.NHAP_NPL_CHI_TIET_IC.SLCT, dbo.NHAP_NPL_VI_TRI_IC.MS_VI_TRI, " +
                      " dbo.NHAP_NPL_VI_TRI_IC.SO_LUONG, dbo.NHAP_NPL_CHI_TIET_IC.SLTN " +
                      " FROM dbo.NHAP_NPL_CHI_TIET_IC INNER JOIN " +
                      " dbo.NHAP_NPL_IC ON dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN = dbo.NHAP_NPL_IC.MS_DHN LEFT OUTER JOIN " +
                      " dbo.NHAP_NPL_VI_TRI_IC ON dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN = dbo.NHAP_NPL_VI_TRI_IC.MS_DHN AND " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.MS_VT = dbo.NHAP_NPL_VI_TRI_IC.MS_VT AND " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.MAU_VT = dbo.NHAP_NPL_VI_TRI_IC.MAU_VT AND " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.KHO_VT = dbo.NHAP_NPL_VI_TRI_IC.KHO_VT AND " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.DVT = dbo.NHAP_NPL_VI_TRI_IC.DVT " +
                      " WHERE dbo.NHAP_NPL_VI_TRI_IC.MS_VI_TRI IS NULL AND dbo.NHAP_NPL_IC.MS_KHO = '" + _kho +"' ";
            DataTable vtb = new DataTable();
            vtb.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text,sql));

            foreach (DataRow vr in vtb.Rows)
            {
                string sqlInsert = "INSERT INTO dbo.NHAP_NPL_VI_TRI_IC (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_VI_TRI, SO_LUONG ) " +
                    " VALUES ('" + vr["MS_DHN"].ToString() + "','" + vr["MS_VT"].ToString() + "','" + vr["MAU_VT"].ToString() + "','" +
                    vr["KHO_VT"].ToString() + "','" + vr["DVT"].ToString() + "','" + cboVitriKho.SelectedValue.ToString() + "','" +
                    vr["SLTN"].ToString() + "')";
                SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlInsert);
            }
        }

        void XoaTonKho(string _kho)
        {
            string sql = "DELETE dbo.VI_TRI_KHO_VAT_TU WHERE MS_KHO ='" + _kho + "'";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sql);
        }

        void XoaViTriXuatKho(string _kho)
        {
            string sql = "DELETE dbo.XUAT_NPL_VI_TRI_IC WHERE  MS_DHX IN (SELECT MS_DHX FROM dbo.XUAT_NPL_IC WHERE dbo.XUAT_NPL_IC.MS_KHO =N'" + _kho + "')";
            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sql);
        }

        void TinhLaiDuLieu(string _Kho)
        {
            string sql = "select MS_DHN as DON_HANG , CONVERT(DATETIME,CONVERT(NVARCHAR(10),NGAY_NHAP,101)+ ' ' + CONVERT(NVARCHAR(8),GIO_NHAP,108),101) as NGAY , 'N' as LOAI , NGAY_NHAP AS NGIO from dbo.NHAP_NPL_IC " +
              " where MS_KHO = '" + _Kho + "'" +
              " Union " +
              " select MS_DHX as DON_HANG, CONVERT(DATETIME,CONVERT(NVARCHAR(10),NGAY_XUAT,101)+ ' ' + CONVERT(NVARCHAR(8),GIO_XUAT,108),101) as NGAY , 'X' as LOAI , NGAY_XUAT AS NGIO from dbo.XUAT_NPL_IC " +
              " where MS_KHO = '" + _Kho + "'" +
              " union " +
              " select  '0' as DON_HANG, CONVERT(DATETIME,CONVERT(NVARCHAR(10),NGAY,101)+ ' ' + GIO + ':00:000',101) as NGAY , 'K' as LOAI , NGAY AS NGIO from  KIEM_KE WHERE MS_KHO = '" + _Kho +"'" +
              " order by ngay ";
            DataTable vData = new DataTable();
            vData.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sql));

            DataView DvKiemKe = new DataView(vData, "LOAI = 'K'", "NGAY", DataViewRowState.CurrentRows);


            int sttKiemKe = 0;
            DateTime NgayKKTruoc = new DateTime();

            foreach (DataRow vKiemKe in DvKiemKe.ToTable().Rows)
            {
                DataView DvNhap ;
                DataView DvXuat;

                if (sttKiemKe == 0)
                {

                    //cap nhat phieu nhap
                    DvNhap = new DataView(vData, "LOAI = 'N' AND NGAY < '" + vKiemKe["NGAY"] + "'", "NGAY", DataViewRowState.CurrentRows);
                    DvXuat = new DataView(vData, "LOAI = 'X' AND NGAY < '" + vKiemKe["NGAY"] + "'", "NGAY", DataViewRowState.CurrentRows);
                    NgayKKTruoc = (DateTime)vKiemKe["NGAY"];
                    sttKiemKe++;
                }
                else
                {
                    DvNhap = new DataView(vData, "LOAI = 'N' AND NGAY < '" + vKiemKe["NGAY"] + "' AND NGAY > '" + NgayKKTruoc + "'", "NGAY", DataViewRowState.CurrentRows);
                    DvXuat = new DataView(vData, "LOAI = 'X' AND NGAY < '" + vKiemKe["NGAY"] + "' AND NGAY > '" + NgayKKTruoc + "'", "NGAY", DataViewRowState.CurrentRows);
                    NgayKKTruoc = (DateTime)vKiemKe["NGAY"];
                }

                foreach (DataRow vrNhap in DvNhap.ToTable().Rows)
                {
                    //if (vrNhap["DON_HANG"].ToString().Equals("132"))
                    //{
                    //    string ds = "";
                    //}

                    string sqlChiTietDH = "SELECT  dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN, dbo.NHAP_NPL_CHI_TIET_IC.MS_VT, dbo.NHAP_NPL_CHI_TIET_IC.MAU_VT, " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.KHO_VT, dbo.NHAP_NPL_CHI_TIET_IC.DVT, dbo.NHAP_NPL_VI_TRI_IC.MS_VI_TRI, " +
                      " dbo.NHAP_NPL_VI_TRI_IC.SO_LUONG, dbo.NHAP_NPL_CHI_TIET_IC.SLTN " +
                      " FROM  dbo.NHAP_NPL_CHI_TIET_IC INNER JOIN " +
                      " dbo.NHAP_NPL_VI_TRI_IC ON dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN = dbo.NHAP_NPL_VI_TRI_IC.MS_DHN AND " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.MS_VT = dbo.NHAP_NPL_VI_TRI_IC.MS_VT AND " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.MAU_VT = dbo.NHAP_NPL_VI_TRI_IC.MAU_VT AND " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.KHO_VT = dbo.NHAP_NPL_VI_TRI_IC.KHO_VT AND " +
                      " dbo.NHAP_NPL_CHI_TIET_IC.DVT = dbo.NHAP_NPL_VI_TRI_IC.DVT " +
                      " WHERE (dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN = '" + vrNhap["DON_HANG"].ToString() + "')";

                    DataTable vDHInfo = new DataTable();
                    vDHInfo.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sqlChiTietDH));

                    DataTable vDHChiTiet = new DataTable();

                    vDHChiTiet = vDHInfo.DefaultView.ToTable(true, "MS_DHN", "MS_VT", "MAU_VT", "KHO_VT", "DVT", "SLTN");

                    foreach (DataRow vrowCT in vDHChiTiet.Rows)
                    {
                        DataView dtChiTietVT = new DataView(vDHInfo, "MS_DHN = '" + vrowCT["MS_DHN"].ToString() +
                        "' AND MS_VT = '" + vrowCT["MS_VT"].ToString() + "' AND  MAU_VT = '" + vrowCT["MAU_VT"].ToString() +
                        "' AND KHO_VT = '" + vrowCT["KHO_VT"].ToString() + "' AND DVT = '" + vrowCT["DVT"].ToString() + "'", "MS_VI_TRI", DataViewRowState.CurrentRows);

                        int stt = 0;
                        float TongTrenVT = 0;
                        foreach (DataRow vrowVT in dtChiTietVT.ToTable().Rows)
                        {
                            TongTrenVT = TongTrenVT + float.Parse(vrowVT["SO_LUONG"].ToString());
                            stt++;
                            if (stt != dtChiTietVT.ToTable().Rows.Count)
                            {
                                // them vao vi tri kho vat tu ( vi tri n -1 )
                                string vIS_VitriKhoVT = "INSERT INTO dbo.VI_TRI_KHO_VAT_TU (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_KHO, MS_VI_TRI, SO_LUONG) " +
                                  " VALUES ('" + vrowVT["MS_DHN"].ToString() + "','" + vrowVT["MS_VT"].ToString() + "','" + vrowVT["MAU_VT"].ToString() +
                                  "','" + vrowVT["KHO_VT"].ToString() + "','" + vrowVT["DVT"].ToString() + "','" + _Kho + "','" + vrowVT["MS_VI_TRI"].ToString() + "','" + vrowVT["SO_LUONG"].ToString() + "')";
                                SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vIS_VitriKhoVT);
                            }
                        }

                        if (float.Parse(vrowCT["SLTN"].ToString()) != TongTrenVT)
                        {
                            float slMoi = float.Parse(dtChiTietVT.ToTable().Rows[stt - 1]["SO_LUONG"].ToString()) + (float.Parse(vrowCT["SLTN"].ToString()) - TongTrenVT);

                            string sqlCNVitri = "UPDATE dbo.NHAP_NPL_VI_TRI_IC SET  SO_LUONG = ROUND(" + slMoi + ",2) WHERE MS_DHN = '" + vrowCT["MS_DHN"].ToString() +
                                 "' AND MS_VT = '" + vrowCT["MS_VT"].ToString() + "' AND  MAU_VT = N'" + vrowCT["MAU_VT"].ToString() +
                                 "' AND KHO_VT = N'" + vrowCT["KHO_VT"].ToString() + "' AND DVT = '" + vrowCT["DVT"].ToString() + "' AND MS_VI_TRI = '" + dtChiTietVT.ToTable().Rows[stt - 1]["MS_VI_TRI"].ToString() + "'";
                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlCNVitri);

                            // them vao vi tri kho vat tu (vi tri cuoi)
                            string vIS_VitriKhoVT = "INSERT INTO dbo.VI_TRI_KHO_VAT_TU (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_KHO, MS_VI_TRI, SO_LUONG) " +
                                  " VALUES ('" + vrowCT["MS_DHN"].ToString() + "',N'" + vrowCT["MS_VT"].ToString() + "',N'" + vrowCT["MAU_VT"].ToString() +
                                  "',N'" + vrowCT["KHO_VT"].ToString() + "',N'" + vrowCT["DVT"].ToString() + "','" + _Kho + "','" + dtChiTietVT.ToTable().Rows[stt - 1]["MS_VI_TRI"].ToString() + "',ROUND(" + slMoi + ",2))";
                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vIS_VitriKhoVT);
                        }
                        else
                        {
                            // them vao vi tri kho vat tu (vi tri cuoi)
                            string vIS_VitriKhoVT = "INSERT INTO dbo.VI_TRI_KHO_VAT_TU (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_KHO, MS_VI_TRI, SO_LUONG) " +
                                  " VALUES ('" + vrowCT["MS_DHN"].ToString() + "',N'" + vrowCT["MS_VT"].ToString() + "',N'" + vrowCT["MAU_VT"].ToString() +
                                  "',N'" + vrowCT["KHO_VT"].ToString() + "',N'" + vrowCT["DVT"].ToString() + "',N'" + _Kho + "','" + dtChiTietVT.ToTable().Rows[stt - 1]["MS_VI_TRI"].ToString() + "', ROUND(" + dtChiTietVT.ToTable().Rows[stt - 1]["SO_LUONG"].ToString() + ",2))";
                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vIS_VitriKhoVT);
                        }
                    }
                }
                //cap nhat phieu xuat
            
                foreach (DataRow vrXuat in DvXuat.ToTable().Rows)
                {
                    string sqlInfoPX = "SELECT MS_DHX , MS_VT, MAU_VT, KHO_VT, DVT, SO_LUONG " +
                    " FROM dbo.XUAT_NPL_CHI_TIET_IC WHERE MS_DHX = '" + vrXuat["DON_HANG"].ToString() + "'";
                    DataTable vDHInfo = new DataTable();
                    vDHInfo.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sqlInfoPX));
                    //if (vrXuat["DON_HANG"].ToString() == "2544")
                    //{
                    //    MessageBox.Show("Fdfd");
                    //}
                    foreach (DataRow vrs in vDHInfo.Rows)
                    {
                        string sqlPN = "SELECT dbo.VI_TRI_KHO_VAT_TU.SO_LUONG, dbo.VI_TRI_KHO_VAT_TU.MS_DHN, dbo.VI_TRI_KHO_VAT_TU.MS_VT, dbo.VI_TRI_KHO_VAT_TU.MAU_VT, " +
                                      " dbo.VI_TRI_KHO_VAT_TU.KHO_VT, dbo.VI_TRI_KHO_VAT_TU.DVT, dbo.VI_TRI_KHO_VAT_TU.MS_KHO, dbo.VI_TRI_KHO_VAT_TU.MS_VI_TRI, " +
                                      " CONVERT(DATETIME,CONVERT(NVARCHAR(10),dbo.NHAP_NPL_IC.NGAY_NHAP,101)+ ' ' + CONVERT(NVARCHAR(8),dbo.NHAP_NPL_IC.GIO_NHAP,108),101) as NGAY " +
                                       " , CONVERT(FLOAT,0.0) AS SL_MOI " +
                                      " FROM    dbo.VI_TRI_KHO_VAT_TU INNER JOIN " +
                                      " dbo.NHAP_NPL_IC ON dbo.VI_TRI_KHO_VAT_TU.MS_DHN = dbo.NHAP_NPL_IC.MS_DHN " +
                                      " WHERE dbo.VI_TRI_KHO_VAT_TU.MS_VT = N'" + vrs["MS_VT"].ToString() + "' AND " +
                                      " dbo.VI_TRI_KHO_VAT_TU.MAU_VT = N'" + vrs["MAU_VT"].ToString() + "' AND dbo.VI_TRI_KHO_VAT_TU.KHO_VT = N'" + vrs["KHO_VT"].ToString() + "' AND " +
                                      " dbo.VI_TRI_KHO_VAT_TU.DVT = N'" + vrs["DVT"].ToString() + "' AND dbo.VI_TRI_KHO_VAT_TU.MS_KHO = N'" + _Kho +"'";
                        DataTable vtbKho = new DataTable();
                        vtbKho.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sqlPN));
                        vtbKho.Columns["SL_MOI"].ReadOnly = false;
                       

                        float slXuat = float.Parse(vrs["SO_LUONG"].ToString());
                        int j = 0;
                        foreach (DataRow vrKho in vtbKho.Rows)
                        {
                            if (slXuat > 0)
                            {
                                if (float.Parse(vrKho["SO_LUONG"].ToString()) < slXuat)
                                {
                                    vtbKho.Rows[j]["SL_MOI"] = float.Parse(vrKho["SO_LUONG"].ToString());
                                    slXuat = slXuat - float.Parse(vrKho["SO_LUONG"].ToString());
                                   
                                }
                                else
                                {
                                    vtbKho.Rows[j]["SL_MOI"] = slXuat ;
                                    slXuat = 0;
                                }
                            }
                            else
                                break;
                            j++;
                        }

                        //if (slXuat > 0)
                        //{
                        //    string PXInfo = vrXuat["DON_HANG"].ToString() + "\t" + vrXuat["NGAY"].ToString() +  "\t" + vrs["MS_VT"].ToString() + "\t\t" + vrs["MAU_VT"].ToString() + "\t\t" + vrs["KHO_VT"].ToString() + "\t\t" + vrs["DVT"].ToString() + "\t\t" + slXuat.ToString();
                        //    Writetextfile(PXInfo);
                        //}

                        DataView DataNew = new DataView(vtbKho, "SL_MOI <> 0", "", DataViewRowState.CurrentRows);
                        foreach (DataRow vrow in DataNew.ToTable().Rows)
                        {
                            float vSL = float.Parse(vrow["SO_LUONG"].ToString()) - float.Parse(vrow["SL_MOI"].ToString());

                            string vXVT = "INSERT INTO dbo.XUAT_NPL_VI_TRI_IC (MS_DHX, MS_VT, MAU_VT, KHO_VT, DVT, MS_VI_TRI, SL_VT, MS_DHN )" +
                                " VALUES ('" + vrXuat["DON_HANG"].ToString() + "','" + vrow["MS_VT"].ToString() + "', '" +
                                 vrow["MAU_VT"].ToString() + "','" + vrow["KHO_VT"].ToString() + "','" +
                                vrow["DVT"].ToString() + "','" + vrow["MS_VI_TRI"].ToString() + "', ROUND(" + vrow["SL_MOI"].ToString() + ",2),'" + vrow["MS_DHN"].ToString() + "' )";
                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vXVT);
                            if (vrow["MS_VT"].ToString() == "1880000496")
                            {
                                string aaa = "aaaa";
                            }                                                        
                            string sqlUD = "UPDATE dbo.VI_TRI_KHO_VAT_TU SET SO_LUONG = ROUND(" + vSL + ",2)" +
                                " WHERE   MS_DHN = '" + vrow["MS_DHN"].ToString() + "' AND MS_VT = N'" + vrow["MS_VT"].ToString() + "' AND " +
                                " MAU_VT = N'" + vrow["MAU_VT"].ToString() + "' AND KHO_VT = N'" + vrow["KHO_VT"].ToString() + "' AND " +
                                " DVT = N'" + vrow["DVT"].ToString() + "' AND MS_KHO = N'" + vrow["MS_KHO"].ToString() + "' AND MS_VI_TRI = N'" + vrow["MS_VI_TRI"].ToString() + "'";
                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlUD);
                        }
                    } 
                }
                // THEM CAC PHIEUNHAP KHONG CO TRONG kiem ke MA CO TRONG VITRI KHO
                //string sqlInKK = " INSERT INTO [KIEM_KE_VAT_TU_CHI_TIET]([MS_KHO],[NGAY],[MS_VT],[MAU_VT], " +
                //        " [KHO_VT],[DVT],[MS_VI_TRI],SO_LUONG_CT,[MS_DHN],SO_LUONG_KK,DON_GIA_KK) " +
                //        " SELECT [MS_KHO],'" + ((DateTime)vKiemKe["NGIO"]).ToString("MM/dd/yyyy HH:mm:ss") + "', " +
                //        " [MS_VT],[MAU_VT], [KHO_VT],[DVT],[MS_VI_TRI],SO_LUONG, " +
                //        " [MS_DHN],SO_LUONG,DON_GIA_VND FROM  VI_TRI_KHO_VAT_TU  A " +
                //        " WHERE NOT EXISTS ( SELECT * FROM KIEM_KE_VAT_TU_CHI_TIET B WHERE  " +
                //        " A.MS_DHN = B.MS_DHN AND A.MS_VT = B.MS_VT AND A.MAU_VT = B.MAU_VT  " +
                //        " AND A.KHO_VT = B.KHO_VT AND A.DVT = B.DVT AND A.MS_KHO = B.MS_KHO  " +
                //        " AND A.MS_VI_TRI = B.MS_VI_TRI  AND CONVERT(nvarchar(10),NGAY,101) = " +
                //        " CONVERT(DATETIME,'" + ((DateTime)vKiemKe["NGAY"]).ToString("MM/dd/yyyy") + "',101)  " +
                //        " AND MS_KHO = '" + _Kho + "' ) ";
                //SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlInKK);

                            // Cap nhat kiem ke
                string sqlKiemKe = "SELECT  dbo.KIEM_KE_VAT_TU_CHI_TIET.MS_VT, dbo.KIEM_KE_VAT_TU_CHI_TIET.MAU_VT, dbo.KIEM_KE_VAT_TU_CHI_TIET.KHO_VT,  " +
                      " dbo.KIEM_KE_VAT_TU_CHI_TIET.DVT, dbo.KIEM_KE_VAT_TU_CHI_TIET.MS_VI_TRI, dbo.KIEM_KE_VAT_TU_CHI_TIET.MS_DHN, " +
                      " dbo.KIEM_KE_VAT_TU_CHI_TIET.NGAY, dbo.KIEM_KE_VAT_TU_CHI_TIET.SO_LUONG_CT, dbo.KIEM_KE_VAT_TU_CHI_TIET.SO_LUONG_KK, " +
                      " dbo.VI_TRI_KHO_VAT_TU.SO_LUONG " +
                      " FROM  dbo.KIEM_KE_VAT_TU_CHI_TIET INNER JOIN " +
                      " dbo.VI_TRI_KHO_VAT_TU ON dbo.KIEM_KE_VAT_TU_CHI_TIET.MS_DHN = dbo.VI_TRI_KHO_VAT_TU.MS_DHN AND " +
                      " dbo.KIEM_KE_VAT_TU_CHI_TIET.MS_VT = dbo.VI_TRI_KHO_VAT_TU.MS_VT AND " +
                      " dbo.KIEM_KE_VAT_TU_CHI_TIET.MAU_VT = dbo.VI_TRI_KHO_VAT_TU.MAU_VT AND " +
                      " dbo.KIEM_KE_VAT_TU_CHI_TIET.KHO_VT = dbo.VI_TRI_KHO_VAT_TU.KHO_VT AND " +
                      " dbo.KIEM_KE_VAT_TU_CHI_TIET.DVT = dbo.VI_TRI_KHO_VAT_TU.DVT AND " +
                      " dbo.KIEM_KE_VAT_TU_CHI_TIET.MS_VI_TRI = dbo.VI_TRI_KHO_VAT_TU.MS_VI_TRI " +
                      " WHERE CONVERT(nvarchar(10),dbo.KIEM_KE_VAT_TU_CHI_TIET.NGAY,101) = " + 
                      " CONVERT(DATETIME,'" + ((DateTime)vKiemKe["NGAY"]).ToString("MM/dd/yyyy") + "',101) " + 
                      " AND dbo.KIEM_KE_VAT_TU_CHI_TIET.MS_KHO = '" + _Kho + "'";
                      
                DataTable vdtKiemKe = new DataTable();
                vdtKiemKe.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sqlKiemKe));

                foreach (DataRow vrow in vdtKiemKe.Rows)
                {

                    string sqlUdKK = "UPDATE dbo.KIEM_KE_VAT_TU_CHI_TIET SET  dbo.KIEM_KE_VAT_TU_CHI_TIET.SO_LUONG_CT = ROUND(" +
                        vrow["SO_LUONG"].ToString() + ",2) WHERE  MS_KHO = '" + _Kho + "' AND  CONVERT(nvarchar(10), NGAY,101) = CONVERT(DATETIME,'" + ((DateTime)vKiemKe["NGAY"]).ToString("MM/dd/yyyy") + "',101)  AND " +
                        " MS_VT  = '" + vrow["MS_VT"].ToString() + "' AND  MAU_VT = N'" + vrow["MAU_VT"].ToString() + "' AND " +
                        " KHO_VT  = N'" + vrow["KHO_VT"].ToString() + "' AND  DVT ='" + vrow["DVT"].ToString() + "' AND " +
                        " MS_VI_TRI = '" + vrow["MS_VI_TRI"].ToString() + "' AND MS_DHN = '" + vrow["MS_DHN"].ToString() + "'";
                    SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlUdKK);



                }

            }

            // kiem ke max den ngay hien tai

            DataView DvNhap1;
            DataView DvXuat1;

            if (sttKiemKe != 0)
            {
                //cap nhat phieu nhap
                DvNhap1 = new DataView(vData, "LOAI = 'N' AND NGAY > '" + NgayKKTruoc + "'", "NGAY", DataViewRowState.CurrentRows);
                DvXuat1 = new DataView(vData, "LOAI = 'X' AND NGAY > '" + NgayKKTruoc + "'", "NGAY", DataViewRowState.CurrentRows);
            }
            else
            {
                DvNhap1 = new DataView(vData, "LOAI = 'N' ", "NGAY", DataViewRowState.CurrentRows);
                DvXuat1 = new DataView(vData, "LOAI = 'X' ", "NGAY", DataViewRowState.CurrentRows);
       
            }
            //    NgayKKTruoc = (DateTime)vKiemKe["NGAY"];
            //    sttKiemKe++;
            //}
            //else
            //{
            //    DvNhap = new DataView(vData, "LOAI = 'N' AND NGAY < '" + vKiemKe["NGAY"] + "' AND NGAY > '" + NgayKKTruoc + "'", "NGAY", DataViewRowState.CurrentRows);
            //    DvXuat = new DataView(vData, "LOAI = 'X' AND NGAY < '" + vKiemKe["NGAY"] + "' AND NGAY > '" + NgayKKTruoc + "'", "NGAY", DataViewRowState.CurrentRows);
            //    NgayKKTruoc = (DateTime)vKiemKe["NGAY"];
            //}


            foreach (DataRow vrNhap in DvNhap1.ToTable().Rows)
            {
                //if (vrNhap["DON_HANG"].ToString().Equals("83"))
                //{
                //    string ds = "";
                //}


                string sqlChiTietDH = "SELECT  dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN, dbo.NHAP_NPL_CHI_TIET_IC.MS_VT, dbo.NHAP_NPL_CHI_TIET_IC.MAU_VT, " +
                  " dbo.NHAP_NPL_CHI_TIET_IC.KHO_VT, dbo.NHAP_NPL_CHI_TIET_IC.DVT, dbo.NHAP_NPL_VI_TRI_IC.MS_VI_TRI, " +
                  " dbo.NHAP_NPL_VI_TRI_IC.SO_LUONG, dbo.NHAP_NPL_CHI_TIET_IC.SLTN " +
                  " FROM  dbo.NHAP_NPL_CHI_TIET_IC INNER JOIN " +
                  " dbo.NHAP_NPL_VI_TRI_IC ON dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN = dbo.NHAP_NPL_VI_TRI_IC.MS_DHN AND " +
                  " dbo.NHAP_NPL_CHI_TIET_IC.MS_VT = dbo.NHAP_NPL_VI_TRI_IC.MS_VT AND " +
                  " dbo.NHAP_NPL_CHI_TIET_IC.MAU_VT = dbo.NHAP_NPL_VI_TRI_IC.MAU_VT AND " +
                  " dbo.NHAP_NPL_CHI_TIET_IC.KHO_VT = dbo.NHAP_NPL_VI_TRI_IC.KHO_VT AND " +
                  " dbo.NHAP_NPL_CHI_TIET_IC.DVT = dbo.NHAP_NPL_VI_TRI_IC.DVT " +
                  " WHERE (dbo.NHAP_NPL_CHI_TIET_IC.MS_DHN = '" + vrNhap["DON_HANG"].ToString() + "')";

                DataTable vDHInfo = new DataTable();
                vDHInfo.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sqlChiTietDH));

                DataTable vDHChiTiet = new DataTable();

                vDHChiTiet = vDHInfo.DefaultView.ToTable(true, "MS_DHN", "MS_VT", "MAU_VT", "KHO_VT", "DVT", "SLTN");

                foreach (DataRow vrowCT in vDHChiTiet.Rows)
                {
                    DataView dtChiTietVT = new DataView(vDHInfo, "MS_DHN = '" + vrowCT["MS_DHN"].ToString() +
                    "' AND MS_VT = '" + vrowCT["MS_VT"].ToString() + "' AND  MAU_VT = '" + vrowCT["MAU_VT"].ToString() +
                    "' AND KHO_VT = '" + vrowCT["KHO_VT"].ToString() + "' AND DVT = '" + vrowCT["DVT"].ToString() + "'", "MS_VI_TRI", DataViewRowState.CurrentRows);

                    int stt = 0;
                    float TongTrenVT = 0;
                    foreach (DataRow vrowVT in dtChiTietVT.ToTable().Rows)
                    {
                        TongTrenVT = TongTrenVT + float.Parse(vrowVT["SO_LUONG"].ToString());
                        stt++;
                        if (stt != dtChiTietVT.ToTable().Rows.Count)
                        {
                            // them vao vi tri kho vat tu ( vi tri n -1 )
                            string vIS_VitriKhoVT = "INSERT INTO dbo.VI_TRI_KHO_VAT_TU (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_KHO, MS_VI_TRI, SO_LUONG) " +
                              " VALUES ('" + vrowVT["MS_DHN"].ToString() + "','" + vrowVT["MS_VT"].ToString() + "','" + vrowVT["MAU_VT"].ToString() +
                              "','" + vrowVT["KHO_VT"].ToString() + "','" + vrowVT["DVT"].ToString() + "','" + _Kho + "','" + vrowVT["MS_VI_TRI"].ToString() + "','" + vrowVT["SO_LUONG"].ToString() + "')";
                            SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vIS_VitriKhoVT);
                        }
                    }

                    if (float.Parse(vrowCT["SLTN"].ToString()) != TongTrenVT)
                    {
                        float slMoi = float.Parse(dtChiTietVT.ToTable().Rows[stt - 1]["SO_LUONG"].ToString()) + (float.Parse(vrowCT["SLTN"].ToString()) - TongTrenVT);

                        string sqlCNVitri = "UPDATE dbo.NHAP_NPL_VI_TRI_IC SET  SO_LUONG = ROUND(" + slMoi + ",2) WHERE MS_DHN = '" + vrowCT["MS_DHN"].ToString() +
                             "' AND MS_VT = '" + vrowCT["MS_VT"].ToString() + "' AND  MAU_VT = N'" + vrowCT["MAU_VT"].ToString() +
                             "' AND KHO_VT = N'" + vrowCT["KHO_VT"].ToString() + "' AND DVT = '" + vrowCT["DVT"].ToString() + "' AND MS_VI_TRI = '" + dtChiTietVT.ToTable().Rows[stt - 1]["MS_VI_TRI"].ToString() + "'";
                        SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlCNVitri);

                        // them vao vi tri kho vat tu (vi tri cuoi)
                        string vIS_VitriKhoVT = "INSERT INTO dbo.VI_TRI_KHO_VAT_TU (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_KHO, MS_VI_TRI, SO_LUONG) " +
                              " VALUES ('" + vrowCT["MS_DHN"].ToString() + "',N'" + vrowCT["MS_VT"].ToString() + "',N'" + vrowCT["MAU_VT"].ToString() +
                              "',N'" + vrowCT["KHO_VT"].ToString() + "',N'" + vrowCT["DVT"].ToString() + "','" + _Kho + "','" + dtChiTietVT.ToTable().Rows[stt - 1]["MS_VI_TRI"].ToString() + "',ROUND(" + slMoi + ",2))";
                        SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vIS_VitriKhoVT);
                    }
                    else
                    {
                        // them vao vi tri kho vat tu (vi tri cuoi)
                        string vIS_VitriKhoVT = "INSERT INTO dbo.VI_TRI_KHO_VAT_TU (MS_DHN, MS_VT, MAU_VT, KHO_VT, DVT, MS_KHO, MS_VI_TRI, SO_LUONG) " +
                              " VALUES ('" + vrowCT["MS_DHN"].ToString() + "',N'" + vrowCT["MS_VT"].ToString() + "',N'" + vrowCT["MAU_VT"].ToString() +
                              "',N'" + vrowCT["KHO_VT"].ToString() + "',N'" + vrowCT["DVT"].ToString() + "',N'" + _Kho + "','" + dtChiTietVT.ToTable().Rows[stt - 1]["MS_VI_TRI"].ToString() + "', ROUND(" + dtChiTietVT.ToTable().Rows[stt - 1]["SO_LUONG"].ToString() + ",2))";
                        SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vIS_VitriKhoVT);
                    }
                }
            }

         
            //cap nhat phieu xuat
            foreach (DataRow vrXuat in DvXuat1.ToTable().Rows)
            {
                string sqlInfoPX = "SELECT MS_DHX , MS_VT, MAU_VT, KHO_VT, DVT, SO_LUONG " +
                " FROM dbo.XUAT_NPL_CHI_TIET_IC WHERE MS_DHX = '" + vrXuat["DON_HANG"].ToString() + "'";
                DataTable vDHInfo = new DataTable();
                vDHInfo.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sqlInfoPX));
                foreach (DataRow vrs in vDHInfo.Rows)
                {
                    string sqlPN = "SELECT dbo.VI_TRI_KHO_VAT_TU.SO_LUONG, dbo.VI_TRI_KHO_VAT_TU.MS_DHN, dbo.VI_TRI_KHO_VAT_TU.MS_VT, dbo.VI_TRI_KHO_VAT_TU.MAU_VT, " +
                                  " dbo.VI_TRI_KHO_VAT_TU.KHO_VT, dbo.VI_TRI_KHO_VAT_TU.DVT, dbo.VI_TRI_KHO_VAT_TU.MS_KHO, dbo.VI_TRI_KHO_VAT_TU.MS_VI_TRI, " +
                                  " CONVERT(DATETIME,CONVERT(NVARCHAR(10),dbo.NHAP_NPL_IC.NGAY_NHAP,101)+ ' ' + CONVERT(NVARCHAR(8),dbo.NHAP_NPL_IC.GIO_NHAP,108),101) as NGAY " +
                                   " , CONVERT(FLOAT,0.0) AS SL_MOI " +
                                  " FROM    dbo.VI_TRI_KHO_VAT_TU INNER JOIN " +
                                  " dbo.NHAP_NPL_IC ON dbo.VI_TRI_KHO_VAT_TU.MS_DHN = dbo.NHAP_NPL_IC.MS_DHN " +
                                  " WHERE dbo.VI_TRI_KHO_VAT_TU.MS_VT = '" + vrs["MS_VT"].ToString() + "' AND " +
                                  " dbo.VI_TRI_KHO_VAT_TU.MAU_VT = N'" + vrs["MAU_VT"].ToString() + "' AND dbo.VI_TRI_KHO_VAT_TU.KHO_VT = N'" + vrs["KHO_VT"].ToString() + "' AND " +
                                  " dbo.VI_TRI_KHO_VAT_TU.DVT = '" + vrs["DVT"].ToString() + "'";
                    DataTable vtbKho = new DataTable();
                    vtbKho.Load(SqlHelper.ExecuteReader(clsConnect.ConnectionString, CommandType.Text, sqlPN));
                    vtbKho.Columns["SL_MOI"].ReadOnly = false;

                    float slXuat = float.Parse(vrs["SO_LUONG"].ToString());
                    int j = 0;
                    foreach (DataRow vrKho in vtbKho.Rows)
                    {
                        if (slXuat > 0)
                        {
                            if (float.Parse(vrKho["SO_LUONG"].ToString()) < slXuat)
                            {
                                vtbKho.Rows[j]["SL_MOI"] = float.Parse(vrKho["SO_LUONG"].ToString());
                                slXuat = slXuat - float.Parse(vrKho["SO_LUONG"].ToString());

                            }
                            else
                            {
                                vtbKho.Rows[j]["SL_MOI"] = slXuat;
                                slXuat = 0;
                            }
                        }
                        else
                            break;
                        j++;
                    }

                    if (slXuat > 0)
                    {
                        string PXInfo = vrXuat["DON_HANG"].ToString() + "\t" + vrXuat["NGAY"].ToString() + "\t" + vrs["MS_VT"].ToString() + "\t\t" + vrs["MAU_VT"].ToString() + "\t\t" + vrs["KHO_VT"].ToString() + "\t\t" + vrs["DVT"].ToString() + "\t\t" + slXuat.ToString();
                        Writetextfile(PXInfo);
                    }

                    DataView DataNew = new DataView(vtbKho, "SL_MOI <> 0", "", DataViewRowState.CurrentRows);
                    foreach (DataRow vrow in DataNew.ToTable().Rows)
                    {
                        float vSL = float.Parse(vrow["SO_LUONG"].ToString()) - float.Parse(vrow["SL_MOI"].ToString());

                        
                        string vXVT = "INSERT INTO dbo.XUAT_NPL_VI_TRI_IC (MS_DHX, MS_VT, MAU_VT, KHO_VT, DVT, MS_VI_TRI, SL_VT, MS_DHN )" +
                            " VALUES ('" + vrXuat["DON_HANG"].ToString() + "','" + vrow["MS_VT"].ToString() + "', '" +
                             vrow["MAU_VT"].ToString() + "','" + vrow["KHO_VT"].ToString() + "','" +
                            vrow["DVT"].ToString() + "','" + vrow["MS_VI_TRI"].ToString() + "', ROUND(" + vrow["SL_MOI"].ToString() + ",2),'" + vrow["MS_DHN"].ToString() + "' )";
                        SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, vXVT);

                        if (vrow["MS_VT"].ToString() == "1880000496")
                        {
                            string aaa = "aaaa";
                        }
                        string sqlUD = "UPDATE dbo.VI_TRI_KHO_VAT_TU SET SO_LUONG = ROUND(" + vSL + ",2)" +
                            " WHERE   MS_DHN = '" + vrow["MS_DHN"].ToString() + "' AND MS_VT ='" + vrow["MS_VT"].ToString() + "' AND " +
                            " MAU_VT ='" + vrow["MAU_VT"].ToString() + "' AND KHO_VT ='" + vrow["KHO_VT"].ToString() + "' AND " +
                            " DVT ='" + vrow["DVT"].ToString() + "' AND MS_KHO ='" + vrow["MS_KHO"].ToString() + "' AND MS_VI_TRI ='" + vrow["MS_VI_TRI"].ToString() + "'";
                        SqlHelper.ExecuteNonQuery(clsConnect.ConnectionString, CommandType.Text, sqlUD);
                    }
                }
            }
            MessageBox.Show("Hoàn thành ");
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            lbaStatus.Text = DateTime.Now.Second.ToString();
        } // end TinhLaiDuLieu


        void Writetextfile(string txt)
        {
            
           // FileStr.WriteLine(txt);
          //  FileStr.Write(FileStr.NewLine);
            
        }
        void CloseFile()
        {
            try
            {
                FileStr.Close();
            }
            catch { }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseFile();
        }

    }
}