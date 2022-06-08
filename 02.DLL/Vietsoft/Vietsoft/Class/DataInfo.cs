using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace Vietsoft
{
    public static partial class DataInfo
    {
        /// <summary>
        /// Select distinct
        /// </summary> 
        public static DataTable SelectDistinct(DataTable TbSelect , params string[]ListColumn)
        {
            return TbSelect.DefaultView.ToTable(true, ListColumn);
        }       
        /// <summary>
        /// Clear data
        /// </summary> 
        public static void ClearData(DataView ViewClear)
        {
            for (int i = 0; i < ViewClear.Count; i++)
            {
                ViewClear.Table.Rows.Remove(ViewClear[i].Row);
                i--;
            }
        }
        public static void ClearData(DataTable TableClear)
        {
            TableClear.Rows.Clear();
        }
        /// <summary>
        /// Insert datarow
        /// </summary> 
        public static int InsertDataRow(SqlInfo SqlInsert , string ProcedureInsert, DataRow DatarowInsert)
        {
            return SqlInsert.ExecuteNonQuery(CommandType.StoredProcedure, ProcedureInsert, DatarowInsert.ItemArray);
        }
        /// <summary>
        /// Insert datarow
        /// </summary> 
        public static int InsertDataRow(string StringConnection, string ProcedureInsert, DataRow DatarowInsert)
        {
            SqlInfo SqlInsert = new SqlInfo(StringConnection);
            return SqlInsert.ExecuteNonQuery(CommandType.StoredProcedure, ProcedureInsert, DatarowInsert.ItemArray);
        }
        /// <summary>
        /// Insert datatable 
        /// </summary> 
        public static int InsertDataTable(SqlInfo SqlInsert, string ProcedureInsert, DataTable TableInsert)
        {
            int RowCount = 0;
            foreach (DataRow RowInsert in TableInsert.Rows)
            {
                RowCount = RowCount + InsertDataRow(SqlInsert, ProcedureInsert, RowInsert);
            }
            return RowCount;
        }       
        /// <summary>
        /// Insert datatable 
        /// </summary> 
        public static int InsertDataTable(string StringConnec , string ProcedureInsert, DataTable TableInsert)
        {
            int RowCount = 0;
            SqlInfo SqlInsert = new SqlInfo(StringConnec);
            foreach (DataRow RowInsert in TableInsert.Rows)
            {
                RowCount = RowCount + InsertDataRow(SqlInsert, ProcedureInsert, RowInsert);
            }
            return RowCount;
        }
        /// <summary>
        /// Insert dataview
        /// </summary> 
        public static int InsertDataView(SqlInfo SqlInsert, string ProcedureInsert, DataView DataViewInsert)
        {
            int RowCount = 0;
            foreach (DataRow RowInsert in DataViewInsert.ToTable().Rows)
            {
                RowCount = RowCount + InsertDataRow(SqlInsert, ProcedureInsert, RowInsert);
            }
            return RowCount;
        }
        public static int InsertDataView(string StringConnec, string ProcedureInsert, DataView DataViewInsert)
        {
            int RowCount = 0;
            SqlInfo SqlInsert = new SqlInfo(StringConnec);
            foreach (DataRow RowInsert in DataViewInsert.ToTable().Rows)
            {
                RowCount = RowCount + InsertDataRow(SqlInsert, ProcedureInsert, RowInsert);
            }
            return RowCount;
        }
        /// <summary>
        /// Delete datarow
        /// </summary> 
        public static int DeleteDataRow(SqlInfo SqlDelete, string ProcedureDelete, DataRow DatarowDelete, params string[]ListColumn)
        {
            object[]ValueColumn = new object[ListColumn.Length];
            for (int i = 0; i < ListColumn.Length; i++)
            {
                ValueColumn[i] = DatarowDelete[ListColumn[i]];
            }
            return SqlDelete.ExecuteNonQuery(CommandType.StoredProcedure, ProcedureDelete, ValueColumn);
        }
        public static int DeleteDataRow(string StringConnec, string ProcedureDelete, DataRow DatarowDelete, params string[] ListColumn)
        {
            SqlInfo SqlDelete = new SqlInfo(StringConnec);
            object[] ValueColumn = new object[ListColumn.Length];
            for (int i = 0; i < ListColumn.Length; i++)
            {
                ValueColumn[i] = DatarowDelete[ListColumn[i]];
            }
            return SqlDelete.ExecuteNonQuery(CommandType.StoredProcedure, ProcedureDelete, ValueColumn);
        }        
        /// <summary>
        /// Delete datatable 
        /// </summary> 
        public static int DeleteDataTable(SqlInfo SqlDelete, string ProcedureDelete, DataTable TableDelete, params string[] ListColumn)
        {
            int RowCount = 0;
            foreach (DataRow DatarowDelete in TableDelete.Rows)
            {
                RowCount = RowCount + DeleteDataRow(SqlDelete, ProcedureDelete, DatarowDelete, ListColumn);
            }
            return RowCount;
        }
        public static int DeleteDataTable(string StringConnec , string ProcedureDelete, DataTable TableDelete, params string[] ListColumn)
        {
            SqlInfo SqlDelete = new SqlInfo(StringConnec);
            int RowCount = 0;
            foreach (DataRow DatarowDelete in TableDelete.Rows)
            {
                RowCount = RowCount + DeleteDataRow(SqlDelete, ProcedureDelete, DatarowDelete, ListColumn);
            }
            return RowCount;
        }
        /// <summary>
        /// Delete dataview 
        /// </summary> 
        public static int DeleteDataView(SqlInfo SqlDelete, string ProcedureDelete, DataView DataViewDelete, params string[] ListColumn)
        {
            int RowCount = 0;
            foreach (DataRow DatarowDelete in DataViewDelete.ToTable().Rows)
            {
                RowCount = RowCount + DeleteDataRow(SqlDelete, ProcedureDelete, DatarowDelete, ListColumn);
            }
            return RowCount;
        }
        public static int DeleteDataView(string StringConnec, string ProcedureDelete, DataView DataViewDelete, params string[] ListColumn)
        {
            SqlInfo SqlDelete = new SqlInfo(StringConnec);
            int RowCount = 0;
            foreach (DataRow DatarowDelete in DataViewDelete.ToTable ().Rows)
            {
                RowCount = RowCount + DeleteDataRow(SqlDelete, ProcedureDelete, DatarowDelete, ListColumn);
            }
            return RowCount;
        }  
        /// <summary>
        /// Update datarow
        /// </summary> 
        public static int UpdateDataRow(SqlInfo SqlUpdate, string ProcedureUpdate, DataRow DataRowUpdate)
        {
            return SqlUpdate.ExecuteNonQuery(CommandType.StoredProcedure, ProcedureUpdate, DataRowUpdate.ItemArray);
        }
        public static int UpdateDataRow(string StringConnec , string ProcedureUpdate, DataRow DataRowUpdate)
        {
            SqlInfo SqlUpdate = new SqlInfo(StringConnec);
            return SqlUpdate.ExecuteNonQuery(CommandType.StoredProcedure, ProcedureUpdate, DataRowUpdate.ItemArray);
        }       
        /// <summary>
        /// Update datatable
        /// </summary> 
        public static void UpdateDataTable(SqlInfo SqlUpdate, string ProcedureInsert, string ProcedureUpdate,string ProcedureCheckData , DataTable TableUpdate, params string[]ListColumn)
        {
            foreach (DataRow DatarowUpdate in TableUpdate.Rows)
            {
                if (CheckDataAllready(SqlUpdate, ProcedureCheckData, DatarowUpdate, ListColumn)>0)
                {
                    UpdateDataRow(SqlUpdate, ProcedureUpdate, DatarowUpdate);
                }
                else
                {
                    InsertDataRow(SqlUpdate, ProcedureInsert, DatarowUpdate);
                }
            }

        }
        public static void UpdateDataTable(string StringConnec, string ProcedureInsert, string ProcedureUpdate, string ProcedureCheckData, DataTable TableUpdate, params string[] ListColumn)
        {
            SqlInfo SqlUpdate = new SqlInfo(StringConnec);
            foreach (DataRow DatarowUpdate in TableUpdate.Rows)
            {
                if (CheckDataAllready(SqlUpdate, ProcedureCheckData, DatarowUpdate, ListColumn) > 0)
                {
                    UpdateDataRow(SqlUpdate, ProcedureUpdate, DatarowUpdate);
                }
                else
                {
                    InsertDataRow(SqlUpdate, ProcedureInsert, DatarowUpdate);
                }
            }

        }
        /// <summary>
        /// Update dataview
        /// </summary> 
        public static void UpdateDataView(SqlInfo SqlUpdate, string ProcedureInsert, string ProcedureUpdate, string ProcedureCheckData, DataView DataViewUpdate , params string[] ListColumn)
        {
            foreach (DataRow DatarowUpdate in DataViewUpdate.ToTable ().Rows)
            {
                if (CheckDataAllready(SqlUpdate, ProcedureCheckData, DatarowUpdate, ListColumn) > 0)
                {
                    UpdateDataRow(SqlUpdate, ProcedureUpdate, DatarowUpdate);
                }
                else
                {
                    InsertDataRow(SqlUpdate, ProcedureInsert, DatarowUpdate);
                }
            }

        }
        public static void UpdateDataView(string StringConnec, string ProcedureInsert, string ProcedureUpdate, string ProcedureCheckData, DataView DataViewUpdate, params string[] ListColumn)
        {
            SqlInfo SqlUpdate = new SqlInfo(StringConnec);
            foreach (DataRow DatarowUpdate in DataViewUpdate.ToTable ().Rows)
            {
                if (CheckDataAllready(SqlUpdate, ProcedureCheckData, DatarowUpdate, ListColumn) > 0)
                {
                    UpdateDataRow(SqlUpdate, ProcedureUpdate, DatarowUpdate);
                }
                else
                {
                    InsertDataRow(SqlUpdate, ProcedureInsert, DatarowUpdate);
                }
            }

        }
        /// <summary>        
        /// Check data allready
        /// </summary> 
        public static int CheckDataAllready(SqlInfo SqlCheck, string ProcedureCheckData, DataRow DataRowCheck, params string[]ListColumn)
        {
            object[] ValueColumn = new object[ListColumn.Length];
            for (int i = 0; i < ListColumn.Length; i++)
            {
                ValueColumn[i] = DataRowCheck[ListColumn[i]];
            }
            return (int)SqlCheck.ExecuteScalar(CommandType.StoredProcedure, ProcedureCheckData, ValueColumn);           
        }
        public static int CheckDataAllready(string StringConnec, string ProcedureCheckData, DataRow DataRowCheck, params string[] ListColumn)
        {
            SqlInfo SqlCheck = new SqlInfo(StringConnec);
            object[] ValueColumn = new object[ListColumn.Length];
            for (int i = 0; i < ListColumn.Length; i++)
            {
                ValueColumn[i] = DataRowCheck[ListColumn[i]];
            }
            return (int)SqlCheck.ExecuteScalar(CommandType.StoredProcedure, ProcedureCheckData, ValueColumn);
        }
       
    }
}
