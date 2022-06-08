using System;
using System.Xml;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public partial class Sqlvs
    {
        /// <summary>
        /// Khai báo chung
        /// </summary>
        private SqlConnection sqlCnn = new SqlConnection();
        private SqlCommand sqlCmd = new SqlCommand();
        private SqlTransaction sqlTran = null;
        /// <summary>
        /// Khởi tạo
        /// </summary>         
        public Sqlvs()
        {
            sqlCnn.ConnectionString = Adminvs.ConnectionString;
            if (sqlCnn.State == ConnectionState.Closed)
            {
                sqlCnn.Open();
            }
            sqlCmd.Connection = sqlCnn;
        }
        /// <summary>
        /// Bắt đầu transaction
        /// </summary>
        public void BeginTransaction()
        {
            sqlTran = sqlCnn.BeginTransaction();
            sqlCmd.Connection = sqlCnn;
            sqlCmd.Transaction = sqlTran;
        }
        /// <summary>
        /// Lưu điểm transaction
        /// </summary>
        public void Save(string strName)
        {
            sqlTran.Save(strName);
        }
        /// <summary>
        /// Hoàn thành transaction
        /// </summary>
        public void Commit()
        {
            sqlTran.Commit();
        }
        /// <summary>
        /// Rollback
        /// </summary>
        public void Rollback()
        {
            sqlTran.Rollback();
        }
        /// <summary>
        /// Rollback
        /// </summary>
        public void Rollback(string strName)
        {
            sqlTran.Rollback(strName);
        }
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        public int ExecuteNonQuery(string strText)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteNonQuery();
        }
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        public int ExecuteNonQuery(CommandType sqlType, string strText)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = sqlType;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteNonQuery();
        }
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        public int ExecuteNonQuery(CommandType sqlType, string strText, params object[] objParameter)
        {
            sqlCmd.Parameters.Clear();
            SetParameter(strText, objParameter);
            sqlCmd.CommandType = sqlType;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteNonQuery();
        }
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        public object ExecuteScalar(string strText)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteScalar();
        }
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        public object ExecuteScalar(CommandType sqlType, string strText)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = sqlType;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteScalar();
        }
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        public object ExecuteScalar(CommandType sqlType, string strText, params object[] objParameter)
        {
            sqlCmd.Parameters.Clear();
            SetParameter(strText, objParameter);
            sqlCmd.CommandType = sqlType;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteScalar();
        }
        /// <summary>
        /// ExecuteXmlReader
        /// </summary>
        public XmlReader ExecuteXmlReader(string strText)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteXmlReader();
        }
        /// <summary>
        /// ExecuteXmlReader
        /// </summary>
        public XmlReader ExecuteXmlReader(CommandType sqlType, string strText)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = sqlType;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteXmlReader();
        }
        /// <summary>
        /// ExecuteXmlReader
        /// </summary>
        public XmlReader ExecuteXmlReader(CommandType sqlType, string strText, params object[] objParameter)
        {
            sqlCmd.Parameters.Clear();
            SetParameter(strText, objParameter);
            sqlCmd.CommandType = sqlType;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteXmlReader();
        }
        /// <summary>
        /// ExecuteReader
        /// </summary>
        public SqlDataReader ExecuteReader(string strText)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// ExecuteReader
        /// </summary>
        public SqlDataReader ExecuteReader(CommandType sqlType, string strText)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = sqlType;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// ExecuteReader
        /// </summary>
        public SqlDataReader ExecuteReader(CommandType sqlType, string strText, params object[] objParameter)
        {
            sqlCmd.Parameters.Clear();
            SetParameter(strText, objParameter);
            sqlCmd.CommandType = sqlType;
            sqlCmd.CommandText = strText;
            return sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// Set tham số cho store 
        /// </summary>
        private void SetParameter(string strName, params object[] objParameter)
        {
            sqlCmd.Connection = sqlCnn;
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = '" + strName + "' ORDER BY ORDINAL_POSITION ASC";
            DataTable Tb_Parameter = new DataTable();
            Tb_Parameter.Load(sqlCmd.ExecuteReader());
            sqlCmd.Parameters.Clear();
            for (int i = 0; i < objParameter.Length; i++)
            {
                DataRow rParameter = Tb_Parameter.Rows[i];
                SqlParameter sqlPara = sqlCmd.CreateParameter();
                sqlPara.ParameterName = rParameter["PARAMETER_NAME"].ToString().Trim();
                switch (rParameter["DATA_TYPE"].ToString().Trim().ToUpper())
                {
                    case "BIGINT":
                        break;
                    case "BINARY":
                        sqlPara.SqlDbType = SqlDbType.Binary;
                        break;
                    case "BIT":
                        sqlPara.SqlDbType = SqlDbType.Bit;
                        break;
                    case "CHAR":
                        sqlPara.SqlDbType = SqlDbType.Char;
                        break;
                    case "DATETIME":
                        sqlPara.SqlDbType = SqlDbType.DateTime;
                        break;
                    case "DECIMAL":
                        sqlPara.SqlDbType = SqlDbType.Decimal;
                        break;
                    case "FLOAT":
                        sqlPara.SqlDbType = SqlDbType.Float;
                        break;
                    case "IMAGE":
                        sqlPara.SqlDbType = SqlDbType.Image;
                        break;
                    case "INT":
                        sqlPara.SqlDbType = SqlDbType.Int;
                        break;
                    case "MONEY":
                        sqlPara.SqlDbType = SqlDbType.Money;
                        break;
                    case "NCHAR":
                        sqlPara.SqlDbType = SqlDbType.NChar;
                        break;
                    case "NTEXT":
                        sqlPara.SqlDbType = SqlDbType.NText;
                        break;
                    case "NUMERIC":
                        sqlPara.SqlDbType = SqlDbType.Real;
                        break;
                    case "NVARCHAR":
                        sqlPara.SqlDbType = SqlDbType.NVarChar;
                        break;
                    case "REAL":
                        sqlPara.SqlDbType = SqlDbType.Real;
                        break;
                    case "SMALLDATETIME":
                        sqlPara.SqlDbType = SqlDbType.SmallDateTime;
                        break;
                    case "SMALLINT":
                        sqlPara.SqlDbType = SqlDbType.SmallInt;
                        break;
                    case "SMALLMONEY":
                        sqlPara.SqlDbType = SqlDbType.SmallMoney;
                        break;
                    case "TEXT":
                        sqlPara.SqlDbType = SqlDbType.Text;
                        break;
                    case "TIMESTAMP":
                        sqlPara.SqlDbType = SqlDbType.Timestamp;
                        break;
                    case "TINYINT":
                        sqlPara.SqlDbType = SqlDbType.TinyInt;
                        break;
                    case "UDT":
                        sqlPara.SqlDbType = SqlDbType.Udt;
                        break;
                    case "UNIQUEIDENTIFIER":
                        sqlPara.SqlDbType = SqlDbType.UniqueIdentifier;
                        break;
                    case "VARBINARY":
                        sqlPara.SqlDbType = SqlDbType.VarBinary;
                        break;
                    case "VARCHAR":
                        sqlPara.SqlDbType = SqlDbType.VarChar;
                        break;
                    case "VARIANT":
                        sqlPara.SqlDbType = SqlDbType.Variant;
                        break;
                    case "XML":
                        sqlPara.SqlDbType = SqlDbType.Xml;
                        break;
                }
                sqlPara.Value = objParameter[i];
                sqlCmd.Parameters.Add(sqlPara);
            }
        }

    }
}
