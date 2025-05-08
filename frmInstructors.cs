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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EDP_WinProject102
{
    public partial class frmInstructors : Form
    {
        public frmInstructors()
        {
            InitializeComponent();
            LoadInstructorsIntoGrid();
            phone.KeyPress += phone_KeyPress;
            DatabaseHelper.LoadDepartmentsIntoComboBox(department);
        }

        private void frmInstructors_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadInstructorsIntoGrid()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT i.instructor_id, i.instructor_fname, i.instructor_lname, i.email, i.phone, i.department_id, d.department_name " +
                                   "FROM instructors i " +
                                   "JOIN departments d ON i.department_id = d.department_id " +
                                   "WHERE i.deleted_at IS NULL";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    InstructorsTable.DataSource = dt;

                    // Set custom column headers
                    InstructorsTable.Columns["instructor_id"].HeaderText = "Instructor ID";
                    InstructorsTable.Columns["instructor_fname"].HeaderText = "First Name";
                    InstructorsTable.Columns["instructor_lname"].HeaderText = "Last Name";
                    InstructorsTable.Columns["email"].HeaderText = "Email";
                    InstructorsTable.Columns["phone"].HeaderText = "Phone Number";
                    InstructorsTable.Columns["department_name"].HeaderText = "Department";
                    InstructorsTable.Columns["department_id"].Visible = false;

                    // Make column headers bold
                    InstructorsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust the DataGridView height based on the number of rows
                    int maxHeight = 600; // You can set this to any value you want
                    int desiredHeight = InstructorsTable.ColumnHeadersHeight +
                        InstructorsTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    // Set the height of the DataGridView (but not beyond maxHeight)
                    InstructorsTable.Height = Math.Min(desiredHeight, maxHeight);

                    // Enable vertical scroll if the content exceeds the max height
                    InstructorsTable.ScrollBars = ScrollBars.Vertical;

                    InstructorsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load data: " + ex.Message);
                }
            }
        }

        private void SubmitInstructor_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(lname.Text) ||
                string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(phone.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            // Validate phone and student number are digits only
            if (!phone.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must contain digits only.");
                return;
            }

            AddInstructorToDatabase();
        }

        private void AddInstructorToDatabase()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                INSERT INTO instructors
                    (instructor_fname, instructor_lname, email, phone, department_id) 
                VALUES 
                    (@FirstName, @LastName, @Email, @Phone, @DepartmentID)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", fname.Text);
                    cmd.Parameters.AddWithValue("@LastName", lname.Text);
                    cmd.Parameters.AddWithValue("@Email", email.Text);
                    cmd.Parameters.AddWithValue("@Phone", phone.Text);
                    cmd.Parameters.AddWithValue("@DepartmentID", department.SelectedValue);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Instructor added successfully!");

                    LoadInstructorsIntoGrid(); // Refresh the grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding instructor: " + ex.Message);
                }
            }
        }
        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void department_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteInstructors_Click(object sender, EventArgs e)
        {
            if (InstructorsTable.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(InstructorsTable.CurrentRow.Cells["instructor_id"].Value);
                    SoftDeleteUser(userId);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void SoftDeleteUser(int userId)
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE instructors SET deleted_at = NOW() WHERE instructor_id = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Row deleted successfully.");
                    LoadInstructorsIntoGrid(); // Refresh the table
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (InstructorsTable.SelectedRows.Count > 0)
            {
                DataGridViewRow row = InstructorsTable.SelectedRows[0];
                int instructorId = Convert.ToInt32(row.Cells["instructor_id"].Value);
                string fname = row.Cells["instructor_fname"].Value.ToString();
                string lname = row.Cells["instructor_lname"].Value.ToString();
                string email = row.Cells["email"].Value.ToString();
                string phone = row.Cells["phone"].Value.ToString();
                int departmentId = Convert.ToInt32(row.Cells["department_id"].Value);

                EditInstructor editForm = new EditInstructor(instructorId, fname, lname, email, phone, departmentId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadInstructorsIntoGrid(); // Reload DataGridView after edit
                }
            }
            else
            {
                MessageBox.Show("Please select an instructor to edit.");
            }
        }
    }
}
