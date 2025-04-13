using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDP_WinProject102
{
    public partial class frmRegsiter : Form
    {
        public frmRegsiter()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin myLogin = new frmLogin();
            myLogin.Show();
            this.FindForm().Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            frmLogin myLogin = new frmLogin();
            myLogin.Show();
            this.FindForm().Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
