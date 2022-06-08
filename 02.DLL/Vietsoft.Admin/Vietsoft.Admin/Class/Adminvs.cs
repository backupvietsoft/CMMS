using System;
using System.Net;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public static partial class Adminvs
    {
        /// <summary>
        /// Khai báo thành phần toàn cục
        /// </summary>        
        private static int _intLanguage = 0;
        private static string _Username = String.Empty;
        private static DateTime _Fromdate = DateTime.Now;
        private static DateTime _Todate = DateTime.Now;
        private static string _ConnectionString = String.Empty;
        /// <summary>
        /// Chuỗi kết nối
        /// </summary>
        public static string ConnectionString 
        {
            set
            {
                _ConnectionString = value;
            }
            get
            {
                return _ConnectionString;
                //return Vietsoft.Admin.Properties.Resources.ConnectionString;
            }           
        }
        /// <summary>
        /// Ngôn ngữ sử dụng
        /// </summary>
        public static int Language
        {
            get
            {
                return _intLanguage;
            }
            set
            {
                _intLanguage = value;
            }
        }
        /// <summary>
        /// Chuỗi kết nối
        /// </summary>
        public static string IpAddress
        {
            get
            {
                string strHostName = Dns.GetHostName();
                IPHostEntry IpEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] IpAddr = IpEntry.AddressList;
                return IpAddr[0].ToString().Replace (".",String.Empty);
            }
        }
        /// <summary>
        /// User đăng nhập hệ thống
        /// </summary>
        public static string UserName
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }
        /// <summary>
        /// Ngày bắt đầu làm việc
        /// </summary>
        public static DateTime FromDate
        {
            get
            {
                return _Fromdate;
            }
            set
            {
                _Fromdate = value;
            }
        }
        /// <summary>
        /// Ngày kết thúc làm việc
        /// </summary>
        public static DateTime ToDate
        {
            get
            {
                return _Todate;
            }
            set
            {
                _Todate = value;
            }
        }
        /// <summary>
        /// Định dạng ngày tháng

       
       
    }
}
