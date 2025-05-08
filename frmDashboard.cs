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
    public partial class frmDashboard: Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            LoadStudentPerCourseIntoGrid();
            LoadInstructorPerDepartmentIntoGrid();
            LoadStudentEnrollmentsIntoGrid();
            LoadSummaryCounts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void topBar1_Load(object sender, EventArgs e)
        {

        }
        private void LoadStudentPerCourseIntoGrid()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT course_name, total_students FROM view_total_students_per_course";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StudentPerCourseTable.DataSource = dt;

                    // Set custom column headers
                    StudentPerCourseTable.Columns["course_name"].HeaderText = "Course Name";
                    StudentPerCourseTable.Columns["total_students"].HeaderText = "Total Students";

                    // Make column headers bold
                    StudentPerCourseTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Fixed height - enable vertical scroll when content exceeds height
                    // StudentPerCourseTable.Height = 400; // Set this to whatever fixed height you prefer
                    StudentPerCourseTable.ScrollBars = ScrollBars.Vertical;
                    StudentPerCourseTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load dashboard data: " + ex.Message);
                }
            }
        }
        private void LoadInstructorPerDepartmentIntoGrid()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT instructor_id, instructor_name, email, phone, department_id FROM view_instructor_departments";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    InstructorPerDepartmentTable.DataSource = dt;

                    // Set custom column headers
                    InstructorPerDepartmentTable.Columns["instructor_id"].HeaderText = "Instructor ID";
                    InstructorPerDepartmentTable.Columns["instructor_name"].HeaderText = "Instructor Name";
                    InstructorPerDepartmentTable.Columns["email"].HeaderText = "Email";
                    InstructorPerDepartmentTable.Columns["phone"].HeaderText = "Phone";
                    InstructorPerDepartmentTable.Columns["department_id"].HeaderText = "Department ID";

                    // Make column headers bold
                    InstructorPerDepartmentTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Scrollbar and column width settings
                    InstructorPerDepartmentTable.ScrollBars = ScrollBars.Vertical;
                    InstructorPerDepartmentTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load instructor data: " + ex.Message);
                }
            }
        }
        private void LoadStudentEnrollmentsIntoGrid()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("GetStudentEnrollments", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StudentsEnrollmentsTable.DataSource = dt;

                    // Set custom column headers
                    StudentsEnrollmentsTable.Columns["student_id"].HeaderText = "Student ID";
                    StudentsEnrollmentsTable.Columns["full_name"].HeaderText = "Full Name";
                    StudentsEnrollmentsTable.Columns["course_name"].HeaderText = "Course Name";
                    StudentsEnrollmentsTable.Columns["enrollment_date"].HeaderText = "Enrollment Date";

                    // Format Enrollment Date
                    StudentsEnrollmentsTable.Columns["enrollment_date"].DefaultCellStyle.Format = "yyyy-MM-dd";

                    // Bold headers and auto fill
                    StudentsEnrollmentsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    StudentsEnrollmentsTable.ScrollBars = ScrollBars.Vertical;
                    StudentsEnrollmentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load student enrollments: " + ex.Message);
                }
            }
        }
        private void LoadSummaryCounts()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Total Enrollments
                    MySqlCommand cmdEnrollments = new MySqlCommand("SELECT TotalEnrollments();", conn);
                    TEnrollments.Text = cmdEnrollments.ExecuteScalar().ToString();

                    // Total Courses
                    MySqlCommand cmdCourses = new MySqlCommand("SELECT TotalCourses();", conn);
                    TCourses.Text = cmdCourses.ExecuteScalar().ToString();

                    // Total Students
                    MySqlCommand cmdStudents = new MySqlCommand("SELECT TotalStudents();", conn);
                    TStudents.Text = cmdStudents.ExecuteScalar().ToString();

                    // Total Instructors
                    MySqlCommand cmdInstructors = new MySqlCommand("SELECT TotalInstructors();", conn);
                    TInstructors.Text = cmdInstructors.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load summary counts: " + ex.Message);
                }
            }
        }

    }
}
