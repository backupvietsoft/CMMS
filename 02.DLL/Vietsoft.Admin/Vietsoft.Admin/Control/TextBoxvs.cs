using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Vietsoft.Admin
{
    public partial class TextBoxvs :MaskedTextBox
    {
        /// <summary>
        /// Khai báo thành phần dùng chung
        /// </summary>
        private int _intTypevalue = 6;
        private int _intLength = 32700;
        private string _strFormatvalue = string.Empty;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public TextBoxvs()
        {
            switch (_intTypevalue)
            {                    
                case 0:
                case 1:
                    try
                    {
                        this.Text = double.Parse(this.Text.Trim()).ToString();
                        this.Text = int.Parse(this.Text.Trim()).ToString(_strFormatvalue);
                    }
                    catch
                    {
                        this.Text = string.Empty;
                    }
                    break;
                case 2:
                case 3:
                    try
                    {
                        this.Text = double.Parse(this.Text.Trim()).ToString(_strFormatvalue);
                    }
                    catch
                    {
                        this.Text = string.Empty;
                    }
                    break;
                case 4:
                    try
                    {
                        this.Text = DateTime.ParseExact(this.Text.Trim(), _strFormatvalue, System.Globalization.CultureInfo.CurrentCulture).ToString();
                    }
                    catch
                    {
                        this.Text = string.Empty;
                    }
                    break;
                case 5:
                    try
                    {
                        this.Text = DateTime.Now.ToString(_strFormatvalue);                        
                    }
                    catch
                    {
                        this.Text = DateTime.Now.ToString(_strFormatvalue);
                    }
                    break;
            }
        }
        /// <summary>
        /// 0 - Là số nguyên dương
        /// 1 - Là số nguyên cho phép số âm
        /// 2 - Là số thực dương 
        /// 3 - Là số thực cho phép số âm
        /// 4 - Là datetime không lấy mặc định ngày hiện tại
        /// 5 - Là datetime lấy mặc định ngày hiện tại
        /// 6 - Là text
        /// </summary>        
        public int TypeValue
        {
            get
            {
                return _intTypevalue;
            }
            set
            {
                if (value >= 0 && value <= 6)
                {
                    _intTypevalue = value;
                }
                else
                {
                    _intTypevalue = 0;
                }
                switch (_intTypevalue)
                {
                    case 0:
                    case 1:
                        try
                        {
                            this.Text = double.Parse(this.Text.Trim()).ToString();
                            this.Text = int.Parse(this.Text.Trim()).ToString(_strFormatvalue);
                        }
                        catch
                        {
                            this.Text = string.Empty;
                        }
                        break;
                    case 2:
                    case 3:
                        try
                        {
                            this.Text = double.Parse(this.Text.Trim()).ToString(_strFormatvalue);
                        }
                        catch
                        {
                            this.Text = string.Empty;
                        }
                        break;
                    case 4:
                        try
                        {
                            this.Text = DateTime.ParseExact(this.Text.Trim(), _strFormatvalue, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        }
                        catch
                        {
                            this.Text = string.Empty;
                        }
                        break;
                    case 5:
                        try
                        {
                            this.Text = DateTime.Now.ToString(_strFormatvalue);
                        }
                        catch
                        {
                            this.Text = DateTime.Now.ToString(_strFormatvalue);
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Chiều dài dữ liệu tối đa
        /// </summary>        
        public int Length
        {
            get
            {                
                return _intLength;
            }
            set
            {
                _intLength = value;
            }
        }
        /// <summary>
        /// Định dạng dữ liệu
        /// </summary>
        public string FormatValue
        {
            get
            {
                return _strFormatvalue;
            }
            set
            {
                _strFormatvalue = value;
                switch (_intTypevalue)
                {
                    case 0:
                    case 1:
                        try
                        {
                            this.Text = double.Parse(this.Text.Trim()).ToString();
                            this.Text = int.Parse(this.Text.Trim()).ToString(_strFormatvalue);
                        }
                        catch
                        {
                            this.Text = string.Empty;
                        }
                        break;
                    case 2:
                    case 3:
                        try
                        {
                            this.Text = double.Parse(this.Text.Trim()).ToString(_strFormatvalue);
                        }
                        catch
                        {
                            this.Text = string.Empty;
                        }
                        break;
                    case 4:
                        try
                        {
                            this.Text = DateTime.ParseExact(this.Text.Trim(), _strFormatvalue, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        }
                        catch
                        {
                            this.Text = string.Empty;
                        }
                        break;
                    case 5:
                        try
                        {
                            this.Text = DateTime.ParseExact(this.Text.Trim(), _strFormatvalue, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        }
                        catch
                        {
                            this.Text = DateTime.Now.ToString(_strFormatvalue);
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// KeyPress
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (this.Text.Length >= _intLength && !Char.IsControl(e.KeyChar) && this.SelectionLength != this.Text.Length)
            {
                e.Handled = true;
                return;
            }
            string strDecimal = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            char charDecimal = Convert.ToChar(strDecimal);
            char charNegative = '-';
            switch (TypeValue)
            {

                case 1:
                    if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                    {
                        if (Char.IsDigit(e.KeyChar) && this.Text.IndexOf(charNegative) != -1 && this.SelectionStart == 0)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (e.KeyChar == charNegative &&
                    this.Text.IndexOf(charNegative) == -1 && this.SelectionStart == 0) { }
                    else
                    {
                        e.Handled = true;
                    }
                    break;
                case 2:
                    if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) { }
                    else if (e.KeyChar == charDecimal &&
                    this.Text.IndexOf(charDecimal) == -1) { }
                    else
                    {
                        e.Handled = true;
                    }
                    break;
                case 3:
                    if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                    {
                        if (Char.IsDigit(e.KeyChar) && this.Text.IndexOf(charNegative) != -1 && this.SelectionStart == 0)
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (e.KeyChar == charDecimal && this.Text.IndexOf(charDecimal) == -1)
                        {
                            if (this.Text.IndexOf(charNegative) != -1 && this.SelectionStart == 0)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (e.KeyChar == charNegative && this.Text.IndexOf(charNegative) == -1 && this.SelectionStart == 0)
                            {
                            }
                            else
                            {
                                e.Handled = true;
                            }
                        }
                    }
                    break;
                case 0:
                case 4:
                case 5:
                    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }
        /// <summary>
        /// KeyPress
        /// </summary>
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            switch (_intTypevalue)
            {
                case 0:
                case 1:
                    try
                    {
                        this.Text = double.Parse(this.Text.Trim()).ToString();
                        this.Text = int.Parse(this.Text.Trim()).ToString(_strFormatvalue);
                    }
                    catch
                    {
                        this.Text = string.Empty;
                    }
                    break;
                case 2:
                case 3:
                    try
                    {
                        this.Text = double.Parse(this.Text.Trim()).ToString(_strFormatvalue);
                    }
                    catch
                    {
                        this.Text = string.Empty;
                    }
                    break;
                case 4:
                    try
                    {
                        this.Text = DateTime.ParseExact(this.Text.Trim(), _strFormatvalue, System.Globalization.CultureInfo.CurrentCulture).ToString();
                    }
                    catch
                    {
                        this.Text = string.Empty;
                    }
                    break;
                case 5:
                    try
                    {
                        this.Text = DateTime.ParseExact(this.Text.Trim(), _strFormatvalue, System.Globalization.CultureInfo.CurrentCulture).ToString();
                    }
                    catch
                    {
                        this.Text = String.Empty;
                    }
                    break;
            }
        }
        /// <summary>
        /// OnEnter
        /// </summary>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (_intTypevalue == 5)
            {
                try
                {
                    this.Text = DateTime.ParseExact(this.Text.Trim(), _strFormatvalue, System.Globalization.CultureInfo.CurrentCulture).ToString();
                }
                catch
                {
                    this.Text = DateTime.Now.ToString(_strFormatvalue);
                }
            }
        }
    }
}
