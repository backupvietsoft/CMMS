using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vietsoft
{
    public partial class MnSystem : FormBase
    {
        public MnSystem()
        {
            InitializeComponent();
            
        }

        private void MnSystem_Load(object sender, EventArgs e)
        {
            this.CurrentStateChanged += new EventHandler(MnSystem_CurrentStateChanged);
            this.CurrentState = "1222";
        }

        void MnSystem_CurrentStateChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.CurrentState);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.CurrentState = "ABC";
        }
    }
}