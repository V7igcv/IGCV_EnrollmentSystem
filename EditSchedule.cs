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
    public partial class EditSchedule : Form
    {
        private int scheduleId;
        public EditSchedule(int scheduleId, int courseId, int instructorId, string dayOfWeek, TimeSpan startTime, TimeSpan endTime)
        {
            InitializeComponent();
            this.scheduleId = scheduleId;

            // Load dropdowns
            DatabaseHelper.LoadCoursesIntoComboBox(cmbCourses);
            DatabaseHelper.LoadInstructorsIntoComboBox(cmbInstructors);
            LoadDayOfWeek();

            // Prefill data
            cmbCourses.SelectedValue = courseId;
            cmbInstructors.SelectedValue = instructorId;
            dayofweek.SelectedItem = dayOfWeek;
            starttime.Format = DateTimePickerFormat.Time;
            starttime.ShowUpDown = true;
            starttime.Value = DateTime.Today.Add(startTime);

            endtime.Format = DateTimePickerFormat.Time;
            endtime.ShowUpDown = true;
            endtime.Value = DateTime.Today.Add(endTime);
        }

        private void LoadDayOfWeek()
        {
            dayofweek.Items.AddRange(new string[]
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=enrollment;port=3306;password=villamecantos974;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE schedules 
                                     SET course_id = @CourseId, 
                                         instructor_id = @InstructorId, 
                                         day_of_week = @DayOfWeek, 
                                         start_time = @StartTime, 
                                         end_time = @EndTime,
                                         modified_at = NOW()
                                     WHERE schedule_id = @ScheduleId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseId", cmbCourses.SelectedValue);
                    cmd.Parameters.AddWithValue("@InstructorId", cmbInstructors.SelectedValue);
                    cmd.Parameters.AddWithValue("@DayOfWeek", dayofweek.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@StartTime", starttime.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@EndTime", endtime.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@ScheduleId", scheduleId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Schedule updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating schedule: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
