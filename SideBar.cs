﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDP_WinProject102;

namespace EDP_WinProject102
{
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
        }

        private void SideBar_Load(object sender, EventArgs e)
        {

        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            frmStudents myStudents = new frmStudents();
            myStudents.Show();
            this.FindForm().Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard myform = new frmDashboard();
            myform.Show();
            this.FindForm().Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session data if used
            Session.Clear();

            // Confirm logout (optional)
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin loginForm = new frmLogin();
                loginForm.Show();

                // Close the parent form of the sidebar (assumes it's hosted in a form)
                Form parentForm = this.FindForm();
                parentForm?.Close();
            }
        }

        private void btnEnrollments_Click(object sender, EventArgs e)
        {
            frmEnrollments myEnrollment = new frmEnrollments();
            myEnrollment.Show();
            this.FindForm().Hide();
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            frmGrades myGrades = new frmGrades();
            myGrades.Show();
            this.FindForm().Hide();
        }

        private void btnTuition_Click(object sender, EventArgs e)
        {
            frmTuitions myTuitions = new frmTuitions();
            myTuitions.Show();
            this.FindForm().Hide();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            frmPayments myPayments = new frmPayments();
            myPayments.Show();
            this.FindForm().Hide();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            frmCourses myCourses = new frmCourses();
            myCourses.Show();
            this.FindForm().Hide();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            frmDepartments myDepartments = new frmDepartments();
            myDepartments.Show();
            this.FindForm().Hide();
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            frmInstructors myInstructors = new frmInstructors();
            myInstructors.Show();
            this.FindForm().Hide();
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            frmSchedules mySchedules = new frmSchedules();
            mySchedules.Show();
            this.FindForm().Hide();
        }

        private void btnEvaluations_Click(object sender, EventArgs e)
        {
            frmEvaluations myEvaluations = new frmEvaluations();
            myEvaluations.Show();
            this.FindForm().Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSystemUsers mySystemUsers = new frmSystemUsers();
            mySystemUsers.Show();
            this.FindForm().Hide();
        }
    }
}
