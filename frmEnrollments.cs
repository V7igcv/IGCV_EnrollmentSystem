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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace EDP_WinProject102
{
    public partial class frmEnrollments : Form
    {
        private readonly DBManager dbManager = new DBManager();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmEnrollments()
        {
            InitializeComponent();
            LoadEnrollmentsIntoGrid();
            DatabaseHelper.LoadCoursesIntoComboBox(course);
            student_no.KeyPress += student_no_KeyPress;
            this.Load += frmEnrollments_Load;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void topBar1_Load(object sender, EventArgs e)
        {

        }

        private void frmEnrollments_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }

        private void LoadEnrollmentsIntoGrid()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
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
            using (MySqlConnection conn = dbManager.GetConnection())
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
            using (MySqlConnection conn = dbManager.GetConnection())
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
            using (MySqlConnection conn = dbManager.GetConnection())
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadEnrollmentsIntoGrid();
            }
            else
            {
                SearchEnrollments(txtSearch.Text);
            }
        }

        private void SearchEnrollments(string keyword)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
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
                WHERE 
                    s.deleted_at IS NULL 
                    AND c.deleted_at IS NULL 
                    AND (
                        CAST(e.enrollment_id AS CHAR) LIKE @keyword OR
                        CONCAT(s.student_fname, ' ', s.student_lname) LIKE @keyword OR
                        c.course_name LIKE @keyword OR
                        CAST(e.enrollment_date AS CHAR) LIKE @keyword
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    EnrollmentsTable.DataSource = dt;

                    // Set custom column headers
                    EnrollmentsTable.Columns["enrollment_id"].HeaderText = "Enrollment ID";
                    EnrollmentsTable.Columns["student_name"].HeaderText = "Student Name";
                    EnrollmentsTable.Columns["course_name"].HeaderText = "Course Name";
                    EnrollmentsTable.Columns["enrollment_date"].HeaderText = "Enrollment Date";

                    // Style the headers
                    EnrollmentsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    EnrollmentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            //string templatePath = Path.Combine(Application.StartupPath, "reportTemplate", "enrollments_template.xlsx");
            string templatePath = Path.Combine(Application.StartupPath, "reportTemplate", "enrollments_template.xlsx");
            templatePath = Path.GetFullPath(templatePath);

            if (!File.Exists(templatePath))
            {
                MessageBox.Show($"Template file not found:\n{templatePath}", "Missing Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //string folderPath = Path.Combine(Application.StartupPath, "generatedreports");
            string folderPath = Path.Combine(Application.StartupPath, "generatedreports");
            folderPath = Path.GetFullPath(folderPath);
            Directory.CreateDirectory(folderPath); // Ensure folder exists

            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd-HH-mm-ss");
            string newFileName = $"enrollments-report-{formattedDate}.xlsx";
            string outputPath = Path.Combine(folderPath, newFileName);

            ExportToExcelTemplate(EnrollmentsTable, templatePath, outputPath);
        }

        private void ExportToExcelTemplate(DataGridView dgv, string templatePath, string newFilePath)
        {
            var excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel is not installed!");
                return;
            }

            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                workbook = excelApp.Workbooks.Open(templatePath);
                worksheet = workbook.Worksheets[1];

                int startRow = 3;

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (!dgv.Rows[i].IsNewRow)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            worksheet.Cells[startRow + i, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                        }
                    }
                }

                workbook.SaveAs(newFilePath);

                MessageBox.Show($"Exported successfully to:\n{newFilePath}", "Export Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // OPTIONAL: Open Excel manually if you want
                // System.Diagnostics.Process.Start(newFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during export:\n" + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Clean up properly
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }

                if (worksheet != null)
                    Marshal.ReleaseComObject(worksheet);

                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }

                workbook = null;
                worksheet = null;
                excelApp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
