using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static partial class Modevs
    {
        /// <summary>
        /// SelectMode
        /// </summary>
        public static DataGridViewSelectionMode SelectMode(string strID)
        {
            try
            {
                Sqlvs sqlMode = new Sqlvs();
                switch (Convert.ToInt32( sqlMode.ExecuteScalar(System.Data.CommandType.StoredProcedure, "SP_S_MODE_DESIGN", strID)))
                {                                            
                    case 2:
                        return DataGridViewSelectionMode.ColumnHeaderSelect;
                    case 3:
                        return DataGridViewSelectionMode.FullColumnSelect;
                    case 4:
                        return DataGridViewSelectionMode.FullRowSelect;
                    case 5:
                        return DataGridViewSelectionMode.RowHeaderSelect;
                    default:
                        return DataGridViewSelectionMode.CellSelect;
                }                
            }
            catch
            {
                return DataGridViewSelectionMode.CellSelect;
            }
        }
    }
}
