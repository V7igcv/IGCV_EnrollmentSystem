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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace EDP_WinProject102
{
    public partial class frmGrades : Form
    {
        private readonly DBManager dbManager = new DBManager();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmGrades()
        {
            InitializeComponent();
            LoadGradesIntoGrid();
            this.Load += frmGrades_Load;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmGrades_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }

        private void LoadGradesIntoGrid()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadGradesIntoGrid();
            }
            else
            {
                SearchGrades(txtSearch.Text);
            }
        }

        private void SearchGrades(string keyword)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
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
                WHERE 
                    s.deleted_at IS NULL 
                    AND c.deleted_at IS NULL 
                    AND (
                        CAST(g.grade_id AS CHAR) LIKE @keyword OR
                        CONCAT(s.student_fname, ' ', s.student_lname) LIKE @keyword OR
                        c.course_name LIKE @keyword OR
                        CAST(g.grade AS CHAR) LIKE @keyword OR
                        CAST(g.date_recorded AS CHAR) LIKE @keyword
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

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

                    GradesTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    GradesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string templatePath = Path.Combine(Application.StartupPath, "reportTemplate", "grades_template.xlsx");

            if (!File.Exists(templatePath))
            {
                MessageBox.Show($"Template file not found:\n{templatePath}", "Missing Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string folderPath = Path.Combine(Application.StartupPath, "generatedreports");
            Directory.CreateDirectory(folderPath); // Ensure folder exists

            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd-HH-mm-ss");
            string newFileName = $"grades-report-{formattedDate}.xlsx";
            string outputPath = Path.Combine(folderPath, newFileName);

            ExportToExcelTemplate(GradesTable, templatePath, outputPath);
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
