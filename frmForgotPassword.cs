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
    public partial class frmForgotPassword : Form
    {
        public static string RecoveryEmail;
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            frmLogin myLogin = new frmLogin();
            myLogin.Show();
            this.FindForm().Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            DateTime birthdate = dtpBirthdate.Value.Date;

            DBManager db = new DBManager();

            if (db.VerifyRecoveryInfo(email, birthdate))
            {
                RecoveryEmail = email; // store email to be used later
                frmForgotPassword2 resetForm = new frmForgotPassword2();
                resetForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or birthdate.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
