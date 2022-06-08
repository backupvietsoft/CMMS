using System;
using System.Xml;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Vietsoft
{
    public partial class SqlInfo
    {
        /// <summary>
        /// Declare public
        /// </summary>
        private SqlConnection sqlCnn = new SqlConnection();
        private SqlCommand sqlCmd = new SqlCommand();
        private SqlTransaction sqlTran = null;
        /// <summary>
        /// Function declare SqlInfo
        /// </summary>         
        public SqlInfo(string StringConnection)
        {
            sqlCnn.ConnectionString = StringConnection;
            if (sqlCnn.State == ConnectionState.Closed)
            {
                sqlCnn.Open();
            }
            sqlCmd.Connection = sqlCnn;
        }
        /// <summary>
        /// Begin transaction
        /// </summary>
        public void BeginTransaction()
        {
            sqlTran = sqlCnn.BeginTransaction();
            sqlCmd.Connection = sqlCnn;
            sqlCmd.Transaction = sqlTran;
        }
        /// <summary>
        /// Save transaction
        /// </summary>
        public void SaveTransaction(string TransactionName)
        {
            sqlTran.Save(TransactionName);
        }
        /// <summary>
        /// Commit transaction
        /// </summary>
        public void CommitTransaction()
        {
            sqlTran.Commit();
        }
        /// <summary>
        /// Rollback transaction
        /// </summary>
        public void RollbackTransaction()
        {
            sqlTran.Rollback();
        }
        /// <summary>
        /// Rollback transaction
        /// </summary>
        public void RollbackTransaction(string TransactionName)
        {
            sqlTran.Rollback(TransactionName);
        }
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        public int ExecuteNonQuery(string SqlString )
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SqlString;
            return sqlCmd.ExecuteNonQuery();
        }
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        public int ExecuteNonQuery(CommandType SqlType, string SqlString)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = SqlType;
            sqlCmd.CommandText = SqlString;
            return sqlCmd.ExecuteNonQuery();
        }
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        public int ExecuteNonQuery(CommandType SqlType, string SqlString, params object[] SqlParameter )
        {
            sqlCmd.Parameters.Clear();
            if (SqlType == CommandType.StoredProcedure)
            {
                AddParameter(SqlString, SqlParameter);
            }
            sqlCmd.CommandType = SqlType;
            sqlCmd.CommandText = SqlString;
            return sqlCmd.ExecuteNonQuery();
        }
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        public object ExecuteScalar(string SqlString)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SqlString;
            return sqlCmd.ExecuteScalar();
        }
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        public object ExecuteScalar(CommandType SqlType, string SqlString)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = SqlType;
            sqlCmd.CommandText = SqlString;
            return sqlCmd.ExecuteScalar();
        }
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        public object ExecuteScalar(CommandType SqlType, string SqlString, params object[] SqlParameter)
        {
            sqlCmd.Parameters.Clear();
            if (SqlType == CommandType.StoredProcedure)
            {
                AddParameter(SqlString, SqlParameter);
            }
            sqlCmd.CommandType = SqlType;
            sqlCmd.CommandText = SqlString;
            return sqlCmd.ExecuteScalar();
        }        
        /// <summary>
        /// ExecuteReader
        /// </summary>
        public SqlDataReader ExecuteReader(string SqlString)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = SqlString;
            return sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// ExecuteReader
        /// </summary>
        public SqlDataReader ExecuteReader(CommandType SqlType, string SqlString)
        {
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = SqlType;
            sqlCmd.CommandText = SqlString;
            return sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// ExecuteReader
        /// </summary>
        public SqlDataReader ExecuteReader(CommandType SqlType, string SqlString, params object[] SqlParameter)
        {
            sqlCmd.Parameters.Clear();
            if (SqlType == CommandType.StoredProcedure)
            {
                AddParameter(SqlString, SqlParameter);
            }
            sqlCmd.CommandType = SqlType;
            sqlCmd.CommandText = SqlString;
            return sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// Add parameter
        /// </summary>
        private void AddParameter(string ProcedureName, params object[]SqlParameter)
        {
            sqlCmd.Connection = sqlCnn;
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = '" + ProcedureName + "' ORDER BY ORDINAL_POSITION ASC";
            DataTable TbParameter = new DataTable();
            TbParameter.Load(sqlCmd.ExecuteReader());
            sqlCmd.Parameters.Clear();
            for (int i = 0; i < SqlParameter.Length; i++)
            {
                DataRow rName = TbParameter.Rows[i];
                SqlParameter SqlParameterAdd = sqlCmd.CreateParameter();
                SqlParameterAdd.ParameterName = rName["PARAMETER_NAME"].ToString().Trim();

                switch (rName["DATA_TYPE"].ToString().Trim().ToUpper())
                {
                    case "BIGINT":
                        SqlParameterAdd.SqlDbType = SqlDbType.BigInt;
                        break;
                    case "BINARY":
                        SqlParameterAdd.SqlDbType = SqlDbType.Binary;
                        break;
                    case "BIT":
                        SqlParameterAdd.SqlDbType = SqlDbType.Bit;
                        break;
                    case "CHAR":
                        SqlParameterAdd.SqlDbType = SqlDbType.Char;
                        break;
                    case "DATETIME":
                        SqlParameterAdd.SqlDbType = SqlDbType.DateTime;
                        break;
                    case "DECIMAL":
                        SqlParameterAdd.SqlDbType = SqlDbType.Decimal;
                        break;
                    case "FLOAT":
                        SqlParameterAdd.SqlDbType = SqlDbType.Float;
                        break;
                    case "IMAGE":
                        SqlParameterAdd.SqlDbType = SqlDbType.Image;
                        break;
                    case "INT":
                        SqlParameterAdd.SqlDbType = SqlDbType.Int;
                        break;
                    case "MONEY":
                        SqlParameterAdd.SqlDbType = SqlDbType.Money;
                        break;
                    case "NCHAR":
                        SqlParameterAdd.SqlDbType = SqlDbType.NChar;
                        break;
                    case "NTEXT":
                        SqlParameterAdd.SqlDbType = SqlDbType.NText;
                        break;
                    case "NUMERIC":
                        SqlParameterAdd.SqlDbType = SqlDbType.Real;
                        break;
                    case "NVARCHAR":
                        SqlParameterAdd.SqlDbType = SqlDbType.NVarChar;
                        break;
                    case "REAL":
                        SqlParameterAdd.SqlDbType = SqlDbType.Real;
                        break;
                    case "SMALLDATETIME":
                        SqlParameterAdd.SqlDbType = SqlDbType.SmallDateTime;
                        break;
                    case "SMALLINT":
                        SqlParameterAdd.SqlDbType = SqlDbType.SmallInt;
                        break;
                    case "SMALLMONEY":
                        SqlParameterAdd.SqlDbType = SqlDbType.SmallMoney;
                        break;
                    case "TEXT":
                        SqlParameterAdd.SqlDbType = SqlDbType.Text;
                        break;
                    case "TIMESTAMP":
                        SqlParameterAdd.SqlDbType = SqlDbType.Timestamp;
                        break;
                    case "TINYINT":
                        SqlParameterAdd.SqlDbType = SqlDbType.TinyInt;
                        break;
                    case "UDT":
                        SqlParameterAdd.SqlDbType = SqlDbType.Udt;
                        break;
                    case "UNIQUEIDENTIFIER":
                        SqlParameterAdd.SqlDbType = SqlDbType.UniqueIdentifier;
                        break;
                    case "VARBINARY":
                        SqlParameterAdd.SqlDbType = SqlDbType.VarBinary;
                        break;
                    case "VARCHAR":
                        SqlParameterAdd.SqlDbType = SqlDbType.VarChar;
                        break;
                    case "VARIANT":
                        SqlParameterAdd.SqlDbType = SqlDbType.Variant;
                        break;
                    case "XML":
                        SqlParameterAdd.SqlDbType = SqlDbType.Xml;
                        break;
                }
                SqlParameterAdd.Value = SqlParameter[i];
                sqlCmd.Parameters.Add(SqlParameterAdd);
            }
        }

    }
}
