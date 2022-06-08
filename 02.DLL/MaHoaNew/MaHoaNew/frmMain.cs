using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MaHoaNew
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtClearText.Text == "")
            {
                error.SetError(txtClearText, "Enter the text you want to encrypt");
            }
            else
            {
                error.Clear();
                string clearText = txtClearText.Text.Trim();
                string cipherText = CryptorEngine.Encrypt(clearText, true);             
                txtCipherText.Text = cipherText;
        
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string cipherText = txtCipherText.Text.Trim();
            string decryptedText = CryptorEngine.Decrypt(cipherText, true);
            txtDecryptedText.Text = decryptedText;
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}