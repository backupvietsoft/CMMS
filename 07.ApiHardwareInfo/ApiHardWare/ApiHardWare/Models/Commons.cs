﻿using Microsoft.VisualBasic;
using System;
using System.Configuration;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace ApiHardWare
{
    public static class Commons
    {
        public static String GetProcessorId()
        {
            //ManagementClass mc = new ManagementClass("win32_processor");
            //ManagementObjectCollection moc = mc.GetInstances();
            //foreach (ManagementObject mo in moc)
            //{
            //    Id = mo.Properties["SerialNumber"].Value.ToString();
            //    break;
            //}
            String Id = String.Empty;
            System.Management.ManagementObjectSearcher moSearcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (System.Management.ManagementObject wmi_HD in moSearcher.Get())
            {
                Id = wmi_HD["SerialNumber"].ToString();
            }
            return Id.Trim();
        }
        public static string GiaiMaDL(string str)
        {
            double dLen = str.Length;
            string sTam = "";
            for (int i = 1; i <= dLen; i++)
                sTam += Strings.ChrW((Strings.AscW(Strings.Mid(str, i, 1)) / 2) - 354).ToString();
            return sTam;
        }

        #region MA HOA

        static string SecurityKey = "vietsoft.com.vn";
        static string chuoi = "_13579_";
        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        /// 
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(chuoi + toEncrypt + chuoi);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                // Get the key from config file
                string key = SecurityKey; /*(string)settingsReader.GetValue("SecurityKey", typeof(String));*/
                //System.Windows.Forms.MessageBox.Show(key);
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch
            {
                byte[] byteData = Encoding.Unicode.GetBytes("");
                return Convert.ToBase64String(byteData);
            }
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                //Get your key from config file to open the lock!
                string key = SecurityKey;//(string)settingsReader.GetValue("SecurityKey", typeof(String));

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(Convert.FromBase64String(cipherString), 0, Convert.FromBase64String(cipherString).Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
            }
            catch(Exception ex)
            {
                byte[] byteData = Encoding.Unicode.GetBytes("");
                //return UTF8Encoding.UTF8.GetString(byteData).Split(new string[] { chuoi }, StringSplitOptions.None)[1];
                return Convert.ToBase64String(byteData);
            }
        }


        #endregion




    }
}