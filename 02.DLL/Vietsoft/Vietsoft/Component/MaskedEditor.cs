using System;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vietsoft
{
    public partial class MaskedEditor :MaskedTextBox
    {
        /// <summary>
        /// Declare public
        /// </summary>
        private int _DataType = 6;
        private int _MaxLength = 32700;
        private string _StringFormat = string.Empty;

        const int WM_NCPAINT = 0x85;
        const uint RDW_INVALIDATE = 0x1;
        const uint RDW_IUPDATENOW = 0x100;
        const uint RDW_FRAME = 0x400;
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
        Color borderColor = ColorTranslator.FromHtml("#ABC1DE");
  
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
                    RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT && BorderColor != Color.Transparent &&
                BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
            {
                var hdc = GetWindowDC(this.Handle);
                using (var g = Graphics.FromHdcInternal(hdc))
                using (var p = new Pen(BorderColor))
                    g.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
                ReleaseDC(this.Handle, hdc);
            }
        }



        /// <summary>
        /// Declare function
        /// </summary>
        public MaskedEditor()
        {           
        }
        /// <summary>
        /// DataType 0 Int , 1 -Int,2 Double , 3 -Double, 4 Datetime None , 5 Datetime Now , 6 String  
        /// </summary>        
        public int DataType
        {
            get
            {
                return _DataType;
            }
            set
            {
                if (value >= 0 && value <= 6)
                {
                    _DataType = value;
                }
                else
                {
                    _DataType = 6;
                }
                switch (_DataType)
                {
                    case 0:
                    case 1:
                        try
                        {
                            this.Text = double.Parse(this.Text.Trim()).ToString();
                            this.Text = int.Parse(this.Text.Trim()).ToString(_StringFormat);
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
                            this.Text = double.Parse(this.Text.Trim()).ToString(_StringFormat);
                        }
                        catch
                        {
                            this.Text = string.Empty;
                        }
                        break;
                    case 4:
                    case 5:
                        try
                        {
                            this.Text = DateTime.ParseExact(this.Text.Trim(), _StringFormat, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        }
                        catch
                        {
                            this.Text = string.Empty;
                        }
                        break;                                           
                }
            }
        }
        /// <summary>
        /// MaxLength
        /// </summary>           
        public int CharLength
        {
            get
            {
                return _MaxLength;
            }
            set
            {
                _MaxLength = value;                
            }
        }
        /// <summary>
        /// StringFormat
        /// </summary>
        public string StringFormat
        {
            get
            {
                return _StringFormat;
            }
            set
            {
                _StringFormat = value;
                switch (_DataType)
                {
                    case 0:
                    case 1:
                        try
                        {
                            this.Text = double.Parse(this.Text.Trim()).ToString();
                            this.Text = int.Parse(this.Text.Trim()).ToString(_StringFormat);
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
                            this.Text = double.Parse(this.Text.Trim()).ToString(_StringFormat);
                        }
                        catch
                        {
                            this.Text = string.Empty;
                        }
                        break;
                    case 4:
                    case 5:
                        try
                        {
                            this.Text = DateTime.ParseExact(this.Text.Trim(), _StringFormat, System.Globalization.CultureInfo.CurrentCulture).ToString();
                        }
                        catch
                        {
                            this.Text = string.Empty;
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
            if (this.Text.Length >= _MaxLength && !Char.IsControl(e.KeyChar) && this.SelectionLength != this.Text.Length)
            {
                e.Handled = true;
                return;
            }
            string strDecimal = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            char charDecimal = Convert.ToChar(strDecimal);
            char charNegative = '-';
            switch (_DataType)
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
        /// OnValidated
        /// </summary>
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            switch (_DataType)
            {
                case 0:
                case 1:
                    try
                    {
                        this.Text = double.Parse(this.Text.Trim()).ToString();
                        this.Text = int.Parse(this.Text.Trim()).ToString(_StringFormat);
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
                        this.Text = double.Parse(this.Text.Trim()).ToString(_StringFormat);
                    }
                    catch
                    {
                        this.Text = string.Empty;
                    }
                    break;
                case 4:
                case 5:
                    try
                    {
                        this.Text = DateTime.ParseExact(this.Text.Trim(), _StringFormat, System.Globalization.CultureInfo.CurrentCulture).ToString();
                    }
                    catch
                    {
                        this.Text = string.Empty;
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
            if (_DataType == 5)
            {
                try
                {
                    this.Text = DateTime.ParseExact(this.Text.Trim(), _StringFormat, System.Globalization.CultureInfo.CurrentCulture).ToString();
                }
                catch
                {
                    this.Text = DateTime.Now.ToString(_StringFormat);
                }
            }
        }       
    }
}
