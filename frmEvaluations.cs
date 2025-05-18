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
    public partial class frmEvaluations : Form
    {
        private readonly DBManager dbManager = new DBManager();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        public frmEvaluations()
        {
            InitializeComponent();
            LoadEvaluationsIntoGrid();
            this.Load += frmEvaluations_Load;
        }

        private void frmEvaluations_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }

        private void LoadEvaluationsIntoGrid()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadEvaluationsIntoGrid();
            }
            else
            {
                SearchEvaluations(txtSearch.Text);
            }
        }

        private void SearchEvaluations(string keyword)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
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
                WHERE e.deleted_at IS NULL AND (
                    CONCAT(s.student_fname, ' ', s.student_lname) LIKE @keyword OR
                    CONCAT(i.instructor_fname, ' ', i.instructor_lname) LIKE @keyword OR
                    c.course_name LIKE @keyword OR
                    e.comments LIKE @keyword OR
                    CAST(e.rating AS CHAR) LIKE @keyword
                )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    EvaluationsTable.DataSource = dt;

                    // Set custom column headers again (in case search is called first)
                    EvaluationsTable.Columns["evaluation_id"].HeaderText = "Evaluation ID";
                    EvaluationsTable.Columns["student_name"].HeaderText = "Student Name";
                    EvaluationsTable.Columns["instructor_name"].HeaderText = "Instructor Name";
                    EvaluationsTable.Columns["course_name"].HeaderText = "Course Name";
                    EvaluationsTable.Columns["rating"].HeaderText = "Rating";
                    EvaluationsTable.Columns["comments"].HeaderText = "Comments";
                    EvaluationsTable.Columns["evaluation_date"].HeaderText = "Evaluation Date";

                    EvaluationsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    EvaluationsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            //string templatePath = Path.Combine(Application.StartupPath, "reportTemplate", "evaluations_template.xlsx");
            string templatePath = Path.Combine(Application.StartupPath, "reportTemplate", "evaluations_template.xlsx");
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
            string newFileName = $"evaluations-report-{formattedDate}.xlsx";
            string outputPath = Path.Combine(folderPath, newFileName);

            ExportToExcelTemplate(EvaluationsTable, templatePath, outputPath);
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
