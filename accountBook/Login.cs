using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accountBook
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text ==""&&textBoxPassword.Text == "")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("사용자이름과 암호가 일치하지 않습니다.");
                textBoxPassword.Focus();
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(textBoxName.Text == "" && textBoxPassword.Text == "")
                {
                    DialogResult=DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("사용자의 이름과 암호가 일치하지 않습니다.");
                    textBoxPassword.Focus();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
