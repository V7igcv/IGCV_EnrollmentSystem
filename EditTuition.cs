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
    public partial class EditTuition : Form
    {
        private readonly DBManager dbManager = new DBManager();

        private int feeId;
        public EditTuition(int feeId, int courseId, decimal amount, string academicYear)
        {
            InitializeComponent();
            this.feeId = feeId;

            DatabaseHelper.LoadCoursesIntoComboBox(cmbCourse);
            cmbCourse.SelectedValue = courseId;

            txtAmount.Text = amount.ToString("0.00");
            txtAcademicYear.Text = academicYear;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = dbManager.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE tuition_fees 
                                     SET course_id = @CourseId, 
                                         amount = @Amount, 
                                         academic_year = @AcademicYear, 
                                         modified_at = NOW()
                                     WHERE fee_id = @FeeId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseId", cmbCourse.SelectedValue);
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text));
                    cmd.Parameters.AddWithValue("@AcademicYear", txtAcademicYear.Text.Trim());
                    cmd.Parameters.AddWithValue("@FeeId", feeId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Tuition fee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating tuition fee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
