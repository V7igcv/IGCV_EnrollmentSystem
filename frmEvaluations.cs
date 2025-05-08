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
    public partial class frmEvaluations : Form
    {
        public frmEvaluations()
        {
            InitializeComponent();
            LoadEvaluationsIntoGrid();
        }

        private void frmEvaluations_Load(object sender, EventArgs e)
        {

        }

        private void LoadEvaluationsIntoGrid()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    e.evaluation_id, 
                    CONCAT(s.student_fname, ' ', s.student_lname) AS student_name, 
                    CONCAT(i.instructor_fname, ' ', i.instructor_lname) AS instructor_name, 
                    c.course_name, 
                    e.rating, 
                    e.comments, 
                    e.evaluation_date
                FROM evaluations e
                JOIN students s ON e.student_id = s.student_id
                JOIN instructors i ON e.instructor_id = i.instructor_id
                JOIN courses c ON e.course_id = c.course_id
                WHERE e.deleted_at IS NULL";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    EvaluationsTable.DataSource = dt;

                    // Set custom column headers
                    EvaluationsTable.Columns["evaluation_id"].HeaderText = "Evaluation ID";
                    EvaluationsTable.Columns["student_name"].HeaderText = "Student Name";
                    EvaluationsTable.Columns["instructor_name"].HeaderText = "Instructor Name";
                    EvaluationsTable.Columns["course_name"].HeaderText = "Course Name";
                    EvaluationsTable.Columns["rating"].HeaderText = "Rating";
                    EvaluationsTable.Columns["comments"].HeaderText = "Comments";
                    EvaluationsTable.Columns["evaluation_date"].HeaderText = "Evaluation Date";

                    // Make column headers bold
                    EvaluationsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust DataGridView height
                    int maxHeight = 900;
                    int desiredHeight = EvaluationsTable.ColumnHeadersHeight +
                        EvaluationsTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    EvaluationsTable.Height = Math.Min(desiredHeight, maxHeight);
                    EvaluationsTable.ScrollBars = ScrollBars.Vertical;
                    EvaluationsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load evaluation data: " + ex.Message);
                }
            }
        }
    }
}
