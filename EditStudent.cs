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
    public partial class EditStudent : Form
    {
        private int studentId;
        public EditStudent(int studentId, string firstName, string lastName, int age, string email, string phone, string address, string studentNumber)
        {
            InitializeComponent();
            this.studentId = studentId;
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtAge.Text = age.ToString();
            txtEmail.Text = email;
            txtPhone.Text = phone;
            txtAddress.Text = address;
            txtStudentNumber.Text = studentNumber;
        }

        private void EditStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string checkQuery = @"SELECT COUNT(*) FROM students 
                                  WHERE student_number = @StudentNumber 
                                  AND student_id != @StudentId";

                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@StudentNumber", txtStudentNumber.Text);
                        checkCmd.Parameters.AddWithValue("@StudentId", studentId);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("The student number already exists. Please use a different student number.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = @"UPDATE students 
                                     SET student_fname = @FirstName, 
                                         student_lname = @LastName, 
                                         age = @Age,
                                         email = @Email, 
                                         phone = @Phone, 
                                         address = @Address, 
                                         student_number = @StudentNumber, 
                                         modified_at = NOW()
                                     WHERE student_id = @StudentId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@StudentNumber", txtStudentNumber.Text);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student updated successfully!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while updating student: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
