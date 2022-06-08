using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static partial class Datavs
    {
        /// <summary>
        /// Select DISTINCT
        /// </summary> 
        public static DataTable SelectDistinct(DataTable TbSource, params string[] strFieldname)
        {
            object[] lastValues;
            DataTable newTable;
            DataRow[] orderedRows;
            if (strFieldname == null || strFieldname.Length == 0)
                throw new ArgumentNullException("strFieldname");

            lastValues = new object[strFieldname.Length];
            newTable = new DataTable();

            foreach (string fieldName in strFieldname)
                newTable.Columns.Add(fieldName, TbSource.Columns[fieldName].DataType);

            orderedRows = TbSource.Select("", string.Join(", ", strFieldname));

            foreach (DataRow row in orderedRows)
            {
                if (!FieldValuesAreEqual(lastValues, row, strFieldname))
                {
                    newTable.Rows.Add(CreateRowClone(row, newTable.NewRow(), strFieldname));

                    SetLastValues(lastValues, row, strFieldname);
                }
            }

            return newTable;
        }
        private static bool FieldValuesAreEqual(object[] lastValues, DataRow currentRow, string[] fieldNames)
        {
            bool areEqual = true;

            for (int i = 0; i < fieldNames.Length; i++)
            {
                if (lastValues[i] == null || !lastValues[i].Equals(currentRow[fieldNames[i]]))
                {
                    areEqual = false;
                    break;
                }
            }

            return areEqual;
        }
        private static DataRow CreateRowClone(DataRow sourceRow, DataRow newRow, string[] fieldNames)
        {
            foreach (string field in fieldNames)
                newRow[field] = sourceRow[field];

            return newRow;
        }
        private static void SetLastValues(object[] lastValues, DataRow sourceRow, string[] fieldNames)
        {
            for (int i = 0; i < fieldNames.Length; i++)
                lastValues[i] = sourceRow[fieldNames[i]];
        }
        /// <summary>
        /// Xóa toàn bộ dữ liệu trong dataview
        /// </summary> 
        public static void ClearDataView(DataView dtDataview)
        {
            for (int i = 0; i < dtDataview.Count; i++)
            {
                dtDataview.Delete(i);
            }
        }
        /// <summary>
        /// Insert 
        /// </summary> 
        public static int Insert(Sqlvs SqlvsInsert, string strStoreInsert, DataRow rDatarow)
        {
            return SqlvsInsert.ExecuteNonQuery(CommandType.StoredProcedure, strStoreInsert, rDatarow.ItemArray);
        }
        /// <summary>
        /// Insert 
        /// </summary> 
        public static int Insert(string strConnec, string strStoreInsert, DataRow rDatarow)
        {
            Sqlvs SqlvsInsert = new Sqlvs();
            return SqlvsInsert.ExecuteNonQuery(CommandType.StoredProcedure, strStoreInsert, rDatarow.ItemArray);
        }
        /// <summary>
        /// Insert  
        /// </summary> 
        public static int Insert(Sqlvs SqlvsInsert, string strStoreInsert, DataTable tbTable)
        {
            int intRowInsert = 0;
            foreach (DataRow rInsert in tbTable.Rows)
            {
                intRowInsert = intRowInsert + Insert(SqlvsInsert, strStoreInsert, rInsert);
            }
            return intRowInsert;
        }
        /// <summary>
        /// Insert  
        /// </summary> 
        public static int Insert(string strConnec, string strStoreInsert, DataTable tbTable)
        {
            int intRowInsert = 0;
            foreach (DataRow rInsert in tbTable.Rows)
            {
                intRowInsert = intRowInsert + Insert(strConnec, strStoreInsert, rInsert);
            }
            return intRowInsert;
        }
        /// <summary>
        /// Delete
        /// </summary> 
        public static int Delete(Sqlvs SqlvsDelete, string strStoreDelete, DataRow rDatarow, params string[] strFieldKey)
        {
            object[] objFieldKey = new object[strFieldKey.Length];
            for (int i = 0; i < strFieldKey.Length; i++)
            {
                objFieldKey[i] = rDatarow[strFieldKey[i]];
            }
            return SqlvsDelete.ExecuteNonQuery(CommandType.StoredProcedure, strStoreDelete, objFieldKey);
        }
        /// <summary>
        /// Delete
        /// </summary> 
        public static int Delete(string strConnec, string strStoreDelete, DataRow rDatarow, params string[] strFieldKey)
        {
            Sqlvs SqlvsDelete = new Sqlvs();
            object[] objFieldKey = new object[strFieldKey.Length];
            for (int i = 0; i < strFieldKey.Length; i++)
            {
                objFieldKey[i] = rDatarow[strFieldKey[i]];
            }
            return SqlvsDelete.ExecuteNonQuery(CommandType.StoredProcedure, strStoreDelete, objFieldKey);
        }
        /// <summary>
        /// Delete 
        /// </summary> 
        public static int Delete(Sqlvs SqlvsDelete, string strStoreDelete, DataTable tbTable, params string[] strFieldKey)
        {
            int intRowDelete = 0;
            foreach (DataRow rDatarow in tbTable.Rows)
            {
                intRowDelete = intRowDelete + Delete(SqlvsDelete, strStoreDelete, rDatarow, strFieldKey);
            }
            return intRowDelete;
        }
        /// <summary>
        /// Delete 
        /// </summary> 
        public static int Delete(string strConnec, string strStoreDelete, DataTable tbTable, params string[] strFieldKey)
        {
            int intRowDelete = 0;
            foreach (DataRow rDatarow in tbTable.Rows)
            {
                intRowDelete = intRowDelete + Delete(strConnec, strStoreDelete, rDatarow, strFieldKey);
            }
            return intRowDelete;
        }
        /// <summary>
        /// Update Recode, không sửa key
        /// </summary> 
        public static int Update(Sqlvs SqlvsUpdate, string strStoreUpdate, DataRow rDatarow)
        {
            return SqlvsUpdate.ExecuteNonQuery(CommandType.StoredProcedure, strStoreUpdate, rDatarow.ItemArray);
        }
        /// <summary>
        /// Update Recode, không sửa key
        /// </summary> 
        public static int Update(string strConnect, string strStoreUpdate, DataRow rDatarow)
        {
            Sqlvs SqlvsUpdate = new Sqlvs();
            return SqlvsUpdate.ExecuteNonQuery(CommandType.StoredProcedure, strStoreUpdate, rDatarow.ItemArray);
        }
        /// <summary>
        /// Update
        /// </summary> 
        public static void Update(Sqlvs SqlvsUpdate, string strStoreInsert, string strStoreUpdate, string strStoreSelect, DataTable tbTable, params string[] strFieldKey)
        {
            foreach (DataRow rDatarow in tbTable.Rows)
            {
                if (AllReady(SqlvsUpdate, strStoreSelect, rDatarow, strFieldKey))
                {
                    Update(SqlvsUpdate, strStoreUpdate, rDatarow);
                }
                else
                {
                    Insert(SqlvsUpdate, strStoreInsert, rDatarow);
                }
            }

        }
        /// <summary>
        /// Update
        /// </summary> 
        public static void Update(string strConnect, string strStoreInsert, string strStoreUpdate, string strStoreSelect, DataTable tbTable, params string[] strFieldKey)
        {
            foreach (DataRow rDatarow in tbTable.Rows)
            {
                if (AllReady(strConnect, strStoreSelect, rDatarow, strFieldKey))
                {
                    Update(strConnect, strStoreUpdate, rDatarow);
                }
                else
                {
                    Insert(strConnect, strStoreInsert, rDatarow);
                }
            }

        }
        /// <summary>        
        /// True là tồn tại ,False là không tồn tại
        /// </summary> 
        public static bool AllReady(Sqlvs SqlvsAllready, string strStoreSelect, DataRow rDataRow, params string[] strFieldKey)
        {
            object[] objFieldKey = new object[strFieldKey.Length];
            for (int i = 0; i < strFieldKey.Length; i++)
            {
                objFieldKey[i] = rDataRow[strFieldKey[i]];
            }
            if (Convert.ToInt32(SqlvsAllready.ExecuteScalar(CommandType.StoredProcedure, strStoreSelect, objFieldKey)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>        
        /// True là tồn tại ,False là không tồn tại
        /// </summary> 
        public static bool AllReady(string strConnect, string strStoreSelect, DataRow rDataRow, params string[] strFieldKey)
        {
            Sqlvs SqlvsAllready = new Sqlvs();
            object[] objFieldKey = new object[strFieldKey.Length];
            for (int i = 0; i < strFieldKey.Length; i++)
            {
                objFieldKey[i] = rDataRow[strFieldKey[i]];
            }            
            if (Convert.ToInt32(SqlvsAllready.ExecuteScalar(CommandType.StoredProcedure, strStoreSelect, objFieldKey)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
