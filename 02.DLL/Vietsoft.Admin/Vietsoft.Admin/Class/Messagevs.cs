using System;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static class Messagevs
    {
        public static DialogResult Show(string msgID, MessageBoxButtons msgButtons, MessageBoxIcon msgIcon, MessageBoxDefaultButton msgDefault)
        {
            try
            {
                Sqlvs sqlMsg = new Sqlvs();
                System.Data.DataTable tbMsg = new DataTable();
                tbMsg.Load(sqlMsg.ExecuteReader(CommandType.StoredProcedure, "SP_S_MESSAGE_DESIGN", Adminvs.Language, msgID));
                return MessageBox.Show(tbMsg.Rows[0]["MSG_C"].ToString(), tbMsg.Rows[0]["MSG_T"].ToString(), msgButtons, msgIcon, msgDefault);
            }
            catch
            {
                return MessageBox.Show("?" + msgID + "?", "?" + msgID + "?", msgButtons, msgIcon, msgDefault);
            }
        }
    }
}
