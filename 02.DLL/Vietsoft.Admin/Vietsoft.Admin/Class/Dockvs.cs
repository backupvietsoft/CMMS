using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static class Dockvs
    {
        /// <summary>
        /// Dock của control
        /// </summary>
        public static DockStyle ToDock(string strID)
        {
            try
            {
                Sqlvs sqlDock = new Sqlvs();
                switch (Convert.ToInt32(sqlDock.ExecuteScalar(System.Data.CommandType.StoredProcedure, "SP_S_DOCK_DESIGN", strID)))
                {
                    case 2:
                        return DockStyle.Top;
                    case 3:
                        return DockStyle.Left;
                    case 4:
                        return DockStyle.Right;
                    case 5:
                        return DockStyle.Bottom;
                    case 6:
                        return DockStyle.Fill;
                    default:
                        return DockStyle.None;
                }
            }
            catch
            {
                return DockStyle.None;
            }
        }
        /// <summary>
        /// Dock của datagridview
        /// </summary>
        public static DataGridViewAutoSizeColumnMode AutoSizeMode(string strID)
        {
            try
            {
                Sqlvs sqlDock = new Sqlvs();
                switch (Convert.ToInt32(sqlDock.ExecuteScalar(System.Data.CommandType.StoredProcedure, "SP_S_AUTOMODE_DESIGN", strID)))
                {
                    case 1:
                        return DataGridViewAutoSizeColumnMode.AllCells;
                    case 2:
                        return DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    case 3:
                        return DataGridViewAutoSizeColumnMode.ColumnHeader;
                    case 4:
                        return DataGridViewAutoSizeColumnMode.DisplayedCells;
                    case 5:
                        return DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                    case 6:
                        return  DataGridViewAutoSizeColumnMode.Fill;                    
                    default:
                        return DataGridViewAutoSizeColumnMode.None;
                }
            }
            catch
            {
                return DataGridViewAutoSizeColumnMode.None;
            }
        }   
    }
}
