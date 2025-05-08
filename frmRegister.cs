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
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtConfirmPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            DateTime birthdate = dtpBirthdate.Value;

            DBManager db = new DBManager();

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (db.EmailExists(email))
            {
                MessageBox.Show("Email already registered.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db.RegisterUser(firstName, lastName, email, password, birthdate);
            MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmLogin myLogin = new frmLogin();
            myLogin.Show();
            this.Close();
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

        private void frmRegsiter_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
