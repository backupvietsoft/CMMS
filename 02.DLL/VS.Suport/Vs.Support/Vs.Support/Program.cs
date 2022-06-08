using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Vs.Support
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //  Application.Run(new Form1());
            
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\vsconfig.xml");
            http = ds.Tables[0].Rows[0]["S"].ToString();
            // http = "http://localhost:8720/VS.Api/";
            //string str = @"Data Source=192.168.2.8;Initial Catalog=CMMS_CEN;User ID=sa;Password=codaikadaiku";
            //Application.Run(new frmSupport(Program.NNgu, "admin", "Nguyen Van X", "Cong ty walh", "xyz@walh.com", "09831xx1xx", "zalo", 19, 18, "trammp335@gmail.com", "thanhthuy2612", "smtp.gmail.com", 587));

            // Application.Run(new frmELearning(4));

            //Application.Run(new frmVSReply(Program.NNgu, "test123", "Nguyen Van Test", "Vietsoft", "vietsoft@gmail.com", "00000", "00000", 17, "skeylerhack@gmail.com", "01689561596", "smtp.gmail.com", 587));


            // Application.Run(new frmLogin(CNStr, 0,"VS.ERP"));
            //  Application.Run(new frmCustomer(CNStrNN,NNgu, "VS.ERP"));
            //  Application.Run(new frmCustomerContract(CNStrNN, NNgu, "VS.ERP"));

            Application.Run(new frmMain());

            // Application.Run(new frmReportContract(CNStrNNgu,NNgu,"VS.ERP"));

            //Application.Run(new frmContractVSStaff(CNStrNNgu,0,"VS.ERP"));
            //Application.Run(new frmReport_NV(CNStrNNgu, NNgu, "VS.ERP"));

        }

        private static int _NNgu;
        private static string _shttp = @"https://api.vietsoft.com.vn/VS.Api/";
        private static string _Subject = "Vs.Suport";
        private static string _Body = "Body";

        private static string _MailFrom_VS = "dattranlfc1010@gmail.com";
        private static string _MailPass_VS = "trpdsbozmcsjgeby";
        private static string _MailSMTP_VS = "smtp.gmail.com";
        private static int _MailPort_VS = 587;

        private static Int64 _CustomerID = 1;
        private static string _UNameLogin;
        private static string _Database;
        private static int _VietStaffID = -1;
        private static int _VSSDept = -1;

        //lay ID VietsoftStaff , frmViewStaff
        private static int _iID;

        private static string _AppName = "Vs.Suport";
        public static string AppName
        {
            get { return _AppName; }
            set { _AppName = value; }
        }

        public static string http
        {
            get { return _shttp; }
            set { _shttp = value; }
        }
        public static int NNgu
        {
            get { return _NNgu; }
            set { _NNgu = value; }
        }
        public static string UNameLogin
        {
            get { return _UNameLogin; }
            set { _UNameLogin = value; }
        }
        public static string Database
        {
            get { return _Database; }
            set { _Database = value; }
        }
        public static Int64 CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public static int VietStaffID
        {
            get { return _VietStaffID; }
            set { _VietStaffID = value; }
        }
        public static int VSSDept
        {
            get { return _VSSDept; }
            set { _VSSDept = value; }
        }
        public static string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        public static string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }
        public static string MailFrom_VS
        {
            get { return _MailFrom_VS; }
            set { _MailFrom_VS = value; }
        }
        public static string MailPass_VS
        {
            get { return _MailPass_VS; }
            set { _MailPass_VS = value; }
        }
        public static string MailSMTP_VS
        {
            get { return _MailSMTP_VS; }
            set { _MailSMTP_VS = value; }
        }
        public static int MailPort_VS
        {
            get { return _MailPort_VS; }
            set { _MailPort_VS = value; }
        }
        public static int iID
        {
            get { return _iID; }
            set { _iID = value; }
        }
        #region Ngon Ngu
        public static string GetLanguage(string sModuleName, string sFormName, string Keyword, int iNNgu, string CNStr)
        {
            string sStr;
            try
            {
                sStr = Convert.ToString(SqlHelper.ExecuteScalar(CNStr, "spGetNN", sModuleName, sFormName, Keyword, iNNgu)).Replace("\\n", "\n");
            }
            catch
            {
                sStr = "?" + Keyword + "?";
            }
            return sStr;
        }


        public static string GetLanguage(string sModuleName, string sFormName, string sKeyword, int iNNgu)
        {
            string sStr;
            try
            {
                //http://localhost:8720/VS.Api/Support/getNNgu?ModuleName=1&FormName=2&Keyword=3&TypeLanguage=4
                DataTable dtNN = new DataTable();
                dtNN = Vs.Support.Commons.API.getDataAPI(http + "Support/getNNgu?ModuleName=" + sModuleName + "&FormName=" + sFormName + "&Keyword=" + sKeyword + "&TypeLanguage=" + iNNgu.ToString() + "");
                sStr = dtNN.Rows[0][0].ToString();
            }
            catch
            {
                sStr = "?" + sKeyword + "?";
            }
            return sStr;
        }

        public static string GetNN(DataTable dtNN,  string sKeyWord, string sFormName)
        {
            string sNN = "";
            try
            {
                sNN = dtNN.AsEnumerable().Where(x => x["KEYWORD"].Equals(sKeyWord)).FirstOrDefault()[1].ToString();
            }
            catch
            {
                sNN = GetLanguage(Program.AppName, sFormName, sKeyWord, Program.NNgu);
            }
            return sNN;
        }
        public static string GetNN(DataTable dtNN, string sModuleName, string sKeyWord, string sFormName)
        {
            string sNN = "";
            try
            {
                sNN = dtNN.AsEnumerable().Where(x => x["KEYWORD"].Equals(sKeyWord)).FirstOrDefault()[1].ToString();
            }
            catch
            {
                sNN = GetLanguage(sModuleName, sFormName, sKeyWord, Program.NNgu);
            }
            return sNN;
        }

        public static DataTable GetDataNN(string sModuleName, string sFormName, int iNNgu)
        {
            //http://localhost:8720/VS.Api/Support/getDataNNgu?ModuleName=1&FormName=2&TypeLanguage=4
            DataTable dtNN = new DataTable();
            try
            {
                dtNN = Vs.Support.Commons.API.getDataAPI(http + "Support/getNNgu?ModuleName=" + sModuleName + "&FormName=" + sFormName + "&TypeLanguage=" + iNNgu.ToString() + "");
            }
            catch
            {

            }
            return dtNN;
        }

        public static DataTable GetDataNN(string sFormName)
        {
            
            //http://localhost:8720/VS.Api/Support/getDataNNgu?ModuleName=1&FormName=2&TypeLanguage=4
            DataTable dtNN = new DataTable();
            try
            {
                dtNN = Vs.Support.Commons.API.getDataAPI(http + "Support/getNNgu?ModuleName=" + Program.AppName + "&FormName=" + sFormName + "&TypeLanguage=" + NNgu.ToString() + "");
            }
            catch
            {

            }
            return dtNN;
        }

        #endregion

        public static DataSet MGetDataSet(string mStoredName, List<SqlParameter> mParameters)
        {
            //DataSet ds = new DataSet();
            //try
            //{
            //    SqlConnection conn = new SqlConnection(CNStr);

            //    SqlCommand cmd = new SqlCommand(mStoredName, conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandTimeout = 0;
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    da.SelectCommand = cmd;
            //    if (mParameters != null)
            //    {
            //        foreach (SqlParameter param in mParameters)
            //        {
            //            cmd.Parameters.Add(param);
            //        }
            //    }

            //    try
            //    {
            //        if (cmd.Connection.State == ConnectionState.Open)
            //        {
            //            cmd.Connection.Close();
            //        }
            //        cmd.Connection.Open();
            //        da.Fill(ds);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        if (cmd.Connection.State == ConnectionState.Open)
            //        {
            //            cmd.Connection.Close();
            //        }
            //        cmd.Dispose();
            //        da.Dispose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return ds;
            return null;
        }

        public static DataTable MGetDatatable(string mStoredName, List<SqlParameter> mParameters)
        {
            DataSet ds = new DataSet();
            ds = MGetDataSet(mStoredName, mParameters);
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else { return null; }

        }


        public static object MExecuteScalar(string mStoredName, List<SqlParameter> mParameters)
        {
            //object result = 0;
            //try
            //{
            //    SqlConnection conn = new SqlConnection(CNStr);

            //    SqlCommand cmd = new SqlCommand(mStoredName, conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandTimeout = 0;

            //    if (mParameters != null)
            //    {
            //        foreach (SqlParameter param in mParameters)
            //        {
            //            cmd.Parameters.Add(param);
            //        }
            //    }
            //    try
            //    {
            //        if (cmd.Connection.State == ConnectionState.Open)
            //        {
            //            cmd.Connection.Close();
            //        }
            //        cmd.Connection.Open();
            //        result = cmd.ExecuteScalar();
            //        return result;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        if (cmd.Connection.State == ConnectionState.Open)
            //        {
            //            cmd.Connection.Close();
            //        }
            //        cmd.Dispose();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        }


        public static object MExecuteNonQuery(string mStoredName, List<SqlParameter> mParameters)
        {
            //object result = 0;

            //SqlConnection conn = new SqlConnection(CNStr);
            //SqlCommand cmd = new SqlCommand(mStoredName, conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandTimeout = 300; //seconds

            ////add parameters
            //SqlParameter returnParam = new SqlParameter();
            //if (mParameters != null)
            //{
            //    foreach (SqlParameter param in mParameters)
            //    {
            //        cmd.Parameters.Add(param);

            //        if (param.Direction == ParameterDirection.ReturnValue)
            //        {
            //            returnParam = param;
            //        }
            //    }
            //}

            //try
            //{
            //    if (cmd.Connection.State == ConnectionState.Open)
            //    {
            //        cmd.Connection.Close();
            //    }
            //    cmd.Connection.Open();
            //    cmd.ExecuteNonQuery();

            //    result = "";// returnParam.Value == null ? "-1000" : returnParam.Value;
            //}
            //catch (Exception ex)
            //{
            //    result = ex.ToString();
            //    throw ex;
            //}
            //finally
            //{
            //    if (cmd.Connection.State == ConnectionState.Open)
            //    {
            //        cmd.Connection.Close();
            //    }
            //    cmd.Dispose();
            //}

            //return result;
            return null;
        }



        static string SecurityKey = "vietsoft.com.vn";
        static string chuoi = "_13579_";
        public static string Decrypt(string cipherString, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                //Get your key from config file to open the lock!
                string key = SecurityKey;//(string)settingsReader.GetValue("SecurityKey", typeof(String));

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
            }
            catch
            {
                byte[] byteData = Encoding.Unicode.GetBytes("");
                //return UTF8Encoding.UTF8.GetString(byteData).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
                return Convert.ToBase64String(byteData);
            }
        }


        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(chuoi + toEncrypt + chuoi);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                // Get the key from config file
                string key = SecurityKey; /*(string)settingsReader.GetValue("SecurityKey", typeof(String));*/
                                          //System.Windows.Forms.MessageBox.Show(key);
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch
            {
                byte[] byteData = Encoding.Unicode.GetBytes("");
                return Convert.ToBase64String(byteData);
            }
        }

    }
}
