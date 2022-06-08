using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace ImportExcels
{
    public class MyUtil
    {
        SqlConnection con;
        public bool finish = false;
        public MyUtil()
        {
            con = new SqlConnection(Utility.MyConnection);
        }
        //Kiem tra MSNX
        public bool IsExist(string workId)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from nha_xuong where MS_N_XUONG=@workId";
            cmd.Parameters.Add("@workId", SqlDbType.NVarChar).Value = workId;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    dr.Close();
                    con.Close();
                    return true;
                }
                catch
                {
                    dr.Close();
                    con.Close();
                    return false;
                }
            }
            dr.Close();
            con.Close();
            return false;
        }
        public bool IsExistDV(string workId)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM  DON_VI WHERE TEN_DON_VI = N'" + workId + "'";
            cmd.Parameters.Add("@workId", SqlDbType.NVarChar).Value = workId;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    dr.Close();
                    con.Close();
                    return true;
                }
                catch
                {
                    dr.Close();
                    con.Close();
                    return false;
                }
            }
            dr.Close();
            con.Close();
            return false;
        }        
        //Kiem tra Tinh
        public string IsExistTinh(string workId)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM  IC_QUOC_GIA WHERE TEN_QG = N'" + workId + "'";
            //cmd.Parameters.Add("@workId", SqlDbType.NVarChar).Value = workId;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                try
                {
                    string DuLieu = dr["MA_QG"].ToString();                    
                    dr.Close();
                    con.Close();
                    return DuLieu;
                }
                catch
                {
                    dr.Close();
                    con.Close();
                    return "";
                }
            }
            dr.Close();
            con.Close();
            return "";
        }
        //Kiem tra Quan
        public string IsExistQuan(string Tinh, string Quan )
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "SELECT ms_cha FROM  IC_QUOC_GIA WHERE TEN_QG=@workId";
                cmd.CommandText = "SELECT MA_QG FROM  IC_QUOC_GIA WHERE TEN_QG = N'" + Quan + "' AND MS_CHA = '" + Tinh + "' ";
                //cmd.Parameters.Add("@workId", SqlDbType.NVarChar).Value =  Quan;
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                    try
                    {
                        string DuLieu = dr["MA_QG"].ToString();
                        dr.Close();
                        con.Close();
                        return DuLieu ;
                    }
                    catch
                    {
                        dr.Close();
                        con.Close();
                        return "";
                    }
                }
                dr.Close();
                con.Close();
                return "";                
                
               
            }
            catch
            {
                con.Close();
                return "";
            }
        }
        //Kiem tra Duong
        public bool IsExistDuong(string Duong, string Quan)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "SELECT ms_cha FROM  IC_QUOC_GIA WHERE TEN_QG=@workId";
                cmd.CommandText = "SELECT * FROM [DUONG_QG] WHERE MS_DUONG IN (SELECT MS FROM IC_DUONG" +  
                                    " WHERE TEN_V = N'" +  Duong + "' ) AND MS_QG = '" + Quan + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    try
                    {
                        dr.Close();
                        con.Close();
                        return true;
                    }
                    catch
                    {
                        dr.Close();
                        con.Close();
                        return false;
                    }
                }
                dr.Close();
                con.Close();
                return false;


            }
            catch
            {
                con.Close();
                return false;
            }
        }

        #region TRAITV
        public DataTable GetList_Trai(string tableName, string cond)
        {

            string cmdText = "select * from " + tableName + " where " + cond;
            SqlCommand command = new SqlCommand(cmdText, con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds, "ds1");

            return ds.Tables["ds1"];
        }
        #endregion

        public DataTable GetList(string tableName)
        {

            string cmdText = "select * from " + tableName;
            SqlCommand command = new SqlCommand(cmdText, con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds, "ds1");

            return ds.Tables["ds1"];
        }
        //Kiem tra ma so thiet bi
        public bool IsExistMsThietBi(string MaSo)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM MAY WHERE MS_MAY = @Id";
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = MaSo;
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    try
                    {
                        dr.Close();
                        con.Close();
                        return true;
                    }
                    catch
                    {
                        dr.Close();
                        con.Close();
                        return false;
                    }
                }
                dr.Close();
                con.Close();
                return false;


            }
            catch
            {
                con.Close();
                return false;
            }
        }
        //Kiem tra NGAY MAX 
        public bool IsExistNgayMax(string MaSo,ref DateTime NgayDC )
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT MAX(NGAY_NHAP) AS NGAY FROM MAY_NHA_XUONG WHERE MS_MAY = @Id";
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = MaSo;
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                    try
                    {
                        DateTime NgayMax = (DateTime)dr["NGAY"];
                        dr.Close();
                        con.Close();
                        if (NgayDC > NgayMax) {NgayDC = NgayMax; return true;}
                        else { NgayDC = NgayMax; return false; }
                    }
                    catch
                    {
                        dr.Close();
                        con.Close();
                        NgayDC = Convert.ToDateTime("01/01/1900");
                        return true;
                    }
                }
                dr.Close();
                con.Close();
                NgayDC = Convert.ToDateTime("01/01/1900");
                return true;
            }
            catch
            {
                con.Close();
                NgayDC = Convert.ToDateTime("01/01/1900");
                return true;
            }
        }
        //Kiem tra ma so nha xuong khac ms nha xuong ngay max
        public bool IsExistMsNhaXuongKhacMSNgayMax(string MaSoMay,string msnx )
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM MAY_NHA_XUONG_NGAY_MAX WHERE MS_MAY = @Id " + 
                                        " AND MS_N_XUONG = @MSNX";

                cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = MaSoMay;
                cmd.Parameters.Add("@MSNX", SqlDbType.NVarChar).Value = msnx;
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    con.Close();
                    return false;
                }
                dr.Close();
                con.Close();
                return true;

            }
            catch
            {
                con.Close();
                return true;
            }
        }
        //Kiem tra ma so nha xuong
        public bool IsExistMsNhaXuong(string msnx)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM NHA_XUONG WHERE MS_N_XUONG = @Id ";
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = msnx;
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    con.Close();
                    return true;
                }
                dr.Close();
                con.Close();
                return false;

            }
            catch
            {
                con.Close();
                return false;
            }
        }
        // Kiem tra loai Cong viec
        public short CategoryID(string workCategory)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Loai_cong_viec where ten_loai_cv=@name";
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = workCategory;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    dr.Read();
                    short catID = Convert.ToInt16(dr[0].ToString());
                    con.Close();
                    return catID;
                }
                catch
                {
                    return 0;
                }
            }
            con.Close();
            return 0;
        }
        // Kiem tra loai may
        public string GetMachineID(string name)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from loai_may where ten_loai_may=@name";
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    dr.Read();
                    string machineId = dr[0].ToString();
                    con.Close();
                    return machineId;
                }
                catch
                {
                    return "";
                }
            }
            con.Close();
            return "";
        }
        // Kiem tra & Get nhom may
        public string IsNhomMay(string name)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NHOM_MAY where TEN_NHOM_MAY=@name";
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                try
                {
                    dr.Read();
                    string machineId = dr[0].ToString();
                    con.Close();
                    return machineId;
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                string sSql = " SELECT * FROM dbo.NHOM_MAY WHERE MS_NHOM_MAY = '"  + name + "' ";
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                if (dtTmp.Rows.Count > 0)
                {
                    try {
                        return dtTmp.Rows[0][0].ToString();
                    }catch {}
                }

            }
            con.Close();
            return "";
        }
        // Kiem tra ngoai te
        public string GetExchangeID(string name)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from ngoai_te where ngoai_te=@name";
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    dr.Read();
                    string ExchangeID = dr[0].ToString();
                    con.Close();
                    return ExchangeID;
                }
                catch
                {
                    return "";
                }
            }
            con.Close();
            return "";
        }
        // Kiem tra chuyen mon
        public int GetMajorID(string name)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from chuyen_mon where ten_chuyen_mon=@name";
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    dr.Read();
                    int majorId = Convert.ToInt32(dr[0].ToString());
                    con.Close();
                    return majorId;
                }
                catch
                {
                    return 0;
                }
            }
            con.Close();
            return 0;
        }
        // Kiem tra bac tho
        public int GetPositionID(string name)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from bac_tho where ten_bac_tho=@name";
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    dr.Read();
                    int levelId = Convert.ToInt32(dr[0].ToString());
                    con.Close();
                    return levelId;
                }
                catch
                {
                    return 0;
                }
            }
            con.Close();
            return 0;
        }
        // Kiem tra cong viec
        public bool IsExistCViec(string workId)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from cong_viec where MS_CV=@workId";
            cmd.Parameters.Add("@workId", SqlDbType.NVarChar).Value = workId;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    con.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            con.Close();
            return false;
        }

        //Cap nhap CVBao tri


        public bool InsertWork(string MaCv, string kyhieucv, int ms_loai_cv, string motacv, string motacveng, string path, string ms_loai_may,
                        long thoi_gian_du_kien, string thaotac, string tieuchuan, string ghichu, int ms_chuyen_mon,
                        int ms_bac_tho, bool antoan, float dinh_muc, string ngoai_te, int item, int count,
                        System.Data.SqlClient.SqlConnection oCon, out string sMaLoi, int iSoNguoi, string sYCNS, string sYCDC)
        {
            sMaLoi = "";
            try
            {
                int iMsCv = 0;
                Commons.OSystems obj = new Commons.OSystems();
                try
                {
                    iMsCv = int.Parse(obj.GetIDInteger("CV").ToString());
                }
                catch { iMsCv = 1; }

                SqlCommand command = new SqlCommand("Add_Work", oCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MS_LOAI_CV", SqlDbType.SmallInt).Value = ms_loai_cv;
                command.Parameters.Add("@MO_TA_CV", SqlDbType.NVarChar).Value = motacv;
                command.Parameters.Add("@PATH_HD", SqlDbType.NVarChar).Value = path;
                command.Parameters.Add("@MS_LOAI_MAY", SqlDbType.NVarChar).Value = ms_loai_may;
                command.Parameters.Add("@THOI_GIAN_DU_KIEN", SqlDbType.Real).Value = thoi_gian_du_kien;
                command.Parameters.Add("@THAO_TAC", SqlDbType.NVarChar).Value = thaotac;
                command.Parameters.Add("@TIEU_CHUAN_KT", SqlDbType.NVarChar).Value = tieuchuan;
                command.Parameters.Add("@MS_CHUYEN_MON", SqlDbType.Int).Value = ms_chuyen_mon;
                command.Parameters.Add("@MS_BAC_THO", SqlDbType.Int).Value = ms_bac_tho;
                command.Parameters.Add("@MA_CV", SqlDbType.NVarChar).Value = (MaCv == "" ? "NULL" : MaCv);
                command.Parameters.Add("@KY_HIEU_CV", SqlDbType.NVarChar).Value = kyhieucv;
                command.Parameters.Add("@AN_TOAN", SqlDbType.Bit).Value = antoan;
                command.Parameters.Add("@DINH_MUC", SqlDbType.Float).Value = dinh_muc;
                command.Parameters.Add("@NGOAI_TE", SqlDbType.NVarChar).Value = ngoai_te;
                command.Parameters.Add("@GHI_CHU", SqlDbType.NVarChar).Value = ghichu;
                command.Parameters.Add("@MS_CV", SqlDbType.NVarChar).Value = iMsCv;
                command.Parameters.Add("@SO_NGUOI", SqlDbType.Int).Value = iSoNguoi;
                command.Parameters.Add("@YEU_CAU_NS", SqlDbType.NVarChar).Value = sYCNS;
                command.Parameters.Add("@YEU_CAU_DUNG_CU", SqlDbType.NVarChar).Value = sYCDC;

                command.ExecuteNonQuery();

                command = new SqlCommand();
                command.Connection = oCon;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE CONG_VIEC SET MO_TA_CV_ANH = N'" + motacveng + "', MO_TA_CV_HOA = N'" + motacveng + "' WHERE MS_CV = " + iMsCv;
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                sMaLoi = ex.Message;
                return false;
            }
        }




        // Get bo_phan_gstt
        public int GetDepartmentID(string name)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string sql = "select * from bo_phan_gstt";
            sql += " where ten_bp_gstt_tv=@name or ten_bp_gstt_ta=@name ";
            sql += "or ten_bp_gstt_th=@name";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    dr.Read();
                    int levelId = Convert.ToInt32(dr[0].ToString());
                    con.Close();
                    return levelId;
                }
                catch
                {
                    return 0;
                }
            }
            con.Close();
            return 0;
        }
        //Kiem tra thong_so_gstt
        public bool IsExistSupervise(string ma_ts_gstt)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from thong_so_gstt where ms_ts_gstt=@ma_ts_gstt";
            cmd.Parameters.Add("@ma_ts_gstt", SqlDbType.NVarChar).Value = ma_ts_gstt;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {
                    con.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            con.Close();
            return false;
        }

        //Kiem tra Ten Thong So va Bo fan
        public bool IsThongSoBoPhan(string TenThongSo, int MsBPhan)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM THONG_SO_GSTT WHERE TEN_TS_GSTT = @TenThongSo AND MS_BP_GSTT = @MsBPhan";
            cmd.Parameters.Add("@TenThongSo", SqlDbType.NVarChar).Value = TenThongSo;
            cmd.Parameters.Add("@MsBPhan", SqlDbType.Int).Value = MsBPhan;

            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                try
                {
                    con.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            con.Close();
            return false;
        }


        // Cap nhap Thong So GSTT Dinh Tinh
        public bool AddThongSoGSTT(string ms_ts_gstt, string ten_ts_gstt, bool loai_ts, string ghichu, int ms_bp_gs_tt,
                                System.Data.SqlClient.SqlConnection oCon,int IDVDo, out string sMaLoi)
        {
            sMaLoi = "";
            try
            {
                SqlCommand command = new SqlCommand("[Add_Status_Supervise]", oCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MS_TS_GSTT", SqlDbType.NVarChar).Value = ms_ts_gstt;
                command.Parameters.Add("@TEN_TS_GSTT", SqlDbType.NVarChar).Value = ten_ts_gstt;
                command.Parameters.Add("@LOAI_TS", SqlDbType.Bit).Value = loai_ts;
                command.Parameters.Add("@GHI_CHU", SqlDbType.NVarChar).Value = ghichu;
                command.Parameters.Add("@MS_BP_GSTT", SqlDbType.Int).Value = ms_bp_gs_tt;
                if (!loai_ts)
                    command.Parameters.Add("@DVDO", SqlDbType.Int).Value = IDVDo;
                else
                    command.Parameters.Add("@DVDO", SqlDbType.Int).Value = DBNull.Value;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sMaLoi = ex.Message;
                return false;
            }
            return true;
        }
        // Cap Nhap Gia Tri Thong So GSTT
        public bool AddGiaTriTSGSTT(string ms_ts_gstt, string tengt, bool dat, string ghichu, System.Data.SqlClient.SqlConnection oCon, out string sMaLoi )
        {
            sMaLoi = "";
            try
            {
                SqlCommand command;
                command = new SqlCommand("AddGIA_TRI_TS_GSTT", oCon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MS_TS_GSTT", SqlDbType.NVarChar).Value = ms_ts_gstt;
                command.Parameters.Add("@TEN_GIA_TRI", SqlDbType.NVarChar).Value = tengt.Replace("(X)", "").Trim();

                if (tengt.ToUpper().IndexOf("(X)") >= 0)                
                    command.Parameters.Add("@DAT", SqlDbType.Bit).Value = 1;
                else
                    command.Parameters.Add("@DAT", SqlDbType.Bit).Value = 0;

                command.Parameters.Add("@GHI_CHU", SqlDbType.NVarChar).Value = ghichu;
                
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sMaLoi = ex.Message;
                return false;
            }
            return true;
        }

        // Kiem tra va get gia tri co ton tai
        public string KiemGetTonTai(string sTableKT, string sCotKT, string sGTKtra)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "SELECT TOP 1 * FROM " +  sTableKT + " A WHERE RTRIM(" +  sCotKT + ") = @name";
            //cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = sGTKtra.Trim();
            //cmd.CommandType = CommandType.Text;
            //SqlDataReader dr = cmd.ExecuteReader();
            string sSql = "";
            DataTable dtTmp = new DataTable();
            sSql = "SELECT TOP 1 * FROM " + sTableKT + " A WHERE LTRIM(RTRIM(" + sCotKT + ")) = N'" + sGTKtra + "' ";
            dtTmp.Load(SqlHelper.ExecuteReader (Commons.IConnections.ConnectionString, CommandType.Text, sSql));
            if (dtTmp.Rows.Count > 0)
            {
                try
                {

                    string sGiaTri = dtTmp.Rows[0][sCotKT].ToString();
                    con.Close();
                    return sGiaTri;
                }
                catch
                {
                    return "";
                }
            }
            //con.Close();
            return "";
        }

        public string GetGiaTri(string sChuoi,string sCotLay)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sChuoi;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                try
                {
                    dr.Read();
                    string sGiaTri = dr[sCotLay].ToString();
                    con.Close();
                    return sGiaTri;
                }
                catch
                {
                    return "";
                }
            }
            con.Close();
            return "";
        }

        
    }
}
