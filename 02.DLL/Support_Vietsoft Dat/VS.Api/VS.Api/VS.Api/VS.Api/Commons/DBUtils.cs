using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Configuration;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Security.Cryptography;
using System.Configuration;

namespace VS.Api
{
    public static class DBUtils
    {

        public static DataTable MGetDatatable(string mStoredName, List<SqlParameter> mParameters)
        {
            DataSet ds = new DataSet();
            ds = ExecDataSetSP(mStoredName, mParameters);
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();
            return dt;
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
                byte[] resultArray = cTransform.TransformFinalBlock(Convert.FromBase64String(cipherString), 0, Convert.FromBase64String(cipherString).Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
            }
            catch (Exception ex)
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






        public static DataSet ExecDataSetSP(string pSPName, List<SqlParameter> pParams)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(Startup.vscnn);

                SqlCommand cmd = new SqlCommand(pSPName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0; //seconds

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                //add parameters
                if (pParams != null)
                {
                    foreach (SqlParameter param in pParams)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                try
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Dispose();
                    da.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet ExecDataSetQR(string sText)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(Startup.vscnn);

                SqlCommand cmd = new SqlCommand(sText,conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0; //seconds

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                //add parameters
                try
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    da.Fill(ds);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Dispose();
                    da.Dispose();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public static object ExecNonQuerySP(string pSPName, List<SqlParameter> pParams)
        {
            object result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(Startup.vscnn);
                SqlCommand cmd = new SqlCommand(pSPName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300; //seconds

                //add parameters
                SqlParameter returnParam = new SqlParameter();
                if (pParams != null)
                {
                    foreach (SqlParameter param in pParams)
                    {
                        cmd.Parameters.Add(param);

                        if (param.Direction == ParameterDirection.ReturnValue)
                        {
                            returnParam = param;
                        }
                    }
                }

                try
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    result = returnParam.Value == null ? -1000 : returnParam.Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static object ExecNonQueryScalar(string pSPName, List<SqlParameter> pParams)
        {
            object result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(Startup.vscnn);
                SqlCommand cmd = new SqlCommand(pSPName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300; //seconds

                //add parameters
                SqlParameter returnParam = new SqlParameter();
                if (pParams != null)
                {
                    foreach (SqlParameter param in pParams)
                    {
                        cmd.Parameters.Add(param);

                        if (param.Direction == ParameterDirection.ReturnValue)
                        {
                            returnParam = param;
                        }
                    }
                }

                try
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public static List<object> ExecOutputSP(string pSPName, List<SqlParameter> pParams)
        {
            List<object> result = new List<object>();
            try
            {
                SqlConnection conn = new SqlConnection(Startup.vscnn);
                SqlCommand cmd = new SqlCommand(pSPName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300; //seconds

                //add parameters
                SqlParameter returnParam = new SqlParameter();
                if (pParams != null)
                {
                    foreach (SqlParameter param in pParams)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                try
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    foreach (SqlParameter param in pParams)
                    {
                        if (param.Direction == ParameterDirection.Output)
                        {
                            result.Add(param.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }



        public static T ExecuteSP<T>(string pSPName, List<SqlParameter> pParameters) where T : new()
        {
            try
            {
                DataTable datatable;
                DataSet ds = ExecDataSetSP(pSPName, pParameters);
                if (ds.Tables.Count > 0)
                    datatable = ds.Tables[0];
                else
                    datatable = new DataTable();

                T Temp = new T();
                try
                {
                    List<string> columnsNames = new List<string>();
                    foreach (DataColumn DataColumn in datatable.Columns)
                        columnsNames.Add(DataColumn.ColumnName);
                    Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObjectMSSql<T>(row, columnsNames)).FirstOrDefault();
                    return Temp;
                }
                catch
                {
                    return Temp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                        pro.SetValue(objT, row[pro.Name]);
                }
                return objT;
            }).ToList();
        }
        public static List<T> ExecuteSPList<T>(string pSPName, List<SqlParameter> pParameters) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                DataTable datatable;
                DataSet ds = ExecDataSetSP(pSPName, pParameters);
                if (ds.Tables.Count > 0)
                    datatable = ds.Tables[0];
                else
                    datatable = new DataTable();

                
                try
                {
                    Temp = ConvertToList<T>(datatable);
                    

                }
                catch  { }
            }
            catch { }
            return Temp;
           
            }

        public static List<T> ExecuteQueryList<T>(string sQuery) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                DataTable datatable;
                DataSet ds = ExecDataSetQR(sQuery);
                if (ds.Tables.Count > 0)
                    datatable = ds.Tables[0];
                else
                    datatable = new DataTable();


                try
                {
                    Temp = ConvertToList<T>(datatable);
                }
                catch { }
            }
            catch { }
            return Temp;

        }


        public static T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }

        }
        public static T getObjectMSSql<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        if (objProperty.PropertyType.Name == "Guid")
                        {
                            value = new Guid(row[columnname].ToString()).ToString();
                        }
                        else
                        {
                            value = row[columnname].ToString();
                        }
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                if (objProperty.PropertyType.Name == "Guid")
                                {
                                    value = new Guid(row[columnname].ToString()).ToString().Replace("$", "").Replace(",", "");
                                    objProperty.SetValue(obj, new Guid(row[columnname].ToString()), null);
                                }
                                else
                                {
                                    value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                    objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                                }
                            }
                            else
                            {
                                if (objProperty.PropertyType.Name == "Guid")
                                {
                                    value = new Guid(row[columnname].ToString()).ToString().Replace("%", "");
                                    objProperty.SetValue(obj, new Guid(row[columnname].ToString()), null);
                                }
                                else
                                {
                                    value = row[columnname].ToString().Replace("%", "");
                                    objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                                }
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }
        public static T getObjectOra<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        if (objProperty.PropertyType.Name == "Guid")
                        {
                            value = new Guid((byte[])row[columnname]).ToString();
                        }
                        else
                        {
                            value = row[columnname].ToString();
                        }
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                if (objProperty.PropertyType.Name == "Guid")
                                {
                                    value = new Guid((byte[])row[columnname]).ToString().Replace("$", "").Replace(",", "");
                                    objProperty.SetValue(obj, new Guid((byte[])row[columnname]), null);
                                }
                                else
                                {
                                    value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                    objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                                }
                            }
                            else
                            {
                                if (objProperty.PropertyType.Name == "Guid")
                                {
                                    value = new Guid((byte[])row[columnname]).ToString().Replace("%", "");
                                    objProperty.SetValue(obj, new Guid((byte[])row[columnname]), null);
                                }
                                else
                                {
                                    value = row[columnname].ToString().Replace("%", "");
                                    objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                                }
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }


        public static bool MCreateTableToDatatable(string tableSQLName, DataTable table, string sTaoTable)
        {
            try
            {
                if (sTaoTable == "")
                {
                    if (!MCreateTable(tableSQLName, table, Startup.vscnn))
                        return false;
                }
                else
                {
                    XoaTable(tableSQLName);
                    SqlHelper.ExecuteReader(Startup.vscnn, CommandType.Text, sTaoTable);
                }

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Startup.vscnn))
                {
                    System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(connection, System.Data.SqlClient.SqlBulkCopyOptions.TableLock | System.Data.SqlClient.SqlBulkCopyOptions.FireTriggers | System.Data.SqlClient.SqlBulkCopyOptions.UseInternalTransaction, null);

                    bulkCopy.DestinationTableName = tableSQLName;
                    connection.Open();

                    bulkCopy.WriteToServer(table);
                    connection.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool MCreateTable(string tableName, DataTable table, string connectionString)
        {
            try
            {
                string sql = "CREATE TABLE " + tableName + " (" + "\n";

                // columns
                int i = 1;
                foreach (DataColumn col in table.Columns)
                {
                    sql += "[" + col.ColumnName + "] " + MGetTypeSql(col.DataType, col.MaxLength, 10, 2) + "," + "\n";
                    i += 1;
                }
                sql += ")";

                XoaTable(tableName);
                SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void XoaTable(string strTableName)
        {
            try
            {
                string strSql = "DROP TABLE " + strTableName;
                SqlHelper.ExecuteScalar(Startup.vscnn, CommandType.Text, strSql);
            }
            catch
            {
            }
        }


        public static string MGetTypeSql(object type, int columnSize, int numericPrecision, int numericScale)
        {
            switch (type.ToString())
            {
                case "System.String":
                    {
                        if ((columnSize >= 2147483646))
                            return "NVARCHAR(MAX)";
                        else
                            return (columnSize == -1) ? "NVARCHAR(MAX)" : "NVARCHAR(" + columnSize.ToString() + ")";
                    }

                case "System.Decimal":
                    {
                        if (numericScale > 0)
                            return "REAL";
                        else if (numericPrecision > 10)
                            return "BIGINT";
                        else
                            return "INT";
                    }

                case "System.Boolean":
                    {
                        return "BIT";
                    }

                case "System.Double":
                    {
                        return "FLOAT";
                    }

                case "System.Single":
                    {
                        return "REAL";
                    }

                case "System.Int64":
                    {
                        return "BIGINT";
                    }

                case "System.Int16":
                    {
                        return "INT";
                    }

                case "System.Int32":
                    {
                        return "INT";
                    }

                case "System.DateTime":
                    {
                        return "DATETIME";
                    }

                case "System.Byte[]":
                    {
                        return "IMAGE";
                    }

                case "System.Drawing.Image":
                    {
                        return "IMAGE";
                    }

                default:
                    {
                        throw new Exception(type.ToString() + " not implemented.");
                    }
            }
        }
        public static void SendEmailCC(string address, string subject, string message)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Startup.vscnn, CommandType.Text, "SELECT MAIL_FROM,PASS_MAIL,SMTP_MAIL,PORT_MAIL,LINK_WEB FROM dbo.THONG_TIN_CHUNG"));
            string str = dt.Rows[0]["PASS_MAIL"].ToString();
            string password = "";
            const int _CODE_ = 354;
            for (int i = 0; i < str.Length; i++)
            {
                password += System.Convert.ToChar(((int)System.Convert.ToChar(str.Substring(i, 1)) / 2) - _CODE_).ToString();
            }
            string email = dt.Rows[0]["MAIL_FROM"].ToString();
            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient(dt.Rows[0]["SMTP_MAIL"].ToString());
            msg.From = new MailAddress(email, "ANDON -  WAHL");
            var mail = address.Split(';');
            foreach (var item in mail)
            {
                if (item.Trim() != "")
                {
                    msg.To.Add(new MailAddress(item));
                }
            }
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;
            //msg.Priority = MailPriority.High;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }


        public static void SendEmailCC(string address, string CC, string subject, string message)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Startup.vscnn, CommandType.Text, "SELECT MAIL_FROM,PASS_MAIL,SMTP_MAIL,PORT_MAIL,LINK_WEB FROM dbo.THONG_TIN_CHUNG"));
            string str = dt.Rows[0]["PASS_MAIL"].ToString();
            string password = "";
            const int _CODE_ = 354;
            for (int i = 0; i < str.Length; i++)
            {
                password += System.Convert.ToChar(((int)System.Convert.ToChar(str.Substring(i, 1)) / 2) - _CODE_).ToString();
            }
            string email = dt.Rows[0]["MAIL_FROM"].ToString();
            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient(dt.Rows[0]["SMTP_MAIL"].ToString());
            msg.From = new MailAddress(email, "ANDON -  WAHL");
            var mail = address.Split(';');
            foreach (var item in mail)
            {
                msg.To.Add(new MailAddress(item));
            }
            var mailcc = CC.Split(';');
            try
            {
                foreach (var item in mailcc)
                {
                    msg.CC.Add(new MailAddress(item));
                }
            }
            catch
            {
            }
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;
            //msg.Priority = MailPriority.High;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }
    }



}
