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
    public partial class EditInstructor : Form
    {
        private int instructorId;
        public EditInstructor(int instructorId, string firstName, string lastName, string email, string phone, int departmentId)
        {
            InitializeComponent();
            this.instructorId = instructorId;

            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtEmail.Text = email;
            txtPhone.Text = phone;

            DatabaseHelper.LoadDepartmentsIntoComboBox(cmbDepartment);
            cmbDepartment.SelectedValue = departmentId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE instructors 
                                     SET instructor_fname = @FirstName, 
                                         instructor_lname = @LastName, 
                                         email = @Email, 
                                         phone = @Phone, 
                                         department_id = @DepartmentId, 
                                         modified_at = NOW()
                                     WHERE instructor_id = @InstructorId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@DepartmentId", cmbDepartment.SelectedValue);
                    cmd.Parameters.AddWithValue("@InstructorId", instructorId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Instructor updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating instructor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
