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
    public partial class frmGrades : Form
    {
        public frmGrades()
        {
            InitializeComponent();
            LoadGradesIntoGrid();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmGrades_Load(object sender, EventArgs e)
        {

        }

        private void LoadGradesIntoGrid()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    g.grade_id,
                    CONCAT(s.student_fname, ' ', s.student_lname) AS student_name,
                    c.course_name,
                    g.grade,
                    g.date_recorded
                FROM grades g
                JOIN enrollments e ON g.enrollment_id = e.enrollment_id
                JOIN students s ON e.student_id = s.student_id
                JOIN courses c ON e.course_id = c.course_id
                WHERE s.deleted_at IS NULL AND c.deleted_at IS NULL";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GradesTable.DataSource = dt;

                    // Set custom column headers
                    GradesTable.Columns["grade_id"].HeaderText = "Grade ID";
                    GradesTable.Columns["student_name"].HeaderText = "Student Name";
                    GradesTable.Columns["course_name"].HeaderText = "Course Name";
                    GradesTable.Columns["grade"].HeaderText = "Grade";
                    GradesTable.Columns["date_recorded"].HeaderText = "Date Recorded";

                    // Make column headers bold
                    GradesTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust DataGridView height
                    int maxHeight = 900;
                    int desiredHeight = GradesTable.ColumnHeadersHeight +
                        GradesTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    GradesTable.Height = Math.Min(desiredHeight, maxHeight);
                    GradesTable.ScrollBars = ScrollBars.Vertical;
                    GradesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load grades: " + ex.Message);
                }
            }
        }
    }
}
