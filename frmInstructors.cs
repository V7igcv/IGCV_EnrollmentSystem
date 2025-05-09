using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;

namespace EDP_WinProject102
{
    public partial class frmInstructors : Form
    {
        private readonly DBManager dbManager = new DBManager();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmInstructors()
        {
            InitializeComponent();
            LoadInstructorsIntoGrid();
            phone.KeyPress += phone_KeyPress;
            DatabaseHelper.LoadDepartmentsIntoComboBox(department);
            this.Load += frmInstructors_Load;
        }

        private void frmInstructors_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }
        private void LoadInstructorsIntoGrid()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
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
                    InstructorsTable.Columns["department_id"].Visible = false;
                    InstructorsTable.Columns["department_name"].HeaderText = "Department";
                    

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
            using (MySqlConnection conn = dbManager.GetConnection())
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
            using (MySqlConnection conn = dbManager.GetConnection())
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadInstructorsIntoGrid();
            }
            else
            {
                SearchInstructors(txtSearch.Text);
            }
        }

        private void SearchInstructors(string keyword)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    i.instructor_id, 
                    i.instructor_fname, 
                    i.instructor_lname, 
                    i.email, 
                    i.phone, 
                    i.department_id, 
                    d.department_name
                FROM instructors i
                JOIN departments d ON i.department_id = d.department_id
                WHERE i.deleted_at IS NULL AND (
                    CAST(i.instructor_id AS CHAR) LIKE @keyword OR
                    i.instructor_fname LIKE @keyword OR
                    i.instructor_lname LIKE @keyword OR
                    i.email LIKE @keyword OR
                    i.phone LIKE @keyword OR
                    d.department_name LIKE @keyword
                )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

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

                    InstructorsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    InstructorsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string templatePath = Path.Combine(Application.StartupPath, "reportTemplate", "instructors_template.xlsx");

            if (!File.Exists(templatePath))
            {
                MessageBox.Show($"Template file not found:\n{templatePath}", "Missing Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string folderPath = Path.Combine(Application.StartupPath, "generatedreports");
            Directory.CreateDirectory(folderPath); // Ensure folder exists

            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd-HH-mm-ss");
            string newFileName = $"instructors-report-{formattedDate}.xlsx";
            string outputPath = Path.Combine(folderPath, newFileName);

            ExportToExcelTemplate(InstructorsTable, templatePath, outputPath);
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
