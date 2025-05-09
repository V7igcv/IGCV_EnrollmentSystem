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
    public partial class frmTuitions : Form
    {
        private readonly DBManager dbManager = new DBManager();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmTuitions()
        {
            InitializeComponent();
            LoadTuitionsIntoGrid();
            DatabaseHelper.LoadCoursesIntoComboBox(course);
            amount.KeyPress += amount_KeyPress;
            this.Load += frmTuitions_Load;

        }

        private void frmTuitions_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }

        private void LoadTuitionsIntoGrid()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    tf.fee_id,
                    c.course_id,
                    c.course_name,
                    tf.amount,
                    tf.academic_year
                FROM tuition_fees tf
                JOIN courses c ON tf.course_id = c.course_id
                WHERE c.deleted_at IS NULL";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    TuitionsTable.DataSource = dt;

                    // Set custom column headers
                    TuitionsTable.Columns["fee_id"].HeaderText = "Fee ID";
                    TuitionsTable.Columns["course_name"].HeaderText = "Course Name";
                    TuitionsTable.Columns["amount"].HeaderText = "Tuition Fee (₱)";
                    TuitionsTable.Columns["academic_year"].HeaderText = "Academic Year";
                    TuitionsTable.Columns["course_id"].Visible = false;

                    // Make column headers bold
                    TuitionsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust DataGridView height
                    int maxHeight = 600;
                    int desiredHeight = TuitionsTable.ColumnHeadersHeight +
                        TuitionsTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    TuitionsTable.Height = Math.Min(desiredHeight, maxHeight);
                    TuitionsTable.ScrollBars = ScrollBars.Vertical;
                    TuitionsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load tuition fees: " + ex.Message);
                }
            }
        }

        private void AddTuitionToDatabase()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                INSERT INTO tuition_fees 
                    (course_id, amount, academic_year) 
                VALUES 
                    (@Course, @Amount, @Year)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Course", course.SelectedValue);
                    cmd.Parameters.AddWithValue("@Amount", amount.Text);
                    cmd.Parameters.AddWithValue("@Year", year.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tuition Fee added successfully!");

                    LoadTuitionsIntoGrid(); // Refresh the grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding tuition fee: " + ex.Message);
                }
            }
        }

        private void SubmitTuition_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(amount.Text) || string.IsNullOrWhiteSpace(year.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            AddTuitionToDatabase();
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, control keys (like backspace), and one dot
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnDeleteTuition_Click(object sender, EventArgs e)
        {
            if (TuitionsTable.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(TuitionsTable.CurrentRow.Cells["fee_id"].Value);
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
                    string query = "UPDATE tuition_fees SET deleted_at = NOW() WHERE fee_id = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Row deleted successfully.");
                    LoadTuitionsIntoGrid(); // Refresh the table
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (TuitionsTable.SelectedRows.Count > 0)
            {
                DataGridViewRow row = TuitionsTable.SelectedRows[0];
                int feeId = Convert.ToInt32(row.Cells["fee_id"].Value);
                int courseId = Convert.ToInt32(row.Cells["course_id"].Value);
                decimal amount = Convert.ToDecimal(row.Cells["amount"].Value);
                string academicYear = row.Cells["academic_year"].Value.ToString();

                EditTuition editForm = new EditTuition(feeId, courseId, amount, academicYear);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTuitionsIntoGrid(); // Reload grid after saving
                }
            }
            else
            {
                MessageBox.Show("Please select a tuition fee entry to edit.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadTuitionsIntoGrid();
            }
            else
            {
                SearchTuitions(txtSearch.Text);
            }
        }

        private void SearchTuitions(string keyword)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    tf.fee_id,
                    c.course_id,
                    c.course_name,
                    tf.amount,
                    tf.academic_year
                FROM tuition_fees tf
                JOIN courses c ON tf.course_id = c.course_id
                WHERE 
                    c.deleted_at IS NULL AND (
                        CAST(tf.fee_id AS CHAR) LIKE @keyword OR
                        c.course_name LIKE @keyword OR
                        CAST(tf.amount AS CHAR) LIKE @keyword OR
                        tf.academic_year LIKE @keyword
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    TuitionsTable.DataSource = dt;

                    // Set custom column headers
                    TuitionsTable.Columns["fee_id"].HeaderText = "Fee ID";
                    TuitionsTable.Columns["course_name"].HeaderText = "Course Name";
                    TuitionsTable.Columns["amount"].HeaderText = "Tuition Fee (₱)";
                    TuitionsTable.Columns["academic_year"].HeaderText = "Academic Year";
                    TuitionsTable.Columns["course_id"].Visible = false;

                    TuitionsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    TuitionsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string templatePath = Path.Combine(Application.StartupPath, "reportTemplate", "tuition_template.xlsx");

            if (!File.Exists(templatePath))
            {
                MessageBox.Show($"Template file not found:\n{templatePath}", "Missing Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string folderPath = Path.Combine(Application.StartupPath, "generatedreports");
            Directory.CreateDirectory(folderPath); // Ensure folder exists

            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd-HH-mm-ss");
            string newFileName = $"tuition-report-{formattedDate}.xlsx";
            string outputPath = Path.Combine(folderPath, newFileName);

            ExportToExcelTemplate(TuitionsTable, templatePath, outputPath);

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
