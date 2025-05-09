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
using System.Runtime.InteropServices;

namespace EDP_WinProject102
{
    public partial class frmCourses : Form
    {
        private readonly DBManager dbManager = new DBManager();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        public frmCourses()
        {
            InitializeComponent();
            LoadCoursesIntoGrid();
            DatabaseHelper.LoadDepartmentsIntoComboBox(department);
            this.Load += frmCourses_Load;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        private void frmCourses_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }

        private void LoadCoursesIntoGrid()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Define the stored procedure to fetch course details
                    string query = "CALL GetCourseDetails()"; // Change the argument here as needed
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Create a data adapter and fill a data table with the result
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Set the DataGridView's data source to the data table
                    CoursesTable.DataSource = dt;

                    // Set custom column headers (if needed)
                    CoursesTable.Columns["course_id"].HeaderText = "Course ID";
                    CoursesTable.Columns["course_name"].HeaderText = "Course Name";
                    CoursesTable.Columns["department_id"].HeaderText = "Department ID";

                    // Make column headers bold
                    CoursesTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Auto size columns to fit data
                    CoursesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    // Show an error message if something goes wrong
                    MessageBox.Show("Failed to load data: " + ex.Message);
                }
            }
        }

        private void AddCourseToDatabase()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                INSERT INTO courses
                    (course_name, department_id) 
                VALUES 
                    (@CourseName, @DepartmentID)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseName", course.Text);
                    cmd.Parameters.AddWithValue("@DepartmentID", department.SelectedValue);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course added successfully!");

                    LoadCoursesIntoGrid(); // Refresh the grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding course: " + ex.Message);
                }
            }
        }

        private void SubmitCourse_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(course.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            AddCourseToDatabase();
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (CoursesTable.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(CoursesTable.CurrentRow.Cells["course_id"].Value);
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
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE courses SET deleted_at = NOW() WHERE course_id = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Row deleted successfully.");
                    LoadCoursesIntoGrid(); // Refresh the table
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting: " + ex.Message);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadCoursesIntoGrid();
            }
            else
            {
                SearchCourses(txtSearch.Text);
            }
        }

        private void SearchCourses(string keyword)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    course_id, 
                    course_name, 
                    department_id 
                FROM 
                    courses 
                WHERE 
                    deleted_at IS NULL AND (
                        CAST(course_id AS CHAR) LIKE @keyword
                        OR course_name LIKE @keyword
                        OR CAST(department_id AS CHAR) LIKE @keyword
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    CoursesTable.DataSource = dt;

                    // Set custom column headers
                    CoursesTable.Columns["course_id"].HeaderText = "Course ID";
                    CoursesTable.Columns["course_name"].HeaderText = "Course Name";
                    CoursesTable.Columns["department_id"].HeaderText = "Department ID";

                    // Style the headers
                    CoursesTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    CoursesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }
    }
}
