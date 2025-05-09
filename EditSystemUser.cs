using MySql.Data.MySqlClient;
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
    public partial class EditSystemUser : Form
    {
        private readonly DBManager dbManager = new DBManager();

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public EditSystemUser()
        {
            InitializeComponent();
        }

        private void EditSystemUser_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = FirstName;
            txtLastName.Text = LastName;
            txtEmail.Text = Email;
            dtpBirthdate.Value = Birthdate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate fields
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE users 
                                     SET first_name = @FirstName, 
                                         last_name = @LastName, 
                                         email = @Email, 
                                         recovery_birthdate = @Birthdate,
                                         modified_at = NOW() 
                                     WHERE id = @UserId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Birthdate", dtpBirthdate.Value);
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Row updated successfully!");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
