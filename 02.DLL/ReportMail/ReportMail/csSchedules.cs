using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;


namespace ReportMail
{
    public class csSchedules
    {
        #region Khai Bao Bien

        public int _Test { get; set; }


        private int ID_SCHEDULES;
        public int _ID_SCHEDULES
        {
            get { return ID_SCHEDULES; }
            set { ID_SCHEDULES = value; }

        }

        private int LOAI_SCHEDULES;
        public int _LOAI_SCHEDULES
        {
            get { return LOAI_SCHEDULES; }
            set { LOAI_SCHEDULES = value; }

        }

        private int GOI_MOI;
        public int _GOI_MOI
        {
            get { return GOI_MOI; }
            set { GOI_MOI = value; }

        }

        private int VAO_NGAY_THANG;
        public int _VAO_NGAY_THANG
        {
            get { return VAO_NGAY_THANG; }
            set { VAO_NGAY_THANG = value; }

        }

        private string THU_TUAN;
        public string _THU_TUAN
        {
            get { return THU_TUAN; }
            set { THU_TUAN = value; }

        }

        private int LOAI_THANG;
        public int _LOAI_THANG
        {
            get { return LOAI_THANG; }
            set { LOAI_THANG = value; }

        }

        private int LOAI_TUAN_THANG;
        public int _LOAI_TUAN_THANG
        {
            get { return LOAI_TUAN_THANG; }
            set { LOAI_TUAN_THANG = value; }

        }

        private int THU_TUAN_THANG;
        public int _THU_TUAN_THANG
        {
            get { return THU_TUAN_THANG; }
            set { THU_TUAN_THANG = value; }

        }

        private int SO_THANG_THANG;
        public int _SO_THANG_THANG
        {
            get { return SO_THANG_THANG; }
            set { SO_THANG_THANG = value; }

        }

        private int KIEU_GOI;
        public int _KIEU_GOI
        {
            get { return KIEU_GOI; }
            set { KIEU_GOI = value; }

        }

        private DateTime GIO_GOI;
        public DateTime _GIO_GOI
        {
            get { return GIO_GOI; }
            set { GIO_GOI = value; }

        }

        private int SO_GIO_GOI;
        public int _SO_GIO_GOI
        {
            get { return SO_GIO_GOI; }
            set { SO_GIO_GOI = value; }

        }

        private int LOAI_TIME;
        public int _LOAI_TIME
        {
            get { return LOAI_TIME; }
            set { LOAI_TIME = value; }

        }

        private DateTime TG_BD;
        public DateTime _TG_BD
        {
            get { return TG_BD; }
            set { TG_BD = value; }

        }

        private DateTime TG_KT;
        public DateTime _TG_KT
        {
            get { return TG_KT; }
            set { TG_KT = value; }

        }

        private int LOAI_HIEU_LUC;
        public int _LOAI_HIEU_LUC
        {
            get { return LOAI_HIEU_LUC; }
            set { LOAI_HIEU_LUC = value; }

        }

        private DateTime TG_BD_HL;
        public DateTime _TG_BD_HL
        {
            get { return TG_BD_HL; }
            set { TG_BD_HL = value; }

        }

        private DateTime TG_KT_HL;
        public DateTime _TG_KT_HL
        {
            get { return TG_KT_HL; }
            set { TG_KT_HL = value; }

        }

        private Boolean THU_2;
        public Boolean _THU_2
        {
            get { return THU_2; }
            set { THU_2 = value; }

        }

        private Boolean THU_3;
        public Boolean _THU_3
        {
            get { return THU_3; }
            set { THU_3 = value; }

        }

        private Boolean THU_4;
        public Boolean _THU_4
        {
            get { return THU_4; }
            set { THU_4 = value; }

        }

        private Boolean THU_5;
        public Boolean _THU_5
        {
            get { return THU_5; }
            set { THU_5 = value; }

        }

        private Boolean THU_6;
        public Boolean _THU_6
        {
            get { return THU_6; }
            set { THU_6 = value; }

        }

        private Boolean THU_7;
        public Boolean _THU_7
        {
            get { return THU_7; }
            set { THU_7 = value; }

        }

        private Boolean THU_CN;
        public Boolean _THU_CN
        {
            get { return THU_CN; }
            set { THU_CN = value; }

        }

        private string TEN_SCHEDULES;
        public string _TEN_SCHEDULES
        {
            get { return TEN_SCHEDULES; }
            set { TEN_SCHEDULES = value; }

        }


        string Gio = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "Gio", Commons.Modules.TypeLanguage);

        string Phut = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "Phut", Commons.Modules.TypeLanguage);
        string Giay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "Giay", Commons.Modules.TypeLanguage);

        string TuanThu1 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "TuanThu1", Commons.Modules.TypeLanguage);
        string TuanThu2 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "TuanThu2", Commons.Modules.TypeLanguage);
        string TuanThu3 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "TuanThu3", Commons.Modules.TypeLanguage);
        string TuanThu4 = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "TuanThu4", Commons.Modules.TypeLanguage);

        string ThuHai = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "ThuHai", Commons.Modules.TypeLanguage);
        string ThuBa = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "ThuBa", Commons.Modules.TypeLanguage);
        string ThuTu = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "ThuTu", Commons.Modules.TypeLanguage);
        string ThuNam = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "ThuNam", Commons.Modules.TypeLanguage);
        string ThuSau = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "ThuSau", Commons.Modules.TypeLanguage);
        string ThuBay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "ThuBay", Commons.Modules.TypeLanguage);
        string ChuNhat = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "ChuNhat", Commons.Modules.TypeLanguage);

        string GoiMoi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "Goivaomoi", Commons.Modules.TypeLanguage);
        string Ngay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "ngay", Commons.Modules.TypeLanguage);
        string Tuan = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "tuan", Commons.Modules.TypeLanguage);
        string Thang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "thang", Commons.Modules.TypeLanguage);
        string VaoLuc = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "vaoluc", Commons.Modules.TypeLanguage);
        string VaoNgay = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "VaoNgay", Commons.Modules.TypeLanguage);

        string Moi = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "moi", Commons.Modules.TypeLanguage);
        string TrongKhoang = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "trongkhoang", Commons.Modules.TypeLanguage);

        string Den = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "den", Commons.Modules.TypeLanguage);

        string BatDau = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                "frmSchedules", "BatDau", Commons.Modules.TypeLanguage);


        #endregion

        public void setNull()
        {
            TEN_SCHEDULES = Convert.ToString(null);
            ID_SCHEDULES = Convert.ToInt16(null); 
            LOAI_SCHEDULES = Convert.ToInt16(null);
            GOI_MOI = Convert.ToInt16(null);
            VAO_NGAY_THANG = Convert.ToInt16(null);
            THU_TUAN = Convert.ToString(null);
            LOAI_THANG = Convert.ToInt16(null);
            LOAI_TUAN_THANG = Convert.ToInt16(null);
            THU_TUAN_THANG = Convert.ToInt16(null);
            SO_THANG_THANG = Convert.ToInt16(null);
            KIEU_GOI = Convert.ToInt16(null);
            GIO_GOI = Convert.ToDateTime(null);
            SO_GIO_GOI = Convert.ToInt16(null);
            LOAI_TIME = Convert.ToInt16(null);
            TG_BD = Convert.ToDateTime(null);
            TG_KT = Convert.ToDateTime(null);
            LOAI_HIEU_LUC = Convert.ToInt16(null);
            TG_BD_HL = Convert.ToDateTime(null);
            TG_KT_HL = Convert.ToDateTime(null);
            THU_2 = false;
            THU_3 = false;
            THU_4 = false;
            THU_5 = false;
            THU_6 = false;
            THU_7 = false;
            THU_CN = false;

        }

        public Boolean CapNhapSchedules(string TenIDMail, ReportMail.Mail.ucSentTo ucSentTo1, string DK_BAOCAO, ref int ID)
        {
            #region Begin cap nhap CSDL
            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            SqlTransaction tran;
            if (con.State == ConnectionState.Closed)
                con.Open();
            tran = con.BeginTransaction();
            try
            {
                // Neu ID = -1 la them moi nguoi lai la sua 
                if (ID_SCHEDULES != 0)
                {
                    ID_SCHEDULES = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, "MAddMailSchedules",
                        ID_SCHEDULES, LOAI_SCHEDULES,
                        GOI_MOI, VAO_NGAY_THANG, THU_TUAN, LOAI_THANG,
                        LOAI_TUAN_THANG, THU_TUAN_THANG, SO_THANG_THANG, KIEU_GOI,
                        GIO_GOI.ToString("dd/MM/yyyy HH:mm:ss") == "01/01/0001 00:00:00" ? null : GIO_GOI.ToString(),
                        SO_GIO_GOI, LOAI_TIME,
                        TG_BD.ToString("dd/MM/yyyy HH:mm:ss") == "01/01/0001 00:00:00" ? null : TG_BD.ToString(),
                        TG_KT.ToString("dd/MM/yyyy HH:mm:ss") == "01/01/0001 00:00:00" ? null : TG_KT.ToString(), LOAI_HIEU_LUC,
                        TG_BD_HL.ToString("dd/MM/yyyy HH:mm:ss") == "01/01/0001 00:00:00" ? null : TG_BD_HL.ToString(),
                        TG_KT_HL.ToString("dd/MM/yyyy HH:mm:ss") == "01/01/0001 00:00:00" ? null : TG_KT_HL.ToString(),
                        THU_2, THU_3, THU_4, THU_5, THU_6, THU_7, THU_CN, TEN_SCHEDULES));
                }

                if (ID_SCHEDULES.ToString() == "-1")
                    ID = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, "MAddDSMail", ID,
                    ID_SCHEDULES.ToString() == "-1" ? null : ID_SCHEDULES.ToString(), TenIDMail,
                    ucSentTo1.sName, ucSentTo1.dNgayTao, ucSentTo1.cHieuLuc, ucSentTo1.sUserName,
                    ucSentTo1.sNgonNgu, ucSentTo1.sMailTo, ucSentTo1.sMailCC, DK_BAOCAO, ucSentTo1.sSubject, ucSentTo1.sMailBCC,
                    ucSentTo1.sNDung));
                else
                    if (ID_SCHEDULES.ToString() == "0")
                        ID = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, "MAddDSMail", ID,
                        ID_SCHEDULES.ToString() == "0" ? null : ID_SCHEDULES.ToString(), TenIDMail,
                        ucSentTo1.sName, ucSentTo1.dNgayTao, ucSentTo1.cHieuLuc, ucSentTo1.sUserName,
                        ucSentTo1.sNgonNgu, ucSentTo1.sMailTo, ucSentTo1.sMailCC, DK_BAOCAO, ucSentTo1.sSubject,
                        ucSentTo1.sMailBCC, ucSentTo1.sNDung));
                    else
                        ID = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, "MAddDSMail", ID,
                        ID_SCHEDULES.ToString() == "-1" ? null : ID_SCHEDULES.ToString(), TenIDMail,
                        ucSentTo1.sName, ucSentTo1.dNgayTao, ucSentTo1.cHieuLuc, ucSentTo1.sUserName,
                        ucSentTo1.sNgonNgu, ucSentTo1.sMailTo, ucSentTo1.sMailCC, DK_BAOCAO, ucSentTo1.sSubject,
                        ucSentTo1.sMailBCC, ucSentTo1.sNDung));
                tran.Commit();
                con.Close();
                return true;
            }
            catch
            {
                tran.Rollback();
                con.Close();
                ID = -1;
                return false;
            }


            #endregion
        }

        public Boolean XoaSchedules(int ID, int ID_SCHEDULES, string TenIDMail)
        {
            #region Begin xoa CSDL
            SqlConnection con = new SqlConnection(Commons.IConnections.ConnectionString);
            SqlTransaction tran;
            if (con.State == ConnectionState.Closed)
                con.Open();
            tran = con.BeginTransaction();
            try
            {
                SqlHelper.ExecuteNonQuery(tran, "MDeleteSche", ID, ID_SCHEDULES, TenIDMail);
                tran.Commit();
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                ID = -1;
                return false;
            }


            #endregion
        }

        public string DocDuLieu()
        {
            try
            {
                if (LOAI_SCHEDULES == 0) return "";

                string sTmp;
                string sTmp1;
                string sTmp2;
                sTmp1 = "";
                sTmp2 = "";
                sTmp = "";


                string sData = "";
                if (LOAI_TIME == 1) sData = Gio;
                if (LOAI_TIME == 2) sData = Phut;
                if (LOAI_TIME == 3) sData = Giay;
                if (KIEU_GOI == 1)
                    sTmp1 = VaoLuc.ToLower() + " " + GIO_GOI.ToString("HH:mm:ss");
                else
                    if (SO_GIO_GOI == 1)
                        sTmp1 = Moi.ToLower() + " " + sData.ToLower() + " " + TrongKhoang + " " + TG_BD.ToString("HH:mm:ss") + " " + Den + " " + TG_KT.ToString("HH:mm:ss");
                    else
                        sTmp1 = Moi.ToLower() + " " + SO_GIO_GOI.ToString().ToLower() + " " +
                        sData.ToLower() + " " + TrongKhoang + " " + TG_BD.ToString("HH:mm:ss") + " " + Den + " " + TG_KT.ToString("HH:mm:ss");



                if (LOAI_SCHEDULES == 1)
                {
                    if (GOI_MOI == 1)
                        sTmp = GoiMoi + " " + Ngay.ToLower() + " " + sTmp1;
                    else
                        sTmp = GoiMoi + " " + GOI_MOI.ToString() + " " + Ngay.ToLower() + " " + sTmp1;
                }
                if (LOAI_SCHEDULES == 2)
                {
                    if (!THU_2 && !THU_3 && !THU_4 && !THU_5 && !THU_6 && !THU_7 && !THU_CN)
                        if (GOI_MOI == 1)
                            sTmp = GoiMoi + " " + Tuan.ToLower() + " ";
                        else
                            sTmp = GoiMoi + " " + GOI_MOI.ToString() + " " + Tuan.ToLower() + " ";
                    else
                        if (GOI_MOI == 1)
                            sTmp = GoiMoi + " " + Tuan.ToLower() + " " + VaoNgay.ToLower() + " ";
                        else
                            sTmp = GoiMoi + " " + GOI_MOI.ToString() + " " + Tuan.ToLower() + " " + VaoNgay.ToLower() + " ";


                    sTmp2 = ", ";
                    if (THU_2) sTmp2 = sTmp2 + ThuHai + ", ";
                    if (THU_3) sTmp2 = sTmp2 + ThuBa + ", ";
                    if (THU_4) sTmp2 = sTmp2 + ThuTu + ", ";
                    if (THU_5) sTmp2 = sTmp2 + ThuNam + ", ";
                    if (THU_6) sTmp2 = sTmp2 + ThuSau + ", ";
                    if (THU_7) sTmp2 = sTmp2 + ThuBay + ", ";
                    if (THU_CN) sTmp2 = sTmp2 + ChuNhat + ", ";
                    if (sTmp2.Length <= 2) sTmp2 = ""; else sTmp2 = sTmp2.Substring(2, sTmp2.Length - 4);
                    sTmp = sTmp + sTmp2 + " " + sTmp1;
                }

                if (LOAI_SCHEDULES == 3)
                {
                    if (LOAI_THANG == 1)
                    {
                        if (GOI_MOI == 1)
                            sTmp = GoiMoi + " " + Thang.ToLower() + " " + VaoNgay.ToLower() + " " + VAO_NGAY_THANG.ToString();
                        else
                            sTmp = GoiMoi + " " + GOI_MOI.ToString() + " " + Thang.ToLower() + " " + VaoNgay.ToLower() + " " + VAO_NGAY_THANG.ToString();
                    }
                    else
                    {
                        sData = "";
                        if (LOAI_TUAN_THANG == 1) sData = TuanThu1;
                        if (LOAI_TUAN_THANG == 2) sData = TuanThu2;
                        if (LOAI_TUAN_THANG == 3) sData = TuanThu3;
                        if (LOAI_TUAN_THANG == 4) sData = TuanThu4;
                        string sThu = "";
                        if (THU_TUAN_THANG == 1) sThu = ThuHai;
                        if (THU_TUAN_THANG == 2) sThu = ThuBa;
                        if (THU_TUAN_THANG == 3) sThu = ThuTu;
                        if (THU_TUAN_THANG == 4) sThu = ThuNam;
                        if (THU_TUAN_THANG == 5) sThu = ThuSau;
                        if (THU_TUAN_THANG == 6) sThu = ThuBay;
                        if (THU_TUAN_THANG == 7) sThu = ChuNhat;

                        if (SO_THANG_THANG == 1)
                            sTmp = GoiMoi + " " + sData.ToLower() + " " + VaoNgay.ToLower() + " " + sThu.ToLower() + " " + Moi.ToLower() + " " + Thang.ToLower();
                        else
                            sTmp = GoiMoi + " " + sData.ToLower() + " " + VaoNgay.ToLower() + " " + sThu.ToLower() + " " + Moi.ToLower() + " " + SO_THANG_THANG.ToString() + " " + Thang.ToLower();
                    }
                    sTmp = sTmp + " " + sTmp1;
                }

                if (LOAI_HIEU_LUC == 1)
                    sTmp = sTmp + ". " + BatDau + " " + TrongKhoang.ToLower() + " " + TG_BD_HL.ToString("dd/MM/yyyy") + " " + Den.ToLower() + " " + TG_KT_HL.ToString("dd/MM/yyyy");
                else
                    sTmp = sTmp + ". " + BatDau + " " + VaoNgay.ToLower() + " " + TG_BD_HL.ToString("dd/MM/yyyy");

                return sTmp;

            }
            catch { return ""; }
        }

        public void GetGTClass(int IDSchedules)
        {
            setNull();
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetmailSchedules", IDSchedules));

            if (dtTmp.Rows.Count <= 0) return;
            ID_SCHEDULES = Convert.ToInt16(dtTmp.Rows[0]["ID_SCHEDULES"].ToString());
            LOAI_SCHEDULES = Convert.ToInt16(dtTmp.Rows[0]["LOAI_SCHEDULES"].ToString());
            GOI_MOI = Convert.ToInt16(dtTmp.Rows[0]["GOI_MOI"].ToString());
            VAO_NGAY_THANG = Convert.ToInt16(dtTmp.Rows[0]["VAO_NGAY_THANG"].ToString());
            THU_TUAN = Convert.ToString(dtTmp.Rows[0]["THU_TUAN"].ToString());
            LOAI_THANG = Convert.ToInt16(dtTmp.Rows[0]["LOAI_THANG"].ToString());
            LOAI_TUAN_THANG = Convert.ToInt16(dtTmp.Rows[0]["LOAI_TUAN_THANG"].ToString());
            THU_TUAN_THANG = Convert.ToInt16(dtTmp.Rows[0]["THU_TUAN_THANG"].ToString());
            SO_THANG_THANG = Convert.ToInt16(dtTmp.Rows[0]["SO_THANG_THANG"].ToString());
            KIEU_GOI = Convert.ToInt16(dtTmp.Rows[0]["KIEU_GOI"].ToString());
            if (dtTmp.Rows[0]["GIO_GOI"].ToString() != "") GIO_GOI = Convert.ToDateTime(dtTmp.Rows[0]["GIO_GOI"].ToString());
            SO_GIO_GOI = Convert.ToInt16(dtTmp.Rows[0]["SO_GIO_GOI"].ToString());
            LOAI_TIME = Convert.ToInt16(dtTmp.Rows[0]["LOAI_TIME"].ToString());

            if (dtTmp.Rows[0]["TG_BD"].ToString() != "") TG_BD = Convert.ToDateTime(dtTmp.Rows[0]["TG_BD"].ToString());
            if (dtTmp.Rows[0]["TG_KT"].ToString() != "") TG_KT = Convert.ToDateTime(dtTmp.Rows[0]["TG_KT"].ToString());
            LOAI_HIEU_LUC = Convert.ToInt16(dtTmp.Rows[0]["LOAI_HIEU_LUC"].ToString());
            if (dtTmp.Rows[0]["TG_BD_HL"].ToString() != "") TG_BD_HL = Convert.ToDateTime(dtTmp.Rows[0]["TG_BD_HL"].ToString());
            if (dtTmp.Rows[0]["TG_KT_HL"].ToString() != "") TG_KT_HL = Convert.ToDateTime(dtTmp.Rows[0]["TG_KT_HL"].ToString());
            if (dtTmp.Rows[0]["THU_2"].ToString() != "") THU_2 = Convert.ToBoolean(dtTmp.Rows[0]["THU_2"].ToString());
            if (dtTmp.Rows[0]["THU_3"].ToString() != "") THU_3 = Convert.ToBoolean(dtTmp.Rows[0]["THU_3"].ToString());
            if (dtTmp.Rows[0]["THU_4"].ToString() != "") THU_4 = Convert.ToBoolean(dtTmp.Rows[0]["THU_4"].ToString());
            if (dtTmp.Rows[0]["THU_5"].ToString() != "") THU_5 = Convert.ToBoolean(dtTmp.Rows[0]["THU_5"].ToString());
            if (dtTmp.Rows[0]["THU_6"].ToString() != "") THU_6 = Convert.ToBoolean(dtTmp.Rows[0]["THU_6"].ToString());
            if (dtTmp.Rows[0]["THU_7"].ToString() != "") THU_7 = Convert.ToBoolean(dtTmp.Rows[0]["THU_7"].ToString());
            if (dtTmp.Rows[0]["THU_CN"].ToString() != "") THU_CN = Convert.ToBoolean(dtTmp.Rows[0]["THU_CN"].ToString());

            if (dtTmp.Rows[0]["TEN_SCHEDULES"].ToString() != "") TEN_SCHEDULES = Convert.ToString(dtTmp.Rows[0]["TEN_SCHEDULES"].ToString());



        }

        public void LoadDuLieu(int MSo, string TenMBaoCao, DevExpress.XtraGrid.GridControl grd, DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            try
            {

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, "MGetDSMail", TenMBaoCao));
                dtTmp.PrimaryKey = new DataColumn[] { dtTmp.Columns["ID"] };

                Commons.Modules.ObjSystems.MLoadXtraGrid(grd, grv, dtTmp, false, false, true, false);
                //Commons.Modules.ObjSystems.MLoadNNXtraGrid(grv, TenMBaoCao);

                grv.Columns["ID"].Visible = false;
                grv.Columns["ID_SCHEDULES"].Visible = false;
                grv.Columns["ID_MAIL"].Visible = false;
                grv.Columns["DK_BAOCAO"].Visible = false;
                grv.Columns["NGON_NGU"].Visible = false;

                if (MSo != -1)
                {
                    int index = dtTmp.Rows.IndexOf(dtTmp.Rows.Find(MSo));
                    grv.FocusedRowHandle = grv.GetRowHandle(index);
                }
            }
            catch { };

        }
    }
}
