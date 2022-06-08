using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vietsoft
{
    public partial class FormBase : Form
    {
        /// <summary>
        /// Khái báo chung
        /// </summary>
        private BindingSource _BindingSource = new BindingSource();
        private string _CurrentState = String.Empty;
        public event EventHandler CurrentStateChanged;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public FormBase()
        {
            InitializeComponent();            
        }
        /// <summary>
        /// Nguồn dữ liệu
        /// </summary>
        public BindingSource BindingSource
        {
            get
            {
                return _BindingSource;
            }
            set
            {
                _BindingSource = value;
            }
        }
        /// <summary>
        /// Trạng thái hiện thời
        /// </summary>
        public string CurrentState
        {
            get
            {
                return _CurrentState;
            }
            set
            {
                if (value != _CurrentState)
                {
                    _CurrentState = value;
                    OnCurrentStateChanged(EventArgs.Empty);
                }                 
            }
        }
        /// <summary>
        /// Thay đổi trạng thái
        /// </summary>
        protected virtual void OnCurrentStateChanged(EventArgs e)
        {
            if (CurrentStateChanged != null)
            {
                CurrentStateChanged(this, e);
            }
        } 


    }
}