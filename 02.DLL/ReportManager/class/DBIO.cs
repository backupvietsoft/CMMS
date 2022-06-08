using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace ReportManager
{
    public class LoaiBaoCao
    {
        public static int _LoaiBC;
        public static int LoaiBC
        {
            get { return _LoaiBC; }
            set { int _LoaiBC = value; }
        }
    }

    public class DBIO
    {

        /*
         * Perform a single row query, storing the resulting fields into the data container.
         * In the SQL select statement, column names should be aliased with the "as <name" if you want
         * the component name to be different than the column name.
         * 
         * All values are stored as strings in the data container.
        */
        public static void QuerySingleRow(DataContainer dc, string spName, string menuName)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, spName, new IDataParameter[] { new SqlParameter("@menuName", menuName) });
            if (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)				// for every field...
                {
                    string s1 = reader.GetName(i);					// get the column or alias name
                    string s2 = reader.GetValue(i).ToString();		// get the value as a string
                    dc[s1] = s2;								// save in our data container
                }
            }
            reader.Close();
        }


        public static DataMatrix QueryMultiRow(DataContainer dc, string spName, string matrixName, string username,string groupname)
        {
            DataTable dt = new DataTable();
            DataMatrix dm;
            if (LoaiBaoCao.LoaiBC == 1)
            {

                if (groupname == "" || groupname == string.Empty)
                {
                    if (Commons.Modules.LicID == 0)
                    {
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, spName,
                            Commons.Modules.TypeLanguage, LoaiBaoCao.LoaiBC));
                    }
                    else
                    {
                        string sBTLic, sBT;
                        sBTLic = "HVER_LIC" + Commons.Modules.UserName;
                        sBT = "HVER" + Commons.Modules.UserName;

                        DataTable dtTMP = new DataTable();
                        dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, spName,
                                                Commons.Modules.TypeLanguage, LoaiBaoCao.LoaiBC));
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTMP, "");
                        Commons.Modules.LicID = 1;
                        string sSql = "SELECT TYPE" + Commons.Modules.LicID.ToString() + " AS MASO FROM LIC_ID " +
                            " WHERE (ID_NAME <> N'" + Commons.Modules.ObjSystems.MaHoaDL("mnuReport").ToString() + "') " +
                            " AND (ID_NAME LIKE N'" + Commons.Modules.ObjSystems.MaHoaDL("mnuReport").ToString() + "%')";
                        dtTMP = new DataTable();
                        dtTMP.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                        dtTMP.Columns[0].ReadOnly = false;


                        foreach (DataRow DR in dtTMP.Rows)
                        {
                            sSql = Commons.Modules.ObjSystems.GiaiMaDL(DR[0].ToString());
                            sSql = sSql.Replace("mnuReport", "");
                            if (int.Parse(sSql.Substring(sSql.Length - 2, 2).Substring(0, 1)) != Commons.Modules.LicID)
                            {
                                DR[0] = "";
                            }
                            else
                            {
                                if (int.Parse(sSql.Substring(sSql.Length - 1, 1)) == 0)
                                {
                                    DR[0] = "";
                                }
                                else
                                {
                                    //mnuReportTHONGKECHIPHI5  -- mnuReportTHONGTINSUDUNG3
                                    sSql = sSql.Substring(0, sSql.Length - 2);
                                    if (sSql.ToUpper() == "THONGKECHIPHI5") sSql = "THONGKECHIPHI";
                                    if (sSql.ToUpper() == "TONKHO8") sSql = "TONKHO";
                                    if (sSql.ToUpper() == "THONGTINSUDUNG3") sSql = "THONGTINSUDUNG";

                                    DR[0] = sSql;
                                }
                            }
                        }
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBTLic, dtTMP, "");
                        sSql = "SELECT A.* FROM " + sBT + "  A INNER JOIN (SELECT * FROM " + sBTLic + " WHERE ISNULL(MASO ,'') <> '') B  ON A.TEN_L_REPORT = B.MASO ORDER BY STT";
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sSql));
                    }
                }
                else
                {
                    string sBTLic, sBT;
                    sBT = "";
                    try
                    {
                        DataTable dtTmp = new DataTable();
                        sBTLic = "AAA_MANAGER_1REPORT_LIC" + Commons.Modules.UserName;
                        Commons.Modules.ObjSystems.MGiaiMaTable(sBTLic, "LIC_REPORT", "REPORT_NAME", Commons.Modules.UserName, true);

                        dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, spName, username,
                            groupname, Commons.Modules.TypeLanguage, LoaiBaoCao.LoaiBC));
                        sBT = "AAA_MANAGER_REPORT" + Commons.Modules.UserName;
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.ConnectionString, sBT, dtTmp, "");

                        sBT = " SELECT  A.REPORT_NAME,A.TEN_REPORT,A.NOTE,A.NAMES,A.[TYPE] FROM " + sBT +
                            " A INNER JOIN " + sBTLic + " B ON A.REPORT_NAME = B.REPORT_NAME ORDER BY A.STT, " +
                            " TEN_REPORT";
                    }
                    catch { }
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, CommandType.Text, sBT));
                    sBTLic = "AAA_MANAGER_1REPORT_LIC" + Commons.Modules.UserName;
                    sBT = "AAA_MANAGER_REPORT" + Commons.Modules.UserName;
                    string sSql;
                    sSql = "DROP TABLE " + sBTLic;
                    try
                    { SqlHelper.ExecuteScalar(Commons.IConnections.ConnectionString, CommandType.Text, sSql); }
                   catch { }
                    Commons.Modules.ObjSystems.XoaTable(sBTLic);
                    Commons.Modules.ObjSystems.XoaTable(sBT);
                }

                dm = new DataMatrix(dt.Columns.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dm.AddRow();
                    for (int j = 0; j < dt.Columns.Count;j++)
                    {
                        dm.SetCell(j, i, dt.Rows[i][j].ToString());
                    }
                    
                }
                dc.Set(matrixName, dm);
                return dm;
            }
            else
            {
                if (groupname == "" || groupname == string.Empty)
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, spName, Commons.Modules.TypeLanguage, LoaiBaoCao.LoaiBC));
                }
                else
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.ConnectionString, spName, username,
                    groupname,Commons.Modules.TypeLanguage, LoaiBaoCao.LoaiBC));             
                }


                dm = new DataMatrix(dt.Columns.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dm.AddRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        dm.SetCell(j, i, dt.Rows[i][j].ToString());
                    }

                }          
                dc.Set(matrixName, dm);
                return dm;
            }
            
        }
    }
}
