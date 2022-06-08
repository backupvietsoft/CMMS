using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Globalization;


namespace MVControl
{
    public class KiemApp
    {
        static string key = @"C!#%C@$^E!@#E$%^N&*(N";
        public static Boolean MLoadCboTreeList(ref ucComboboxTreeList cboTree, System.Data.DataTable dtTmp, string MaCha, string Ma, string Ten)
        {
            try
            {
                cboTree.DataSource = null;
                cboTree.KeyFieldName = Ma;
                cboTree.ParentFieldName = MaCha;
                cboTree.ColumnDisplayName = Ten;
                cboTree.DataSource = dtTmp;
                cboTree.DataBind();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean MKiemTrail(string sBD)
        {
            
            #region Bien
            string sChung, sCC, sM, sN, sK;
            sCC = "01/01/0001";
           
            sChung = "01/01/0001;01/01/0001";
            sK = "01/01/0001";
            Boolean bDungNgay = true;
            #endregion
            //Kiem chay lan dau, neu chua co thi ghi ngay vao + lay du lieu tu regedit
            #region "Kiem Chay Lan Dau"
            try
            {
                using (Microsoft.Win32.RegistryKey key =                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE"))
                {
                    sChung = (string)key.GetValue("KeyValue");
                    if (string.IsNullOrEmpty(sChung.ToString()))
                    {
                        using (Microsoft.Win32.RegistryKey key1 =
                        Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE"))
                        {
                            sChung = DateTime.Now.Date.ToString("MM/dd/yyyy") + ";" + DateTime.Now.Date.ToString("MM/dd/yyyy");
                            var cipher = MEn(sChung);
                            sChung = cipher.ToString();
                            key1.SetValue("KeyValue", sChung, Microsoft.Win32.RegistryValueKind.String);
                        }
                    }
                }
            }
            catch
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey key1 =
                        Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE"))
                    {
                        sChung = DateTime.Now.Date.ToString("MM/dd/yyyy") + ";" + DateTime.Now.Date.ToString("MM/dd/yyyy");
                        var cipher = MEn(sChung);
                        sChung = cipher.ToString();
                        key1.SetValue("KeyValue", sChung, Microsoft.Win32.RegistryValueKind.String);

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    return false;
                }

            }
            #endregion
            #region Kiem tra 
            try
            {
                //sChung = "20/08/2018;18/08/2018";
                sChung = MDe(sChung).ToString();
                sCC = sChung.Substring(11, 10);
                sK = Convert.ToDateTime(sBD, CultureInfo.InvariantCulture).AddMonths(3).ToString("MM/dd/yyyy");
            }
            catch
            {

            }
            sM = DateTime.Now.Date.ToString("MM/dd/yyyy");
            sN = MGetDateInt().ToString("MM/dd/yyyy");
            if (Convert.ToDateTime(sN, CultureInfo.InvariantCulture) == Convert.ToDateTime("01/01/0001", CultureInfo.InvariantCulture))
            {
                if (Convert.ToDateTime(sM, CultureInfo.InvariantCulture) < Convert.ToDateTime(sCC, CultureInfo.InvariantCulture))
                    sN = sCC;
                else
                    sN = sM;
                bDungNgay = false;
            }

            if (Convert.ToDateTime(sM, CultureInfo.InvariantCulture) < Convert.ToDateTime(sN, CultureInfo.InvariantCulture))
            {
                bDungNgay = false;
                XtraMessageBox.Show("Chương trình phát hiện bạn đã thay đổi ngày, Vui lòng đổi lại theo đúng ngày hệ thống!");
                return false;
            }
            else
            {
                sN = sM;
            }



            if (bDungNgay)
            {
                //if (Convert.ToDateTime(sCC, CultureInfo.InvariantCulture) <= Convert.ToDateTime(sN, CultureInfo.InvariantCulture))
                sCC = sN;
                //else
                //    sCC = sCC;
            }
            else
            {
                if (Convert.ToDateTime(sM, CultureInfo.InvariantCulture) <= Convert.ToDateTime(sN, CultureInfo.InvariantCulture))
                {
                    if (Convert.ToDateTime(sCC, CultureInfo.InvariantCulture) <= Convert.ToDateTime(sN, CultureInfo.InvariantCulture))
                        sCC = Convert.ToDateTime(sN, CultureInfo.InvariantCulture).AddDays(1).ToString("MM/dd/yyyy");
                    else
                        sCC = Convert.ToDateTime(sCC, CultureInfo.InvariantCulture).AddDays(1).ToString("MM/dd/yyyy");
                }
                else
                {
                    if (Convert.ToDateTime(sCC, CultureInfo.InvariantCulture) <= Convert.ToDateTime(sM, CultureInfo.InvariantCulture))
                        sCC = Convert.ToDateTime(sM, CultureInfo.InvariantCulture).AddDays(1).ToString("MM/dd/yyyy");
                    else
                        sCC = Convert.ToDateTime(sCC, CultureInfo.InvariantCulture).AddDays(1).ToString("MM/dd/yyyy");
                }

            }

            int day = (Convert.ToDateTime(sCC, CultureInfo.InvariantCulture) - Convert.ToDateTime(sK, CultureInfo.InvariantCulture)).Days;

            if (day > 0)
            {
                XtraMessageBox.Show("Đã hết thời gian dùng thử, Vui lòng liên hệ nhà cung cấp!");
                return false;
            }
            #endregion
            #region Ghi dulieu vao regedit
            sChung = sBD + ";" + sCC;
            sChung = MEn(sChung).ToString();
            try
            {
                using (Microsoft.Win32.RegistryKey key1 =
                    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE"))
                {
                    key1.SetValue("KeyValue", sChung, Microsoft.Win32.RegistryValueKind.String);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            #endregion
            return true;
        }

        private static DateTime MGetDateInt()
        {
            {
                try
                {
                    using (WebResponse response = WebRequest.Create("http://www.microsoft.com").GetResponse()) return DateTime.ParseExact(response.Headers["date"], "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
                }
                catch { return DateTime.Parse("01/01/0001 00:00:00"); }
            }
        }

        public static string MEn(string sChuoi)
        {
            using (var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
            {
                using (var tdes = new System.Security.Cryptography.TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = System.Security.Cryptography.CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(sChuoi);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static string MDe(string sChuoi)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(sChuoi);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }


    }
    public class clsTinhTrangThietBi
    {
        public int msthongso { get; set; }
        public string msmay { get; set; }
        public string msbp { get; set; }
        public int mstt { get; set; }


        public string sTenCV;
        public string sThaoTac { get; set; }
        public string sTieuChuan { get; set; }
        public string sYeuCauNS { get; set; }
        public string sYeuCauDC { get; set; }
        public string sTaiLieu { get; set; }

    }
    class GiamSatTinhTrangTS
    {
        public string TEN_GIA_TRI;
        public string MS_MAY;
        public bool CHON;
        public string MS_TS_GSTT;
        public string MS_BO_PHAN;
        public bool DAT;
        public string GHI_CHU;
    }


    

}
