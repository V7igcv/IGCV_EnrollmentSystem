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
    public partial class frmSystemUsers : Form
    {
        private readonly DBManager dbManager = new DBManager();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmSystemUsers()
        {
            InitializeComponent();
            LoadUsersIntoGrid();
            this.Load += frmSystemUsers_Load;
        }

        private void frmSystemUsers_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search...");
        }
        private void LoadUsersIntoGrid()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, first_name, last_name, email, recovery_birthdate FROM users WHERE deleted_at IS NULL";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    systemUsersTable.DataSource = dt;

                    // Set custom column headers
                    systemUsersTable.Columns["id"].HeaderText = "User ID";
                    systemUsersTable.Columns["first_name"].HeaderText = "First Name";
                    systemUsersTable.Columns["last_name"].HeaderText = "Last Name";
                    systemUsersTable.Columns["email"].HeaderText = "Email";
                    systemUsersTable.Columns["recovery_birthdate"].HeaderText = "Birthdate";

                    // Make column headers bold
                    systemUsersTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust the DataGridView height based on the number of rows
                    int maxHeight = 600; // You can set this to any value you want
                    int desiredHeight = systemUsersTable.ColumnHeadersHeight +
                        systemUsersTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    // Set the height of the DataGridView (but not beyond maxHeight)
                    systemUsersTable.Height = Math.Min(desiredHeight, maxHeight);

                    // Enable vertical scroll if the content exceeds the max height
                    systemUsersTable.ScrollBars = ScrollBars.Vertical;

                    systemUsersTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load data: " + ex.Message);
                }
            }
        }
        private void AddUserToDatabase()
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO users (first_name, last_name, email, password, recovery_birthdate, created_at)
                                     VALUES (@FirstName, @LastName, @Email, @Password, @RecoveryBirthdate, NOW())";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // You might want to hash the password before storing it
                    cmd.Parameters.AddWithValue("@RecoveryBirthdate", dtpBirthdate.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User added successfully!");

                    // Reload the users into the DataGridView to show the new entry
                    LoadUsersIntoGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding user: " + ex.Message);
                }
            }
        }

        private void SubmitUser_Click(object sender, EventArgs e)
        {
            // Make sure all fields are filled
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }

            // Call the method to insert the user into the database
            AddUserToDatabase();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (systemUsersTable.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected user?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(systemUsersTable.CurrentRow.Cells["id"].Value);
                    SoftDeleteUser(userId);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void SoftDeleteUser(int userId)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE users SET deleted_at = NOW() WHERE id = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User deleted successfully.");
                    LoadUsersIntoGrid(); // Refresh the table
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting user: " + ex.Message);
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (systemUsersTable.CurrentRow != null)
            {
                EditSystemUser editForm = new EditSystemUser
                {
                    UserId = Convert.ToInt32(systemUsersTable.CurrentRow.Cells["id"].Value),
                    FirstName = systemUsersTable.CurrentRow.Cells["first_name"].Value.ToString(),
                    LastName = systemUsersTable.CurrentRow.Cells["last_name"].Value.ToString(),
                    Email = systemUsersTable.CurrentRow.Cells["email"].Value.ToString(),
                    Birthdate = Convert.ToDateTime(systemUsersTable.CurrentRow.Cells["recovery_birthdate"].Value)
                };

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsersIntoGrid(); // Refresh table after editing
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadUsersIntoGrid();
            }
            else
            {
                SearchUsers(txtSearch.Text);
            }
        }

        private void SearchUsers(string keyword)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT id, first_name, last_name, email, recovery_birthdate
                             FROM users
                             WHERE deleted_at IS NULL
                               AND (CAST(id AS CHAR) LIKE @keyword
                                    OR first_name LIKE @keyword
                                    OR last_name LIKE @keyword
                                    OR email LIKE @keyword
                                    OR DATE_FORMAT(recovery_birthdate, '%Y-%m-%d') LIKE @keyword)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    systemUsersTable.DataSource = dt;

                    // Optionally reset column headers again (if needed)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message);
                }
            }
        }
    }
}
