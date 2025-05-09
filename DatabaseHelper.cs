using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace EDP_WinProject102
{
    internal class DatabaseHelper
    {
        public static void LoadDepartmentsIntoComboBox(ComboBox comboBox)
        {
            LoadDataIntoComboBox(comboBox,
                "SELECT department_id, department_name FROM departments WHERE deleted_at IS NULL",
                "department_name", "department_id");
        }

        public static void LoadStudentsIntoComboBox(ComboBox comboBox)
        {
            LoadDataIntoComboBox(comboBox,
                "SELECT student_id, CONCAT(student_fname, ' ', student_lname) AS full_name FROM students WHERE deleted_at IS NULL",
                "full_name", "student_id");
        }

        public static void LoadCoursesIntoComboBox(ComboBox comboBox)
        {
            LoadDataIntoComboBox(comboBox,
                "SELECT course_id, course_name FROM courses WHERE deleted_at IS NULL",
                "course_name", "course_id");
        }

        public static void LoadInstructorsIntoComboBox(ComboBox comboBox)
        {
            LoadDataIntoComboBox(comboBox,
                "SELECT instructor_id, CONCAT(instructor_fname, ' ', instructor_lname) AS full_name FROM instructors WHERE deleted_at IS NULL",
                "full_name", "instructor_id");
        }

        // Generic method to reduce repetition
        private static void LoadDataIntoComboBox(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            using (MySqlConnection conn = new DBManager().GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBox.DisplayMember = displayMember;
                    comboBox.ValueMember = valueMember;
                    comboBox.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
