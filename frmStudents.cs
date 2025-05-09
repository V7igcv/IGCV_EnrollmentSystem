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
    public partial class frmStudents : Form
    {
        private readonly DBManager dbManager = new DBManager();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        public frmStudents()
        {
            InitializeComponent();
            LoadStudentsIntoGrid();
            this.Load += frmStudents_Load;

            // Attach the KeyPress event handlers
            phone.KeyPress += phone_KeyPress;
            student_no.KeyPress += student_no_KeyPress;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(lname.Text) ||
                string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(phone.Text) ||
                string.IsNullOrWhiteSpace(address.Text) || string.IsNullOrWhiteSpace(student_no.Text))
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

            if (!student_no.Text.All(char.IsDigit))
            {
                MessageBox.Show("Student number must contain digits only.");
                return;
            }

            AddStudentToDatabase();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmStudents_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }
        private void LoadStudentsIntoGrid()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            student_id, 
                            student_fname, 
                            student_lname, 
                            age, 
                            email, 
                            phone, 
                            address, 
                            student_number,
                            GetTotalTuition(student_id) AS total_tuition,
                            GetOutstandingBalance(student_id) AS outstanding_balance
                        FROM 
                            students
                        WHERE 
                            deleted_at IS NULL";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StudentsTable.DataSource = dt;

                    // Set custom column headers
                    StudentsTable.Columns["student_id"].HeaderText = "Student ID";
                    StudentsTable.Columns["student_fname"].HeaderText = "First Name";
                    StudentsTable.Columns["student_lname"].HeaderText = "Last Name";
                    StudentsTable.Columns["age"].HeaderText = "Age";
                    StudentsTable.Columns["email"].HeaderText = "Email";
                    StudentsTable.Columns["phone"].HeaderText = "Phone Number";
                    StudentsTable.Columns["address"].HeaderText = "Address";
                    StudentsTable.Columns["student_number"].HeaderText = "Student Number";
                    StudentsTable.Columns["total_tuition"].HeaderText = "Total Tuition (₱)";
                    StudentsTable.Columns["outstanding_balance"].HeaderText = "Outstanding Balance (₱)";

                    // Make column headers bold
                    StudentsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust the DataGridView height based on the number of rows
                    int maxHeight = 900; // You can set this to any value you want
                    int desiredHeight = StudentsTable.ColumnHeadersHeight +
                        StudentsTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    // Set the height of the DataGridView (but not beyond maxHeight)
                    StudentsTable.Height = Math.Min(desiredHeight, maxHeight);

                    // Enable vertical scroll if the content exceeds the max height
                    StudentsTable.ScrollBars = ScrollBars.Vertical;

                    StudentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load data: " + ex.Message);
                }
            }
        }

        private void phone_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddStudentToDatabase()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                INSERT INTO students 
                    (student_fname, student_lname, age, email, phone, address, student_number) 
                VALUES 
                    (@FirstName, @LastName, @Age, @Email, @Phone, @Address, @StudentNumber)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", fname.Text);
                    cmd.Parameters.AddWithValue("@LastName", lname.Text);
                    cmd.Parameters.AddWithValue("@Age", age.Value);
                    cmd.Parameters.AddWithValue("@Email", email.Text);
                    cmd.Parameters.AddWithValue("@Phone", phone.Text);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@StudentNumber", student_no.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added successfully!");

                    LoadStudentsIntoGrid(); // Refresh the grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding student: " + ex.Message);
                }
            }
        }
        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void student_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (StudentsTable.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(StudentsTable.CurrentRow.Cells["student_id"].Value);
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
                    string query = "UPDATE students SET deleted_at = NOW() WHERE student_id = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Row deleted successfully.");
                    LoadStudentsIntoGrid(); // Refresh the table
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (StudentsTable.CurrentRow != null)
            {
                int studentId = Convert.ToInt32(StudentsTable.CurrentRow.Cells["student_id"].Value);
                string fname = StudentsTable.CurrentRow.Cells["student_fname"].Value.ToString();
                string lname = StudentsTable.CurrentRow.Cells["student_lname"].Value.ToString();
                int age = Convert.ToInt32(StudentsTable.CurrentRow.Cells["age"].Value);
                string email = StudentsTable.CurrentRow.Cells["email"].Value.ToString();
                string phone = StudentsTable.CurrentRow.Cells["phone"].Value.ToString();
                string address = StudentsTable.CurrentRow.Cells["address"].Value.ToString();
                string studentNumber = StudentsTable.CurrentRow.Cells["student_number"].Value.ToString();

                EditStudent editForm = new EditStudent(studentId, fname, lname, age, email, phone, address, studentNumber);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadStudentsIntoGrid(); // Refresh data
                }
            }
            else
            {
                MessageBox.Show("Please select a student to edit.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadStudentsIntoGrid();
            }
            else
            {
                SearchStudents(txtSearch.Text);
            }
        }

        private void SearchStudents(string keyword)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    student_id, 
                    student_fname, 
                    student_lname, 
                    age, 
                    email, 
                    phone, 
                    address, 
                    student_number,
                    GetTotalTuition(student_id) AS total_tuition,
                    GetOutstandingBalance(student_id) AS outstanding_balance
                FROM 
                    students
                WHERE 
                    deleted_at IS NULL
                    AND (
                        CAST(student_id AS CHAR) LIKE @keyword OR
                        student_fname LIKE @keyword OR
                        student_lname LIKE @keyword OR
                        email LIKE @keyword OR
                        phone LIKE @keyword OR
                        student_number LIKE @keyword
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    StudentsTable.DataSource = dt;

                    // Re-apply column headers (optional, based on your existing LoadStudentsIntoGrid)
                    StudentsTable.Columns["student_id"].HeaderText = "Student ID";
                    StudentsTable.Columns["student_fname"].HeaderText = "First Name";
                    StudentsTable.Columns["student_lname"].HeaderText = "Last Name";
                    StudentsTable.Columns["age"].HeaderText = "Age";
                    StudentsTable.Columns["email"].HeaderText = "Email";
                    StudentsTable.Columns["phone"].HeaderText = "Phone Number";
                    StudentsTable.Columns["address"].HeaderText = "Address";
                    StudentsTable.Columns["student_number"].HeaderText = "Student Number";
                    StudentsTable.Columns["total_tuition"].HeaderText = "Total Tuition (₱)";
                    StudentsTable.Columns["outstanding_balance"].HeaderText = "Outstanding Balance (₱)";

                    StudentsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    StudentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    int maxHeight = 900;
                    int desiredHeight = StudentsTable.ColumnHeadersHeight +
                        StudentsTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
                    StudentsTable.Height = Math.Min(desiredHeight, maxHeight);
                    StudentsTable.ScrollBars = ScrollBars.Vertical;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string templatePath = Path.Combine(Application.StartupPath, "reportTemplate", "students_template.xlsx");

            if (!File.Exists(templatePath))
            {
                MessageBox.Show($"Template file not found:\n{templatePath}", "Missing Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string folderPath = Path.Combine(Application.StartupPath, "generatedreports");
            Directory.CreateDirectory(folderPath); // Ensure folder exists

            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd-HH-mm-ss");
            string newFileName = $"students-report-{formattedDate}.xlsx";
            string outputPath = Path.Combine(folderPath, newFileName);

            ExportToExcelTemplate(StudentsTable, templatePath, outputPath);
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
