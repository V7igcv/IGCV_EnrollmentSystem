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
    public partial class frmSchedules : Form
    {
        public frmSchedules()
        {
            InitializeComponent();
            LoadSchedulesIntoGrid();
            LoadComboBoxData();
        }

        private void frmSchedules_Load(object sender, EventArgs e)
        {

        }

        private void LoadComboBoxData()
        {
            DatabaseHelper.LoadInstructorsIntoComboBox(instructor);
            DatabaseHelper.LoadCoursesIntoComboBox(course);
            dayofweek.Items.AddRange(new string[]
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            });
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LoadSchedulesIntoGrid()
        {
            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    s.schedule_id,
                    c.course_id,
                    c.course_name,
                    i.instructor_id,
                    CONCAT(i.instructor_fname, ' ', i.instructor_lname) AS instructor_name, 
                    s.day_of_week, 
                    s.start_time, 
                    s.end_time
                FROM schedules s
                JOIN courses c ON s.course_id = c.course_id
                JOIN instructors i ON s.instructor_id = i.instructor_id
                WHERE s.deleted_at IS NULL";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    SchedulesTable.DataSource = dt;

                    // Set custom column headers
                    SchedulesTable.Columns["schedule_id"].HeaderText = "Schedule ID";
                    SchedulesTable.Columns["course_name"].HeaderText = "Course Name";
                    SchedulesTable.Columns["instructor_name"].HeaderText = "Instructor Name";
                    SchedulesTable.Columns["day_of_week"].HeaderText = "Day of Week";
                    SchedulesTable.Columns["start_time"].HeaderText = "Start Time";
                    SchedulesTable.Columns["end_time"].HeaderText = "End Time";
                    SchedulesTable.Columns["course_id"].Visible = false;
                    SchedulesTable.Columns["instructor_id"].Visible = false;

                    // Make column headers bold
                    SchedulesTable.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);

                    // Adjust DataGridView height
                    int maxHeight = 600;
                    int desiredHeight = SchedulesTable.ColumnHeadersHeight +
                        SchedulesTable.Rows.GetRowsHeight(DataGridViewElementStates.Visible);

                    SchedulesTable.Height = Math.Min(desiredHeight, maxHeight);
                    SchedulesTable.ScrollBars = ScrollBars.Vertical;
                    SchedulesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load schedule data: " + ex.Message);
                }
            }
        }

        private void SubmitSchedule_Click(object sender, EventArgs e)
        {
            if (instructor.SelectedValue == null || course.SelectedValue == null || dayofweek.SelectedItem == null)
            {
                MessageBox.Show("Please select an instructor, course, and day.");
                return;
            }

            int instructorId = Convert.ToInt32(instructor.SelectedValue);
            int courseId = Convert.ToInt32(course.SelectedValue);
            string dayOfWeek = dayofweek.SelectedItem.ToString();
            TimeSpan startTime = starttime.Value.TimeOfDay;
            TimeSpan endTime = endtime.Value.TimeOfDay;

            string connectionString = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Check if the instructor is assigned to the course (same department)
                string checkQuery = @"
                    SELECT COUNT(*) FROM instructors i
                    JOIN courses c ON i.department_id = c.department_id
                    WHERE i.instructor_id = @instructorId AND c.course_id = @courseId AND i.deleted_at IS NULL AND c.deleted_at IS NULL";

                using (MySqlCommand cmd = new MySqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@instructorId", instructorId);
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    int matchCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (matchCount == 0)
                    {
                        MessageBox.Show("Instructor is not assigned to this course (different department).");
                        return;
                    }
                }

                // Insert the schedule
                string insertQuery = @"
                    INSERT INTO schedules (course_id, instructor_id, day_of_week, start_time, end_time)
                    VALUES (@courseId, @instructorId, @dayOfWeek, @startTime, @endTime)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    cmd.Parameters.AddWithValue("@instructorId", instructorId);
                    cmd.Parameters.AddWithValue("@dayOfWeek", dayOfWeek);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@endTime", endTime);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Schedule submitted successfully.");
                    LoadSchedulesIntoGrid(); // Refresh grid
                }
            }
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (SchedulesTable.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(SchedulesTable.CurrentRow.Cells["schedule_id"].Value);
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
                    string query = "UPDATE schedules SET deleted_at = NOW() WHERE schedule_id = @UserId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Row deleted successfully.");
                    LoadSchedulesIntoGrid(); // Refresh the table
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SchedulesTable.SelectedRows.Count > 0)
            {
                DataGridViewRow row = SchedulesTable.SelectedRows[0];

                int scheduleId = Convert.ToInt32(row.Cells["schedule_id"].Value);
                int courseId = Convert.ToInt32(row.Cells["course_id"].Value);
                int instructorId = Convert.ToInt32(row.Cells["instructor_id"].Value);
                string dayOfWeek = row.Cells["day_of_week"].Value.ToString();
                TimeSpan startTime = (TimeSpan)row.Cells["start_time"].Value;
                TimeSpan endTime = (TimeSpan)row.Cells["end_time"].Value;

                EditSchedule editForm = new EditSchedule(scheduleId, courseId, instructorId, dayOfWeek, startTime, endTime);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSchedulesIntoGrid(); // Refresh DataGridView
                }
            }
            else
            {
                MessageBox.Show("Please select a schedule to edit.");
            }
        }
    }
}
