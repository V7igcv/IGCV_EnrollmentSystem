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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EDP_WinProject102
{
    public partial class frmEnrollments : Form
    {
        public frmEnrollments()
        {
            InitializeComponent();
            LoadEnrollmentsIntoGrid();
            DatabaseHelper.LoadCoursesIntoComboBox(course);
            student_no.KeyPress += student_no_KeyPress;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void topBar1_Load(object sender, EventArgs e)
        {

        }

        private void frmEnrollments_Load(object sender, EventArgs e)
        {

        }

        private void LoadEnrollmentsIntoGrid()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    e.enrollment_id,
                    CONCAT(s.student_fname, ' ', s.student_lname) AS student_name,
                    c.course_name,
                    e.enrollment_date
                FROM enrollments e
                JOIN students s ON e.student_id = s.student_id
                JOIN courses c ON e.course_id = c.course_id
                WHERE s.deleted_at IS NULL AND c.deleted_at IS NULL";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    EnrollmentsTable.DataSource = dt;

                    // Set custom column headers
                    EnrollmentsTable.Columns["enrollment_id"].HeaderText = "Enrollment ID";
                    EnrollmentsTable.Columns["student_name"].HeaderText = "Student Name";
                    EnrollmentsTable.Columns["course_name"].HeaderText = "Course Name";
                    EnrollmentsTable.Columns["enrollment_date"].HeaderText = "Enrollment Date";

                    // Make column headers bold
                    EnrollmentsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust the DataGridView height based on the number of rows
                    int maxHeight = 600;
                    int desiredHeight = EnrollmentsTable.ColumnHeadersHeight +
                        EnrollmentsTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    EnrollmentsTable.Height = Math.Min(desiredHeight, maxHeight);
                    EnrollmentsTable.ScrollBars = ScrollBars.Vertical;
                    EnrollmentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load enrollment data: " + ex.Message);
                }
            }
        }

        private void AddEnrollmentToDatabase()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Get the student_id from the student_number
                    string getStudentIdQuery = "SELECT student_id FROM students WHERE student_number = @StudentNumber AND deleted_at IS NULL";
                    MySqlCommand getIdCmd = new MySqlCommand(getStudentIdQuery, conn);
                    getIdCmd.Parameters.AddWithValue("@StudentNumber", student_no.Text);

                    object result = getIdCmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Student number not found.");
                        return;
                    }

                    int studentId = Convert.ToInt32(result);

                    // Now insert into enrollments
                    string insertQuery = @"
                INSERT INTO enrollments
                    (student_id, course_id, enrollment_date) 
                VALUES 
                    (@StudentId, @CourseID, @EnrollmentDate)";

                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@StudentId", studentId);
                    insertCmd.Parameters.AddWithValue("@CourseID", course.SelectedValue);
                    insertCmd.Parameters.AddWithValue("@EnrollmentDate", date.Value); // date is your DateTimePicker

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Enrollment added successfully!");

                    LoadEnrollmentsIntoGrid(); // Refresh the grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding enrollment: " + ex.Message);
                }
            }
        }

        private void SubmitEnrollment_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(student_no.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            if (!StudentNumberExists(student_no.Text))
            {
                MessageBox.Show("Student number not found in the database.");
                return;
            }

            AddEnrollmentToDatabase();
        }

        private void student_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private bool StudentNumberExists(string studentNumber)
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM students WHERE student_number = @StudentNumber AND deleted_at IS NULL";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error validating student number: " + ex.Message);
                    return false;
                }
            }
        }

        private void btnDeleteEnrollment_Click(object sender, EventArgs e)
        {
            if (EnrollmentsTable.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(EnrollmentsTable.CurrentRow.Cells["enrollment_id"].Value);
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
                    string query = "UPDATE enrollments SET deleted_at = NOW() WHERE enrollment_id = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Row deleted successfully.");
                    LoadEnrollmentsIntoGrid(); // Refresh the table
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting: " + ex.Message);
                }
            }
        }
    }
}
