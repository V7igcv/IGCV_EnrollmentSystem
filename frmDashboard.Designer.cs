namespace EDP_WinProject102
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel12 = new System.Windows.Forms.Panel();
            this.topBar1 = new EDP_WinProject102.TopBar();
            this.label5 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.InstructorPerDepartmentTable = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.TInstructors = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.TCourses = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.TStudents = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.StudentPerCourseTable = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.TEnrollments = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sideBar1 = new EDP_WinProject102.SideBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StudentsEnrollmentsTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel12.SuspendLayout();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstructorPerDepartmentTable)).BeginInit();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentPerCourseTable)).BeginInit();
            this.panel14.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsEnrollmentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel12.Controls.Add(this.panel1);
            this.panel12.Controls.Add(this.topBar1);
            this.panel12.Controls.Add(this.label5);
            this.panel12.Controls.Add(this.panel19);
            this.panel12.Controls.Add(this.panel17);
            this.panel12.Controls.Add(this.panel16);
            this.panel12.Controls.Add(this.panel15);
            this.panel12.Controls.Add(this.panel18);
            this.panel12.Controls.Add(this.panel14);
            this.panel12.Location = new System.Drawing.Point(201, 0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel12.Size = new System.Drawing.Size(1100, 837);
            this.panel12.TabIndex = 1;
            this.panel12.Paint += new System.Windows.Forms.PaintEventHandler(this.panel12_Paint);
            // 
            // topBar1
            // 
            this.topBar1.Location = new System.Drawing.Point(0, 0);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1097, 84);
            this.topBar1.TabIndex = 8;
            this.topBar1.Load += new System.EventHandler(this.topBar1_Load);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 40);
            this.label5.TabIndex = 7;
            this.label5.Text = "DASHBOARD";
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel19.Controls.Add(this.InstructorPerDepartmentTable);
            this.panel19.Controls.Add(this.label15);
            this.panel19.Location = new System.Drawing.Point(50, 437);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(1012, 352);
            this.panel19.TabIndex = 6;
            // 
            // InstructorPerDepartmentTable
            // 
            this.InstructorPerDepartmentTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructorPerDepartmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InstructorPerDepartmentTable.Location = new System.Drawing.Point(15, 53);
            this.InstructorPerDepartmentTable.Name = "InstructorPerDepartmentTable";
            this.InstructorPerDepartmentTable.RowHeadersWidth = 51;
            this.InstructorPerDepartmentTable.RowTemplate.Height = 24;
            this.InstructorPerDepartmentTable.Size = new System.Drawing.Size(983, 283);
            this.InstructorPerDepartmentTable.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(190, 24);
            this.label15.TabIndex = 13;
            this.label15.Text = "Instructors per Department";
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel17.Controls.Add(this.TInstructors);
            this.panel17.Controls.Add(this.label9);
            this.panel17.Location = new System.Drawing.Point(302, 296);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(229, 120);
            this.panel17.TabIndex = 3;
            // 
            // TInstructors
            // 
            this.TInstructors.AutoSize = true;
            this.TInstructors.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TInstructors.Location = new System.Drawing.Point(177, 63);
            this.TInstructors.Name = "TInstructors";
            this.TInstructors.Size = new System.Drawing.Size(31, 40);
            this.TInstructors.TabIndex = 12;
            this.TInstructors.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 24);
            this.label9.TabIndex = 10;
            this.label9.Text = "Total Instructors";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel16.Controls.Add(this.TCourses);
            this.panel16.Controls.Add(this.label7);
            this.panel16.Location = new System.Drawing.Point(302, 159);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(229, 120);
            this.panel16.TabIndex = 2;
            // 
            // TCourses
            // 
            this.TCourses.AutoSize = true;
            this.TCourses.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCourses.Location = new System.Drawing.Point(177, 66);
            this.TCourses.Name = "TCourses";
            this.TCourses.Size = new System.Drawing.Size(31, 40);
            this.TCourses.TabIndex = 11;
            this.TCourses.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total Courses";
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel15.Controls.Add(this.TStudents);
            this.panel15.Controls.Add(this.label8);
            this.panel15.Location = new System.Drawing.Point(50, 296);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(229, 120);
            this.panel15.TabIndex = 2;
            // 
            // TStudents
            // 
            this.TStudents.AutoSize = true;
            this.TStudents.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TStudents.Location = new System.Drawing.Point(169, 63);
            this.TStudents.Name = "TStudents";
            this.TStudents.Size = new System.Drawing.Size(31, 40);
            this.TStudents.TabIndex = 10;
            this.TStudents.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 24);
            this.label8.TabIndex = 9;
            this.label8.Text = "Total Students";
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel18.Controls.Add(this.StudentPerCourseTable);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Location = new System.Drawing.Point(566, 159);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(496, 257);
            this.panel18.TabIndex = 5;
            // 
            // StudentPerCourseTable
            // 
            this.StudentPerCourseTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StudentPerCourseTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentPerCourseTable.Location = new System.Drawing.Point(16, 57);
            this.StudentPerCourseTable.Name = "StudentPerCourseTable";
            this.StudentPerCourseTable.RowHeadersWidth = 51;
            this.StudentPerCourseTable.RowTemplate.Height = 24;
            this.StudentPerCourseTable.Size = new System.Drawing.Size(466, 184);
            this.StudentPerCourseTable.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(179, 24);
            this.label14.TabIndex = 12;
            this.label14.Text = "Total Students per Course";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel14.Controls.Add(this.TEnrollments);
            this.panel14.Controls.Add(this.label6);
            this.panel14.Location = new System.Drawing.Point(50, 159);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(229, 120);
            this.panel14.TabIndex = 1;
            // 
            // TEnrollments
            // 
            this.TEnrollments.AutoSize = true;
            this.TEnrollments.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEnrollments.Location = new System.Drawing.Point(169, 57);
            this.TEnrollments.Name = "TEnrollments";
            this.TEnrollments.Size = new System.Drawing.Size(31, 40);
            this.TEnrollments.TabIndex = 9;
            this.TEnrollments.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total Enrollments";
            // 
            // sideBar1
            // 
            this.sideBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.sideBar1.Location = new System.Drawing.Point(0, 1);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(203, 831);
            this.sideBar1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.StudentsEnrollmentsTable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(50, 811);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 352);
            this.panel1.TabIndex = 15;
            // 
            // StudentsEnrollmentsTable
            // 
            this.StudentsEnrollmentsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StudentsEnrollmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentsEnrollmentsTable.Location = new System.Drawing.Point(15, 53);
            this.StudentsEnrollmentsTable.Name = "StudentsEnrollmentsTable";
            this.StudentsEnrollmentsTable.RowHeadersWidth = 51;
            this.StudentsEnrollmentsTable.RowTemplate.Height = 24;
            this.StudentsEnrollmentsTable.Size = new System.Drawing.Size(983, 283);
            this.StudentsEnrollmentsTable.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Students Enrollments";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.sideBar1);
            this.Controls.Add(this.panel12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enrollment Dashbaord";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstructorPerDepartmentTable)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentPerCourseTable)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsEnrollmentsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TInstructors;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label TCourses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TStudents;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label TEnrollments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView StudentPerCourseTable;
        private SideBar sideBar1;
        private TopBar topBar1;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.DataGridView InstructorPerDepartmentTable;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView StudentsEnrollmentsTable;
        private System.Windows.Forms.Label label1;
    }
}

