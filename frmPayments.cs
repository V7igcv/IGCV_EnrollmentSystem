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

namespace EDP_WinProject102
{
    public partial class frmPayments : Form
    {
        private readonly DBManager dbManager = new DBManager();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmPayments()
        {
            InitializeComponent();
            LoadPaymentsIntoGrid();
            this.Load += frmPayments_Load;
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LoadPaymentsIntoGrid()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    p.payment_id, 
                    CONCAT(s.student_fname, ' ', s.student_lname) AS full_name, 
                    p.amount_paid, 
                    p.payment_date, 
                    tf.academic_year
                FROM payments p
                JOIN students s ON p.student_id = s.student_id
                JOIN tuition_fees tf ON p.fee_id = tf.fee_id
                WHERE s.deleted_at IS NULL AND tf.deleted_at IS NULL";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    PaymentsTable.DataSource = dt;

                    // Set custom column headers
                    PaymentsTable.Columns["payment_id"].HeaderText = "Payment ID";
                    PaymentsTable.Columns["full_name"].HeaderText = "Student Name";
                    PaymentsTable.Columns["amount_paid"].HeaderText = "Amount Paid (₱)";
                    PaymentsTable.Columns["payment_date"].HeaderText = "Payment Date";
                    PaymentsTable.Columns["academic_year"].HeaderText = "Academic Year";

                    // Make column headers bold
                    PaymentsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust DataGridView height
                    int maxHeight = 600;
                    int desiredHeight = PaymentsTable.ColumnHeadersHeight +
                        PaymentsTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    PaymentsTable.Height = Math.Min(desiredHeight, maxHeight);
                    PaymentsTable.ScrollBars = ScrollBars.Vertical;
                    PaymentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load payments data: " + ex.Message);
                }
            }
        }

        private void SubmitPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(student_no.Text) || string.IsNullOrWhiteSpace(course.Text) || string.IsNullOrWhiteSpace(amount.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!decimal.TryParse(amount.Text, out decimal amountPaid))
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            AddPaymentToDatabase(student_no.Text.Trim(), course.Text.Trim(), amountPaid);
        }

        private void AddPaymentToDatabase(string studentNumber, string courseName, decimal amountPaid)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Get student_id from student_number
                    string getStudentIdQuery = "SELECT student_id FROM students WHERE student_number = @studentNumber AND deleted_at IS NULL";
                    MySqlCommand cmd1 = new MySqlCommand(getStudentIdQuery, conn);
                    cmd1.Parameters.AddWithValue("@studentNumber", studentNumber);
                    object studentIdObj = cmd1.ExecuteScalar();

                    if (studentIdObj == null)
                    {
                        MessageBox.Show("Student not found.");
                        return;
                    }
                    int studentId = Convert.ToInt32(studentIdObj);

                    // 2. Get course_id from course_name
                    string getCourseIdQuery = "SELECT course_id FROM courses WHERE course_name = @courseName AND deleted_at IS NULL";
                    MySqlCommand cmd2 = new MySqlCommand(getCourseIdQuery, conn);
                    cmd2.Parameters.AddWithValue("@courseName", courseName);
                    object courseIdObj = cmd2.ExecuteScalar();

                    if (courseIdObj == null)
                    {
                        MessageBox.Show("Course not found.");
                        return;
                    }
                    int courseId = Convert.ToInt32(courseIdObj);

                    // 3. Check if student is enrolled in the course
                    string enrollmentCheckQuery = @"
                SELECT enrollment_id FROM enrollments 
                WHERE student_id = @studentId AND course_id = @courseId AND deleted_at IS NULL";
                    MySqlCommand cmd3 = new MySqlCommand(enrollmentCheckQuery, conn);
                    cmd3.Parameters.AddWithValue("@studentId", studentId);
                    cmd3.Parameters.AddWithValue("@courseId", courseId);
                    object enrollmentIdObj = cmd3.ExecuteScalar();

                    if (enrollmentIdObj == null)
                    {
                        MessageBox.Show("This student is not enrolled in the specified course.");
                        return;
                    }

                    // 4. Get the fee_id for the course
                    string getFeeIdQuery = "SELECT fee_id FROM tuition_fees WHERE course_id = @courseId AND deleted_at IS NULL LIMIT 1";
                    MySqlCommand cmd4 = new MySqlCommand(getFeeIdQuery, conn);
                    cmd4.Parameters.AddWithValue("@courseId", courseId);
                    object feeIdObj = cmd4.ExecuteScalar();

                    if (feeIdObj == null)
                    {
                        MessageBox.Show("No tuition fee found for this course.");
                        return;
                    }
                    int feeId = Convert.ToInt32(feeIdObj);

                    // 5. Insert payment record
                    string insertPaymentQuery = @"
                INSERT INTO payments (student_id, amount_paid, payment_date, fee_id, modified_at)
                VALUES (@studentId, @amountPaid, @paymentDate, @feeId, NOW())";
                    MySqlCommand insertCmd = new MySqlCommand(insertPaymentQuery, conn);
                    insertCmd.Parameters.AddWithValue("@studentId", studentId);
                    insertCmd.Parameters.AddWithValue("@amountPaid", amountPaid);
                    insertCmd.Parameters.AddWithValue("@paymentDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    insertCmd.Parameters.AddWithValue("@feeId", feeId);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Payment recorded successfully.");
                        LoadPaymentsIntoGrid(); // Refresh DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to record payment.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            if (PaymentsTable.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(PaymentsTable.CurrentRow.Cells["payment_id"].Value);
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
                    string query = "UPDATE payments SET deleted_at = NOW() WHERE payment_id = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Row deleted successfully.");
                    LoadPaymentsIntoGrid(); // Refresh the table
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
                LoadPaymentsIntoGrid();
            }
            else
            {
                SearchPayments(txtSearch.Text);
            }
        }

        private void SearchPayments(string keyword)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    p.payment_id, 
                    CONCAT(s.student_fname, ' ', s.student_lname) AS full_name, 
                    p.amount_paid, 
                    p.payment_date, 
                    tf.academic_year
                FROM payments p
                JOIN students s ON p.student_id = s.student_id
                JOIN tuition_fees tf ON p.fee_id = tf.fee_id
                WHERE 
                    s.deleted_at IS NULL AND tf.deleted_at IS NULL AND (
                        CAST(p.payment_id AS CHAR) LIKE @keyword OR
                        CONCAT(s.student_fname, ' ', s.student_lname) LIKE @keyword OR
                        CAST(p.amount_paid AS CHAR) LIKE @keyword OR
                        p.payment_date LIKE @keyword OR
                        tf.academic_year LIKE @keyword
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    PaymentsTable.DataSource = dt;

                    // Set custom column headers
                    PaymentsTable.Columns["payment_id"].HeaderText = "Payment ID";
                    PaymentsTable.Columns["full_name"].HeaderText = "Student Name";
                    PaymentsTable.Columns["amount_paid"].HeaderText = "Amount Paid (₱)";
                    PaymentsTable.Columns["payment_date"].HeaderText = "Payment Date";
                    PaymentsTable.Columns["academic_year"].HeaderText = "Academic Year";

                    PaymentsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    PaymentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }
    }
}
