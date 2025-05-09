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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace EDP_WinProject102
{
    public partial class frmDepartments : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmDepartments()
        {
            InitializeComponent();
            LoadDepartmentsIntoGrid();
            this.Load += frmDepartments_Load;
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void LoadDepartmentsIntoGrid()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT department_id, department_name FROM departments WHERE deleted_at IS NULL";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DepartmentsTable.DataSource = dt;

                    // Set custom column headers
                    DepartmentsTable.Columns["department_id"].HeaderText = "Department ID";
                    DepartmentsTable.Columns["department_name"].HeaderText = "Depratment Name";

                    // Make column headers bold
                    DepartmentsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust the DataGridView height based on the number of rows
                    int maxHeight = 600; // You can set this to any value you want
                    int desiredHeight = DepartmentsTable.ColumnHeadersHeight +
                        DepartmentsTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    // Set the height of the DataGridView (but not beyond maxHeight)
                    DepartmentsTable.Height = Math.Min(desiredHeight, maxHeight);

                    // Enable vertical scroll if the content exceeds the max height
                    DepartmentsTable.ScrollBars = ScrollBars.Vertical;

                    DepartmentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load data: " + ex.Message);
                }
            }
        }

        private void AddDepartmentToDatabase()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                INSERT INTO departments 
                    (department_name) 
                VALUES 
                    (@DeptName)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DeptName", department.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department added successfully!");

                    LoadDepartmentsIntoGrid(); // Refresh the grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding department: " + ex.Message);
                }
            }
        }

        private void SubmitDept_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(department.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            AddDepartmentToDatabase();
        }

        private void btnDeleteDept_Click(object sender, EventArgs e)
        {
            if (DepartmentsTable.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(DepartmentsTable.CurrentRow.Cells["department_id"].Value);
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
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE departments SET deleted_at = NOW() WHERE department_id = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Row deleted successfully.");
                    LoadDepartmentsIntoGrid(); // Refresh the table
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
                LoadDepartmentsIntoGrid();
            }
            else
            {
                SearchDepartments(txtSearch.Text);
            }
        }

        private void SearchDepartments(string keyword)
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    department_id, 
                    department_name 
                FROM 
                    departments 
                WHERE 
                    deleted_at IS NULL AND (
                        CAST(department_id AS CHAR) LIKE @keyword
                        OR department_name LIKE @keyword
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DepartmentsTable.DataSource = dt;

                    // Set custom column headers
                    DepartmentsTable.Columns["department_id"].HeaderText = "Department ID";
                    DepartmentsTable.Columns["department_name"].HeaderText = "Department Name";

                    // Style the headers
                    DepartmentsTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
                    DepartmentsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }
    }
}
