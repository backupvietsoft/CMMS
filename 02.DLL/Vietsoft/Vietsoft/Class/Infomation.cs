using System;
using System.Data;

using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;
using System.Net;
using System.Globalization;

namespace Vietsoft
{
    public static class Information
    {
        /// <summary>
        /// Declare public
        /// </summary> 
        private static string _IP = String.Empty;
        private static string _Connectionstring = "Data Source=CMMS;Initial Catalog=CMMS_DUYTAN;User ID=sa;Pwd=123";
        private static string _Username = String.Empty;
        private static string _UserID = String.Empty;
        private static string _ModuleName = String.Empty;
        private static int _Language = 0;
        private static string _Dateformat = String.Empty;
        private static string _Datemask = String.Empty;
        private static string _Timeformat = String.Empty;
        private static string _Timemask = String.Empty;
        private static string _Quantityformat = String.Empty;
        private static string _Priceformat = String.Empty;
        private static string _Currencyformat = String.Empty;
        private static string _Quantityformats = String.Empty;
        private static string _Priceformats = String.Empty;
        private static string _Currencyformats = String.Empty;

        /// <summary>
        /// IP
        /// </summary> 
        public static string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                _IP = value;
            }
        }
        /// <summary>
        /// ConnectionString
        /// </summary> 
        public static string ConnectionString
        {
            get
            {
                return _Connectionstring;
            }
            set
            {
                _Connectionstring = value;
            }
        }
        /// <summary>
        /// Username
        /// </summary> 
        public static string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }
        /// <summary>
        /// Username
        /// </summary> 
        public static string UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        /// <summary>
        /// Username
        /// </summary> 
        public static string ModuleName
        {
            get
            {
                return _ModuleName;
            }
            set
            {
                _ModuleName = value;
            }
        }
        /// <summary>
        /// Language
        /// </summary> 
        public static int Language
        {
            get
            {
                return _Language;
            }
            set
            {
                _Language = value;
            }
        }
        /// <summary>
        /// DateFormat
        /// </summary> 
        public static string DateFormat
        {
            get
            {
                return _Dateformat;
            }
            set
            {
                _Dateformat = value;
            }
        }
        /// <summary>
        /// DateMask
        /// </summary> 
        public static string DateMask
        {
            get
            {
                return _Datemask;
            }
            set
            {
                _Datemask = value;
            }
        }
        /// <summary>
        /// TimeFormat
        /// </summary> 
        public static string TimeFormat
        {
            get
            {
                return _Timeformat;
            }
            set
            {
                _Timeformat = value;
            }
        }
        /// <summary>
        /// TimeMask
        /// </summary> 
        public static string TimeMask
        {
            get
            {
                return _Timemask;
            }
            set
            {
                _Timemask = value;
            }
        }
        /// <summary>
        /// QuantityFormat
        /// </summary> 
        public static string QuantityFormat
        {
            get
            {
                return _Quantityformat;
            }
            set
            {
                _Quantityformat = value;
            }
        }
        /// <summary>
        /// PriceFormat
        /// </summary> 
        public static string PriceFormat
        {
            get
            {
                return _Priceformat;
            }
            set
            {
                _Priceformat = value;
            }
        }
        /// <summary>
        /// CurrencyFormat
        /// </summary> 
        public static string CurrencyFormat
        {
            get
            {
                return _Currencyformat;
            }
            set
            {
                _Currencyformat = value;
            }
        }
        /// <summary>
        /// QuantityFormats
        /// </summary> 
        public static string QuantityFormats
        {
            get
            {
                return _Quantityformats;
            }
            set
            {
                _Quantityformats = value;
            }
        }
        /// <summary>
        /// PriceFormats
        /// </summary> 
        public static string PriceFormats
        {
            get
            {
                return _Priceformats;
            }
            set
            {
                _Priceformats = value;
            }
        }
        /// <summary>
        /// CurrencyFormats
        /// </summary> 
        public static string CurrencyFormats
        {
            get
            {
                return _Currencyformats;
            }
            set
            {
                _Currencyformats = value;
            }
        }
        /// <summary>
        /// GetID
        /// </summary>
        public static string GetID(string Hkey)
        {
            try
            {
                SqlInfo sqlID = new SqlInfo(_Connectionstring);
                string ID = String.Empty;
                DateTime Hdate = DateTime.ParseExact("01/" + DateTime.Now.ToString("MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                ID = (string)sqlID.ExecuteScalar(CommandType.StoredProcedure, "sp_get_id", Hkey, Hdate);
                return ID;
            }
            catch
            {
                return null;
            }
        }       
        public static string GetID(string Hkey, DateTime Hdate)
        {
            try
            {
                SqlInfo sqlID = new SqlInfo(_Connectionstring);
                string ID = String.Empty;
                Hdate = DateTime.ParseExact("01/" + Hdate.ToString("MM/yyyy"), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                ID = (string)sqlID.ExecuteScalar(CommandType.StoredProcedure, "sp_get_id", Hkey, Hdate);
                return ID;
            }
            catch
            {
                return null;
            }
        }

        public static string GetLanguage(string ModuleName, string FormName, string Keyword, int TypeLanguage)
        {
            //SqlDataReader dtReader;
            Vietsoft.SqlInfo SqlLanguage = new Vietsoft.SqlInfo(Vietsoft.Information.ConnectionString);
            SqlDataReader dtReader;
            string tam = null;
            //MsgBox(Connect.ConnectionString)            
            dtReader = SqlLanguage.ExecuteReader(CommandType.StoredProcedure, "GetLanguage", ModuleName, FormName, Keyword);
            if (dtReader.HasRows)
            {
                while (dtReader.Read())
                {
                    if (TypeLanguage == 0)
                    {
                        tam = dtReader["VIETNAM"].ToString();
                    }
                    else
                    {
                        if (TypeLanguage == 1)
                        {
                            tam = dtReader["ENGLISH"].ToString();
                        }
                        else
                        {
                            tam = dtReader["CHINESE"].ToString();
                        }
                    }
                    dtReader.Close();
                    return tam;
                }

            }
            else
            {
                dtReader.Close();
                string sTV = "@" + Keyword + "@";
                string sTA = "@" + Keyword + "@";
                string sTH = "@" + Keyword + "@";
                string sSql = " SELECT TOP 1 ISNULL(VIETNAM,'') AS VIETNAM, ISNULL(ENGLISH,'') AS ENGLISH,ISNULL(CHINESE,'') AS CHINESE " + " FROM [LANGUAGES] WHERE KEYWORD = N'" + Keyword + "'   AND SUBSTRING(VIETNAM,1,1) <> '@' " + " GROUP BY VIETNAM , ENGLISH, CHINESE ORDER BY COUNT(KEYWORD) DESC";

                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Vietsoft.Information.ConnectionString, CommandType.Text, sSql));

                if (dtTmp.Rows.Count > 0)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(dtTmp.Rows[0]["VIETNAM"].ToString()))
                            sTV = dtTmp.Rows[0]["VIETNAM"].ToString();
                    }
                    catch 
                    {
                        sTV = "@" + Keyword + "@";
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(dtTmp.Rows[0]["ENGLISH"].ToString()))
                            sTA = dtTmp.Rows[0]["ENGLISH"].ToString();
                    }
                    catch 
                    {
                        sTA = "@" + Keyword + "@";
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(dtTmp.Rows[0]["CHINESE"].ToString()))
                            sTH = dtTmp.Rows[0]["CHINESE"].ToString();
                    }
                    catch 
                    {
                        sTH = "@" + Keyword + "@";
                    }
                }
                int result = SqlHelper.ExecuteNonQuery(Vietsoft.Information.ConnectionString, CommandType.Text, " INSERT INTO [LANGUAGES]([MS_MODULE],[FORM],[KEYWORD],[VIETNAM],[ENGLISH],[CHINESE]," + " [FORM_HAY_REPORT],[VIETNAM_OR],[ENGLISH_OR],[CHINESE_OR]) " + " VALUES(N'" + ModuleName + "',N'" + FormName + "',N'" + Keyword + "',N'" + sTV + "',N'" + sTA + "',N'" + sTH + "'," + " 0,N'" + sTV + "',N'" + sTA + "',N'" + sTH + "')");
                if (TypeLanguage == 0)
                {
                    tam = sTV;
                }
                else
                {
                    if (TypeLanguage == 1)
                    {
                        tam = sTA;
                    }
                    else
                    {
                        tam = sTH;
                    }
                }
                dtReader.Close();
                return tam;
            }
            if (dtReader.IsClosed)
            {
                dtReader.Close();
            }
            return "?" + Keyword + "?";
            
        }
        public static void ThayDoiNN(System.Windows.Forms.Form frmContent)
        {
            frmContent.Text = GetLanguage(Vietsoft.Information.ModuleName, frmContent.Name, frmContent.Name, Vietsoft.Information.Language);
            foreach (System.Windows.Forms.Control ctl in frmContent.Controls)
            {
                ControlType(ctl, frmContent);
            }
        }
        private static void ControlType(System.Windows.Forms.Control Ctl, System.Windows.Forms.Form frm)
        {
            if (Ctl.Controls.Count >= 1)
            {
                if (Ctl.GetType().Name == "TabPage")
                {
                    DoiNN(Ctl, frm);
                }
                if (Ctl.GetType().Name == "GroupBox")
                {
                    DoiNN(Ctl, frm);
                }
                foreach (System.Windows.Forms.Control type in Ctl.Controls)
                {
                    if (type.GetType().Name == "DataGridView" || type.GetType().Name == "DataGridViewEditor")
                    {
                        foreach (System.Windows.Forms.DataGridViewColumn cl in ((System.Windows.Forms.DataGridView)type).Columns)
                        {
                            cl.HeaderText = GetLanguage(Vietsoft.Information.ModuleName, frm.Name, cl.Name, Vietsoft.Information.Language);
                        }
                    }
                    else
                    {
                        ControlType(type, frm);
                    }
                }
            }
            else
            {
                DoiNN(Ctl, frm);
            }
        }
        private static void DoiNN(System.Windows.Forms.Control Ctl, System.Windows.Forms.Form frm)
        {
            switch (Ctl.GetType().Name)
            {
                case "Label":
                case "Button":
                case "RadioButton":
                case "CheckBox":
                    Ctl.Text = GetLanguage(Vietsoft.Information.ModuleName, frm.Name, Ctl.Name, Vietsoft.Information.Language);
                    break;
                case "GroupBox":
                    Ctl.Text = GetLanguage(Vietsoft.Information.ModuleName, frm.Name, Ctl.Name, Vietsoft.Information.Language);
                    break;
                case "TabPage":
                    Ctl.Text = GetLanguage(Vietsoft.Information.ModuleName, frm.Name, Ctl.Name, Vietsoft.Information.Language);
                    break;
            }
        }

        /// <summary>
        /// MsgBox
        /// </summary>
        public static DialogResult MsgBox(System.Windows.Forms.Form frm ,string msgID, MessageBoxButtons msgButtons, MessageBoxIcon msgIcon, MessageBoxDefaultButton msgDefault)
        {
            return DevExpress.XtraEditors.XtraMessageBox.Show(GetLanguage(Vietsoft.Information.ModuleName, frm.Name, msgID, Vietsoft.Information.Language), "Vietsoft", msgButtons, msgIcon, msgDefault);
        }

        public static DateTime GetNistTime()
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
            var response = myHttpWebRequest.GetResponse();
            string todaysDates = response.Headers["date"];
            return DateTime.ParseExact(todaysDates,
                                       "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                       CultureInfo.InvariantCulture.DateTimeFormat,
                                       DateTimeStyles.AssumeUniversal);
        }

    }
}
