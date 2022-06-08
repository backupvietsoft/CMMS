using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.ApplicationBlocks.Data;
using System.Windows.Forms;

namespace CMMSIntegrationLib.CMMS
{
    public class integrate_data_generate
    {
        public integrate_data_generate()
        {
        }

        public static void generateScriptToCMMSData()
        {
            UpdateQuery();

        }

        private static void UpdateQuery()
        {
            string _path = Application.StartupPath + "\\SQL_INTEGRATION";

            if (string.IsNullOrEmpty(FileSystem.Dir(_path, FileAttribute.Directory)))
                return;
            string[] sListFiles = System.IO.Directory.GetFiles(_path);
            if (sListFiles.Length == 0)
            {
                System.IO.Directory.Delete(_path);
                return;
            }
            for (int i = 0; i <= sListFiles.Length - 1; i++)
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(Integration.integrate_common.cmms_connection,System.Data.CommandType.Text, LayNoiDungFileText(sListFiles[i]));
                }
                catch 
                {
                }
            }
        }
        private static string LayNoiDungFileText(string sPathFile)
        {
            string sTmp = "";
            //Khon co file 
            if (!System.IO.File.Exists(sPathFile))
            {
                return sTmp;
            }
            System.IO.StreamReader sFileInclude = null;
            try
            {
                sFileInclude = System.IO.File.OpenText(sPathFile);
                sTmp = sFileInclude.ReadToEnd();
                sFileInclude.Close();
            }
            catch 
            {
            }
            return sTmp;
         }

    }
}
