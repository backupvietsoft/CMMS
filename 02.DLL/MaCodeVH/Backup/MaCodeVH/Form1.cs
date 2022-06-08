using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaCodeVH
{
    public partial class frmCodeVH : Form
    {
        public frmCodeVH()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMSDX.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã code Đề xuất");
                    txtMSDX.Focus();
                    return;
                }
                try
                {
                    int iMaCode = int.Parse(txtMCode.Text);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập code là số INT");
                    txtMCode.Focus();
                    return;
                }
                if (txtMCode.Text.Length > 4)
                {
                    MessageBox.Show("Vui lòng nhập code 4 số INT");
                    txtMCode.Focus();
                    return;
                }
                string Key;
                Key = txtMSDX.Text;
                Key = ConvertHexToString(Key, System.Text.Encoding.ASCII);
                Key = EncryptOrDecrypt(Key, txtMCode.Text);

                Key = "DX-" + Key.Substring(0, 4) + "-" + Key.Substring(4, Key.Length - 4);

                txtGNen.Text = Key;
            }
            catch (Exception ex)                
            {
                txtGNen.Text = ""; 
                MessageBox.Show(ex.Message.ToString() );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }
        public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }

        private void frmCodeVH_Load(object sender, EventArgs e)
        {
            txtMSDX.Focus();
        }

        private void frmCodeVH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            button2_Click(sender, e);
        }

    
    }
}
